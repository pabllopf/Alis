using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im draw list splitter
    /// </summary>
    public unsafe struct ImDrawListSplitter
    {
        /// <summary>
        /// The current
        /// </summary>
        public int _Current;
        /// <summary>
        /// The count
        /// </summary>
        public int _Count;
        /// <summary>
        /// The channels
        /// </summary>
        public ImVector _Channels;
    }
}
