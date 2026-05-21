

using System;
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Delegates
{
    /// <summary>
    ///     The sdl wops size callback
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long SdlWopsSizeCallback(IntPtr context);
}