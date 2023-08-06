namespace Alis.Core.Graphic.ImGui.Extras.ImPlot
{
    /// <summary>
    /// The im plot subplot flags enum
    /// </summary>
    [System.Flags]
    public enum ImPlotSubplotFlags
    {
        /// <summary>
        /// The none im plot subplot flags
        /// </summary>
        None = 0,
        /// <summary>
        /// The no title im plot subplot flags
        /// </summary>
        NoTitle = 1,
        /// <summary>
        /// The no legend im plot subplot flags
        /// </summary>
        NoLegend = 2,
        /// <summary>
        /// The no menus im plot subplot flags
        /// </summary>
        NoMenus = 4,
        /// <summary>
        /// The no resize im plot subplot flags
        /// </summary>
        NoResize = 8,
        /// <summary>
        /// The no align im plot subplot flags
        /// </summary>
        NoAlign = 16,
        /// <summary>
        /// The share items im plot subplot flags
        /// </summary>
        ShareItems = 32,
        /// <summary>
        /// The link rows im plot subplot flags
        /// </summary>
        LinkRows = 64,
        /// <summary>
        /// The link cols im plot subplot flags
        /// </summary>
        LinkCols = 128,
        /// <summary>
        /// The link all im plot subplot flags
        /// </summary>
        LinkAllX = 256,
        /// <summary>
        /// The link all im plot subplot flags
        /// </summary>
        LinkAllY = 512,
        /// <summary>
        /// The col major im plot subplot flags
        /// </summary>
        ColMajor = 1024,
    }
}
