// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameControllerAxis.cs
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

namespace Alis.Core.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The sdl game controller axis enum
    /// </summary>
    public enum GameControllerAxis
    {
        /// <summary>
        ///     The sdl controller axis invalid sdl game controller axis
        /// </summary>
        SdlControllerAxisInvalid = -1,
        
        /// <summary>
        ///     The sdl controller axis left x sdl game controller axis
        /// </summary>
        SdlControllerAxisLeftX,
        
        /// <summary>
        ///     The sdl controller axis lefty sdl game controller axis
        /// </summary>
        SdlControllerAxisLeftY,
        
        /// <summary>
        ///     The sdl controller axis right X sdl game controller axis
        /// </summary>
        SdlControllerAxisRightX,
        
        /// <summary>
        ///     The sdl controller axis right Y sdl game controller axis
        /// </summary>
        SdlControllerAxisRightY,
        
        /// <summary>
        ///     The sdl controller axis trigger left sdl game controller axis
        /// </summary>
        SdlControllerAxisTriggerLeft,
        
        /// <summary>
        ///     The sdl controller axis trigger right sdl game controller axis
        /// </summary>
        SdlControllerAxisTriggerRight,
        
        /// <summary>
        ///     The sdl controller axis max sdl game controller axis
        /// </summary>
        SdlControllerAxisMax
    }
}