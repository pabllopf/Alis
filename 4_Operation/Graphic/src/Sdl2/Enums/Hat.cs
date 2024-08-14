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

namespace Alis.Core.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The hat enum
    /// </summary>
    public enum Hat : byte
    {
        /// <summary>
        ///     The sdl hat centered
        /// </summary>
        HatCentered = 0x00,
        
        /// <summary>
        ///     The sdl hat up
        /// </summary>
        HatUp = 0x01,
        
        /// <summary>
        ///     The sdl hat right
        /// </summary>
        HatRight = 0x02,
        
        /// <summary>
        ///     The sdl hat down
        /// </summary>
        HatDown = 0x04,
        
        /// <summary>
        ///     The sdl hat left
        /// </summary>
        HatLeft = 0x08,
        
        /// <summary>
        ///     The sdl hat up
        /// </summary>
        HatRightUp = HatRight | HatUp,
        
        /// <summary>
        ///     The sdl hat down
        /// </summary>
        HatRightDown = HatRight | HatDown,
        
        /// <summary>
        ///     The sdl hat up
        /// </summary>
        HatLeftUp = HatLeft | HatUp,
        
        /// <summary>
        ///     The sdl hat down
        /// </summary>
        HatLeftDown = HatLeft | HatDown
    }
}