

using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Shapes.Point;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl vertex
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Vertex
    {
        /// <summary>
        ///     The position
        /// </summary>
        public PointF Position { get; set; }

        /// <summary>
        ///     The color
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        ///     The text coordinate
        /// </summary>
        public PointF TexCoordinate { get; set; }
    }
}