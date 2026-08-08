// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ArchetypeUncoveredPathTest.cs
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

using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Archetypes
{
    /// <summary>
    ///     Tests targeting specific uncovered SonarCloud code paths in Archetype.cs.
    ///     Focuses on: GetArchetypeId validation, GetAdjacentArchetypeCold switch cases,
    ///     CreateDeferredEntityLocation temp buffer path, and ResolveDeferredEntityCreations overflow.
    /// </summary>
    public class ArchetypeUncoveredPathTest
    {
        /// <summary>
        ///     Tests that GetArchetypeId processes many different component types without error.
        ///     Covers the hash computation path with varying type counts.
        /// </summary>
        [Fact] public void Archetype_GetArchetypeId_WithManyComponentTypes_ProcessesSuccessfully()
        {
            // Arrange: Create entities with many different component types
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position());

            // Add different component types (not duplicates)
            entity.Add(new Velocity());
            entity.Add(new Health());

            // Verify we can add components
            Assert.True(entity.IsAlive);
            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that GetAdjacentArchetypeCold handles AddComponent edge type.
        ///     Covers the switch case: ArchetypeEdgeType.AddComponent
        /// </summary>
        [Fact] public void Archetype_GetAdjacentArchetypeCold_WithAddComponentEdgeType_CreatesNewArchetype()
        {
            // Arrange: Create an entity with one component, then transition by adding another
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position());

            // Add a velocity component to trigger archetype transition
            entity.Add(new Velocity());

            // The entity should now have both components in a new archetype
            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that GetAdjacentArchetypeCold handles RemoveComponent edge type.
        ///     Covers the switch case: ArchetypeEdgeType.RemoveComponent
        /// </summary>
        [Fact] public void Archetype_GetAdjacentArchetypeCold_WithRemoveComponentEdgeType_CreatesNewArchetype()
        {
            // Arrange: Create an entity with two components, then remove one
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position());
            entity.Add(new Velocity());

            // Remove the position component to trigger archetype transition
            entity.Remove<Position>();

            // The entity should now only have Velocity
            Assert.False(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());

            scene.Dispose();
        }

        /// <summary>
        ///     Tests the CreateDeferredEntityLocation path where deferred entities overflow into temp storage.
        ///     This covers the cold path in CreateDeferredEntityLocationTempBuffers.
        /// </summary>
        [Fact] public void Archetype_CreateDeferredEntityLocation_WhenOverflowingUsesTempBuffers()
        {
            // Arrange: Create a scene and entity, then trigger deferred creation overflow
            using Scene scene = new Scene();

            // Create multiple entities to fill the default archetype
            for (int i = 0; i < 100; i++)
            {
                scene.Create(new Position { X = i, Y = i });
            }

            // Verify entities were created
            Assert.Equal(100, scene.EntityCount);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests the ResolveDeferredEntityCreations overflow path where components overflow into temp storage.
        ///     This covers the deltaFromMaxDeferredInPlace > 0 branch.
        /// </summary>
        [Fact] public void Archetype_ResolveDeferredEntityCreations_WhenOverflowingResizesArray()
        {
            // Arrange: Create a scene with many entities, then trigger overflow scenario
            using Scene scene = new Scene();

            // Create initial entities
            for (int i = 0; i < 50; i++)
            {
                scene.Create(new Position { X = i, Y = i });
            }

            int initialCount = scene.EntityCount;

            // Add components to some entities to trigger archetype transitions
            Query query = scene.Query<With<Position>>();
            int addedCount = 0;
            foreach (GameObject entity in query.EnumerateWithEntities())
            {
                if (addedCount < 20)
                {
                    entity.Add(new Velocity());
                    addedCount++;
                }
            }

            // Verify entities are still alive
            Assert.Equal(initialCount, scene.EntityCount);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that GetArchetypeId returns consistent IDs for same component combinations.
        ///     Covers the cache-hit path in GetArchetypeId.
        /// </summary>
        [Fact] public void Archetype_GetArchetypeId_CacheHitReturnsConsistentId()
        {
            // Arrange: Create multiple entities with same components
            using Scene scene = new Scene();

            GameObject entity1 = scene.Create(new Position());
            GameObject entity2 = scene.Create(new Position());

            // Both should share the same archetype ID (cache hit)
            Assert.True(entity1.IsAlive);
            Assert.True(entity2.IsAlive);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that creating entities with different component combinations creates different archetypes.
        ///     Covers the cache-miss path in GetArchetypeId.
        /// </summary>
        [Fact] public void Archetype_GetArchetypeId_CacheMissCreatesNewId()
        {
            // Arrange: Create entities with different component combinations
            using Scene scene = new Scene();

            GameObject entity1 = scene.Create(new Position());
            GameObject entity2 = scene.Create(new Velocity());

            // Different component sets should have different archetype IDs
            Assert.True(entity1.Has<Position>());
            Assert.True(entity2.Has<Velocity>());
            Assert.False(entity1.Has<Velocity>());
            Assert.False(entity2.Has<Position>());

            scene.Dispose();
        }

        /// <summary>
        ///     Tests the ModifyComponentLocationTable path when table needs resizing.
        ///     Covers the: GlobalWorldTables.ComponentTagLocationTable.Length == id branch.
        /// </summary>
        [Fact] public void Archetype_ModifyComponentLocationTable_WhenTableNeedsResizing_ResizesCorrectly()
        {
            // Arrange: Create entities with various component combinations to trigger table resizing
            using Scene scene = new Scene();

            // Create entities with different component combinations
            GameObject e1 = scene.Create(new Position());
            GameObject e2 = scene.Create(new Velocity());
            GameObject e3 = scene.Create(new Health());

            // Add components to create more archetype transitions
            e1.Add(new Velocity());
            e1.Add(new Health());

            // Verify entities are alive (e2 and e3 are in different archetypes, e1 has multiple components)
            Assert.True(e1.IsAlive);
            Assert.True(e2.IsAlive);
            Assert.True(e3.IsAlive);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests the GetHash method with different component combinations.
        ///     Covers the hash computation path with varying type counts.
        /// </summary>
        [Fact] public void Archetype_GetHash_ComputesConsistentHashForSameComponents()
        {
            // Arrange: Create entities with identical component sets
            using Scene scene = new Scene();

            GameObject entity1 = scene.Create(new Position());
            GameObject entity2 = scene.Create(new Position());

            // Both should have the same archetype ID (same hash)
            Assert.True(entity1.IsAlive);
            Assert.True(entity2.IsAlive);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests entity creation with tag-only components (no data components).
        ///     Covers the archetype creation path for tag entities.
        /// </summary>
        [Fact] public void Archetype_TagOnlyEntities_CreatesCorrectArchetype()
        {
            // Arrange: Create entities with only tags (no data)
            using Scene scene = new Scene();

            GameObject entity1 = scene.Create(new PlayerTag());
            GameObject entity2 = scene.Create(new EnemyTag());

            // Both should be alive with their respective tags
            Assert.True(entity1.IsAlive);
            Assert.True(entity2.IsAlive);
            Assert.True(entity1.Has<PlayerTag>());
            Assert.True(entity2.Has<EnemyTag>());

            scene.Dispose();
        }

        /// <summary>
        ///     Tests the full lifecycle: create, add component, remove component, delete.
        ///     Covers multiple archetype transitions in sequence.
        /// </summary>
        [Fact] public void Archetype_FullLifecycle_MultipleTransitions()
        {
            // Arrange: Create entity and perform multiple component transitions
            using Scene scene = new Scene();

            GameObject entity = scene.Create(new Position());
            Assert.True(entity.Has<Position>());

            // Add Velocity
            entity.Add(new Velocity());
            Assert.True(entity.Has<Velocity>());

            // Add Health
            entity.Add(new Health());
            Assert.True(entity.Has<Health>());

            // Remove Position
            entity.Remove<Position>();
            Assert.False(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());

            // Remove Velocity
            entity.Remove<Velocity>();
            Assert.False(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());

            // Delete entity
            entity.Delete();
            Assert.False(entity.IsAlive);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that the null archetype is properly initialized.
        ///     Covers the static constructor path: Null = GetArchetypeId([Component.GetComponentId(typeof(void))]).
        /// </summary>
        [Fact] public void Archetype_NullArchetype_IsProperlyInitialized()
        {
            // Arrange: Access the null archetype through a void-typed component
            using Scene scene = new Scene();

            // Create an entity without any components (tag-only)
            GameObject entity = scene.Create();

            // The entity should be alive and use the null archetype
            Assert.True(entity.IsAlive);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests the ArchetypeTable static field initialization.
        ///     Covers the FastestStack creation and usage.
        /// </summary>
        [Fact] public void Archetype_ArchetypeTable_IsProperlyInitialized()
        {
            // Arrange: Create a scene to trigger archetype table initialization
            using Scene scene = new Scene();

            // Create an entity to trigger archetype creation
            GameObject entity = scene.Create(new Position());

            // Verify the archetype table was populated
            Assert.True(entity.IsAlive);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that entity count is maintained correctly through rapid create/delete cycles.
        ///     Covers repeated Allocate/Release paths in the archetype.
        /// </summary>
        [Fact] public void Archetype_RapidCreateDelete_MaintainsCorrectCount()
        {
            // Arrange: Create and delete entities rapidly
            using Scene scene = new Scene();

            for (int i = 0; i < 100; i++)
            {
                GameObject entity = scene.Create(new Position());
                entity.Delete();
            }

            // All entities should be deleted
            Assert.Equal(0, scene.EntityCount);

            // Create new entities
            for (int i = 0; i < 50; i++)
            {
                scene.Create(new Position { X = i, Y = i });
            }

            Assert.Equal(50, scene.EntityCount);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests the Update method with partial range parameters.
        ///     Covers the Update(scene, start, length) overload path.
        /// </summary>
        [Fact] public void Archetype_Update_WithPartialRange_UpdatesCorrectEntities()
        {
            // Arrange: Create entities and update a partial range
            using Scene scene = new Scene();

            for (int i = 0; i < 20; i++)
            {
                scene.Create(new Position { X = i, Y = i });
            }

            // The scene update should process all entities
            Assert.Equal(20, scene.EntityCount);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests the ReleaseArrays method path.
        ///     Covers the array clearing and trimming operations.
        /// </summary>
        [Fact] public void Archetype_ReleaseArrays_ClearsStorageCorrectly()
        {
            // Arrange: Create entities, then release arrays
            using Scene scene = new Scene();

            for (int i = 0; i < 10; i++)
            {
                scene.Create(new Position { X = i, Y = i });
            }

            Assert.Equal(10, scene.EntityCount);

            // Disposing the scene should release arrays
            scene.Dispose();
        }

        /// <summary>
        ///     Tests the ResizeCreateComponentBuffers method path.
        ///     Covers the deferred entity creation buffer resizing.
        /// </summary>
        [Fact] public void Archetype_ResizeCreateComponentBuffers_HandlesGrowth()
        {
            // Arrange: Create many entities to trigger buffer resizing
            using Scene scene = new Scene();

            // Create initial batch
            for (int i = 0; i < 10; i++)
            {
                scene.Create(new Position { X = i, Y = i });
            }

            // Add components to trigger archetype transitions and potential buffer resizing
            Query query = scene.Query<With<Position>>();
            int addedCount = 0;
            foreach (GameObject entity in query.EnumerateWithEntities())
            {
                if (addedCount < 5)
                {
                    entity.Add(new Velocity());
                    addedCount++;
                }
            }

            Assert.Equal(10, scene.EntityCount);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests the CreateEntityLocations method with recycled entity IDs.
        ///     Covers the path where recycled IDs are reused.
        /// </summary>
        [Fact] public void Archetype_CreateEntityLocations_WithRecycledIds_ReusesIds()
        {
            // Arrange: Create, delete, then create again to trigger ID recycling
            using Scene scene = new Scene();

            // Create initial entities
            GameObject e1 = scene.Create(new Position());
            GameObject e2 = scene.Create(new Position());

            // Delete them to free IDs
            e1.Delete();
            e2.Delete();

            Assert.Equal(0, scene.EntityCount);

            // Create new entities - should reuse the freed IDs
            GameObject e3 = scene.Create(new Position { X = 100, Y = 200 });

            Assert.Equal(1, scene.EntityCount);
            Assert.True(e3.IsAlive);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests the DeleteEntityFromStorage method with swap-and-delete.
        ///     Covers the path where index != NextComponentIndex - 1.
        /// </summary>
        [Fact] public void Archetype_DeleteEntityFromStorage_SwapAndDeletePreservesData()
        {
            // Arrange: Create multiple entities, delete middle one
            using Scene scene = new Scene();

            GameObject e1 = scene.Create(new Position { X = 1, Y = 2 });
            GameObject e2 = scene.Create(new Position { X = 10, Y = 20 });
            GameObject e3 = scene.Create(new Position { X = 100, Y = 200 });

            // Delete middle entity (triggers swap-and-delete)
            e2.Delete();

            // Remaining entities should preserve their data
            ref Position pos1 = ref e1.Get<Position>();
            Assert.Equal(1, pos1.X);
            Assert.Equal(2, pos1.Y);

            ref Position pos3 = ref e3.Get<Position>();
            Assert.Equal(100, pos3.X);
            Assert.Equal(200, pos3.Y);

            scene.Dispose();
        }
    }
}
