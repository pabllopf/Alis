

using System;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im draw data
    /// </summary>
    public struct ImDrawData
    {
        /// <summary>
        ///     The valid
        /// </summary>
        public byte Valid { get; set; }

        /// <summary>
        ///     The cmd lists count
        /// </summary>
        public int CmdListsCount { get; set; }

        /// <summary>
        ///     The total idx count
        /// </summary>
        public int TotalIdxCount { get; set; }

        /// <summary>
        ///     The total vtx count
        /// </summary>
        public int TotalVtxCount { get; set; }

        /// <summary>
        ///     The cmd lists
        /// </summary>
        public IntPtr CmdListsPtr { get; set; }

        /// <summary>
        ///     The display pos
        /// </summary>
        public Vector2F DisplayPos { get; set; }

        /// <summary>
        ///     The display size
        /// </summary>
        public Vector2F DisplaySize { get; set; }

        /// <summary>
        ///     The framebuffer scale
        /// </summary>
        public Vector2F FramebufferScale { get; set; }

        /// <summary>
        ///     The owner viewport
        /// </summary>
        public IntPtr OwnerViewportPtr { get; set; }

        /// <summary>
        ///     Clears this instance
        /// </summary>
        public void Clear()
        {
            ImGuiNative.ImDrawData_Clear(ref this);
        }

        /// <summary>
        ///     Des the index all buffers
        /// </summary>
        public void DeIndexAllBuffers()
        {
            ImGuiNative.ImDrawData_DeIndexAllBuffers(ref this);
        }

        /// <summary>
        ///     Scales the clip rects using the specified fb scale
        /// </summary>
        /// <param name="fbScale">The fb scale</param>
        public void ScaleClipRects(Vector2F fbScale)
        {
            ImGuiNative.ImDrawData_ScaleClipRects(ref this, fbScale);
        }

        /// <summary>
        ///     Gets the value of the cmd lists range
        /// </summary>
        public RangePtrAccessor<ImDrawListPtr> CmdListsRange => new RangePtrAccessor<ImDrawListPtr>(CmdListsPtr, CmdListsCount);
    }
}