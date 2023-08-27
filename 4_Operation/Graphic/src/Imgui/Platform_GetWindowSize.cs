using System.Numerics;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The platform getwindowsize
    /// </summary>
    public unsafe delegate void PlatformGetWindowSize(ImGuiViewportPtr vp, Vector2* outSize);
}