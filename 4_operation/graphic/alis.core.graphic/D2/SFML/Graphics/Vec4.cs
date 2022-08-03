using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.D2.SFML.Graphics
{
    /// <summary>
    ///     <see cref="Vec4" /> is a struct represent a glsl vec4 value
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec4
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Vec4" /> from its coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        /// <param name="w">W coordinate</param>
        ////////////////////////////////////////////////////////////
        public Vec4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        ///     Construct the <see cref="Vec4" /> from a <see cref="Color" />
        /// </summary>
        /// <remarks>
        ///     The <see cref="Color" />'s values will be normalized from 0..255 to 0..1
        /// </remarks>
        /// <param name="color">A SFML <see cref="Color" /> to be translated to a 4D floating-point vector</param>
        public Vec4(Color color)
        {
            X = color.R / 255.0f;
            Y = color.G / 255.0f;
            Z = color.B / 255.0f;
            W = color.A / 255.0f;
        }

        /// <summary>Horizontal component of the vector</summary>
        public float X;

        /// <summary>Vertical component of the vector</summary>
        public float Y;

        /// <summary>Depth component of the vector</summary>
        public float Z;

        /// <summary>Projective/Homogenous component of the vector</summary>
        public float W;
    }
}