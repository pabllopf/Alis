namespace ImGuiNET
{
    /// <summary>
    /// The im gui combo flags enum
    /// </summary>
    [System.Flags]
    public enum ImGuiComboFlags
    {
        /// <summary>
        /// The none im gui combo flags
        /// </summary>
        None = 0,
        /// <summary>
        /// The popup align left im gui combo flags
        /// </summary>
        PopupAlignLeft = 1,
        /// <summary>
        /// The height small im gui combo flags
        /// </summary>
        HeightSmall = 2,
        /// <summary>
        /// The height regular im gui combo flags
        /// </summary>
        HeightRegular = 4,
        /// <summary>
        /// The height large im gui combo flags
        /// </summary>
        HeightLarge = 8,
        /// <summary>
        /// The height largest im gui combo flags
        /// </summary>
        HeightLargest = 16,
        /// <summary>
        /// The no arrow button im gui combo flags
        /// </summary>
        NoArrowButton = 32,
        /// <summary>
        /// The no preview im gui combo flags
        /// </summary>
        NoPreview = 64,
        /// <summary>
        /// The height mask im gui combo flags
        /// </summary>
        HeightMask = 30,
    }
}
