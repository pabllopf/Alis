

using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating
{
    /// <summary>
    ///     The archetype deferred update record test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="ArchetypeDeferredUpdateRecord" /> record struct which stores
    ///     information about deferred archetype updates (original archetype, temporary buffers, entity count).
    /// </remarks>
    public class ArchetypeDeferredUpdateRecordTest
    {
        /// <summary>
        ///     Tests that archetype deferred update record can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that ArchetypeDeferredUpdateRecord can be instantiated.
        /// </remarks>
        [Fact]
        public void ArchetypeDeferredUpdateRecord_CanBeCreated()
        {
            ArchetypeDeferredUpdateRecord record = new ArchetypeDeferredUpdateRecord(null, null, 10);

            Assert.NotNull(record);
        }

        /// <summary>
        ///     Tests that archetype deferred update record fields are preserved
        /// </summary>
        /// <remarks>
        ///     Validates that all fields are correctly stored.
        /// </remarks>
        [Fact]
        public void ArchetypeDeferredUpdateRecord_FieldsArePreserved()
        {
            int entityCount = 42;

            ArchetypeDeferredUpdateRecord record = new ArchetypeDeferredUpdateRecord(null, null, entityCount);

            Assert.Equal(entityCount, record.InitEntityCount);
        }

        /// <summary>
        ///     Tests that archetype deferred update record with zero entity count
        /// </summary>
        /// <remarks>
        ///     Tests creation with zero initial entity count.
        /// </remarks>
        [Fact]
        public void ArchetypeDeferredUpdateRecord_WithZeroEntityCount()
        {
            ArchetypeDeferredUpdateRecord record = new ArchetypeDeferredUpdateRecord(null, null, 0);

            Assert.Equal(0, record.InitEntityCount);
        }

        /// <summary>
        ///     Tests that archetype deferred update record with negative entity count
        /// </summary>
        /// <remarks>
        ///     Tests creation with negative entity count.
        /// </remarks>
        [Fact]
        public void ArchetypeDeferredUpdateRecord_WithNegativeEntityCount()
        {
            ArchetypeDeferredUpdateRecord record = new ArchetypeDeferredUpdateRecord(null, null, -1);

            Assert.Equal(-1, record.InitEntityCount);
        }

        /// <summary>
        ///     Tests that archetype deferred update record is record struct
        /// </summary>
        /// <remarks>
        ///     Confirms that ArchetypeDeferredUpdateRecord is a record struct.
        /// </remarks>
        [Fact]
        public void ArchetypeDeferredUpdateRecord_IsRecordStruct()
        {
            ArchetypeDeferredUpdateRecord record1 = new ArchetypeDeferredUpdateRecord(null, null, 10);
            ArchetypeDeferredUpdateRecord record2 = new ArchetypeDeferredUpdateRecord(null, null, 10);

            Assert.Equal(record1, record2);
        }

        /// <summary>
        ///     Tests that archetype deferred update record with different counts are not equal
        /// </summary>
        /// <remarks>
        ///     Validates that records with different entity counts are not equal.
        /// </remarks>
        [Fact]
        public void ArchetypeDeferredUpdateRecord_WithDifferentCountsAreNotEqual()
        {
            ArchetypeDeferredUpdateRecord record1 = new ArchetypeDeferredUpdateRecord(null, null, 10);
            ArchetypeDeferredUpdateRecord record2 = new ArchetypeDeferredUpdateRecord(null, null, 20);

            Assert.NotEqual(record1, record2);
        }

        /// <summary>
        ///     Tests that archetype deferred update record can store null archetypes
        /// </summary>
        /// <remarks>
        ///     Validates that null archetype references can be stored.
        /// </remarks>
        [Fact]
        public void ArchetypeDeferredUpdateRecord_CanStoreNullArchetypes()
        {
            ArchetypeDeferredUpdateRecord record = new ArchetypeDeferredUpdateRecord(null, null, 10);

            Assert.Null(record.Archetype);
            Assert.Null(record.TemporaryBuffers);
        }
    }
}