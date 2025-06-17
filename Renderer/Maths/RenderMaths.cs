using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renderer.DataTypes;
namespace Renderer.Maths
{
    internal static class RenderMaths
    {
        //Calculates the dot product
        public static float Dot(float2 a, float2 b) => a.x * b.x + a.y * b.y;

        //Rotates the vector by 90 degrees counter-clockwise(Even though its not called a vector in my case)
        public static float2 Perpendicular(float2 vec)
        {
            //Returns the perpendicular vector of a
            return new float2(-vec.y, vec.x);
        }

    }
}
