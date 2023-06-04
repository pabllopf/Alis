using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdlr wops seek callback
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long SdlrWopsSeekCallback(
        IntPtr context,
        long offset,
        int whence
    );
}