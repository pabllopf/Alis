using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL.Delegates
{
    /// <summary>
    ///     The sdl wops seek callback
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long SdlWopsSeekCallback(IntPtr context, long offset, int whence);
}