// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: BlendEquationMode.cs
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

namespace Alis.App.Engine.OpenGL.Enums
{
    /// <summary>
    ///     The blend equation mode enum
    /// </summary>
    public enum BlendEquationMode
    {
        /// <summary>
        ///     The func add blend equation mode
        /// </summary>
        FuncAdd = 0x8006,

        /// <summary>
        ///     The min blend equation mode
        /// </summary>
        Min = 0x8007,

        /// <summary>
        ///     The max blend equation mode
        /// </summary>
        Max = 0x8008,

        /// <summary>
        ///     The func subtract blend equation mode
        /// </summary>
        FuncSubtract = 0x800A,

        /// <summary>
        ///     The func reverse subtract blend equation mode
        /// </summary>
        FuncReverseSubtract = 0x800B
    }
}