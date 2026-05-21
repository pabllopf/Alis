

using System;
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The internal android wm info
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct InternalAndroidWmInfo
    {
        /// <summary>
        ///     Refers to an ANativeWindow
        /// </summary>
        public IntPtr Window { get; set; }

        /// <summary>
        ///     Refers to an EGLSurface
        /// </summary>
        public IntPtr Surface { get; set; }
    }
}