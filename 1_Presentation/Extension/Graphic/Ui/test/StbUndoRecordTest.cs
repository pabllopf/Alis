// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StbUndoRecordTest.cs
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
    ///     The stb undo record test class
    /// </summary>
    public class StbUndoRecordTest
    {
        /// <summary>
        ///     Tests that where should be initialized correctly
        /// </summary>
        [Fact]
        public void Where_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoRecord undoRecord = new StbUndoRecord {Where = 10};

            // Act
            int where = undoRecord.Where;

            // Assert
            Assert.Equal(10, where);
        }

        /// <summary>
        ///     Tests that insert length should be initialized correctly
        /// </summary>
        [Fact]
        public void InsertLength_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoRecord undoRecord = new StbUndoRecord {InsertLength = 20};

            // Act
            int insertLength = undoRecord.InsertLength;

            // Assert
            Assert.Equal(20, insertLength);
        }

        /// <summary>
        ///     Tests that delete length should be initialized correctly
        /// </summary>
        [Fact]
        public void DeleteLength_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoRecord undoRecord = new StbUndoRecord {DeleteLength = 30};

            // Act
            int deleteLength = undoRecord.DeleteLength;

            // Assert
            Assert.Equal(30, deleteLength);
        }

        /// <summary>
        ///     Tests that char storage should be initialized correctly
        /// </summary>
        [Fact]
        public void CharStorage_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoRecord undoRecord = new StbUndoRecord {CharStorage = 40};

            // Act
            int charStorage = undoRecord.CharStorage;

            // Assert
            Assert.Equal(40, charStorage);
        }
    }
}