namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im gui hovered flags enum
    /// </summary>
    [System.Flags]
    public enum ImGuiHoveredFlags
    {
        /// <summary>
        /// The none im gui hovered flags
        /// </summary>
        None = 0,
        /// <summary>
        /// The child windows im gui hovered flags
        /// </summary>
        ChildWindows = 1,
        /// <summary>
        /// The root window im gui hovered flags
        /// </summary>
        RootWindow = 2,
        /// <summary>
        /// The any window im gui hovered flags
        /// </summary>
        AnyWindow = 4,
        /// <summary>
        /// The no popup hierarchy im gui hovered flags
        /// </summary>
        NoPopupHierarchy = 8,
        /// <summary>
        /// The dock hierarchy im gui hovered flags
        /// </summary>
        DockHierarchy = 16,
        /// <summary>
        /// The allow when blocked by popup im gui hovered flags
        /// </summary>
        AllowWhenBlockedByPopup = 32,
        /// <summary>
        /// The allow when blocked by active item im gui hovered flags
        /// </summary>
        AllowWhenBlockedByActiveItem = 128,
        /// <summary>
        /// The allow when overlapped im gui hovered flags
        /// </summary>
        AllowWhenOverlapped = 256,
        /// <summary>
        /// The allow when disabled im gui hovered flags
        /// </summary>
        AllowWhenDisabled = 512,
        /// <summary>
        /// The no nav override im gui hovered flags
        /// </summary>
        NoNavOverride = 1024,
        /// <summary>
        /// The rect only im gui hovered flags
        /// </summary>
        RectOnly = 416,
        /// <summary>
        /// The root and child windows im gui hovered flags
        /// </summary>
        RootAndChildWindows = 3,
        /// <summary>
        /// The delay normal im gui hovered flags
        /// </summary>
        DelayNormal = 2048,
        /// <summary>
        /// The delay short im gui hovered flags
        /// </summary>
        DelayShort = 4096,
        /// <summary>
        /// The no shared delay im gui hovered flags
        /// </summary>
        NoSharedDelay = 8192,
    }
}
