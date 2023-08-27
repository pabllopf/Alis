using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im gui text filter
    /// </summary>
    public unsafe struct ImGuiTextFilter
    {
        /// <summary>
        /// The input buf
        /// </summary>
        public fixed byte InputBuf[256];
        /// <summary>
        /// The filters
        /// </summary>
        public ImVector Filters;
        /// <summary>
        /// The count grep
        /// </summary>
        public int CountGrep;
    }
}
