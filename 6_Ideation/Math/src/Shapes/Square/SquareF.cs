

using System.Runtime.InteropServices;

namespace Alis.Core.Aspect.Math.Shapes.Square
{
    /// <summary>
    ///     Represents a square with single-precision floating-point X, Y coordinates and width W. Implements <see cref="IShape" />.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SquareF : IShape
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
        ///     Gets or sets the width of the square.
        /// </summary>
        public float W { get; set; }
    }
}