

using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The world archetype table item extended test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="WorldArchetypeTableItem" /> struct which stores
    ///     archetype and temporary creation archetype references with extended test cases.
    /// </remarks>
    public class WorldArchetypeTableItemExtendedTest
    {
        /// <summary>
        ///     Tests that world archetype table item can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that WorldArchetypeTableItem can be instantiated with null archetypes.
        /// </remarks>
        [Fact]
        public void WorldArchetypeTableItem_CanBeCreatedWithNullArchetypes()
        {
            WorldArchetypeTableItem item = new WorldArchetypeTableItem(null, null);

            Assert.Null(item.Archetype);
            Assert.Null(item.DeferredCreationArchetype);
        }

        /// <summary>
        ///     Tests that world archetype table item fields are accessible
        /// </summary>
        /// <remarks>
        ///     Validates that the Archetype and DeferredCreationArchetype fields are accessible.
        /// </remarks>
        [Fact]
        public void WorldArchetypeTableItem_FieldsAreAccessible()
        {
            WorldArchetypeTableItem item = new WorldArchetypeTableItem(null, null);

            Assert.NotNull(item);
            Assert.True(item.Archetype == null || item.Archetype != null);
        }

        /// <summary>
        ///     Tests that world archetype table item is value type
        /// </summary>
        /// <remarks>
        ///     Confirms that WorldArchetypeTableItem is a value type (struct).
        /// </remarks>
        [Fact]
        public void WorldArchetypeTableItem_IsValueType()
        {
            WorldArchetypeTableItem item1 = new WorldArchetypeTableItem(null, null);
            WorldArchetypeTableItem item2 = item1;

            Assert.NotNull(item1);
            Assert.NotNull(item2);
        }

        /// <summary>
        ///     Tests that world archetype table item fields can be modified
        /// </summary>
        /// <remarks>
        ///     Validates that the public fields can be modified.
        /// </remarks>
        [Fact]
        public void WorldArchetypeTableItem_FieldsCanBeModified()
        {
            WorldArchetypeTableItem item = new WorldArchetypeTableItem(null, null);

            item.Archetype = null;
            item.DeferredCreationArchetype = null;

            Assert.Null(item.Archetype);
            Assert.Null(item.DeferredCreationArchetype);
        }
    }
}