namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im gui drag drop flags enum
    /// </summary>
    [System.Flags]
    public enum ImGuiDragDropFlags
    {
        /// <summary>
        /// The none im gui drag drop flags
        /// </summary>
        None = 0,
        /// <summary>
        /// The source no preview tooltip im gui drag drop flags
        /// </summary>
        SourceNoPreviewTooltip = 1,
        /// <summary>
        /// The source no disable hover im gui drag drop flags
        /// </summary>
        SourceNoDisableHover = 2,
        /// <summary>
        /// The source no hold to open others im gui drag drop flags
        /// </summary>
        SourceNoHoldToOpenOthers = 4,
        /// <summary>
        /// The source allow null id im gui drag drop flags
        /// </summary>
        SourceAllowNullId = 8,
        /// <summary>
        /// The source extern im gui drag drop flags
        /// </summary>
        SourceExtern = 16,
        /// <summary>
        /// The source auto expire payload im gui drag drop flags
        /// </summary>
        SourceAutoExpirePayload = 32,
        /// <summary>
        /// The accept before delivery im gui drag drop flags
        /// </summary>
        AcceptBeforeDelivery = 1024,
        /// <summary>
        /// The accept no draw default rect im gui drag drop flags
        /// </summary>
        AcceptNoDrawDefaultRect = 2048,
        /// <summary>
        /// The accept no preview tooltip im gui drag drop flags
        /// </summary>
        AcceptNoPreviewTooltip = 4096,
        /// <summary>
        /// The accept peek only im gui drag drop flags
        /// </summary>
        AcceptPeekOnly = 3072,
    }
}
