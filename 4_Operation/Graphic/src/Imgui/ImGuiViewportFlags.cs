namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im gui viewport flags enum
    /// </summary>
    [System.Flags]
    public enum ImGuiViewportFlags
    {
        /// <summary>
        /// The none im gui viewport flags
        /// </summary>
        None = 0,
        /// <summary>
        /// The is platform window im gui viewport flags
        /// </summary>
        IsPlatformWindow = 1,
        /// <summary>
        /// The is platform monitor im gui viewport flags
        /// </summary>
        IsPlatformMonitor = 2,
        /// <summary>
        /// The owned by app im gui viewport flags
        /// </summary>
        OwnedByApp = 4,
        /// <summary>
        /// The no decoration im gui viewport flags
        /// </summary>
        NoDecoration = 8,
        /// <summary>
        /// The no task bar icon im gui viewport flags
        /// </summary>
        NoTaskBarIcon = 16,
        /// <summary>
        /// The no focus on appearing im gui viewport flags
        /// </summary>
        NoFocusOnAppearing = 32,
        /// <summary>
        /// The no focus on click im gui viewport flags
        /// </summary>
        NoFocusOnClick = 64,
        /// <summary>
        /// The no inputs im gui viewport flags
        /// </summary>
        NoInputs = 128,
        /// <summary>
        /// The no renderer clear im gui viewport flags
        /// </summary>
        NoRendererClear = 256,
        /// <summary>
        /// The top most im gui viewport flags
        /// </summary>
        TopMost = 512,
        /// <summary>
        /// The minimized im gui viewport flags
        /// </summary>
        Minimized = 1024,
        /// <summary>
        /// The no auto merge im gui viewport flags
        /// </summary>
        NoAutoMerge = 2048,
        /// <summary>
        /// The can host other windows im gui viewport flags
        /// </summary>
        CanHostOtherWindows = 4096,
    }
}
