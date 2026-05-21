

using System;
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The internal directfb info
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct InternalDirectfbWmInfo
    {
        /// <summary>
        ///     Refers to an IDirectFB*
        /// </summary>
        public IntPtr Dfb { get; set; }

        /// <summary>
        ///     Refers to an IDirectFBWindow*
        /// </summary>
        public IntPtr Window { get; set; }

        /// <summary>
        ///     Refers to an IDirectFBSurface*
        /// </summary>
        public IntPtr Surface { get; set; }
    }
}