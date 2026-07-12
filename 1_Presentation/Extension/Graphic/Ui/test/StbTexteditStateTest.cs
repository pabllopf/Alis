// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StbTexteditStateTest.cs
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

using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The stb textedit state test class
    /// </summary>
    public class StbTexteditStateTest
    {
        /// <summary>
        ///     Tests that cursor should be initialized correctly
        /// </summary>
        [Fact]
        public void Cursor_ShouldBeInitializedCorrectly()
        {
            StbTexteditState texteditState = new StbTexteditState {Cursor = 5};

            int cursor = texteditState.Cursor;

            Assert.Equal(5, cursor);
        }

        /// <summary>
        ///     Tests that select start should be initialized correctly
        /// </summary>
        [Fact]
        public void SelectStart_ShouldBeInitializedCorrectly()
        {
            StbTexteditState texteditState = new StbTexteditState {SelectStart = 10};

            int selectStart = texteditState.SelectStart;

            Assert.Equal(10, selectStart);
        }

        /// <summary>
        ///     Tests that select end should be initialized correctly
        /// </summary>
        [Fact]
        public void SelectEnd_ShouldBeInitializedCorrectly()
        {
            StbTexteditState texteditState = new StbTexteditState {SelectEnd = 15};

            int selectEnd = texteditState.SelectEnd;

            Assert.Equal(15, selectEnd);
        }

        /// <summary>
        ///     Tests that insert mode should be initialized correctly
        /// </summary>
        [Fact]
        public void InsertMode_ShouldBeInitializedCorrectly()
        {
            StbTexteditState texteditState = new StbTexteditState {InsertMode = 1};

            byte insertMode = texteditState.InsertMode;

            Assert.Equal(1, insertMode);
        }

        /// <summary>
        ///     Tests that row count per page should be initialized correctly
        /// </summary>
        [Fact]
        public void RowCountPerPage_ShouldBeInitializedCorrectly()
        {
            StbTexteditState texteditState = new StbTexteditState {RowCountPerPage = 20};

            int rowCountPerPage = texteditState.RowCountPerPage;

            Assert.Equal(20, rowCountPerPage);
        }

        /// <summary>
        ///     Tests that cursor at end of line should be initialized correctly
        /// </summary>
        [Fact]
        public void CursorAtEndOfLine_ShouldBeInitializedCorrectly()
        {
            StbTexteditState texteditState = new StbTexteditState {CursorAtEndOfLine = 1};

            byte cursorAtEndOfLine = texteditState.CursorAtEndOfLine;

            Assert.Equal(1, cursorAtEndOfLine);
        }

        /// <summary>
        ///     Tests that initialized should be initialized correctly
        /// </summary>
        [Fact]
        public void Initialized_ShouldBeInitializedCorrectly()
        {
            StbTexteditState texteditState = new StbTexteditState {Initialized = 1};

            byte initialized = texteditState.Initialized;

            Assert.Equal(1, initialized);
        }

        /// <summary>
        ///     Tests that has preferred x should be initialized correctly
        /// </summary>
        [Fact]
        public void HasPreferredX_ShouldBeInitializedCorrectly()
        {
            StbTexteditState texteditState = new StbTexteditState {HasPreferredX = 1};

            byte hasPreferredX = texteditState.HasPreferredX;

            Assert.Equal(1, hasPreferredX);
        }

        /// <summary>
        ///     Tests that single line should be initialized correctly
        /// </summary>
        [Fact]
        public void SingleLine_ShouldBeInitializedCorrectly()
        {
            StbTexteditState texteditState = new StbTexteditState {SingleLine = 1};

            byte singleLine = texteditState.SingleLine;

            Assert.Equal(1, singleLine);
        }

        /// <summary>
        ///     Tests that padding 1 should be initialized correctly
        /// </summary>
        [Fact]
        public void Padding1_ShouldBeInitializedCorrectly()
        {
            StbTexteditState texteditState = new StbTexteditState {Padding1 = 1};

            byte padding1 = texteditState.Padding1;

            Assert.Equal(1, padding1);
        }

        /// <summary>
        ///     Tests that padding 2 should be initialized correctly
        /// </summary>
        [Fact]
        public void Padding2_ShouldBeInitializedCorrectly()
        {
            StbTexteditState texteditState = new StbTexteditState {Padding2 = 1};

            byte padding2 = texteditState.Padding2;

            Assert.Equal(1, padding2);
        }

        /// <summary>
        ///     Tests that padding 3 should be initialized correctly
        /// </summary>
        [Fact]
        public void Padding3_ShouldBeInitializedCorrectly()
        {
            StbTexteditState texteditState = new StbTexteditState {Padding3 = 1};

            byte padding3 = texteditState.Padding3;

            Assert.Equal(1, padding3);
        }

        /// <summary>
        ///     Tests that preferred x should be initialized correctly
        /// </summary>
        [Fact]
        public void PreferredX_ShouldBeInitializedCorrectly()
        {
            StbTexteditState texteditState = new StbTexteditState {PreferredX = 1.0f};

            float preferredX = texteditState.PreferredX;

            Assert.Equal(1.0f, preferredX);
        }

        /// <summary>
        ///     Tests that undo state should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoState_ShouldBeInitializedCorrectly()
        {
            StbUndoState undoState = new StbUndoState();
            StbTexteditState texteditState = new StbTexteditState {UndoState = undoState};

            StbUndoState result = texteditState.UndoState;

            Assert.Equal(undoState, result);
        }
    }
}