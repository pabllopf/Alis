// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: SdlJoystickType.cs
// 
//  Author: Pablo Perdomo Falcón
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

namespace Alis.Core.Graphic.SDL.Enums
{
    /// <summary>
    ///     The sdl joysticktype enum
    /// </summary>
    public enum SdlJoystickType
    {
        /// <summary>
        ///     The sdl joystick type unknown sdl joysticktype
        /// </summary>
        SdlJoystickTypeUnknown,

        /// <summary>
        ///     The sdl joystick type gamecontroller sdl joysticktype
        /// </summary>
        SdlJoystickTypeGamecontroller,

        /// <summary>
        ///     The sdl joystick type wheel sdl joysticktype
        /// </summary>
        SdlJoystickTypeWheel,

        /// <summary>
        ///     The sdl joystick type arcade stick sdl joysticktype
        /// </summary>
        SdlJoystickTypeArcadeStick,

        /// <summary>
        ///     The sdl joystick type flight stick sdl joysticktype
        /// </summary>
        SdlJoystickTypeFlightStick,

        /// <summary>
        ///     The sdl joystick type dance pad sdl joysticktype
        /// </summary>
        SdlJoystickTypeDancePad,

        /// <summary>
        ///     The sdl joystick type guitar sdl joysticktype
        /// </summary>
        SdlJoystickTypeGuitar,

        /// <summary>
        ///     The sdl joystick type drum kit sdl joysticktype
        /// </summary>
        SdlJoystickTypeDrumKit,

        /// <summary>
        ///     The sdl joystick type arcade pad sdl joysticktype
        /// </summary>
        SdlJoystickTypeArcadePad
    }
}