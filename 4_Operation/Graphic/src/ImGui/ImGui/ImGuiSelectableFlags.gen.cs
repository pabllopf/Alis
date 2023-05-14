namespace Alis.Core.Graphic.ImGui.ImGui
{
    /// <summary>
    /// The im gui selectable flags enum
    /// </summary>
    [System.Flags]
    public enum ImGuiSelectableFlags
    {
        /// <summary>
        /// The none im gui selectable flags
        /// </summary>
        None = 0,
        /// <summary>
        /// The dont close popups im gui selectable flags
        /// </summary>
        DontClosePopups = 1,
        /// <summary>
        /// The span all columns im gui selectable flags
        /// </summary>
        SpanAllColumns = 2,
        /// <summary>
        /// The allow double click im gui selectable flags
        /// </summary>
        AllowDoubleClick = 4,
        /// <summary>
        /// The disabled im gui selectable flags
        /// </summary>
        Disabled = 8,
        /// <summary>
        /// The allow item overlap im gui selectable flags
        /// </summary>
        AllowItemOverlap = 16,
    }
}
