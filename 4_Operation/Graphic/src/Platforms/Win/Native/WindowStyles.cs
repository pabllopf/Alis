

#if winx64 || winx86 || winarm64 || winarm || win
using System;
using System.Diagnostics.CodeAnalysis;

namespace Alis.Core.Graphic.Platforms.Win.Native
{
    /// <summary>
    ///     Window styles for Win32 window creation.
    /// </summary>
    [Flags]
    public enum WindowStyles : uint
    {
        /// <summary>
        /// </summary>
        OverlappedWindow = 0x00CF0000,

        /// <summary>
        /// </summary>
        Visible = 0x10000000,

        /// <summary>
        ///     The popup window styles
        /// </summary>
        Popup = 0x80000000,

        /// <summary>
        ///     The child window styles
        /// </summary>
        Child = 0x40000000,

        /// <summary>
        ///     The border window styles
        /// </summary>
        Border = 0x00800000,

        /// <summary>
        ///     The app window window styles
        /// </summary>
        AppWindow = 0x00040000,

        /// <summary>
        ///     The topmost window styles
        /// </summary>
        Topmost = 0x00000008,

        /// <summary>
        ///     The tool window window styles
        /// </summary>
        ToolWindow = 0x00000080
    }
}

#endif