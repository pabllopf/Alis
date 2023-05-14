namespace Alis.Core.Graphic.ImGui.ImGui
{
    /// <summary>
    /// The im draw list flags enum
    /// </summary>
    [System.Flags]
    public enum ImDrawListFlags
    {
        /// <summary>
        /// The none im draw list flags
        /// </summary>
        None = 0,
        /// <summary>
        /// The anti aliased lines im draw list flags
        /// </summary>
        AntiAliasedLines = 1,
        /// <summary>
        /// The anti aliased lines use tex im draw list flags
        /// </summary>
        AntiAliasedLinesUseTex = 2,
        /// <summary>
        /// The anti aliased fill im draw list flags
        /// </summary>
        AntiAliasedFill = 4,
        /// <summary>
        /// The allow vtx offset im draw list flags
        /// </summary>
        AllowVtxOffset = 8,
    }
}
