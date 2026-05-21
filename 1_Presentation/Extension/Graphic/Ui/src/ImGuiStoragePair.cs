

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui storage pair
    /// </summary>
    public struct ImGuiStoragePair
    {
        /// <summary>
        ///     The key
        /// </summary>
        public uint Key { get; set; }

        /// <summary>
        ///     The value
        /// </summary>
        public UnionValue Value { get; set; }
    }
}