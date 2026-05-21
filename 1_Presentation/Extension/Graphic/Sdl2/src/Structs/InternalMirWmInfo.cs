

using System;
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The internal mir wm info
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct InternalMirWmInfo
    {
        /// <summary>
        ///     Refers to a MirConnection*
        /// </summary>
        public IntPtr Connection { get; set; }

        /// <summary>
        ///     Refers to a MirSurface*
        /// </summary>
        public IntPtr Surface { get; set; }
    }
}