using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl eventfilter
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int SdlEventFilter(
        IntPtr userdata, 
        IntPtr sdlevent 
    );
}