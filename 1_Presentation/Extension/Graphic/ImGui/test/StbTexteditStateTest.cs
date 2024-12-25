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

using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test
{
    /// <summary>
    ///     The stb textedit state test class
    /// </summary>
    	 [ExcludeFromCodeCoverage] 
	 public class StbTexteditStateTest 
    {
        /// <summary>
        ///     Tests that cursor should be initialized correctly
        /// </summary>
        [Fact]
        public void Cursor_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbTexteditState texteditState = new StbTexteditState {Cursor = 5};

            // Act
            int cursor = texteditState.Cursor;

            // Assert
            Assert.Equal(5, cursor);
        }

        /// <summary>
        ///     Tests that select start should be initialized correctly
        /// </summary>
        [Fact]
        public void SelectStart_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbTexteditState texteditState = new StbTexteditState {SelectStart = 10};

            // Act
            int selectStart = texteditState.SelectStart;

            // Assert
            Assert.Equal(10, selectStart);
        }

        /// <summary>
        ///     Tests that select end should be initialized correctly
        /// </summary>
        [Fact]
        public void SelectEnd_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbTexteditState texteditState = new StbTexteditState {SelectEnd = 15};

            // Act
            int selectEnd = texteditState.SelectEnd;

            // Assert
            Assert.Equal(15, selectEnd);
        }

        /// <summary>
        ///     Tests that insert mode should be initialized correctly
        /// </summary>
        [Fact]
        public void InsertMode_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbTexteditState texteditState = new StbTexteditState {InsertMode = 1};

            // Act
            byte insertMode = texteditState.InsertMode;

            // Assert
            Assert.Equal(1, insertMode);
        }

        /// <summary>
        ///     Tests that row count per page should be initialized correctly
        /// </summary>
        [Fact]
        public void RowCountPerPage_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbTexteditState texteditState = new StbTexteditState {RowCountPerPage = 20};

            // Act
            int rowCountPerPage = texteditState.RowCountPerPage;

            // Assert
            Assert.Equal(20, rowCountPerPage);
        }

        /// <summary>
        ///     Tests that cursor at end of line should be initialized correctly
        /// </summary>
        [Fact]
        public void CursorAtEndOfLine_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbTexteditState texteditState = new StbTexteditState {CursorAtEndOfLine = 1};

            // Act
            byte cursorAtEndOfLine = texteditState.CursorAtEndOfLine;

            // Assert
            Assert.Equal(1, cursorAtEndOfLine);
        }

        /// <summary>
        ///     Tests that initialized should be initialized correctly
        /// </summary>
        [Fact]
        public void Initialized_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbTexteditState texteditState = new StbTexteditState {Initialized = 1};

            // Act
            byte initialized = texteditState.Initialized;

            // Assert
            Assert.Equal(1, initialized);
        }

        /// <summary>
        ///     Tests that has preferred x should be initialized correctly
        /// </summary>
        [Fact]
        public void HasPreferredX_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbTexteditState texteditState = new StbTexteditState {HasPreferredX = 1};

            // Act
            byte hasPreferredX = texteditState.HasPreferredX;

            // Assert
            Assert.Equal(1, hasPreferredX);
        }

        /// <summary>
        ///     Tests that single line should be initialized correctly
        /// </summary>
        [Fact]
        public void SingleLine_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbTexteditState texteditState = new StbTexteditState {SingleLine = 1};

            // Act
            byte singleLine = texteditState.SingleLine;

            // Assert
            Assert.Equal(1, singleLine);
        }

        /// <summary>
        ///     Tests that padding 1 should be initialized correctly
        /// </summary>
        [Fact]
        public void Padding1_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbTexteditState texteditState = new StbTexteditState {Padding1 = 1};

            // Act
            byte padding1 = texteditState.Padding1;

            // Assert
            Assert.Equal(1, padding1);
        }

        /// <summary>
        ///     Tests that padding 2 should be initialized correctly
        /// </summary>
        [Fact]
        public void Padding2_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbTexteditState texteditState = new StbTexteditState {Padding2 = 1};

            // Act
            byte padding2 = texteditState.Padding2;

            // Assert
            Assert.Equal(1, padding2);
        }

        /// <summary>
        ///     Tests that padding 3 should be initialized correctly
        /// </summary>
        [Fact]
        public void Padding3_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbTexteditState texteditState = new StbTexteditState {Padding3 = 1};

            // Act
            byte padding3 = texteditState.Padding3;

            // Assert
            Assert.Equal(1, padding3);
        }

        /// <summary>
        ///     Tests that preferred x should be initialized correctly
        /// </summary>
        [Fact]
        public void PreferredX_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbTexteditState texteditState = new StbTexteditState {PreferredX = 1.0f};

            // Act
            float preferredX = texteditState.PreferredX;

            // Assert
            Assert.Equal(1.0f, preferredX);
        }

        /// <summary>
        ///     Tests that undo state should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoState_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState();
            StbTexteditState texteditState = new StbTexteditState {UndoState = undoState};

            // Act
            StbUndoState result = texteditState.UndoState;

            // Assert
            Assert.Equal(undoState, result);
        }
    }
}