

using System;
using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Sdl2.Enums;

namespace Alis.Extension.Graphic.Sdl2.Delegates
{
    /// <summary>
    ///     The sdl log output function
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void SdlLogOutputFunction(IntPtr userdata, int category, LogPriority priority, IntPtr message);
}