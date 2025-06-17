using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renderer.DataTypes
{
    internal class float2 
    {
        public float x;
        public float y;
        public float2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static float2 operator - (float2 a, float2 b)
        {
            float2 result = new float2(a.x - b.x, a.y - b.y);
            return result;
        }

        public static float2 operator +(float2 a, float2 b)
        {
            float2 result = new float2(a.x + b.x, a.y + b.y);
            return result;
        }
    }
}
