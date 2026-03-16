// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneInfrastructureTest.cs
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
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Tests lower-level infrastructure behaviors in <see cref="Scene" />.
    /// </summary>
    public class SceneInfrastructureTest
    {
        /// <summary>
        ///     Tests that scene create from objects with single component creates entity with component
        /// </summary>
        [Fact]
        public void Scene_CreateFromObjects_WithSingleComponent_CreatesEntityWithComponent()
        {
            using Scene scene = new Scene();
            object[] components = [new Position {X = 9, Y = 11}];

            GameObject entity = scene.CreateFromObjects(components);

            Assert.True(entity.IsAlive);
            Assert.True(entity.Has<Position>());
            Position p = entity.Get<Position>();
            Assert.Equal(9, p.X);
            Assert.Equal(11, p.Y);
        }

        /// <summary>
        ///     Tests that scene create from objects with multiple components creates entity with all components
        /// </summary>
        [Fact]
        public void Scene_CreateFromObjects_WithMultipleComponents_CreatesEntityWithAllComponents()
        {
            using Scene scene = new Scene();
            object[] components = [new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}];

            GameObject entity = scene.CreateFromObjects(components);

            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
        }

        /// <summary>
        ///     Tests that scene create from objects with empty span creates alive entity
        /// </summary>
        [Fact]
        public void Scene_CreateFromObjects_WithEmptySpan_CreatesAliveEntity()
        {
            using Scene scene = new Scene();
            object[] components = [];

            GameObject entity = scene.CreateFromObjects(components);

            Assert.True(entity.IsAlive);
            Assert.Equal(1, scene.EntityCount);
        }

        /// <summary>
        ///     Tests that scene create from objects with more than 127 components throws argument exception
        /// </summary>
        [Fact]
        public void Scene_CreateFromObjects_WithMoreThan127Components_ThrowsArgumentException()
        {
            using Scene scene = new Scene();
            object[] components = new object[128];
            for (int i = 0; i < components.Length; i++)
            {
                components[i] = new TestComponent {Value = i};
            }

            Assert.Throws<ArgumentException>(() => scene.CreateFromObjects(components));
        }

        /// <summary>
        ///     Tests that scene custom query with same rules returns cached query instance
        /// </summary>
        [Fact]
        public void Scene_CustomQuery_WithSameRules_ReturnsCachedQueryInstance()
        {
            using Scene scene = new Scene();
            Rule withPosition = new With<Position>().Rule;
            Rule withVelocity = new With<Velocity>().Rule;

            Query q1 = scene.CustomQuery(withPosition, withVelocity);
            Query q2 = scene.CustomQuery(withPosition, withVelocity);

            Assert.Same(q1, q2);
        }

        /// <summary>
        ///     Tests that scene custom query with different rules returns different query instances
        /// </summary>
        [Fact]
        public void Scene_CustomQuery_WithDifferentRules_ReturnsDifferentQueryInstances()
        {
            using Scene scene = new Scene();
            Rule withPosition = new With<Position>().Rule;
            Rule withVelocity = new With<Velocity>().Rule;
            Rule withHealth = new With<Health>().Rule;

            Query q1 = scene.CustomQuery(withPosition, withVelocity);
            Query q2 = scene.CustomQuery(withPosition, withHealth);

            Assert.NotSame(q1, q2);
        }

        /// <summary>
        ///     Tests that scene invoke entity created invokes subscribers
        /// </summary>
        [Fact]
        public void Scene_InvokeEntityCreated_InvokesSubscribers()
        {
            using Scene scene = new Scene();
            bool invoked = false;
            scene.EntityCreated += _ => invoked = true;
            GameObject entity = scene.CreateEntityWithoutEvent();

            scene.InvokeEntityCreated(entity);

            Assert.True(invoked);
        }

        /// <summary>
        ///     Tests that scene update archetype table resizes backing array
        /// </summary>
        [Fact]
        public void Scene_UpdateArchetypeTable_ResizesBackingArray()
        {
            using Scene scene = new Scene();
            int initialLength = scene.WorldArchetypeTable.Length;

            scene.UpdateArchetypeTable(initialLength + 8);

            Assert.Equal(initialLength + 8, scene.WorldArchetypeTable.Length);
        }

        /// <summary>
        ///     Tests that scene enter and exit disallow state tracks allow structural changes
        /// </summary>
        [Fact]
        public void Scene_EnterAndExitDisallowState_TracksAllowStructuralChanges()
        {
            using Scene scene = new Scene();

            Assert.True(scene.AllowStructualChanges);

            scene.EnterDisallowState();
            Assert.False(scene.AllowStructualChanges);

            scene.ExitDisallowState(null);
            Assert.True(scene.AllowStructualChanges);
        }

        /// <summary>
        ///     Tests that scene enter disallow state is reentrant and requires matching exits
        /// </summary>
        [Fact]
        public void Scene_EnterDisallowState_IsReentrantAndRequiresMatchingExits()
        {
            using Scene scene = new Scene();

            scene.EnterDisallowState();
            scene.EnterDisallowState();
            Assert.False(scene.AllowStructualChanges);

            scene.ExitDisallowState(null);
            Assert.False(scene.AllowStructualChanges);

            scene.ExitDisallowState(null);
            Assert.True(scene.AllowStructualChanges);
        }

        /// <summary>
        ///     Tests that move entity to archetype iso keeps moved entity component values.
        /// </summary>
        [Fact]
        public void Scene_MoveEntityToArchetypeIso_PreservesMovedEntityComponents()
        {
            using Scene scene = new Scene();

            Archetype destination = CreateDestinationArchetype(scene);

            GameObject entity = scene.Create(
                new Position {X = 10, Y = 20},
                new Velocity {X = 3, Y = 4}
            );

            ref GameObjectLocation lookup = ref scene.EntityTable.UnsafeIndexNoResize(entity.EntityID);

            scene.MoveEntityToArchetypeIso(entity, ref lookup, destination);

            Position pos = entity.Get<Position>();
            Velocity vel = entity.Get<Velocity>();

            Assert.True(entity.IsAlive);
            Assert.Equal(10, pos.X);
            Assert.Equal(20, pos.Y);
            Assert.Equal(3, vel.X);
            Assert.Equal(4, vel.Y);
            Assert.True(entity.Has<Health>());
            Assert.Same(destination, lookup.Archetype);
        }

        /// <summary>
        ///     Tests that move entity to archetype iso keeps remaining source entities valid after compaction.
        /// </summary>
        [Fact]
        public void Scene_MoveEntityToArchetypeIso_KeepsOtherEntitiesValidAfterSourceCompaction()
        {
            using Scene scene = new Scene();
            Archetype destination = CreateDestinationArchetype(scene);

            GameObject moved = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {X = 5, Y = 6}
            );

            GameObject stays = scene.Create(
                new Position {X = 100, Y = 200},
                new Velocity {X = 7, Y = 8}
            );

            ref GameObjectLocation movedLookup = ref scene.EntityTable.UnsafeIndexNoResize(moved.EntityID);
            Archetype sourceArchetype = movedLookup.Archetype;

            scene.MoveEntityToArchetypeIso(moved, ref movedLookup, destination);

            // Accessing the second entity validates that source archetype compaction updated its location correctly.
            Position staysPos = stays.Get<Position>();
            Velocity staysVel = stays.Get<Velocity>();

            Assert.True(stays.IsAlive);
            Assert.Equal(100, staysPos.X);
            Assert.Equal(200, staysPos.Y);
            Assert.Equal(7, staysVel.X);
            Assert.Equal(8, staysVel.Y);
            Assert.Same(sourceArchetype, scene.EntityTable.UnsafeIndexNoResize(stays.EntityID).Archetype);
            Assert.Same(destination, scene.EntityTable.UnsafeIndexNoResize(moved.EntityID).Archetype);
        }

        /// <summary>
        ///     Creates the destination archetype using the specified scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <returns>The destination</returns>
        private static Archetype CreateDestinationArchetype(Scene scene)
        {
            GameObject seed = scene.Create(
                new Position {X = -1, Y = -1},
                new Velocity {X = -1, Y = -1},
                new Health {Value = -1}
            );

            Archetype destination = scene.EntityTable.UnsafeIndexNoResize(seed.EntityID).Archetype;
            seed.Delete();
            return destination;
        }
    }
}