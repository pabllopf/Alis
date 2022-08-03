using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.D2.SFML.Graphics
{
    /// <summary>
    ///     <see cref="Vec3" /> is a struct represent a glsl vec3 value
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec3
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Implicit cast from <see cref="Vector3f" /> to <see cref="Vec3" />
        /// </summary>
        public static implicit operator Vec3(Vector3f vec)
        {
            return new Vec3(vec);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Vec3" /> from its coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        ////////////////////////////////////////////////////////////
        public Vec3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Vec3" /> from a standard SFML <see cref="Vector3f" />
        /// </summary>
        /// <param name="vec">A standard SFML 3D vector</param>
        ////////////////////////////////////////////////////////////
        public Vec3(Vector3f vec)
        {
            X = vec.X;
            Y = vec.Y;
            Z = vec.Z;
        }

        /// <summary>Horizontal component of the vector</summary>
        public float X;

        /// <summary>Vertical component of the vector</summary>
        public float Y;

        /// <summary>Depth component of the vector</summary>
        public float Z;
    }
}