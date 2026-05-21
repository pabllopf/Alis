

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The stb undo record
    /// </summary>
    public struct StbUndoRecord
    {
        /// <summary>
        ///     The where
        /// </summary>
        public int Where { get; set; }

        /// <summary>
        ///     The insert length
        /// </summary>
        public int InsertLength { get; set; }

        /// <summary>
        ///     The delete length
        /// </summary>
        public int DeleteLength { get; set; }

        /// <summary>
        ///     The char storage
        /// </summary>
        public int CharStorage { get; set; }
    }
}