

#if winx64 || winx86 || winarm64 || winarm || win
using System;
using System.Diagnostics.CodeAnalysis;

namespace Alis.Core.Graphic.Platforms.Win.Native
{
    /// <summary>
    ///     Window messages.
    /// </summary>
    [Flags]
    public enum WindowMessage : uint
    {
        /// <summary>
        /// </summary>
        Close = 0x0010,

        /// <summary>
        /// </summary>
        OnDestroy = 0x0002,

        /// <summary>
        /// </summary>
        KeyDown = 0x0100,

        /// <summary>
        /// </summary>
        Size = 0x0005,

        /// <summary>
        ///     The key up window message
        /// </summary>
        KeyUp = 0x0101
    }
}

#endif