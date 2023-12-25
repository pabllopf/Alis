// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: PackedLayout.cs
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
    ///     The sdl packed layout enum
    /// </summary>
    public enum PackedLayout
    {
        /// <summary>
        ///     The sdl packed layout none sdl packed layout
        /// </summary>
        PackedLayoutNone,

        /// <summary>
        ///     The sdl packed layout 332 sdl packed layout
        /// </summary>
        PackedLayout332,

        /// <summary>
        ///     The sdl packed layout 4444 sdl packed layout
        /// </summary>
        PackedLayout4444,

        /// <summary>
        ///     The sdl packed layout 1555 sdl packed layout
        /// </summary>
        PackedLayout1555,

        /// <summary>
        ///     The sdl packed layout 5551 sdl packed layout
        /// </summary>
        PackedLayout5551,

        /// <summary>
        ///     The sdl packed layout 565 sdl packed layout
        /// </summary>
        PackedLayout565,

        /// <summary>
        ///     The sdl packed layout 8888 sdl packed layout
        /// </summary>
        PackedLayout8888,

        /// <summary>
        ///     The sdl packed layout 2101010 sdl packed layout
        /// </summary>
        PackedLayout2101010,

        /// <summary>
        ///     The sdl packed layout 1010102 sdl packed layout
        /// </summary>
        PackedLayout1010102
    }
}