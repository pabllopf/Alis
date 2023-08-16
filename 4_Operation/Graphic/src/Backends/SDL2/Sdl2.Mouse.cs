using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Backends.SDL2
{
    /// <summary>
    /// A transparent wrapper over a pointer representing an SDL Sdl2Cursor object.
    /// </summary>
    public struct SDL_Cursor
    {
        /// <summary>
        /// The native SDL_Cursor pointer.
        /// </summary>
        public readonly IntPtr NativePointer;

        /// <summary>
        /// Initializes a new instance of the <see cref="SDL_Cursor"/> class
        /// </summary>
        /// <param name="pointer">The pointer</param>
        public SDL_Cursor(IntPtr pointer)
        {
            NativePointer = pointer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Sdl2Cursor"></param>
        /// <returns></returns>
        public static implicit operator IntPtr(SDL_Cursor Sdl2Cursor) => Sdl2Cursor.NativePointer;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pointer"></param>
        /// <returns></returns>
        public static implicit operator SDL_Cursor(IntPtr pointer) => new SDL_Cursor(pointer);
    }

    /// <summary>
    /// Cursor types for SDL_CreateSystemCursor().
    /// </summary>
    public enum SDL_SystemCursor
    {
        /// <summary>
        /// The arrow sdl systemcursor
        /// </summary>
        Arrow,
        /// <summary>
        /// The beam sdl systemcursor
        /// </summary>
        IBeam,
        /// <summary>
        /// The wait sdl systemcursor
        /// </summary>
        Wait,
        /// <summary>
        /// The crosshair sdl systemcursor
        /// </summary>
        Crosshair,
        /// <summary>
        /// The wait arrow sdl systemcursor
        /// </summary>
        WaitArrow,
        /// <summary>
        /// The size nwse sdl systemcursor
        /// </summary>
        SizeNWSE,
        /// <summary>
        /// The size nesw sdl systemcursor
        /// </summary>
        SizeNESW,
        /// <summary>
        /// The size we sdl systemcursor
        /// </summary>
        SizeWE,
        /// <summary>
        /// The size ns sdl systemcursor
        /// </summary>
        SizeNS,
        /// <summary>
        /// The size all sdl systemcursor
        /// </summary>
        SizeAll,
        /// <summary>
        /// The no sdl systemcursor
        /// </summary>
        No,
        /// <summary>
        /// The hand sdl systemcursor
        /// </summary>
        Hand
    }

    /// <summary>
    /// The sdl native class
    /// </summary>
    public static unsafe partial class Sdl2Native
    {
        /// <summary>
        /// The sdl query
        /// </summary>
        public const int SDL_QUERY = -1;
        /// <summary>
        /// The sdl disable
        /// </summary>
        public const int SDL_DISABLE = 0;
        /// <summary>
        /// The sdl enable
        /// </summary>
        public const int SDL_ENABLE = 1;

        /// <summary>
        /// The sdl showcursor
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_ShowCursor_t(int toggle);
        /// <summary>
        /// The sdl showcursor
        /// </summary>
        private static SDL_ShowCursor_t s_sdl_showCursor = LoadFunction<SDL_ShowCursor_t>("SDL_ShowCursor");
        /// <summary>
        /// Toggle whether or not the cursor should be shown.
        /// </summary>
        public static int SDL_ShowCursor(int toggle) => s_sdl_showCursor(toggle);

        /// <summary>
        /// The sdl warpmouseinwindow
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_WarpMouseInWindow_t(SDL_Window window, int x, int y);
        /// <summary>
        /// The sdl warpmouseinwindow
        /// </summary>
        private static SDL_WarpMouseInWindow_t s_sdl_warpMouseInWindow = LoadFunction<SDL_WarpMouseInWindow_t>("SDL_WarpMouseInWindow");
        /// <summary>
        /// Move mouse position to the given position in the window.
        /// </summary>
        public static void SDL_WarpMouseInWindow(SDL_Window window, int x, int y) => s_sdl_warpMouseInWindow(window, x, y);

        /// <summary>
        /// The sdl setrelativemousemode
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetRelativeMouseMode_t(bool enabled);
        /// <summary>
        /// The sdl setrelativemousemode
        /// </summary>
        private static SDL_SetRelativeMouseMode_t s_sdl_setRelativeMouseMode = LoadFunction<SDL_SetRelativeMouseMode_t>("SDL_SetRelativeMouseMode");
        /// <summary>
        /// Enable/disable relative mouse mode.
        /// If enabled mouse cursor will be hidden and only relative
        /// mouse motion events will be delivered, mouse position will not change.
        /// </summary>
        /// <returns>
        /// Returns 0 on success or a negative error code on failure; call SDL_GetError() for more information.
        /// If relative mode is not supported this returns -1.
        /// </returns>
        public static int SDL_SetRelativeMouseMode(bool enabled) => s_sdl_setRelativeMouseMode(enabled);

        /// <summary>
        /// The sdl capturemouse
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_CaptureMouse_t(bool enabled);
        /// <summary>
        /// The sdl capturemouse
        /// </summary>
        private static SDL_CaptureMouse_t s_sdl_captureMouse = LoadFunction<SDL_CaptureMouse_t>("SDL_CaptureMouse");
        /// <summary>
        /// Enable/disable capture mouse.
        /// If enabled mouse will also be tracked outside the window.
        /// </summary>
        /// <returns>
        /// Returns 0 on success or -1 if not supported; call SDL_GetError() for more information.
        /// </returns>
        public static int SDL_CaptureMouse(bool enabled) => s_sdl_captureMouse(enabled);

        /// <summary>
        /// The sdl setwindowgrab
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_SetWindowGrab_t(SDL_Window window, bool grabbed);
        /// <summary>
        /// The sdl setwindowgrab
        /// </summary>
        private static SDL_SetWindowGrab_t s_sdl_setWindowGrabbed = LoadFunction<SDL_SetWindowGrab_t>("SDL_SetWindowGrab");
        /// <summary>
        /// Enable/disable window grab mouse.
        /// If enabled mouse will be contained inside of window.
        /// </summary>
        public static void SDL_SetWindowGrab(SDL_Window window, bool grabbed) => s_sdl_setWindowGrabbed(window, grabbed);

        /// <summary>
        /// The sdl createsystemcursor
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Cursor SDL_CreateSystemCursor_t(SDL_SystemCursor id);
        /// <summary>
        /// The sdl createsystemcursor
        /// </summary>
        private static SDL_CreateSystemCursor_t s_sdl_createSystemCursor = LoadFunction<SDL_CreateSystemCursor_t>("SDL_CreateSystemCursor");
        /// <summary>
        /// Create a system cursor.
        /// </summary>
        public static SDL_Cursor SDL_CreateSystemCursor(SDL_SystemCursor id) => s_sdl_createSystemCursor(id);

        /// <summary>
        /// The sdl freecursor
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_FreeCursor_t(SDL_Cursor cursor);
        /// <summary>
        /// The sdl freecursor
        /// </summary>
        private static SDL_FreeCursor_t s_sdl_freeCursor = LoadFunction<SDL_FreeCursor_t>("SDL_FreeCursor");
        /// <summary>
        /// Free a cursor created with SDL_CreateCursor(), SDL_CreateColorCursor() or SDL_CreateSystemCursor().
        /// </summary>
        public static void SDL_FreeCursor(SDL_Cursor cursor) => s_sdl_freeCursor(cursor);

        /// <summary>
        /// The sdl getdefaultcursor
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Cursor SDL_GetDefaultCursor_t();
        /// <summary>
        /// The sdl getdefaultcursor
        /// </summary>
        private static SDL_GetDefaultCursor_t s_sdl_getDefaultCursor = LoadFunction<SDL_GetDefaultCursor_t>("SDL_GetDefaultCursor");
        /// <summary>
        /// Get the default cursor.
        /// </summary>
        public static SDL_Cursor SDL_GetDefaultCursor() => s_sdl_getDefaultCursor();

        /// <summary>
        /// The sdl setcursor
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_SetCursor_t(SDL_Cursor cursor);
        /// <summary>
        /// The sdl setcursor
        /// </summary>
        private static SDL_SetCursor_t s_sdl_setCursor = LoadFunction<SDL_SetCursor_t>("SDL_SetCursor");
        /// <summary>
        /// Set the active cursor.
        /// </summary>
        public static void SDL_SetCursor(SDL_Cursor cursor) => s_sdl_setCursor(cursor);
    }
}
