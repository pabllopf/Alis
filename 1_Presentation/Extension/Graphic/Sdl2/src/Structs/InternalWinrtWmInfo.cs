

using System;
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The internal winrt wm info
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct InternalWinrtWmInfo
    {
        /// <summary>
        ///     Refers to an inspect
        /// </summary>
        public IntPtr Window { get; set; }
    }
}