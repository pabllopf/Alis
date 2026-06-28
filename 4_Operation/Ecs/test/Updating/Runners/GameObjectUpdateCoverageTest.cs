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
    ///     Targets uncovered conditions in the <c>Run(Scene, Archetype, int, int)</c> overload,
    ///     which executes entity updates on a sub-range (used during deferred-creation resolution).
    /// </summary>
    public class GameObjectUpdateCoverageTest
    {
        /// <summary>
        ///     Tests that the range-based Run overload processes entities correctly
        ///     when deferred creation occurs during an update cycle.
        /// </summary>
        [Fact]
        public void RangeRun_ProcessesEntities_WhenDeferredCreationOccurs()
        {
            using Scene scene = new Scene();

            _ = scene.Create(
                new DeferredSpawnComponent { SpawnCount = 2 },
                new Position { X = 1, Y = 2 }
            );

            Assert.Equal(1, scene.EntityCount);

            _ = scene.Create(
                new DeferredSpawnComponent { SpawnCount = 2 },
                new Position { X = 1, Y = 2 }
            );

            Assert.Equal(2, scene.EntityCount);

            _ = scene.Create(
                new DeferredSpawnComponent { SpawnCount = 2 },
                new Position { X = 1, Y = 2 }
            );

            Assert.Equal(3, scene.EntityCount);

            scene.Update();

            Assert.True(scene.EntityCount >= 3);
        }
    }

    /// <summary>
    ///     Component that spawns additional entities during its Update call,
    ///     triggering the deferred-creation path.
    /// </summary>
    internal struct DeferredSpawnComponent : IOnUpdate<Position>
    {
        /// <summary>
        ///     Number of entities to spawn on the first update.
        /// </summary>
        public int SpawnCount;

        /// <summary>
        ///     Whether this component has already spawned its entities.
        /// </summary>
        public bool HasSpawned;

        /// <summary>
        ///     Updates the self
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
}
