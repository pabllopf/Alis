using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl audiocallback
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void SdlAudioCallback(
        IntPtr userdata,
        IntPtr stream,
        int len
    );
}