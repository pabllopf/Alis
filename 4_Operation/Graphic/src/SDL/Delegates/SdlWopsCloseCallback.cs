using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL.Delegates
{
    /// <summary>
    ///     The sdl wops close callback
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int SdlWopsCloseCallback(IntPtr context);
}