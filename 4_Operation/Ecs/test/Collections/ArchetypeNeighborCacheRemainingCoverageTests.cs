// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ArchetypeNeighborCacheRemainingCoverageTests.cs
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
using Alis.Core.Ecs.Kernel.Archetypes;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     Remaining coverage tests for <see cref="ArchetypeNeighborCache" />.
    /// </summary>
    public class ArchetypeNeighborCacheRemainingCoverageTests
    {
        /// <summary>
        ///     Verifies that a newly created cache has all keys zero, all values zero, and _nextIndex is zero.
        /// </summary>
        [Fact]
        public void DefaultState_AllSlotsEmpty_NextIndexZero()
        {
            ArchetypeNeighborCache cache = default;

            Assert.Equal(32, cache.Traverse(42));
            Assert.Equal(0, cache.Lookup(0));
            Assert.Equal(0, cache.Lookup(1));
            Assert.Equal(0, cache.Lookup(2));
            Assert.Equal(0, cache.Lookup(3));
        }

        /// <summary>
        ///     Verifies that Set followed by Traverse returns the correct slot index.
        /// </summary>
        [Fact]
        public void Set_ThenTraverse_ReturnsSlotIndex()
        {
            ArchetypeNeighborCache cache = default;
            cache.Set(1, 100);

            int slot = cache.Traverse(1);

            Assert.Equal(0, slot);
        }

        /// <summary>
        ///     Verifies that Traverse returns 32 when the key is not present.
        /// </summary>
        [Fact]
        public void Traverse_MissingKey_Returns32()
        {
            ArchetypeNeighborCache cache = default;
            cache.Set(1, 100);

            int slot = cache.Traverse(999);

            Assert.Equal(32, slot);
        }

        /// <summary>
        ///     Verifies that Lookup returns the stored value for a given slot index.
        /// </summary>
        [Fact]
        public void Set_ThenLookup_ReturnsStoredValue()
        {
            ArchetypeNeighborCache cache = default;
            cache.Set(1, 100);

            ushort value = cache.Lookup(0);

            Assert.Equal(100, value);
        }

        /// <summary>
        ///     Verifies that four sets fill all slots and the fifth set wraps to slot 0 (round-robin eviction).
        /// </summary>
        [Fact]
        public void RoundRobinEviction_FiveSets_WrapsToSlotZero()
        {
            ArchetypeNeighborCache cache = default;

            cache.Set(10, 100);
            cache.Set(20, 200);
            cache.Set(30, 300);
            cache.Set(40, 400);
            cache.Set(50, 500);

            Assert.Equal(32, cache.Traverse(10));
            Assert.Equal(0, cache.Traverse(50));
        }

        /// <summary>
        ///     Verifies that after round-robin eviction an older key is gone and a newer key is found.
        /// </summary>
        [Fact]
        public void TraverseAfterEviction_OldKeyEvicted_NewKeyFound()
        {
            ArchetypeNeighborCache cache = default;

            cache.Set(10, 100);
            cache.Set(20, 200);
            cache.Set(30, 300);
            cache.Set(40, 400);
            cache.Set(50, 500);

            int oldSlot = cache.Traverse(10);
            int newSlot = cache.Traverse(50);

            Assert.Equal(32, oldSlot);
            Assert.Equal(0, newSlot);
        }

        /// <summary>
        ///     Verifies that setting into the same slot via round-robin overwrites the previous entry.
        /// </summary>
        [Fact]
        public void MultipleSetOverwrite_SameSlot_Overwrites()
        {
            ArchetypeNeighborCache cache = default;

            cache.Set(1, 100);
            cache.Set(2, 200);
            cache.Set(3, 300);
            cache.Set(4, 400);
            cache.Set(5, 500);

            Assert.Equal(32, cache.Traverse(1));
            Assert.Equal(0, cache.Traverse(5));
            Assert.Equal(500, cache.Lookup(0));
        }

        /// <summary>
        ///     Verifies that Lookup returns correct values for all four slot indices.
        /// </summary>
        [Fact]
        public void Lookup_AllFourSlots_ReturnsCorrectValues()
        {
            ArchetypeNeighborCache cache = default;

            cache.Set(10, 100);
            cache.Set(20, 200);
            cache.Set(30, 300);
            cache.Set(40, 400);

            Assert.Equal(100, cache.Lookup(0));
            Assert.Equal(200, cache.Lookup(1));
            Assert.Equal(300, cache.Lookup(2));
            Assert.Equal(400, cache.Lookup(3));
        }

        /// <summary>
        ///     Verifies that each of the four slots can be hit via Traverse.
        /// </summary>
        [Fact]
        public void Traverse_AllFourSlots_EachSlotHittable()
        {
            ArchetypeNeighborCache cache = default;

            cache.Set(10, 100);
            cache.Set(20, 200);
            cache.Set(30, 300);
            cache.Set(40, 400);

            Assert.Equal(0, cache.Traverse(10));
            Assert.Equal(1, cache.Traverse(20));
            Assert.Equal(2, cache.Traverse(30));
            Assert.Equal(3, cache.Traverse(40));
        }

        /// <summary>
        ///     Verifies that TraverseArchetype returns null when keys were stored via the ushort-only overload.
        /// </summary>
        [Fact]
        public void TraverseArchetype_AfterUshortSet_ReturnsNull()
        {
            ArchetypeNeighborCache cache = default;

            cache.Set(1, 100);

            Archetype result = cache.TraverseArchetype(1);

            Assert.Null(result);
        }
    }
}
