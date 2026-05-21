// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentHandleTest.cs
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
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     Tests the <see cref="ComponentHandle" /> struct.
    /// </summary>
    public class ComponentHandleTest
    {
        /// <summary>
        ///     Tests that create with component returns valid handle.
        /// </summary>
        [Fact]
        public void Create_WithComponent_ShouldReturnValidHandle()
        {
            Position position = new Position {X = 10, Y = 20};

            ComponentHandle handle = ComponentHandle.Create(position);

            Assert.Equal(typeof(Position), handle.Type);
            Assert.Equal(Component<Position>.Id, handle.ComponentId);
        }

        /// <summary>
        ///     Tests that retrieve returns correct component value.
        /// </summary>
        [Fact]
        public void Retrieve_WithValidHandle_ShouldReturnCorrectValue()
        {
            Position position = new Position {X = 10, Y = 20};
            ComponentHandle handle = ComponentHandle.Create(position);

            Position retrieved = handle.Retrieve<Position>();

            Assert.Equal(10, retrieved.X);
            Assert.Equal(20, retrieved.Y);
        }

        /// <summary>
        ///     Tests that retrieve boxed returns component as object.
        /// </summary>
        [Fact]
        public void RetrieveBoxed_WithValidHandle_ShouldReturnBoxedComponent()
        {
            Position position = new Position {X = 10, Y = 20};
            ComponentHandle handle = ComponentHandle.Create(position);

            object retrieved = handle.RetrieveBoxed();

            Assert.NotNull(retrieved);
            Assert.IsType<Position>(retrieved);
            Position pos = (Position) retrieved;
            Assert.Equal(10, pos.X);
            Assert.Equal(20, pos.Y);
        }

        /// <summary>
        ///     Tests that create from boxed with component id works correctly.
        /// </summary>
        [Fact]
        public void CreateFromBoxed_WithComponentId_ShouldCreateValidHandle()
        {
            object position = new Position {X = 10, Y = 20};
            ComponentId typeId = Component<Position>.Id;

            ComponentHandle handle = ComponentHandle.CreateFromBoxed(typeId, position);

            Assert.Equal(typeof(Position), handle.Type);
            Assert.Equal(typeId, handle.ComponentId);
        }

        /// <summary>
        ///     Tests that create from boxed without component id works correctly.
        /// </summary>
        [Fact]
        public void CreateFromBoxed_WithoutComponentId_ShouldCreateValidHandle()
        {
            object velocity = new Velocity {X = 1, Y = 2};

            ComponentHandle handle = ComponentHandle.CreateFromBoxed(velocity);

            Assert.Equal(typeof(Velocity), handle.Type);
        }

        /// <summary>
        ///     Tests that type property returns correct component type.
        /// </summary>
        [Fact]
        public void Type_ShouldReturnCorrectComponentType()
        {
            Health health = new Health {Value = 100};
            ComponentHandle handle = ComponentHandle.Create(health);

            Type type = handle.Type;

            Assert.Equal(typeof(Health), type);
        }

        /// <summary>
        ///     Tests that component id property returns correct id.
        /// </summary>
        [Fact]
        public void ComponentId_ShouldReturnCorrectId()
        {
            Position position = new Position();
            ComponentHandle handle = ComponentHandle.Create(position);

            ComponentId componentId = handle.ComponentId;

            Assert.Equal(Component<Position>.Id, componentId);
        }

        /// <summary>
        ///     Tests that equals with same handle returns true.
        /// </summary>
        [Fact]
        public void Equals_WithSameHandle_ShouldReturnTrue()
        {
            Position position = new Position {X = 10, Y = 20};
            ComponentHandle handle1 = ComponentHandle.Create(position);
            ComponentHandle handle2 = handle1;

            bool equals = handle1.Equals(handle2);

            Assert.True(equals);
        }

        /// <summary>
        ///     Tests that equals with different handles returns false.
        /// </summary>
        [Fact]
        public void Equals_WithDifferentHandles_ShouldReturnFalse()
        {
            Position position1 = new Position {X = 10, Y = 20};
            Position position2 = new Position {X = 30, Y = 40};
            ComponentHandle handle1 = ComponentHandle.Create(position1);
            ComponentHandle handle2 = ComponentHandle.Create(position2);

            bool equals = handle1.Equals(handle2);

            Assert.False(equals);
        }

        /// <summary>
        ///     Tests that operator equals works correctly.
        /// </summary>
        [Fact]
        public void OperatorEquals_WithSameHandles_ShouldReturnTrue()
        {
            Position position = new Position();
            ComponentHandle handle1 = ComponentHandle.Create(position);
            ComponentHandle handle2 = handle1;

            bool equals = handle1 == handle2;

            Assert.True(equals);
        }

        /// <summary>
        ///     Tests that operator not equals works correctly.
        /// </summary>
        [Fact]
        public void OperatorNotEquals_WithDifferentHandles_ShouldReturnTrue()
        {
            Position position1 = new Position();
            Position position2 = new Position();
            ComponentHandle handle1 = ComponentHandle.Create(position1);
            ComponentHandle handle2 = ComponentHandle.Create(position2);

            bool notEquals = handle1 != handle2;

            Assert.True(notEquals);
        }

        /// <summary>
        ///     Tests that get hash code returns consistent value.
        /// </summary>
        [Fact]
        public void GetHashCode_ShouldReturnConsistentValue()
        {
            Position position = new Position();
            ComponentHandle handle = ComponentHandle.Create(position);

            int hashCode1 = handle.GetHashCode();
            int hashCode2 = handle.GetHashCode();

            Assert.Equal(hashCode1, hashCode2);
        }

        /// <summary>
        ///     Tests that dispose does not throw exception.
        /// </summary>
        [Fact]
        public void Dispose_ShouldNotThrowException()
        {
            Position position = new Position();
            ComponentHandle handle = ComponentHandle.Create(position);

            handle.Dispose();
        }

        /// <summary>
        ///     Tests that handle works with reference type components.
        /// </summary>
        [Fact]
        public void ComponentHandle_WithReferenceTypes_ShouldWork()
        {
            string text = "test";
            ComponentHandle handle = ComponentHandle.Create(text);

            string retrieved = handle.Retrieve<string>();

            Assert.Equal("test", retrieved);
        }

        /// <summary>
        ///     Tests that multiple create and retrieve operations work correctly.
        /// </summary>
        [Fact]
        public void MultipleCreateAndRetrieve_ShouldWorkCorrectly()
        {
            Position pos1 = new Position {X = 1, Y = 2};
            Position pos2 = new Position {X = 3, Y = 4};
            Position pos3 = new Position {X = 5, Y = 6};

            ComponentHandle handle1 = ComponentHandle.Create(pos1);
            ComponentHandle handle2 = ComponentHandle.Create(pos2);
            ComponentHandle handle3 = ComponentHandle.Create(pos3);

            Position retrieved1 = handle1.Retrieve<Position>();
            Position retrieved2 = handle2.Retrieve<Position>();
            Position retrieved3 = handle3.Retrieve<Position>();

            Assert.Equal(1, retrieved1.X);
            Assert.Equal(3, retrieved2.X);
            Assert.Equal(5, retrieved3.X);

            handle1.Dispose();
            handle2.Dispose();
            handle3.Dispose();
        }

        /// <summary>
        ///     Tests that equals with object returns correct result.
        /// </summary>
        [Fact]
        public void Equals_WithObject_ShouldReturnCorrectResult()
        {
            Position position = new Position();
            ComponentHandle handle = ComponentHandle.Create(position);
            object handleObj = handle;

            bool equals = handle.Equals(handleObj);

            Assert.True(equals);
        }

        /// <summary>
        ///     Tests that equals with null object returns false.
        /// </summary>
        [Fact]
        public void Equals_WithNullObject_ShouldReturnFalse()
        {
            Position position = new Position();
            ComponentHandle handle = ComponentHandle.Create(position);

            bool equals = handle.Equals(null);

            Assert.False(equals);
        }
    }
}