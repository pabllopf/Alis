using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Backends.SDL2
{
    /// <summary>
    /// The sdl native class
    /// </summary>
    public static unsafe partial class Sdl2Native
    {
        /// <summary>
        /// The sdl getwindowwminfo
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetWindowWMInfo_t(SDL_Window Sdl2Window, SDL_SysWMinfo* info);
        /// <summary>
        /// The sdl getwindowwminfo
        /// </summary>
        private static readonly SDL_GetWindowWMInfo_t s_getWindowWMInfo = LoadFunction<SDL_GetWindowWMInfo_t>("SDL_GetWindowWMInfo");
        /// <summary>
        /// Sdls the get wm window info using the specified sdl 2 window
        /// </summary>
        /// <param name="Sdl2Window">The sdl window</param>
        /// <param name="info">The info</param>
        /// <returns>The int</returns>
        public static int SDL_GetWMWindowInfo(SDL_Window Sdl2Window, SDL_SysWMinfo* info) => s_getWindowWMInfo(Sdl2Window, info);
    }

    /// <summary>
    /// The sdl syswminfo
    /// </summary>
    public struct SDL_SysWMinfo
    {
        /// <summary>
        /// The version
        /// </summary>
        public SDL_version version;
        /// <summary>
        /// The subsystem
        /// </summary>
        public SysWMType subsystem;
        /// <summary>
        /// The info
        /// </summary>
        public WindowInfo info;
    }

    /// <summary>
    /// The window info
    /// </summary>
    public unsafe struct WindowInfo
    {
        /// <summary>
        /// The window info size in bytes
        /// </summary>
        public const int WindowInfoSizeInBytes = 100;
        /// <summary>
        /// The window info size in bytes
        /// </summary>
        private fixed byte bytes[WindowInfoSizeInBytes];
    }

    /// <summary>
    /// The win 32 window info
    /// </summary>
    public struct Win32WindowInfo
    {
        /// <summary>
        /// The Sdl2Window handle.
        /// </summary>
        public IntPtr Sdl2Window;
        /// <summary>
        /// The Sdl2Window device context.
        /// </summary>
        public IntPtr hdc;
        /// <summary>
        /// The instance handle.
        /// </summary>
        public IntPtr hinstance;
    }

    /// <summary>
    /// The 11 window info
    /// </summary>
    public struct X11WindowInfo
    {
        /// <summary>
        /// The display
        /// </summary>
        public IntPtr display;
        /// <summary>
        /// The sdl window
        /// </summary>
        public IntPtr Sdl2Window;
    }

    /// <summary>
    /// The wayland window info
    /// </summary>
    public struct WaylandWindowInfo
    {
        /// <summary>
        /// The display
        /// </summary>
        public IntPtr display;
        /// <summary>
        /// The surface
        /// </summary>
        public IntPtr surface;
        /// <summary>
        /// The shell surface
        /// </summary>
        public IntPtr shellSurface;
    }

    /// <summary>
    /// The cocoa window info
    /// </summary>
    public struct CocoaWindowInfo
    {
        /// <summary>
        /// The NSWindow* Cocoa window.
        /// </summary>
        public IntPtr Window;
    }

    /// <summary>
    /// The android window info
    /// </summary>
    public struct AndroidWindowInfo
    {
        /// <summary>
        /// The window
        /// </summary>
        public IntPtr window;
        /// <summary>
        /// The surface
        /// </summary>
        public IntPtr surface;
    }

    /// <summary>
    /// The sys wm type enum
    /// </summary>
    public enum SysWMType
    {
        /// <summary>
        /// The unknown sys wm type
        /// </summary>
        Unknown,
        /// <summary>
        /// The windows sys wm type
        /// </summary>
        Windows,
        /// <summary>
        /// The 11 sys wm type
        /// </summary>
        X11,
        /// <summary>
        /// The direct fb sys wm type
        /// </summary>
        DirectFB,
        /// <summary>
        /// The cocoa sys wm type
        /// </summary>
        Cocoa,
        /// <summary>
        /// The ui kit sys wm type
        /// </summary>
        UIKit,
        /// <summary>
        /// The wayland sys wm type
        /// </summary>
        Wayland,
        /// <summary>
        /// The mir sys wm type
        /// </summary>
        Mir,
        /// <summary>
        /// The win rt sys wm type
        /// </summary>
        WinRT,
        /// <summary>
        /// The android sys wm type
        /// </summary>
        Android,
        /// <summary>
        /// The vivante sys wm type
        /// </summary>
        Vivante
    }
}
