

using Alis.Core.Ecs.Kernel.Archetypes;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Tests the <see cref="WorldArchetypeTableItem" /> struct.
    /// </summary>
    public class WorldArchetypeTableItemTest
    {
        /// <summary>
        ///     Tests that constructor initializes archetype correctly.
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeArchetype()
        {
            Scene world = new Scene();
            Archetype archetype = world.DefaultArchetype;
            Archetype temp = world.DefaultArchetype;

            WorldArchetypeTableItem item = new WorldArchetypeTableItem(archetype, temp);

            Assert.Equal(archetype, item.Archetype);

            world.Dispose();
        }

        /// <summary>
        ///     Tests that constructor initializes deferred creation archetype correctly.
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeDeferredCreationArchetype()
        {
            Scene world = new Scene();
            Archetype archetype = world.DefaultArchetype;
            Archetype temp = world.DefaultArchetype;

            WorldArchetypeTableItem item = new WorldArchetypeTableItem(archetype, temp);

            Assert.Equal(temp, item.DeferredCreationArchetype);

            world.Dispose();
        }

        /// <summary>
        ///     Tests that archetype can be modified after construction.
        /// </summary>
        [Fact]
        public void Archetype_CanBeModified_AfterConstruction()
        {
            Scene world = new Scene();
            Archetype archetype1 = world.DefaultArchetype;
            Archetype archetype2 = world.DefaultArchetype;
            Archetype temp = world.DefaultArchetype;
            WorldArchetypeTableItem item = new WorldArchetypeTableItem(archetype1, temp);

            item.Archetype = archetype2;

            Assert.Equal(archetype2, item.Archetype);

            world.Dispose();
        }

        /// <summary>
        ///     Tests that deferred creation archetype can be modified after construction.
        /// </summary>
        [Fact]
        public void DeferredCreationArchetype_CanBeModified_AfterConstruction()
        {
            Scene world = new Scene();
            Archetype archetype = world.DefaultArchetype;
            Archetype temp1 = world.DefaultArchetype;
            Archetype temp2 = world.DefaultArchetype;
            WorldArchetypeTableItem item = new WorldArchetypeTableItem(archetype, temp1);

            item.DeferredCreationArchetype = temp2;

            Assert.Equal(temp2, item.DeferredCreationArchetype);

            world.Dispose();
        }

        /// <summary>
        ///     Tests that both archetypes can be the same instance.
        /// </summary>
        [Fact]
        public void BothArchetypes_CanBeTheSameInstance()
        {
            Scene world = new Scene();
            Archetype archetype = world.DefaultArchetype;

            WorldArchetypeTableItem item = new WorldArchetypeTableItem(archetype, archetype);

            Assert.Equal(archetype, item.Archetype);
            Assert.Equal(archetype, item.DeferredCreationArchetype);
            Assert.Same(item.Archetype, item.DeferredCreationArchetype);

            world.Dispose();
        }

        /// <summary>
        ///     Tests that multiple instances maintain separate data.
        /// </summary>
        [Fact]
        public void MultipleInstances_ShouldMaintainSeparateData()
        {
            Scene world = new Scene();
            Archetype archetype1 = world.DefaultArchetype;
            Archetype archetype2 = world.DefaultArchetype;
            Archetype temp1 = world.DefaultArchetype;
            Archetype temp2 = world.DefaultArchetype;

            WorldArchetypeTableItem item1 = new WorldArchetypeTableItem(archetype1, temp1);
            WorldArchetypeTableItem item2 = new WorldArchetypeTableItem(archetype2, temp2);

            Assert.Equal(archetype1, item1.Archetype);
            Assert.Equal(temp1, item1.DeferredCreationArchetype);
            Assert.Equal(archetype2, item2.Archetype);
            Assert.Equal(temp2, item2.DeferredCreationArchetype);

            world.Dispose();
        }

        /// <summary>
        ///     Tests that constructor with archetypes stores them correctly.
        /// </summary>
        [Fact]
        public void Constructor_WithArchetypes_ShouldStoreCorrectly()
        {
            Scene world = new Scene();
            Archetype archetype = world.DefaultArchetype;
            Archetype temp = world.DefaultArchetype;

            WorldArchetypeTableItem item = new WorldArchetypeTableItem(archetype, temp);

            Assert.NotNull(item.Archetype);
            Assert.NotNull(item.DeferredCreationArchetype);

            world.Dispose();
        }
    }
}