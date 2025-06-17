using Renderer.Maths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renderer.DataTypes.Structs
{
    internal struct TwoDimensionalTriangle
    {
        public float2 vertAPos;
        public float2 vertBPos;
        public float2 vertCPos;

        public int3 RGB;
        public TwoDimensionalTriangle(float2 vertAPos, float2 vertBPos, float2 vertCPos)
        {
            this.vertAPos = vertAPos;
            this.vertBPos = vertBPos;
            this.vertCPos = vertCPos;
            RGB = new int3(Random.Shared.Next(0, 256), Random.Shared.Next(0, 256), Random.Shared.Next(0, 256));
        }

        //Renders a triangle defined by three vertices, and fills it with the color specified
        public static bool IsPixelInTriangle(TwoDimensionalTriangle tri, float2 pixelPoint)
        {

            bool sideAB = isPointOnRightSideOfLine(tri.vertAPos, tri.vertBPos, pixelPoint);

            bool sideBC = isPointOnRightSideOfLine(tri.vertBPos, tri.vertCPos, pixelPoint);

            bool sideCA = isPointOnRightSideOfLine(tri.vertCPos, tri.vertAPos, pixelPoint);

            return sideAB == sideBC && sideBC == sideCA;
        }

        //Calculates whether or not a point is on the right side of a line defined by two points, 
        public static bool isPointOnRightSideOfLine(float2 a, float2 b, float2 p)
        {
            float2 ap = p - a;
            float2 abPerp = RenderMaths.Perpendicular(b - a);

            return RenderMaths.Dot(ap, abPerp) >= 0;
        }
        public static TwoDimensionalTriangle CreateRandomTriangle(float2 centerPos, float2 gridSizes,float size)
        {

            float2 vertA = new float2(gridSizes.x / 2 * size, 0) + centerPos; 
            float2 vertB = new float2(0, gridSizes.y * size) + centerPos; 
            float2 vertC = new float2(gridSizes.x * size, gridSizes.y * size) + centerPos;
           
            return new TwoDimensionalTriangle(vertA, vertB, vertC);
        }
    }
}
