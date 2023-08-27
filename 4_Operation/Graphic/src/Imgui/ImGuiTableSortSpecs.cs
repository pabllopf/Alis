using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im gui table sort specs
    /// </summary>
    public unsafe struct ImGuiTableSortSpecs
    {
        /// <summary>
        /// The specs
        /// </summary>
        public ImGuiTableColumnSortSpecs* Specs;
        /// <summary>
        /// The specs count
        /// </summary>
        public int SpecsCount;
        /// <summary>
        /// The specs dirty
        /// </summary>
        public byte SpecsDirty;
    }
}
