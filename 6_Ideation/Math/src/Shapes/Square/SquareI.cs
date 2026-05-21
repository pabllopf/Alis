

using System.Runtime.InteropServices;

namespace Alis.Core.Aspect.Math.Shapes.Square
{
    /// <summary>
    ///     Represents a square with integer X, Y coordinates and width W. Implements <see cref="IShape" />.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SquareI : IShape
    {
        /// <summary>
        ///     Gets or sets the X coordinate of the top-left corner.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        ///     Gets or sets the Y coordinate of the top-left corner.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        ///     Gets or sets the width of the square.
        /// </summary>
        public int W { get; set; }
    }
}