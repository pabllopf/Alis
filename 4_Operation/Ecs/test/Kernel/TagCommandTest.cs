// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TagCommandTest.cs
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
    ///     The tag command test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="TagCommand"/> record struct which represents
    ///     a command to attach or detach a tag from an entity.
    /// </remarks>
    public class TagCommandTest
    {
        /// <summary>
        ///     Tests that tag command can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that TagCommand can be instantiated with valid parameters.
        /// </remarks>
        [Fact]
        public void TagCommand_CanBeCreated()
        {
            // Arrange
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);
            TagId tagId = new TagId(0);

            // Act
            TagCommand command = new TagCommand(entity, tagId);

            // Assert
            Assert.NotNull(command);
            Assert.Equal(1, command.Entity.ID);
        }

        /// <summary>
        ///     Tests that tag command entity field is preserved
        /// </summary>
        /// <remarks>
        ///     Validates that the Entity field is correctly stored.
        /// </remarks>
        [Fact]
        public void TagCommand_EntityFieldIsPreserved()
        {
            // Arrange
            GameObjectIdOnly entity = new GameObjectIdOnly(42, 5);
            TagId tagId = new TagId(10);

            // Act
            TagCommand command = new TagCommand(entity, tagId);

            // Assert
            Assert.Equal(42, command.Entity.ID);
            Assert.Equal((ushort)5, command.Entity.Version);
        }

        /// <summary>
        ///     Tests that tag command tag id field is preserved
        /// </summary>
        /// <remarks>
        ///     Validates that the TagId field is correctly stored.
        /// </remarks>
        [Fact]
        public void TagCommand_TagIdFieldIsPreserved()
        {
            // Arrange
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);
            TagId tagId = new TagId(25);

            // Act
            TagCommand command = new TagCommand(entity, tagId);

            // Assert
            Assert.Equal((ushort)25, command.TagId.RawValue);
        }

        /// <summary>
        ///     Tests that tag command is record struct
        /// </summary>
        /// <remarks>
        ///     Confirms that TagCommand behaves as a record struct.
        /// </remarks>
        [Fact]
        public void TagCommand_IsRecordStruct()
        {
            // Arrange
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);
            TagId tagId = new TagId(5);

            // Act
            TagCommand command1 = new TagCommand(entity, tagId);
            TagCommand command2 = new TagCommand(entity, tagId);

            // Assert
            Assert.Equal(command1, command2);
        }

        /// <summary>
        ///     Tests that tag command with different entities are not equal
        /// </summary>
        /// <remarks>
        ///     Validates that commands with different entities are not equal.
        /// </remarks>
        [Fact]
        public void TagCommand_WithDifferentEntitiesAreNotEqual()
        {
            // Arrange
            GameObjectIdOnly entity1 = new GameObjectIdOnly(1, 0);
            GameObjectIdOnly entity2 = new GameObjectIdOnly(2, 0);
            TagId tagId = new TagId(5);

            // Act
            TagCommand command1 = new TagCommand(entity1, tagId);
            TagCommand command2 = new TagCommand(entity2, tagId);

            // Assert
            Assert.NotEqual(command1, command2);
        }

        /// <summary>
        ///     Tests that tag command with different tag ids are not equal
        /// </summary>
        /// <remarks>
        ///     Validates that commands with different tag IDs are not equal.
        /// </remarks>
        [Fact]
        public void TagCommand_WithDifferentTagIdsAreNotEqual()
        {
            // Arrange
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);
            TagId tagId1 = new TagId(5);
            TagId tagId2 = new TagId(10);

            // Act
            TagCommand command1 = new TagCommand(entity, tagId1);
            TagCommand command2 = new TagCommand(entity, tagId2);

            // Assert
            Assert.NotEqual(command1, command2);
        }
    }
}

