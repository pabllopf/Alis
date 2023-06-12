using System;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl glcontext enum
    /// </summary>
    [Flags]
    public enum SdlGLcontext
    {
        /// <summary>
        ///     The sdl gl context debug flag sdl glcontext
        /// </summary>
        SdlGlContextDebugFlag = 0x0001,

        /// <summary>
        ///     The sdl gl context forward compatible flag sdl glcontext
        /// </summary>
        SdlGlContextForwardCompatibleFlag = 0x0002,

        /// <summary>
        ///     The sdl gl context robust access flag sdl glcontext
        /// </summary>
        SdlGlContextRobustAccessFlag = 0x0004,

        /// <summary>
        ///     The sdl gl context reset isolation flag sdl glcontext
        /// </summary>
        SdlGlContextResetIsolationFlag = 0x0008
    }
}