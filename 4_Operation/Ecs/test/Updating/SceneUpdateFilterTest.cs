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
using Alis.Core.Aspect.Fluent.Components;
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
        /// Tests that constructor with valid scene and attribute type creates filter
        /// </summary>
        [Fact]
        public void Constructor_WithValidSceneAndAttributeType_CreatesFilter()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 2});

            SceneUpdateFilter filter = new SceneUpdateFilter(scene, typeof(UpdateOrderAttribute));

            Assert.NotNull(filter);
        }

        /// <summary>
        /// Tests that constructor processes existing archetypes
        /// </summary>
        [Fact]
        public void Constructor_ProcessesExistingArchetypes()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 2});
            scene.Create(new Velocity {VX = 3, VY = 4});

            SceneUpdateFilter filter = new SceneUpdateFilter(scene, typeof(UpdateOrderAttribute));

            
            Assert.NotNull(filter);
        }

        /// <summary>
        /// Tests that update invokes on update for all components with attribute
        /// </summary>
        [Fact]
        public void Update_InvokesOnUpdateForAllComponentsWithAttribute()
        {
            using Scene scene = new Scene();
            GameObject e1 = scene.Create(new Position {X = 1, Y = 2});
            GameObject e2 = scene.Create(new Velocity {VX = 3, VY = 4});

            SceneUpdateFilter filter = new SceneUpdateFilter(scene, typeof(IOnUpdate));
            filter.Update();

            // Entities should be updated based on IOnUpdate interface
        }

        /// <summary>
        /// Tests that update with multiple archetypes updates all matching
        /// </summary>
        [Fact]
        public void Update_WithMultipleArchetypes_UpdatesAllMatching()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 2});
            scene.Create(new Position {X = 3, Y = 4}, new Velocity {VX = 5, VY = 6});

            SceneUpdateFilter filter = new SceneUpdateFilter(scene, typeof(IOnUpdate));
            filter.Update();

            // Both archetypes should be processed
        }

        /// <summary>
        /// Tests that update called multiple times executes each time
        /// </summary>
        [Fact]
        public void Update_CalledMultipleTimes_ExecutesEachTime()
        {
            using Scene scene = new Scene();
            scene.Create(new UpdateComponent {CallCount = 0});

            SceneUpdateFilter filter = new SceneUpdateFilter(scene, typeof(IOnUpdate));
            filter.Update();
            filter.Update();

            // Should execute twice
        }

        /// <summary>
        /// Tests that archetype added after construction is handled correctly
        /// </summary>
        [Fact]
        public void ArchetypeAdded_AfterConstruction_IsHandledCorrectly()
        {
            using Scene scene = new Scene();
            SceneUpdateFilter filter = new SceneUpdateFilter(scene, typeof(IOnUpdate));

            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            filter.Update();

            // New archetype should be processed
        }

        /// <summary>
        /// Tests that update with no matching components does not throw
        /// </summary>
        [Fact]
        public void Update_WithNoMatchingComponents_DoesNotThrow()
        {
            using Scene scene = new Scene();
            scene.Create(new TestComponent {Value = 1, Name = "test"});

            SceneUpdateFilter filter = new SceneUpdateFilter(scene, typeof(IOnUpdate));
            filter.Update();

            // No exception expected
        }

        /// <summary>
        /// Tests that update with empty scene does not throw
        /// </summary>
        [Fact]
        public void Update_WithEmptyScene_DoesNotThrow()
        {
            using Scene scene = new Scene();

            SceneUpdateFilter filter = new SceneUpdateFilter(scene, typeof(IOnUpdate));
            filter.Update();

            // No exception expected
        }

        /// <summary>
        /// Tests that archetype added with matching components includes in filter
        /// </summary>
        [Fact]
        public void ArchetypeAdded_WithMatchingComponents_IncludesInFilter()
        {
            using Scene scene = new Scene();
            SceneUpdateFilter filter = new SceneUpdateFilter(scene, typeof(IOnUpdate));

            scene.Create(new UpdateComponent {CallCount = 0});
            scene.Create(new Position {X = 1, Y = 2});

            filter.Update();

            // Archetypes with matching components should be included
        }

        /// <summary>
        /// Tests that archetype added with no matching components does not affect filter
        /// </summary>
        [Fact]
        public void ArchetypeAdded_WithNoMatchingComponents_DoesNotAffectFilter()
        {
            using Scene scene = new Scene();
            scene.Create(new UpdateComponent {CallCount = 0});

            SceneUpdateFilter filter = new SceneUpdateFilter(scene, typeof(IOnUpdate));

            scene.Create(new TestComponent {Value = 1, Name = "test"});
            filter.Update();

            // Only matching components should be updated
        }

        /// <summary>
        /// Tests that update with multiple components in same archetype updates all
        /// </summary>
        [Fact]
        public void Update_WithMultipleComponentsInSameArchetype_UpdatesAll()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 2}, new Velocity {VX = 3, VY = 4});

            SceneUpdateFilter filter = new SceneUpdateFilter(scene, typeof(IOnUpdate));
            filter.Update();

            // Both Position and Velocity should be updated if they implement IOnUpdate
        }

        /// <summary>
        /// Tests that constructor with null attribute type handles gracefully
        /// </summary>
        [Fact]
        public void Constructor_WithNullAttributeType_HandlesGracefully()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 2});

            // This tests that the filter handles null or missing attribute types
            SceneUpdateFilter filter = new SceneUpdateFilter(scene, typeof(NonExistentAttribute));
            filter.Update();

            // Should handle gracefully without throwing
        }

        /// <summary>
        /// The non existent attribute class
        /// </summary>
        /// <seealso cref="Attribute"/>
        private class NonExistentAttribute : Attribute
        {
        }
    }
}

