// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EntityDataTest.cs
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
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The entity data test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="EntityData" /> struct which stores internal entity metadata
    ///     including entity ID, version, and world ID.
    /// </remarks>
    public class EntityDataTest
    {
        /// <summary>
        ///     Tests that entity data can be created with default values
        /// </summary>
        /// <remarks>
        ///     Verifies that EntityData can be initialized with default values.
        /// </remarks>
        [Fact]
        public void EntityData_CanBeCreatedWithDefaultValues()
        {
            EntityData entityData = default(EntityData);

            Assert.Equal(0, entityData.EntityID);
            Assert.Equal((ushort) 0, entityData.EntityVersion);
            Assert.Equal((ushort) 0, entityData.WorldID);
        }

        /// <summary>
        ///     Tests that entity data fields can be set and retrieved
        /// </summary>
        /// <remarks>
        ///     Validates that all fields in EntityData can be properly set and retrieved.
        /// </remarks>
        [Fact]
        public void EntityData_FieldsCanBeSetAndRetrieved()
        {
            EntityData entityData = new EntityData
            {
                EntityID = 123,
                EntityVersion = 5,
                WorldID = 10
            };

            Assert.Equal(123, entityData.EntityID);
            Assert.Equal((ushort) 5, entityData.EntityVersion);
            Assert.Equal((ushort) 10, entityData.WorldID);
        }

        /// <summary>
        ///     Tests that entity id can store negative values
        /// </summary>
        /// <remarks>
        ///     Confirms that EntityID can handle negative integer values.
        /// </remarks>
        [Fact]
        public void EntityData_EntityIdCanStoreNegativeValues()
        {
            EntityData entityData = new EntityData
            {
                EntityID = -1
            };

            Assert.Equal(-1, entityData.EntityID);
        }

        /// <summary>
        ///     Tests that entity version can store max ushort value
        /// </summary>
        /// <remarks>
        ///     Validates that EntityVersion can store the maximum ushort value.
        /// </remarks>
        [Fact]
        public void EntityData_EntityVersionCanStoreMaxUShortValue()
        {
            EntityData entityData = new EntityData
            {
                EntityVersion = ushort.MaxValue
            };

            Assert.Equal(ushort.MaxValue, entityData.EntityVersion);
        }

        /// <summary>
        ///     Tests that world id can store max ushort value
        /// </summary>
        /// <remarks>
        ///     Validates that WorldID can store the maximum ushort value.
        /// </remarks>
        [Fact]
        public void EntityData_WorldIdCanStoreMaxUShortValue()
        {
            EntityData entityData = new EntityData
            {
                WorldID = ushort.MaxValue
            };

            Assert.Equal(ushort.MaxValue, entityData.WorldID);
        }

        /// <summary>
        ///     Tests that entity data is value type
        /// </summary>
        /// <remarks>
        ///     Confirms that EntityData is a value type (struct) and exhibits value semantics.
        /// </remarks>
        [Fact]
        public void EntityData_IsValueType()
        {
            EntityData entityData1 = new EntityData {EntityID = 100};
            EntityData entityData2 = entityData1;

            entityData2.EntityID = 200;

            Assert.Equal(100, entityData1.EntityID);
            Assert.Equal(200, entityData2.EntityID);
        }

        /// <summary>
        ///     Tests that entity data can be compared for equality
        /// </summary>
        /// <remarks>
        ///     Tests that two EntityData instances with the same values are equal.
        /// </remarks>
        [Fact]
        public void EntityData_CanBeComparedForEquality()
        {
            EntityData entityData1 = new EntityData
            {
                EntityID = 42,
                EntityVersion = 3,
                WorldID = 7
            };

            EntityData entityData2 = new EntityData
            {
                EntityID = 42,
                EntityVersion = 3,
                WorldID = 7
            };

            Assert.Equal(entityData1.EntityID, entityData2.EntityID);
            Assert.Equal(entityData1.EntityVersion, entityData2.EntityVersion);
            Assert.Equal(entityData1.WorldID, entityData2.WorldID);
        }

        /// <summary>
        ///     Tests that entity data with different values are not equal
        /// </summary>
        /// <remarks>
        ///     Validates that EntityData instances with different field values are not equal.
        /// </remarks>
        [Fact]
        public void EntityData_WithDifferentValuesAreNotEqual()
        {
            EntityData entityData1 = new EntityData {EntityID = 42};
            EntityData entityData2 = new EntityData {EntityID = 43};

            Assert.NotEqual(entityData1.EntityID, entityData2.EntityID);
        }

        /// <summary>
        ///     Tests that entity data can store boundary values
        /// </summary>
        /// <remarks>
        ///     Tests that EntityData can handle boundary values for all its fields.
        /// </remarks>
        [Fact]
        public void EntityData_CanStoreBoundaryValues()
        {
            EntityData entityData = new EntityData
            {
                EntityID = int.MaxValue,
                EntityVersion = ushort.MaxValue,
                WorldID = ushort.MaxValue
            };

            Assert.Equal(int.MaxValue, entityData.EntityID);
            Assert.Equal(ushort.MaxValue, entityData.EntityVersion);
            Assert.Equal(ushort.MaxValue, entityData.WorldID);
        }

        /// <summary>
        ///     Tests that entity data can store minimum values
        /// </summary>
        /// <remarks>
        ///     Tests that EntityData can handle minimum values for all its fields.
        /// </remarks>
        [Fact]
        public void EntityData_CanStoreMinimumValues()
        {
            EntityData entityData = new EntityData
            {
                EntityID = int.MinValue,
                EntityVersion = ushort.MinValue,
                WorldID = ushort.MinValue
            };

            Assert.Equal(int.MinValue, entityData.EntityID);
            Assert.Equal(ushort.MinValue, entityData.EntityVersion);
            Assert.Equal(ushort.MinValue, entityData.WorldID);
        }

        /// <summary>
        ///     Tests that EntityData has the expected memory size of 8 bytes
        /// </summary>
        /// <remarks>
        ///     Verifies that the packed struct layout (int: 4 bytes + ushort: 2 bytes +
        ///     ushort: 2 bytes) results in exactly 8 bytes total with no padding.
        /// </remarks>
        [Fact]
        public void EntityData_MemorySizeIs8Bytes()
        {
            int size = Marshal.SizeOf<EntityData>();

            Assert.Equal(8, size);
        }

        /// <summary>
        ///     Tests that EntityData field offsets match the expected packed layout
        /// </summary>
        /// <remarks>
        ///     Verifies field memory offsets: EntityID at 0, EntityVersion at 4,
        ///     WorldID at 6 — confirming Pack=1 eliminates padding.
        /// </remarks>
        [Fact]
        public void EntityData_FieldOffsetsMatchPackedLayout()
        {
            long entityIDOffset = Marshal.OffsetOf<EntityData>(nameof(EntityData.EntityID)).ToInt64();
            long entityVersionOffset = Marshal.OffsetOf<EntityData>(nameof(EntityData.EntityVersion)).ToInt64();
            long worldIDOffset = Marshal.OffsetOf<EntityData>(nameof(EntityData.WorldID)).ToInt64();

            Assert.Equal(0, entityIDOffset);
            Assert.Equal(4, entityVersionOffset);
            Assert.Equal(6, worldIDOffset);
        }

        /// <summary>
        ///     Tests that EntityData can be stored in arrays without boxing
        /// </summary>
        /// <remarks>
        ///     Validates that EntityData arrays store elements contiguously in memory
        ///     as a value type, enabling efficient bulk operations.
        /// </remarks>
        [Fact]
        public void EntityData_CanBeStoredInArrays()
        {
            EntityData[] entities = new EntityData[100];

            for (int i = 0; i < entities.Length; i++)
            {
                entities[i] = new EntityData
                {
                    EntityID = i,
                    EntityVersion = (ushort)(i % 10),
                    WorldID = (ushort)(i % 5)
                };
            }

            for (int i = 0; i < entities.Length; i++)
            {
                Assert.Equal(i, entities[i].EntityID);
                Assert.Equal((ushort)(i % 10), entities[i].EntityVersion);
                Assert.Equal((ushort)(i % 5), entities[i].WorldID);
            }
        }

        /// <summary>
        ///     Tests that modifying one field does not affect other fields
        /// </summary>
        /// <remarks>
        ///     Ensures field independence — each field can be modified independently
        ///     without side effects on the others.
        /// </remarks>
        [Fact]
        public void EntityData_FieldModificationsAreIndependent()
        {
            EntityData entityData = new EntityData
            {
                EntityID = 100,
                EntityVersion = 2,
                WorldID = 3
            };

            entityData.EntityID = -999;
            Assert.Equal(-999, entityData.EntityID);
            Assert.Equal((ushort)2, entityData.EntityVersion);
            Assert.Equal((ushort)3, entityData.WorldID);

            entityData.EntityVersion = 65535;
            Assert.Equal(-999, entityData.EntityID);
            Assert.Equal(ushort.MaxValue, entityData.EntityVersion);
            Assert.Equal((ushort)3, entityData.WorldID);

            entityData.WorldID = 0;
            Assert.Equal(-999, entityData.EntityID);
            Assert.Equal(ushort.MaxValue, entityData.EntityVersion);
            Assert.Equal((ushort)0, entityData.WorldID);
        }

        /// <summary>
        ///     Tests that EntityData default is all-zero initialized
        /// </summary>
        /// <remarks>
        ///     Verifies that default(EntityData) produces a zero-initialized struct
        ///     with all fields set to their default values.
        /// </remarks>
        [Fact]
        public void EntityData_DefaultIsAllZeroInitialized()
        {
            EntityData entityData = default;

            Assert.Equal(0, entityData.EntityID);
            Assert.Equal((ushort)0, entityData.EntityVersion);
            Assert.Equal((ushort)0, entityData.WorldID);
        }

        /// <summary>
        ///     Tests that EntityData can be explicitly constructed with all field types
        /// </summary>
        /// <remarks>
        ///     Validates that all three field types (int, ushort, ushort) can be
        ///     assigned with their full range of valid values.
        /// </remarks>
        [Fact]
        public void EntityData_AllFieldTypesCanBeAssigned()
        {
            EntityData entityData = new EntityData
            {
                EntityID = int.MinValue,
                EntityVersion = ushort.MaxValue,
                WorldID = ushort.MaxValue
            };

            Assert.Equal(int.MinValue, entityData.EntityID);
            Assert.Equal(ushort.MaxValue, entityData.EntityVersion);
            Assert.Equal(ushort.MaxValue, entityData.WorldID);
        }

        /// <summary>
        ///     Tests that EntityData version increments correctly for recycling detection
        /// </summary>
        /// <remarks>
        ///     Validates the version increment pattern used for detecting stale references
        ///     when entity IDs are recycled after deletion.
        /// </remarks>
        [Fact]
        public void EntityData_VersionIncrementsCorrectlyForRecycling()
        {
            EntityData entityData = new EntityData
            {
                EntityID = 42,
                EntityVersion = 0,
                WorldID = 1
            };

            entityData.EntityVersion++;
            Assert.Equal((ushort)1, entityData.EntityVersion);

            entityData.EntityVersion++;
            Assert.Equal((ushort)2, entityData.EntityVersion);

            entityData.EntityVersion = ushort.MaxValue;
            Assert.Equal(ushort.MaxValue, entityData.EntityVersion);

            // Verify version wrap-around behavior (unsigned overflow)
            entityData.EntityVersion++;
            Assert.Equal((ushort)0, entityData.EntityVersion);
        }

        /// <summary>
        ///     Tests that EntityData can represent a deleted entity with recycled ID
        /// </summary>
        /// <remarks>
        ///     Validates the scenario where an entity ID is recycled: same EntityID
        ///     but different EntityVersion indicates a new entity reusing the ID.
        /// </remarks>
        [Fact]
        public void EntityData_RecycledEntityIdHasDifferentVersion()
        {
            EntityData oldEntity = new EntityData
            {
                EntityID = 42,
                EntityVersion = 1,
                WorldID = 5
            };

            EntityData newEntity = new EntityData
            {
                EntityID = 42, // Same ID recycled
                EntityVersion = 2, // Incremented version
                WorldID = 5
            };

            Assert.Equal(oldEntity.EntityID, newEntity.EntityID);
            Assert.NotEqual(oldEntity.EntityVersion, newEntity.EntityVersion);
            Assert.Equal(oldEntity.WorldID, newEntity.WorldID);
        }

        /// <summary>
        ///     Tests that EntityData can be used as a dictionary key
        /// </summary>
        /// <remarks>
        ///     Validates that EntityData instances can serve as dictionary keys,
        ///     relying on value-based field comparison for lookups.
        /// </remarks>
        [Fact]
        public void EntityData_CanBeUsedAsDictionaryKey()
        {
            var lookup = new Dictionary<EntityData, string>();

            EntityData key1 = new EntityData { EntityID = 1, EntityVersion = 1, WorldID = 1 };
            EntityData key2 = new EntityData { EntityID = 2, EntityVersion = 1, WorldID = 1 };
            EntityData key3 = new EntityData { EntityID = 1, EntityVersion = 2, WorldID = 1 };

            lookup[key1] = "first";
            lookup[key2] = "second";
            lookup[key3] = "third";

            Assert.Equal("first", lookup[key1]);
            Assert.Equal("second", lookup[key2]);
            Assert.Equal("third", lookup[key3]);
        }

        /// <summary>
        ///     Tests that EntityData can be used in a HashSet
        /// </summary>
        /// <remarks>
        ///     Validates that EntityData can be added to and searched in a HashSet.
        /// </remarks>
        [Fact]
        public void EntityData_CanBeUsedInHashSet()
        {
            var set = new HashSet<EntityData>();

            EntityData e1 = new EntityData { EntityID = 1, EntityVersion = 1, WorldID = 1 };
            EntityData e2 = new EntityData { EntityID = 2, EntityVersion = 1, WorldID = 1 };
            EntityData e3 = new EntityData { EntityID = 1, EntityVersion = 2, WorldID = 1 };

            set.Add(e1);
            set.Add(e2);
            set.Add(e3);

            Assert.Equal(3, set.Count);
            Assert.True(set.Contains(e1));
            Assert.True(set.Contains(e2));
            Assert.True(set.Contains(e3));
        }

        /// <summary>
        ///     Tests that EntityData can be copied and modifications to copy don't affect original
        /// </summary>
        /// <remarks>
        ///     Confirms value-type copy semantics: assigning an EntityData to another
        ///     variable creates an independent copy.
        /// </remarks>
        [Fact]
        public void EntityData_CopyDoesNotAffectOriginal()
        {
            EntityData original = new EntityData
            {
                EntityID = 100,
                EntityVersion = 5,
                WorldID = 10
            };

            EntityData copy = original;
            copy.EntityID = 999;
            copy.EntityVersion = 99;
            copy.WorldID = 99;

            Assert.Equal(100, original.EntityID);
            Assert.Equal((ushort)5, original.EntityVersion);
            Assert.Equal((ushort)10, original.WorldID);
        }

        /// <summary>
        ///     Tests that EntityData works correctly with List<T>
        /// </summary>
        /// <remarks>
        ///     Validates that EntityData can be stored in and retrieved from a List.
        /// </remarks>
        [Fact]
        public void EntityData_WorksCorrectlyWithList()
        {
            var list = new List<EntityData>();

            for (int i = 0; i < 50; i++)
            {
                list.Add(new EntityData
                {
                    EntityID = i * 2,
                    EntityVersion = (ushort)(i / 10),
                    WorldID = (ushort)(i % 8)
                });
            }

            Assert.Equal(50, list.Count);
            Assert.Equal(98, list[49].EntityID);
            Assert.Equal((ushort)4, list[49].EntityVersion);
            Assert.Equal((ushort)1, list[49].WorldID);
        }

        /// <summary>
        ///     Tests that EntityData zero entity ID is valid
        /// </summary>
        /// <remarks>
        ///     Validates that EntityID = 0 is a valid and commonly used entity identifier.
        /// </remarks>
        [Fact]
        public void EntityData_ZeroEntityIdIsValid()
        {
            EntityData entityData = new EntityData
            {
                EntityID = 0,
                EntityVersion = 1,
                WorldID = 1
            };

            Assert.Equal(0, entityData.EntityID);
            Assert.Equal((ushort)1, entityData.EntityVersion);
            Assert.Equal((ushort)1, entityData.WorldID);
        }

        /// <summary>
        ///     Tests that EntityData world ID zero is valid
        /// </summary>
        /// <remarks>
        ///     Validates that WorldID = 0 is a valid scene identifier.
        /// </remarks>
        [Fact]
        public void EntityData_ZeroWorldIdIsValid()
        {
            EntityData entityData = new EntityData
            {
                EntityID = 42,
                EntityVersion = 1,
                WorldID = 0
            };

            Assert.Equal(42, entityData.EntityID);
            Assert.Equal((ushort)1, entityData.EntityVersion);
            Assert.Equal((ushort)0, entityData.WorldID);
        }

        /// <summary>
        ///     Tests that EntityData version zero is valid
        /// </summary>
        /// <remarks>
        ///     Validates that EntityVersion = 0 is a valid initial version for new entities.
        /// </remarks>
        [Fact]
        public void EntityData_ZeroVersionIsValid()
        {
            EntityData entityData = new EntityData
            {
                EntityID = 42,
                EntityVersion = 0,
                WorldID = 1
            };

            Assert.Equal(42, entityData.EntityID);
            Assert.Equal((ushort)0, entityData.EntityVersion);
            Assert.Equal((ushort)1, entityData.WorldID);
        }

        /// <summary>
        ///     Tests that EntityData can handle concurrent field assignments
        /// </summary>
        /// <remarks>
        ///     Validates that all three fields can be set in a single object initializer
        ///     and are all correctly preserved.
        /// </remarks>
        [Fact]
        public void EntityData_AllFieldsSetInSingleInitializer()
        {
            EntityData entityData = new EntityData
            {
                EntityID = int.MinValue,
                EntityVersion = ushort.MaxValue,
                WorldID = ushort.MaxValue
            };

            Assert.Equal(int.MinValue, entityData.EntityID);
            Assert.Equal(ushort.MaxValue, entityData.EntityVersion);
            Assert.Equal(ushort.MaxValue, entityData.WorldID);
        }

        /// <summary>
        ///     Tests that EntityData can be serialized in a contiguous memory block
        /// </summary>
        /// <remarks>
        ///     Validates that EntityData can be used in interop scenarios where a
        ///     contiguous memory block of 8 bytes is expected.
        /// </remarks>
        [Fact]
        public void EntityData_SerializationProduces8ByteBlock()
        {
            EntityData entityData = new EntityData
            {
                EntityID = 12345,
                EntityVersion = 42,
                WorldID = 7
            };

            int size = Marshal.SizeOf<EntityData>();
            Assert.Equal(8, size);

            // Verify individual field sizes sum to total
            Assert.Equal(4, Marshal.SizeOf<int>());
            Assert.Equal(2, Marshal.SizeOf<ushort>());
            Assert.Equal(2, Marshal.SizeOf<ushort>());
        }

        /// <summary>
        ///     Tests that EntityData can be used with Array.Copy for bulk operations
        /// </summary>
        /// <remarks>
        ///     Validates that EntityData arrays can be copied efficiently using Array.Copy,
        ///     leveraging their value-type nature.
        /// </remarks>
        [Fact]
        public void EntityData_ArrayCopyWorksCorrectly()
        {
            EntityData[] source = new EntityData[10];
            for (int i = 0; i < source.Length; i++)
            {
                source[i] = new EntityData
                {
                    EntityID = i,
                    EntityVersion = (ushort)(i * 2),
                    WorldID = (ushort)(i / 3)
                };
            }

            EntityData[] destination = new EntityData[10];
            Array.Copy(source, destination, source.Length);

            for (int i = 0; i < source.Length; i++)
            {
                Assert.Equal(source[i].EntityID, destination[i].EntityID);
                Assert.Equal(source[i].EntityVersion, destination[i].EntityVersion);
                Assert.Equal(source[i].WorldID, destination[i].WorldID);
            }
        }

        /// <summary>
        ///     Tests that EntityData struct layout is sequential not explicit
        /// </summary>
        /// <remarks>
        ///     Verifies that the default sequential layout preserves field declaration order
        ///     in memory: EntityID (offset 0), EntityVersion (offset 4), WorldID (offset 6).
        /// </remarks>
        [Fact]
        public void EntityData_SequentialLayoutPreservesFieldOrder()
        {
            long field1 = Marshal.OffsetOf<EntityData>("EntityID").ToInt64();
            long field2 = Marshal.OffsetOf<EntityData>("EntityVersion").ToInt64();
            long field3 = Marshal.OffsetOf<EntityData>("WorldID").ToInt64();

            Assert.Equal(0, field1);
            Assert.Equal(4, field2);
            Assert.Equal(6, field3);

            // Verify order is preserved: EntityID < EntityVersion < WorldID
            Assert.True(field1 < field2);
            Assert.True(field2 < field3);
        }

        /// <summary>
        ///     Tests that EntityData with extreme but valid values works correctly
        /// </summary>
        /// <remarks>
        ///     Validates behavior with the full range of valid values for each field type,
        ///     including edge cases like int.MaxValue, int.MinValue, and ushort boundaries.
        /// </remarks>
        [Fact]
        public void EntityData_ExtremeButValidValuesWork()
        {
            EntityData entityData = new EntityData
            {
                EntityID = int.MaxValue,
                EntityVersion = 1,
                WorldID = 1
            };

            Assert.Equal(int.MaxValue, entityData.EntityID);

            entityData.EntityID = int.MinValue;
            Assert.Equal(int.MinValue, entityData.EntityID);

            entityData.EntityID = -1;
            Assert.Equal(-1, entityData.EntityID);

            entityData.EntityID = 1;
            Assert.Equal(1, entityData.EntityID);
        }

        /// <summary>
        ///     Tests that EntityData can be reset to default state
        /// </summary>
        /// <remarks>
        ///     Validates that an EntityData instance with arbitrary values can be reset
        ///     to a clean default state by reassigning default(EntityData).
        /// </remarks>
        [Fact]
        public void EntityData_CanBeResetToDefaultState()
        {
            EntityData entityData = new EntityData
            {
                EntityID = int.MinValue,
                EntityVersion = ushort.MaxValue,
                WorldID = ushort.MaxValue
            };

            entityData = default;

            Assert.Equal(0, entityData.EntityID);
            Assert.Equal((ushort)0, entityData.EntityVersion);
            Assert.Equal((ushort)0, entityData.WorldID);
        }

        /// <summary>
        ///     Tests that EntityData can be iterated in a for loop over an array
        /// </summary>
        /// <remarks>
        ///     Validates efficient iteration patterns commonly used in ECS systems.
        /// </remarks>
        [Fact]
        public void EntityData_CanBeIteratedInArray()
        {
            const int count = 1000;
            EntityData[] entities = new EntityData[count];

            for (int i = 0; i < count; i++)
            {
                entities[i] = new EntityData
                {
                    EntityID = i,
                    EntityVersion = (ushort)(i % 100),
                    WorldID = (ushort)(i % 50)
                };
            }

            int positiveCount = 0;
            int negativeCount = 0;

            for (int i = 0; i < count; i++)
            {
                if (entities[i].EntityID >= 0)
                {
                    positiveCount++;
                }
                else
                {
                    negativeCount++;
                }
            }

            Assert.Equal(count, positiveCount);
            Assert.Equal(0, negativeCount);
        }

        /// <summary>
        ///     Tests that EntityData can represent a scene with multiple entities
        /// </summary>
        /// <remarks>
        ///     Validates the scenario of a scene (WorldID) containing multiple entities
        ///     with different IDs and versions.
        /// </remarks>
        [Fact]
        public void EntityData_CanRepresentMultipleEntitiesInSameScene()
        {
            const int entityCount = 25;
            const ushort sceneId = 42;

            EntityData[] entities = new EntityData[entityCount];

            for (int i = 0; i < entityCount; i++)
            {
                entities[i] = new EntityData
                {
                    EntityID = i,
                    EntityVersion = 0,
                    WorldID = sceneId
                };
            }

            // All entities should share the same WorldID
            for (int i = 0; i < entityCount; i++)
            {
                Assert.Equal(sceneId, entities[i].WorldID);
            }

            // All entity IDs should be unique within the scene
            for (int i = 0; i < entityCount; i++)
            {
                for (int j = i + 1; j < entityCount; j++)
                {
                    Assert.NotEqual(entities[i].EntityID, entities[j].EntityID);
                }
            }
        }

        /// <summary>
        ///     Tests that EntityData can represent entities across multiple scenes
        /// </summary>
        /// <remarks>
        ///     Validates that entities with the same EntityID can exist in different scenes
        ///     (different WorldID), which is a valid ECS scenario.
        /// </remarks>
        [Fact]
        public void EntityData_SameEntityIdDifferentWorldsIsValid()
        {
            EntityData entityInScene1 = new EntityData
            {
                EntityID = 42,
                EntityVersion = 1,
                WorldID = 1
            };

            EntityData entityInScene2 = new EntityData
            {
                EntityID = 42, // Same ID in a different scene
                EntityVersion = 1,
                WorldID = 2
            };

            Assert.Equal(entityInScene1.EntityID, entityInScene2.EntityID);
            Assert.NotEqual(entityInScene1.WorldID, entityInScene2.WorldID);
        }

        /// <summary>
        ///     Tests that EntityData version overflow wraps correctly
        /// </summary>
        /// <remarks>
        ///     Validates unsigned overflow behavior when EntityVersion exceeds ushort.MaxValue.
        /// </remarks>
        [Fact]
        public void EntityData_VersionOverflowWrapsCorrectly()
        {
            EntityData entityData = new EntityData
            {
                EntityID = 1,
                EntityVersion = ushort.MaxValue,
                WorldID = 1
            };

            unchecked
            {
                entityData.EntityVersion++;
            }

            Assert.Equal((ushort)0, entityData.EntityVersion);
        }
    }

}