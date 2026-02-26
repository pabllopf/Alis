// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ArchetypeDeferredUpdateRecordTest.cs
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

using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating
{
    /// <summary>
    ///     The archetype deferred update record test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="ArchetypeDeferredUpdateRecord"/> record struct which stores
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
            // Act
            ArchetypeDeferredUpdateRecord record = new ArchetypeDeferredUpdateRecord(null, null, 10);

            // Assert
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
            // Arrange
            int entityCount = 42;

            // Act
            ArchetypeDeferredUpdateRecord record = new ArchetypeDeferredUpdateRecord(null, null, entityCount);

            // Assert
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
            // Act
            ArchetypeDeferredUpdateRecord record = new ArchetypeDeferredUpdateRecord(null, null, 0);

            // Assert
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
            // Act
            ArchetypeDeferredUpdateRecord record = new ArchetypeDeferredUpdateRecord(null, null, -1);

            // Assert
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
            // Act
            ArchetypeDeferredUpdateRecord record1 = new ArchetypeDeferredUpdateRecord(null, null, 10);
            ArchetypeDeferredUpdateRecord record2 = new ArchetypeDeferredUpdateRecord(null, null, 10);

            // Assert
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
            // Act
            ArchetypeDeferredUpdateRecord record1 = new ArchetypeDeferredUpdateRecord(null, null, 10);
            ArchetypeDeferredUpdateRecord record2 = new ArchetypeDeferredUpdateRecord(null, null, 20);

            // Assert
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
            // Act
            ArchetypeDeferredUpdateRecord record = new ArchetypeDeferredUpdateRecord(null, null, 10);

            // Assert
            Assert.Null(record.Archetype);
            Assert.Null(record.TemporaryBuffers);
        }
    }
}

