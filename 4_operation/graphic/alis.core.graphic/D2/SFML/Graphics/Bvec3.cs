using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.D2.SFML.Graphics
{
    /// <summary>
    ///     <see cref="Bvec3" /> is a struct represent a glsl bvec3 value
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct Bvec3
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Bvec3" /> from its coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        ////////////////////////////////////////////////////////////
        public Bvec3(bool x, bool y, bool z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>Horizontal component of the vector</summary>
        public bool X;

        /// <summary>Vertical component of the vector</summary>
        public bool Y;

        /// <summary>Depth component of the vector</summary>
        public bool Z;
    }
}