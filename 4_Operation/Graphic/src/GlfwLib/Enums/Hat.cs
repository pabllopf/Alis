// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Hat.cs
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
    ///     Describes joystick hat states.
    /// </summary>
    [Flags]
    public enum Hat
    {
        /// <summary>
        ///     Centered
        /// </summary>
        Centered = 0x00,

        /// <summary>
        ///     Up
        /// </summary>
        Up = 0x01,

        /// <summary>
        ///     Right
        /// </summary>
        Right = 0x02,

        /// <summary>
        ///     Down
        /// </summary>
        Down = 0x04,

        /// <summary>
        ///     Left
        /// </summary>
        Left = 0x08,

        /// <summary>
        ///     Right and up
        /// </summary>
        RightUp = Right | Up,

        /// <summary>
        ///     Right and down
        /// </summary>
        RightDown = Right | Down,

        /// <summary>
        ///     Left and up
        /// </summary>
        LeftUp = Left | Up,

        /// <summary>
        ///     Left and down
        /// </summary>
        LeftDown = Left | Down
    }
}