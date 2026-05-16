// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JoystickPowerLevel.cs
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
    ///     The sdl joystick power level enum
    /// </summary>
    public enum JoystickPowerLevel
    {
    /// <summary>
    ///     Joystick power level could not be determined
    /// </summary>
    SdlJoystickPowerUnknown = -1,

    /// <summary>
    ///     Joystick battery is empty or critically low
    /// </summary>
    SdlJoystickPowerEmpty,

    /// <summary>
    ///     Joystick battery level is low
    /// </summary>
    SdlJoystickPowerLow,

    /// <summary>
    ///     Joystick battery level is medium
    /// </summary>
    SdlJoystickPowerMedium,

    /// <summary>
    ///     Joystick battery level is full
    /// </summary>
    SdlJoystickPowerFull,

    /// <summary>
    ///     Joystick is powered via a wired connection (no battery used)
    /// </summary>
    SdlJoystickPowerWired,

    /// <summary>
    ///     Maximum joystick power level value (sentinel)
    /// </summary>
    SdlJoystickPowerMax
    }
}