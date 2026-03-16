// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NeighborCacheAllAritiesTest.cs
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

using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Ensures every NeighborCache arity (1..8) modifies component sets correctly.
    /// </summary>
    public class NeighborCacheAllAritiesTest
    {
        /// <summary>
        ///     Creates the components using the specified ids
        /// </summary>
        /// <param name="ids">The ids</param>
        /// <returns>A fast immutable array of component id</returns>
        private static FastImmutableArray<ComponentId> CreateComponents(params ComponentId[] ids)
        {
            FastImmutableArray<ComponentId>.Builder builder = FastImmutableArray<ComponentId>.CreateBuilder<ComponentId>(ids.Length);
            foreach (ComponentId id in ids)
            {
                builder.Add(id);
            }

            return builder.ToImmutable();
        }

        /// <summary>
        ///     Asserts the contains all using the specified components
        /// </summary>
        /// <param name="components">The components</param>
        /// <param name="expectedIds">The expected ids</param>
        private static void AssertContainsAll(FastImmutableArray<ComponentId> components, params ComponentId[] expectedIds)
        {
            foreach (ComponentId id in expectedIds)
            {
                Assert.Contains(id, components);
            }
        }

        /// <summary>
        ///     Tests that neighbor cache arity 1 add and remove modifies expected components
        /// </summary>
        [Fact]
        public void NeighborCacheArity1_AddAndRemove_ModifiesExpectedComponents()
        {
            NeighborCache<Position> cache = default(NeighborCache<Position>);
            FastImmutableArray<ComponentId> components = FastImmutableArray<ComponentId>.Empty;

            cache.ModifyComponents(ref components, true);

            Assert.Equal(1, components.Length);
            AssertContainsAll(components, Component<Position>.Id);

            components = CreateComponents(Component<Position>.Id, Component<AnotherComponent2>.Id);
            cache.ModifyComponents(ref components, false);

            Assert.Equal(1, components.Length);
            AssertContainsAll(components, Component<AnotherComponent2>.Id);
        }

        /// <summary>
        ///     Tests that neighbor cache arity 2 add and remove modifies expected components
        /// </summary>
        [Fact]
        public void NeighborCacheArity2_AddAndRemove_ModifiesExpectedComponents()
        {
            NeighborCache<Position, Velocity> cache = default(NeighborCache<Position, Velocity>);
            FastImmutableArray<ComponentId> components = FastImmutableArray<ComponentId>.Empty;

            cache.ModifyComponents(ref components, true);

            Assert.Equal(2, components.Length);
            AssertContainsAll(components, Component<Position>.Id, Component<Velocity>.Id);

            components = CreateComponents(Component<Position>.Id, Component<Velocity>.Id, Component<AnotherComponent2>.Id);
            cache.ModifyComponents(ref components, false);

            Assert.Equal(1, components.Length);
            AssertContainsAll(components, Component<AnotherComponent2>.Id);
        }

        /// <summary>
        ///     Tests that neighbor cache arity 3 add and remove modifies expected components
        /// </summary>
        [Fact]
        public void NeighborCacheArity3_AddAndRemove_ModifiesExpectedComponents()
        {
            NeighborCache<Position, Velocity, Health> cache = default(NeighborCache<Position, Velocity, Health>);
            FastImmutableArray<ComponentId> components = FastImmutableArray<ComponentId>.Empty;

            cache.ModifyComponents(ref components, true);

            Assert.Equal(3, components.Length);
            AssertContainsAll(components, Component<Position>.Id, Component<Velocity>.Id, Component<Health>.Id);

            components = CreateComponents(Component<Position>.Id, Component<Velocity>.Id, Component<Health>.Id, Component<AnotherComponent2>.Id);
            cache.ModifyComponents(ref components, false);

            Assert.Equal(1, components.Length);
            AssertContainsAll(components, Component<AnotherComponent2>.Id);
        }

        /// <summary>
        ///     Tests that neighbor cache arity 4 add and remove modifies expected components
        /// </summary>
        [Fact]
        public void NeighborCacheArity4_AddAndRemove_ModifiesExpectedComponents()
        {
            NeighborCache<Position, Velocity, Health, Armor> cache = default(NeighborCache<Position, Velocity, Health, Armor>);
            FastImmutableArray<ComponentId> components = FastImmutableArray<ComponentId>.Empty;

            cache.ModifyComponents(ref components, true);

            Assert.Equal(4, components.Length);
            AssertContainsAll(components, Component<Position>.Id, Component<Velocity>.Id, Component<Health>.Id, Component<Armor>.Id);

            components = CreateComponents(Component<Position>.Id, Component<Velocity>.Id, Component<Health>.Id, Component<Armor>.Id, Component<AnotherComponent2>.Id);
            cache.ModifyComponents(ref components, false);

            Assert.Equal(1, components.Length);
            AssertContainsAll(components, Component<AnotherComponent2>.Id);
        }

        /// <summary>
        ///     Tests that neighbor cache arity 5 add and remove modifies expected components
        /// </summary>
        [Fact]
        public void NeighborCacheArity5_AddAndRemove_ModifiesExpectedComponents()
        {
            NeighborCache<Position, Velocity, Health, Armor, Damage> cache = default(NeighborCache<Position, Velocity, Health, Armor, Damage>);
            FastImmutableArray<ComponentId> components = FastImmutableArray<ComponentId>.Empty;

            cache.ModifyComponents(ref components, true);

            Assert.Equal(5, components.Length);
            AssertContainsAll(components, Component<Position>.Id, Component<Velocity>.Id, Component<Health>.Id, Component<Armor>.Id, Component<Damage>.Id);

            components = CreateComponents(Component<Position>.Id, Component<Velocity>.Id, Component<Health>.Id, Component<Armor>.Id, Component<Damage>.Id, Component<AnotherComponent2>.Id);
            cache.ModifyComponents(ref components, false);

            Assert.Equal(1, components.Length);
            AssertContainsAll(components, Component<AnotherComponent2>.Id);
        }

        /// <summary>
        ///     Tests that neighbor cache arity 6 add and remove modifies expected components
        /// </summary>
        [Fact]
        public void NeighborCacheArity6_AddAndRemove_ModifiesExpectedComponents()
        {
            NeighborCache<Position, Velocity, Health, Armor, Damage, TestComponent> cache = default(NeighborCache<Position, Velocity, Health, Armor, Damage, TestComponent>);
            FastImmutableArray<ComponentId> components = FastImmutableArray<ComponentId>.Empty;

            cache.ModifyComponents(ref components, true);

            Assert.Equal(6, components.Length);
            AssertContainsAll(components, Component<Position>.Id, Component<Velocity>.Id, Component<Health>.Id, Component<Armor>.Id, Component<Damage>.Id, Component<TestComponent>.Id);

            components = CreateComponents(Component<Position>.Id, Component<Velocity>.Id, Component<Health>.Id, Component<Armor>.Id, Component<Damage>.Id, Component<TestComponent>.Id, Component<AnotherComponent2>.Id);
            cache.ModifyComponents(ref components, false);

            Assert.Equal(1, components.Length);
            AssertContainsAll(components, Component<AnotherComponent2>.Id);
        }

        /// <summary>
        ///     Tests that neighbor cache arity 7 add and remove modifies expected components
        /// </summary>
        [Fact]
        public void NeighborCacheArity7_AddAndRemove_ModifiesExpectedComponents()
        {
            NeighborCache<Position, Velocity, Health, Armor, Damage, TestComponent, TestComponent2> cache = default(NeighborCache<Position, Velocity, Health, Armor, Damage, TestComponent, TestComponent2>);
            FastImmutableArray<ComponentId> components = FastImmutableArray<ComponentId>.Empty;

            cache.ModifyComponents(ref components, true);

            Assert.Equal(7, components.Length);
            AssertContainsAll(components, Component<Position>.Id, Component<Velocity>.Id, Component<Health>.Id, Component<Armor>.Id, Component<Damage>.Id, Component<TestComponent>.Id, Component<TestComponent2>.Id);

            components = CreateComponents(Component<Position>.Id, Component<Velocity>.Id, Component<Health>.Id, Component<Armor>.Id, Component<Damage>.Id, Component<TestComponent>.Id, Component<TestComponent2>.Id, Component<AnotherComponent2>.Id);
            cache.ModifyComponents(ref components, false);

            Assert.Equal(1, components.Length);
            AssertContainsAll(components, Component<AnotherComponent2>.Id);
        }

        /// <summary>
        ///     Tests that neighbor cache arity 8 add and remove modifies expected components
        /// </summary>
        [Fact]
        public void NeighborCacheArity8_AddAndRemove_ModifiesExpectedComponents()
        {
            NeighborCache<Position, Velocity, Health, Armor, Damage, TestComponent, TestComponent2, AnotherComponent> cache = default(NeighborCache<Position, Velocity, Health, Armor, Damage, TestComponent, TestComponent2, AnotherComponent>);
            FastImmutableArray<ComponentId> components = FastImmutableArray<ComponentId>.Empty;

            cache.ModifyComponents(ref components, true);

            Assert.Equal(8, components.Length);
            AssertContainsAll(components, Component<Position>.Id, Component<Velocity>.Id, Component<Health>.Id, Component<Armor>.Id, Component<Damage>.Id, Component<TestComponent>.Id, Component<TestComponent2>.Id, Component<AnotherComponent>.Id);

            components = CreateComponents(Component<Position>.Id, Component<Velocity>.Id, Component<Health>.Id, Component<Armor>.Id, Component<Damage>.Id, Component<TestComponent>.Id, Component<TestComponent2>.Id, Component<AnotherComponent>.Id, Component<AnotherComponent2>.Id);
            cache.ModifyComponents(ref components, false);

            Assert.Equal(1, components.Length);
            AssertContainsAll(components, Component<AnotherComponent2>.Id);
        }
    }
}