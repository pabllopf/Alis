using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.D2.SFML.Graphics
{
    /// <summary>
    ///     <see cref="Bvec4" /> is a struct represent a glsl bvec4 value
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct Bvec4
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Bvec4" /> from its coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        /// <param name="w">W coordinate</param>
        ////////////////////////////////////////////////////////////
        public Bvec4(bool x, bool y, bool z, bool w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>Horizontal component of the vector</summary>
        public bool X;

        /// <summary>Vertical component of the vector</summary>
        public bool Y;

        /// <summary>Depth component of the vector</summary>
        public bool Z;

        /// <summary>Projective/Homogenous component of the vector</summary>
        public bool W;
    }
}