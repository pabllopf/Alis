using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL.Delegates
{
    /// <summary>
    ///     The sdl event filter
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int SdlEventFilter(IntPtr userdata, IntPtr sdlEvent);
}