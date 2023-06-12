using System;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl glprofile enum
    /// </summary>
    [Flags]
    public enum SdlGLprofile
    {
        /// <summary>
        ///     The sdl gl context profile core sdl glprofile
        /// </summary>
        SdlGlContextProfileCore = 0x0001,

        /// <summary>
        ///     The sdl gl context profile compatibility sdl glprofile
        /// </summary>
        SdlGlContextProfileCompatibility = 0x0002,

        /// <summary>
        ///     The sdl gl context profile es sdl glprofile
        /// </summary>
        SdlGlContextProfileEs = 0x0004
    }
}