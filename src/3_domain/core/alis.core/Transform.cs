using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public class Transform
    {
        private Vector3D size;

        private Vector3D position;

        private Vector3D rotation;

        public Vector3D Size { get => size; set => size = value; }
        public Vector3D Position { get => position; set => position = value; }
        public Vector3D Rotation { get => rotation; set => rotation = value; }
    }
}