using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdlr wops read callback
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr SdlrWopsReadCallback(
        IntPtr context,
        IntPtr ptr,
        IntPtr size,
        IntPtr maxnum
    );
}