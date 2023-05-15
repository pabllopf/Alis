namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    /// The im gui backend flags enum
    /// </summary>
    [System.Flags]
    public enum ImGuiBackendFlags
    {
        /// <summary>
        /// The none im gui backend flags
        /// </summary>
        None = 0,
        /// <summary>
        /// The has gamepad im gui backend flags
        /// </summary>
        HasGamepad = 1,
        /// <summary>
        /// The has mouse cursors im gui backend flags
        /// </summary>
        HasMouseCursors = 2,
        /// <summary>
        /// The has set mouse pos im gui backend flags
        /// </summary>
        HasSetMousePos = 4,
        /// <summary>
        /// The renderer has vtx offset im gui backend flags
        /// </summary>
        RendererHasVtxOffset = 8,
        /// <summary>
        /// The platform has viewports im gui backend flags
        /// </summary>
        PlatformHasViewports = 1024,
        /// <summary>
        /// The has mouse hovered viewport im gui backend flags
        /// </summary>
        HasMouseHoveredViewport = 2048,
        /// <summary>
        /// The renderer has viewports im gui backend flags
        /// </summary>
        RendererHasViewports = 4096,
    }
}
