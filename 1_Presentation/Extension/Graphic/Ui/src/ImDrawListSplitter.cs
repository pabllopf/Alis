

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im draw list splitter
    /// </summary>
    public struct ImDrawListSplitter
    {
        /// <summary>
        ///     The current
        /// </summary>
        public int Current { get; set; }

        /// <summary>
        ///     The count
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        ///     The channels
        /// </summary>
        public ImVector Channels { get; set; }
    }
}