

using System;
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Delegates
{
    /// <summary>
    ///     The sdl audio callback
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void SdlAudioCallback(IntPtr userdata, IntPtr stream, int len);
}