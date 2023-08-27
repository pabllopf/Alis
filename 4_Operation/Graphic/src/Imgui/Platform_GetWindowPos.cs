using System.Numerics;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The platform getwindowpos
    /// </summary>
    public unsafe delegate void Platform_GetWindowPos(ImGuiViewportPtr vp, Vector2* outPos);
}