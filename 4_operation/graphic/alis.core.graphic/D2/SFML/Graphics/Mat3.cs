using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.D2.SFML.Graphics
{
    /// <summary>
    ///     <see cref="Mat3" /> is a struct representing a glsl mat3 value
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct Mat3
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Mat3" /> from its components
        /// </summary>
        /// <remarks>
        ///     Arguments are in row-major order
        /// </remarks>
        ////////////////////////////////////////////////////////////
        public Mat3(float a00, float a01, float a02,
            float a10, float a11, float a12,
            float a20, float a21, float a22)
        {
            array[0] = a00;
            array[3] = a01;
            array[6] = a02;
            array[1] = a10;
            array[4] = a11;
            array[7] = a12;
            array[2] = a20;
            array[5] = a21;
            array[8] = a22;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Mat3" /> from a SFML <see cref="Transform" />
        /// </summary>
        /// <param name="transform">A SFML <see cref="Transform" /></param>
        ////////////////////////////////////////////////////////////
        public Mat3(Transform transform)
        {
            array[0] = transform.m00;
            array[3] = transform.m01;
            array[6] = transform.m02;
            array[1] = transform.m10;
            array[4] = transform.m11;
            array[7] = transform.m12;
            array[2] = transform.m20;
            array[5] = transform.m21;
            array[8] = transform.m22;
        }

        // column-major!
        /// <summary>
        ///     The array
        /// </summary>
        private fixed float array[3 * 3];
    }
}