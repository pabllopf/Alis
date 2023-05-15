using System.Numerics;

namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    /// The platform getwindowsize
    /// </summary>
    public unsafe delegate void Platform_GetWindowSize(ImGuiViewportPtr vp, Vector2* outSize);
}