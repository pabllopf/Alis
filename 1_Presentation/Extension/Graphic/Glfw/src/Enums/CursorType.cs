// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CursorType.cs
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

namespace Alis.Extension.Graphic.Glfw.Enums
{
    /// <summary>
    ///     Strongly-typed values describing possible cursor shapes.
    /// </summary>
    public enum CursorType
    {
        /// <summary>
        ///     The regular arrow cursor.
        /// </summary>
        Arrow = 0x00036001,

        /// <summary>
        ///     The text input I-beam cursor shape.
        /// </summary>
        Beam = 0x00036002,

        /// <summary>
        ///     The crosshair shape.
        /// </summary>
        Crosshair = 0x00036003,

        /// <summary>
        ///     The hand shape.
        /// </summary>
        Hand = 0x00036004,

        /// <summary>
        ///     The horizontal resize arrow shape.
        /// </summary>
        ResizeHorizontal = 0x00036005,

        /// <summary>
        ///     The vertical resize arrow shape.
        /// </summary>
        ResizeVertical = 0x00036006
    }
}