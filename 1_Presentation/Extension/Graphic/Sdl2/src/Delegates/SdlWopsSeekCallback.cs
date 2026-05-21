

using System;
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Delegates
{
    /// <summary>
    ///     The sdl wops seek callback
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long SdlWopsSeekCallback(IntPtr context, long offset, int whence);
}