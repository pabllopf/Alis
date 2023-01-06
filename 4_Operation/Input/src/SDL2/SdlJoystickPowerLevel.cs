// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Sdl.SdlJoystickPowerLevel.cs
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

namespace Alis.Core.Input.SDL2
{
    /// <summary>
        ///     The sdl joystickpowerlevel enum
        /// </summary>
        public enum SdlJoystickPowerLevel
        {
            /// <summary>
            ///     The sdl joystick power unknown sdl joystickpowerlevel
            /// </summary>
            SdlJoystickPowerUnknown = -1,

            /// <summary>
            ///     The sdl joystick power empty sdl joystickpowerlevel
            /// </summary>
            SdlJoystickPowerEmpty,

            /// <summary>
            ///     The sdl joystick power low sdl joystickpowerlevel
            /// </summary>
            SdlJoystickPowerLow,

            /// <summary>
            ///     The sdl joystick power medium sdl joystickpowerlevel
            /// </summary>
            SdlJoystickPowerMedium,

            /// <summary>
            ///     The sdl joystick power full sdl joystickpowerlevel
            /// </summary>
            SdlJoystickPowerFull,

            /// <summary>
            ///     The sdl joystick power wired sdl joystickpowerlevel
            /// </summary>
            SdlJoystickPowerWired,

            /// <summary>
            ///     The sdl joystick power max sdl joystickpowerlevel
            /// </summary>
            SdlJoystickPowerMax
        }
    
}