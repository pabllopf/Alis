

using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Sdl2.Enums;
using Alis.Extension.Graphic.Sdl2.Mapping;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl key sym
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct KeySym
    {
        /// <summary>
        ///     The scancode
        /// </summary>
        public SdlScancode scancode;

        /// <summary>
        ///     The sym
        /// </summary>
        public KeyCodes sym;

        /// <summary>
        ///     The mod
        /// </summary>
        public KeyMods mod;

        /// <summary>
        ///     The unicode
        /// </summary>
        public uint unicode;
    }
}