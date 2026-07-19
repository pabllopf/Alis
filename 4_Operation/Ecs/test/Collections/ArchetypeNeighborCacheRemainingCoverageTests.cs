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
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     Coverage for remaining uncovered paths in <see cref="ArchetypeNeighborCache" />.
    /// </summary>
    public class ArchetypeNeighborCacheRemainingCoverageTests
    {
        [Fact]
        public void Traverse_Empty_Returns32()
        {
            ArchetypeNeighborCache cache = default;
            Assert.Equal(32, cache.Traverse(42));
        }

        [Fact]
        public void Traverse_FindsKeyInSlot0()
        {
            ArchetypeNeighborCache cache = default;
            cache.Set(10, (ushort)100);
            Assert.Equal(0, cache.Traverse(10));
        }

        [Fact]
        public void Traverse_FindsKeyInSlot1()
        {
            ArchetypeNeighborCache cache = default;
            cache.Set(10, 100);
            cache.Set(20, 200);
            Assert.Equal(1, cache.Traverse(20));
        }

        [Fact]
        public void Traverse_FindsKeyInSlot2()
        {
            ArchetypeNeighborCache cache = default;
            cache.Set(10, 100);
            cache.Set(20, 200);
            cache.Set(30, 300);
            Assert.Equal(2, cache.Traverse(30));
        }

        [Fact]
        public void Traverse_FindsKeyInSlot3()
        {
            ArchetypeNeighborCache cache = default;
            cache.Set(10, 100);
            cache.Set(20, 200);
            cache.Set(30, 300);
            cache.Set(40, 400);
            Assert.Equal(3, cache.Traverse(40));
        }

        [Fact]
        public void Traverse_Miss_Returns32()
        {
            ArchetypeNeighborCache cache = default;
            cache.Set(10, 100);
            cache.Set(20, 200);
            cache.Set(30, 300);
            cache.Set(40, 400);
            Assert.Equal(32, cache.Traverse(99));
        }

        [Fact]
        public void TraverseArchetype_Empty_ReturnsNull()
        {
            ArchetypeNeighborCache cache = default;
            Assert.Null(cache.TraverseArchetype(42));
        }

        [Fact]
        public void TraverseArchetype_Miss_ReturnsNull()
        {
            ArchetypeNeighborCache cache = default;
            cache.Set(10, (ushort)100);
            Assert.Null(cache.TraverseArchetype(99));
        }

        [Fact]
        public void Lookup_ReturnsValuesForAllSlots()
        {
            ArchetypeNeighborCache cache = default;
            cache.Set(10, 100);
            cache.Set(20, 200);
            cache.Set(30, 300);
            cache.Set(40, 400);
            Assert.Equal((ushort)100, cache.Lookup(0));
            Assert.Equal((ushort)200, cache.Lookup(1));
            Assert.Equal((ushort)300, cache.Lookup(2));
            Assert.Equal((ushort)400, cache.Lookup(3));
        }

        [Fact]
        public void Lookup_IndexOutOfRange_ReturnsSlot3()
        {
            ArchetypeNeighborCache cache = default;
            cache.Set(10, 100);
            cache.Set(20, 200);
            cache.Set(30, 300);
            cache.Set(40, 400);
            Assert.Equal((ushort)400, cache.Lookup(42));
        }

        [Fact]
        public void Set_UshortOnly_SetsNullArchetype()
        {
            ArchetypeNeighborCache cache = default;
            cache.Set(10, (ushort)100);
            Assert.Null(cache.TraverseArchetype(10));
        }

        [Fact]
        public void RoundRobin_WrapsAround()
        {
            ArchetypeNeighborCache cache = default;
            for (int i = 0; i < 8; i++)
            {
                cache.Set((ushort)(i + 1), (ushort)((i + 1) * 10));
            }
            Assert.Equal((ushort)50, cache.Lookup(0));
            Assert.Equal((ushort)60, cache.Lookup(1));
            Assert.Equal((ushort)70, cache.Lookup(2));
            Assert.Equal((ushort)80, cache.Lookup(3));
        }

        [Fact]
        public void RoundRobin_EvictsOldEntries()
        {
            ArchetypeNeighborCache cache = default;
            cache.Set(1, 10);
            cache.Set(2, 20);
            cache.Set(3, 30);
            cache.Set(4, 40);
            cache.Set(5, 50);
            Assert.Equal(0, cache.Traverse(5));
            Assert.Equal(32, cache.Traverse(1));
        }

        [Fact]
        public void WorksWithZeroKey()
        {
            ArchetypeNeighborCache cache = default;
            cache.Set(0, (ushort)100);
            Assert.Equal(0, cache.Traverse(0));
            Assert.Equal((ushort)100, cache.Lookup(0));
        }

        [Fact]
        public void WorksWithMaxKey()
        {
            ArchetypeNeighborCache cache = default;
            cache.Set(ushort.MaxValue, (ushort)1);
            Assert.Equal(0, cache.Traverse(ushort.MaxValue));
        }

        [Fact]
        public void SameKeyOverwritesSlot()
        {
            ArchetypeNeighborCache cache = default;
            cache.Set(1, 100);
            cache.Set(2, 200);
            cache.Set(3, 300);
            cache.Set(4, 400);
            cache.Set(1, 999);
            Assert.Equal(999, cache.Lookup(0));
            Assert.Equal(0, cache.Traverse(1));
        }
    }
}
