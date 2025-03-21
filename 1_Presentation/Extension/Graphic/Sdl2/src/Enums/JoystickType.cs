// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JoystickType.cs
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
    ///     The sdl joystick type enum
    /// </summary>
    public enum JoystickType
    {
        /// <summary>
        ///     The sdl joystick type unknown sdl joystick type
        /// </summary>
        SdlJoystickTypeUnknown,

        /// <summary>
        ///     The sdl joystick type game controller sdl joystick type
        /// </summary>
        SdlJoystickTypeGameController,

        /// <summary>
        ///     The sdl joystick type wheel sdl joystick type
        /// </summary>
        SdlJoystickTypeWheel,

        /// <summary>
        ///     The sdl joystick type arcade stick sdl joystick type
        /// </summary>
        SdlJoystickTypeArcadeStick,

        /// <summary>
        ///     The sdl joystick type flight stick sdl joystick type
        /// </summary>
        SdlJoystickTypeFlightStick,

        /// <summary>
        ///     The sdl joystick type dance pad sdl joystick type
        /// </summary>
        SdlJoystickTypeDancePad,

        /// <summary>
        ///     The sdl joystick type guitar sdl joystick type
        /// </summary>
        SdlJoystickTypeGuitar,

        /// <summary>
        ///     The sdl joystick type drum kit sdl joystick type
        /// </summary>
        SdlJoystickTypeDrumKit,

        /// <summary>
        ///     The sdl joystick type arcade pad sdl joystick type
        /// </summary>
        SdlJoystickTypeArcadePad
    }
}