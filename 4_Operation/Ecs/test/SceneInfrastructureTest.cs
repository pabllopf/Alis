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
using Alis.Core.Ecs.Kernel;
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

        [Fact]
        public void Scene_CreateFromObjects_WithMultipleComponents_CreatesEntityWithAllComponents()
        {
            using Scene scene = new Scene();
            object[] components = [new Position {X = 1, Y = 2}, new Velocity {VX = 3, VY = 4}, new Health {Value = 5}];

            GameObject entity = scene.CreateFromObjects(components);

            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
        }

        [Fact]
        public void Scene_CreateFromObjects_WithEmptySpan_CreatesAliveEntity()
        {
            using Scene scene = new Scene();
            object[] components = [];

            GameObject entity = scene.CreateFromObjects(components);

            Assert.True(entity.IsAlive);
            Assert.Equal(1, scene.EntityCount);
        }

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

        [Fact]
        public void Scene_UpdateArchetypeTable_ResizesBackingArray()
        {
            using Scene scene = new Scene();
            int initialLength = scene.WorldArchetypeTable.Length;

            scene.UpdateArchetypeTable(initialLength + 8);

            Assert.Equal(initialLength + 8, scene.WorldArchetypeTable.Length);
        }

        [Fact]
        public void Scene_EnterAndExitDisallowState_TracksAllowStructuralChanges()
        {
            using Scene scene = new Scene();

            Assert.True(scene.AllowStructualChanges);

            scene.EnterDisallowState();
            Assert.False(scene.AllowStructualChanges);

            scene.ExitDisallowState(null, false);
            Assert.True(scene.AllowStructualChanges);
        }

        [Fact]
        public void Scene_EnterDisallowState_IsReentrantAndRequiresMatchingExits()
        {
            using Scene scene = new Scene();

            scene.EnterDisallowState();
            scene.EnterDisallowState();
            Assert.False(scene.AllowStructualChanges);

            scene.ExitDisallowState(null, false);
            Assert.False(scene.AllowStructualChanges);

            scene.ExitDisallowState(null, false);
            Assert.True(scene.AllowStructualChanges);
        }
    }
}

