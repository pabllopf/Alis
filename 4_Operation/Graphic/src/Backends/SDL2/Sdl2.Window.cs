using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Alis.Core.Graphic.Backends.SDL2
{
    /// <summary>
    /// The sdl native class
    /// </summary>
    public static unsafe partial class Sdl2Native
    {
        /// <summary>
        /// A special sentinel value indicating that a newly-created window should be centered in the screen.
        /// </summary>
        public const int SDL_WINDOWPOS_CENTERED = 0x2FFF0000;

        /// <summary>
        /// The sdl createwindow
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Window SDL_CreateWindow_t(byte* title, int x, int y, int w, int h, SDL_WindowFlags flags);
        /// <summary>
        /// The sdl createwindow
        /// </summary>
        private static SDL_CreateWindow_t s_sdl_createWindow = LoadFunction<SDL_CreateWindow_t>("SDL_CreateWindow");
        /// <summary>
        /// Sdls the create window using the specified title
        /// </summary>
        /// <param name="title">The title</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <param name="flags">The flags</param>
        /// <returns>The sdl window</returns>
        public static SDL_Window SDL_CreateWindow(string title, int x, int y, int w, int h, SDL_WindowFlags flags)
        {
            byte* utf8Bytes;
            if (title != null)
            {
                int byteCount = Encoding.UTF8.GetByteCount(title);
                if (byteCount == 0)
                {
                    byte zeroByte = 0;
                    utf8Bytes = &zeroByte;
                }
                else
                {
                    byte* utf8BytesAlloc = stackalloc byte[byteCount + 1];
                    utf8Bytes = utf8BytesAlloc;
                    fixed (char* titlePtr = title)
                    {
                        int actualBytes = Encoding.UTF8.GetBytes(titlePtr, title.Length, utf8Bytes, byteCount);
                        utf8Bytes[actualBytes] = 0;
                    }
                }
            }
            else
            {
                utf8Bytes = null;
            }

            return s_sdl_createWindow(utf8Bytes, x, y, w, h, flags);
        }

        /// <summary>
        /// The sdl createwindowfrom
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Window SDL_CreateWindowFrom_t(IntPtr data);
        /// <summary>
        /// The sdl createwindowfrom
        /// </summary>
        private static SDL_CreateWindowFrom_t s_sdl_createWindowFrom = LoadFunction<SDL_CreateWindowFrom_t>("SDL_CreateWindowFrom");
        /// <summary>
        /// Sdls the create window from using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The sdl window</returns>
        public static SDL_Window SDL_CreateWindowFrom(IntPtr data) => s_sdl_createWindowFrom(data);

        /// <summary>
        /// The sdl destroywindow
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_DestroyWindow_t(SDL_Window SDL2Window);
        /// <summary>
        /// The sdl destroywindow
        /// </summary>
        private static SDL_DestroyWindow_t s_sdl_destroyWindow = LoadFunction<SDL_DestroyWindow_t>("SDL_DestroyWindow");
        /// <summary>
        /// Sdls the destroy window using the specified sdl 2 window
        /// </summary>
        /// <param name="Sdl2Window">The sdl window</param>
        public static void SDL_DestroyWindow(SDL_Window Sdl2Window) => s_sdl_destroyWindow(Sdl2Window);

        /// <summary>
        /// The sdl getwindowsize
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_GetWindowSize_t(SDL_Window SDL2Window, int* w, int* h);
        /// <summary>
        /// The sdl getwindowsize
        /// </summary>
        private static SDL_GetWindowSize_t s_getWindowSize = LoadFunction<SDL_GetWindowSize_t>("SDL_GetWindowSize");
        /// <summary>
        /// Sdls the get window size using the specified sdl 2 window
        /// </summary>
        /// <param name="Sdl2Window">The sdl window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        public static void SDL_GetWindowSize(SDL_Window Sdl2Window, int* w, int* h) => s_getWindowSize(Sdl2Window, w, h);

        /// <summary>
        /// The sdl getwindowposition
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_GetWindowPosition_t(SDL_Window SDL2Window, int* x, int* y);
        /// <summary>
        /// The sdl getwindowposition
        /// </summary>
        private static SDL_GetWindowPosition_t s_getWindowPosition = LoadFunction<SDL_GetWindowPosition_t>("SDL_GetWindowPosition");
        /// <summary>
        /// Sdls the get window position using the specified sdl 2 window
        /// </summary>
        /// <param name="Sdl2Window">The sdl window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        public static void SDL_GetWindowPosition(SDL_Window Sdl2Window, int* x, int* y) => s_getWindowPosition(Sdl2Window, x, y);

        /// <summary>
        /// The sdl setwindowposition
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_SetWindowPosition_t(SDL_Window SDL2Window, int x, int y);
        /// <summary>
        /// The sdl setwindowposition
        /// </summary>
        private static SDL_SetWindowPosition_t s_setWindowPosition = LoadFunction<SDL_SetWindowPosition_t>("SDL_SetWindowPosition");
        /// <summary>
        /// Sdls the set window position using the specified sdl 2 window
        /// </summary>
        /// <param name="Sdl2Window">The sdl window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        public static void SDL_SetWindowPosition(SDL_Window Sdl2Window, int x, int y) => s_setWindowPosition(Sdl2Window, x, y);

        /// <summary>
        /// The sdl setwindowsize
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_SetWindowSize_t(SDL_Window SDL2Window, int w, int h);
        /// <summary>
        /// The sdl setwindowsize
        /// </summary>
        private static SDL_SetWindowSize_t s_setWindowSize = LoadFunction<SDL_SetWindowSize_t>("SDL_SetWindowSize");
        /// <summary>
        /// Sdls the set window size using the specified sdl 2 window
        /// </summary>
        /// <param name="Sdl2Window">The sdl window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        public static void SDL_SetWindowSize(SDL_Window Sdl2Window, int w, int h) => s_setWindowSize(Sdl2Window, w, h);

        /// <summary>
        /// The sdl getwindowtitle
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate string SDL_GetWindowTitle_t(SDL_Window SDL2Window);
        /// <summary>
        /// The sdl getwindowtitle
        /// </summary>
        private static SDL_GetWindowTitle_t s_getWindowTitle = LoadFunction<SDL_GetWindowTitle_t>("SDL_GetWindowTitle");
        /// <summary>
        /// Sdls the get window title using the specified sdl 2 window
        /// </summary>
        /// <param name="Sdl2Window">The sdl window</param>
        /// <returns>The string</returns>
        public static string SDL_GetWindowTitle(SDL_Window Sdl2Window) => s_getWindowTitle(Sdl2Window);

        /// <summary>
        /// The sdl setwindowtitle
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_SetWindowTitle_t(SDL_Window SDL2Window, byte* title);
        /// <summary>
        /// The sdl setwindowtitle
        /// </summary>
        private static SDL_SetWindowTitle_t s_setWindowTitle = LoadFunction<SDL_SetWindowTitle_t>("SDL_SetWindowTitle");
        /// <summary>
        /// Sdls the set window title using the specified sdl 2 window
        /// </summary>
        /// <param name="Sdl2Window">The sdl window</param>
        /// <param name="title">The title</param>
        public static void SDL_SetWindowTitle(SDL_Window Sdl2Window, string title)
        {
            byte* utf8Bytes;
            if (title != null)
            {
                int byteCount = Encoding.UTF8.GetByteCount(title);
                if (byteCount == 0)
                {
                    byte zeroByte = 0;
                    utf8Bytes = &zeroByte;
                }
                else
                {
                    byte* utf8BytesAlloc = stackalloc byte[byteCount + 1];
                    utf8Bytes = utf8BytesAlloc;
                    fixed (char* titlePtr = title)
                    {
                        int actualBytes = Encoding.UTF8.GetBytes(titlePtr, title.Length, utf8Bytes, byteCount);
                        utf8Bytes[actualBytes] = 0;
                    }
                }
            }
            else
            {
                utf8Bytes = null;
            }

            s_setWindowTitle(Sdl2Window, utf8Bytes);
        }

        /// <summary>
        /// The sdl getwindowflags
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_WindowFlags SDL_GetWindowFlags_t(SDL_Window SDL2Window);
        /// <summary>
        /// The sdl getwindowflags
        /// </summary>
        private static SDL_GetWindowFlags_t s_getWindowFlags = LoadFunction<SDL_GetWindowFlags_t>("SDL_GetWindowFlags");
        /// <summary>
        /// Sdls the get window flags using the specified sdl 2 window
        /// </summary>
        /// <param name="Sdl2Window">The sdl window</param>
        /// <returns>The sdl window flags</returns>
        public static SDL_WindowFlags SDL_GetWindowFlags(SDL_Window Sdl2Window) => s_getWindowFlags(Sdl2Window);

        /// <summary>
        /// The sdl setwindowbordered
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_SetWindowBordered_t(SDL_Window SDL2Window, uint bordered);
        /// <summary>
        /// The sdl setwindowbordered
        /// </summary>
        private static SDL_SetWindowBordered_t s_setWindowBordered = LoadFunction<SDL_SetWindowBordered_t>("SDL_SetWindowBordered");
        /// <summary>
        /// Sdls the set window bordered using the specified sdl 2 window
        /// </summary>
        /// <param name="Sdl2Window">The sdl window</param>
        /// <param name="bordered">The bordered</param>
        public static void SDL_SetWindowBordered(SDL_Window Sdl2Window, uint bordered) => s_setWindowBordered(Sdl2Window, bordered);

        /// <summary>
        /// The sdl maximizewindow
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_MaximizeWindow_t(SDL_Window SDL2Window);
        /// <summary>
        /// The sdl maximizewindow
        /// </summary>
        private static SDL_MaximizeWindow_t s_maximizeWindow = LoadFunction<SDL_MaximizeWindow_t>("SDL_MaximizeWindow");
        /// <summary>
        /// Sdls the maximize window using the specified sdl 2 window
        /// </summary>
        /// <param name="Sdl2Window">The sdl window</param>
        public static void SDL_MaximizeWindow(SDL_Window Sdl2Window) => s_maximizeWindow(Sdl2Window);

        /// <summary>
        /// The sdl minimizewindow
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_MinimizeWindow_t(SDL_Window SDL2Window);
        /// <summary>
        /// The sdl minimizewindow
        /// </summary>
        private static SDL_MinimizeWindow_t s_minimizeWindow = LoadFunction<SDL_MinimizeWindow_t>("SDL_MinimizeWindow");
        /// <summary>
        /// Sdls the minimize window using the specified sdl 2 window
        /// </summary>
        /// <param name="Sdl2Window">The sdl window</param>
        public static void SDL_MinimizeWindow(SDL_Window Sdl2Window) => s_minimizeWindow(Sdl2Window);

        /// <summary>
        /// The sdl raisewindow
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_RaiseWindow_t(SDL_Window SDL2Window);
        /// <summary>
        /// The sdl raisewindow
        /// </summary>
        private static SDL_RaiseWindow_t s_raiseWindow = LoadFunction<SDL_RaiseWindow_t>("SDL_RaiseWindow");
        /// <summary>
        /// Sdls the raise window using the specified sdl 2 window
        /// </summary>
        /// <param name="Sdl2Window">The sdl window</param>
        public static void SDL_RaiseWindow(SDL_Window Sdl2Window) => s_raiseWindow(Sdl2Window);

        /// <summary>
        /// The sdl setwindowfullscreen
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetWindowFullscreen_t(SDL_Window Sdl2Window, SDL_FullscreenMode mode);
        /// <summary>
        /// The sdl setwindowfullscreen
        /// </summary>
        private static SDL_SetWindowFullscreen_t s_setWindowFullscreen = LoadFunction<SDL_SetWindowFullscreen_t>("SDL_SetWindowFullscreen");
        /// <summary>
        /// Sdls the set window fullscreen using the specified sdl 2 window
        /// </summary>
        /// <param name="Sdl2Window">The sdl window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        public static int SDL_SetWindowFullscreen(SDL_Window Sdl2Window, SDL_FullscreenMode mode) => s_setWindowFullscreen(Sdl2Window, mode);

        /// <summary>
        /// The sdl showwindow
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_ShowWindow_t(SDL_Window SDL2Window);
        /// <summary>
        /// The sdl showwindow
        /// </summary>
        private static SDL_ShowWindow_t s_showWindow = LoadFunction<SDL_ShowWindow_t>("SDL_ShowWindow");
        /// <summary>
        /// Sdls the show window using the specified sdl 2 window
        /// </summary>
        /// <param name="Sdl2Window">The sdl window</param>
        public static void SDL_ShowWindow(SDL_Window Sdl2Window) => s_showWindow(Sdl2Window);

        /// <summary>
        /// The sdl hidewindow
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_HideWindow_t(SDL_Window SDL2Window);
        /// <summary>
        /// The sdl hidewindow
        /// </summary>
        private static SDL_HideWindow_t s_hideWindow = LoadFunction<SDL_HideWindow_t>("SDL_HideWindow");
        /// <summary>
        /// Sdls the hide window using the specified sdl 2 window
        /// </summary>
        /// <param name="Sdl2Window">The sdl window</param>
        public static void SDL_HideWindow(SDL_Window Sdl2Window) => s_hideWindow(Sdl2Window);

        /// <summary>
        /// The sdl getwindowid
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint SDL_GetWindowID_t(SDL_Window SDL2Window);
        /// <summary>
        /// The sdl getwindowid
        /// </summary>
        private static SDL_GetWindowID_t s_getWindowID = LoadFunction<SDL_GetWindowID_t>("SDL_GetWindowID");
        /// <summary>
        /// Sdls the get window id using the specified sdl 2 window
        /// </summary>
        /// <param name="Sdl2Window">The sdl window</param>
        /// <returns>The uint</returns>
        public static uint SDL_GetWindowID(SDL_Window Sdl2Window) => s_getWindowID(Sdl2Window);

        /// <summary>
        /// The sdl setwindowopacity
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetWindowOpacity_t(SDL_Window window, float opacity);
        /// <summary>
        /// The sdl setwindowopacity
        /// </summary>
        private static SDL_SetWindowOpacity_t s_setWindowOpacity = LoadFunction<SDL_SetWindowOpacity_t>("SDL_SetWindowOpacity");
        /// <summary>
        /// Sdls the set window opacity using the specified sdl 2 window
        /// </summary>
        /// <param name="Sdl2Window">The sdl window</param>
        /// <param name="opacity">The opacity</param>
        /// <returns>The int</returns>
        public static int SDL_SetWindowOpacity(SDL_Window Sdl2Window, float opacity) => s_setWindowOpacity(Sdl2Window, opacity);

        /// <summary>
        /// The sdl getwindowopacity
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetWindowOpacity_t(SDL_Window window, float* opacity);
        /// <summary>
        /// The sdl getwindowopacity
        /// </summary>
        private static SDL_GetWindowOpacity_t s_getWindowOpacity = LoadFunction<SDL_GetWindowOpacity_t>("SDL_GetWindowOpacity");
        /// <summary>
        /// Sdls the get window opacity using the specified sdl 2 window
        /// </summary>
        /// <param name="Sdl2Window">The sdl window</param>
        /// <param name="opacity">The opacity</param>
        /// <returns>The int</returns>
        public static int SDL_GetWindowOpacity(SDL_Window Sdl2Window, float* opacity) => s_getWindowOpacity(Sdl2Window, opacity);

        /// <summary>
        /// The sdl setwindowresizable
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_SetWindowResizable_t(SDL_Window window, uint resizable);
        /// <summary>
        /// The sdl setwindowresizable
        /// </summary>
        private static SDL_SetWindowResizable_t s_setWindowResizable = LoadFunction<SDL_SetWindowResizable_t>("SDL_SetWindowResizable");
        /// <summary>
        /// Sdls the set window resizable using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="resizable">The resizable</param>
        public static void SDL_SetWindowResizable(SDL_Window window, uint resizable) => s_setWindowResizable(window, resizable);

        /// <summary>
        /// The sdl getdisplaybounds
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetDisplayBounds_t(int displayIndex, Rectangle* rect);
        /// <summary>
        /// The sdl getdisplaybounds
        /// </summary>
        private static SDL_GetDisplayBounds_t s_sdl_getDisplayBounds = LoadFunction<SDL_GetDisplayBounds_t>("SDL_GetDisplayBounds");
        /// <summary>
        /// Sdls the get display bounds using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        public static int SDL_GetDisplayBounds(int displayIndex, Rectangle* rect) => s_sdl_getDisplayBounds(displayIndex, rect);

        /// <summary>
        /// The sdl getwindowdisplayindex
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetWindowDisplayIndex_t(SDL_Window window);
        /// <summary>
        /// The sdl getwindowdisplayindex
        /// </summary>
        private static SDL_GetWindowDisplayIndex_t s_sdl_getWindowDisplayIndex = LoadFunction<SDL_GetWindowDisplayIndex_t>("SDL_GetWindowDisplayIndex");
        /// <summary>
        /// Sdls the get window display index using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        public static int SDL_GetWindowDisplayIndex(SDL_Window window) => s_sdl_getWindowDisplayIndex(window);

        /// <summary>
        /// The sdl getcurrentdisplaymode
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetCurrentDisplayMode_t(int displayIndex, SDL_DisplayMode* mode);
        /// <summary>
        /// The sdl getcurrentdisplaymode
        /// </summary>
        private static SDL_GetCurrentDisplayMode_t s_sdl_getCurrentDisplayMode = LoadFunction<SDL_GetCurrentDisplayMode_t>("SDL_GetCurrentDisplayMode");
        /// <summary>
        /// Sdls the get current display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        public static int SDL_GetCurrentDisplayMode(int displayIndex, SDL_DisplayMode* mode) => s_sdl_getCurrentDisplayMode(displayIndex, mode);

        /// <summary>
        /// The sdl getdesktopdisplaymode
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetDesktopDisplayMode_t(int displayIndex, SDL_DisplayMode* mode);
        /// <summary>
        /// The sdl getdesktopdisplaymode
        /// </summary>
        private static SDL_GetDesktopDisplayMode_t s_sdl_getDesktopDisplayMode = LoadFunction<SDL_GetDesktopDisplayMode_t>("SDL_GetDesktopDisplayMode");
        /// <summary>
        /// Sdls the get desktop display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        public static int SDL_GetDesktopDisplayMode(int displayIndex, SDL_DisplayMode* mode) => s_sdl_getDesktopDisplayMode(displayIndex, mode);

        /// <summary>
        /// The sdl getnumvideodisplays
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetNumVideoDisplays_t();
        /// <summary>
        /// The sdl getnumvideodisplays
        /// </summary>
        private static SDL_GetNumVideoDisplays_t s_sdl_getNumVideoDisplays = LoadFunction<SDL_GetNumVideoDisplays_t>("SDL_GetNumVideoDisplays");
        /// <summary>
        /// Sdls the get num video displays
        /// </summary>
        /// <returns>The int</returns>
        public static int SDL_GetNumVideoDisplays() => s_sdl_getNumVideoDisplays();

        /// <summary>
        /// The sdl sethint
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private delegate bool SDL_SetHint_t(string name, string value);
        /// <summary>
        /// The sdl sethint
        /// </summary>
        private static SDL_SetHint_t s_sdl_setHint = LoadFunction<SDL_SetHint_t>("SDL_SetHint");
        /// <summary>
        /// Describes whether sdl set hint
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        public static bool SDL_SetHint(string name, string value) => s_sdl_setHint(name, value);

    }

    /// <summary>
    /// The sdl windowflags enum
    /// </summary>
    [Flags]
    public enum SDL_WindowFlags : uint
    {
        /// <summary>
        /// fullscreen Sdl2Window.
        /// </summary>
        Fullscreen = 0x00000001,
        /// <summary>
        /// Sdl2Window usable with OpenGL context.
        /// </summary>
        OpenGL = 0x00000002,
        /// <summary>
        /// Sdl2Window is visible.
        /// </summary>
        Shown = 0x00000004,
        /// <summary>
        /// Sdl2Window is not visible.
        /// </summary>
        Hidden = 0x00000008,
        /// <summary>
        /// no Sdl2Window decoration.
        /// </summary>
        Borderless = 0x00000010,
        /// <summary>
        /// Sdl2Window can be resized.
        /// </summary>
        Resizable = 0x00000020,
        /// <summary>
        /// Sdl2Window is minimized.
        /// </summary>
        Minimized = 0x00000040,
        /// <summary>
        /// Sdl2Window is maximized.
        /// </summary>
        Maximized = 0x00000080,
        /// <summary>
        /// Sdl2Window has grabbed input focus.
        /// </summary>
        InputGrabbed = 0x00000100,
        /// <summary>
        /// Sdl2Window has input focus.
        /// </summary>
        InputFocus = 0x00000200,
        /// <summary>
        /// Sdl2Window has mouse focus.
        /// </summary>
        MouseFocus = 0x00000400,
        /// <summary>
        /// The full screen desktop sdl windowflags
        /// </summary>
        FullScreenDesktop = (Fullscreen | 0x00001000),
        /// <summary>
        /// Sdl2Window not created by SDL.
        /// </summary>
        Foreign = 0x00000800,
        /// <summary>
        /// Sdl2Window should be created in high-DPI mode if supported.
        /// </summary>
        AllowHighDpi = 0x00002000,
        /// <summary>
        /// Sdl2Window has mouse captured (unrelated to InputGrabbed).
        /// </summary>
        MouseCapture = 0x00004000,
        /// <summary>
        /// Sdl2Window should always be above others.
        /// </summary>
        AlwaysOnTop = 0x00008000,
        /// <summary>
        /// Sdl2Window should not be added to the taskbar.
        /// </summary>
        SkipTaskbar = 0x00010000,
        /// <summary>
        /// Sdl2Window should be treated as a utility Sdl2Window.
        /// </summary>
        Utility = 0x00020000,
        /// <summary>
        /// Sdl2Window should be treated as a tooltip.
        /// </summary>
        Tooltip = 0x00040000,
        /// <summary>
        /// Sdl2Window should be treated as a popup menu.
        /// </summary>
        PopupMenu = 0x00080000
    }

    /// <summary>
    /// The sdl fullscreenmode enum
    /// </summary>
    public enum SDL_FullscreenMode : uint
    {
        /// <summary>
        /// The windowed sdl fullscreenmode
        /// </summary>
        Windowed = 0,
        /// <summary>
        /// The fullscreen sdl fullscreenmode
        /// </summary>
        Fullscreen = 0x00000001,
        /// <summary>
        /// The full screen desktop sdl fullscreenmode
        /// </summary>
        FullScreenDesktop = (Fullscreen | 0x00001000),
    }

    /// <summary>
    /// The sdl displaymode
    /// </summary>
    public unsafe struct SDL_DisplayMode
    {
        /// <summary>
        /// The format
        /// </summary>
        public uint format;
        /// <summary>
        /// The 
        /// </summary>
        public int w;
        /// <summary>
        /// The 
        /// </summary>
        public int h;
        /// <summary>
        /// The refresh rate
        /// </summary>
        public int refresh_rate;
        /// <summary>
        /// The driverdata
        /// </summary>
        public void* driverdata;
    }
}
