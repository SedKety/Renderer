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
        public TwoDimensionalTriangle(float2 vertAPos, float2 vertBPos, float2 vertCPos)
        {
            this.vertAPos = vertAPos;
            this.vertBPos = vertBPos;
            this.vertCPos = vertCPos;
        }
    }
}
