using Renderer.DataTypes;
using Renderer.DataTypes.Structs;
using Renderer.Maths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renderer
{
    internal static class Renderer
    { 
        public static void CreateRender(int ppmWidth, int ppmHeight, int frameCount, string path = null)
        {
            int3[,] pixelBuffer = new int3[ppmWidth, ppmHeight];

            TwoDimensionalTriangle tri = new TwoDimensionalTriangle(
                new float2(ppmWidth / 2, 0), // Vertex A
                new float2(0, ppmHeight), // Vertex B
                new float2(ppmWidth, ppmHeight)  // Vertex C (different from A and B)
            );



            for (int i = 0; i < frameCount; i++)
            {
                //Use of the ternary operator to decide whether or not to generate a new path for the ppm file, or use the set one
                var curPath = path != null ? path : $"Output{i}.pmm";

                StreamWriter ppmFile = new StreamWriter(curPath);

                #region PPM BoilerPlate
                //The magic number making it so the ppm's numbers will be recognised as whole numbers, instead of bytes(code P6)
                ppmFile.WriteLine("P3");

                //Specifying the width and height of the ppm image
                ppmFile.WriteLine($"{ppmWidth} {ppmHeight}");

                //The maximum color value, which is 255 for RGB
                ppmFile.WriteLine(255);
                ppmFile.WriteLine();
                #endregion

                var curPixelPos = new float2(0, 0);
                //The y value of the grid(aka the height)
                for (int y = 0; y < ppmHeight; y++)
                {
                    //The x value of the grid(aka the width)
                    for (int x = 0; x < ppmWidth; x++)
                    {
                        curPixelPos.x = x;
                        curPixelPos.y = y;

                        if (!IsPixelInTriangle(tri, curPixelPos))
                        {
                            //If the pixel is not in the triangle, set it to black
                            pixelBuffer[x, y] = new int3(0, 0, 0);
                        }
                        else
                        {
                            //If the pixel is in the triangle, set it to white
                            pixelBuffer[x, y] = new int3(255, 255, 255);
                        }


                        //Create a pixel buffer, not used with ppm format. but usefull when ill introduce raylib or some other graphics library

                        ppmFile.Write(pixelBuffer[x, y].r);
                        ppmFile.Write(" ");

                        ppmFile.Write(pixelBuffer[x, y].g);
                        ppmFile.Write(" ");

                        ppmFile.Write(pixelBuffer[x, y].b);
                        ppmFile.Write("   ");

                    }
                    ppmFile.Write("\n");
                }
                ppmFile.Close();

            }
        }

        #region Triangle_Rendering
        //Renders a triangle defined by three vertices, and fills it with the color specified
        private static bool IsPixelInTriangle(TwoDimensionalTriangle tri, float2 pixelPoint)
        {

            bool sideAB = isPointOnRightSideOfLine(tri.vertAPos, tri.vertBPos, pixelPoint);

            bool sideBC = isPointOnRightSideOfLine(tri.vertBPos, tri.vertCPos, pixelPoint);

            bool sideCA = isPointOnRightSideOfLine(tri.vertCPos, tri.vertAPos, pixelPoint);

            return sideAB == sideBC && sideBC == sideCA;
        }

        //Calculates whether or not a point is on the right side of a line defined by two points, 
        private static bool isPointOnRightSideOfLine(float2 a, float2 b, float2 p)
        {
            float2 ap = p - a;
            float2 abPerp = RenderMaths.Perpendicular(b - a);

            return RenderMaths.Dot(ap, abPerp) >= 0;
        }

        #endregion

    }
}
