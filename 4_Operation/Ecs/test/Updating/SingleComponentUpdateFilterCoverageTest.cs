// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SingleComponentUpdateFilterCoverageTest.cs
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
using Alis.Core.Ecs.Test.Models;
using Alis.Core.Ecs.Test.Updating.Runners;
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating
{
    /// <summary>
    ///     Coverage tests for <see cref="SingleComponentUpdateFilter.UpdateSubset" />.
    /// </summary>
    public class SingleComponentUpdateFilterCoverageTest
    {
        /// <summary>
        ///     Tests that UpdateSubset updates only deferred entities with the matching component
        ///     when called through deferred creation resolution.
        /// </summary>
        [Fact] public void UpdateSubset_WithDeferredComponentEntity_UpdatesNewEntity()
        {
            using (Scene scene = new Scene())
            {
                GameObject existing = scene.Create(new UpdateComponent {CallCount = 0});

                SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<UpdateComponent>.Id);

                scene.EnterDisallowState();
                GameObject deferred = scene.Create(new UpdateComponent {CallCount = 0});
                scene.ExitDisallowState(filter, true);

                Assert.Equal(0, existing.Get<UpdateComponent>().CallCount);
                Assert.Equal(1, deferred.Get<UpdateComponent>().CallCount);
            }
        }

        /// <summary>
        ///     Tests that UpdateSubset with an entity not having the filter's component
        ///     does not throw. This covers the <c>componentIndex == 0</c> branch.
        /// </summary>
        [Fact] public void UpdateSubset_WithDeferredNonComponentEntity_DoesNotThrow()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(new UpdateComponent {CallCount = 0});

                SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<UpdateComponent>.Id);

                scene.EnterDisallowState();
                scene.Create(new Position {X = 1, Y = 2});
                scene.ExitDisallowState(filter, true);
            }
        }

        /// <summary>
        ///     Tests that UpdateSubset with multiple archetypes (some with, some without the
        ///     component) processes only matching deferred entities.
        /// </summary>
        [Fact] public void UpdateSubset_WithMixedDeferredEntities_UpdatesOnlyMatching()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(new UpdateComponent {CallCount = 0});

                SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<UpdateComponent>.Id);

                scene.EnterDisallowState();
                GameObject matched = scene.Create(new UpdateComponent {CallCount = 0});
                scene.Create(new Position {X = 1, Y = 2});
                GameObject alsoMatched = scene.Create(new UpdateComponent {CallCount = 0}, new Velocity {X = 3, Y = 4});
                scene.ExitDisallowState(filter, true);

                Assert.Equal(1, matched.Get<UpdateComponent>().CallCount);
                Assert.Equal(1, alsoMatched.Get<UpdateComponent>().CallCount);
            }
        }

        /// <summary>
        ///     Tests that UpdateSubset is invoked when multiple entities are deferred and
        ///     that all deferred entities are updated exactly once.
        /// </summary>
        [Fact] public void UpdateSubset_WithMultipleDeferredEntities_UpdatesAll()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(new UpdateComponent {CallCount = 0});
                scene.Create(new UpdateComponent {CallCount = 0});

                SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<UpdateComponent>.Id);

                scene.EnterDisallowState();
                GameObject deferred1 = scene.Create(new UpdateComponent {CallCount = 0});
                GameObject deferred2 = scene.Create(new UpdateComponent {CallCount = 0});
                scene.ExitDisallowState(filter, true);

                Assert.Equal(1, deferred1.Get<UpdateComponent>().CallCount);
                Assert.Equal(1, deferred2.Get<UpdateComponent>().CallCount);
            }
        }
    }
}
