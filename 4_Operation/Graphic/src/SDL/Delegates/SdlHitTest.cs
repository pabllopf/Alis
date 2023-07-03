using System;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.SDL.Enums;

namespace Alis.Core.Graphic.SDL.Delegates
{
    /// <summary>
    ///     The sdl hit test
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate SdlHitTestResult SdlHitTest(IntPtr win, IntPtr area, IntPtr data);
}