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

        public Transform()
        {
            size =      new Vector3D(x: 1.0f, y: 1.0f, z: 1.0f);
            position =  new Vector3D(x: 0.0f, y: 0.0f, z: 0.0f);
            rotation =  new Vector3D(x: 0.0f, y: 0.0f, z: 0.0f);
        }

        public Transform(Vector3D size)
        {
            this.size = size;
            position =  new Vector3D(x: 0.0f, y: 0.0f, z: 0.0f);
            rotation =  new Vector3D(x: 0.0f, y: 0.0f, z: 0.0f);
        }

        public Vector3D Size { get => size; set => size = value; }
        public Vector3D Position { get => position; set => position = value; }
        public Vector3D Rotation { get => rotation; set => rotation = value; }
    }
}