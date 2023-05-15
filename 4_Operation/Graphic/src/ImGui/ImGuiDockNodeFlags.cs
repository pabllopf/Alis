namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    /// The im gui dock node flags enum
    /// </summary>
    [System.Flags]
    public enum ImGuiDockNodeFlags
    {
        /// <summary>
        /// The none im gui dock node flags
        /// </summary>
        None = 0,
        /// <summary>
        /// The keep alive only im gui dock node flags
        /// </summary>
        KeepAliveOnly = 1,
        /// <summary>
        /// The no docking in central node im gui dock node flags
        /// </summary>
        NoDockingInCentralNode = 4,
        /// <summary>
        /// The passthru central node im gui dock node flags
        /// </summary>
        PassthruCentralNode = 8,
        /// <summary>
        /// The no split im gui dock node flags
        /// </summary>
        NoSplit = 16,
        /// <summary>
        /// The no resize im gui dock node flags
        /// </summary>
        NoResize = 32,
        /// <summary>
        /// The auto hide tab bar im gui dock node flags
        /// </summary>
        AutoHideTabBar = 64,
    }
}
