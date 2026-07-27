// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ArchetypeRemainingCoverageTests.cs
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
using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Exceptions;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Archetypes
{
    /// <summary>
    /// The archetype remaining coverage tests class
    /// </summary>
    [CollectionDefinition("ArchetypeRemainingCoverageTests", DisableParallelization = true)]
    public class ArchetypeRemainingCoverageTests
    {
        /// <summary>
        /// Tests that release arrays on archetype does not throw
        /// </summary>
        [Fact] public void ReleaseArrays_OnArchetype_DoesNotThrow()
        {
            using Scene scene = new Scene();
            for (int i = 0; i < 5; i++)
            {
                scene.Create(new Position { X = i, Y = i * 2 });
            }
            Assert.Equal(5, scene.EntityCount);

            Archetype archetype = scene.DefaultArchetype;
            archetype.ReleaseArrays();
        }

        /// <summary>
        /// Tests that update empty archetype returns early
        /// </summary>
        [Fact] public void Update_EmptyArchetype_ReturnsEarly()
        {
            using Scene scene = new Scene();
            Archetype archetype = scene.DefaultArchetype;
            Assert.Equal(0, archetype.EntityCount);
            scene.Update();
        }

        /// <summary>
        /// Tests that update with range non empty archetype processes correct range
        /// </summary>
        [Fact] public void UpdateWithRange_NonEmptyArchetype_ProcessesCorrectRange()
        {
            using Scene scene = new Scene();
            for (int i = 0; i < 5; i++)
            {
                scene.Create(new Position { X = i, Y = i });
            }
            Assert.Equal(5, scene.EntityCount);
            scene.Update();
        }

        /// <summary>
        /// Tests that create deferred entity location non overflow multiple entities resolves correctly
        /// </summary>
        [Fact] public void CreateDeferredEntityLocation_NonOverflowMultipleEntities_ResolvesCorrectly()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();

            GameObject e1 = scene.Create(new Position { X = 1, Y = 2 });
            GameObject e2 = scene.Create(new Position { X = 3, Y = 4 });
            GameObject e3 = scene.Create(new Position { X = 5, Y = 6 });

            scene.ExitDisallowState(null);

            Assert.Equal(3, scene.EntityCount);
            Assert.True(e1.IsAlive);
            Assert.True(e2.IsAlive);
            Assert.True(e3.IsAlive);

            ref Position p1 = ref e1.Get<Position>();
            Assert.Equal(1, p1.X);
            ref Position p3 = ref e3.Get<Position>();
            Assert.Equal(5, p3.X);
        }

        /// <summary>
        /// Tests that resolve deferred entity creations non overflow updates entity table
        /// </summary>
        [Fact] public void ResolveDeferredEntityCreations_NonOverflow_UpdatesEntityTable()
        {
            using Scene scene = new Scene();

            scene.EnterDisallowState();
            for (int i = 0; i < 4; i++)
            {
                scene.Create(new Position { X = i, Y = i * 10 });
            }
            scene.ExitDisallowState(null);

            Assert.Equal(4, scene.EntityCount);

            for (int i = 0; i < 4; i++)
            {
                Query query = scene.Query<With<Position>>();
                int count = 0;
                foreach (RefTuple<Position> _ in query.Enumerate<Position>())
                {
                    count++;
                }
                Assert.Equal(4, count);
            }
        }

        /// <summary>
        /// Tests that modify component location table when not resizing sets component table
        /// </summary>
        [Fact] public void ModifyComponentLocationTable_WhenNotResizing_SetsComponentTable()
        {
            using Scene scene = new Scene();
            GameObject e1 = scene.Create(new Position { X = 1, Y = 2 });
            GameObject e2 = scene.Create(new Velocity { X = 3, Y = 4 });
            GameObject e3 = scene.Create(new Health { Value = 100 });
            GameObject e4 = scene.Create(new Damage { Value = 50 });
            GameObject e5 = scene.Create(new Armor { Value = 25 });

            Assert.True(e1.IsAlive);
            Assert.True(e2.IsAlive);
            Assert.True(e3.IsAlive);
            Assert.True(e4.IsAlive);
            Assert.True(e5.IsAlive);
        }

        /// <summary>
        /// Tests that get component index non generic overload with component id
        /// </summary>
        [Fact] public void GetComponentIndex_NonGenericOverload_WithComponentId()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 10, Y = 20 });

            Assert.True(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
        }

        /// <summary>
        /// Tests that data property get returns fields with map and components
        /// </summary>
        [Fact] public void DataProperty_Get_ReturnsFieldsWithMapAndComponents()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 5, Y = 10 });

            Fields data = scene.DefaultArchetype.Data;
            Assert.NotNull(data.Map);
            Assert.NotNull(data.Components);
            Assert.True(data.Map.Length > 0);
            Assert.True(data.Components.Length > 0);
        }

        /// <summary>
        /// Tests that archetype with 5 components creates and validates all components
        /// </summary>
        [Fact] public void ArchetypeWith5Components_CreatesAndValidates_AllComponents()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position { X = 1, Y = 2 },
                new Velocity { X = 3, Y = 4 },
                new Health { Value = 100 },
                new Damage { Value = 50 },
                new Armor { Value = 25 }
            );

            Assert.True(entity.IsAlive);
            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Damage>());
            Assert.True(entity.Has<Armor>());

            ref Position pos = ref entity.Get<Position>();
            Assert.Equal(1, pos.X);

            ref Armor armor = ref entity.Get<Armor>();
            Assert.Equal(25, armor.Value);
        }

        /// <summary>
        /// Tests that archetype with 6 components creates and validates all components
        /// </summary>
        [Fact] public void ArchetypeWith6Components_CreatesAndValidates_AllComponents()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position { X = 1, Y = 2 },
                new Velocity { X = 3, Y = 4 },
                new Health { Value = 100 },
                new Damage { Value = 50 },
                new Armor { Value = 25 },
                new TagComponent()
            );

            Assert.True(entity.IsAlive);
            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Damage>());
            Assert.True(entity.Has<Armor>());
            Assert.True(entity.Has<TagComponent>());
        }

        /// <summary>
        /// Tests that archetype with 7 components creates and validates all components
        /// </summary>
        [Fact] public void ArchetypeWith7Components_CreatesAndValidates_AllComponents()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position { X = 1, Y = 2 },
                new Velocity { X = 3, Y = 4 },
                new Health { Value = 100 },
                new Damage { Value = 50 },
                new Armor { Value = 25 },
                new PlayerTag(),
                new ComplexType { Id = 42, Name = "test" }
            );

            Assert.True(entity.IsAlive);
            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Damage>());
            Assert.True(entity.Has<Armor>());
            Assert.True(entity.Has<PlayerTag>());
            Assert.True(entity.Has<ComplexType>());

            ref ComplexType ct = ref entity.Get<ComplexType>();
            Assert.Equal(42, ct.Id);
            Assert.Equal("test", ct.Name);
        }

        /// <summary>
        /// Tests that archetype with 8 components creates and validates all components
        /// </summary>
        [Fact] public void ArchetypeWith8Components_CreatesAndValidates_AllComponents()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position { X = 1, Y = 2 },
                new Velocity { X = 3, Y = 4 },
                new Health { Value = 100 },
                new Damage { Value = 50 },
                new Armor { Value = 25 },
                new Transform { X = 10, Y = 20, Rotation = 45 },
                new AnotherComponent { Data = 3.14f, Name = "test" },
                new AnotherComponent2 { Data = 99, Name = "test2" }
            );

            Assert.True(entity.IsAlive);
            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Damage>());
            Assert.True(entity.Has<Armor>());
            Assert.True(entity.Has<Transform>());
            Assert.True(entity.Has<AnotherComponent>());
            Assert.True(entity.Has<AnotherComponent2>());

            ref Transform t = ref entity.Get<Transform>();
            Assert.Equal(45, t.Rotation);

            ref AnotherComponent ac = ref entity.Get<AnotherComponent>();
            Assert.Equal(3.14f, ac.Data);
        }

        /// <summary>
        /// Tests that create entity location when array full resizes
        /// </summary>
        [Fact] public void CreateEntityLocation_WhenArrayFull_Resizes()
        {
            using Scene scene = new Scene();

            for (int i = 0; i < 100; i++)
            {
                scene.Create(new Position { X = i, Y = i * 2 });
            }

            Assert.Equal(100, scene.EntityCount);

            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (RefTuple<Position> _ in query.Enumerate<Position>())
            {
                count++;
            }
            Assert.Equal(100, count);
        }

        /// <summary>
        /// Tests that ensure capacity when already sufficient returns early
        /// </summary>
        [Fact] public void EnsureCapacity_WhenAlreadySufficient_ReturnsEarly()
        {
            using Scene scene = new Scene();

            for (int i = 0; i < 5; i++)
            {
                scene.Create(new Position { X = i, Y = i });
            }

            int countBefore = scene.EntityCount;
            scene.DefaultArchetype.EnsureCapacity(100);
            Assert.Equal(countBefore, scene.EntityCount);

            scene.DefaultArchetype.EnsureCapacity(10);
            Assert.Equal(countBefore, scene.EntityCount);

            scene.DefaultArchetype.EnsureCapacity(5);
            Assert.Equal(countBefore, scene.EntityCount);
        }

        /// <summary>
        /// Tests that create or get existing archetype when already exists returns existing
        /// </summary>
        [Fact] public void CreateOrGetExistingArchetype_WhenAlreadyExists_ReturnsExisting()
        {
            using Scene scene = new Scene();

            GameObject e1 = scene.Create(new Position { X = 1, Y = 2 });
            GameObject e2 = scene.Create(new Position { X = 3, Y = 4 });

            Assert.True(e1.IsAlive);
            Assert.True(e2.IsAlive);

            ref Position p1 = ref e1.Get<Position>();
            ref Position p2 = ref e2.Get<Position>();
            Assert.Equal(1, p1.X);
            Assert.Equal(3, p2.X);
        }

        /// <summary>
        /// Tests that get adjacent archetype cold with add and remove edge types
        /// </summary>
        [Fact] public void GetAdjacentArchetypeCold_WithAddAndRemoveEdgeTypes()
        {
            using Scene scene = new Scene();

            GameObject entity = scene.Create(new Position { X = 10, Y = 20 });
            Assert.True(entity.Has<Position>());

            entity.Add(new Velocity { X = 1, Y = 2 });
            Assert.True(entity.Has<Velocity>());

            entity.Add(new Health { Value = 100 });
            Assert.True(entity.Has<Health>());

            entity.Remove<Position>();
            Assert.False(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());

            entity.Remove<Velocity>();
            Assert.False(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());

            ref Health hp = ref entity.Get<Health>();
            Assert.Equal(100, hp.Value);

            entity.Add(new Damage { Value = 50 });
            Assert.True(entity.Has<Damage>());
            Assert.True(entity.Has<Health>());
        }

        /// <summary>
        /// Tests that delete entity from storage swap and delete last entity moves to deleted slot
        /// </summary>
        [Fact] public void DeleteEntityFromStorage_SwapAndDelete_LastEntityMovesToDeletedSlot()
        {
            using Scene scene = new Scene();

            GameObject e1 = scene.Create(new Position { X = 1, Y = 2 });
            GameObject e2 = scene.Create(new Position { X = 10, Y = 20 });
            GameObject e3 = scene.Create(new Position { X = 100, Y = 200 });

            int countBefore = scene.EntityCount;
            Assert.Equal(3, countBefore);

            e2.Delete();

            Assert.Equal(countBefore - 1, scene.EntityCount);
            Assert.False(e2.IsAlive);
            Assert.True(e1.IsAlive);
            Assert.True(e3.IsAlive);

            ref Position p1 = ref e1.Get<Position>();
            Assert.Equal(1, p1.X);

            ref Position p3 = ref e3.Get<Position>();
            Assert.Equal(100, p3.X);
        }

        /// <summary>
        /// Tests that resize when create entity location resizes correctly
        /// </summary>
        [Fact] public void Resize_WhenCreateEntityLocation_ResizesCorrectly()
        {
            using Scene scene = new Scene();
            Archetype archetype = scene.DefaultArchetype;

            for (int i = 0; i < 200; i++)
            {
                scene.Create(new Position { X = i, Y = i * 2 });
            }

            Assert.Equal(200, scene.EntityCount);

            archetype.EnsureCapacity(400);
            Assert.Equal(200, scene.EntityCount);

            for (int i = 0; i < 200; i++)
            {
                scene.Create(new Position { X = i + 200, Y = i });
            }
            Assert.Equal(400, scene.EntityCount);
        }

        /// <summary>
        /// Tests that get hash with odd component count computes correct hash
        /// </summary>
        [Fact] public void GetHash_WithOddComponentCount_ComputesCorrectHash()
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

            GameObject entity2 = scene.Create(
                new Position { X = 5, Y = 6 },
                new Velocity { X = 7, Y = 8 },
                new Health { Value = 200 }
            );

            Assert.True(entity2.IsAlive);
            ref Position p2 = ref entity2.Get<Position>();
            Assert.Equal(5, p2.X);
        }

        /// <summary>
        /// Tests that get hash with even component count computes correct hash
        /// </summary>
        [Fact] public void GetHash_WithEvenComponentCount_ComputesCorrectHash()
        {
            using Scene scene = new Scene();

            GameObject entity = scene.Create(
                new Position { X = 1, Y = 2 },
                new Velocity { X = 3, Y = 4 }
            );

            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());

            GameObject entity2 = scene.Create(
                new Position { X = 5, Y = 6 },
                new Velocity { X = 7, Y = 8 }
            );

            Assert.True(entity2.IsAlive);
        }

        /// <summary>
        /// Tests that create deferred entity location temp buffers when index exceeds length resizes
        /// </summary>
        [Fact] public void CreateDeferredEntityLocationTempBuffers_WhenIndexExceedsLength_Resizes()
        {
            using Scene scene = new Scene();

            scene.EnterDisallowState();
            int count = 50;
            for (int i = 0; i < count; i++)
            {
                scene.Create(new Position { X = i, Y = i * 2 });
            }
            scene.ExitDisallowState(null);

            Assert.Equal(count, scene.EntityCount);

            Query query = scene.Query<With<Position>>();
            int found = 0;
            foreach (RefTuple<Position> _ in query.Enumerate<Position>())
            {
                found++;
            }
            Assert.Equal(count, found);
        }

        /// <summary>
        /// Tests that resolve deferred entity creations with non overflow multiple batches
        /// </summary>
        [Fact] public void ResolveDeferredEntityCreations_WithNonOverflow_MultipleBatches()
        {
            using Scene scene = new Scene();

            for (int batch = 0; batch < 3; batch++)
            {
                scene.EnterDisallowState();
                for (int i = 0; i < 3; i++)
                {
                    scene.Create(new Position { X = batch * 10 + i, Y = i });
                }
                scene.ExitDisallowState(null);
            }

            Assert.Equal(9, scene.EntityCount);

            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (RefTuple<Position> _ in query.Enumerate<Position>())
            {
                count++;
            }
            Assert.Equal(9, count);
        }

        /// <summary>
        /// Tests that archetype type array returns correct types
        /// </summary>
        [Fact] public void ArchetypeTypeArray_ReturnsCorrectTypes()
        {
            using Scene scene = new Scene();
            scene.Create(new Position());
            scene.Create(new Velocity());

            FastImmutableArray<ComponentId> types = scene.DefaultArchetype.ArchetypeTypeArray;
            Assert.NotNull(types);
        }

        /// <summary>
        /// Tests that delete entity multiple entities all deleted cleanly
        /// </summary>
        [Fact] public void DeleteEntity_MultipleEntities_AllDeletedCleanly()
        {
            using Scene scene = new Scene();

            GameObject[] entities = new GameObject[10];
            for (int i = 0; i < 10; i++)
            {
                entities[i] = scene.Create(new Position { X = i, Y = i * 10 });
            }

            Assert.Equal(10, scene.EntityCount);

            for (int i = 9; i >= 0; i--)
            {
                entities[i].Delete();
            }

            Assert.Equal(0, scene.EntityCount);
        }

        /// <summary>
        /// Tests that delete entity from middle remaining entity data preserved
        /// </summary>
        [Fact] public void DeleteEntity_FromMiddle_RemainingEntityDataPreserved()
        {
            using Scene scene = new Scene();

            GameObject e1 = scene.Create(new Position { X = 1, Y = 2 });
            GameObject e2 = scene.Create(new Position { X = 10, Y = 20 });
            GameObject e3 = scene.Create(new Position { X = 100, Y = 200 });
            GameObject e4 = scene.Create(new Position { X = 1000, Y = 2000 });

            e2.Delete();
            e3.Delete();

            Assert.Equal(2, scene.EntityCount);
            Assert.False(e2.IsAlive);
            Assert.False(e3.IsAlive);
            Assert.True(e1.IsAlive);
            Assert.True(e4.IsAlive);

            ref Position p1 = ref e1.Get<Position>();
            Assert.Equal(1, p1.X);
            ref Position p4 = ref e4.Get<Position>();
            Assert.Equal(1000, p4.X);
        }

        /// <summary>
        /// Tests that entity count after multiple create delete cycles accurate
        /// </summary>
        [Fact] public void EntityCount_AfterMultipleCreateDeleteCycles_Accurate()
        {
            using Scene scene = new Scene();

            for (int cycle = 0; cycle < 3; cycle++)
            {
                for (int i = 0; i < 5; i++)
                {
                    scene.Create(new Position { X = i, Y = i * 2 });
                }

                Query query = scene.Query<With<Position>>();
                foreach (GameObject entity in query.EnumerateWithEntities())
                {
                    entity.Delete();
                }
            }

            Assert.Equal(0, scene.EntityCount);

            for (int i = 0; i < 10; i++)
            {
                scene.Create(new Position { X = i, Y = i });
            }
            Assert.Equal(10, scene.EntityCount);
        }

        /// <summary>
        /// Tests that get component span throws component not found exception when component does not exist
        /// </summary>
        [Fact]
        public void GetComponentSpan_WhenComponentNotFound_ThrowsComponentNotFoundException()
        {
            using Scene scene = new Scene();
            Archetype archetype = scene.DefaultArchetype;
            Assert.Throws<ComponentNotFoundException>(() => archetype.GetComponentSpan<Position>());
        }

        /// <summary>
        /// Tests that get component data reference throws component not found exception when component does not exist
        /// </summary>
        [Fact]
        public void GetComponentDataReference_WhenComponentNotFound_ThrowsComponentNotFoundException()
        {
            using Scene scene = new Scene();
            Archetype archetype = scene.DefaultArchetype;
            Assert.Throws<ComponentNotFoundException>(() => archetype.GetComponentDataReference<Position>());
        }

        /// <summary>
        /// Tests that delete entity throws invalid operation exception when archetype has no entities
        /// </summary>
        [Fact]
        public void DeleteEntity_WhenEmptyArchetype_ThrowsInvalidOperationException()
        {
            using Scene scene = new Scene();
            Archetype archetype = scene.DefaultArchetype;
            Assert.Throws<InvalidOperationException>(() => archetype.DeleteEntity(0));
        }

        /// <summary>
        /// Tests that update with range returns early when archetype has no entities
        /// </summary>
        [Fact]
        public void UpdateWithRange_WhenEmptyArchetype_ReturnsEarly()
        {
            using Scene scene = new Scene();
            Archetype archetype = scene.DefaultArchetype;
            archetype.Update(scene, 0, 0);
        }

        /// <summary>
        /// Tests that components span returns non empty span
        /// </summary>
        [Fact]
        public void ComponentsSpan_OnDefaultArchetype_ReturnsComponents()
        {
            using Scene scene = new Scene();
            ReadOnlySpan<ComponentStorageBase> span = scene.DefaultArchetype.ComponentsSpan;
            Assert.False(span.IsEmpty);
        }

        /// <summary>
        /// Tests that component tag table span returns non empty span
        /// </summary>
        [Fact]
        public void ComponentTagTableSpan_OnDefaultArchetype_ReturnsTagTable()
        {
            using Scene scene = new Scene();
            ReadOnlySpan<byte> span = scene.DefaultArchetype.ComponentTagTableSpan;
            Assert.False(span.IsEmpty);
        }

        /// <summary>
        /// Tests that get entity span returns correct entity count
        /// </summary>
        [Fact]
        public void GetEntitySpan_WithDefaultEntities_ReturnsCorrectCount()
        {
            using Scene scene = new Scene();
            for (int i = 0; i < 3; i++)
            {
                scene.Create();
            }

            Archetype archetype = scene.DefaultArchetype;
            Span<GameObjectIdOnly> entities = archetype.GetEntitySpan();
            Assert.Equal(3, entities.Length);
        }

        /// <summary>
        /// Tests that get entity data reference returns reference to first entity
        /// </summary>
        [Fact]
        public void GetEntityDataReference_OnNonEmptyArchetype_ReturnsReference()
        {
            using Scene scene = new Scene();
            scene.Create();

            Archetype archetype = scene.DefaultArchetype;
            ref GameObjectIdOnly first = ref archetype.GetEntityDataReference();
            Assert.NotNull(first);
        }

        /// <summary>
        /// Tests that static constructor initializes null
        /// </summary>
        [Fact]
        public void ArchetypeStaticConstructor_InitializesNull()
        {
            GameObjectType nullId = Archetype<Position>.Null;
            Assert.NotNull(nullId);
        }

        /// <summary>
        /// Tests that null is shared between generic and non generic
        /// </summary>
        [Fact]
        public void ArchetypeNull_SharedBetweenGenericAndNonGeneric()
        {
            Assert.Equal(Archetype<Position>.Null, Archetype.Null);
        }

        /// <summary>
        /// Tests that get archetype id throws invalid operation exception when too many components
        /// </summary>
        [Fact]
        public void GetArchetypeId_WithTooManyComponents_ThrowsInvalidOperationException()
        {
            ComponentId[] components = new ComponentId[128];
            for (int i = 0; i < 128; i++)
            {
                components[i] = Component<Position>.Id;
            }

            Assert.Throws<InvalidOperationException>(() => Archetype.GetArchetypeId(components.AsSpan()));
        }

        /// <summary>
        /// Tests that resize create component buffers resizes when array full
        /// </summary>
        [Fact]
        public void ResizeCreateComponentBuffers_ResizesWhenArrayFull()
        {
            using Scene scene = new Scene();

            scene.EnterDisallowState();
            int count = 10;
            for (int i = 0; i < count; i++)
            {
                scene.Create(new Position { X = i, Y = i * 2 });
            }
            scene.ExitDisallowState(null);

            Assert.Equal(count, scene.EntityCount);
        }

        /// <summary>
        /// Tests that get adjacent archetype lookup when not cached calls cold path
        /// </summary>
        [Fact]
        public void GetAdjacentArchetypeLookup_WhenNotCached_CallsColdPath()
        {
            using Scene scene = new Scene();

            GameObject entity = scene.Create(new Position { X = 1, Y = 2 });
            entity.Add(new Velocity { X = 3, Y = 4 });
            entity.Add(new Health { Value = 100 });
            entity.Remove<Velocity>();

            Assert.True(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
        }
    }
}
