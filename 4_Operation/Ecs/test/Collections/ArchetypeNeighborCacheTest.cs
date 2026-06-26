// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ArchetypeNeighborCacheTest.cs
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
    ///     Tests the <see cref="ArchetypeNeighborCache" /> struct — a 4-way set-associative cache
    ///     mapping source archetype IDs to destination archetypes.
    /// </summary>
    public partial class ArchetypeNeighborCacheTest
    {
        /// <summary>
        ///     Tests that <see cref="ArchetypeNeighborCache.Traverse" /> returns the slot index when the key is in slot 0
        /// </summary>
        [Fact]
        public void Traverse_FindsKeyInSlot0()
        {
            var cache = new ArchetypeNeighborCache();
            cache.Set(10, 100);
            Assert.Equal(0, cache.Traverse(10));
        }

        /// <summary>
        ///     Tests that <see cref="ArchetypeNeighborCache.Traverse" /> returns the slot index when the key is in slot 1
        /// </summary>
        [Fact]
        public void Traverse_FindsKeyInSlot1()
        {
            var cache = new ArchetypeNeighborCache();
            cache.Set(10, 100);
            cache.Set(20, 200);
            Assert.Equal(1, cache.Traverse(20));
        }

        /// <summary>
        ///     Tests that <see cref="ArchetypeNeighborCache.Traverse" /> returns the slot index when the key is in slot 2
        /// </summary>
        [Fact]
        public void Traverse_FindsKeyInSlot2()
        {
            var cache = new ArchetypeNeighborCache();
            cache.Set(10, 100);
            cache.Set(20, 200);
            cache.Set(30, 300);
            Assert.Equal(2, cache.Traverse(30));
        }

        /// <summary>
        ///     Tests that <see cref="ArchetypeNeighborCache.Traverse" /> returns the slot index when the key is in slot 3
        /// </summary>
        [Fact]
        public void Traverse_FindsKeyInSlot3()
        {
            var cache = new ArchetypeNeighborCache();
            cache.Set(10, 100);
            cache.Set(20, 200);
            cache.Set(30, 300);
            cache.Set(40, 400);
            Assert.Equal(3, cache.Traverse(40));
        }

        /// <summary>
        ///     Tests that <see cref="ArchetypeNeighborCache.Traverse" /> returns 32 when the key is not present
        /// </summary>
        [Fact]
        public void Traverse_Returns32_OnMiss()
        {
            var cache = new ArchetypeNeighborCache();
            Assert.Equal(32, cache.Traverse(99));
        }

        /// <summary>
        ///     Tests that <see cref="ArchetypeNeighborCache.Traverse" /> returns 32 after a full set of different keys
        /// </summary>
        [Fact]
        public void Traverse_Returns32_WhenKeyNotCached()
        {
            var cache = new ArchetypeNeighborCache();
            cache.Set(1, 10);
            cache.Set(2, 20);
            cache.Set(3, 30);
            cache.Set(4, 40);
            Assert.Equal(32, cache.Traverse(99));
        }

        /// <summary>
        ///     Tests that <see cref="ArchetypeNeighborCache.TraverseArchetype" /> returns null on miss
        /// </summary>
        [Fact]
        public void TraverseArchetype_ReturnsNull_OnMiss()
        {
            var cache = new ArchetypeNeighborCache();
            Assert.Null(cache.TraverseArchetype(99));
        }

        /// <summary>
        ///     Tests that <see cref="ArchetypeNeighborCache.Lookup" /> returns the value stored at each slot
        /// </summary>
        [Fact]
        public void Lookup_ReturnsValue_ForEachSlot()
        {
            var cache = new ArchetypeNeighborCache();
            cache.Set(1, 100);
            cache.Set(2, 200);
            cache.Set(3, 300);
            cache.Set(4, 400);

            Assert.Equal(100, cache.Lookup(0));
            Assert.Equal(200, cache.Lookup(1));
            Assert.Equal(300, cache.Lookup(2));
            Assert.Equal(400, cache.Lookup(3));
        }

        /// <summary>
        ///     Tests that <see cref="ArchetypeNeighborCache.Set(ushort, ushort)" /> stores ushort values in round-robin order
        /// </summary>
        [Fact]
        public void Set_RoundRobin_StoresInSequentialSlots()
        {
            var cache = new ArchetypeNeighborCache();

            cache.Set(1, 10);
            Assert.Equal(10, cache.Lookup(0));

            cache.Set(2, 20);
            Assert.Equal(20, cache.Lookup(1));

            cache.Set(3, 30);
            Assert.Equal(30, cache.Lookup(2));

            cache.Set(4, 40);
            Assert.Equal(40, cache.Lookup(3));
        }
        

        /// <summary>
        ///     Tests that <see cref="ArchetypeNeighborCache.Set(ushort, ushort)" /> can wrap multiple times
        /// </summary>
        [Fact]
        public void Set_RoundRobin_WrapsMultipleTimes()
        {
            var cache = new ArchetypeNeighborCache();
            for (int i = 0; i < 8; i++)
            {
                cache.Set((ushort)(i + 1), (ushort)((i + 1) * 10));
            }

            Assert.Equal((ushort)50, cache.Lookup(0));
            Assert.Equal((ushort)60, cache.Lookup(1));
            Assert.Equal((ushort)70, cache.Lookup(2));
            Assert.Equal((ushort)80, cache.Lookup(3));
        }


        /// <summary>
        ///     Tests that <see cref="ArchetypeNeighborCache.Set(ushort, Archetype)" /> stores null Archetype reference in the
        ///     ushort-only overload
        /// </summary>
        [Fact]
        public void Set_UshortOnly_SetsNullArchetype()
        {
            var cache = new ArchetypeNeighborCache();
            cache.Set(10, 100);
            Assert.Null(cache.TraverseArchetype(10));
        }

       
       

        /// <summary>
        ///     Tests that <see cref="ArchetypeNeighborCache" /> can handle all ushort key values
        /// </summary>
        [Fact]
        public void Traverse_WorksWithUshortMaxValueKey()
        {
            var cache = new ArchetypeNeighborCache();
            cache.Set(ushort.MaxValue, 1);
            Assert.Equal(0, cache.Traverse(ushort.MaxValue));
        }

        /// <summary>
        ///     Tests that <see cref="ArchetypeNeighborCache" /> can handle zero as a key
        /// </summary>
        [Fact]
        public void Traverse_WorksWithZeroKey()
        {
            var cache = new ArchetypeNeighborCache();
            cache.Set(0, 100);
            Assert.Equal(0, cache.Traverse(0));
        }

        /// <summary>
        ///     Tests that <see cref="ArchetypeNeighborCache" /> can hold different values for the same key overwritten in
        ///     different round-robin passes
        /// </summary>
        [Fact]
        public void Set_SameKey_UpdatesValueAndSlot()
        {
            var cache = new ArchetypeNeighborCache();
            cache.Set(1, 100);
            Assert.Equal(100, cache.Lookup(0));

            cache.Set(2, 200);
            cache.Set(3, 300);
            cache.Set(4, 400);

            // Re-insert key 1 — slot 0 is overwritten
            cache.Set(1, 999);
            Assert.Equal(999, cache.Lookup(0));
            Assert.Equal(0, cache.Traverse(1));
        }
    }
}
