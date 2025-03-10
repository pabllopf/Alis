// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ModifierKeys.cs
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

using System;

namespace Alis.Core.Graphic.GlfwLib.Enums
{
    /// <summary>
    ///     Describes bitwise combination of modifier keys.
    /// </summary>
    [Flags]
    public enum ModifierKeys
    {
        /// <summary>
        ///     Either of the Shift keys.
        /// </summary>
        Shift = 0x0001,

        /// <summary>
        ///     Either of the Ctrl keys.
        /// </summary>
        Control = 0x0002,

        /// <summary>
        ///     Either of the Alt keys
        /// </summary>
        Alt = 0x0004,

        /// <summary>
        ///     The super key ("Windows" key on Windows)
        /// </summary>
        Super = 0x0008,

        /// <summary>
        ///     The caps-lock is enabled.
        /// </summary>
        CapsLock = 0x0010,

        /// <summary>
        ///     The num-lock is enabled.
        /// </summary>
        NumLock = 0x0020
    }
}