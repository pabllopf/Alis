// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastLookupTest.cs
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

using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     The fast lookup test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="FastLookup"/> struct which provides fast
    ///     archetype lookup for component and tag operations.
    /// </remarks>
    public class FastLookupTest
    {
        /// <summary>
        ///     Tests that fast lookup can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that a FastLookup instance can be created.
        /// </remarks>
        [Fact]
        public void FastLookup_CanBeCreated()
        {
            // Act
            FastLookup lookup = new FastLookup();

            // Assert
            Assert.NotNull(lookup.Archetypes);
        }

        /// <summary>
        ///     Tests that fast lookup get key combines id and archetype
        /// </summary>
        /// <remarks>
        ///     Validates that GetKey properly combines component/tag ID with archetype ID.
        /// </remarks>
        [Fact]
        public void FastLookup_GetKeyCombinesIdAndArchetype()
        {
            // Arrange
            FastLookup lookup = new FastLookup();
            ushort id = 5;
            GameObjectType archetypeId = new GameObjectType(10);

            // Act
            uint key = lookup.GetKey(id, archetypeId);

            // Assert
            Assert.NotEqual(0u, key);
            Assert.Equal((uint)((id << 16) | archetypeId.RawIndex), key);
        }

        /// <summary>
        ///     Tests that fast lookup get key with zero values
        /// </summary>
        /// <remarks>
        ///     Tests GetKey with zero ID and zero archetype ID.
        /// </remarks>
        [Fact]
        public void FastLookup_GetKeyWithZeroValues()
        {
            // Arrange
            FastLookup lookup = new FastLookup();
            ushort id = 0;
            GameObjectType archetypeId = new GameObjectType(0);

            // Act
            uint key = lookup.GetKey(id, archetypeId);

            // Assert
            Assert.Equal(0u, key);
        }

        /// <summary>
        ///     Tests that fast lookup get key with max values
        /// </summary>
        /// <remarks>
        ///     Tests GetKey with maximum ID values.
        /// </remarks>
        [Fact]
        public void FastLookup_GetKeyWithMaxValues()
        {
            // Arrange
            FastLookup lookup = new FastLookup();
            ushort id = ushort.MaxValue;
            GameObjectType archetypeId = new GameObjectType(ushort.MaxValue);

            // Act
            uint key = lookup.GetKey(id, archetypeId);

            // Assert
            Assert.NotEqual(0u, key);
        }

        /// <summary>
        ///     Tests that fast lookup lookup index returns not found for non existent key
        /// </summary>
        /// <remarks>
        ///     Verifies that LookupIndex returns 32 (not found) for non-existent keys.
        /// </remarks>
        [Fact]
        public void FastLookup_LookupIndexReturnsNotFoundForNonExistentKey()
        {
            // Arrange
            FastLookup lookup = new FastLookup();
            uint key = 999u;

            // Act
            int result = lookup.LookupIndex(key);

            // Assert
            Assert.Equal(32, result);
        }

        /// <summary>
        ///     Tests that fast lookup archetypes array is initialized
        /// </summary>
        /// <remarks>
        ///     Validates that the Archetypes array is properly initialized.
        /// </remarks>
        [Fact]
        public void FastLookup_ArchetypesArrayIsInitialized()
        {
            // Arrange & Act
            FastLookup lookup = new FastLookup();

            // Assert
            Assert.NotNull(lookup.Archetypes);
            Assert.Equal(8, lookup.Archetypes.Length);
        }

        /// <summary>
        ///     Tests that fast lookup different keys produce different values
        /// </summary>
        /// <remarks>
        ///     Verifies that different input combinations produce different keys.
        /// </remarks>
        [Fact]
        public void FastLookup_DifferentKeysProduceDifferentValues()
        {
            // Arrange
            FastLookup lookup = new FastLookup();

            // Act
            uint key1 = lookup.GetKey(1, new GameObjectType(1));
            uint key2 = lookup.GetKey(2, new GameObjectType(2));
            uint key3 = lookup.GetKey(1, new GameObjectType(2));

            // Assert
            Assert.NotEqual(key1, key2);
            Assert.NotEqual(key1, key3);
            Assert.NotEqual(key2, key3);
        }

        /// <summary>
        ///     Tests that fast lookup is value type
        /// </summary>
        /// <remarks>
        ///     Confirms that FastLookup is a value type (struct).
        /// </remarks>
        [Fact]
        public void FastLookup_IsValueType()
        {
            // Arrange
            FastLookup lookup1 = new FastLookup();
            FastLookup lookup2 = lookup1;
            lookup2.Archetypes[0] = null;
            
            Assert.Null(lookup2.Archetypes[0]);
        }
    }
}

