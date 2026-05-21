

using System;

namespace Alis.Extension.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The sdl gl context enum
    /// </summary>
    [Flags]
    public enum Sdl2Contexts
    {
        /// <summary>
        ///     The sdl gl context debug flag sdl gl context
        /// </summary>
        SdlGlContextDebugFlag = 0x0001,

        /// <summary>
        ///     The sdl gl context forward compatible flag sdl gl context
        /// </summary>
        SdlGlContextForwardCompatibleFlag = 0x0002,

        /// <summary>
        ///     The sdl gl context robust access flag sdl gl context
        /// </summary>
        SdlGlContextRobustAccessFlag = 0x0004,

        /// <summary>
        ///     The sdl gl context reset isolation flag sdl gl context
        /// </summary>
        SdlGlContextResetIsolationFlag = 0x0008
    }
}