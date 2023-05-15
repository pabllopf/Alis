namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    /// The im draw flags enum
    /// </summary>
    [System.Flags]
    public enum ImDrawFlags
    {
        /// <summary>
        /// The none im draw flags
        /// </summary>
        None = 0,
        /// <summary>
        /// The closed im draw flags
        /// </summary>
        Closed = 1,
        /// <summary>
        /// The round corners top left im draw flags
        /// </summary>
        RoundCornersTopLeft = 16,
        /// <summary>
        /// The round corners top right im draw flags
        /// </summary>
        RoundCornersTopRight = 32,
        /// <summary>
        /// The round corners bottom left im draw flags
        /// </summary>
        RoundCornersBottomLeft = 64,
        /// <summary>
        /// The round corners bottom right im draw flags
        /// </summary>
        RoundCornersBottomRight = 128,
        /// <summary>
        /// The round corners none im draw flags
        /// </summary>
        RoundCornersNone = 256,
        /// <summary>
        /// The round corners top im draw flags
        /// </summary>
        RoundCornersTop = 48,
        /// <summary>
        /// The round corners bottom im draw flags
        /// </summary>
        RoundCornersBottom = 192,
        /// <summary>
        /// The round corners left im draw flags
        /// </summary>
        RoundCornersLeft = 80,
        /// <summary>
        /// The round corners right im draw flags
        /// </summary>
        RoundCornersRight = 160,
        /// <summary>
        /// The round corners all im draw flags
        /// </summary>
        RoundCornersAll = 240,
        /// <summary>
        /// The round corners default im draw flags
        /// </summary>
        RoundCornersDefault = 240,
        /// <summary>
        /// The round corners mask im draw flags
        /// </summary>
        RoundCornersMask = 496,
    }
}
