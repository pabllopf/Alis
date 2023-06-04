using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl windowsmessagehook
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr SdlWindowsMessageHook(
        IntPtr userdata,
        IntPtr hWnd,
        uint message,
        ulong wParam,
        long lParam
    );
}