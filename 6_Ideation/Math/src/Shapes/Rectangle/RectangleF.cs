

using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Aspect.Math.Shapes.Rectangle
{
    /// <summary>
    ///     Represents a rectangle defined by its top-left corner position, width, and height using single-precision floating-point coordinates. Implements <see cref="IShape" />.
    ///     Provides a method to test whether a point lies within the rectangle bounds.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RectangleF : IShape
    {
        /// <summary>
        ///     Gets or sets the X coordinate of the top-left corner.
        /// </summary>
        public float X { get; set; }

        /// <summary>
        ///     Gets or sets the Y coordinate of the top-left corner.
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        ///     Gets or sets the width of the rectangle.
        /// </summary>
        public float W { get; set; }

        /// <summary>
        ///     Gets or sets the height of the rectangle.
        /// </summary>
        public float H { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="RectangleF" /> struct.
        /// </summary>
        /// <param name="x">The X coordinate of the top-left corner.</param>
        /// <param name="y">The Y coordinate of the top-left corner.</param>
        /// <param name="w">The width of the rectangle.</param>
        /// <param name="h">The height of the rectangle.</param>
        public RectangleF(float x, float y, float w, float h)
        {
            X = x;
            Y = y;
            W = w;
            H = h;
        }

        /// <summary>
        ///     Determines whether the specified point lies within the bounds of this rectangle.
        /// </summary>
        /// <param name="pos">The 2D point to test.</param>
        /// <returns><c>true</c> if the point is inside the rectangle; otherwise, <c>false</c>.</returns>
        public bool Contains(Vector2F pos) => (pos.X >= X) && (pos.X <= X + W) && (pos.Y >= Y) && (pos.Y <= Y + H);
    }
}
