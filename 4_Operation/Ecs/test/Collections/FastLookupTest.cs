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
using Alis.Core.Ecs.Kernel.Archetypes;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     The fast lookup test class
    /// </summary>
    public class FastLookupTest
    {
        /// <summary>
        ///     Tests that GetKey combines archetype index and component id correctly
        /// </summary>
        [Fact]
        public void GetKey_ShouldCombineArchetypeIndexAndComponentId()
        {
            ushort componentId = 5;
            GameObjectType archetype = new GameObjectType(3);

            uint key = FastLookup.GetKey(componentId, archetype);

            Assert.Equal(archetype.RawIndex | ((uint) componentId << 16), key);
        }

        /// <summary>
        ///     Tests that GetKey with zero archetype index uses only component id
        /// </summary>
        [Fact]
        public void GetKey_WithZeroArchetype_ShouldUseComponentId()
        {
            ushort componentId = 10;
            GameObjectType archetype = new GameObjectType(0);

            uint key = FastLookup.GetKey(componentId, archetype);

            Assert.Equal((uint) componentId << 16, key);
        }

        /// <summary>
        ///     Tests that GetKey with maximum component id works correctly
        /// </summary>
        [Fact]
        public void GetKey_WithMaxComponentId_ShouldWork()
        {
            ushort componentId = ushort.MaxValue;
            GameObjectType archetype = new GameObjectType(1);

            uint key = FastLookup.GetKey(componentId, archetype);

            Assert.Equal(1 | ((uint) ushort.MaxValue << 16), key);
        }

        /// <summary>
        ///     Tests that GetKey produces unique keys for different component ids
        /// </summary>
        [Fact]
        public void GetKey_DifferentComponentIds_ShouldProduceDifferentKeys()
        {
            GameObjectType archetype = new GameObjectType(2);

            uint key1 = FastLookup.GetKey(1, archetype);
            uint key2 = FastLookup.GetKey(2, archetype);

            Assert.NotEqual(key1, key2);
        }

        /// <summary>
        ///     Tests that GetKey produces unique keys for different archetypes
        /// </summary>
        [Fact]
        public void GetKey_DifferentArchetypes_ShouldProduceDifferentKeys()
        {
            ushort componentId = 5;

            uint key1 = FastLookup.GetKey(componentId, new GameObjectType(0));
            uint key2 = FastLookup.GetKey(componentId, new GameObjectType(1));

            Assert.NotEqual(key1, key2);
        }

        /// <summary>
        ///     Tests that LookupIndex returns 0 for matching first entry
        /// </summary>
        [Fact]
        public void LookupIndex_WhenFirstEntryMatches_ShouldReturnZero()
        {
            FastLookup fastLookup = new FastLookup();
            fastLookup._data._0 = 42;

            int result = fastLookup.LookupIndex(42);

            Assert.Equal(0, result);
        }

        /// <summary>
        ///     Tests that LookupIndex returns 32 for non-matching key
        /// </summary>
        [Fact]
        public void LookupIndex_WhenNoEntryMatches_ShouldReturn32()
        {
            FastLookup fastLookup = new FastLookup();
            fastLookup._data._0 = 42;
            fastLookup._data._1 = 43;

            int result = fastLookup.LookupIndex(99);

            Assert.Equal(32, result);
        }

        /// <summary>
        ///     Tests that LookupIndex returns correct index for second entry
        /// </summary>
        [Fact]
        public void LookupIndex_WhenSecondEntryMatches_ShouldReturnOne()
        {
            FastLookup fastLookup = new FastLookup();
            fastLookup._data._1 = 42;

            int result = fastLookup.LookupIndex(42);

            Assert.Equal(1, result);
        }

        /// <summary>
        ///     Tests that LookupIndex returns correct index for third entry
        /// </summary>
        [Fact]
        public void LookupIndex_WhenThirdEntryMatches_ShouldReturnTwo()
        {
            FastLookup fastLookup = new FastLookup();
            fastLookup._data._2 = 42;

            int result = fastLookup.LookupIndex(42);

            Assert.Equal(2, result);
        }

        /// <summary>
        ///     Tests that LookupIndex returns correct index for fourth entry
        /// </summary>
        [Fact]
        public void LookupIndex_WhenFourthEntryMatches_ShouldReturnThree()
        {
            FastLookup fastLookup = new FastLookup();
            fastLookup._data._3 = 42;

            int result = fastLookup.LookupIndex(42);

            Assert.Equal(3, result);
        }

        /// <summary>
        ///     Tests that LookupIndex returns correct index for fifth entry
        /// </summary>
        [Fact]
        public void LookupIndex_WhenFifthEntryMatches_ShouldReturnFour()
        {
            FastLookup fastLookup = new FastLookup();
            fastLookup._data._4 = 42;

            int result = fastLookup.LookupIndex(42);

            Assert.Equal(4, result);
        }

        /// <summary>
        ///     Tests that LookupIndex returns correct index for sixth entry
        /// </summary>
        [Fact]
        public void LookupIndex_WhenSixthEntryMatches_ShouldReturnFive()
        {
            FastLookup fastLookup = new FastLookup();
            fastLookup._data._5 = 42;

            int result = fastLookup.LookupIndex(42);

            Assert.Equal(5, result);
        }

        /// <summary>
        ///     Tests that LookupIndex returns correct index for seventh entry
        /// </summary>
        [Fact]
        public void LookupIndex_WhenSeventhEntryMatches_ShouldReturnSix()
        {
            FastLookup fastLookup = new FastLookup();
            fastLookup._data._6 = 42;

            int result = fastLookup.LookupIndex(42);

            Assert.Equal(6, result);
        }

        /// <summary>
        ///     Tests that LookupIndex returns correct index for eighth entry
        /// </summary>
        [Fact]
        public void LookupIndex_WhenEighthEntryMatches_ShouldReturnSeven()
        {
            FastLookup fastLookup = new FastLookup();
            fastLookup._data._7 = 42;

            int result = fastLookup.LookupIndex(42);

            Assert.Equal(7, result);
        }

        /// <summary>
        ///     Tests that LookupIndex returns 32 when all entries are different
        /// </summary>
        [Fact]
        public void LookupIndex_WhenAllEntriesDifferent_ShouldReturn32()
        {
            FastLookup fastLookup = new FastLookup();
            fastLookup._data._0 = 1;
            fastLookup._data._1 = 2;
            fastLookup._data._2 = 3;
            fastLookup._data._3 = 4;
            fastLookup._data._4 = 5;
            fastLookup._data._5 = 6;
            fastLookup._data._6 = 7;
            fastLookup._data._7 = 8;

            int result = fastLookup.LookupIndex(99);

            Assert.Equal(32, result);
        }

        /// <summary>
        ///     Tests that the struct initializes with default values
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithDefaults()
        {
            FastLookup fastLookup = new FastLookup();

            Assert.NotNull(fastLookup.Archetypes);
            Assert.Equal(8, fastLookup.Archetypes.Length);
        }
    }
}
