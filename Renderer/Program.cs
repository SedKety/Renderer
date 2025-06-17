using System.Drawing;
using System;
using Renderer.DataTypes;
using System.Security.Cryptography;

namespace Renderer
{
    internal class Program
    {
        const int PpmWidth = 124;
        const int PpmHeight = PpmWidth;
        const int FrameCount = 1;
        static void Main(string[] args)
        {
            Renderer.CreateRender(PpmWidth, PpmHeight, FrameCount);
        }
        
    }
}
