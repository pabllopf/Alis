using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl hittest
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate Sdl.SdlHitTestResult SdlHitTest(IntPtr win, IntPtr area, IntPtr data);
}