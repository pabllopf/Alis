using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Archetypes
{
    /// <summary>
    /// The archetype data test class
    /// </summary>
    public class ArchetypeDataTest
    {
        /// <summary>
        /// Tests that constructor should set id and component types
        /// </summary>
        [Fact]
        public void Constructor_ShouldSetIdAndComponentTypes()
        {
            GameObjectType id = new GameObjectType(1);

            FastImmutableArray<ComponentId>.Builder builder = FastImmutableArray<ComponentId>.CreateBuilder<ComponentId>(2);
            builder.Add(new ComponentId(10));
            builder.Add(new ComponentId(20));
            FastImmutableArray<ComponentId> types = builder.ToImmutable();

            ArchetypeData data = new ArchetypeData(id, types);

            Assert.Equal(id, data.Id);
            Assert.Equal(2, data.ComponentTypes.Length);
        }

        /// <summary>
        /// Tests that constructor with empty types should set empty component types
        /// </summary>
        [Fact]
        public void Constructor_WithEmptyTypes_ShouldSetEmptyComponentTypes()
        {
            GameObjectType id = new GameObjectType(5);
            FastImmutableArray<ComponentId> types = FastImmutableArray<ComponentId>.Empty;

            ArchetypeData data = new ArchetypeData(id, types);

            Assert.Equal(id, data.Id);
            Assert.Equal(0, data.ComponentTypes.Length);
        }

        /// <summary>
        /// Tests that deconstruct should return id and component types
        /// </summary>
        [Fact]
        public void Deconstruct_ShouldReturnIdAndComponentTypes()
        {
            GameObjectType id = new GameObjectType(3);
            FastImmutableArray<ComponentId> types = FastImmutableArray<ComponentId>.Empty;

            ArchetypeData data = new ArchetypeData(id, types);
            (GameObjectType deconstructedId, FastImmutableArray<ComponentId> deconstructedTypes) = data;

            Assert.Equal(id, deconstructedId);
            Assert.Equal(types.Length, deconstructedTypes.Length);
        }

        /// <summary>
        /// Tests that equals same values should be equal
        /// </summary>
        [Fact]
        public void Equals_SameValues_ShouldBeEqual()
        {
            GameObjectType id = new GameObjectType(1);
            FastImmutableArray<ComponentId> types = FastImmutableArray<ComponentId>.Empty;

            ArchetypeData data1 = new ArchetypeData(id, types);
            ArchetypeData data2 = new ArchetypeData(id, types);

            Assert.True(data1.Equals(data2));
        }

        /// <summary>
        /// Tests that equals different id should not be equal
        /// </summary>
        [Fact]
        public void Equals_DifferentId_ShouldNotBeEqual()
        {
            GameObjectType id1 = new GameObjectType(1);
            GameObjectType id2 = new GameObjectType(2);
            FastImmutableArray<ComponentId> types = FastImmutableArray<ComponentId>.Empty;

            ArchetypeData data1 = new ArchetypeData(id1, types);
            ArchetypeData data2 = new ArchetypeData(id2, types);

            Assert.False(data1.Equals(data2));
        }
    }
}
