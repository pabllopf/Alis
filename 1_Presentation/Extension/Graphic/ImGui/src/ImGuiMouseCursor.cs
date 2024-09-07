// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiMouseCursor.cs
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

namespace Alis.Extension.Graphic.ImGui
{
    /// <summary>
    ///     The im gui mouse cursor enum
    /// </summary>
    public enum ImGuiMouseCursor
    {
        /// <summary>
        ///     The none im gui mouse cursor
        /// </summary>
        None = -1,

        /// <summary>
        ///     The arrow im gui mouse cursor
        /// </summary>
        Arrow = 0,

        /// <summary>
        ///     The text input im gui mouse cursor
        /// </summary>
        TextInput = 1,

        /// <summary>
        ///     The resize all im gui mouse cursor
        /// </summary>
        ResizeAll = 2,

        /// <summary>
        ///     The resize ns im gui mouse cursor
        /// </summary>
        ResizeNs = 3,

        /// <summary>
        ///     The resize ew im gui mouse cursor
        /// </summary>
        ResizeEw = 4,

        /// <summary>
        ///     The resize nesw im gui mouse cursor
        /// </summary>
        ResizeNesw = 5,

        /// <summary>
        ///     The resize nwse im gui mouse cursor
        /// </summary>
        ResizeNwse = 6,

        /// <summary>
        ///     The hand im gui mouse cursor
        /// </summary>
        Hand = 7,

        /// <summary>
        ///     The not allowed im gui mouse cursor
        /// </summary>
        NotAllowed = 8,

        /// <summary>
        ///     The count im gui mouse cursor
        /// </summary>
        Count = 9
    }
}