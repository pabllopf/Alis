namespace Alis.Core.Graphic.ImGui.Extras.ImPlot
{
    /// <summary>
    /// The im plot histogram flags enum
    /// </summary>
    [System.Flags]
    public enum ImPlotHistogramFlags
    {
        /// <summary>
        /// The none im plot histogram flags
        /// </summary>
        None = 0,
        /// <summary>
        /// The horizontal im plot histogram flags
        /// </summary>
        Horizontal = 1024,
        /// <summary>
        /// The cumulative im plot histogram flags
        /// </summary>
        Cumulative = 2048,
        /// <summary>
        /// The density im plot histogram flags
        /// </summary>
        Density = 4096,
        /// <summary>
        /// The no outliers im plot histogram flags
        /// </summary>
        NoOutliers = 8192,
        /// <summary>
        /// The col major im plot histogram flags
        /// </summary>
        ColMajor = 16384,
    }
}
