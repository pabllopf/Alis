using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im gui table column sort specs
    /// </summary>
    public struct ImGuiTableColumnSortSpecs
    {
        /// <summary>
        /// The column user id
        /// </summary>
        public uint ColumnUserId;
        /// <summary>
        /// The column index
        /// </summary>
        public short ColumnIndex;
        /// <summary>
        /// The sort order
        /// </summary>
        public short SortOrder;
        /// <summary>
        /// The sort direction
        /// </summary>
        public ImGuiSortDirection SortDirection;
    }
}
