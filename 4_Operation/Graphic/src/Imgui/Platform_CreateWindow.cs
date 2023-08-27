namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The platform createwindow
    /// </summary>
    public delegate void PlatformCreateWindow(ImGuiViewportPtr vp);                    // Create a new platform window for the given viewport

    // Newly created windows are initially hidden so SetWindowPos/Size/Title can be called on them first
    // Move window to front and set input focus
}
