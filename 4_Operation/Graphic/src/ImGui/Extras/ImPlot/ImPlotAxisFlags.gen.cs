namespace Alis.Core.Graphic.ImGui.Extras.ImPlot
{
    /// <summary>
    /// The im plot axis flags enum
    /// </summary>
    [System.Flags]
    public enum ImPlotAxisFlags
    {
        /// <summary>
        /// The none im plot axis flags
        /// </summary>
        None = 0,
        /// <summary>
        /// The no label im plot axis flags
        /// </summary>
        NoLabel = 1,
        /// <summary>
        /// The no grid lines im plot axis flags
        /// </summary>
        NoGridLines = 2,
        /// <summary>
        /// The no tick marks im plot axis flags
        /// </summary>
        NoTickMarks = 4,
        /// <summary>
        /// The no tick labels im plot axis flags
        /// </summary>
        NoTickLabels = 8,
        /// <summary>
        /// The no initial fit im plot axis flags
        /// </summary>
        NoInitialFit = 16,
        /// <summary>
        /// The no menus im plot axis flags
        /// </summary>
        NoMenus = 32,
        /// <summary>
        /// The no side switch im plot axis flags
        /// </summary>
        NoSideSwitch = 64,
        /// <summary>
        /// The no highlight im plot axis flags
        /// </summary>
        NoHighlight = 128,
        /// <summary>
        /// The opposite im plot axis flags
        /// </summary>
        Opposite = 256,
        /// <summary>
        /// The foreground im plot axis flags
        /// </summary>
        Foreground = 512,
        /// <summary>
        /// The invert im plot axis flags
        /// </summary>
        Invert = 1024,
        /// <summary>
        /// The auto fit im plot axis flags
        /// </summary>
        AutoFit = 2048,
        /// <summary>
        /// The range fit im plot axis flags
        /// </summary>
        RangeFit = 4096,
        /// <summary>
        /// The pan stretch im plot axis flags
        /// </summary>
        PanStretch = 8192,
        /// <summary>
        /// The lock min im plot axis flags
        /// </summary>
        LockMin = 16384,
        /// <summary>
        /// The lock max im plot axis flags
        /// </summary>
        LockMax = 32768,
        /// <summary>
        /// The lock im plot axis flags
        /// </summary>
        Lock = 49152,
        /// <summary>
        /// The no decorations im plot axis flags
        /// </summary>
        NoDecorations = 15,
        /// <summary>
        /// The aux default im plot axis flags
        /// </summary>
        AuxDefault = 258,
    }
}
