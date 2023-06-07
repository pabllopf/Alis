// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlPowerState.cs
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

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl powerstate enum
    /// </summary>
    public enum SdlPowerState
    {
        /// <summary>
        ///     The sdl powerstate unknown sdl powerstate
        /// </summary>
        SdlPowerstateUnknown = 0,

        /// <summary>
        ///     The sdl powerstate on battery sdl powerstate
        /// </summary>
        SdlPowerstateOnBattery,

        /// <summary>
        ///     The sdl powerstate no battery sdl powerstate
        /// </summary>
        SdlPowerstateNoBattery,

        /// <summary>
        ///     The sdl powerstate charging sdl powerstate
        /// </summary>
        SdlPowerstateCharging,

        /// <summary>
        ///     The sdl powerstate charged sdl powerstate
        /// </summary>
        SdlPowerstateCharged
    }
}