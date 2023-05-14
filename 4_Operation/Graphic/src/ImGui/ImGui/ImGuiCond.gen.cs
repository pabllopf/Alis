namespace Alis.Core.Graphic.ImGui.ImGui
{
    /// <summary>
    /// The im gui cond enum
    /// </summary>
    public enum ImGuiCond
    {
        /// <summary>
        /// The none im gui cond
        /// </summary>
        None = 0,
        /// <summary>
        /// The always im gui cond
        /// </summary>
        Always = 1,
        /// <summary>
        /// The once im gui cond
        /// </summary>
        Once = 2,
        /// <summary>
        /// The first use ever im gui cond
        /// </summary>
        FirstUseEver = 4,
        /// <summary>
        /// The appearing im gui cond
        /// </summary>
        Appearing = 8,
    }
}
