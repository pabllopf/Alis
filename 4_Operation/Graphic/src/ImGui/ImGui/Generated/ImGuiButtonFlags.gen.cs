namespace ImGuiNET
{
    /// <summary>
    /// The im gui button flags enum
    /// </summary>
    [System.Flags]
    public enum ImGuiButtonFlags
    {
        /// <summary>
        /// The none im gui button flags
        /// </summary>
        None = 0,
        /// <summary>
        /// The mouse button left im gui button flags
        /// </summary>
        MouseButtonLeft = 1,
        /// <summary>
        /// The mouse button right im gui button flags
        /// </summary>
        MouseButtonRight = 2,
        /// <summary>
        /// The mouse button middle im gui button flags
        /// </summary>
        MouseButtonMiddle = 4,
        /// <summary>
        /// The mouse button mask im gui button flags
        /// </summary>
        MouseButtonMask = 7,
        /// <summary>
        /// The mouse button default im gui button flags
        /// </summary>
        MouseButtonDefault = 1,
    }
}
