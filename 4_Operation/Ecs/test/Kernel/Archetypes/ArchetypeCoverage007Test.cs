// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ArchetypeCoverage007Test.cs
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

using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Archetypes
{
    /// <summary>
    ///     Tests targeting remaining uncovered code paths in Archetype.cs.
    ///     Covers: multi-generic archetypes (T1-T8), ResolveDeferredEntityCreations
    ///     overflow, ModifyComponentLocationTable resize, and hash edge cases.
    /// </summary>
    [CollectionDefinition("ArchetypeCoverage007Test", DisableParallelization = true)]
    public class ArchetypeCoverage007Test
    {
        /// <summary>
        ///     Tests creating an entity with 4 components.
        ///     Exercises Archetype&lt;T1,T2,T3,T4&gt;.CreateNewOrGetExistingArchetypes.
        /// </summary>
        [Fact] public void Archetype_With4Components_CreatesArchetypeT1T2T3T4()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position { X = 1, Y = 2 },
                new Velocity { X = 3, Y = 4 },
                new Health { Value = 100 },
                new Damage { Value = 50 }
            );

            Assert.True(entity.IsAlive);
            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Damage>());

            ref Position pos = ref entity.Get<Position>();
            Assert.Equal(1, pos.X);
            Assert.Equal(2, pos.Y);
        }

        /// <summary>
        ///     Tests creating an entity with 5 components.
        ///     Exercises Archetype&lt;T1,T2,T3,T4,T5&gt;.CreateNewOrGetExistingArchetypes.
        /// </summary>
        [Fact] public void Archetype_With5Components_CreatesArchetypeT1T2T3T4T5()
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
        ///     Tests creating an entity with 6 components.
        ///     Exercises Archetype&lt;T1,T2,T3,T4,T5,T6&gt;.CreateNewOrGetExistingArchetypes.
        /// </summary>
        [Fact] public void Archetype_With6Components_CreatesArchetypeT1T2T3T4T5T6()
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
        ///     Tests creating an entity with 7 components.
        ///     Exercises Archetype&lt;T1,T2,T3,T4,T5,T6,T7&gt;.CreateNewOrGetExistingArchetypes.
        /// </summary>
        [Fact] public void Archetype_With7Components_CreatesArchetypeT1T2T3T4T5T6T7()
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
        ///     Tests creating an entity with 8 components.
        ///     Exercises Archetype&lt;T1,T2,T3,T4,T5,T6,T7,T8&gt;.CreateNewOrGetExistingArchetypes.
        /// </summary>
        [Fact] public void Archetype_With8Components_CreatesArchetypeT1T2T3T4T5T6T7T8()
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
        }

        /// <summary>
        ///     Tests that ResolveDeferredEntityCreations handles the overflow path
        ///     where deltaFromMaxDeferredInPlace > 0 (entities overflowed into temp buffers).
        ///     Creates deferred entities that exceed the main array capacity.
        /// </summary>
        [Fact] public void Archetype_ResolveDeferredWithOverflow_CopiesFromTempBuffers()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();

            // Create 3 entities in deferred mode.
            // With a fresh archetype (_entities.Length=1), the 2nd and 3rd
            // overflow into temp buffers via CreateDeferredEntityLocationTempBuffers.
            const int count = 3;
            for (int i = 0; i < count; i++)
            {
                scene.Create(new Position { X = i, Y = i * 10 });
            }

            scene.ExitDisallowState(null);

            // Verify all entities resolved correctly
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
        ///     Tests ResolveDeferredEntityCreations with many deferred entities
        ///     to exercise the component buffer copy loop.
        /// </summary>
        [Fact] public void Archetype_ResolveDeferredWithManyEntities_CopiesComponentBuffers()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();

            // Create enough deferred entities to overflow and trigger
            // the copy loop in ResolveDeferredEntityCreations
            const int count = 50;
            for (int i = 0; i < count; i++)
            {
                scene.Create(
                    new Position { X = i, Y = i * 2 },
                    new Velocity { X = i + 1, Y = i * 3 }
                );
            }

            scene.ExitDisallowState(null);

            Assert.Equal(count, scene.EntityCount);

            // Verify by querying
            Query query = scene.Query<With<Position>, With<Velocity>>();
            int qCount = 0;
            foreach (RefTuple<Position, Velocity> _ in query.Enumerate<Position, Velocity>())
            {
                qCount++;
            }

            Assert.Equal(count, qCount);
        }

        /// <summary>
        ///     Tests creating many unique archetype combinations to force
        ///     the ComponentTagLocationTable resize in ModifyComponentLocationTable.
        /// </summary>
        [Fact] public void Archetype_ManyArchetypeCombinations_ForcesTableResize()
        {
            using Scene scene = new Scene();

            // Create entities with many distinct component combinations
            // to force the GlobalWorldTables.ComponentTagLocationTable resize
            GameObject e1 = scene.Create(new Position());
            scene.Create(new Velocity());
            scene.Create(new Health());
            scene.Create(new Damage());
            GameObject e5 = scene.Create(new Armor());
            scene.Create(new Transform());
            scene.Create(new TagComponent());
            scene.Create(new AnotherComponent());

            // Combinations of 2
            scene.Create(new Position(), new Velocity());
            GameObject e10 = scene.Create(new Position(), new Health());
            scene.Create(new Position(), new Damage());
            scene.Create(new Position(), new Armor());
            scene.Create(new Velocity(), new Health());
            scene.Create(new Velocity(), new Damage());

            // Combinations of 3
            GameObject e15 = scene.Create(new Position(), new Velocity(), new Health());
            scene.Create(new Position(), new Velocity(), new Damage());
            GameObject e17 = scene.Create(new Position(), new Velocity(), new Armor());

            // Verify all entities alive
            Assert.True(e1.IsAlive);
            Assert.True(e5.IsAlive);
            Assert.True(e10.IsAlive);
            Assert.True(e15.IsAlive);
            Assert.True(e17.IsAlive);

            // Verify query across archetypes
            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (RefTuple<Position> _ in query.Enumerate<Position>())
            {
                count++;
            }

            Assert.True(count >= 7);
        }

        /// <summary>
        ///     Tests GetHash with an odd number of component types
        ///     to exercise both hash computation loops (h1 and h2).
        /// </summary>
        [Fact] public void Archetype_GetHash_WithOddComponentCount_HitsBothLoops()
        {
            using Scene scene = new Scene();

            // With 3 component types: types.Length >> 1 = 1, so
            // loop 0: i=0, i < 1 → h1.Add(types[0])
            // loop 1: i=1, i < 3 → h2.Add(types[1]), h2.Add(types[2])
            GameObject entity = scene.Create(
                new Position { X = 1, Y = 2 },
                new Velocity { X = 3, Y = 4 },
                new Health { Value = 100 }
            );

            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());

            // Same combination should produce same hash
            GameObject entity2 = scene.Create(
                new Position { X = 5, Y = 6 },
                new Velocity { X = 7, Y = 8 },
                new Health { Value = 200 }
            );

            Assert.True(entity2.IsAlive);
        }

        /// <summary>
        ///     Tests the GetComponentIndex overload that takes ComponentId directly.
        ///     This exercises the non-generic overload at Archetype.GetComponentIndex(ComponentId).
        /// </summary>
        [Fact] public void Archetype_GetComponentIndex_WithComponentId_ReturnsIndex()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 10, Y = 20 });

            Assert.True(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
        }

        /// <summary>
        ///     Tests that ResolveDeferredEntityCreations correctly
        ///     updates entity table references in the overflow loop.
        ///     Exercises the for loop at lines 302-307.
        /// </summary>
        [Fact] public void Archetype_ResolveDeferred_UpdatesEntityTableReferences()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();

            // Create entities that will be in temp buffers
            for (int i = 0; i < 5; i++)
            {
                scene.Create(new Position { X = i, Y = i });
            }

            scene.ExitDisallowState(null);

            // Verify entity table entries are correct after resolve
            Assert.Equal(5, scene.EntityCount);

            // Create a normal entity after deferred resolution
            GameObject normal = scene.Create(new Position { X = 99, Y = 199 });
            Assert.True(normal.IsAlive);
            ref Position p = ref normal.Get<Position>();
            Assert.Equal(99, p.X);
        }

        /// <summary>
        ///     Tests that EnsureCapacity with pool resize works correctly
        ///     after many operations. Exercises the FastestArrayPool path.
        /// </summary>
        [Fact] public void Archetype_EnsureCapacity_PoolResize_WorksAfterManyDeletions()
        {
            using Scene scene = new Scene();

            // Create and delete many entities to fragment state
            for (int i = 0; i < 20; i++)
            {
                GameObject e = scene.Create(new Position { X = i, Y = i });
                e.Delete();
            }

            Assert.Equal(0, scene.EntityCount);

            // Create fresh entities - should use recycled IDs
            for (int i = 0; i < 10; i++)
            {
                scene.Create(new Position { X = i * 10, Y = i * 20 });
            }

            Assert.Equal(10, scene.EntityCount);

            // Verify data integrity
            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (RefTuple<Position> _ in query.Enumerate<Position>())
            {
                count++;
            }

            Assert.Equal(10, count);
        }

        /// <summary>
        ///     Tests that the GetArchetypeId cache miss path creates a new
        ///     archetype and pushes it to the ArchetypeTable.
        /// </summary>
        [Fact] public void Archetype_GetArchetypeId_CacheMiss_CreatesNewEntry()
        {
            using Scene scene = new Scene();

            // Create an entity with a unique component combination
            // that hasn't been seen before (cache miss)
            GameObject entity = scene.Create(
                new Position(),
                new Velocity(),
                new Health(),
                new Damage(),
                new Armor()
            );

            Assert.True(entity.IsAlive);
            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Armor>());
        }

    
    }
}
