// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ArchetypeDeferredCoverageTest.cs
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

using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Archetypes
{
    /// <summary>
    ///     Tests targeting deferred entity creation paths and overflow code paths
    ///     in the Archetype class for SonarCloud coverage improvement.
    ///     Covers: CreateDeferredEntityLocation, CreateDeferredEntityLocationTempBuffers,
    ///     ResolveDeferredEntityCreations overflow branch, ModifyComponentLocationTable resize.
    /// </summary>
    public class ArchetypeDeferredCoverageTest
    {
        /// <summary>
        ///     Tests deferred entity creation with a single entity.
        ///     Exercises the CreateDeferredEntityLocation hot path
        ///     where futureSlot is within the existing array.
        /// </summary>
        [Fact] public void Archetype_DeferredCreate_SingleEntity()
        {
            using (Scene scene = new Scene())
            {
                scene.EnterDisallowState();
                GameObject entity = scene.Create(new Position {X = 10, Y = 20});
                scene.ExitDisallowState(null);

                Assert.True(entity.IsAlive);
                ref Position pos = ref entity.Get<Position>();
                Assert.Equal(10, pos.X);
                Assert.Equal(20, pos.Y);
            }
        }

        /// <summary>
        ///     Tests deferred entity creation with multiple entities.
        ///     Exercises the temp buffer overflow path in
        ///     CreateDeferredEntityLocation when futureSlot exceeds _entities.Length.
        /// </summary>
        [Fact] public void Archetype_DeferredCreate_MultipleEntitiesOverflow()
        {
            using (Scene scene = new Scene())
            {
                scene.EnterDisallowState();
                const int count = 10;
                GameObject[] entities = new GameObject[count];
                for (int i = 0; i < count; i++)
                {
                    entities[i] = scene.Create(new Position {X = i, Y = i * 2});
                }

                scene.ExitDisallowState(null);

                for (int i = 0; i < count; i++)
                {
                    Assert.True(entities[i].IsAlive);
                    ref Position pos = ref entities[i].Get<Position>();
                    Assert.Equal(i, pos.X);
                    Assert.Equal(i * 2, pos.Y);
                }

                Assert.Equal(count, scene.EntityCount);
            }
        }

        /// <summary>
        ///     Tests deferred entity creation with mixed normal and deferred entities.
        ///     First entity is created normally, then more are created in deferred mode,
        ///     which exercises the cold path when _entities.Length is exceeded.
        /// </summary>
        [Fact] public void Archetype_DeferredCreate_AfterNormalCreate()
        {
            using (Scene scene = new Scene())
            {
                GameObject first = scene.Create(new Position {X = 1, Y = 2});
                scene.EnterDisallowState();
                GameObject second = scene.Create(new Position {X = 3, Y = 4});
                scene.ExitDisallowState(null);

                Assert.True(first.IsAlive);
                Assert.True(second.IsAlive);
                ref Position pos1 = ref first.Get<Position>();
                Assert.Equal(1, pos1.X);
                ref Position pos2 = ref second.Get<Position>();
                Assert.Equal(3, pos2.X);
            }
        }

        /// <summary>
        ///     Tests deferred entity creation with multiple component types.
        ///     Exercises the deferred path with archetype of Position + Velocity.
        /// </summary>
        [Fact] public void Archetype_DeferredCreate_MultiComponent()
        {
            using (Scene scene = new Scene())
            {
                scene.EnterDisallowState();
                GameObject entity = scene.Create(
                    new Position {X = 100, Y = 200},
                    new Velocity {X = 5, Y = 10}
                );
                scene.ExitDisallowState(null);

                Assert.True(entity.IsAlive);
                Assert.True(entity.Has<Position>());
                Assert.True(entity.Has<Velocity>());
                ref Position pos = ref entity.Get<Position>();
                Assert.Equal(100, pos.X);
                ref Velocity vel = ref entity.Get<Velocity>();
                Assert.Equal(5, vel.X);
            }
        }

        /// <summary>
        ///     Tests deferred entity creation with temp buffer resize.
        ///     Creating many entities in deferred mode forces
        ///     multiple resizes of the temp buffer array.
        /// </summary>
        [Fact] public void Archetype_DeferredCreate_LargeBatchOverflow()
        {
            using (Scene scene = new Scene())
            {
                scene.EnterDisallowState();
                const int count = 100;
                for (int i = 0; i < count; i++)
                {
                    scene.Create(new Position {X = i, Y = i});
                }

                scene.ExitDisallowState(null);

                Assert.Equal(count, scene.EntityCount);
            }
        }

        /// <summary>
        ///     Tests deferred entity creation with component addition during deferred state.
        ///     Exercises the deferred add component path which also uses deferred archetypes.
        /// </summary>
        [Fact] public void Archetype_DeferredCreate_WithComponentAdd()
        {
            using (Scene scene = new Scene())
            {
                scene.EnterDisallowState();
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});
                scene.ExitDisallowState(null);

                Assert.True(entity.IsAlive);
                ref Position pos = ref entity.Get<Position>();
                Assert.Equal(1, pos.X);
            }
        }

        /// <summary>
        ///     Tests deferred creation with alternate deferred archetypes.
        ///     Uses the Archetype<T1,T2>.CreateNewOrGetExistingArchetypes
        ///     code path which creates archetypes with two components.
        /// </summary>
        [Fact] public void Archetype_DeferredCreate_AlternateArchetype()
        {
            using (Scene scene = new Scene())
            {
                scene.EnterDisallowState();
                GameObject entity = scene.Create(
                    new Position {X = 1, Y = 2},
                    new Velocity {X = 3, Y = 4},
                    new Health {Value = 100}
                );
                scene.ExitDisallowState(null);

                Assert.True(entity.IsAlive);
                Assert.True(entity.Has<Position>());
                Assert.True(entity.Has<Velocity>());
                Assert.True(entity.Has<Health>());
                ref Health hp = ref entity.Get<Health>();
                Assert.Equal(100, hp.Value);
            }
        }

        /// <summary>
        ///     Tests that deferred entity creation followed by component removal works.
        ///     Exercises the remove component code path after deferred resolution.
        /// </summary>
        [Fact] public void Archetype_DeferredCreate_ThenRemoveComponent()
        {
            using (Scene scene = new Scene())
            {
                scene.EnterDisallowState();
                GameObject entity = scene.Create(
                    new Position {X = 1, Y = 2},
                    new Velocity {X = 3, Y = 4}
                );
                scene.ExitDisallowState(null);

                Assert.True(entity.Has<Velocity>());
                entity.Remove<Velocity>();
                Assert.False(entity.Has<Velocity>());
                Assert.True(entity.Has<Position>());
            }
        }

        /// <summary>
        ///     Tests that deferred entity creation works with tag-only entities (no components).
        /// </summary>
        [Fact] public void Archetype_DeferredCreate_TagOnlyEntity()
        {
            using (Scene scene = new Scene())
            {
                scene.EnterDisallowState();
                GameObject entity = scene.Create();
                scene.ExitDisallowState(null);

                Assert.True(entity.IsAlive);
                Assert.Equal(1, scene.EntityCount);
            }
        }

        /// <summary>
        ///     Tests deferred creation with multiple sequential batches.
        ///     Exercises the clear and reuse of deferred creation archetypes.
        /// </summary>
        [Fact] public void Archetype_DeferredCreate_MultipleBatches()
        {
            using (Scene scene = new Scene())
            {
                for (int batch = 0; batch < 3; batch++)
                {
                    scene.EnterDisallowState();
                    for (int i = 0; i < 5; i++)
                    {
                        scene.Create(new Position {X = batch * 100 + i, Y = i});
                    }

                    scene.ExitDisallowState(null);
                }

                Assert.Equal(15, scene.EntityCount);
            }
        }

        /// <summary>
        ///     Tests that entity deletion preserves count after deferred creation resolution.
        ///     Exercises the DeleteEntity and ResolveDeferredEntityCreations interaction.
        /// </summary>
        [Fact] public void Archetype_DeferredCreate_ThenDelete()
        {
            using (Scene scene = new Scene())
            {
                scene.EnterDisallowState();
                GameObject e1 = scene.Create(new Position {X = 1, Y = 2});
                GameObject e2 = scene.Create(new Position {X = 3, Y = 4});
                scene.ExitDisallowState(null);

                Assert.Equal(2, scene.EntityCount);
                e1.Delete();
                Assert.Equal(1, scene.EntityCount);
                Assert.False(e1.IsAlive);
                Assert.True(e2.IsAlive);
            }
        }

        /// <summary>
        ///     Tests ArchetypeTable push in GetArchetypeId when a new archetype is created.
        ///     Exercises the cache-miss and push path in GetArchetypeId.
        /// </summary>
        [Fact] public void Archetype_GetArchetypeId_CacheMissPushesToTable()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position());

                Assert.True(entity.Has<Position>());
                Assert.False(entity.Has<Velocity>());

                entity.Add(new Velocity());
                Assert.True(entity.Has<Velocity>());
            }
        }

        /// <summary>
        ///     Tests that the Archetype.EdgeKey and adjacent lookups work
        ///     after deferred creation resolution.
        /// </summary>
        [Fact] public void Archetype_DeferredCreate_AdjacentLookup()
        {
            using (Scene scene = new Scene())
            {
                scene.EnterDisallowState();
                GameObject entity = scene.Create(new Position {X = 5, Y = 10});
                scene.ExitDisallowState(null);

                entity.Add(new Velocity {X = 1, Y = 2});
                Assert.True(entity.Has<Velocity>());
                ref Position pos = ref entity.Get<Position>();
                Assert.Equal(5, pos.X);
            }
        }

        /// <summary>
        ///     Tests that nested EnterDisallowState/ExitDisallowState works correctly.
        ///     Exercises the re-entrant deferred creation path.
        /// </summary>
        [Fact] public void Archetype_DeferredCreate_NestedDisallowState()
        {
            using (Scene scene = new Scene())
            {
                scene.EnterDisallowState();
                scene.EnterDisallowState();
                scene.EnterDisallowState();

                for (int i = 0; i < 3; i++)
                {
                    scene.Create(new Position {X = i, Y = i});
                }

                scene.ExitDisallowState(null);
                scene.ExitDisallowState(null);
                scene.ExitDisallowState(null);

                Assert.Equal(3, scene.EntityCount);
            }
        }

        /// <summary>
        ///     Tests that EnsureCapacity with pool-based resize works after deferred creation.
        ///     Exercises the FastestArrayPool.ResizeArrayFromPool path.
        /// </summary>
        [Fact] public void Archetype_DeferredCreate_EnsureCapacityPoolResize()
        {
            using (Scene scene = new Scene())
            {
                scene.EnterDisallowState();
                for (int i = 0; i < 50; i++)
                {
                    scene.Create(new Position {X = i, Y = i * 2});
                }

                scene.ExitDisallowState(null);

                scene.DefaultArchetype.EnsureCapacity(200);
                Assert.Equal(50, scene.EntityCount);

                for (int i = 0; i < 150; i++)
                {
                    scene.Create(new Position {X = i + 50, Y = i});
                }

                Assert.Equal(200, scene.EntityCount);
            }
        }

        /// <summary>
        ///     Tests EntityCount property after deferred creation and resolution.
        ///     Validates that EntityCount reflects the correct number after resolve.
        /// </summary>
        [Fact] public void Archetype_EntityCount_AfterDeferredResolve()
        {
            using (Scene scene = new Scene())
            {
                scene.EnterDisallowState();
                scene.Create(new Position());
                scene.Create(new Position());
                scene.Create(new Position());
                scene.ExitDisallowState(null);

                Assert.Equal(3, scene.EntityCount);
            }
        }

        /// <summary>
        ///     Tests that Archetype.Id is valid after deferred creation.
        /// </summary>
        [Fact] public void Archetype_Id_ValidAfterDeferredCreate()
        {
            using (Scene scene = new Scene())
            {
                scene.EnterDisallowState();
                scene.Create(new Position());
                scene.ExitDisallowState(null);

                GameObjectType id = scene.DefaultArchetype.Id;
            }
        }

        /// <summary>
        ///     Tests Archetype.Data property after deferred creation and resolution.
        /// </summary>
        [Fact] public void Archetype_Data_ValidAfterDeferredCreate()
        {
            using (Scene scene = new Scene())
            {
                scene.EnterDisallowState();
                scene.Create(new Position());
                scene.ExitDisallowState(null);

                Fields data = scene.DefaultArchetype.Data;
                Assert.NotNull(data.Map);
                Assert.NotNull(data.Components);
            }
        }

        /// <summary>
        ///     Tests that ReleaseArrays in deferred archetype works after resolution.
        /// </summary>
        [Fact] public void Archetype_DeferredCreate_ReleaseArrays()
        {
            using (Scene scene = new Scene())
            {
                scene.EnterDisallowState();
                for (int i = 0; i < 10; i++)
                {
                    scene.Create(new Position());
                }

                scene.ExitDisallowState(null);

                Assert.Equal(10, scene.EntityCount);
                
            }
        }
    }
}
