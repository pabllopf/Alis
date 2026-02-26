// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentDataTest.cs
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

using System;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     The component data test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="ComponentData"/> record struct which stores metadata
    ///     about a component type including its storage and initialization/destruction handlers.
    /// </remarks>
    public class ComponentDataTest
    {
        /// <summary>
        ///     Tests that component data can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that ComponentData can be instantiated with valid parameters.
        /// </remarks>
        [Fact]
        public void ComponentData_CanBeCreated()
        {
            // Arrange
            Type type = typeof(TestComponent);
            IdTable storage = new IdTable<TestComponent>();
            Delegate initer = null;
            Delegate destroyer = null;

            // Act
            ComponentData data = new ComponentData(type, storage, initer, destroyer);

            // Assert
            Assert.Equal(type, data.Type);
            Assert.Equal(storage, data.Storage);
        }

        /// <summary>
        ///     Tests that component data type field is preserved
        /// </summary>
        /// <remarks>
        ///     Validates that the Type field is correctly stored.
        /// </remarks>
        [Fact]
        public void ComponentData_TypeFieldIsPreserved()
        {
            // Arrange
            Type type = typeof(Position);
            IdTable storage = new IdTable<Position>();

            // Act
            ComponentData data = new ComponentData(type, storage, null, null);

            // Assert
            Assert.Equal(type, data.Type);
        }

        /// <summary>
        ///     Tests that component data storage field is preserved
        /// </summary>
        /// <remarks>
        ///     Validates that the Storage field is correctly stored.
        /// </remarks>
        [Fact]
        public void ComponentData_StorageFieldIsPreserved()
        {
            // Arrange
            IdTable storage = new IdTable<Health>();
            Type type = typeof(Health);

            // Act
            ComponentData data = new ComponentData(type, storage, null, null);

            // Assert
            Assert.Equal(storage, data.Storage);
        }

        /// <summary>
        ///     Tests that component data initer delegate is preserved
        /// </summary>
        /// <remarks>
        ///     Validates that the Initer delegate can be stored.
        /// </remarks>
        [Fact]
        public void ComponentData_IniterDelegateIsPreserved()
        {
            // Arrange
            Type type = typeof(TestComponent);
            IdTable storage = new IdTable<TestComponent>();
            Action initer = () => { };

            // Act
            ComponentData data = new ComponentData(type, storage, initer, null);

            // Assert
            Assert.Equal(initer, data.Initer);
        }

        /// <summary>
        ///     Tests that component data destroyer delegate is preserved
        /// </summary>
        /// <remarks>
        ///     Validates that the Destroyer delegate can be stored.
        /// </remarks>
        [Fact]
        public void ComponentData_DestroyerDelegateIsPreserved()
        {
            // Arrange
            Type type = typeof(TestComponent);
            IdTable storage = new IdTable<TestComponent>();
            Action destroyer = () => { };

            // Act
            ComponentData data = new ComponentData(type, storage, null, destroyer);

            // Assert
            Assert.Equal(destroyer, data.Destroyer);
        }

        /// <summary>
        ///     Tests that component data is record struct
        /// </summary>
        /// <remarks>
        ///     Confirms that ComponentData behaves as a record struct.
        /// </remarks>
        [Fact]
        public void ComponentData_IsRecordStruct()
        {
            // Arrange
            Type type = typeof(TestComponent);
            IdTable storage = new IdTable<TestComponent>();

            // Act
            ComponentData data1 = new ComponentData(type, storage, null, null);
            ComponentData data2 = new ComponentData(type, storage, null, null);

            // Assert
            Assert.Equal(data1, data2);
        }

        /// <summary>
        ///     Tests that component data with different types are not equal
        /// </summary>
        /// <remarks>
        ///     Validates that records with different types are not equal.
        /// </remarks>
        [Fact]
        public void ComponentData_WithDifferentTypesAreNotEqual()
        {
            // Arrange
            IdTable storage = new IdTable<TestComponent>();
            Type type1 = typeof(TestComponent);
            Type type2 = typeof(Position);

            // Act
            ComponentData data1 = new ComponentData(type1, storage, null, null);
            ComponentData data2 = new ComponentData(type2, storage, null, null);

            // Assert
            Assert.NotEqual(data1, data2);
        }

        /// <summary>
        ///     Tests that component data with null delegates
        /// </summary>
        /// <remarks>
        ///     Validates that null delegates are acceptable.
        /// </remarks>
        [Fact]
        public void ComponentData_WithNullDelegates()
        {
            // Arrange
            Type type = typeof(TestComponent);
            IdTable storage = new IdTable<TestComponent>();

            // Act
            ComponentData data = new ComponentData(type, storage, null, null);

            // Assert
            Assert.Null(data.Initer);
            Assert.Null(data.Destroyer);
        }

        /// <summary>
        ///     Tests that component data hash code consistency
        /// </summary>
        /// <remarks>
        ///     Validates that equal ComponentData structs have same hash code.
        /// </remarks>
        [Fact]
        public void ComponentData_HashCodeConsistency()
        {
            // Arrange
            Type type = typeof(TestComponent);
            IdTable storage = new IdTable<TestComponent>();

            // Act
            ComponentData data1 = new ComponentData(type, storage, null, null);
            ComponentData data2 = new ComponentData(type, storage, null, null);

            // Assert
            Assert.Equal(data1.GetHashCode(), data2.GetHashCode());
        }

        /// <summary>
        ///     Tests that component data with different storages are not equal
        /// </summary>
        /// <remarks>
        ///     Validates that ComponentData with different storages are not equal.
        /// </remarks>
        [Fact]
        public void ComponentData_WithDifferentStoragesAreNotEqual()
        {
            // Arrange
            Type type = typeof(TestComponent);
            IdTable storage1 = new IdTable<TestComponent>();
            IdTable storage2 = new IdTable<TestComponent>();

            // Act
            ComponentData data1 = new ComponentData(type, storage1, null, null);
            ComponentData data2 = new ComponentData(type, storage2, null, null);

            // Assert
            Assert.NotEqual(data1, data2);
        }

        /// <summary>
        ///     Tests that component data with different initer delegates are not equal
        /// </summary>
        /// <remarks>
        ///     Validates that ComponentData with different delegates are not equal.
        /// </remarks>
        [Fact]
        public void ComponentData_WithDifferentInitersAreNotEqual()
        {
            // Arrange
            Type type = typeof(TestComponent);
            IdTable storage = new IdTable<TestComponent>();
            Action initer1 = () => { };
            Action initer2 = () => { };

            // Act
            ComponentData data1 = new ComponentData(type, storage, initer1, null);
            ComponentData data2 = new ComponentData(type, storage, initer2, null);

            // Assert
            Assert.NotEqual(data1, data2);
        }

        /// <summary>
        ///     Tests that component data with different destroyer delegates are not equal
        /// </summary>
        /// <remarks>
        ///     Validates that ComponentData with different destroyers are not equal.
        /// </remarks>
        [Fact]
        public void ComponentData_WithDifferentDestroyersAreNotEqual()
        {
            // Arrange
            Type type = typeof(TestComponent);
            IdTable storage = new IdTable<TestComponent>();
            Action destroyer1 = () => { };
            Action destroyer2 = () => { };

            // Act
            ComponentData data1 = new ComponentData(type, storage, null, destroyer1);
            ComponentData data2 = new ComponentData(type, storage, null, destroyer2);

            // Assert
            Assert.NotEqual(data1, data2);
        }

        /// <summary>
        ///     Tests that component data to string works
        /// </summary>
        /// <remarks>
        ///     Validates string representation of ComponentData.
        /// </remarks>
        [Fact]
        public void ComponentData_ToStringWorks()
        {
            // Arrange
            Type type = typeof(TestComponent);
            IdTable storage = new IdTable<TestComponent>();

            // Act
            ComponentData data = new ComponentData(type, storage, null, null);
            string result = data.ToString();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }

        /// <summary>
        ///     Tests that component data with both delegates
        /// </summary>
        /// <remarks>
        ///     Tests ComponentData with both initer and destroyer delegates set.
        /// </remarks>
        [Fact]
        public void ComponentData_WithBothDelegates()
        {
            // Arrange
            Type type = typeof(TestComponent);
            IdTable storage = new IdTable<TestComponent>();
            Action initer = () => { };
            Action destroyer = () => { };

            // Act
            ComponentData data = new ComponentData(type, storage, initer, destroyer);

            // Assert
            Assert.Equal(initer, data.Initer);
            Assert.Equal(destroyer, data.Destroyer);
            Assert.NotNull(data.Initer);
            Assert.NotNull(data.Destroyer);
        }

        /// <summary>
        ///     Tests that component data equality
        /// </summary>
        /// <remarks>
        ///     Tests ComponentData equality with identical values.
        /// </remarks>
        [Fact]
        public void ComponentData_Equality()
        {
            // Arrange
            Type type = typeof(TestComponent);
            IdTable storage = new IdTable<TestComponent>();

            // Act
            ComponentData data1 = new ComponentData(type, storage, null, null);
            ComponentData data2 = new ComponentData(type, storage, null, null);

            // Assert
            Assert.Equal(data1, data2);
        }
    }
}

