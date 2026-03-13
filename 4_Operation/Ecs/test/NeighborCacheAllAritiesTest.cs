using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    /// Ensures every NeighborCache arity (1..8) modifies component sets correctly.
    /// </summary>
    public class NeighborCacheAllAritiesTest
    {
        private static FastImmutableArray<ComponentId> CreateComponents(params ComponentId[] ids)
        {
            FastImmutableArray<ComponentId>.Builder builder = FastImmutableArray<ComponentId>.CreateBuilder<ComponentId>(ids.Length);
            foreach (ComponentId id in ids)
            {
                builder.Add(id);
            }

            return builder.ToImmutable();
        }

        private static void AssertContainsAll(FastImmutableArray<ComponentId> components, params ComponentId[] expectedIds)
        {
            foreach (ComponentId id in expectedIds)
            {
                Assert.Contains(id, components);
            }
        }

        [Fact]
        public void NeighborCacheArity1_AddAndRemove_ModifiesExpectedComponents()
        {
            NeighborCache<Position> cache = default;
            FastImmutableArray<ComponentId> components = FastImmutableArray<ComponentId>.Empty;

            cache.ModifyComponents(ref components, add: true);

            Assert.Equal(1, components.Length);
            AssertContainsAll(components, Component<Position>.Id);

            components = CreateComponents(Component<Position>.Id, Component<AnotherComponent2>.Id);
            cache.ModifyComponents(ref components, add: false);

            Assert.Equal(1, components.Length);
            AssertContainsAll(components, Component<AnotherComponent2>.Id);
        }

        [Fact]
        public void NeighborCacheArity2_AddAndRemove_ModifiesExpectedComponents()
        {
            NeighborCache<Position, Velocity> cache = default;
            FastImmutableArray<ComponentId> components = FastImmutableArray<ComponentId>.Empty;

            cache.ModifyComponents(ref components, add: true);

            Assert.Equal(2, components.Length);
            AssertContainsAll(components, Component<Position>.Id, Component<Velocity>.Id);

            components = CreateComponents(Component<Position>.Id, Component<Velocity>.Id, Component<AnotherComponent2>.Id);
            cache.ModifyComponents(ref components, add: false);

            Assert.Equal(1, components.Length);
            AssertContainsAll(components, Component<AnotherComponent2>.Id);
        }

        [Fact]
        public void NeighborCacheArity3_AddAndRemove_ModifiesExpectedComponents()
        {
            NeighborCache<Position, Velocity, Health> cache = default;
            FastImmutableArray<ComponentId> components = FastImmutableArray<ComponentId>.Empty;

            cache.ModifyComponents(ref components, add: true);

            Assert.Equal(3, components.Length);
            AssertContainsAll(components, Component<Position>.Id, Component<Velocity>.Id, Component<Health>.Id);

            components = CreateComponents(Component<Position>.Id, Component<Velocity>.Id, Component<Health>.Id, Component<AnotherComponent2>.Id);
            cache.ModifyComponents(ref components, add: false);

            Assert.Equal(1, components.Length);
            AssertContainsAll(components, Component<AnotherComponent2>.Id);
        }

        [Fact]
        public void NeighborCacheArity4_AddAndRemove_ModifiesExpectedComponents()
        {
            NeighborCache<Position, Velocity, Health, Armor> cache = default;
            FastImmutableArray<ComponentId> components = FastImmutableArray<ComponentId>.Empty;

            cache.ModifyComponents(ref components, add: true);

            Assert.Equal(4, components.Length);
            AssertContainsAll(components, Component<Position>.Id, Component<Velocity>.Id, Component<Health>.Id, Component<Armor>.Id);

            components = CreateComponents(Component<Position>.Id, Component<Velocity>.Id, Component<Health>.Id, Component<Armor>.Id, Component<AnotherComponent2>.Id);
            cache.ModifyComponents(ref components, add: false);

            Assert.Equal(1, components.Length);
            AssertContainsAll(components, Component<AnotherComponent2>.Id);
        }

        [Fact]
        public void NeighborCacheArity5_AddAndRemove_ModifiesExpectedComponents()
        {
            NeighborCache<Position, Velocity, Health, Armor, Damage> cache = default;
            FastImmutableArray<ComponentId> components = FastImmutableArray<ComponentId>.Empty;

            cache.ModifyComponents(ref components, add: true);

            Assert.Equal(5, components.Length);
            AssertContainsAll(components, Component<Position>.Id, Component<Velocity>.Id, Component<Health>.Id, Component<Armor>.Id, Component<Damage>.Id);

            components = CreateComponents(Component<Position>.Id, Component<Velocity>.Id, Component<Health>.Id, Component<Armor>.Id, Component<Damage>.Id, Component<AnotherComponent2>.Id);
            cache.ModifyComponents(ref components, add: false);

            Assert.Equal(1, components.Length);
            AssertContainsAll(components, Component<AnotherComponent2>.Id);
        }

        [Fact]
        public void NeighborCacheArity6_AddAndRemove_ModifiesExpectedComponents()
        {
            NeighborCache<Position, Velocity, Health, Armor, Damage, TestComponent> cache = default;
            FastImmutableArray<ComponentId> components = FastImmutableArray<ComponentId>.Empty;

            cache.ModifyComponents(ref components, add: true);

            Assert.Equal(6, components.Length);
            AssertContainsAll(components, Component<Position>.Id, Component<Velocity>.Id, Component<Health>.Id, Component<Armor>.Id, Component<Damage>.Id, Component<TestComponent>.Id);

            components = CreateComponents(Component<Position>.Id, Component<Velocity>.Id, Component<Health>.Id, Component<Armor>.Id, Component<Damage>.Id, Component<TestComponent>.Id, Component<AnotherComponent2>.Id);
            cache.ModifyComponents(ref components, add: false);

            Assert.Equal(1, components.Length);
            AssertContainsAll(components, Component<AnotherComponent2>.Id);
        }

        [Fact]
        public void NeighborCacheArity7_AddAndRemove_ModifiesExpectedComponents()
        {
            NeighborCache<Position, Velocity, Health, Armor, Damage, TestComponent, TestComponent2> cache = default;
            FastImmutableArray<ComponentId> components = FastImmutableArray<ComponentId>.Empty;

            cache.ModifyComponents(ref components, add: true);

            Assert.Equal(7, components.Length);
            AssertContainsAll(components, Component<Position>.Id, Component<Velocity>.Id, Component<Health>.Id, Component<Armor>.Id, Component<Damage>.Id, Component<TestComponent>.Id, Component<TestComponent2>.Id);

            components = CreateComponents(Component<Position>.Id, Component<Velocity>.Id, Component<Health>.Id, Component<Armor>.Id, Component<Damage>.Id, Component<TestComponent>.Id, Component<TestComponent2>.Id, Component<AnotherComponent2>.Id);
            cache.ModifyComponents(ref components, add: false);

            Assert.Equal(1, components.Length);
            AssertContainsAll(components, Component<AnotherComponent2>.Id);
        }

        [Fact]
        public void NeighborCacheArity8_AddAndRemove_ModifiesExpectedComponents()
        {
            NeighborCache<Position, Velocity, Health, Armor, Damage, TestComponent, TestComponent2, AnotherComponent> cache = default;
            FastImmutableArray<ComponentId> components = FastImmutableArray<ComponentId>.Empty;

            cache.ModifyComponents(ref components, add: true);

            Assert.Equal(8, components.Length);
            AssertContainsAll(components, Component<Position>.Id, Component<Velocity>.Id, Component<Health>.Id, Component<Armor>.Id, Component<Damage>.Id, Component<TestComponent>.Id, Component<TestComponent2>.Id, Component<AnotherComponent>.Id);

            components = CreateComponents(Component<Position>.Id, Component<Velocity>.Id, Component<Health>.Id, Component<Armor>.Id, Component<Damage>.Id, Component<TestComponent>.Id, Component<TestComponent2>.Id, Component<AnotherComponent>.Id, Component<AnotherComponent2>.Id);
            cache.ModifyComponents(ref components, add: false);

            Assert.Equal(1, components.Length);
            AssertContainsAll(components, Component<AnotherComponent2>.Id);
        }
    }
}

