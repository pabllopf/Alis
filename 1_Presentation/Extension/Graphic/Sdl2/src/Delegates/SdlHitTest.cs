

using System;
using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Sdl2.Enums;

namespace Alis.Extension.Graphic.Sdl2.Delegates
{
    /// <summary>
    ///     The sdl hit test
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate HitTestResult SdlHitTest(IntPtr win, IntPtr area, IntPtr data);
}