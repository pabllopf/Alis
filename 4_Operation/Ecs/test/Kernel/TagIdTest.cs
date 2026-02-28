// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TagIdTest.cs
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
using System.Collections.Generic;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     The tag id test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="TagId"/> struct which represents a lightweight
    ///     tag type identifier used for fast tag-based queries.
    /// </remarks>
    public class TagIdTest
    {
        /// <summary>
        ///     Tests that tag id can be retrieved for type
        /// </summary>
        /// <remarks>
        ///     Verifies that Tag.Id returns a valid TagId.
        /// </remarks>
        [Fact]
        public void TagId_CanBeRetrievedForType()
        {
            // Act
            TagId id = Tag<PlayerTag>.Id;

            // Assert
            Assert.NotEqual(default(TagId), id);
        }

        /// <summary>
        ///     Tests that tag id is consistent across calls
        /// </summary>
        /// <remarks>
        ///     Validates that multiple calls to get the same tag ID return the same value.
        /// </remarks>
        [Fact]
        public void TagId_IsConsistentAcrossCalls()
        {
            // Act
            TagId id1 = Tag<PlayerTag>.Id;
            TagId id2 = Tag<PlayerTag>.Id;

            // Assert
            Assert.Equal(id1, id2);
        }

        /// <summary>
        ///     Tests that different tags have different ids
        /// </summary>
        /// <remarks>
        ///     Validates that different tag types get unique IDs.
        /// </remarks>
        [Fact]
        public void DifferentTags_HaveDifferentIds()
        {
            // Act
            TagId playerId = Tag<PlayerTag>.Id;
            TagId enemyId = Tag<EnemyTag>.Id;

            // Assert
            Assert.NotEqual(playerId, enemyId);
        }

        /// <summary>
        ///     Tests that tag id equality works correctly
        /// </summary>
        /// <remarks>
        ///     Tests the Equals method of TagId.
        /// </remarks>
        [Fact]
        public void TagId_EqualityWorksCorrectly()
        {
            // Arrange
            TagId id1 = Tag<PlayerTag>.Id;
            TagId id2 = Tag<PlayerTag>.Id;
            TagId id3 = Tag<EnemyTag>.Id;

            // Assert
            Assert.True(id1.Equals(id2));
            Assert.False(id1.Equals(id3));
        }

        /// <summary>
        ///     Tests that tag id equality operator works
        /// </summary>
        /// <remarks>
        ///     Tests the == and != operators of TagId.
        /// </remarks>
        [Fact]
        public void TagId_EqualityOperatorWorks()
        {
            // Arrange
            TagId id1 = Tag<PlayerTag>.Id;
            TagId id2 = Tag<PlayerTag>.Id;
            TagId id3 = Tag<EnemyTag>.Id;

            // Assert
            Assert.True(id1 == id2);
            Assert.False(id1 == id3);
            Assert.True(id1 != id3);
            Assert.False(id1 != id2);
        }

        /// <summary>
        ///     Tests that tag id get hash code returns consistent values
        /// </summary>
        /// <remarks>
        ///     Validates that GetHashCode returns consistent values for the same TagId.
        /// </remarks>
        [Fact]
        public void TagId_GetHashCodeReturnsConsistentValues()
        {
            // Arrange
            TagId id = Tag<PlayerTag>.Id;

            // Act
            int hash1 = id.GetHashCode();
            int hash2 = id.GetHashCode();

            // Assert
            Assert.Equal(hash1, hash2);
        }

        /// <summary>
        ///     Tests that tag id has type property
        /// </summary>
        /// <remarks>
        ///     Validates that TagId.Type returns the correct Type.
        /// </remarks>
        [Fact]
        public void TagId_HasTypeProperty()
        {
            // Arrange
            TagId id = Tag<PlayerTag>.Id;

            // Act
            Type type = id.Type;

            // Assert
            Assert.NotNull(type);
            Assert.Equal(typeof(PlayerTag), type);
        }

        /// <summary>
        ///     Tests that tag id can be used in dictionary
        /// </summary>
        /// <remarks>
        ///     Tests that TagId can be used as a dictionary key.
        /// </remarks>
        [Fact]
        public void TagId_CanBeUsedInDictionary()
        {
            // Arrange
            Dictionary<TagId, string> dict = new System.Collections.Generic.Dictionary<TagId, string>();
            TagId playerId = Tag<PlayerTag>.Id;
            TagId enemyId = Tag<EnemyTag>.Id;

            // Act
            dict[playerId] = "Player";
            dict[enemyId] = "Enemy";

            // Assert
            Assert.Equal("Player", dict[playerId]);
            Assert.Equal("Enemy", dict[enemyId]);
            Assert.Equal(2, dict.Count);
        }

        /// <summary>
        ///     Tests that tag id equals null returns false
        /// </summary>
        /// <remarks>
        ///     Validates that TagId.Equals(null) returns false.
        /// </remarks>
        [Fact]
        public void TagId_EqualsNullReturnsFalse()
        {
            // Arrange
            TagId id = Tag<PlayerTag>.Id;

            // Act
            bool result = id.Equals(null);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that tag id equals wrong type returns false
        /// </summary>
        /// <remarks>
        ///     Validates that TagId.Equals with wrong type returns false.
        /// </remarks>
        [Fact]
        public void TagId_EqualsWrongTypeReturnsFalse()
        {
            // Arrange
            TagId id = Tag<PlayerTag>.Id;

            // Act
            bool result = id.Equals("string");

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that disable tag has id
        /// </summary>
        /// <remarks>
        ///     Validates that the Disable tag has a valid TagId.
        /// </remarks>
        [Fact]
        public void DisableTag_HasId()
        {
            // Act
            TagId id = Tag<Disable>.Id;
            
            Assert.Equal(typeof(Disable), id.Type);
        }

        /// <summary>
        ///     Tests that tag id works with custom tags
        /// </summary>
        /// <remarks>
        ///     Tests that TagId works correctly with custom tag types.
        /// </remarks>
        [Fact]
        public void TagId_WorksWithCustomTags()
        {
            // Act
            TagId tagId = Tag<TagComponent>.Id;

            // Assert
            Assert.NotEqual(default(TagId), tagId);
            Assert.Equal(typeof(TagComponent), tagId.Type);
        }

        /// <summary>
        ///     Tests that multiple tag ids are unique
        /// </summary>
        /// <remarks>
        ///     Validates that multiple different tag types all have unique IDs.
        /// </remarks>
        [Fact]
        public void MultipleTagIds_AreUnique()
        {
            // Act
            TagId id1 = Tag<PlayerTag>.Id;
            TagId id2 = Tag<EnemyTag>.Id;
            TagId id3 = Tag<TagComponent>.Id;
            TagId id4 = Tag<Disable>.Id;

            // Assert
            Assert.NotEqual(id1, id2);
            Assert.NotEqual(id1, id3);
            Assert.NotEqual(id1, id4);
            Assert.NotEqual(id2, id3);
            Assert.NotEqual(id2, id4);
            Assert.NotEqual(id3, id4);
        }
    }
}

