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

namespace Alis.Extension.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The hat enum
    /// </summary>
    public enum Hat : byte
    {
    /// <summary>
    ///     Joystick hat is in the center (neutral position)
    /// </summary>
    HatCentered = 0x00,

    /// <summary>
    ///     Joystick hat is pushed up
    /// </summary>
    HatUp = 0x01,

    /// <summary>
    ///     Joystick hat is pushed right
    /// </summary>
    HatRight = 0x02,

    /// <summary>
    ///     Joystick hat is pushed down
    /// </summary>
    HatDown = 0x04,

    /// <summary>
    ///     Joystick hat is pushed left
    /// </summary>
    HatLeft = 0x08,

    /// <summary>
    ///     Joystick hat is pushed up and to the right
    /// </summary>
    HatRightUp = HatRight | HatUp,

    /// <summary>
    ///     Joystick hat is pushed down and to the right
    /// </summary>
    HatRightDown = HatRight | HatDown,

    /// <summary>
    ///     Joystick hat is pushed up and to the left
    /// </summary>
    HatLeftUp = HatLeft | HatUp,

    /// <summary>
    ///     Joystick hat is pushed down and to the left
    /// </summary>
    HatLeftDown = HatLeft | HatDown
    }
}