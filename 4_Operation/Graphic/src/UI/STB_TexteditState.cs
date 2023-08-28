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

namespace Alis.Core.Graphic.UI
{
    /// <summary>
    ///     The stb texteditstate
    /// </summary>
    public struct StbTexteditState
    {
        /// <summary>
        ///     The cursor
        /// </summary>
        public int Cursor;

        /// <summary>
        ///     The select start
        /// </summary>
        public int SelectStart;

        /// <summary>
        ///     The select end
        /// </summary>
        public int SelectEnd;

        /// <summary>
        ///     The insert mode
        /// </summary>
        public byte InsertMode;

        /// <summary>
        ///     The row count per page
        /// </summary>
        public int RowCountPerPage;

        /// <summary>
        ///     The cursor at end of line
        /// </summary>
        public byte CursorAtEndOfLine;

        /// <summary>
        ///     The initialized
        /// </summary>
        public byte Initialized;

        /// <summary>
        ///     The has preferred
        /// </summary>
        public byte HasPreferredX;

        /// <summary>
        ///     The single line
        /// </summary>
        public byte SingleLine;

        /// <summary>
        ///     The padding
        /// </summary>
        public byte Padding1;

        /// <summary>
        ///     The padding
        /// </summary>
        public byte Padding2;

        /// <summary>
        ///     The padding
        /// </summary>
        public byte Padding3;

        /// <summary>
        ///     The preferred
        /// </summary>
        public float PreferredX;

        /// <summary>
        ///     The undostate
        /// </summary>
        public StbUndoState Undostate;
    }
}