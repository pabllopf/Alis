namespace Alis.Core.Graphic.ImGui.Extras.ImNodes
{
    /// <summary>
    /// The im nodes style flags enum
    /// </summary>
    [System.Flags]
    public enum ImNodesStyleFlags
    {
        /// <summary>
        /// The none im nodes style flags
        /// </summary>
        None = 0,
        /// <summary>
        /// The node outline im nodes style flags
        /// </summary>
        NodeOutline = 1,
        /// <summary>
        /// The grid lines im nodes style flags
        /// </summary>
        GridLines = 4,
        /// <summary>
        /// The grid lines primary im nodes style flags
        /// </summary>
        GridLinesPrimary = 8,
        /// <summary>
        /// The grid snapping im nodes style flags
        /// </summary>
        GridSnapping = 16,
    }
}
