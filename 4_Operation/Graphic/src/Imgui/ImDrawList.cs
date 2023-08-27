using System;
using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im draw list
    /// </summary>
    public unsafe struct ImDrawList
    {
        /// <summary>
        /// The cmd buffer
        /// </summary>
        public ImVector CmdBuffer;
        /// <summary>
        /// The idx buffer
        /// </summary>
        public ImVector IdxBuffer;
        /// <summary>
        /// The vtx buffer
        /// </summary>
        public ImVector VtxBuffer;
        /// <summary>
        /// The flags
        /// </summary>
        public ImDrawListFlags Flags;
        /// <summary>
        /// The vtx current idx
        /// </summary>
        public uint VtxCurrentIdx;
        /// <summary>
        /// The data
        /// </summary>
        public IntPtr Data;
        /// <summary>
        /// The owner name
        /// </summary>
        public byte* OwnerName;
        /// <summary>
        /// The vtx write ptr
        /// </summary>
        public ImDrawVert* VtxWritePtr;
        /// <summary>
        /// The idx write ptr
        /// </summary>
        public ushort* IdxWritePtr;
        /// <summary>
        /// The clip rect stack
        /// </summary>
        public ImVector ClipRectStack;
        /// <summary>
        /// The texture id stack
        /// </summary>
        public ImVector TextureIdStack;
        /// <summary>
        /// The path
        /// </summary>
        public ImVector Path;
        /// <summary>
        /// The cmd header
        /// </summary>
        public ImDrawCmdHeader CmdHeader;
        /// <summary>
        /// The splitter
        /// </summary>
        public ImDrawListSplitter Splitter;
        /// <summary>
        /// The fringe scale
        /// </summary>
        public float FringeScale;
    }
}
