// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:STB_TexteditState.cs
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
    ///     The stb texteditstate
    /// </summary>
    public struct STB_TexteditState
    {
        /// <summary>
        ///     The cursor
        /// </summary>
        public int cursor;

        /// <summary>
        ///     The select start
        /// </summary>
        public int select_start;

        /// <summary>
        ///     The select end
        /// </summary>
        public int select_end;

        /// <summary>
        ///     The insert mode
        /// </summary>
        public byte insert_mode;

        /// <summary>
        ///     The row count per page
        /// </summary>
        public int row_count_per_page;

        /// <summary>
        ///     The cursor at end of line
        /// </summary>
        public byte cursor_at_end_of_line;

        /// <summary>
        ///     The initialized
        /// </summary>
        public byte initialized;

        /// <summary>
        ///     The has preferred
        /// </summary>
        public byte has_preferred_x;

        /// <summary>
        ///     The single line
        /// </summary>
        public byte single_line;

        /// <summary>
        ///     The padding
        /// </summary>
        public byte padding1;

        /// <summary>
        ///     The padding
        /// </summary>
        public byte padding2;

        /// <summary>
        ///     The padding
        /// </summary>
        public byte padding3;

        /// <summary>
        ///     The preferred
        /// </summary>
        public float preferred_x;

        /// <summary>
        ///     The undostate
        /// </summary>
        public StbUndoState undostate;
    }
}