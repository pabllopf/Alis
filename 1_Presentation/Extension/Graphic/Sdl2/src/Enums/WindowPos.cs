

using System;

namespace Alis.Extension.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The window pos enum
    /// </summary>
    [Flags]
    public enum WindowPos
    {
        /// <summary>
        ///     The sdl window pos undefined mask
        /// </summary>
        WindowPosUndefinedMask = 0x1FFF0000,

        /// <summary>
        ///     The sdl window pos centered mask
        /// </summary>
        WindowPosCenteredMask = 0x2FFF0000,

        /// <summary>
        ///     The sdl window pos undefined
        /// </summary>
        WindowPosUndefined = 0x1FFF0000,

        /// <summary>
        ///     The sdl window pos centered
        /// </summary>
        WindowPosCentered = 0x2FFF0000
    }
}