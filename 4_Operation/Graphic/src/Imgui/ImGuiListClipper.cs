using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im gui list clipper
    /// </summary>
    public unsafe struct ImGuiListClipper
    {
        /// <summary>
        /// The display start
        /// </summary>
        public int DisplayStart;
        /// <summary>
        /// The display end
        /// </summary>
        public int DisplayEnd;
        /// <summary>
        /// The items count
        /// </summary>
        public int ItemsCount;
        /// <summary>
        /// The items height
        /// </summary>
        public float ItemsHeight;
        /// <summary>
        /// The start pos
        /// </summary>
        public float StartPosY;
        /// <summary>
        /// The temp data
        /// </summary>
        public void* TempData;
    }
}
