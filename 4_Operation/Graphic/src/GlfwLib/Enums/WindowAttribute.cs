// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WindowAttribute.cs
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

namespace Alis.Core.Graphic.GlfwLib.Enums
{
    /// <summary>
    ///     Strongly-typed values used for getting/setting window hints.
    /// </summary>
    public enum WindowAttribute
    {
        /// <summary>
        ///     Indicates whether the windowed mode window will be given input focus when created.
        ///     <para>This hint is ignored for full screen and initially hidden windows.</para>
        /// </summary>
        Focused = 0x00020001,

        /// <summary>
        ///     Indicates whether the full screen window will automatically iconify and restore the previous video mode on input
        ///     focus loss.
        ///     <para>This hint is ignored for windowed mode windows.</para>
        /// </summary>
        AutoIconify = 0x00020002,

        /// <summary>
        ///     Indicates whether the windowed mode window will be maximized when created.
        ///     <para>This hint is ignored for full screen windows.</para>
        /// </summary>
        Maximized = 0x00020008,

        /// <summary>
        ///     Indicates whether the windowed mode window will be initially visible.
        ///     <para>This hint is ignored for full screen windows.</para>
        /// </summary>
        Visible = 0x00020004,

        /// <summary>
        ///     Indicates whether the windowed mode window will be resizable by the <i>user</i>.
        ///     <para>The window will still be resizable using the <see cref="Glfw.SetWindowSize" /> function.</para>
        ///     <para>This hint is ignored for full screen windows.</para>
        /// </summary>
        Resizable = 0x00020003,

        /// <summary>
        ///     Indicates whether the windowed mode window will have window decorations such as a border, a close widget, etc.
        ///     <para>An undecorated window may still allow the user to generate close events on some platforms.</para>
        ///     <para>This hint is ignored for full screen windows.</para>
        /// </summary>
        Decorated = 0x00020005,

        /// <summary>
        ///     Indicates whether the windowed mode window will be floating above other regular windows, also called topmost or
        ///     always-on-top.
        ///     <para>This is intended primarily for debugging purposes and cannot be used to implement proper full screen windows.</para>
        ///     <para>This hint is ignored for full screen windows.</para>
        /// </summary>
        Floating = 0x00020007,

        /// <summary>
        ///     Indicates whether the cursor is currently directly over the content area of the window, with no other
        ///     windows between.
        /// </summary>
        MouseHover = 0x0002000B
    }
}