// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneUpdateFilterSubsetTest.cs
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
using Alis.Core.Ecs.Test.Models;
using Alis.Core.Ecs.Test.Updating.Runners;
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating
{
    /// <summary>
    ///     Focused tests for SceneUpdateFilter.Update and SceneUpdateFilter.UpdateSubset paths.
    /// </summary>
    public class SceneUpdateFilterSubsetTest
    {
        /// <summary>
        ///     The scene update filter subset attribute
        /// </summary>
        private static readonly Type FilterMarkerType = typeof(SceneUpdateFilterSubsetAttribute);

        /// <summary>
        ///     Tests that update processes all matching archetypes
        /// </summary>
        [Fact]
        public void Update_ProcessesAllMatchingArchetypes()
        {
            using Scene scene = new Scene();
            GenerationServices.RegisterUpdateMethodAttribute(FilterMarkerType, typeof(UpdateComponent));
            GameObject first = scene.Create(new UpdateComponent {CallCount = 0});
            GameObject second = scene.Create(new UpdateComponent {CallCount = 0}, new Position {X = 1, Y = 2});

            SceneUpdateFilter filter = new SceneUpdateFilter(scene, FilterMarkerType);

            filter.Update();
            filter.Update();

            Assert.Equal(2, first.Get<UpdateComponent>().CallCount);
            Assert.Equal(2, second.Get<UpdateComponent>().CallCount);
        }

        /// <summary>
        ///     Tests that update subset when resolving deferred creation updates only new entities
        /// </summary>
        [Fact]
        public void UpdateSubset_WhenResolvingDeferredCreation_UpdatesOnlyNewEntities()
        {
            using Scene scene = new Scene();
            GenerationServices.RegisterUpdateMethodAttribute(FilterMarkerType, typeof(UpdateComponent));
            GameObject existing = scene.Create(new UpdateComponent {CallCount = 0});
            SceneUpdateFilter filter = new SceneUpdateFilter(scene, FilterMarkerType);

            scene.EnterDisallowState();
            GameObject deferred = scene.Create(new UpdateComponent {CallCount = 0});
            scene.ExitDisallowState(filter, true);

            // ExitDisallowState(..., true) routes deferred records through SceneUpdateFilter.UpdateSubset.
            Assert.Equal(0, existing.Get<UpdateComponent>().CallCount);
            Assert.Equal(1, deferred.Get<UpdateComponent>().CallCount);
        }

        /// <summary>
        ///     The scene update filter subset attribute class
        /// </summary>
        /// <seealso cref="Attribute" />
        private sealed class SceneUpdateFilterSubsetAttribute : Attribute
        {
        }
    }
}