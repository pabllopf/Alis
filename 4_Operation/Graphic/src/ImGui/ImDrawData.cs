using System.Numerics;

namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    /// The im draw data
    /// </summary>
    public unsafe struct ImDrawData
    {
        /// <summary>
        /// The valid
        /// </summary>
        public byte Valid;
        /// <summary>
        /// The cmd lists count
        /// </summary>
        public int CmdListsCount;
        /// <summary>
        /// The total idx count
        /// </summary>
        public int TotalIdxCount;
        /// <summary>
        /// The total vtx count
        /// </summary>
        public int TotalVtxCount;
        /// <summary>
        /// The cmd lists
        /// </summary>
        public ImDrawList** CmdLists;
        /// <summary>
        /// The display pos
        /// </summary>
        public Vector2 DisplayPos;
        /// <summary>
        /// The display size
        /// </summary>
        public Vector2 DisplaySize;
        /// <summary>
        /// The framebuffer scale
        /// </summary>
        public Vector2 FramebufferScale;
        /// <summary>
        /// The owner viewport
        /// </summary>
        public ImGuiViewport* OwnerViewport;
    }
}
