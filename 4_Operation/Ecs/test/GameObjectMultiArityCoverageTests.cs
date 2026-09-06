// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectMultiArityCoverageTests.cs
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
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Coverage-focused tests for <see cref="GameObject" /> boxed and by-type structural
    ///     changes, per entity event emission and the multi-arity per entity event helpers.
    ///     The multi-arity add and remove unions are exercised by the pre-existing suite.
    /// </summary>
    public class GameObjectMultiArityCoverageTests
    {
        /// <summary>
        ///     Tests that <see cref="GameObject.AddBoxed(object)" /> and <see cref="GameObject.AddAs(Type, object)" />
        ///     add boxed components through their runtime type, explicit type and component id overloads.
        /// </summary>
        [Fact]
        public void AddBoxed_And_AddAs_AddComponents()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();

                entity.AddBoxed(new TestComponent {Value = 7, Name = "boxed"});
                Assert.Equal(7, entity.Get<TestComponent>().Value);

                entity.AddAs(typeof(Position), new Position {X = 3, Y = 4});
                Assert.Equal(3f, entity.Get<Position>().X);

                entity.AddAs(Component<Velocity>.Id, new Velocity {X = 5, Y = 6});
                Assert.Equal(5f, entity.Get<Velocity>().X);
            }
        }

        /// <summary>
        ///     Tests that <see cref="GameObject.AddAs(ComponentId, object)" />, <see cref="GameObject.Remove(ComponentId)" />
        ///     and <see cref="GameObject.Delete()" /> defer their structural changes while disallowed and apply on exit.
        /// </summary>
        [Fact]
        public void AddAs_RemoveByIdentity_Delete_WhileDisallowed_ApplyOnExit()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();
                entity.Add(new Position {X = 1, Y = 2});

                GameObject survivor = scene.Create();
                survivor.Add(new Position {X = 1, Y = 2});

                scene.EnterDisallowState();
                entity.AddAs(Component<Health>.Id, new Health {Value = 9});
                entity.Remove(Component<Position>.Id);
                entity.Delete();
                survivor.AddAs(Component<Health>.Id, new Health {Value = 9});
                survivor.Remove(Component<Position>.Id);
                scene.ExitDisallowState(null, false);

                Assert.False(entity.IsAlive);
                Assert.True(survivor.IsAlive);
                Assert.True(survivor.Has<Health>());
                Assert.False(survivor.Has<Position>());
            }
        }

        /// <summary>
        ///     Tests that accessing a component on a deleted <see cref="GameObject" /> throws
        ///     <see cref="InvalidOperationException" />.
        /// </summary>
        [Fact]
        public void Get_OnDeadEntity_ThrowsInvalidOperation()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();
                entity.Add(new Position {X = 1, Y = 2});
                entity.Delete();

                Assert.Throws<InvalidOperationException>(() => entity.Get<Position>());
            }
        }

        /// <summary>
        ///     Tests that per entity events fire on add and remove, that unsubscribing works and that
        ///     <see cref="GameObject.InitalizeEventRecord(object, GameObjectFlags, bool)" /> supports generic handlers.
        /// </summary>
        [Fact]
        public void Events_FireOnAddRemove_UnsubscribeAndInitalizeGeneric()
        {
            using (Scene scene = new Scene())
            {
                int added = 0;
                int removed = 0;
                int deleted = 0;

                GameObject addEntity = scene.Create();
                Action<GameObject, ComponentId> addHandler = (gameObject, componentId) => added++;
                addEntity.OnComponentAdded += addHandler;
                addEntity.Add(new Position {X = 1, Y = 2});
                Assert.Equal(1, added);
                Assert.True(addEntity.Has<Position>());
                Assert.Equal(1f, addEntity.Get<Position>().X);

                GameObject removeEntity = scene.Create();
                Action<GameObject, ComponentId> removeHandler = (gameObject, componentId) => removed++;
                removeEntity.OnComponentRemoved += removeHandler;
                removeEntity.Add(new Health {Value = 7});
                removeEntity.Remove<Health>();
                Assert.Equal(1, removed);
                Assert.False(removeEntity.Has<Health>());

                removeEntity.OnComponentRemoved -= removeHandler;

                GameObject deleteEntity = scene.Create();
                Action<GameObject> deleteHandler = gameObject => deleted++;
                deleteEntity.OnDelete += deleteHandler;
                deleteEntity.Delete();
                Assert.Equal(1, deleted);
                Assert.False(deleteEntity.IsAlive);

                GameObject filled = scene.Create();
                GenericEvent addGenericEvent = new GenericEvent();
                GenericEvent removeGenericEvent = new GenericEvent();
                filled.InitalizeEventRecord(addGenericEvent, GameObjectFlags.AddComp, true);
                filled.InitalizeEventRecord(removeGenericEvent, GameObjectFlags.RemoveComp, true);
            }
        }

        /// <summary>
        ///     Tests that the multi-arity per entity event helpers exit early when no generic
        ///     event handler is registered after firing the non generic listeners once per component.
        /// </summary>
        [Fact]
        public void InvokePerEntityEvents_AritiesTwoThroughEight_WithoutGenericEvent()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();

                int count = 0;
                ComponentEvent addEvents = new ComponentEvent();
                Action<GameObject, ComponentId> handler = (gameObject, componentId) => count++;
                addEvents.NormalEvent.Add(handler);
                Velocity velocity = new Velocity {X = 1, Y = 2};
                Health health = new Health {Value = 3};
                GameObject.InvokePerEntityEvents(entity, false, ref addEvents, ref velocity, ref health);
                Assert.Equal(2, count);

                count = 0;
                ComponentEvent threeEvents = new ComponentEvent();
                threeEvents.NormalEvent.Add(handler);
                Armor armor = new Armor {Value = 4};
                GameObject.InvokePerEntityEvents(entity, false, ref threeEvents, ref velocity, ref health, ref armor);
                Assert.Equal(3, count);

                count = 0;
                ComponentEvent fourEvents = new ComponentEvent();
                fourEvents.NormalEvent.Add(handler);
                Damage damage = new Damage {Value = 5};
                Transform transform = new Transform {X = 6, Y = 7, Rotation = 8};
                GameObject.InvokePerEntityEvents(entity, false, ref fourEvents, ref velocity, ref health, ref armor, ref damage);
                Assert.Equal(4, count);

                count = 0;
                ComponentEvent fiveEvents = new ComponentEvent();
                fiveEvents.NormalEvent.Add(handler);
                GameObject.InvokePerEntityEvents(entity, false, ref fiveEvents, ref velocity, ref health, ref armor, ref damage,
                    ref transform);
                Assert.Equal(5, count);

                count = 0;
                ComponentEvent sixEvents = new ComponentEvent();
                sixEvents.NormalEvent.Add(handler);
                TestComponent testComponent = new TestComponent {Value = 9, Name = "nine"};
                TestComponent2 testComponent2 = new TestComponent2 {Value = 10};
                AnotherComponent anotherComponent = new AnotherComponent {Name = "a", Data = 11, Y = 12};
                AnotherComponent2 anotherComponent2 = new AnotherComponent2 {Name = "b", Data = 13};
                GameObject.InvokePerEntityEvents(entity, false, ref sixEvents, ref testComponent, ref testComponent2,
                    ref anotherComponent, ref anotherComponent2, ref velocity, ref health);
                Assert.Equal(6, count);

                count = 0;
                ComponentEvent sevenEvents = new ComponentEvent();
                sevenEvents.NormalEvent.Add(handler);
                GameObject.InvokePerEntityEvents(entity, false, ref sevenEvents, ref testComponent, ref testComponent2,
                    ref anotherComponent, ref anotherComponent2, ref velocity, ref health, ref armor);
                Assert.Equal(7, count);

                count = 0;
                ComponentEvent eightEvents = new ComponentEvent();
                eightEvents.NormalEvent.Add(handler);
                GameObject.InvokePerEntityEvents(entity, false, ref eightEvents, ref testComponent, ref testComponent2,
                    ref anotherComponent, ref anotherComponent2, ref velocity, ref health, ref armor, ref damage);
                Assert.Equal(8, count);
            }
        }
    }
}