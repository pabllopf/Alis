using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im draw cmd header
    /// </summary>
    public unsafe struct ImDrawCmdHeader
    {
        /// <summary>
        /// The clip rect
        /// </summary>
        public Vector4 ClipRect;
        /// <summary>
        /// The texture id
        /// </summary>
        public IntPtr TextureId;
        /// <summary>
        /// The vtx offset
        /// </summary>
        public uint VtxOffset;
    }
}
