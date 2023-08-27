using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im draw cmd
    /// </summary>
    public unsafe struct ImDrawCmd
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
        /// <summary>
        /// The idx offset
        /// </summary>
        public uint IdxOffset;
        /// <summary>
        /// The elem count
        /// </summary>
        public uint ElemCount;
        /// <summary>
        /// The user callback
        /// </summary>
        public IntPtr UserCallback;
        /// <summary>
        /// The user callback data
        /// </summary>
        public void* UserCallbackData;
    }
}
