namespace ImGuiNET
{
    /// <summary>
    /// The im gui slider flags enum
    /// </summary>
    [System.Flags]
    public enum ImGuiSliderFlags
    {
        /// <summary>
        /// The none im gui slider flags
        /// </summary>
        None = 0,
        /// <summary>
        /// The always clamp im gui slider flags
        /// </summary>
        AlwaysClamp = 16,
        /// <summary>
        /// The logarithmic im gui slider flags
        /// </summary>
        Logarithmic = 32,
        /// <summary>
        /// The no round to format im gui slider flags
        /// </summary>
        NoRoundToFormat = 64,
        /// <summary>
        /// The no input im gui slider flags
        /// </summary>
        NoInput = 128,
        /// <summary>
        /// The invalid mask im gui slider flags
        /// </summary>
        InvalidMask = 1879048207,
    }
}
