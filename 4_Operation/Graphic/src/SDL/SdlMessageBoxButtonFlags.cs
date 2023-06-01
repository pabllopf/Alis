using System;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl messageboxbuttonflags enum
    /// </summary>
    [Flags]
    public enum SdlMessageBoxButtonFlags : uint
    {
        /// <summary>
        ///     The sdl messagebox button returnkey default sdl messageboxbuttonflags
        /// </summary>
        SdlMessageboxButtonReturnkeyDefault = 0x00000001,

        /// <summary>
        ///     The sdl messagebox button escapekey default sdl messageboxbuttonflags
        /// </summary>
        SdlMessageboxButtonEscapekeyDefault = 0x00000002
    }
}