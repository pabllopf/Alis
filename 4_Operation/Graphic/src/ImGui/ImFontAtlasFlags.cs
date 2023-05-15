namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    /// The im font atlas flags enum
    /// </summary>
    [System.Flags]
    public enum ImFontAtlasFlags
    {
        /// <summary>
        /// The none im font atlas flags
        /// </summary>
        None = 0,
        /// <summary>
        /// The no power of two height im font atlas flags
        /// </summary>
        NoPowerOfTwoHeight = 1,
        /// <summary>
        /// The no mouse cursors im font atlas flags
        /// </summary>
        NoMouseCursors = 2,
        /// <summary>
        /// The no baked lines im font atlas flags
        /// </summary>
        NoBakedLines = 4,
    }
}
