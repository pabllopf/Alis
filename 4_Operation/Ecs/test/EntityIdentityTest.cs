// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EntityIdentityTest.cs
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

using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Tests for entity identity and equality
    /// </summary>
    /// <remarks>
    ///     Validates that entities have unique identities, can be compared
    ///     for equality, and maintain identity across operations.
    /// </remarks>
    public class EntityIdentityTest
    {
        /// <summary>
        ///     Tests that default game object is null
        /// </summary>
        [Fact]
        public void GameObject_DefaultIsNull()
        {
            // Arrange & Act
            GameObject defaultEntity = default;

            // Assert
            Assert.True(defaultEntity.IsNull);
            Assert.False(defaultEntity.IsAlive);
        }

        /// <summary>
        ///     Tests entity equality
        /// </summary>
        [Fact]
        public void GameObject_EqualityWorks()
        {
            // Arrange
            using var scene = new Scene();
            GameObject entity1 = scene.Create();
            GameObject entity2 = entity1; // Same reference

            // Act & Assert
            Assert.Equal(entity1, entity2);
            Assert.True(entity1 == entity2);
        }

        /// <summary>
        ///     Tests different entities are not equal
        /// </summary>
        [Fact]
        public void GameObject_DifferentEntitiesAreNotEqual()
        {
            // Arrange
            using var scene = new Scene();
            GameObject entity1 = scene.Create();
            GameObject entity2 = scene.Create();

            // Act & Assert
            Assert.NotEqual(entity1, entity2);
            Assert.False(entity1 == entity2);
        }

        /// <summary>
        ///     Tests that entities from different scenes are not equal
        /// </summary>
        [Fact]
        public void GameObject_EntitiesFromDifferentScenesAreNotEqual()
        {
            // Arrange
            using var scene1 = new Scene();
            using var scene2 = new Scene();
            GameObject entity1 = scene1.Create();
            GameObject entity2 = scene2.Create();

            // Act & Assert
            Assert.NotEqual(entity1, entity2);
        }

        /// <summary>
        ///     Tests entity hash code
        /// </summary>
        [Fact]
        public void GameObject_GetHashCodeWorks()
        {
            // Arrange
            using var scene = new Scene();
            GameObject entity1 = scene.Create();
            GameObject entity2 = entity1;

            // Act
            int hash1 = entity1.GetHashCode();
            int hash2 = entity2.GetHashCode();

            // Assert
            Assert.Equal(hash1, hash2);
        }

        /// <summary>
        ///     Tests that entity IDs are sequential
        /// </summary>
        [Fact]
        public void Scene_EntityIdsAreSequential()
        {
            // Arrange
            using var scene = new Scene();

            // Act
            GameObject entity1 = scene.Create();
            GameObject entity2 = scene.Create();
            GameObject entity3 = scene.Create();

            // Assert
            Assert.True(entity2.EntityID > entity1.EntityID);
            Assert.True(entity3.EntityID > entity2.EntityID);
        }

        /// <summary>
        ///     Tests checking if entity is null
        /// </summary>
        [Fact]
        public void GameObject_IsNullCheck()
        {
            // Arrange
            using var scene = new Scene();
            GameObject nullEntity = default;
            GameObject validEntity = scene.Create();

            // Act & Assert
            Assert.True(nullEntity.IsNull);
            Assert.False(validEntity.IsNull);
        }

        /// <summary>
        ///     Tests that entity maintains identity after component changes
        /// </summary>
        [Fact]
        public void GameObject_MaintainsIdentityAfterComponentChanges()
        {
            // Arrange
            using var scene = new Scene();
            GameObject entity = scene.Create();
            int originalId = entity.EntityID;

            // Act
            entity.Add(new Position { X = 1 });
            entity.Add(new Health { Value = 100 });
            entity.Remove<Position>();

            // Assert
            Assert.Equal(originalId, entity.EntityID);
        }
    }
}

