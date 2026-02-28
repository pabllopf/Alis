// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectIdOnlyTest.cs
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
    ///     The game object id only test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="GameObjectIdOnly"/> struct which stores only
    ///     the entity ID and version, used for lightweight entity references.
    /// </remarks>
    public partial class GameObjectIdOnlyTest
    {
        /// <summary>
        ///     Tests that game object id only can be created with values
        /// </summary>
        /// <remarks>
        ///     Verifies that GameObjectIdOnly can be instantiated with ID and version.
        /// </remarks>
        [Fact]
        public void GameObjectIdOnly_CanBeCreatedWithValues()
        {
            // Arrange & Act
            GameObjectIdOnly entityIdOnly = new GameObjectIdOnly(42, 5);

            // Assert
            Assert.Equal(42, entityIdOnly.ID);
            Assert.Equal((ushort)5, entityIdOnly.Version);
        }

        /// <summary>
        ///     Tests that game object id only can be created with default
        /// </summary>
        /// <remarks>
        ///     Tests creation with default constructor.
        /// </remarks>
        [Fact]
        public void GameObjectIdOnly_CanBeCreatedWithDefault()
        {
            // Act
            GameObjectIdOnly entityIdOnly = default;

            // Assert
            Assert.Equal(0, entityIdOnly.ID);
            Assert.Equal((ushort)0, entityIdOnly.Version);
        }

        /// <summary>
        ///     Tests that game object id only fields can be set independently
        /// </summary>
        /// <remarks>
        ///     Validates that ID and Version can be set independently.
        /// </remarks>
        [Fact]
        public void GameObjectIdOnly_FieldsCanBeSetIndependently()
        {
            // Arrange & Act
            GameObjectIdOnly entityIdOnly = new GameObjectIdOnly(100, 10);
            entityIdOnly.ID = 200;
            entityIdOnly.Version = 20;

            // Assert
            Assert.Equal(200, entityIdOnly.ID);
            Assert.Equal((ushort)20, entityIdOnly.Version);
        }

        /// <summary>
        ///     Tests that game object id only with negative id
        /// </summary>
        /// <remarks>
        ///     Confirms that GameObjectIdOnly can store negative IDs.
        /// </remarks>
        [Fact]
        public void GameObjectIdOnly_CanStoreNegativeId()
        {
            // Arrange & Act
            GameObjectIdOnly entityIdOnly = new GameObjectIdOnly(-1, 0);

            // Assert
            Assert.Equal(-1, entityIdOnly.ID);
        }

        /// <summary>
        ///     Tests that game object id only with max version
        /// </summary>
        /// <remarks>
        ///     Validates that GameObjectIdOnly can store max ushort version.
        /// </remarks>
        [Fact]
        public void GameObjectIdOnly_CanStoreMaxVersion()
        {
            // Arrange & Act
            GameObjectIdOnly entityIdOnly = new GameObjectIdOnly(1, ushort.MaxValue);

            // Assert
            Assert.Equal(ushort.MaxValue, entityIdOnly.Version);
        }

        /// <summary>
        ///     Tests that game object id only deconstruct
        /// </summary>
        /// <remarks>
        ///     Tests the Deconstruct method for tuple-like usage.
        /// </remarks>
        [Fact]
        public void GameObjectIdOnly_CanDeconstruct()
        {
            // Arrange
            GameObjectIdOnly entityIdOnly = new GameObjectIdOnly(42, 5);

            // Act
            entityIdOnly.Deconstruct(out int id, out ushort version);

            // Assert
            Assert.Equal(42, id);
            Assert.Equal((ushort)5, version);
        }

        /// <summary>
        ///     Tests that game object id only is value type
        /// </summary>
        /// <remarks>
        ///     Confirms that GameObjectIdOnly exhibits value type semantics.
        /// </remarks>
        [Fact]
        public void GameObjectIdOnly_IsValueType()
        {
            // Arrange
            GameObjectIdOnly entity1 = new GameObjectIdOnly(1, 0);
            GameObjectIdOnly entity2 = entity1;
            entity2.ID = 999;

            // Assert
            Assert.NotEqual(entity1.ID, entity2.ID);
            Assert.Equal(1, entity1.ID);
            Assert.Equal(999, entity2.ID);
        }

        /// <summary>
        ///     Tests that game object id only with multiple versions
        /// </summary>
        /// <remarks>
        ///     Validates that version cycling works correctly.
        /// </remarks>
        [Fact]
        public void GameObjectIdOnly_WithMultipleVersions()
        {
            // Arrange & Act
            GameObjectIdOnly entity1 = new GameObjectIdOnly(1, 0);
            GameObjectIdOnly entity2 = new GameObjectIdOnly(1, 1);
            GameObjectIdOnly entity3 = new GameObjectIdOnly(1, 100);

            // Assert
            Assert.Equal(1, entity1.ID);
            Assert.Equal((ushort)0, entity1.Version);
            Assert.Equal(1, entity2.ID);
            Assert.Equal((ushort)1, entity2.Version);
            Assert.Equal(1, entity3.ID);
            Assert.Equal((ushort)100, entity3.Version);
        }
    }
}

