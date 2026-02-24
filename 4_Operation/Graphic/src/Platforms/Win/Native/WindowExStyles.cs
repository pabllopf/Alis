// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WindowExStyles.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------



#if winx64 || winx86 || winarm64 || winarm || win

using System;

namespace Alis.Core.Graphic.Platforms.Win.Native
{
    /// <summary>
    ///     Extended window styles.
    /// </summary>
    [Flags]
    public enum WindowExStyles : uint
    {
        /// <summary>
        /// </summary>
        None = 0,

        /// <summary>
        ///     The window has a double border; the window can, optionally, be used as a modal dialog box.
        /// </summary>
        DlgModalFrame = 0x00000001,

        /// <summary>
        ///     The child window created with this style does not send the WM_PARENTNOTIFY message to its parent window when it is
        ///     created or destroyed.
        /// </summary>
        NoParentNotify = 0x00000004,

        /// <summary>
        ///     The window should be placed above all non-topmost windows and stay above them, even when the window is deactivated.
        /// </summary>
        Topmost = 0x00000008,

        /// <summary>
        ///     The window accepts drag-and-drop files.
        /// </summary>
        AcceptFiles = 0x00000010,

        /// <summary>
        ///     The window should not be painted until siblings beneath the window have been painted.
        /// </summary>
        Transparent = 0x00000020,

        /// <summary>
        ///     The window is a MDI child window.
        /// </summary>
        MdiChild = 0x00000040,

        /// <summary>
        ///     The window is intended to be used as a floating toolbar.
        /// </summary>
        ToolWindow = 0x00000080,

        /// <summary>
        ///     The window has a border with a raised edge.
        /// </summary>
        WindowEdge = 0x00000100,

        /// <summary>
        ///     The window has a border with a sunken edge.
        /// </summary>
        ClientEdge = 0x00000200,

        /// <summary>
        ///     The window includes a question mark in the title bar.
        /// </summary>
        ContextHelp = 0x00000400,

        /// <summary>
        ///     The window is on the right side of the screen.
        /// </summary>
        Right = 0x00001000,

        /// <summary>
        ///     The window is on the left side of the screen.
        /// </summary>
        Left = 0x00000000,

        /// <summary>
        ///     If the shell language is Hebrew, Arabic, or another language that supports reading order alignment, the window text
        ///     is displayed using right-to-left reading order.
        /// </summary>
        RtlReading = 0x00002000,

        /// <summary>
        ///     The window text is displayed using left-to-right reading order.
        /// </summary>
        LtrReading = 0x00000000,

        /// <summary>
        ///     If the shell language is Hebrew, Arabic, or another language that supports reading order alignment, the vertical
        ///     scroll bar (if present) is to the left of the client area.
        /// </summary>
        LeftScrollbar = 0x00004000,

        /// <summary>
        ///     The vertical scroll bar (if present) is to the right of the client area.
        /// </summary>
        RightScrollbar = 0x00000000,

        /// <summary>
        ///     The window is a control parent.
        /// </summary>
        ControlParent = 0x00010000,

        /// <summary>
        ///     The window has a three-dimensional border style intended to be used for items that do not accept user input.
        /// </summary>
        StaticEdge = 0x00020000,

        /// <summary>
        ///     The window is an application window.
        /// </summary>
        AppWindow = 0x00040000,

        /// <summary>
        ///     The window is layered.
        /// </summary>
        Layered = 0x00080000,

        /// <summary>
        ///     The window does not inherit the layout of its parent.
        /// </summary>
        NoInheritLayout = 0x00100000,

        /// <summary>
        ///     The window does not render to a redirection surface.
        /// </summary>
        NoRedirectionBitmap = 0x00200000,

        /// <summary>
        ///     The window has layout RTL.
        /// </summary>
        LayoutRtl = 0x00400000,

        /// <summary>
        ///     The window is composited.
        /// </summary>
        Composited = 0x02000000,

        /// <summary>
        ///     The window does not become the foreground window when the user clicks it.
        /// </summary>
        NoActivate = 0x08000000,

        /// <summary>
        ///     The window is a layer upon which other windows can be placed.
        /// </summary>
        Overlapped = 0x10000000,

        /// <summary>
        ///     The window is a top-level window.
        /// </summary>
        TopLevel = 0x20000000,

        /// <summary>
        ///     The window is a tool window.
        /// </summary>
        ToolWindowEx = 0x40000000,

        /// <summary>
        ///     The window is a dialog window.
        /// </summary>
        DialogWindow = 0x80000000
    }
}

#endif