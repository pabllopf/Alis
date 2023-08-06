namespace ImPlotNET
{
    /// <summary>
    /// The im plot flags enum
    /// </summary>
    [System.Flags]
    public enum ImPlotFlags
    {
        /// <summary>
        /// The none im plot flags
        /// </summary>
        None = 0,
        /// <summary>
        /// The no title im plot flags
        /// </summary>
        NoTitle = 1,
        /// <summary>
        /// The no legend im plot flags
        /// </summary>
        NoLegend = 2,
        /// <summary>
        /// The no mouse text im plot flags
        /// </summary>
        NoMouseText = 4,
        /// <summary>
        /// The no inputs im plot flags
        /// </summary>
        NoInputs = 8,
        /// <summary>
        /// The no menus im plot flags
        /// </summary>
        NoMenus = 16,
        /// <summary>
        /// The no box select im plot flags
        /// </summary>
        NoBoxSelect = 32,
        /// <summary>
        /// The no child im plot flags
        /// </summary>
        NoChild = 64,
        /// <summary>
        /// The no frame im plot flags
        /// </summary>
        NoFrame = 128,
        /// <summary>
        /// The equal im plot flags
        /// </summary>
        Equal = 256,
        /// <summary>
        /// The crosshairs im plot flags
        /// </summary>
        Crosshairs = 512,
        /// <summary>
        /// The canvas only im plot flags
        /// </summary>
        CanvasOnly = 55,
    }
}
