namespace Alis.Core.Graphic.ImGui.ImGui
{
    /// <summary>
    /// The im gui tree node flags enum
    /// </summary>
    [System.Flags]
    public enum ImGuiTreeNodeFlags
    {
        /// <summary>
        /// The none im gui tree node flags
        /// </summary>
        None = 0,
        /// <summary>
        /// The selected im gui tree node flags
        /// </summary>
        Selected = 1,
        /// <summary>
        /// The framed im gui tree node flags
        /// </summary>
        Framed = 2,
        /// <summary>
        /// The allow item overlap im gui tree node flags
        /// </summary>
        AllowItemOverlap = 4,
        /// <summary>
        /// The no tree push on open im gui tree node flags
        /// </summary>
        NoTreePushOnOpen = 8,
        /// <summary>
        /// The no auto open on log im gui tree node flags
        /// </summary>
        NoAutoOpenOnLog = 16,
        /// <summary>
        /// The default open im gui tree node flags
        /// </summary>
        DefaultOpen = 32,
        /// <summary>
        /// The open on double click im gui tree node flags
        /// </summary>
        OpenOnDoubleClick = 64,
        /// <summary>
        /// The open on arrow im gui tree node flags
        /// </summary>
        OpenOnArrow = 128,
        /// <summary>
        /// The leaf im gui tree node flags
        /// </summary>
        Leaf = 256,
        /// <summary>
        /// The bullet im gui tree node flags
        /// </summary>
        Bullet = 512,
        /// <summary>
        /// The frame padding im gui tree node flags
        /// </summary>
        FramePadding = 1024,
        /// <summary>
        /// The span avail width im gui tree node flags
        /// </summary>
        SpanAvailWidth = 2048,
        /// <summary>
        /// The span full width im gui tree node flags
        /// </summary>
        SpanFullWidth = 4096,
        /// <summary>
        /// The nav left jumps back here im gui tree node flags
        /// </summary>
        NavLeftJumpsBackHere = 8192,
        /// <summary>
        /// The collapsing header im gui tree node flags
        /// </summary>
        CollapsingHeader = 26,
    }
}
