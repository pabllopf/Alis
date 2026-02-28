// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EntityDataTest.cs
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

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The entity data test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="EntityData"/> struct which stores internal entity metadata
    ///     including entity ID, version, and world ID.
    /// </remarks>
    public class EntityDataTest
    {
        /// <summary>
        ///     Tests that entity data can be created with default values
        /// </summary>
        /// <remarks>
        ///     Verifies that EntityData can be initialized with default values.
        /// </remarks>
        [Fact]
        public void EntityData_CanBeCreatedWithDefaultValues()
        {
            // Act
            EntityData entityData = default;

            // Assert
            Assert.Equal(0, entityData.EntityID);
            Assert.Equal((ushort)0, entityData.EntityVersion);
            Assert.Equal((ushort)0, entityData.WorldID);
        }

        /// <summary>
        ///     Tests that entity data fields can be set and retrieved
        /// </summary>
        /// <remarks>
        ///     Validates that all fields in EntityData can be properly set and retrieved.
        /// </remarks>
        [Fact]
        public void EntityData_FieldsCanBeSetAndRetrieved()
        {
            // Arrange
            EntityData entityData = new EntityData
            {
                EntityID = 123,
                EntityVersion = 5,
                WorldID = 10
            };

            // Assert
            Assert.Equal(123, entityData.EntityID);
            Assert.Equal((ushort)5, entityData.EntityVersion);
            Assert.Equal((ushort)10, entityData.WorldID);
        }

        /// <summary>
        ///     Tests that entity id can store negative values
        /// </summary>
        /// <remarks>
        ///     Confirms that EntityID can handle negative integer values.
        /// </remarks>
        [Fact]
        public void EntityData_EntityIdCanStoreNegativeValues()
        {
            // Arrange
            EntityData entityData = new EntityData
            {
                EntityID = -1
            };

            // Assert
            Assert.Equal(-1, entityData.EntityID);
        }

        /// <summary>
        ///     Tests that entity version can store max ushort value
        /// </summary>
        /// <remarks>
        ///     Validates that EntityVersion can store the maximum ushort value.
        /// </remarks>
        [Fact]
        public void EntityData_EntityVersionCanStoreMaxUShortValue()
        {
            // Arrange
            EntityData entityData = new EntityData
            {
                EntityVersion = ushort.MaxValue
            };

            // Assert
            Assert.Equal(ushort.MaxValue, entityData.EntityVersion);
        }

        /// <summary>
        ///     Tests that world id can store max ushort value
        /// </summary>
        /// <remarks>
        ///     Validates that WorldID can store the maximum ushort value.
        /// </remarks>
        [Fact]
        public void EntityData_WorldIdCanStoreMaxUShortValue()
        {
            // Arrange
            EntityData entityData = new EntityData
            {
                WorldID = ushort.MaxValue
            };

            // Assert
            Assert.Equal(ushort.MaxValue, entityData.WorldID);
        }

        /// <summary>
        ///     Tests that entity data is value type
        /// </summary>
        /// <remarks>
        ///     Confirms that EntityData is a value type (struct) and exhibits value semantics.
        /// </remarks>
        [Fact]
        public void EntityData_IsValueType()
        {
            // Arrange
            EntityData entityData1 = new EntityData { EntityID = 100 };
            EntityData entityData2 = entityData1;

            // Act
            entityData2.EntityID = 200;

            // Assert - Changes to entityData2 should not affect entityData1
            Assert.Equal(100, entityData1.EntityID);
            Assert.Equal(200, entityData2.EntityID);
        }

        /// <summary>
        ///     Tests that entity data can be compared for equality
        /// </summary>
        /// <remarks>
        ///     Tests that two EntityData instances with the same values are equal.
        /// </remarks>
        [Fact]
        public void EntityData_CanBeComparedForEquality()
        {
            // Arrange
            EntityData entityData1 = new EntityData
            {
                EntityID = 42,
                EntityVersion = 3,
                WorldID = 7
            };
            
            EntityData entityData2 = new EntityData
            {
                EntityID = 42,
                EntityVersion = 3,
                WorldID = 7
            };

            // Assert
            Assert.Equal(entityData1.EntityID, entityData2.EntityID);
            Assert.Equal(entityData1.EntityVersion, entityData2.EntityVersion);
            Assert.Equal(entityData1.WorldID, entityData2.WorldID);
        }

        /// <summary>
        ///     Tests that entity data with different values are not equal
        /// </summary>
        /// <remarks>
        ///     Validates that EntityData instances with different field values are not equal.
        /// </remarks>
        [Fact]
        public void EntityData_WithDifferentValuesAreNotEqual()
        {
            // Arrange
            EntityData entityData1 = new EntityData { EntityID = 42 };
            EntityData entityData2 = new EntityData { EntityID = 43 };

            // Assert
            Assert.NotEqual(entityData1.EntityID, entityData2.EntityID);
        }

        /// <summary>
        ///     Tests that entity data can store boundary values
        /// </summary>
        /// <remarks>
        ///     Tests that EntityData can handle boundary values for all its fields.
        /// </remarks>
        [Fact]
        public void EntityData_CanStoreBoundaryValues()
        {
            // Arrange & Act
            EntityData entityData = new EntityData
            {
                EntityID = int.MaxValue,
                EntityVersion = ushort.MaxValue,
                WorldID = ushort.MaxValue
            };

            // Assert
            Assert.Equal(int.MaxValue, entityData.EntityID);
            Assert.Equal(ushort.MaxValue, entityData.EntityVersion);
            Assert.Equal(ushort.MaxValue, entityData.WorldID);
        }

        /// <summary>
        ///     Tests that entity data can store minimum values
        /// </summary>
        /// <remarks>
        ///     Tests that EntityData can handle minimum values for all its fields.
        /// </remarks>
        [Fact]
        public void EntityData_CanStoreMinimumValues()
        {
            // Arrange & Act
            EntityData entityData = new EntityData
            {
                EntityID = int.MinValue,
                EntityVersion = ushort.MinValue,
                WorldID = ushort.MinValue
            };

            // Assert
            Assert.Equal(int.MinValue, entityData.EntityID);
            Assert.Equal(ushort.MinValue, entityData.EntityVersion);
            Assert.Equal(ushort.MinValue, entityData.WorldID);
        }
    }
}

