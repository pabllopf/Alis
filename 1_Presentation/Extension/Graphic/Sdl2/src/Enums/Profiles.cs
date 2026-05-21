

using System;

namespace Alis.Extension.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The sdl gl profile enum
    /// </summary>
    [Flags]
    public enum Profiles
    {
        /// <summary>
        ///     The sdl gl context profile core sdl gl profile
        /// </summary>
        SdlGlContextProfileCore = 0x0001,

        /// <summary>
        ///     The sdl gl context profile compatibility sdl gl profile
        /// </summary>
        SdlGlContextProfileCompatibility = 0x0002,

        /// <summary>
        ///     The sdl gl context profile es sdl gl profile
        /// </summary>
        SdlGlContextProfileEs = 0x0004
    }
}