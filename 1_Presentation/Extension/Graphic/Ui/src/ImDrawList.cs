

using System;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im draw list
    /// </summary>
    public struct ImDrawList
    {
        /// <summary>
        ///     The cmd buffer
        /// </summary>
        public ImVector CmdBuffer { get; set; }

        /// <summary>
        ///     The idx buffer
        /// </summary>
        public ImVector IdxBuffer { get; set; }

        /// <summary>
        ///     The vtx buffer
        /// </summary>
        public ImVector VtxBuffer { get; set; }

        /// <summary>
        ///     The flags
        /// </summary>
        public ImDrawListFlags Flags { get; set; }

        /// <summary>
        ///     The vtx current idx
        /// </summary>
        public uint VtxCurrentIdx { get; set; }

        /// <summary>
        ///     The data
        /// </summary>
        public IntPtr Data { get; set; }

        /// <summary>
        ///     The owner name
        /// </summary>
        public IntPtr OwnerName { get; set; }

        /// <summary>
        ///     The vtx write ptr
        /// </summary>
        public IntPtr VtxWritePtr { get; set; }

        /// <summary>
        ///     The idx write ptr
        /// </summary>
        public IntPtr IdxWritePtr { get; set; }

        /// <summary>
        ///     The clip rect stack
        /// </summary>
        public ImVector ClipRectStack { get; set; }

        /// <summary>
        ///     The texture id stack
        /// </summary>
        public ImVector TextureIdStack { get; set; }

        /// <summary>
        ///     The path
        /// </summary>
        public ImVector Path { get; set; }

        /// <summary>
        ///     The cmd header
        /// </summary>
        public ImDrawCmdHeader CmdHeader { get; set; }

        /// <summary>
        ///     The splitter
        /// </summary>
        public ImDrawListSplitter Splitter { get; set; }

        /// <summary>
        ///     The fringe scale
        /// </summary>
        public float FringeScale { get; set; }
    }
}