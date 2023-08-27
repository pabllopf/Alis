// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BitmapOrder.cs
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

namespace Alis.Core.Graphic.SDL.Enums
{
    /// <summary>
    ///     The sdl bit map order enum
    /// </summary>
    public enum BitmapOrder
    {
        /// <summary>
        ///     The sdl bit map order none sdl bit map order
        /// </summary>
        BitMapOrderNone,

        /// <summary>
        ///     The sdl bit map order 4321 sdl bit map order
        /// </summary>
        BitMapOrder4321,

        /// <summary>
        ///     The sdl bit map order 1234 sdl bit map order
        /// </summary>
        BitMapOrder1234
    }
}