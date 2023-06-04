using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdlr wops write callback
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr SdlrWopsWriteCallback(
        IntPtr context,
        IntPtr ptr,
        IntPtr size,
        IntPtr num
    );
}