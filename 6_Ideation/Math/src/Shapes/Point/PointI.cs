

using System.Runtime.InteropServices;

namespace Alis.Core.Aspect.Math.Shapes.Point
{
    /// <summary>
    ///     Represents a 2D point with integer X and Y coordinates. Implements <see cref="IShape" />.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PointI : IShape
    {
        /// <summary>
        ///     Gets or sets the X coordinate.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        ///     Gets or sets the Y coordinate.
        /// </summary>
        public int Y { get; set; }
    }
}
