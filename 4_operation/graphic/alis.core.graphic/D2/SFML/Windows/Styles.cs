using System;

namespace Alis.Core.Graphic.D2.SFML.Windows
{
    /// <summary>
    ///     Enumeration of window creation styles
    /// </summary>
    ////////////////////////////////////////////////////////////
    [Flags]
    public enum Styles
    {
        /// <summary>No border / title bar (this flag and all others are mutually exclusive)</summary>
        None = 0,

        /// <summary>Title bar + fixed border</summary>
        Titlebar = 1 << 0,

        /// <summary>Titlebar + resizable border + maximize button</summary>
        Resize = 1 << 1,

        /// <summary>Titlebar + close button</summary>
        Close = 1 << 2,

        /// <summary>Fullscreen mode (this flag and all others are mutually exclusive))</summary>
        Fullscreen = 1 << 3,

        /// <summary>Default window style (titlebar + resize + close)</summary>
        Default = Titlebar | Resize | Close
    }
}