using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl logoutputfunction
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void SdlLogOutputFunction(
        IntPtr userdata,
        int category,
        SdlLogPriority priority,
        IntPtr message
    );
}