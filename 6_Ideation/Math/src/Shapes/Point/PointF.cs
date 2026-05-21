

using System.Runtime.InteropServices;

namespace Alis.Core.Aspect.Math.Shapes.Point
{
    /// <summary>
    ///     Represents a 2D point with single-precision floating-point X and Y coordinates. Implements <see cref="IShape" />.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PointF : IShape
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PointF" /> struct with both coordinates set to the same value.
        /// </summary>
        /// <param name="value">The value to assign to both X and Y.</param>
        public PointF(float value)
        {
            X = value;
            Y = value;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PointF" /> struct as a copy of another point.
        /// </summary>
        /// <param name="point">The point to copy coordinates from.</param>
        public PointF(PointF point)
        {
            X = point.X;
            Y = point.Y;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PointF" /> struct with explicit coordinates.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        public PointF(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        ///     Gets or sets the X coordinate.
        /// </summary>
        public float X { get; set; }

        /// <summary>
        ///     Gets or sets the Y coordinate.
        /// </summary>
        public float Y { get; set; }
    }
}
