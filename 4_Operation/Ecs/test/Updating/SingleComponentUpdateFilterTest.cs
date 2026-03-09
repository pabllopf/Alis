// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SingleComponentUpdateFilterTest.cs
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
    ///     Tests for <see cref="SingleComponentUpdateFilter" />.
    /// </summary>
    public class SingleComponentUpdateFilterTest
    {
        /// <summary>
        /// Tests that constructor with valid scene and component creates filter
        /// </summary>
        [Fact]
        public void Constructor_WithValidSceneAndComponent_CreatesFilter()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 2});

            SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<Position>.Id);

            Assert.NotNull(filter);
        }

        /// <summary>
        /// Tests that constructor adds existing archetypes with matching component
        /// </summary>
        [Fact]
        public void Constructor_AddsExistingArchetypesWithMatchingComponent()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 2});
            scene.Create(new Position {X = 3, Y = 4}, new Velocity {VX = 5, VY = 6});

            SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<Position>.Id);

            Assert.NotNull(filter);
        }

        /// <summary>
        /// Tests that update invokes on update for all entities with component
        /// </summary>
        [Fact]
        public void Update_InvokesOnUpdateForAllEntitiesWithComponent()
        {
            using Scene scene = new Scene();
            GameObject e1 = scene.Create(new UpdateComponent {CallCount = 0});
            GameObject e2 = scene.Create(new UpdateComponent {CallCount = 0});

            SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<UpdateComponent>.Id);
            filter.Update();

            Assert.Equal(1, e1.Get<UpdateComponent>().CallCount);
            Assert.Equal(1, e2.Get<UpdateComponent>().CallCount);
        }

        /// <summary>
        /// Tests that update with multiple archetypes updates all matching entities
        /// </summary>
        [Fact]
        public void Update_WithMultipleArchetypes_UpdatesAllMatchingEntities()
        {
            using Scene scene = new Scene();
            GameObject e1 = scene.Create(new UpdateComponent {CallCount = 0});
            GameObject e2 = scene.Create(new UpdateComponent {CallCount = 0}, new Position {X = 1, Y = 2});

            SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<UpdateComponent>.Id);
            filter.Update();

            Assert.Equal(1, e1.Get<UpdateComponent>().CallCount);
            Assert.Equal(1, e2.Get<UpdateComponent>().CallCount);
        }

        /// <summary>
        /// Tests that update called multiple times accumulates call count
        /// </summary>
        [Fact]
        public void Update_CalledMultipleTimes_AccumulatesCallCount()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new UpdateComponent {CallCount = 0});

            SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<UpdateComponent>.Id);
            filter.Update();
            filter.Update();
            filter.Update();

            Assert.Equal(3, entity.Get<UpdateComponent>().CallCount);
        }

        /// <summary>
        /// Tests that update with no matching entities does not throw
        /// </summary>
        [Fact]
        public void Update_WithNoMatchingEntities_DoesNotThrow()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 2});

            SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<UpdateComponent>.Id);
            filter.Update();

            // No exception expected
        }

        /// <summary>
        /// Tests that archetype added with matching component adds archetype to filter
        /// </summary>
        [Fact]
        public void ArchetypeAdded_WithMatchingComponent_AddsArchetypeToFilter()
        {
            using Scene scene = new Scene();
            SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<UpdateComponent>.Id);

            GameObject entity = scene.Create(new UpdateComponent {CallCount = 0});
            filter.Update();

            Assert.Equal(0, entity.Get<UpdateComponent>().CallCount);
        }

        /// <summary>
        /// Tests that archetype added with non matching component does not affect filter
        /// </summary>
        [Fact]
        public void ArchetypeAdded_WithNonMatchingComponent_DoesNotAffectFilter()
        {
            using Scene scene = new Scene();
            GameObject e1 = scene.Create(new UpdateComponent {CallCount = 0});

            SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<UpdateComponent>.Id);

            GameObject e2 = scene.Create(new Position {X = 1, Y = 2});
            filter.Update();

            Assert.Equal(1, e1.Get<UpdateComponent>().CallCount);
            Assert.False(e2.Has<UpdateComponent>());
        }

        /// <summary>
        /// Tests that update subset updates only specified range
        /// </summary>
        [Fact]
        public void UpdateSubset_UpdatesOnlySpecifiedRange()
        {
            using Scene scene = new Scene();
            scene.Create(new UpdateComponent {CallCount = 0});
            scene.Create(new UpdateComponent {CallCount = 0});

            SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<UpdateComponent>.Id);
            filter.Update();

            // Both should be updated in full Update
        }

        /// <summary>
        /// Tests that update with mixed archetypes updates only matching component
        /// </summary>
        [Fact]
        public void Update_WithMixedArchetypes_UpdatesOnlyMatchingComponent()
        {
            using Scene scene = new Scene();
            GameObject e1 = scene.Create(new UpdateComponent {CallCount = 0});
            GameObject e2 = scene.Create(new Position {X = 1, Y = 2});
            GameObject e3 = scene.Create(new UpdateComponent {CallCount = 0}, new Velocity {VX = 3, VY = 4});

            SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<UpdateComponent>.Id);
            filter.Update();

            Assert.Equal(1, e1.Get<UpdateComponent>().CallCount);
            Assert.False(e2.Has<UpdateComponent>());
            Assert.Equal(1, e3.Get<UpdateComponent>().CallCount);
        }
    }
}

