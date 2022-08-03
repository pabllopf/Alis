using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.D2.SFML.Graphics
{
    /// <summary>
    ///     <see cref="Ivec2" /> is a struct represent a glsl ivec2 value
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct Ivec2
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Implicit cast from <see cref="Vector2i" /> to <see cref="Ivec2" />
        /// </summary>
        public static implicit operator Ivec2(Vector2i vec)
        {
            return new Ivec2(vec);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Ivec2" /> from its coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        ////////////////////////////////////////////////////////////
        public Ivec2(int x, int y)
        {
            X = x;
            Y = y;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Ivec2" /> from a standard SFML <see cref="Vector2i" />
        /// </summary>
        /// <param name="vec">A standard SFML 2D integer vector</param>
        ////////////////////////////////////////////////////////////
        public Ivec2(Vector2i vec)
        {
            X = vec.X;
            Y = vec.Y;
        }

        /// <summary>Horizontal component of the vector</summary>
        public int X;

        /// <summary>Vertical component of the vector</summary>
        public int Y;
    }
}