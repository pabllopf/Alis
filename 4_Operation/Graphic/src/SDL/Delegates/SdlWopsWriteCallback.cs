using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL.Delegates
{
    /// <summary>
    ///     The sdl wops write callback
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr SdlWopsWriteCallback(IntPtr context, IntPtr ptr, IntPtr size, IntPtr num);
}