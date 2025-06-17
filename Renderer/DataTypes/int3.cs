using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renderer.DataTypes
{
    internal class int3
    {
        public int x;
        public int y;
        public int z;

        public int r
        {
            get => x;
            set => x = value;
        }
        public int g
        {
            get => y;
            set => y = value;
        }
        public int b
        {
            get => z;
            set => z = value;
        }

        public int3(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
