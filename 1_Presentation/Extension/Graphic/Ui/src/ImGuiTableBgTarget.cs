// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTableBgTarget.cs
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


namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui table bg target enum
    /// </summary>
    public enum ImGuiTableBgTarget
    {
        /// <summary>
        ///     The none im gui table bg target
        /// </summary>
        None = 0,

        /// <summary>
        ///     The row bg im gui table bg target
        /// </summary>
        RowBg0 = 1,

        /// <summary>
        ///     The row bg im gui table bg target
        /// </summary>
        RowBg1 = 2,

        /// <summary>
        ///     The cell bg im gui table bg target
        /// </summary>
        CellBg = 3
    }
}