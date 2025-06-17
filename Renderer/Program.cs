using System.Drawing;
using System;
using Renderer.DataTypes;
using System.Security.Cryptography;

namespace Renderer
{
    internal class Program
    {
        const int PmmWidth = 512;
        const int PmmHeight = PmmWidth;
        const int FrameCount = 1;
        static void Main()
        {
            Renderer.CreateRender(PmmWidth, PmmHeight, FrameCount);
        }
        
    }
}
