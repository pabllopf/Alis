namespace Alis.Core.Graphic.Imgui.Extras.ImPlot
{
    /// <summary>
    /// The im plot drag tool flags enum
    /// </summary>
    [System.Flags]
    public enum ImPlotDragToolFlags
    {
        /// <summary>
        /// The none im plot drag tool flags
        /// </summary>
        None = 0,
        /// <summary>
        /// The no cursors im plot drag tool flags
        /// </summary>
        NoCursors = 1,
        /// <summary>
        /// The no fit im plot drag tool flags
        /// </summary>
        NoFit = 2,
        /// <summary>
        /// The no inputs im plot drag tool flags
        /// </summary>
        NoInputs = 4,
        /// <summary>
        /// The delayed im plot drag tool flags
        /// </summary>
        Delayed = 8,
    }
}
