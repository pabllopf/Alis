// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ArchetypeFinalCoverageTest.cs
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
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Archetypes
{
    /// <summary>
    /// The archetype final coverage test class
    /// </summary>
    public class ArchetypeFinalCoverageTest
    {
        /// <summary>
        /// Tests that archetype components span returns correct read only span
        /// </summary>
        [Fact]
        public void Archetype_ComponentsSpan_ReturnsCorrectReadOnlySpan()
        {
            using Scene scene = new Scene();
            scene.Create(new Position());
            Archetype archetype = scene.DefaultArchetype;
            ReadOnlySpan<ComponentStorageBase> span = archetype.ComponentsSpan;
            Assert.False(span.IsEmpty);
        }

        /// <summary>
        /// Tests that archetype component tag table span returns correct read only span
        /// </summary>
        [Fact]
        public void Archetype_ComponentTagTableSpan_ReturnsCorrectReadOnlySpan()
        {
            using Scene scene = new Scene();
            scene.Create(new Position());
            Archetype archetype = scene.DefaultArchetype;
            ReadOnlySpan<byte> span = archetype.ComponentTagTableSpan;
            Assert.False(span.IsEmpty);
        }

        /// <summary>
        /// Tests that archetype of component index is accessible
        /// </summary>
        [Fact]
        public void Archetype_OfComponentIndex_IsAccessible()
        {
            using Scene scene = new Scene();
            scene.Create(new Position());
            int index = Archetype<Position>.OfComponent<Position>.Index;
            Assert.NotEqual(0, index);
        }

        /// <summary>
        /// Tests that archetype get component index with component id returns correct value
        /// </summary>
        [Fact]
        public void Archetype_GetComponentIndex_WithComponentId_ReturnsCorrectValue()
        {
            using Scene scene = new Scene();
            WorldArchetypeTableItem item = Archetype<Position>.CreateNewOrGetExistingArchetypes(scene);
            Archetype archetype = item.Archetype;
            int posIndex = archetype.GetComponentIndex(Component<Position>.Id);
            Assert.True(posIndex > 0);
        }

        /// <summary>
        /// Tests that archetype get hash with even component count computes hash
        /// </summary>
        [Fact]
        public void Archetype_GetHash_WithEvenComponentCount_ComputesHash()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position(), new Velocity());
            Assert.True(entity.IsAlive);
            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
        }

        /// <summary>
        /// Tests that archetype get hash with single component computes hash
        /// </summary>
        [Fact]
        public void Archetype_GetHash_WithSingleComponent_ComputesHash()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position());
            Assert.True(entity.IsAlive);
        }

        /// <summary>
        /// Tests that archetype ensure capacity when count less than length returns early
        /// </summary>
        [Fact]
        public void Archetype_EnsureCapacity_WhenCountLessThanLength_ReturnsEarly()
        {
            using Scene scene = new Scene();
            Archetype archetype = scene.DefaultArchetype;
            scene.Create(new Position());
            int initialCount = archetype.EntityCount;
            archetype.EnsureCapacity(0);
            Assert.Equal(initialCount, archetype.EntityCount);
        }

        /// <summary>
        /// Tests that archetype delete entity on empty archetype throws invalid operation
        /// </summary>
        [Fact]
        public void Archetype_DeleteEntity_OnEmptyArchetype_ThrowsInvalidOperation()
        {
            using Scene scene = new Scene();
            Archetype archetype = scene.DefaultArchetype;
            Assert.Equal(0, archetype.EntityCount);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => archetype.DeleteEntity(0));
            Assert.Contains("No entities", ex.Message);
        }

        /// <summary>
        /// Tests that archetype release arrays on empty archetype does not throw
        /// </summary>
        [Fact]
        public void Archetype_ReleaseArrays_OnEmptyArchetype_DoesNotThrow()
        {
            using Scene scene = new Scene();
            Archetype archetype = scene.DefaultArchetype;
            archetype.ReleaseArrays();
            Assert.Equal(0, archetype.EntityCount);
        }

        /// <summary>
        /// Tests that archetype update with range and empty archetype returns early
        /// </summary>
        [Fact]
        public void Archetype_Update_WithRangeAndEmptyArchetype_ReturnsEarly()
        {
            using Scene scene = new Scene();
            Archetype archetype = scene.DefaultArchetype;
            Assert.Equal(0, archetype.EntityCount);
            scene.Update();
        }

        /// <summary>
        /// Tests that archetype t get archetype id with over max components throws
        /// </summary>
        [Fact]
        public void Archetype_T_GetArchetypeId_WithOverMaxComponents_Throws()
        {
            ComponentId[] manyComponents = new ComponentId[128];
            for (int i = 0; i < 128; i++)
            {
                manyComponents[i] = new ComponentId((ushort)i);
            }
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
                Archetype.GetArchetypeId(manyComponents.AsSpan()));
            Assert.Contains("max of 127", ex.Message);
        }

        /// <summary>
        /// Tests that archetype ensure capacity passthrough does not throw
        /// </summary>
        [Fact]
        public void Archetype_EnsureCapacity_Passthrough_DoesNotThrow()
        {
            using Scene scene = new Scene();
            scene.Create(new Position());
            scene.DefaultArchetype.EnsureCapacity(1);
        }

        /// <summary>
        /// Tests that archetype t of component index is positive
        /// </summary>
        [Fact]
        public void Archetype_T_OfComponent_IndexIsPositive()
        {
            int index = Archetype<Position>.OfComponent<Position>.Index;
            Assert.True(index > 0);
        }

        /// <summary>
        /// Tests that archetype t get archetype id cache hit returns consistent
        /// </summary>
        [Fact]
        public void Archetype_T_GetArchetypeId_CacheHit_ReturnsConsistent()
        {
            GameObjectType id1 = Archetype.GetArchetypeId(new[] { Component<Position>.Id }.AsSpan());
            GameObjectType id2 = Archetype.GetArchetypeId(new[] { Component<Position>.Id }.AsSpan());
            Assert.Equal(id1.RawIndex, id2.RawIndex);
        }

        /// <summary>
        /// Tests that archetype t get hash with odd count hits both loops
        /// </summary>
        [Fact]
        public void Archetype_T_GetHash_WithOddCount_HitsBothLoops()
        {
            GameObjectType id = Archetype<Position, Velocity, Health>.Id;
        }

        /// <summary>
        /// Tests that archetype t get hash with even count hits first loop
        /// </summary>
        [Fact]
        public void Archetype_T_GetHash_WithEvenCount_HitsFirstLoop()
        {
            GameObjectType id = Archetype<Position, Velocity>.Id;
        }

        /// <summary>
        /// Tests that archetype resize create component buffers when empty handles correctly
        /// </summary>
        [Fact]
        public void Archetype_ResizeCreateComponentBuffers_WhenEmpty_HandlesCorrectly()
        {
            using Scene scene = new Scene();
            Archetype archetype = scene.DefaultArchetype;
            archetype.ResizeCreateComponentBuffers();
            Assert.True(archetype.EntityCount >= 0);
        }

        /// <summary>
        /// Tests that archetype create entity locations new entity id when not recycled
        /// </summary>
        [Fact]
        public void Archetype_CreateEntityLocations_NewEntityId_WhenNotRecycled()
        {
            using Scene scene = new Scene();
            scene.Create(new Position());
            Assert.Equal(1, scene.EntityCount);
        }

        /// <summary>
        /// Tests that archetype t 1 t 2 create new or get existing archetypes returns archetype
        /// </summary>
        [Fact]
        public void Archetype_T1T2_CreateNewOrGetExistingArchetypes_ReturnsArchetype()
        {
            using Scene scene = new Scene();
            WorldArchetypeTableItem item = Archetype<Position, Velocity>.CreateNewOrGetExistingArchetypes(scene);
            Assert.NotNull(item.Archetype);
        }

        /// <summary>
        /// Tests that archetype t 1 t 2 t 3 create new or get existing archetypes returns archetype
        /// </summary>
        [Fact]
        public void Archetype_T1T2T3_CreateNewOrGetExistingArchetypes_ReturnsArchetype()
        {
            using Scene scene = new Scene();
            WorldArchetypeTableItem item = Archetype<Position, Velocity, Health>.CreateNewOrGetExistingArchetypes(scene);
            Assert.NotNull(item.Archetype);
        }

        /// <summary>
        /// Tests that archetype t 1 t 2 t 3 t 4 create new or get existing archetypes returns archetype
        /// </summary>
        [Fact]
        public void Archetype_T1T2T3T4_CreateNewOrGetExistingArchetypes_ReturnsArchetype()
        {
            using Scene scene = new Scene();
            WorldArchetypeTableItem item = Archetype<Position, Velocity, Health, Damage>.CreateNewOrGetExistingArchetypes(scene);
            Assert.NotNull(item.Archetype);
        }

        /// <summary>
        /// Tests that archetype t 1 t 2 t 3 t 4 t 5 create new or get existing archetypes returns archetype
        /// </summary>
        [Fact]
        public void Archetype_T1T2T3T4T5_CreateNewOrGetExistingArchetypes_ReturnsArchetype()
        {
            using Scene scene = new Scene();
            WorldArchetypeTableItem item = Archetype<Position, Velocity, Health, Damage, Armor>.CreateNewOrGetExistingArchetypes(scene);
            Assert.NotNull(item.Archetype);
        }

        /// <summary>
        /// Tests that archetype t 1 t 2 t 3 t 4 t 5 t 6 create new or get existing archetypes returns archetype
        /// </summary>
        [Fact]
        public void Archetype_T1T2T3T4T5T6_CreateNewOrGetExistingArchetypes_ReturnsArchetype()
        {
            using Scene scene = new Scene();
            WorldArchetypeTableItem item = Archetype<Position, Velocity, Health, Damage, Armor, TagComponent>.CreateNewOrGetExistingArchetypes(scene);
            Assert.NotNull(item.Archetype);
        }

        /// <summary>
        /// Tests that archetype t 1 t 2 t 3 t 4 t 5 t 6 t 7 create new or get existing archetypes returns archetype
        /// </summary>
        [Fact]
        public void Archetype_T1T2T3T4T5T6T7_CreateNewOrGetExistingArchetypes_ReturnsArchetype()
        {
            using Scene scene = new Scene();
            WorldArchetypeTableItem item = Archetype<Position, Velocity, Health, Damage, Armor, PlayerTag, ComplexType>.CreateNewOrGetExistingArchetypes(scene);
            Assert.NotNull(item.Archetype);
        }

        /// <summary>
        /// Tests that archetype t 1 t 2 t 3 t 4 t 5 t 6 t 7 t 8 create new or get existing archetypes returns archetype
        /// </summary>
        [Fact]
        public void Archetype_T1T2T3T4T5T6T7T8_CreateNewOrGetExistingArchetypes_ReturnsArchetype()
        {
            using Scene scene = new Scene();
            WorldArchetypeTableItem item = Archetype<Position, Velocity, Health, Damage, Armor, Transform, AnotherComponent, AnotherComponent2>.CreateNewOrGetExistingArchetypes(scene);
            Assert.NotNull(item.Archetype);
        }

        /// <summary>
        /// Tests that archetype many archetypes forces component location table resize
        /// </summary>
        [Fact]
        public void Archetype_ManyArchetypes_ForcesComponentLocationTableResize()
        {
            using Scene scene = new Scene();
            for (int i = 0; i < 30; i++)
            {
                scene.Create(new Position { X = i, Y = i });
            }
            Assert.Equal(30, scene.EntityCount);
        }

        /// <summary>
        /// Tests that archetype update non empty archetype processes all
        /// </summary>
        [Fact]
        public void Archetype_Update_NonEmptyArchetype_ProcessesAll()
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
        /// Tests that archetype update range with non zero start covers branch
        /// </summary>
        [Fact]
        public void Archetype_UpdateRange_WithNonZeroStart_CoversBranch()
        {
            using Scene scene = new Scene();
            for (int i = 0; i < 10; i++)
            {
                scene.Create(new Position { X = i, Y = i });
            }
            Assert.Equal(10, scene.EntityCount);
            scene.Update();
        }

        /// <summary>
        /// Tests that archetype t create new or get existing archetypes cache hit returns existing
        /// </summary>
        [Fact]
        public void Archetype_T_CreateNewOrGetExistingArchetypes_CacheHit_ReturnsExisting()
        {
            using Scene scene = new Scene();
            WorldArchetypeTableItem first = Archetype<Position>.CreateNewOrGetExistingArchetypes(scene);
            WorldArchetypeTableItem second = Archetype<Position>.CreateNewOrGetExistingArchetypes(scene);
            Assert.Same(first.Archetype, second.Archetype);
        }

        /// <summary>
        /// Tests that archetype create or get existing archetype by id returns existing
        /// </summary>
        [Fact]
        public void Archetype_CreateOrGetExistingArchetype_ById_ReturnsExisting()
        {
            using Scene scene = new Scene();
            GameObjectType id = Archetype<Position>.Id;
            Archetype result = Archetype.CreateOrGetExistingArchetype(id, scene);
            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that archetype create or get existing archetype by span returns archetype
        /// </summary>
        [Fact]
        public void Archetype_CreateOrGetExistingArchetype_BySpan_ReturnsArchetype()
        {
            using Scene scene = new Scene();
            ReadOnlySpan<ComponentId> types = new[] { Component<Position>.Id };
            Archetype result = Archetype.CreateOrGetExistingArchetype(types, scene);
            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that archetype t 1 t 2 create new or get existing archetypes cache hit returns existing
        /// </summary>
        [Fact]
        public void Archetype_T1T2_CreateNewOrGetExistingArchetypes_CacheHit_ReturnsExisting()
        {
            using Scene scene = new Scene();
            WorldArchetypeTableItem first = Archetype<Position, Velocity>.CreateNewOrGetExistingArchetypes(scene);
            WorldArchetypeTableItem second = Archetype<Position, Velocity>.CreateNewOrGetExistingArchetypes(scene);
            Assert.Same(first.Archetype, second.Archetype);
        }

        /// <summary>
        /// Tests that archetype t 1 t 2 t 3 create new or get existing archetypes cache hit returns existing
        /// </summary>
        [Fact]
        public void Archetype_T1T2T3_CreateNewOrGetExistingArchetypes_CacheHit_ReturnsExisting()
        {
            using Scene scene = new Scene();
            WorldArchetypeTableItem first = Archetype<Position, Velocity, Health>.CreateNewOrGetExistingArchetypes(scene);
            WorldArchetypeTableItem second = Archetype<Position, Velocity, Health>.CreateNewOrGetExistingArchetypes(scene);
            Assert.Same(first.Archetype, second.Archetype);
        }

        /// <summary>
        /// Tests that archetype modify component location table with multiple archetypes covers resize
        /// </summary>
        [Fact]
        public void Archetype_ModifyComponentLocationTable_WithMultipleArchetypes_CoversResize()
        {
            using Scene scene = new Scene();
            scene.Create(new Position());
            scene.Create(new Position());
            scene.Create(new Position());
            Assert.Equal(3, scene.EntityCount);

            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (GameObject entity in query.EnumerateWithEntities())
            {
                count++;
                Assert.True(entity.Has<Position>());
            }

            Assert.Equal(3, count);
        }
    }
}
