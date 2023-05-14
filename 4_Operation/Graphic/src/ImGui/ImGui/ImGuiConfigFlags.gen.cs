namespace Alis.Core.Graphic.ImGui.ImGui
{
    /// <summary>
    /// The im gui config flags enum
    /// </summary>
    [System.Flags]
    public enum ImGuiConfigFlags
    {
        /// <summary>
        /// The none im gui config flags
        /// </summary>
        None = 0,
        /// <summary>
        /// The nav enable keyboard im gui config flags
        /// </summary>
        NavEnableKeyboard = 1,
        /// <summary>
        /// The nav enable gamepad im gui config flags
        /// </summary>
        NavEnableGamepad = 2,
        /// <summary>
        /// The nav enable set mouse pos im gui config flags
        /// </summary>
        NavEnableSetMousePos = 4,
        /// <summary>
        /// The nav no capture keyboard im gui config flags
        /// </summary>
        NavNoCaptureKeyboard = 8,
        /// <summary>
        /// The no mouse im gui config flags
        /// </summary>
        NoMouse = 16,
        /// <summary>
        /// The no mouse cursor change im gui config flags
        /// </summary>
        NoMouseCursorChange = 32,
        /// <summary>
        /// The docking enable im gui config flags
        /// </summary>
        DockingEnable = 64,
        /// <summary>
        /// The viewports enable im gui config flags
        /// </summary>
        ViewportsEnable = 1024,
        /// <summary>
        /// The dpi enable scale viewports im gui config flags
        /// </summary>
        DpiEnableScaleViewports = 16384,
        /// <summary>
        /// The dpi enable scale fonts im gui config flags
        /// </summary>
        DpiEnableScaleFonts = 32768,
        /// <summary>
        /// The is srgb im gui config flags
        /// </summary>
        IsSRGB = 1048576,
        /// <summary>
        /// The is touch screen im gui config flags
        /// </summary>
        IsTouchScreen = 2097152,
    }
}
