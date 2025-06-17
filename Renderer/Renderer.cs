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
        public static void CreateRender(int pmmWidth, int pmmHeight, int frameCount, string path = null)
        {
            int3[,] pixelBuffer = new int3[pmmWidth, pmmHeight];

            List<TwoDimensionalTriangle> triangles = new List<TwoDimensionalTriangle>();

            #region Objects to render

            var gridSizes = new float2(pmmWidth, pmmHeight);

            var triCount = 32;
            for (int i = 0; i < triCount; i++)
            {
                triangles.Add(TwoDimensionalTriangle.CreateRandomTriangle(
                    new float2(
                        Random.Shared.Next(0, pmmWidth),
                        Random.Shared.Next(0, pmmHeight)
                    ),
                    gridSizes,
                   Random.Shared.Next(32, 128) / 1000f
                ));
            }

            var faceCount = 32;
            Face[] faces = new Face[faceCount];

            for (int i = 0; i < faceCount; i++)
            {
                faces[i] = Face.CreateRandomFace(
                    new float2(
                        Random.Shared.Next(0, pmmWidth),
                        Random.Shared.Next(0, pmmHeight)
                    ),
                    Random.Shared.Next(32, 64)
                );
            }

            foreach (var face in faces)
            {
                triangles.AddRange(face.tris);
            }

            #endregion


            for (int i = 0; i < frameCount; i++)
            {
                //Use of the ternary operator to decide whether or not to generate a new path for the ppm file, or use the set one
                var curPath = path != null ? path : $"Output{i}.pmm";

                StreamWriter ppmFile = new StreamWriter(curPath);

                #region PMM BoilerPlate
                //The magic number making it so the ppm's numbers will be recognised as whole numbers, instead of bytes(code P6)
                ppmFile.WriteLine("P3");

                //Specifying the width and height of the ppm image
                ppmFile.WriteLine($"{pmmWidth} {pmmHeight}");

                //The maximum color value, which is 255 for RGB
                ppmFile.WriteLine(255);
                ppmFile.WriteLine();
                #endregion

                var curPixelPos = new float2(0, 0);
                int3 pixelColor = new int3(0, 0, 0);
                //The y value of the grid(aka the height)
                for (int y = 0; y < pmmHeight; y++)
                {
                    //The x value of the grid(aka the width)
                    for (int x = 0; x < pmmWidth; x++)
                    {
                        curPixelPos.x = x;
                        curPixelPos.y = y;

                        bool isInTriangle = false;
                        for (int o = 0; o < triangles.Count; o++)
                        {
                            if (TwoDimensionalTriangle.IsPixelInTriangle(triangles[o], curPixelPos))
                            {
                                isInTriangle = true;
                                pixelColor = triangles[o].RGB;
                            }
                        }

                        if (isInTriangle)
                        {
                            //If the pixel is in the triangle, set it to the color of the triangle
                            pixelBuffer[x, y] = pixelColor;
                        }
                        else
                        {
                            //If the pixel is not in the triangle, set it to black
                            pixelBuffer[x, y] = new int3(0, 0, 0);
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


    }
}
