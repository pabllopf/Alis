using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.D2.SFML.Graphics
{
    /// <summary>
    ///     <see cref="Ivec4" /> is a struct represent a glsl ivec4 value
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct Ivec4
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Ivec4" /> from its coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        /// <param name="w">W coordinate</param>
        ////////////////////////////////////////////////////////////
        public Ivec4(int x, int y, int z, int w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        ///     Construct the <see cref="Ivec4" /> from a <see cref="Color" />
        /// </summary>
        /// <param name="color">A SFML <see cref="Color" /> to be translated to a 4D integer vector</param>
        public Ivec4(Color color)
        {
            X = color.R;
            Y = color.G;
            Z = color.B;
            W = color.A;
        }

        /// <summary>Horizontal component of the vector</summary>
        public int X;

        /// <summary>Vertical component of the vector</summary>
        public int Y;

        /// <summary>Depth component of the vector</summary>
        public int Z;

        /// <summary>Projective/Homogenous component of the vector</summary>
        public int W;
    }
}