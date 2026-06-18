// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastLookupLookupIndexTest.cs
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
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     Tests for <see cref="FastLookup.LookupIndex" /> covering all inline array slots.
    /// </summary>
    public class FastLookupLookupIndexTest
    {
        /// <summary>
        ///     Tests that LookupIndex finds a key stored at slot 0.
        /// </summary>
        [Fact]
        public void LookupIndex_WithKeyInSlot0_Returns0()
        {
            FastLookup lookup = new FastLookup();
            InlineArray8<uint>.Get(ref lookup._data, 0) = 42;

            int result = lookup.LookupIndex(42);

            Assert.Equal(0, result);
        }

        /// <summary>
        ///     Tests that LookupIndex finds a key stored at slot 1.
        /// </summary>
        [Fact]
        public void LookupIndex_WithKeyInSlot1_Returns1()
        {
            FastLookup lookup = new FastLookup();
            InlineArray8<uint>.Get(ref lookup._data, 1) = 42;

            int result = lookup.LookupIndex(42);

            Assert.Equal(1, result);
        }

        /// <summary>
        ///     Tests that LookupIndex finds a key stored at slot 2.
        /// </summary>
        [Fact]
        public void LookupIndex_WithKeyInSlot2_Returns2()
        {
            FastLookup lookup = new FastLookup();
            InlineArray8<uint>.Get(ref lookup._data, 2) = 42;

            int result = lookup.LookupIndex(42);

            Assert.Equal(2, result);
        }

        /// <summary>
        ///     Tests that LookupIndex finds a key stored at slot 3.
        /// </summary>
        [Fact]
        public void LookupIndex_WithKeyInSlot3_Returns3()
        {
            FastLookup lookup = new FastLookup();
            InlineArray8<uint>.Get(ref lookup._data, 3) = 42;

            int result = lookup.LookupIndex(42);

            Assert.Equal(3, result);
        }

        /// <summary>
        ///     Tests that LookupIndex finds a key stored at slot 4.
        /// </summary>
        [Fact]
        public void LookupIndex_WithKeyInSlot4_Returns4()
        {
            FastLookup lookup = new FastLookup();
            InlineArray8<uint>.Get(ref lookup._data, 4) = 42;

            int result = lookup.LookupIndex(42);

            Assert.Equal(4, result);
        }

        /// <summary>
        ///     Tests that LookupIndex finds a key stored at slot 5.
        /// </summary>
        [Fact]
        public void LookupIndex_WithKeyInSlot5_Returns5()
        {
            FastLookup lookup = new FastLookup();
            InlineArray8<uint>.Get(ref lookup._data, 5) = 42;

            int result = lookup.LookupIndex(42);

            Assert.Equal(5, result);
        }

        /// <summary>
        ///     Tests that LookupIndex finds a key stored at slot 6.
        /// </summary>
        [Fact]
        public void LookupIndex_WithKeyInSlot6_Returns6()
        {
            FastLookup lookup = new FastLookup();
            InlineArray8<uint>.Get(ref lookup._data, 6) = 42;

            int result = lookup.LookupIndex(42);

            Assert.Equal(6, result);
        }

        /// <summary>
        ///     Tests that LookupIndex finds a key stored at slot 7.
        /// </summary>
        [Fact]
        public void LookupIndex_WithKeyInSlot7_Returns7()
        {
            FastLookup lookup = new FastLookup();
            InlineArray8<uint>.Get(ref lookup._data, 7) = 42;

            int result = lookup.LookupIndex(42);

            Assert.Equal(7, result);
        }

        /// <summary>
        ///     Tests that LookupIndex prefers the earliest match when multiple slots have the same key.
        /// </summary>
        [Fact]
        public void LookupIndex_WithDuplicateKey_ReturnsEarliestSlot()
        {
            FastLookup lookup = new FastLookup();
            InlineArray8<uint>.Get(ref lookup._data, 3) = 42;
            InlineArray8<uint>.Get(ref lookup._data, 0) = 42;

            int result = lookup.LookupIndex(42);

            Assert.Equal(0, result);
        }
    }
}
