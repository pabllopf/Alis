using System.Numerics;
using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im draw vert
    /// </summary>
    public unsafe struct ImDrawVert
    {
        /// <summary>
        /// The pos
        /// </summary>
        public Vector2 Pos;
        /// <summary>
        /// The uv
        /// </summary>
        public Vector2 Uv;
        /// <summary>
        /// The col
        /// </summary>
        public uint Col;
    }
}
