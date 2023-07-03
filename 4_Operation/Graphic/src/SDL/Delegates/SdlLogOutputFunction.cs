using System;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.SDL.Enums;

namespace Alis.Core.Graphic.SDL.Delegates
{
    /// <summary>
    ///     The sdl log output function
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void SdlLogOutputFunction(IntPtr userdata, int category, SdlLogPriority priority, IntPtr message);
}