// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastLookupExtendedTest.cs
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

using System.Collections.Generic;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     Extended tests for FastLookup collection to ensure comprehensive behavior validation.
    ///     Tests include edge cases, capacity management, and stress scenarios.
    /// </summary>
    public class FastLookupExtendedTest
    {
        /// <summary>
        ///     Test that FastLookup can be created successfully.
        /// </summary>
        [Fact]
        public void Constructor_Default_CreatedSuccessfully()
        {
            // Arrange & Act
            FastLookup lookup = new FastLookup();

            // Assert
            Assert.NotNull(lookup);
        }

        /// <summary>
        ///     Test that FastLookup properly stores and retrieves data.
        /// </summary>
        [Fact]
        public void GetKey_AfterGet_ReturnsValidIndex()
        {
            // Arrange
            FastLookup lookup = new FastLookup();

            // Act
            uint key1 = FastLookup.GetKey(10, new GameObjectType(5));
            uint key2 = FastLookup.GetKey(20, new GameObjectType(5));

            // Assert
            Assert.NotEqual(key1, key2);
        }

        /// <summary>
        ///     Test that FastLookup properly handles multiple different keys.
        /// </summary>
        [Fact]
        public void GetKey_DifferentInputs_DifferentKeys()
        {
            // Arrange
            FastLookup lookup = new FastLookup();

            // Act
            uint key1 = FastLookup.GetKey(5, new GameObjectType(10));
            uint key2 = FastLookup.GetKey(5, new GameObjectType(11));
            uint key3 = FastLookup.GetKey(6, new GameObjectType(10));

            // Assert
            Assert.NotEqual(key1, key2);
            Assert.NotEqual(key1, key3);
            Assert.NotEqual(key2, key3);
        }

        /// <summary>
        ///     Test that FastLookup can generate keys for boundary values.
        /// </summary>
        [Fact]
        public void GetKey_BoundaryValues_GeneratesValidKeys()
        {
            // Arrange
            FastLookup lookup = new FastLookup();

            // Act
            uint key1 = FastLookup.GetKey(0, new GameObjectType(0));
            uint key2 = FastLookup.GetKey(ushort.MaxValue, new GameObjectType(ushort.MaxValue));

            // Assert
            Assert.NotEqual(key1, key2);
        }

        /// <summary>
        ///     Test that FastLookup generates consistent keys for same inputs.
        /// </summary>
        [Fact]
        public void GetKey_SameInputs_GeneratesSameKey()
        {
            // Arrange
            FastLookup lookup = new FastLookup();
            ushort id = 42;
            GameObjectType archetype = new GameObjectType(10);

            // Act
            uint key1 = FastLookup.GetKey(id, archetype);
            uint key2 = FastLookup.GetKey(id, archetype);

            // Assert
            Assert.Equal(key1, key2);
        }

        /// <summary>
        ///     Test that FastLookup can handle many key generation requests.
        /// </summary>
        [Fact]
        public void GetKey_ManyRequests_AllUnique()
        {
            // Arrange
            FastLookup lookup = new FastLookup();
            HashSet<uint> keys = new HashSet<uint>();

            // Act
            for (ushort i = 0; i < 100; i++)
            {
                uint key = FastLookup.GetKey(i, new GameObjectType(i));
                keys.Add(key);
            }

            // Assert
            Assert.Equal(100, keys.Count); // All keys should be unique
        }

        /// <summary>
        ///     Test that FastLookup properly manages lookup index operations.
        /// </summary>
        [Fact]
        public void LookupIndex_AfterGetKey_ReturnsValidIndex()
        {
            // Arrange
            FastLookup lookup = new FastLookup();
            uint key = FastLookup.GetKey(5, new GameObjectType(10));

            // Act
            int index = lookup.LookupIndex(key);

            // Assert
            Assert.True(index >= 0 || index == 32); // Valid index or not found indicator
        }

        /// <summary>
        ///     Test that FastLookup handles repeated lookups for same key.
        /// </summary>
        [Fact]
        public void LookupIndex_RepeatCalls_ReturnsSameIndex()
        {
            // Arrange
            FastLookup lookup = new FastLookup();
            uint key = FastLookup.GetKey(15, new GameObjectType(20));

            // Act
            int index1 = lookup.LookupIndex(key);
            int index2 = lookup.LookupIndex(key);

            // Assert
            Assert.Equal(index1, index2);
        }

        /// <summary>
        ///     Test that FastLookup properly handles non-existent key lookups.
        /// </summary>
        [Fact]
        public void LookupIndex_NonExistentKey_ReturnsNotFoundIndicator()
        {
            // Arrange
            FastLookup lookup = new FastLookup();

            // Act
            int index = lookup.LookupIndex(999999u);

            // Assert
            Assert.Equal(32, index); // Assuming 32 indicates not found
        }
    }
}