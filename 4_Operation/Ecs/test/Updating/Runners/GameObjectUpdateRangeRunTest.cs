// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectUpdateRangeRunTest.cs
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
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Alis.Core.Ecs.Updating;
using Alis.Core.Ecs.Updating.Runners;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating.Runners
{
    /// <summary>
    ///     Focused tests for the <see cref="GameObjectUpdate{TComp,TArg}" /> 
    ///     <c>Run(Scene, Archetype, int, int)</c> overload, which is invoked
    ///     only through the deferred-creation / <c>UpdateSubset</c> path.
    /// </summary>
    public class GameObjectUpdateRangeRunTest
    {
        /// <summary>
        ///     Tests that the range-based Run overload processes only newly created
        ///     entities when called through SingleComponentUpdateFilter.UpdateSubset.
        /// </summary>
        [Fact] public void RunRange_ThroughUpdateSubset_UpdatesOnlyNewEntities()
        {
            using (Scene scene = new Scene())
            {
                GameObject existing = scene.Create(
                    new RangeUpdateComponent {CallCount = 0},
                    new Position {X = 1, Y = 2}
                );

                SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<RangeUpdateComponent>.Id);

                scene.EnterDisallowState();
                GameObject deferred = scene.Create(
                    new RangeUpdateComponent {CallCount = 0},
                    new Position {X = 3, Y = 4}
                );
                scene.ExitDisallowState(filter, true);

                Assert.Equal(0, existing.Get<RangeUpdateComponent>().CallCount);
                Assert.Equal(1, deferred.Get<RangeUpdateComponent>().CallCount);
            }
        }

        /// <summary>
        ///     Tests that the range-based Run overload correctly updates component
        ///     data (Position.X/Y) for deferred entities.
        /// </summary>
        [Fact] public void RunRange_ThroughUpdateSubset_UpdatesComponentData()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(
                    new RangeUpdateComponent {CallCount = 0},
                    new Position {X = 10, Y = 20}
                );

                SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<RangeUpdateComponent>.Id);

                scene.EnterDisallowState();
                GameObject deferred = scene.Create(
                    new RangeUpdateComponent {CallCount = 0},
                    new Position {X = 1, Y = 2}
                );
                scene.ExitDisallowState(filter, true);

                Assert.Equal(2, deferred.Get<Position>().X);
                Assert.Equal(3, deferred.Get<Position>().Y);
            }
        }

        /// <summary>
        ///     Tests that the range-based Run overload processes multiple deferred
        ///     entities across potentially multiple archetypes.
        /// </summary>
        [Fact] public void RunRange_ThroughUpdateSubset_MultipleDeferredEntities()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(
                    new RangeUpdateComponent {CallCount = 0},
                    new Position {X = 0, Y = 0}
                );

                SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<RangeUpdateComponent>.Id);

                scene.EnterDisallowState();
                GameObject deferred1 = scene.Create(
                    new RangeUpdateComponent {CallCount = 0},
                    new Position {X = 5, Y = 10}
                );
                GameObject deferred2 = scene.Create(
                    new RangeUpdateComponent {CallCount = 0},
                    new Position {X = 15, Y = 20}
                );
                scene.ExitDisallowState(filter, true);

                Assert.Equal(1, deferred1.Get<RangeUpdateComponent>().CallCount);
                Assert.Equal(6, deferred1.Get<Position>().X);
                Assert.Equal(11, deferred1.Get<Position>().Y);

                Assert.Equal(1, deferred2.Get<RangeUpdateComponent>().CallCount);
                Assert.Equal(16, deferred2.Get<Position>().X);
                Assert.Equal(21, deferred2.Get<Position>().Y);
            }
        }
    }

    /// <summary>
    ///     Component for testing <see cref="GameObjectUpdate{TComp,TArg}" /> range Run.
    /// </summary>
    internal struct RangeUpdateComponent : IOnUpdate<Position>
    {
        /// <summary>
        /// The call count
        /// </summary>
        public int CallCount;

        /// <summary>
        /// Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="pos">The pos</param>
        public void Update(IGameObject self, ref Position pos)
        {
            CallCount++;
            pos.X += 1;
            pos.Y += 1;
        }
    }
}
