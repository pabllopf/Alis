using System;
using System.Runtime.CompilerServices;

namespace ImGuiNET
{
    /// <summary>
    /// The im gui platform io
    /// </summary>
    public unsafe partial struct ImGuiPlatformIO
    {
        /// <summary>
        /// The platform createwindow
        /// </summary>
        public IntPtr Platform_CreateWindow;
        /// <summary>
        /// The platform destroywindow
        /// </summary>
        public IntPtr Platform_DestroyWindow;
        /// <summary>
        /// The platform showwindow
        /// </summary>
        public IntPtr Platform_ShowWindow;
        /// <summary>
        /// The platform setwindowpos
        /// </summary>
        public IntPtr Platform_SetWindowPos;
        /// <summary>
        /// The platform getwindowpos
        /// </summary>
        public IntPtr Platform_GetWindowPos;
        /// <summary>
        /// The platform setwindowsize
        /// </summary>
        public IntPtr Platform_SetWindowSize;
        /// <summary>
        /// The platform getwindowsize
        /// </summary>
        public IntPtr Platform_GetWindowSize;
        /// <summary>
        /// The platform setwindowfocus
        /// </summary>
        public IntPtr Platform_SetWindowFocus;
        /// <summary>
        /// The platform getwindowfocus
        /// </summary>
        public IntPtr Platform_GetWindowFocus;
        /// <summary>
        /// The platform getwindowminimized
        /// </summary>
        public IntPtr Platform_GetWindowMinimized;
        /// <summary>
        /// The platform setwindowtitle
        /// </summary>
        public IntPtr Platform_SetWindowTitle;
        /// <summary>
        /// The platform setwindowalpha
        /// </summary>
        public IntPtr Platform_SetWindowAlpha;
        /// <summary>
        /// The platform updatewindow
        /// </summary>
        public IntPtr Platform_UpdateWindow;
        /// <summary>
        /// The platform renderwindow
        /// </summary>
        public IntPtr Platform_RenderWindow;
        /// <summary>
        /// The platform swapbuffers
        /// </summary>
        public IntPtr Platform_SwapBuffers;
        /// <summary>
        /// The platform getwindowdpiscale
        /// </summary>
        public IntPtr Platform_GetWindowDpiScale;
        /// <summary>
        /// The platform onchangedviewport
        /// </summary>
        public IntPtr Platform_OnChangedViewport;
        /// <summary>
        /// The platform createvksurface
        /// </summary>
        public IntPtr Platform_CreateVkSurface;
        /// <summary>
        /// The renderer createwindow
        /// </summary>
        public IntPtr Renderer_CreateWindow;
        /// <summary>
        /// The renderer destroywindow
        /// </summary>
        public IntPtr Renderer_DestroyWindow;
        /// <summary>
        /// The renderer setwindowsize
        /// </summary>
        public IntPtr Renderer_SetWindowSize;
        /// <summary>
        /// The renderer renderwindow
        /// </summary>
        public IntPtr Renderer_RenderWindow;
        /// <summary>
        /// The renderer swapbuffers
        /// </summary>
        public IntPtr Renderer_SwapBuffers;
        /// <summary>
        /// The monitors
        /// </summary>
        public ImVector Monitors;
        /// <summary>
        /// The viewports
        /// </summary>
        public ImVector Viewports;
    }
    /// <summary>
    /// The im gui platform io ptr
    /// </summary>
    public unsafe partial struct ImGuiPlatformIOPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImGuiPlatformIO* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiPlatformIOPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiPlatformIOPtr(ImGuiPlatformIO* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiPlatformIOPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiPlatformIOPtr(IntPtr nativePtr) => NativePtr = (ImGuiPlatformIO*)nativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiPlatformIOPtr(ImGuiPlatformIO* nativePtr) => new ImGuiPlatformIOPtr(nativePtr);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiPlatformIO* (ImGuiPlatformIOPtr wrappedPtr) => wrappedPtr.NativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiPlatformIOPtr(IntPtr nativePtr) => new ImGuiPlatformIOPtr(nativePtr);
        /// <summary>
        /// Gets the value of the platform createwindow
        /// </summary>
        public ref IntPtr Platform_CreateWindow => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_CreateWindow);
        /// <summary>
        /// Gets the value of the platform destroywindow
        /// </summary>
        public ref IntPtr Platform_DestroyWindow => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_DestroyWindow);
        /// <summary>
        /// Gets the value of the platform showwindow
        /// </summary>
        public ref IntPtr Platform_ShowWindow => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_ShowWindow);
        /// <summary>
        /// Gets the value of the platform setwindowpos
        /// </summary>
        public ref IntPtr Platform_SetWindowPos => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_SetWindowPos);
        /// <summary>
        /// Gets the value of the platform getwindowpos
        /// </summary>
        public ref IntPtr Platform_GetWindowPos => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_GetWindowPos);
        /// <summary>
        /// Gets the value of the platform setwindowsize
        /// </summary>
        public ref IntPtr Platform_SetWindowSize => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_SetWindowSize);
        /// <summary>
        /// Gets the value of the platform getwindowsize
        /// </summary>
        public ref IntPtr Platform_GetWindowSize => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_GetWindowSize);
        /// <summary>
        /// Gets the value of the platform setwindowfocus
        /// </summary>
        public ref IntPtr Platform_SetWindowFocus => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_SetWindowFocus);
        /// <summary>
        /// Gets the value of the platform getwindowfocus
        /// </summary>
        public ref IntPtr Platform_GetWindowFocus => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_GetWindowFocus);
        /// <summary>
        /// Gets the value of the platform getwindowminimized
        /// </summary>
        public ref IntPtr Platform_GetWindowMinimized => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_GetWindowMinimized);
        /// <summary>
        /// Gets the value of the platform setwindowtitle
        /// </summary>
        public ref IntPtr Platform_SetWindowTitle => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_SetWindowTitle);
        /// <summary>
        /// Gets the value of the platform setwindowalpha
        /// </summary>
        public ref IntPtr Platform_SetWindowAlpha => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_SetWindowAlpha);
        /// <summary>
        /// Gets the value of the platform updatewindow
        /// </summary>
        public ref IntPtr Platform_UpdateWindow => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_UpdateWindow);
        /// <summary>
        /// Gets the value of the platform renderwindow
        /// </summary>
        public ref IntPtr Platform_RenderWindow => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_RenderWindow);
        /// <summary>
        /// Gets the value of the platform swapbuffers
        /// </summary>
        public ref IntPtr Platform_SwapBuffers => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_SwapBuffers);
        /// <summary>
        /// Gets the value of the platform getwindowdpiscale
        /// </summary>
        public ref IntPtr Platform_GetWindowDpiScale => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_GetWindowDpiScale);
        /// <summary>
        /// Gets the value of the platform onchangedviewport
        /// </summary>
        public ref IntPtr Platform_OnChangedViewport => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_OnChangedViewport);
        /// <summary>
        /// Gets the value of the platform createvksurface
        /// </summary>
        public ref IntPtr Platform_CreateVkSurface => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_CreateVkSurface);
        /// <summary>
        /// Gets the value of the renderer createwindow
        /// </summary>
        public ref IntPtr Renderer_CreateWindow => ref Unsafe.AsRef<IntPtr>(&NativePtr->Renderer_CreateWindow);
        /// <summary>
        /// Gets the value of the renderer destroywindow
        /// </summary>
        public ref IntPtr Renderer_DestroyWindow => ref Unsafe.AsRef<IntPtr>(&NativePtr->Renderer_DestroyWindow);
        /// <summary>
        /// Gets the value of the renderer setwindowsize
        /// </summary>
        public ref IntPtr Renderer_SetWindowSize => ref Unsafe.AsRef<IntPtr>(&NativePtr->Renderer_SetWindowSize);
        /// <summary>
        /// Gets the value of the renderer renderwindow
        /// </summary>
        public ref IntPtr Renderer_RenderWindow => ref Unsafe.AsRef<IntPtr>(&NativePtr->Renderer_RenderWindow);
        /// <summary>
        /// Gets the value of the renderer swapbuffers
        /// </summary>
        public ref IntPtr Renderer_SwapBuffers => ref Unsafe.AsRef<IntPtr>(&NativePtr->Renderer_SwapBuffers);
        /// <summary>
        /// Gets the value of the monitors
        /// </summary>
        public ImPtrVector<ImGuiPlatformMonitorPtr> Monitors => new ImPtrVector<ImGuiPlatformMonitorPtr>(NativePtr->Monitors, Unsafe.SizeOf<ImGuiPlatformMonitor>());
        /// <summary>
        /// Gets the value of the viewports
        /// </summary>
        public ImVector<ImGuiViewportPtr> Viewports => new ImVector<ImGuiViewportPtr>(NativePtr->Viewports);
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImGuiPlatformIO_destroy((ImGuiPlatformIO*)(NativePtr));
        }
    }
}
