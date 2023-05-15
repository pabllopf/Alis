using System;

namespace Alis.Core.Graphic.ImGui
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
        public uint _VtxCurrentIdx;
        /// <summary>
        /// The data
        /// </summary>
        public IntPtr _Data;
        /// <summary>
        /// The owner name
        /// </summary>
        public byte* _OwnerName;
        /// <summary>
        /// The vtx write ptr
        /// </summary>
        public ImDrawVert* _VtxWritePtr;
        /// <summary>
        /// The idx write ptr
        /// </summary>
        public ushort* _IdxWritePtr;
        /// <summary>
        /// The clip rect stack
        /// </summary>
        public ImVector _ClipRectStack;
        /// <summary>
        /// The texture id stack
        /// </summary>
        public ImVector _TextureIdStack;
        /// <summary>
        /// The path
        /// </summary>
        public ImVector _Path;
        /// <summary>
        /// The cmd header
        /// </summary>
        public ImDrawCmdHeader _CmdHeader;
        /// <summary>
        /// The splitter
        /// </summary>
        public ImDrawListSplitter _Splitter;
        /// <summary>
        /// The fringe scale
        /// </summary>
        public float _FringeScale;
    }
}
