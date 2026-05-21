

using System;
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The internal x11 wm info
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct InternalX11WmInfo
    {
        /// <summary>
        ///     Refers to a Display*
        /// </summary>
        public IntPtr Display { get; set; }

        /// <summary>
        ///     Refers to a Window (XID, use ToInt64!)
        /// </summary>
        public IntPtr Window { get; set; }
    }
}