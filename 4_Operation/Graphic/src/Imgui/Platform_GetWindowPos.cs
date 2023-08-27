using System.Numerics;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The platform getwindowpos
    /// </summary>
    public unsafe delegate void PlatformGetWindowPos(ImGuiViewportPtr vp, Vector2* outPos);
}