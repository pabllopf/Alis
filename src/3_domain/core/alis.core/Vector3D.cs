using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public struct Vector3D
    {
        private int x;

        private int y;

        private int z;

        public Vector3D(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Z { get => z; set => z = value; }
    }
}