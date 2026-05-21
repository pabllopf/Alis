

using System.Runtime.InteropServices;

namespace Alis.Core.Aspect.Math.Shapes.Circle
{
    /// <summary>
    ///     Represents a circle defined by its center point (X, Y) and radius (R) using integer coordinates.
    ///     Implements the <see cref="IShape" /> interface for geometric shape operations.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CircleI : IShape
    {
        /// <summary>
        ///     Gets or sets the X coordinate of the center.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        ///     Gets or sets the Y coordinate of the center.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        ///     Gets or sets the radius of the circle.
        /// </summary>
        public int R { get; set; }
    }
}