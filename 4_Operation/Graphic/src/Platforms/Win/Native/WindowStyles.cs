// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WindowStyles.cs
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