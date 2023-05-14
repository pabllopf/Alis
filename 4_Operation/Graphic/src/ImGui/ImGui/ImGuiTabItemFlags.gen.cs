namespace Alis.Core.Graphic.ImGui.ImGui
{
    /// <summary>
    /// The im gui tab item flags enum
    /// </summary>
    [System.Flags]
    public enum ImGuiTabItemFlags
    {
        /// <summary>
        /// The none im gui tab item flags
        /// </summary>
        None = 0,
        /// <summary>
        /// The unsaved document im gui tab item flags
        /// </summary>
        UnsavedDocument = 1,
        /// <summary>
        /// The set selected im gui tab item flags
        /// </summary>
        SetSelected = 2,
        /// <summary>
        /// The no close with middle mouse button im gui tab item flags
        /// </summary>
        NoCloseWithMiddleMouseButton = 4,
        /// <summary>
        /// The no push id im gui tab item flags
        /// </summary>
        NoPushId = 8,
        /// <summary>
        /// The no tooltip im gui tab item flags
        /// </summary>
        NoTooltip = 16,
        /// <summary>
        /// The no reorder im gui tab item flags
        /// </summary>
        NoReorder = 32,
        /// <summary>
        /// The leading im gui tab item flags
        /// </summary>
        Leading = 64,
        /// <summary>
        /// The trailing im gui tab item flags
        /// </summary>
        Trailing = 128,
    }
}
