// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectTypeTest.cs
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
    ///     The game object type test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="GameObjectType"/> struct which represents an archetype ID
    ///     or the set of component and tag types that make up an entity type.
    /// </remarks>
    public class GameObjectTypeTest
    {
        /// <summary>
        ///     Tests that game object type can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that GameObjectType can be instantiated with a raw index.
        /// </remarks>
        [Fact]
        public void GameObjectType_CanBeCreated()
        {
            // Act
            GameObjectType type = new GameObjectType(0);

            // Assert
            Assert.NotNull(type);
        }

        /// <summary>
        ///     Tests that game object type raw index is preserved
        /// </summary>
        /// <remarks>
        ///     Validates that the RawIndex field is correctly stored.
        /// </remarks>
        [Fact]
        public void GameObjectType_RawIndexIsPreserved()
        {
            // Arrange
            ushort index = 42;

            // Act
            GameObjectType type = new GameObjectType(index);

            // Assert
            Assert.Equal(index, type.RawIndex);
        }

        /// <summary>
        ///     Tests that game object type with zero index
        /// </summary>
        /// <remarks>
        ///     Tests creation with zero index.
        /// </remarks>
        [Fact]
        public void GameObjectType_WithZeroIndex()
        {
            // Act
            GameObjectType type = new GameObjectType(0);

            // Assert
            Assert.Equal((ushort)0, type.RawIndex);
        }

        /// <summary>
        ///     Tests that game object type with max index
        /// </summary>
        /// <remarks>
        ///     Validates that maximum ushort index can be stored.
        /// </remarks>
        [Fact]
        public void GameObjectType_WithMaxIndex()
        {
            // Act
            GameObjectType type = new GameObjectType(ushort.MaxValue);

            // Assert
            Assert.Equal(ushort.MaxValue, type.RawIndex);
        }

        /// <summary>
        ///     Tests that game object type equals with same index
        /// </summary>
        /// <remarks>
        ///     Validates that GameObjectType equality works correctly.
        /// </remarks>
        [Fact]
        public void GameObjectType_EqualsWithSameIndex()
        {
            // Arrange
            GameObjectType type1 = new GameObjectType(5);
            GameObjectType type2 = new GameObjectType(5);

            // Assert
            Assert.True(type1.Equals(type2));
            Assert.Equal(type1, type2);
        }

        /// <summary>
        ///     Tests that game object type not equals with different index
        /// </summary>
        /// <remarks>
        ///     Validates that GameObjectType inequality works correctly.
        /// </remarks>
        [Fact]
        public void GameObjectType_NotEqualsWithDifferentIndex()
        {
            // Arrange
            GameObjectType type1 = new GameObjectType(1);
            GameObjectType type2 = new GameObjectType(2);

            // Assert
            Assert.False(type1.Equals(type2));
            Assert.NotEqual(type1, type2);
        }

        /// <summary>
        ///     Tests that game object type hash code equals with same index
        /// </summary>
        /// <remarks>
        ///     Validates that GameObjectType hash code is consistent.
        /// </remarks>
        [Fact]
        public void GameObjectType_HashCodeEqualsWithSameIndex()
        {
            // Arrange
            GameObjectType type1 = new GameObjectType(10);
            GameObjectType type2 = new GameObjectType(10);

            // Assert
            Assert.Equal(type1.GetHashCode(), type2.GetHashCode());
        }

        /// <summary>
        ///     Tests that game object type can use equality operator
        /// </summary>
        /// <remarks>
        ///     Tests the == operator for GameObjectType.
        /// </remarks>
        [Fact]
        public void GameObjectType_EqualityOperator()
        {
            // Arrange
            GameObjectType type1 = new GameObjectType(7);
            GameObjectType type2 = new GameObjectType(7);
            GameObjectType type3 = new GameObjectType(8);

            // Assert
            Assert.True(type1 == type2);
            Assert.False(type1 == type3);
        }

        /// <summary>
        ///     Tests that game object type can use inequality operator
        /// </summary>
        /// <remarks>
        ///     Tests the != operator for GameObjectType.
        /// </remarks>
        [Fact]
        public void GameObjectType_InequalityOperator()
        {
            // Arrange
            GameObjectType type1 = new GameObjectType(7);
            GameObjectType type2 = new GameObjectType(7);
            GameObjectType type3 = new GameObjectType(8);

            // Assert
            Assert.False(type1 != type2);
            Assert.True(type1 != type3);
        }

        /// <summary>
        ///     Tests that game object type equals object method
        /// </summary>
        /// <remarks>
        ///     Tests the Equals(object) method.
        /// </remarks>
        [Fact]
        public void GameObjectType_EqualsObjectMethod()
        {
            // Arrange
            GameObjectType type1 = new GameObjectType(5);
            GameObjectType type2 = new GameObjectType(5);
            GameObjectType type3 = new GameObjectType(6);

            // Assert
            Assert.True(type1.Equals((object)type2));
            Assert.False(type1.Equals((object)type3));
            Assert.False(type1.Equals(null));
            Assert.False(type1.Equals("string"));
        }
    }
}

