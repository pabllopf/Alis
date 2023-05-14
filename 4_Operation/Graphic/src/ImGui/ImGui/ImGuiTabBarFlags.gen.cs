namespace Alis.Core.Graphic.ImGui.ImGui
{
    /// <summary>
    /// The im gui tab bar flags enum
    /// </summary>
    [System.Flags]
    public enum ImGuiTabBarFlags
    {
        /// <summary>
        /// The none im gui tab bar flags
        /// </summary>
        None = 0,
        /// <summary>
        /// The reorderable im gui tab bar flags
        /// </summary>
        Reorderable = 1,
        /// <summary>
        /// The auto select new tabs im gui tab bar flags
        /// </summary>
        AutoSelectNewTabs = 2,
        /// <summary>
        /// The tab list popup button im gui tab bar flags
        /// </summary>
        TabListPopupButton = 4,
        /// <summary>
        /// The no close with middle mouse button im gui tab bar flags
        /// </summary>
        NoCloseWithMiddleMouseButton = 8,
        /// <summary>
        /// The no tab list scrolling buttons im gui tab bar flags
        /// </summary>
        NoTabListScrollingButtons = 16,
        /// <summary>
        /// The no tooltip im gui tab bar flags
        /// </summary>
        NoTooltip = 32,
        /// <summary>
        /// The fitting policy resize down im gui tab bar flags
        /// </summary>
        FittingPolicyResizeDown = 64,
        /// <summary>
        /// The fitting policy scroll im gui tab bar flags
        /// </summary>
        FittingPolicyScroll = 128,
        /// <summary>
        /// The fitting policy mask im gui tab bar flags
        /// </summary>
        FittingPolicyMask = 192,
        /// <summary>
        /// The fitting policy default im gui tab bar flags
        /// </summary>
        FittingPolicyDefault = 64,
    }
}
