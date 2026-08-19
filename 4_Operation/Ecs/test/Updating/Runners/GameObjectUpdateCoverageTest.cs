// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectUpdateCoverageTest.cs
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
using Alis.Core.Ecs.Updating.Runners;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating.Runners
{
    /// <summary>
    ///     Coverage tests for <see cref="GameObjectUpdate{TComp,TArg}" />.
    ///     Targets the <c>Run(Scene, Archetype, int, int)</c> overload via deferred creation.
    /// </summary>
    public class GameObjectUpdateCoverageTest
    {
        /// <summary>
        ///     Tests that an entity without the matching TComp does not trigger
        ///     GameObjectUpdate Runner, verifying the pipeline handles non-matching
        ///     archetypes gracefully (no-op).
        /// </summary>
        [Fact] public void Run_WithNonMatchingArchetype_DoesNotThrow()
        {
            using (Scene scene = new Scene())
            {
                _ = scene.Create(new TagComponent());
                scene.Update();
            }
        }

        /// <summary>
        ///     Tests that deferred creation during update does not throw even when
        ///     the spawned entities do not match the runner's component type.
        /// </summary>
        [Fact] public void Run_WithDeferredNonMatchingEntities_DoesNotThrow()
        {
            using (Scene scene = new Scene())
            {
                _ = scene.Create(
                    new SpawnPositionOnlyComponent {SpawnCount = 2},
                    new Position {X = 1, Y = 2}
                );

                scene.Update();
            }
        }

        /// <summary>
        ///     Tests that the range-based Run overload processes deferred entities
        ///     that share the same component type as the spawning entity.
        /// </summary>
        [Fact] public void RangeRun_SameTypeDeferredEntities_TriggersRangeBasedRun()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(
                    new SelfSpawningComponent {SpawnCount = 3, HasSpawned = false, CallCount = 0},
                    new Position {X = 1, Y = 2}
                );

                Assert.Equal(1, scene.EntityCount);

                scene.Update();

                Assert.Equal(4, scene.EntityCount);
                Assert.Equal(1, entity.Get<SelfSpawningComponent>().CallCount);
            }
        }
    }

    /// <summary>
    ///     Component that spawns Position-only entities during its Update call.
    /// </summary>
    internal struct SpawnPositionOnlyComponent : IOnUpdate<Position>
    {
        /// <summary>
        /// The spawn count
        /// </summary>
        public int SpawnCount;

        /// <summary>
        /// The has spawned
        /// </summary>
        public bool HasSpawned;

        /// <summary>
        /// Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="arg1">The arg</param>
        public void Update(IGameObject self, ref Position arg1)
        {
            if (!HasSpawned)
            {
                GameObject owner = (GameObject)self;

                for (int i = 0; i < SpawnCount; i++)
                {
                    owner.Scene.Create(new Position());
                }

                HasSpawned = true;
            }
        }
    }

    /// <summary>
    ///     Component that spawns additional entities with the SAME component type
    ///     during Update, triggering the range-based Run overload on the same
    ///     GameObjectUpdate type.
    /// </summary>
    internal struct SelfSpawningComponent : IOnUpdate<Position>
    {
        /// <summary>
        /// The spawn count
        /// </summary>
        public int SpawnCount;
        /// <summary>
        /// The has spawned
        /// </summary>
        public bool HasSpawned;
        /// <summary>
        /// The call count
        /// </summary>
        public int CallCount;

        /// <summary>
        /// Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="arg1">The arg</param>
        public void Update(IGameObject self, ref Position arg1)
        {
            CallCount++;
            if (!HasSpawned && SpawnCount > 0)
            {
                GameObject owner = (GameObject)self;

                for (int i = 0; i < SpawnCount; i++)
                {
                    owner.Scene.Create(
                        new SelfSpawningComponent { SpawnCount = 0, HasSpawned = true, CallCount = 0 },
                        new Position { X = 0, Y = 0 }
                    );
                }

                HasSpawned = true;
            }
        }
    }
}
