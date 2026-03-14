// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EntityUpdateTest.cs
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

using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Test.Models;
using System.Collections.Generic;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating.Runners
{
    /// <summary>
    ///     Tests for EntityUpdate runner (arity 5 update components).
    /// </summary>
    public class EntityUpdateTest
    {
        /// <summary>
        /// Tests that entity update constructor creates instance
        /// </summary>
        [Fact]
        public void EntityUpdate_Constructor_CreatesInstance()
        {
            EntityUpdate<EntityUpdate5Component, Position, Velocity, Health, Armor, Damage> update =
                new EntityUpdate<EntityUpdate5Component, Position, Velocity, Health, Armor, Damage>(8);

            Assert.NotNull(update);
            Assert.Equal(8, update.Buffer.Length);
        }

        /// <summary>
        /// Tests that entity update scene update invokes component update and mutates all args
        /// </summary>
        [Fact]
        public void EntityUpdate_SceneUpdate_InvokesComponentUpdateAndMutatesAllArgs()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new EntityUpdate5Component {CallCount = 0},
                new Position {X = 10, Y = 20},
                new Velocity {X = 1, Y = 2},
                new Health {Value = 100},
                new Armor {Value = 50},
                new Damage {Value = 5}
            );

            scene.Update();

            Assert.Equal(1, entity.Get<EntityUpdate5Component>().CallCount);
            Assert.Equal(11, entity.Get<Position>().X);
            Assert.Equal(22, entity.Get<Position>().Y);
            Assert.Equal(99, entity.Get<Health>().Value);
            Assert.Equal(51, entity.Get<Armor>().Value);
            Assert.Equal(7, entity.Get<Damage>().Value);
        }

        /// <summary>
        /// Tests that entity update scene update two frames accumulates changes
        /// </summary>
        [Fact]
        public void EntityUpdate_SceneUpdate_TwoFrames_AccumulatesChanges()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new EntityUpdate5Component {CallCount = 0},
                new Position {X = 0, Y = 0},
                new Velocity {X = 2, Y = 3},
                new Health {Value = 10},
                new Armor {Value = 1},
                new Damage {Value = 0}
            );

            scene.Update();
            scene.Update();

            Assert.Equal(2, entity.Get<EntityUpdate5Component>().CallCount);
            Assert.Equal(4, entity.Get<Position>().X);
            Assert.Equal(6, entity.Get<Position>().Y);
            Assert.Equal(8, entity.Get<Health>().Value);
            Assert.Equal(3, entity.Get<Armor>().Value);
            Assert.Equal(4, entity.Get<Damage>().Value);
        }

        /// <summary>
        /// Tests that entity update scene update updates all matching entities
        /// </summary>
        [Fact]
        public void EntityUpdate_SceneUpdate_UpdatesAllMatchingEntities()
        {
            using Scene scene = new Scene();
            GameObject e1 = scene.Create(
                new EntityUpdate5Component {CallCount = 0},
                new Position {X = 1, Y = 1},
                new Velocity {X = 1, Y = 1},
                new Health {Value = 5},
                new Armor {Value = 10},
                new Damage {Value = 1}
            );
            GameObject e2 = scene.Create(
                new EntityUpdate5Component {CallCount = 0},
                new Position {X = 2, Y = 2},
                new Velocity {X = 2, Y = 2},
                new Health {Value = 6},
                new Armor {Value = 20},
                new Damage {Value = 2}
            );

            scene.Update();

            Assert.Equal(1, e1.Get<EntityUpdate5Component>().CallCount);
            Assert.Equal(1, e2.Get<EntityUpdate5Component>().CallCount);
            Assert.Equal(2, e1.Get<Position>().X);
            Assert.Equal(4, e2.Get<Position>().X);
        }

        /// <summary>
        /// Tests that update runner wires the correct gameObject into each update invocation.
        /// </summary>
        [Fact]
        public void EntityUpdate_SceneUpdate_PassesCorrectEntityIdentityToEachComponent()
        {
            using Scene scene = new Scene();
            GameObject e1 = scene.Create(
                new EntityUpdate5IdentityComponent(),
                new Position {X = 0, Y = 0},
                new Velocity {X = 1, Y = 1},
                new Health {Value = 2},
                new Armor {Value = 3},
                new Damage {Value = 4}
            );
            GameObject e2 = scene.Create(
                new EntityUpdate5IdentityComponent(),
                new Position {X = 10, Y = 10},
                new Velocity {X = 2, Y = 2},
                new Health {Value = 12},
                new Armor {Value = 13},
                new Damage {Value = 14}
            );

            scene.Update();

            Assert.Equal(e1.EntityID, e1.Get<EntityUpdate5IdentityComponent>().LastSeenEntityId);
            Assert.Equal(e2.EntityID, e2.Get<EntityUpdate5IdentityComponent>().LastSeenEntityId);
            Assert.Equal(1, e1.Get<EntityUpdate5IdentityComponent>().CallCount);
            Assert.Equal(1, e2.Get<EntityUpdate5IdentityComponent>().CallCount);
        }

        /// <summary>
        /// Tests that deferred creations are processed through the subset range and existing entities are not re-updated.
        /// </summary>
        [Fact]
        public void EntityUpdate_SceneUpdate_DeferredCreation_UpdatesOnlyDeferredRange()
        {
            EntityUpdate5SpawnerComponent.ResetTracking();

            using Scene scene = new Scene();
            GameObject existingSpawner = scene.Create(
                new EntityUpdate5SpawnerComponent {SpawnCount = 2},
                new Position {X = 1, Y = 2},
                new Velocity {X = 2, Y = 3},
                new Health {Value = 10},
                new Armor {Value = 20},
                new Damage {Value = 1}
            );
            GameObject existingPassive = scene.Create(
                new EntityUpdate5SpawnerComponent {SpawnCount = 0},
                new Position {X = 3, Y = 4},
                new Velocity {X = 1, Y = 1},
                new Health {Value = 30},
                new Armor {Value = 40},
                new Damage {Value = 2}
            );

            scene.Update();

            // Existing entities run once in the main loop and are not included in deferred subset range.
            Assert.Equal(1, existingSpawner.Get<EntityUpdate5SpawnerComponent>().CallCount);
            Assert.Equal(1, existingPassive.Get<EntityUpdate5SpawnerComponent>().CallCount);

            Assert.Equal(2, EntityUpdate5SpawnerComponent.TotalSpawned);
            Assert.Equal(4, EntityUpdate5SpawnerComponent.TotalCalls);
            Assert.Equal(2, EntityUpdate5SpawnerComponent.SpawnedEntities.Count);

            foreach (GameObject spawned in EntityUpdate5SpawnerComponent.SpawnedEntities)
            {
                EntityUpdate5SpawnerComponent component = spawned.Get<EntityUpdate5SpawnerComponent>();
                Assert.Equal(1, component.CallCount);

                // Spawned entity was created with these values and then updated once in deferred subset.
                Assert.Equal(7, spawned.Get<Position>().X);
                Assert.Equal(8, spawned.Get<Position>().Y);
                Assert.Equal(49, spawned.Get<Health>().Value);
                Assert.Equal(61, spawned.Get<Armor>().Value);
                Assert.Equal(8, spawned.Get<Damage>().Value);
            }
        }

        /// <summary>
        /// Tests deferred path edge case where no entity is created and subset length is effectively zero.
        /// </summary>
        [Fact]
        public void EntityUpdate_SceneUpdate_NoDeferredCreation_DoesNotPerformExtraCalls()
        {
            EntityUpdate5SpawnerComponent.ResetTracking();

            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new EntityUpdate5SpawnerComponent {SpawnCount = 0},
                new Position {X = 1, Y = 1},
                new Velocity {X = 1, Y = 1},
                new Health {Value = 5},
                new Armor {Value = 5},
                new Damage {Value = 5}
            );

            scene.Update();

            Assert.Equal(1, entity.Get<EntityUpdate5SpawnerComponent>().CallCount);
            Assert.Equal(1, EntityUpdate5SpawnerComponent.TotalCalls);
            Assert.Equal(0, EntityUpdate5SpawnerComponent.TotalSpawned);
            Assert.Empty(EntityUpdate5SpawnerComponent.SpawnedEntities);
        }

        /// <summary>
        /// The entity update component
        /// </summary>
        internal struct EntityUpdate5Component : IOnUpdate<Position, Velocity, Health, Armor, Damage>
        {
            /// <summary>
            /// The call count
            /// </summary>
            public int CallCount;

            /// <summary>
            /// Updates the self
            /// </summary>
            /// <param name="self">The self</param>
            /// <param name="arg1">The arg</param>
            /// <param name="arg2">The arg</param>
            /// <param name="arg3">The arg</param>
            /// <param name="arg4">The arg</param>
            /// <param name="arg5">The arg</param>
            public void Update(IGameObject self, ref Position arg1, ref Velocity arg2, ref Health arg3, ref Armor arg4,
                ref Damage arg5)
            {
                CallCount++;
                arg1.X += arg2.X;
                arg1.Y += arg2.Y;
                arg3.Value -= 1;
                arg4.Value += 1;
                arg5.Value += 2;
            }
        }

        /// <summary>
        /// Update component used to validate that SetEntity wires the right entity in the loop.
        /// </summary>
        internal struct EntityUpdate5IdentityComponent : IOnUpdate<Position, Velocity, Health, Armor, Damage>
        {
            /// <summary>
            /// The call count
            /// </summary>
            public int CallCount;
            /// <summary>
            /// The last seen entity id
            /// </summary>
            public int LastSeenEntityId;

            /// <summary>
            /// Updates the self
            /// </summary>
            /// <param name="self">The self</param>
            /// <param name="arg1">The arg</param>
            /// <param name="arg2">The arg</param>
            /// <param name="arg3">The arg</param>
            /// <param name="arg4">The arg</param>
            /// <param name="arg5">The arg</param>
            public void Update(IGameObject self, ref Position arg1, ref Velocity arg2, ref Health arg3, ref Armor arg4,
                ref Damage arg5)
            {
                CallCount++;
                LastSeenEntityId = ((GameObject) self).EntityID;
            }
        }

        /// <summary>
        /// Update component that can spawn deferred entities to force execution of subset range updates.
        /// </summary>
        internal struct EntityUpdate5SpawnerComponent : IOnUpdate<Position, Velocity, Health, Armor, Damage>
        {
            /// <summary>
            /// The total calls
            /// </summary>
            public static int TotalCalls;
            /// <summary>
            /// The total spawned
            /// </summary>
            public static int TotalSpawned;
            /// <summary>
            /// The spawned entities
            /// </summary>
            public static readonly List<GameObject> SpawnedEntities = [];

            /// <summary>
            /// The call count
            /// </summary>
            public int CallCount;
            /// <summary>
            /// The spawn count
            /// </summary>
            public int SpawnCount;

            /// <summary>
            /// Resets the tracking
            /// </summary>
            public static void ResetTracking()
            {
                TotalCalls = 0;
                TotalSpawned = 0;
                SpawnedEntities.Clear();
            }

            /// <summary>
            /// Updates the self
            /// </summary>
            /// <param name="self">The self</param>
            /// <param name="arg1">The arg</param>
            /// <param name="arg2">The arg</param>
            /// <param name="arg3">The arg</param>
            /// <param name="arg4">The arg</param>
            /// <param name="arg5">The arg</param>
            public void Update(IGameObject self, ref Position arg1, ref Velocity arg2, ref Health arg3, ref Armor arg4,
                ref Damage arg5)
            {
                TotalCalls++;
                CallCount++;

                arg1.X += arg2.X;
                arg1.Y += arg2.Y;
                arg3.Value -= 1;
                arg4.Value += 1;
                arg5.Value += 2;

                if (SpawnCount > 0)
                {
                    for (int i = 0; i < SpawnCount; i++)
                    {
                        GameObject owner = (GameObject) self;
                        GameObject spawned = owner.Scene.Create(
                            new EntityUpdate5SpawnerComponent {SpawnCount = 0},
                            new Position {X = 5, Y = 5},
                            new Velocity {X = 2, Y = 3},
                            new Health {Value = 50},
                            new Armor {Value = 60},
                            new Damage {Value = 6}
                        );

                        SpawnedEntities.Add(spawned);
                        TotalSpawned++;
                    }

                    SpawnCount = 0;
                }
            }
        }
    }
}

