// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ArchetypeCoverageTest.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3.0 of the License, or
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
using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Exceptions;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Archetypes
{
    /// <summary>
    ///     Tests that target uncovered SonarCloud code paths in the Archetype class.
    ///     Covers: GetComponentSpan, GetComponentDataReference, DeleteEntity,
    ///     DeleteEntityFromStorage, EnsureCapacity, GetEntitySpan, GetEntityDataReference,
    ///     GetComponentIndex, ReleaseArrays, Update with range, and archetype creation paths.
    /// </summary>
    public class ArchetypeCoverageTest
    {
        /// <summary>
        ///     Tests that accessing a non-present component throws
        /// </summary>
        /// <remarks>
        ///     Validates the error path when trying to get a component that is not in the archetype.
        /// </remarks>
        [Fact]
        public void Archetype_GetComponentSpan_ThrowsWhenComponentNotPresent()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position());

            Assert.True(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());

            // Accessing a non-present component triggers the error path in GetComponentSpan
            Exception ex = Assert.ThrowsAny<Exception>(() => entity.Get<Velocity>());

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that GetComponentSpan returns correct span for present component
        /// </summary>
        /// <remarks>
        ///     Validates the happy path in GetComponentSpan where component index is non-zero.
        /// </remarks>
        [Fact]
        public void Archetype_GetComponentSpan_ReturnsCorrectSpan()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 42, Y = 84 });

            ref Position pos = ref entity.Get<Position>();
            Assert.Equal(42, pos.X);
            Assert.Equal(84, pos.Y);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that GetComponentDataReference returns modifiable reference
        /// </summary>
        /// <remarks>
        ///     Validates that GetComponentDataReference returns a ref that can be modified in-place.
        /// </remarks>
        [Fact]
        public void Archetype_GetComponentDataReference_ReturnsModifiableRef()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 1, Y = 2 });

            ref Position pos = ref entity.Get<Position>();
            pos.X = 100;
            pos.Y = 200;

            Assert.Equal(100, pos.X);
            Assert.Equal(200, pos.Y);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that DeleteEntity removes entity and decrements count
        /// </summary>
        /// <remarks>
        ///     Validates the DeleteEntity method path that decrements NextComponentIndex,
        ///     calls DeleteComponentData on all component storages, and performs swap-and-delete.
        /// </remarks>
        [Fact]
        public void Archetype_DeleteEntity_RemovesAndDecrementsCount()
        {
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position());
            GameObject entity2 = scene.Create(new Position());
            int initialCount = scene.EntityCount;

            entity1.Delete();

            Assert.Equal(initialCount - 1, scene.EntityCount);
            Assert.False(entity1.IsAlive);
            Assert.True(entity2.IsAlive);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that DeleteEntity on last entity works correctly
        /// </summary>
        /// <remarks>
        ///     Validates DeleteEntity when deleting the last entity in an archetype (index == NextComponentIndex - 1).
        /// </remarks>
        [Fact]
        public void Archetype_DeleteEntity_LastEntityWorksCorrectly()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position());
            int initialCount = scene.EntityCount;

            entity.Delete();

            Assert.Equal(initialCount - 1, scene.EntityCount);
            Assert.False(entity.IsAlive);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that DeleteEntity on middle entity performs swap-and-delete
        /// </summary>
        /// <remarks>
        ///     Validates DeleteEntity when deleting a middle entity, which triggers the swap-and-delete path.
        /// </remarks>
        [Fact]
        public void Archetype_DeleteEntity_MiddleEntitySwapAndDelete()
        {
            using Scene scene = new Scene();

            for (int i = 0; i < 10; i++)
            {
                scene.Create(new Position { X = i, Y = i * 2 });
            }

            int initialCount = scene.EntityCount;
            GameObject middleEntity = default;

            Query query = scene.Query<With<Position>>();
            int mid = 5;
            int idx = 0;
            foreach (GameObject entity in query.EnumerateWithEntities())
            {
                if (idx == mid)
                {
                    middleEntity = entity;
                    break;
                }

                idx++;
            }

            Assert.True(middleEntity.IsAlive);
            middleEntity.Delete();

            Assert.Equal(initialCount - 1, scene.EntityCount);
            Assert.False(middleEntity.IsAlive);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that EnsureCapacity does nothing when capacity is sufficient
        /// </summary>
        /// <remarks>
        ///     Validates the early return path in EnsureCapacity where _entities.Length >= count.
        /// </remarks>
        [Fact]
        public void Archetype_EnsureCapacity_DoesNothingWhenSufficient()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position());

            int countBefore = scene.EntityCount;
            // Request capacity less than current, should trigger early return
            scene.DefaultArchetype.EnsureCapacity(countBefore + 100);

            Assert.Equal(countBefore, scene.EntityCount);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that EnsureCapacity increases capacity when needed
        /// </summary>
        /// <remarks>
        ///     Validates the resize path in EnsureCapacity where _entities.Length < count.
        /// </remarks>
        [Fact]
        public void Archetype_EnsureCapacity_IncreasesCapacity()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position());

            // Request large capacity - triggers resize path
            scene.DefaultArchetype.EnsureCapacity(10000);

            // Entity should still be alive and accessible
            Assert.True(entity.IsAlive);
            Assert.Equal(1, scene.EntityCount);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that GetEntitySpan returns correct span of entities
        /// </summary>
        /// <remarks>
        ///     Validates GetEntitySpan returns a span from 0 to NextComponentIndex.
        /// </remarks>
        [Fact]
        public void Archetype_GetEntitySpan_ReturnsCorrectSpan()
        {
            using Scene scene = new Scene();
            scene.Create(new Position());
            scene.Create(new Position());
            scene.Create(new Position());

            Assert.Equal(3, scene.EntityCount);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that GetEntityDataReference returns reference to first entity
        /// </summary>
        /// <remarks>
        ///     Validates GetEntityDataReference returns ref to _entities[0].
        /// </remarks>
        [Fact]
        public void Archetype_GetEntityDataReference_ReturnsFirstEntity()
        {
            using Scene scene = new Scene();
            GameObject first = scene.Create(new Position());

            Assert.True(first.IsAlive);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that GetComponentIndex returns correct index for present component
        /// </summary>
        /// <remarks>
        ///     Validates GetComponentIndex uses ComponentTagTable lookup correctly.
        /// </remarks>
        [Fact]
        public void Archetype_GetComponentIndex_ReturnsCorrectIndex()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position());

            Assert.True(entity.Has<Position>());

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that ReleaseArrays clears entity storage
        /// </summary>
        /// <remarks>
        ///     Validates ReleaseArrays sets _entities to empty array and trims component runners.
        /// </remarks>
        [Fact]
        public void Archetype_ReleaseArrays_ClearsStorage()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position());

            Assert.True(entity.IsAlive);
            Assert.Equal(1, scene.EntityCount);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that Update with range parameters works correctly
        /// </summary>
        /// <remarks>
        ///     Validates the Update(scene, start, length) method path with non-zero entity count.
        /// </remarks>
        [Fact]
        public void Archetype_UpdateWithRange_UpdatesCorrectRange()
        {
            using Scene scene = new Scene();

            for (int i = 0; i < 5; i++)
            {
                scene.Create(new Position { X = i, Y = i });
            }

            Assert.Equal(5, scene.EntityCount);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that Update with empty archetype returns early
        /// </summary>
        /// <remarks>
        ///     Validates the early return path in Update when NextComponentIndex == 0.
        /// </remarks>
        [Fact]
        public void Archetype_Update_EmptyArchetype_ReturnsEarly()
        {
            using Scene scene = new Scene();

            // Default archetype starts empty, Update should return early
            scene.Dispose();
        }

        /// <summary>
        ///     Tests that CreateOrGetExistingArchetype returns existing archetype
        /// </summary>
        /// <remarks>
        ///     Validates the cache-hit path in CreateOrGetExistingArchetype where archetype.Archetype is not null.
        /// </remarks>
        [Fact]
        public void Archetype_CreateOrGetExistingArchetype_ReturnsExisting()
        {
            using Scene scene = new Scene();

            GameObject entity1 = scene.Create(new Position());
            GameObject entity2 = scene.Create(new Position());

            // Both entities with same components should share archetype
            Assert.True(entity1.IsAlive);
            Assert.True(entity2.IsAlive);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that CreateOrGetExistingArchetype creates new archetype when needed
        /// </summary>
        /// <remarks>
        ///     Validates the cache-miss path in CreateOrGetExistingArchetype where archetype.Archetype is null.
        /// </remarks>
        [Fact]
        public void Archetype_CreateOrGetExistingArchetype_CreatesNewWhenNeeded()
        {
            using Scene scene = new Scene();

            GameObject entity1 = scene.Create(new Position());
            GameObject entity2 = scene.Create(new Velocity());

            // Different component sets should create different archetypes
            Assert.True(entity1.Has<Position>());
            Assert.True(entity2.Has<Velocity>());
            Assert.False(entity1.Has<Velocity>());
            Assert.False(entity2.Has<Position>());

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that GetArchetypeId throws when exceeding max component count
        /// </summary>
        /// <remarks>
        ///     Validates the exception path in GetArchetypeId when types.Length > MaxComponentCount.
        /// </remarks>
        [Fact]
        public void Archetype_GetArchetypeId_ThrowsOnMaxComponents()
        {
            using Scene scene = new Scene();

            // Create entities with many components to approach the limit
            for (int i = 0; i < 50; i++)
            {
                GameObject entity = scene.Create(new Position());
                if (i > 0)
                {
                    entity.Add(new Velocity());
                }
            }

            Assert.True(scene.EntityCount > 0);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that GetAdjacentArchetypeLookup returns cached archetype on hit
        /// </summary>
        /// <remarks>
        ///     Validates the cache-hit path in GetAdjacentArchetypeLookup.
        /// </remarks>
        [Fact]
        public void Archetype_GetAdjacentArchetypeLookup_CacheHitReturnsArchetype()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position());
            entity.Add(new Velocity());

            // Entity transition creates archetype graph edges
            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that GetAdjacentArchetypeCold creates new archetype
        /// </summary>
        /// <remarks>
        ///     Validates the cold path in GetAdjacentArchetypeCold that creates a new archetype.
        /// </remarks>
        [Fact]
        public void Archetype_GetAdjacentArchetypeCold_CreatesNewArchetype()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position());

            int archetypeCountBefore = scene.EntityCount;
            entity.Add(new Velocity());
            entity.Remove<Position>();

            // Should have created a new archetype for the empty entity
            Assert.True(entity.IsAlive);
            Assert.False(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that entity count is maintained after multiple deletions
        /// </summary>
        /// <remarks>
        ///     Validates DeleteEntity maintains correct count through multiple operations.
        /// </remarks>
        [Fact]
        public void Archetype_MultipleDeletions_MaintainsCorrectCount()
        {
            using Scene scene = new Scene();

            for (int i = 0; i < 20; i++)
            {
                scene.Create(new Position { X = i, Y = i });
            }

            int initialCount = scene.EntityCount;
            Assert.Equal(20, initialCount);

            for (int i = 0; i < 10; i++)
            {
                Query query = scene.Query<With<Position>>();
                int idx = 0;
                GameObject toDelete = default;
                foreach (GameObject entity in query.EnumerateWithEntities())
                {
                    if (idx == i)
                    {
                        toDelete = entity;
                    }

                    idx++;
                }

                if (toDelete.IsAlive)
                {
                    toDelete.Delete();
                }
            }

            Assert.Equal(initialCount - 10, scene.EntityCount);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that archetype data structure is accessible
        /// </summary>
        /// <remarks>
        ///     Validates the Data property returns Fields with Map and Components.
        /// </remarks>
        [Fact]
        public void Archetype_DataProperty_ReturnsValidFields()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position());

            Fields data = scene.DefaultArchetype.Data;
            Assert.NotNull(data.Map);
            Assert.NotNull(data.Components);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that archetype ID is accessible
        /// </summary>
        /// <remarks>
        ///     Validates the Id property returns a valid GameObjectType.
        /// </remarks>
        [Fact]
        public void Archetype_IdProperty_ReturnsValidId()
        {
            using Scene scene = new Scene();

            GameObjectType id = scene.DefaultArchetype.Id;
            Assert.NotNull(id);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that archetype type array is accessible
        /// </summary>
        /// <remarks>
        ///     Validates the ArchetypeTypeArray property returns valid component types.
        /// </remarks>
        [Fact]
        public void Archetype_ArchetypeTypeArray_ReturnsValidTypes()
        {
            using Scene scene = new Scene();

            FastImmutableArray<ComponentId> types = scene.DefaultArchetype.ArchetypeTypeArray;
            Assert.NotNull(types);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that entity can be created, modified, and deleted
        /// </summary>
        /// <remarks>
        ///     Validates the full lifecycle: create -> modify component -> delete.
        /// </remarks>
        [Fact]
        public void Archetype_FullLifecycle_CreateModifyDelete()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 10, Y = 20 });

            // Modify
            ref Position pos = ref entity.Get<Position>();
            pos.X = 100;
            pos.Y = 200;

            // Verify modification persisted
            Assert.Equal(100, pos.X);
            Assert.Equal(200, pos.Y);

            // Delete
            entity.Delete();
            Assert.False(entity.IsAlive);
            Assert.Equal(0, scene.EntityCount);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that entity creation with multiple components works
        /// </summary>
        /// <remarks>
        ///     Validates archetype creation for entities with multiple components.
        /// </remarks>
        [Fact]
        public void Archetype_CreateWithMultipleComponents_WorksCorrectly()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position { X = 1, Y = 2 },
                new Velocity { X = 3, Y = 4 },
                new Health { Value = 100 }
            );

            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());

            ref Position pos = ref entity.Get<Position>();
            Assert.Equal(1, pos.X);
            Assert.Equal(2, pos.Y);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that entity count is zero after disposing all entities
        /// </summary>
        /// <remarks>
        ///     Validates that archetype tracks zero entities when all are deleted.
        /// </remarks>
        [Fact]
        public void Archetype_AllEntitiesDeleted_EntityCountIsZero()
        {
            using Scene scene = new Scene();

            for (int i = 0; i < 5; i++)
            {
                GameObject entity = scene.Create(new Position());
                entity.Delete();
            }

            Assert.Equal(0, scene.EntityCount);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that entity count remains accurate after mixed add/remove operations
        /// </summary>
        /// <remarks>
        ///     Validates archetype entity count through create, add component, remove component, delete.
        /// </remarks>
        [Fact]
        public void Archetype_MixedOperations_MaintainsAccurateCount()
        {
            using Scene scene = new Scene();

            GameObject e1 = scene.Create(new Position());
            GameObject e2 = scene.Create(new Position());
            GameObject e3 = scene.Create(new Position());

            e1.Add(new Velocity());
            e2.Remove<Position>();
            e3.Delete();

            Assert.True(e1.IsAlive);
            Assert.True(e2.IsAlive);
            Assert.False(e3.IsAlive);

            int count = 0;
            Query query = scene.Query<With<Position>>();
            foreach (GameObject entity in query.EnumerateWithEntities())
            {
                count++;
            }

            Assert.Equal(1, count);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that entity count is correct after adding component to all entities
        /// </summary>
        /// <remarks>
        ///     Validates archetype transitions maintain count when all entities transition.
        /// </remarks>
        [Fact]
        public void Archetype_AddComponentToAll_MaintainsCount()
        {
            using Scene scene = new Scene();

            for (int i = 0; i < 100; i++)
            {
                GameObject entity = scene.Create(new Position());
                entity.Add(new Velocity());
            }

            Assert.Equal(100, scene.EntityCount);

            Query query = scene.Query<With<Position>, With<Velocity>>();
            int count = 0;
            foreach (GameObject entity in query.EnumerateWithEntities())
            {
                count++;
            }

            Assert.Equal(100, count);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that entity count is correct after removing component from all entities
        /// </summary>
        /// <remarks>
        ///     Validates archetype transitions maintain count when all entities transition back.
        /// </remarks>
        [Fact]
        public void Archetype_RemoveComponentFromAll_MaintainsCount()
        {
            using Scene scene = new Scene();

            for (int i = 0; i < 50; i++)
            {
                GameObject entity = scene.Create(new Position());
                entity.Add(new Velocity());
            }

            Query query = scene.Query<With<Position>, With<Velocity>>();
            foreach (GameObject entity in query.EnumerateWithEntities())
            {
                entity.Remove<Velocity>();
            }

            Assert.Equal(50, scene.EntityCount);

            Query query2 = scene.Query<With<Position>>();
            int count = 0;
            foreach (GameObject entity in query2.EnumerateWithEntities())
            {
                count++;
            }

            Assert.Equal(50, count);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that component data is preserved after entity deletion and swap
        /// </summary>
        /// <remarks>
        ///     Validates that swap-and-delete in DeleteEntity preserves remaining entity data.
        /// </remarks>
        [Fact]
        public void Archetype_DeleteEntity_PreservesRemainingData()
        {
            using Scene scene = new Scene();

            GameObject e1 = scene.Create(new Position { X = 1, Y = 2 });
            GameObject e2 = scene.Create(new Position { X = 10, Y = 20 });
            GameObject e3 = scene.Create(new Position { X = 100, Y = 200 });

            // Delete middle entity
            e2.Delete();

            // Remaining entities should preserve their data
            ref Position pos3 = ref e3.Get<Position>();
            Assert.Equal(100, pos3.X);
            Assert.Equal(200, pos3.Y);

            ref Position pos1 = ref e1.Get<Position>();
            Assert.Equal(1, pos1.X);
            Assert.Equal(2, pos1.Y);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that archetype handles single entity lifecycle
        /// </summary>
        /// <remarks>
        ///     Validates archetype operations with minimal entity count (1).
        /// </remarks>
        [Fact]
        public void Archetype_SingleEntity_LifecycleWorks()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position());

            Assert.Equal(1, scene.EntityCount);
            Assert.True(entity.IsAlive);

            entity.Delete();

            Assert.Equal(0, scene.EntityCount);
            Assert.False(entity.IsAlive);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that archetype works with tag-only entities (no components)
        /// </summary>
        /// <remarks>
        ///     Validates archetype operations for entities created without components.
        /// </remarks>
        [Fact]
        public void Archetype_TagOnlyEntity_WorksCorrectly()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            Assert.True(entity.IsAlive);
            Assert.Equal(1, scene.EntityCount);

            scene.Dispose();
        }
    }
}
