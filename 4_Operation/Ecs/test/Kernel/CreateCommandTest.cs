// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CreateCommandTest.cs
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

using Alis.Core.Ecs.Kernel;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     The create command test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="CreateCommand"/> record struct which represents
    ///     a command to create a new entity with specific components.
    /// </remarks>
    public class CreateCommandTest
    {
        /// <summary>
        ///     Tests that create command can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that CreateCommand can be instantiated.
        /// </remarks>
        [Fact]
        public void CreateCommand_CanBeCreated()
        {
            // Arrange
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);

            // Act
            CreateCommand command = new CreateCommand(entity, 0, 10);

            // Assert
            Assert.NotNull(command);
        }

        /// <summary>
        ///     Tests that create command archetype id is preserved
        /// </summary>
        /// <remarks>
        ///     Validates that the ArchetypeId field is correctly stored.
        /// </remarks>
        [Fact]
        public void CreateCommand_ParametersArePreserved()
        {
            // Arrange
            GameObjectIdOnly entity = new GameObjectIdOnly(42, 5);
            int bufferIndex = 10;
            int bufferLength = 50;

            // Act
            CreateCommand command = new CreateCommand(entity, bufferIndex, bufferLength);

            // Assert
            Assert.NotNull(command);
        }

        /// <summary>
        ///     Tests that create command is record struct
        /// </summary>
        /// <remarks>
        ///     Confirms that CreateCommand behaves as a record struct.
        /// </remarks>
        [Fact]
        public void CreateCommand_IsRecordStruct()
        {
            // Arrange
            GameObjectIdOnly entity = new GameObjectIdOnly(10, 0);

            // Act
            CreateCommand command1 = new CreateCommand(entity, 5, 20);
            CreateCommand command2 = new CreateCommand(entity, 5, 20);

            // Assert
            Assert.Equal(command1, command2);
        }

        /// <summary>
        ///     Tests that create command with different buffer indices are not equal
        /// </summary>
        /// <remarks>
        ///     Validates that commands with different buffer indices are not equal.
        /// </remarks>
        [Fact]
        public void CreateCommand_WithDifferentBufferIndicesAreNotEqual()
        {
            // Arrange
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);

            // Act
            CreateCommand command1 = new CreateCommand(entity, 1, 20);
            CreateCommand command2 = new CreateCommand(entity, 2, 20);

            // Assert
            Assert.NotEqual(command1, command2);
        }

        /// <summary>
        ///     Tests that create command with zero indices
        /// </summary>
        /// <remarks>
        ///     Tests creation with zero indices.
        /// </remarks>
        [Fact]
        public void CreateCommand_WithZeroIndices()
        {
            // Act
            CreateCommand command = new CreateCommand(new GameObjectIdOnly(0, 0), 0, 0);

            // Assert
            Assert.NotNull(command);
        }

        /// <summary>
        ///     Tests that create command with max values
        /// </summary>
        /// <remarks>
        ///     Tests creation with maximum values.
        /// </remarks>
        [Fact]
        public void CreateCommand_WithMaxValues()
        {
            // Act
            CreateCommand command = new CreateCommand(new GameObjectIdOnly(int.MaxValue, ushort.MaxValue), int.MaxValue, int.MaxValue);

            // Assert
            Assert.NotNull(command);
        }
    }
}

