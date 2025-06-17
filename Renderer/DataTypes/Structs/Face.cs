using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renderer.DataTypes.Structs
{
    internal struct Face
    {
        //The triangles that make up the face
        public TwoDimensionalTriangle[] tris;

        public Face(TwoDimensionalTriangle[] triangles) 
        {
            tris = triangles;
        }

        // Constructor to create a square
        public Face(float2 triA, float2 triangleB, float2 triangleC, float2 triangleD)
        {
            tris = new TwoDimensionalTriangle[2];
            tris[0] =  new TwoDimensionalTriangle(triA, triangleC, triangleD);
            tris[1] = new TwoDimensionalTriangle(triA, triangleB, triangleD);
        }

        public static Face CreateRandomFace(float2 centerPos, float size)
        {
            Face face = new Face();

            face.tris = new TwoDimensionalTriangle[2];
            float2 triA = new float2(centerPos.x - size / 2, centerPos.y - size / 2);
            float2 triB = new float2(centerPos.x + size / 2, centerPos.y - size / 2);
            float2 triC = new float2(centerPos.x - size / 2, centerPos.y + size / 2);
            float2 triD = new float2(centerPos.x + size / 2, centerPos.y + size / 2);
            face.tris[0] = new TwoDimensionalTriangle(triA, triC, triD);
            face.tris[1] = new TwoDimensionalTriangle(triA, triB, triD);
            return face;
        }
    }
}
