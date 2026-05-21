

using System;
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Delegates
{
    /// <summary>
    ///     The sdl event filter
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int SdlEventFilter(IntPtr userdata, IntPtr sdlEvent);
}