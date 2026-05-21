

using System.Runtime.InteropServices;

namespace Alis.Core.Aspect.Math.Shapes.Line
{
    /// <summary>
    ///     Represents a line segment defined by two endpoints with single-precision floating-point coordinates. Implements <see cref="IShape" />.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct LineF : IShape
    {
        /// <summary>
        ///     Gets or sets the X coordinate of the first endpoint.
        /// </summary>
        public float X1 { get; set; }

        /// <summary>
        ///     Gets or sets the Y coordinate of the first endpoint.
        /// </summary>
        public float Y1 { get; set; }

        /// <summary>
        ///     Gets or sets the X coordinate of the second endpoint.
        /// </summary>
        public float X2 { get; set; }

        /// <summary>
        ///     Gets or sets the Y coordinate of the second endpoint.
        /// </summary>
        public float Y2 { get; set; }
    }
}
