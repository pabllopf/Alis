// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StbTexteditState.cs
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
    ///     The stb text
    /// </summary>
    public struct StbTexteditState
    {
        /// <summary>
        ///     The cursor
        /// </summary>
        public int Cursor { get; set; }

        /// <summary>
        ///     The select start
        /// </summary>
        public int SelectStart { get; set; }

        /// <summary>
        ///     The select end
        /// </summary>
        public int SelectEnd { get; set; }

        /// <summary>
        ///     The insert mode
        /// </summary>
        public byte InsertMode { get; set; }

        /// <summary>
        ///     The row count per page
        /// </summary>
        public int RowCountPerPage { get; set; }

        /// <summary>
        ///     The cursor at end of line
        /// </summary>
        public byte CursorAtEndOfLine { get; set; }

        /// <summary>
        ///     The initialized
        /// </summary>
        public byte Initialized { get; set; }

        /// <summary>
        ///     The has preferred
        /// </summary>
        public byte HasPreferredX { get; set; }

        /// <summary>
        ///     The single line
        /// </summary>
        public byte SingleLine { get; set; }

        /// <summary>
        ///     The padding
        /// </summary>
        public byte Padding1 { get; set; }

        /// <summary>
        ///     The padding
        /// </summary>
        public byte Padding2 { get; set; }

        /// <summary>
        ///     The padding
        /// </summary>
        public byte Padding3 { get; set; }

        /// <summary>
        ///     The preferred
        /// </summary>
        public float PreferredX { get; set; }

        /// <summary>
        ///     The undo
        /// </summary>
        public StbUndoState UndoState { get; set; }
    }
}