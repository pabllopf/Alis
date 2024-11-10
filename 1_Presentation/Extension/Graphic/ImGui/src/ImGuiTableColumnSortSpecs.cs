// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTableColumnSortSpecs.cs
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
    ///     The im gui table column sort specs
    /// </summary>
    public struct ImGuiTableColumnSortSpecs
    {
        /// <summary>
        ///     The column user id
        /// </summary>
        public uint ColumnUserId { get; set; }
        
        /// <summary>
        ///     The column index
        /// </summary>
        public short ColumnIndex { get; set; }
        
        /// <summary>
        ///     The sort order
        /// </summary>
        public short SortOrder { get; set; }
        
        /// <summary>
        ///     The sort direction
        /// </summary>
        public ImGuiSortDirection SortDirection { get; set; }
    }
}