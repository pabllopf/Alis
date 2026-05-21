// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneUpdateFilterTest.cs
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
    ///     Tests for <see cref="SceneUpdateFilter" />.
    /// </summary>
    public class SceneUpdateFilterTest
    {
        /// <summary>
        ///     The registered scene update filter attribute
        /// </summary>
        private static readonly Type RegisteredFilterType = typeof(RegisteredSceneUpdateFilterAttribute);

        /// <summary>
        ///     The empty scene update filter attribute
        /// </summary>
        private static readonly Type EmptyFilterType = typeof(EmptySceneUpdateFilterAttribute);

        /// <summary>
        ///     Tests that constructor with valid scene and attribute type creates filter
        /// </summary>
        [Fact]
        public void Constructor_WithValidSceneAndAttributeType_CreatesFilter()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 2});

            SceneUpdateFilter filter = new SceneUpdateFilter(scene, RegisteredFilterType);

            Assert.NotNull(filter);
        }

        /// <summary>
        ///     Tests that constructor processes existing archetypes
        /// </summary>
        [Fact]
        public void Constructor_ProcessesExistingArchetypes()
        {
            using Scene scene = new Scene();
            GenerationServices.RegisterUpdateMethodAttribute(RegisteredFilterType, typeof(UpdateComponent));
            GameObject entityA = scene.Create(new UpdateComponent {CallCount = 0});
            GameObject entityB = scene.Create(new UpdateComponent {CallCount = 0}, new Position {X = 3, Y = 4});

            SceneUpdateFilter filter = new SceneUpdateFilter(scene, RegisteredFilterType);

            filter.Update();

            Assert.Equal(1, entityA.Get<UpdateComponent>().CallCount);
            Assert.Equal(1, entityB.Get<UpdateComponent>().CallCount);
        }

        /// <summary>
        ///     Tests that update invokes on update for all components with attribute
        /// </summary>
        [Fact]
        public void Update_InvokesOnUpdateForAllComponentsWithAttribute()
        {
            using Scene scene = new Scene();
            GenerationServices.RegisterUpdateMethodAttribute(RegisteredFilterType, typeof(UpdateComponent));
            GameObject e1 = scene.Create(new UpdateComponent {CallCount = 0});
            GameObject e2 = scene.Create(new UpdateComponent {CallCount = 0}, new Velocity {X = 3, Y = 4});

            SceneUpdateFilter filter = new SceneUpdateFilter(scene, RegisteredFilterType);
            filter.Update();

            Assert.Equal(1, e1.Get<UpdateComponent>().CallCount);
            Assert.Equal(1, e2.Get<UpdateComponent>().CallCount);
        }

        /// <summary>
        ///     Tests that update called multiple times executes each time
        /// </summary>
        [Fact]
        public void Update_CalledMultipleTimes_ExecutesEachTime()
        {
            using Scene scene = new Scene();
            GenerationServices.RegisterUpdateMethodAttribute(RegisteredFilterType, typeof(UpdateComponent));
            GameObject entity = scene.Create(new UpdateComponent {CallCount = 0});

            SceneUpdateFilter filter = new SceneUpdateFilter(scene, RegisteredFilterType);
            filter.Update();
            filter.Update();

            Assert.Equal(2, entity.Get<UpdateComponent>().CallCount);
        }

        /// <summary>
        ///     Tests that update with no matching components does not throw
        /// </summary>
        [Fact]
        public void Update_WithNoMatchingComponents_DoesNotThrow()
        {
            using Scene scene = new Scene();
            scene.Create(new TestComponent {Value = 1, Name = "test"});

            SceneUpdateFilter filter = new SceneUpdateFilter(scene, EmptyFilterType);
            Exception ex = Record.Exception(filter.Update);

            Assert.Null(ex);
        }

        /// <summary>
        ///     Tests that update with empty scene does not throw
        /// </summary>
        [Fact]
        public void Update_WithEmptyScene_DoesNotThrow()
        {
            using Scene scene = new Scene();

            SceneUpdateFilter filter = new SceneUpdateFilter(scene, EmptyFilterType);
            Exception ex = Record.Exception(filter.Update);

            Assert.Null(ex);
        }

        /// <summary>
        ///     Tests that update subset through deferred creation updates only new entities
        /// </summary>
        [Fact]
        public void UpdateSubset_ThroughDeferredCreation_UpdatesOnlyNewEntities()
        {
            using Scene scene = new Scene();
            GenerationServices.RegisterUpdateMethodAttribute(RegisteredFilterType, typeof(UpdateComponent));
            GameObject existing = scene.Create(new UpdateComponent {CallCount = 0});
            SceneUpdateFilter filter = new SceneUpdateFilter(scene, RegisteredFilterType);

            scene.EnterDisallowState();
            GameObject deferred = scene.Create(new UpdateComponent {CallCount = 0});
            scene.ExitDisallowState(filter, true);

            Assert.Equal(0, existing.Get<UpdateComponent>().CallCount);
            Assert.Equal(1, deferred.Get<UpdateComponent>().CallCount);
        }

        /// <summary>
        ///     The registered scene update filter attribute class
        /// </summary>
        /// <seealso cref="Attribute" />
        private sealed class RegisteredSceneUpdateFilterAttribute : Attribute
        {
        }

        /// <summary>
        ///     The empty scene update filter attribute class
        /// </summary>
        /// <seealso cref="Attribute" />
        private sealed class EmptySceneUpdateFilterAttribute : Attribute
        {
        }
    }
}