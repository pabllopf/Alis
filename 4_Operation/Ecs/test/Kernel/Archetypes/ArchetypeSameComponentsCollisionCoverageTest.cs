// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ArchetypeSameComponentsCollisionCoverageTest.cs
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
using Alis.Core.Ecs.Kernel.Archetypes;
using HashCode = Alis.Core.Aspect.Math.HashCode;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Archetypes
{
    /// <summary>
    ///     Covers the value-comparison guard used by <see cref="Archetype" /> when it looks up an
    ///     existing archetype by its 64-bit hash key. These tests build genuine hash collisions at
    ///     runtime (using the very same public <see cref="HashCode" /> implementation that
    ///     <c>Archetype.GetHash</c> uses) so that a stale or collided <c>ExistingArchetypes</c> entry
    ///     with a different component set is rejected instead of being returned.
    /// </summary>
    public class ArchetypeSameComponentsCollisionCoverageTest
    {
        /// <summary>
        ///     The number of distinct component ids used as the search domain.
        /// </summary>
        private const int DomainSize = 32;

        /// <summary>
        ///     Gets a block of valid component ids used as the collision search domain.
        ///     Every id is guaranteed to be a registered component id, so it is always a
        ///     valid component table index.
        /// </summary>
        private static readonly ComponentId[] Domain =
        {
            Component<D00>.Id, Component<D01>.Id, Component<D02>.Id, Component<D03>.Id,
            Component<D04>.Id, Component<D05>.Id, Component<D06>.Id, Component<D07>.Id,
            Component<D08>.Id, Component<D09>.Id, Component<D10>.Id, Component<D11>.Id,
            Component<D12>.Id, Component<D13>.Id, Component<D14>.Id, Component<D15>.Id,
            Component<D16>.Id, Component<D17>.Id, Component<D18>.Id, Component<D19>.Id,
            Component<D20>.Id, Component<D21>.Id, Component<D22>.Id, Component<D23>.Id,
            Component<D24>.Id, Component<D25>.Id, Component<D26>.Id, Component<D27>.Id,
            Component<D28>.Id, Component<D29>.Id, Component<D30>.Id, Component<D31>.Id
        };

        /// <summary>
        ///     When an existing archetype shares the same hash key but a different number of
        ///     components, the value-comparison guard must reject it and a new archetype must be
        ///     created instead of returning the mismatching one.
        /// </summary>
        [Fact]
        public void GetArchetypeId_WhenStoredAndRequestedLengthsDiffer_ReturnsDistinctArchetype()
        {
            // Arrange: build two colliding component layouts of different lengths.
            bool found = TryFindDifferentLengthCollision(out ComponentId[] shorter, out ComponentId[] longer);
            Assert.True(found, "Expected to discover a different-length archetype hash collision in the search domain.");

            // Act
            GameObjectType shorterId = Archetype.GetArchetypeId(shorter.AsSpan());
            GameObjectType longerId = Archetype.GetArchetypeId(longer.AsSpan());

            // Assert: the guard rejects the length-mismatched entry, so the two layouts map to
            // different archetypes even though their hash keys are identical.
            Assert.NotEqual(shorterId.RawIndex, longerId.RawIndex);
            Assert.Equal(shorter.Length + 1, longer.Length);

            // The freshly created longer archetype must be stable and cached on its own.
            GameObjectType longerIdAgain = Archetype.GetArchetypeId(longer.AsSpan());
            Assert.Equal(longerId.RawIndex, longerIdAgain.RawIndex);
            Assert.NotEqual(shorterId.RawIndex, longerIdAgain.RawIndex);
        }

        /// <summary>
        ///     When an existing archetype shares the same hash key and the same length but holds
        ///     different components, the value-comparison guard must reject it element-wise and a new
        ///     archetype must be created instead of returning the mismatching one.
        /// </summary>
        [Fact]
        public void GetArchetypeId_WhenStoredAndRequestedComponentsDiffer_ReturnsDistinctArchetype()
        {
            // Arrange: build two colliding component layouts of equal length with different elements.
            bool found = TryFindSameLengthCollision(out ComponentId[] first, out ComponentId[] second);
            Assert.True(found, "Expected to discover a same-length archetype hash collision in the search domain.");

            // Act
            GameObjectType firstId = Archetype.GetArchetypeId(first.AsSpan());
            GameObjectType secondId = Archetype.GetArchetypeId(second.AsSpan());

            // Assert: the guard rejects the element-wise mismatch, so the two layouts map to
            // different archetypes even though their hash keys are identical.
            Assert.NotEqual(firstId.RawIndex, secondId.RawIndex);

            // The freshly created second archetype must be stable and cached on its own.
            GameObjectType secondIdAgain = Archetype.GetArchetypeId(second.AsSpan());
            Assert.Equal(secondId.RawIndex, secondIdAgain.RawIndex);
            Assert.NotEqual(firstId.RawIndex, secondIdAgain.RawIndex);
        }

        /// <summary>
        ///     Searches for two distinct component sequences with different total lengths that
        ///     produce the same 64-bit archetype hash key. The first halves are identical, so the
        ///     key can only differ through the second half, where a length-4 hash must equal a
        ///     length-5 hash.
        /// </summary>
        private static bool TryFindDifferentLengthCollision(out ComponentId[] shorter, out ComponentId[] longer)
        {
            const int halfLength = 4;
            ComponentId[] firstHalf = FirstHalf(halfLength);

            Dictionary<int, int> fourHash = new Dictionary<int, int>();
            for (int a = 0; a < DomainSize; a++)
            for (int b = 0; b < DomainSize; b++)
            for (int c = 0; c < DomainSize; c++)
            for (int d = 0; d < DomainSize; d++)
            {
                int h = HashElements(Domain[a], Domain[b], Domain[c], Domain[d]);
                fourHash[h] = a;
            }

            for (int e0 = 0; e0 < DomainSize; e0++)
            for (int e1 = 0; e1 < DomainSize; e1++)
            for (int e2 = 0; e2 < DomainSize; e2++)
            for (int e3 = 0; e3 < DomainSize; e3++)
            for (int e4 = 0; e4 < DomainSize; e4++)
            {
                ComponentId[] secondHalf = {Domain[e0], Domain[e1], Domain[e2], Domain[e3], Domain[e4]};
                if (fourHash.ContainsKey(HashElements(secondHalf)))
                {
                    // Recover the matching four-element tuple by scanning (cheap, once).
                    for (int a = 0; a < DomainSize; a++)
                    for (int b = 0; b < DomainSize; b++)
                    for (int c = 0; c < DomainSize; c++)
                    for (int d = 0; d < DomainSize; d++)
                    {
                        if (HashElements(Domain[a], Domain[b], Domain[c], Domain[d]) == HashElements(secondHalf))
                        {
                            shorter = Concat(firstHalf, Domain[a], Domain[b], Domain[c], Domain[d]);
                            longer = Concat(firstHalf, Domain[e0], Domain[e1], Domain[e2], Domain[e3], Domain[e4]);
                            return true;
                        }
                    }
                }
            }

            shorter = null;
            longer = null;
            return false;
        }

        /// <summary>
        ///     Searches for two distinct component sequences of equal total length that produce the
        ///     same 64-bit archetype hash key. Both use the same first half, so the second halves
        ///     only need to be two distinct length-4 sequences that share a hash.
        /// </summary>
        private static bool TryFindSameLengthCollision(out ComponentId[] first, out ComponentId[] second)
        {
            const int halfLength = 4;
            ComponentId[] firstHalf = FirstHalf(halfLength);

            Dictionary<int, int> seen = new Dictionary<int, int>();
            for (int a = 0; a < DomainSize; a++)
            for (int b = 0; b < DomainSize; b++)
            for (int c = 0; c < DomainSize; c++)
            for (int d = 0; d < DomainSize; d++)
            {
                int h = HashElements(Domain[a], Domain[b], Domain[c], Domain[d]);
                if (seen.TryGetValue(h, out int previousPacked))
                {
                    int pa = previousPacked / (DomainSize * DomainSize * DomainSize);
                    int pb = previousPacked / (DomainSize * DomainSize) % DomainSize;
                    int pc = previousPacked / DomainSize % DomainSize;
                    int pd = previousPacked % DomainSize;

                    first = Concat(firstHalf, Domain[pa], Domain[pb], Domain[pc], Domain[pd]);
                    second = Concat(firstHalf, Domain[a], Domain[b], Domain[c], Domain[d]);
                    return true;
                }

                seen[h] = ((a * DomainSize + b) * DomainSize + c) * DomainSize + d;
            }

            first = null;
            second = null;
            return false;
        }

        /// <summary>
        ///     Builds the shared first half from the first elements of the domain.
        /// </summary>
        private static ComponentId[] FirstHalf(int length)
        {
            ComponentId[] half = new ComponentId[length];
            for (int i = 0; i < length; i++)
            {
                half[i] = Domain[i];
            }

            return half;
        }

        /// <summary>
        ///     Concatenates the shared prefix with the supplied ids to form a full component layout.
        /// </summary>
        private static ComponentId[] Concat(ComponentId[] prefix, params ComponentId[] suffix)
        {
            ComponentId[] result = new ComponentId[prefix.Length + suffix.Length];
            prefix.CopyTo(result, 0);
            suffix.CopyTo(result, prefix.Length);
            return result;
        }

        /// <summary>
        ///     Computes the hash of a component sequence exactly like <c>Archetype.GetHash</c> does
        ///     for a single half of a layout.
        /// </summary>
        private static int HashElements(params ComponentId[] elements)
        {
            HashCode hash = new HashCode();
            for (int i = 0; i < elements.Length; i++)
            {
                hash.Add(elements[i]);
            }

            return hash.ToHashCode();
        }

        private struct D00
        {
        }

        private struct D01
        {
        }

        private struct D02
        {
        }

        private struct D03
        {
        }

        private struct D04
        {
        }

        private struct D05
        {
        }

        private struct D06
        {
        }

        private struct D07
        {
        }

        private struct D08
        {
        }

        private struct D09
        {
        }

        private struct D10
        {
        }

        private struct D11
        {
        }

        private struct D12
        {
        }

        private struct D13
        {
        }

        private struct D14
        {
        }

        private struct D15
        {
        }

        private struct D16
        {
        }

        private struct D17
        {
        }

        private struct D18
        {
        }

        private struct D19
        {
        }

        private struct D20
        {
        }

        private struct D21
        {
        }

        private struct D22
        {
        }

        private struct D23
        {
        }

        private struct D24
        {
        }

        private struct D25
        {
        }

        private struct D26
        {
        }

        private struct D27
        {
        }

        private struct D28
        {
        }

        private struct D29
        {
        }

        private struct D30
        {
        }

        private struct D31
        {
        }
    }
}
