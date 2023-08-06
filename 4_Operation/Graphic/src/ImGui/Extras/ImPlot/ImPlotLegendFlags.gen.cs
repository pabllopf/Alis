namespace Alis.Core.Graphic.ImGui.Extras.ImPlot
{
    /// <summary>
    /// The im plot legend flags enum
    /// </summary>
    [System.Flags]
    public enum ImPlotLegendFlags
    {
        /// <summary>
        /// The none im plot legend flags
        /// </summary>
        None = 0,
        /// <summary>
        /// The no buttons im plot legend flags
        /// </summary>
        NoButtons = 1,
        /// <summary>
        /// The no highlight item im plot legend flags
        /// </summary>
        NoHighlightItem = 2,
        /// <summary>
        /// The no highlight axis im plot legend flags
        /// </summary>
        NoHighlightAxis = 4,
        /// <summary>
        /// The no menus im plot legend flags
        /// </summary>
        NoMenus = 8,
        /// <summary>
        /// The outside im plot legend flags
        /// </summary>
        Outside = 16,
        /// <summary>
        /// The horizontal im plot legend flags
        /// </summary>
        Horizontal = 32,
        /// <summary>
        /// The sort im plot legend flags
        /// </summary>
        Sort = 64,
    }
}
