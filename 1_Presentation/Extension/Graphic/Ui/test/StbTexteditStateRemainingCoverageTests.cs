// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StbTexteditStateRemainingCoverageTests.cs
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

using Alis.Extension.Graphic.Ui;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The stb textedit state remaining coverage tests class
    /// </summary>
    public class StbTexteditStateRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that properties round trip
        /// </summary>
        [Fact]
        public void Properties_RoundTrip()
        {
            StbTexteditState state = new StbTexteditState
            {
                Cursor = 3,
                SelectStart = 1,
                SelectEnd = 5,
                InsertMode = 1,
                RowCountPerPage = 10,
                CursorAtEndOfLine = 1,
                Initialized = 1,
                HasPreferredX = 1,
                SingleLine = 1,
                Padding1 = 1,
                Padding2 = 1,
                Padding3 = 1,
                PreferredX = 0.5f,
                UndoState = new StbUndoState()
            };

            Assert.Equal(3, state.Cursor);
            Assert.Equal(1, state.SelectStart);
            Assert.Equal(5, state.SelectEnd);
            Assert.Equal(1, state.InsertMode);
            Assert.Equal(10, state.RowCountPerPage);
            Assert.Equal(1, state.CursorAtEndOfLine);
            Assert.Equal(1, state.Initialized);
            Assert.Equal(1, state.HasPreferredX);
            Assert.Equal(1, state.SingleLine);
            Assert.Equal(1, state.Padding1);
            Assert.Equal(1, state.Padding2);
            Assert.Equal(1, state.Padding3);
            Assert.Equal(0.5f, state.PreferredX, 5);
            Assert.NotNull(state.UndoState);
        }

        /// <summary>
        ///     Tests that defaults are zero
        /// </summary>
        [Fact]
        public void Defaults_AreZero()
        {
            StbTexteditState state = new StbTexteditState();

            Assert.Equal(0, state.Cursor);
            Assert.Equal(0, state.SelectStart);
            Assert.Equal(0, state.SelectEnd);
            Assert.Equal(0, state.InsertMode);
            Assert.Equal(0, state.RowCountPerPage);
            Assert.Equal(0, state.CursorAtEndOfLine);
            Assert.Equal(0, state.Initialized);
            Assert.Equal(0, state.HasPreferredX);
            Assert.Equal(0, state.SingleLine);
            Assert.Equal(0, state.Padding1);
            Assert.Equal(0, state.Padding2);
            Assert.Equal(0, state.Padding3);
            Assert.Equal(0f, state.PreferredX, 5);
            Assert.NotNull(state.UndoState);
        }
    }
}
