// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiDir.cs
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

namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    ///     The im gui dir enum
    /// </summary>
    public enum ImGuiDir
    {
        /// <summary>
        ///     The none im gui dir
        /// </summary>
        None = -1,

        /// <summary>
        ///     The left im gui dir
        /// </summary>
        Left = 0,

        /// <summary>
        ///     The right im gui dir
        /// </summary>
        Right = 1,

        /// <summary>
        ///     The up im gui dir
        /// </summary>
        Up = 2,

        /// <summary>
        ///     The down im gui dir
        /// </summary>
        Down = 3,

        /// <summary>
        ///     The count im gui dir
        /// </summary>
        Count = 4
    }
}