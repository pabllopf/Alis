namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im gui mod flags enum
    /// </summary>
    [System.Flags]
    public enum ImGuiModFlags
    {
        /// <summary>
        /// The none im gui mod flags
        /// </summary>
        None = 0,
        /// <summary>
        /// The ctrl im gui mod flags
        /// </summary>
        Ctrl = 1,
        /// <summary>
        /// The shift im gui mod flags
        /// </summary>
        Shift = 2,
        /// <summary>
        /// The alt im gui mod flags
        /// </summary>
        Alt = 4,
        /// <summary>
        /// The super im gui mod flags
        /// </summary>
        Super = 8,
    }
}
