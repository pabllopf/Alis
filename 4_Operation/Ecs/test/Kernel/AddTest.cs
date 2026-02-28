// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AddTest.cs
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
    ///     The add component test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="Add"/> record struct which represents
    ///     a command to add a component to an entity.
    /// </remarks>
    public class AddTest
    {
        /// <summary>
        ///     Tests that add component can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that Add can be instantiated with valid parameters.
        /// </remarks>
        [Fact]
        public void Add_CanBeCreated()
        {
            // Arrange
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);
            ComponentId componentId = new ComponentId(0);
            ComponentHandle componentHandle = new ComponentHandle(0, componentId);

            // Act
            AddComponent addComp = new AddComponent(entity, componentHandle);

            // Assert
            Assert.Equal(1, addComp.Entity.ID);
        }

        /// <summary>
        ///     Tests that add component entity field is preserved
        /// </summary>
        /// <remarks>
        ///     Validates that the Entity field is correctly stored.
        /// </remarks>
        [Fact]
        public void Add_EntityFieldIsPreserved()
        {
            // Arrange
            GameObjectIdOnly entity = new GameObjectIdOnly(42, 5);
            ComponentId componentId = new ComponentId(0);
            ComponentHandle componentHandle = new ComponentHandle(0, componentId);

            // Act
            AddComponent addComp = new AddComponent(entity, componentHandle);

            // Assert
            Assert.Equal(42, addComp.Entity.ID);
            Assert.Equal((ushort)5, addComp.Entity.Version);
        }

        /// <summary>
        ///     Tests that add component handle field is preserved
        /// </summary>
        /// <remarks>
        ///     Validates that the ComponentHandle field is correctly stored.
        /// </remarks>
        [Fact]
        public void Add_ComponentHandleFieldIsPreserved()
        {
            // Arrange
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);
            ComponentId componentId = new ComponentId(2);
            ComponentHandle componentHandle = new ComponentHandle(10, componentId);

            // Act
            AddComponent addComp = new AddComponent(entity, componentHandle);

            // Assert
            Assert.Equal(10, addComp.ComponentHandle.Index);
            Assert.Equal((ushort)2, addComp.ComponentHandle.ComponentId.RawIndex);
        }

        /// <summary>
        ///     Tests that add component is record struct
        /// </summary>
        /// <remarks>
        ///     Confirms that Add behaves as a record struct with value semantics.
        /// </remarks>
        [Fact]
        public void Add_IsRecordStruct()
        {
            // Arrange
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);
            ComponentId componentId = new ComponentId(0);
            ComponentHandle componentHandle = new ComponentHandle(0, componentId);

            // Act
            AddComponent addComp1 = new AddComponent(entity, componentHandle);
            AddComponent addComp2 = new AddComponent(entity, componentHandle);

            // Assert
            Assert.Equal(addComp1, addComp2);
        }

        /// <summary>
        ///     Tests that add component with different entities are not equal
        /// </summary>
        /// <remarks>
        ///     Validates that Add with different entities are not equal.
        /// </remarks>
        [Fact]
        public void Add_WithDifferentEntitiesAreNotEqual()
        {
            // Arrange
            GameObjectIdOnly entity1 = new GameObjectIdOnly(1, 0);
            GameObjectIdOnly entity2 = new GameObjectIdOnly(2, 0);
            ComponentId id = new ComponentId(0);
            ComponentHandle componentHandle = new ComponentHandle(0, id);

            // Act
            AddComponent addComp1 = new AddComponent(entity1, componentHandle);
            AddComponent addComp2 = new AddComponent(entity2, componentHandle);

            // Assert
            Assert.NotEqual(addComp1, addComp2);
        }

        /// <summary>
        ///     Tests that add component with different handles are not equal
        /// </summary>
        /// <remarks>
        ///     Validates that Add with different handles are not equal.
        /// </remarks>
        [Fact]
        public void Add_WithDifferentHandlesAreNotEqual()
        {
            // Arrange
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);
            ComponentId id = new ComponentId(0);
            ComponentHandle handle1 = new ComponentHandle(1, id);
            ComponentHandle handle2 = new ComponentHandle(2, id);

            // Act
            AddComponent addComp1 = new AddComponent(entity, handle1);
            AddComponent addComp2 = new AddComponent(entity, handle2);

            // Assert
            Assert.NotEqual(addComp1, addComp2);
        }

        /// <summary>
        ///     Tests that add component hash code consistency
        /// </summary>
        /// <remarks>
        ///     Validates that equal Add structs have same hash code.
        /// </remarks>
        [Fact]
        public void Add_HashCodeConsistency()
        {
            // Arrange
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);
            ComponentId id = new ComponentId(0);
            ComponentHandle handle = new ComponentHandle(0, id);

            // Act
            AddComponent addComp1 = new AddComponent(entity, handle);
            AddComponent addComp2 = new AddComponent(entity, handle);

            // Assert
            Assert.Equal(addComp1.GetHashCode(), addComp2.GetHashCode());
        }

        /// <summary>
        ///     Tests that add component with different versions are not equal
        /// </summary>
        /// <remarks>
        ///     Validates that Add with different entity versions are not equal.
        /// </remarks>
        [Fact]
        public void Add_WithDifferentVersionsAreNotEqual()
        {
            // Arrange
            GameObjectIdOnly entity1 = new GameObjectIdOnly(1, 0);
            GameObjectIdOnly entity2 = new GameObjectIdOnly(1, 1);
            ComponentId id = new ComponentId(0);
            ComponentHandle handle = new ComponentHandle(0, id);

            // Act
            AddComponent addComp1 = new AddComponent(entity1, handle);
            AddComponent addComp2 = new AddComponent(entity2, handle);

            // Assert
            Assert.NotEqual(addComp1, addComp2);
        }

        /// <summary>
        ///     Tests that add component with different component ids are not equal
        /// </summary>
        /// <remarks>
        ///     Validates that Add with different component IDs are not equal.
        /// </remarks>
        [Fact]
        public void Add_WithDifferentComponentIdsAreNotEqual()
        {
            // Arrange
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);
            ComponentId id1 = new ComponentId(0);
            ComponentId id2 = new ComponentId(1);
            ComponentHandle handle1 = new ComponentHandle(0, id1);
            ComponentHandle handle2 = new ComponentHandle(0, id2);

            // Act
            AddComponent addComp1 = new AddComponent(entity, handle1);
            AddComponent addComp2 = new AddComponent(entity, handle2);

            // Assert
            Assert.NotEqual(addComp1, addComp2);
        }

        /// <summary>
        ///     Tests that add component with max values
        /// </summary>
        /// <remarks>
        ///     Tests Add with maximum values.
        /// </remarks>
        [Fact]
        public void Add_WithMaxValues()
        {
            // Arrange
            GameObjectIdOnly entity = new GameObjectIdOnly(int.MaxValue, ushort.MaxValue);
            ComponentId id = new ComponentId(ushort.MaxValue);
            ComponentHandle handle = new ComponentHandle(int.MaxValue, id);

            // Act
            AddComponent addComp = new AddComponent(entity, handle);

            // Assert
            Assert.Equal(int.MaxValue, addComp.Entity.ID);
            Assert.Equal(ushort.MaxValue, addComp.Entity.Version);
            Assert.Equal(int.MaxValue, addComp.ComponentHandle.Index);
            Assert.Equal(ushort.MaxValue, addComp.ComponentHandle.ComponentId.RawIndex);
        }

        /// <summary>
        ///     Tests that add component to string works
        /// </summary>
        /// <remarks>
        ///     Validates string representation of Add.
        /// </remarks>
        [Fact]
        public void Add_ToStringWorks()
        {
            // Arrange
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);
            ComponentId id = new ComponentId(0);
            ComponentHandle handle = new ComponentHandle(0, id);

            // Act
            AddComponent addComp = new AddComponent(entity, handle);
            string result = addComp.ToString();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }
    }
}

