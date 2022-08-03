using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.D2.SFML.Graphics
{
    /// <summary>
    ///     <see cref="Mat4" /> is a struct representing a glsl mat4 value
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct Mat4
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Provides easy-access to an identity matrix
        /// </summary>
        /// <remarks>
        ///     Keep in mind that a Mat4 cannot be modified after construction
        /// </remarks>
        ////////////////////////////////////////////////////////////
        public static Mat4 Identity =>
            new Mat4(1, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Mat4" /> from its components
        /// </summary>
        /// <remarks>
        ///     Arguments are in row-major order
        /// </remarks>
        ////////////////////////////////////////////////////////////
        public Mat4(float a00, float a01, float a02, float a03,
            float a10, float a11, float a12, float a13,
            float a20, float a21, float a22, float a23,
            float a30, float a31, float a32, float a33)
        {
            // transpose to column major
            array[0] = a00;
            array[4] = a01;
            array[8] = a02;
            array[12] = a03;
            array[1] = a10;
            array[5] = a11;
            array[9] = a12;
            array[13] = a13;
            array[2] = a20;
            array[6] = a21;
            array[10] = a22;
            array[14] = a23;
            array[3] = a30;
            array[7] = a31;
            array[11] = a32;
            array[15] = a33;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Mat3" /> from a SFML <see cref="Transform" /> and expand it to a 4x4 matrix
        /// </summary>
        /// <param name="transform">A SFML <see cref="Transform" /></param>
        ////////////////////////////////////////////////////////////
        public Mat4(Transform transform)
        {
            // swapping to column-major (OpenGL) from row-major (SFML) order
            // in addition, filling in the blanks (from expanding to a mat4) with values from
            // an identity matrix
            array[0] = transform.m00;
            array[4] = transform.m01;
            array[8] = 0;
            array[12] = transform.m02;
            array[1] = transform.m10;
            array[5] = transform.m11;
            array[9] = 0;
            array[13] = transform.m12;
            array[2] = 0;
            array[6] = 0;
            array[10] = 1;
            array[14] = 0;
            array[3] = transform.m20;
            array[7] = transform.m21;
            array[11] = 0;
            array[15] = transform.m22;
        }

        // column major!
        /// <summary>
        ///     The array
        /// </summary>
        private fixed float array[4 * 4];
    }
}