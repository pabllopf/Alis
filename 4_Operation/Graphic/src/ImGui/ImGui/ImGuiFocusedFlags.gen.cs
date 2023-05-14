namespace Alis.Core.Graphic.ImGui.ImGui
{
    /// <summary>
    /// The im gui focused flags enum
    /// </summary>
    [System.Flags]
    public enum ImGuiFocusedFlags
    {
        /// <summary>
        /// The none im gui focused flags
        /// </summary>
        None = 0,
        /// <summary>
        /// The child windows im gui focused flags
        /// </summary>
        ChildWindows = 1,
        /// <summary>
        /// The root window im gui focused flags
        /// </summary>
        RootWindow = 2,
        /// <summary>
        /// The any window im gui focused flags
        /// </summary>
        AnyWindow = 4,
        /// <summary>
        /// The no popup hierarchy im gui focused flags
        /// </summary>
        NoPopupHierarchy = 8,
        /// <summary>
        /// The dock hierarchy im gui focused flags
        /// </summary>
        DockHierarchy = 16,
        /// <summary>
        /// The root and child windows im gui focused flags
        /// </summary>
        RootAndChildWindows = 3,
    }
}
