// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DeleteComponentTest.cs
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
    ///     The delete component test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="DeleteComponent"/> record struct which represents
    ///     a command to remove a component from an entity.
    /// </remarks>
    public class DeleteComponentTest
    {
        /// <summary>
        ///     Tests that delete component can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that DeleteComponent can be instantiated with valid parameters.
        /// </remarks>
        [Fact]
        public void DeleteComponent_CanBeCreated()
        {
            // Arrange
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);
            ComponentId componentId = new ComponentId(0);

            // Act
            DeleteComponent deleteComp = new DeleteComponent(entity, componentId);

            // Assert
            Assert.NotNull(deleteComp);
            Assert.Equal(1, deleteComp.Entity.ID);
        }

        /// <summary>
        ///     Tests that delete component entity field is preserved
        /// </summary>
        /// <remarks>
        ///     Validates that the Entity field is correctly stored.
        /// </remarks>
        [Fact]
        public void DeleteComponent_EntityFieldIsPreserved()
        {
            // Arrange
            GameObjectIdOnly entity = new GameObjectIdOnly(99, 10);
            ComponentId componentId = new ComponentId(5);

            // Act
            DeleteComponent deleteComp = new DeleteComponent(entity, componentId);

            // Assert
            Assert.Equal(99, deleteComp.Entity.ID);
            Assert.Equal((ushort)10, deleteComp.Entity.Version);
        }

        /// <summary>
        ///     Tests that delete component id field is preserved
        /// </summary>
        /// <remarks>
        ///     Validates that the ComponentId field is correctly stored.
        /// </remarks>
        [Fact]
        public void DeleteComponent_ComponentIdFieldIsPreserved()
        {
            // Arrange
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);
            ComponentId componentId = new ComponentId(42);

            // Act
            DeleteComponent deleteComp = new DeleteComponent(entity, componentId);

            // Assert
            Assert.Equal((ushort)42, deleteComp.ComponentId.RawIndex);
        }

        /// <summary>
        ///     Tests that delete component is record struct
        /// </summary>
        /// <remarks>
        ///     Confirms that DeleteComponent behaves as a record struct with value semantics.
        /// </remarks>
        [Fact]
        public void DeleteComponent_IsRecordStruct()
        {
            // Arrange
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);
            ComponentId componentId = new ComponentId(5);

            // Act
            DeleteComponent deleteComp1 = new DeleteComponent(entity, componentId);
            DeleteComponent deleteComp2 = new DeleteComponent(entity, componentId);

            // Assert
            Assert.Equal(deleteComp1, deleteComp2);
        }

        /// <summary>
        ///     Tests that delete component with different entities are not equal
        /// </summary>
        /// <remarks>
        ///     Validates that DeleteComponent with different entities are not equal.
        /// </remarks>
        [Fact]
        public void DeleteComponent_WithDifferentEntitiesAreNotEqual()
        {
            // Arrange
            GameObjectIdOnly entity1 = new GameObjectIdOnly(1, 0);
            GameObjectIdOnly entity2 = new GameObjectIdOnly(2, 0);
            ComponentId componentId = new ComponentId(5);

            // Act
            DeleteComponent deleteComp1 = new DeleteComponent(entity1, componentId);
            DeleteComponent deleteComp2 = new DeleteComponent(entity2, componentId);

            // Assert
            Assert.NotEqual(deleteComp1, deleteComp2);
        }

        /// <summary>
        ///     Tests that delete component with different ids are not equal
        /// </summary>
        /// <remarks>
        ///     Validates that DeleteComponent with different component IDs are not equal.
        /// </remarks>
        [Fact]
        public void DeleteComponent_WithDifferentComponentIdsAreNotEqual()
        {
            // Arrange
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);
            ComponentId componentId1 = new ComponentId(5);
            ComponentId componentId2 = new ComponentId(10);

            // Act
            DeleteComponent deleteComp1 = new DeleteComponent(entity, componentId1);
            DeleteComponent deleteComp2 = new DeleteComponent(entity, componentId2);

            // Assert
            Assert.NotEqual(deleteComp1, deleteComp2);
        }
    }
}

