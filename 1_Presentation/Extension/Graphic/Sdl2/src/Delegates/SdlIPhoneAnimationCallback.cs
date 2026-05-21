

using System;
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Delegates
{
    /// <summary>
    ///     The sdl iphone animation callback
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void SdlIPhoneAnimationCallback(IntPtr p);
}