

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui table column sort specs
    /// </summary>
    public struct ImGuiTableColumnSortSpecs
    {
        /// <summary>
        ///     The column user id
        /// </summary>
        public uint ColumnUserId { get; set; }

        /// <summary>
        ///     The column index
        /// </summary>
        public short ColumnIndex { get; set; }

        /// <summary>
        ///     The sort order
        /// </summary>
        public short SortOrder { get; set; }

        /// <summary>
        ///     The sort direction
        /// </summary>
        public ImGuiSortDirection SortDirection { get; set; }
    }
}