using System;
using System.Numerics;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The platform createwindow
    /// </summary>
    public delegate void Platform_CreateWindow(ImGuiViewportPtr vp);                    // Create a new platform window for the given viewport
    /// <summary>
    /// The platform destroywindow
    /// </summary>
    public delegate void Platform_DestroyWindow(ImGuiViewportPtr vp);
    /// <summary>
    /// The platform showwindow
    /// </summary>
    public delegate void Platform_ShowWindow(ImGuiViewportPtr vp);                      // Newly created windows are initially hidden so SetWindowPos/Size/Title can be called on them first
    /// <summary>
    /// The platform setwindowpos
    /// </summary>
    public delegate void Platform_SetWindowPos(ImGuiViewportPtr vp, Vector2 pos);
    /// <summary>
    /// The platform getwindowpos
    /// </summary>
    public unsafe delegate void Platform_GetWindowPos(ImGuiViewportPtr vp, Vector2* outPos);
    /// <summary>
    /// The platform setwindowsize
    /// </summary>
    public delegate void Platform_SetWindowSize(ImGuiViewportPtr vp, Vector2 size);
    /// <summary>
    /// The platform getwindowsize
    /// </summary>
    public unsafe delegate void Platform_GetWindowSize(ImGuiViewportPtr vp, Vector2* outSize);
    /// <summary>
    /// The platform setwindowfocus
    /// </summary>
    public delegate void Platform_SetWindowFocus(ImGuiViewportPtr vp);                  // Move window to front and set input focus
    /// <summary>
    /// The platform getwindowfocus
    /// </summary>
    public delegate byte Platform_GetWindowFocus(ImGuiViewportPtr vp);
    /// <summary>
    /// The platform getwindowminimized
    /// </summary>
    public delegate byte Platform_GetWindowMinimized(ImGuiViewportPtr vp);
    /// <summary>
    /// The platform setwindowtitle
    /// </summary>
    public delegate void Platform_SetWindowTitle(ImGuiViewportPtr vp, IntPtr title);
}
