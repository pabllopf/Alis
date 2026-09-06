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
    ///     Coverage-focused tests for the multi-arity structural change and event
    ///     invocation paths of <see cref="GameObject" />.
    /// </summary>
    public class GameObjectMultiArityCoverageTests
    {
        /// <summary>
        ///     Pre-creates every multi-arity union used by these tests so that first-touch global
        ///     archetype creation happens in a single sequential block at class load.
        /// </summary>
        static GameObjectMultiArityCoverageTests()
        {
            Prewarm();
        }

        /// <summary>
        ///     Creates and removes each component union exercised by these tests on a throwaway
        ///     entity so the global archetype tables are warmed deterministically.
        /// </summary>
        private static void Prewarm()
        {
            GameObject pre = scene.Create();

            pre.Add(new Position {X = 1, Y = 2});
            pre.Remove<Position>();

            pre.Add(new Velocity {X = 1, Y = 2}, new Health {Value = 3});
            pre.Remove<Velocity, Health>();

            pre.Add(new Armor {Value = 4}, new Damage {Value = 5}, new Transform {X = 6, Y = 7, Rotation = 8});
            pre.Remove<Armor, Damage, Transform>();

            pre.Add(new TestComponent {Value = 1, Name = "a"}, new TestComponent2 {Value = 2},
                new AnotherComponent {Name = "b", Data = 3, Y = 4}, new AnotherComponent2 {Name = "c", Data = 5});
            pre.Remove<TestComponent, TestComponent2, AnotherComponent, AnotherComponent2>();

            pre.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 10},
                new Armor {Value = 20}, new Damage {Value = 30});
            pre.Remove<Position, Velocity, Health, Armor, Damage>();

            pre.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 10},
                new Armor {Value = 20}, new Damage {Value = 30}, new Transform {X = 40, Y = 50, Rotation = 60});
            pre.Remove<Position, Velocity, Health, Armor, Damage, Transform>();

            pre.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 10},
                new Armor {Value = 20}, new Damage {Value = 30}, new Transform {X = 40, Y = 50, Rotation = 60},
                new TestComponent {Value = 7, Name = "seven"});
            pre.Remove<Position, Velocity, Health, Armor, Damage, Transform, TestComponent>();

            pre.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 10},
                new Armor {Value = 20}, new Damage {Value = 30}, new Transform {X = 40, Y = 50, Rotation = 60},
                new TestComponent {Value = 7, Name = "seven"}, new AnotherComponent2 {Name = "eight", Data = 8});
            pre.Remove<Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent2>();
        }
        private static readonly Scene scene = new Scene();
        /// <summary>
        ///     Tests that multi-arity <see cref="GameObject.Add{T1,T2}" /> style calls add every
        ///     component and fire both the world and per entity listeners for arities 1 through 8.
        /// </summary>
        [Fact]
        public void Add_AritiesOneThroughEight_FireWorldAndEntityListeners()
        {
            {
                int worldCount = 0;
                int entityCount = 0;
                Action<GameObject, ComponentId> worldHandler = (gameObject, componentId) => worldCount++;
                Action<GameObject, ComponentId> entityHandler = (gameObject, componentId) => entityCount++;
                scene.ComponentAddedEvent.Add(worldHandler);

                GameObject e1 = scene.Create();
                e1.OnComponentAdded += entityHandler;
                e1.Add(new Position {X = 1, Y = 2});
                Assert.Equal(1f, e1.Get<Position>().X);

                GameObject e2 = scene.Create();
                e2.OnComponentAdded += entityHandler;
                e2.Add(new Velocity {X = 3, Y = 4}, new Health {Value = 10});
                Assert.Equal(3f, e2.Get<Velocity>().X);
                Assert.Equal(10, e2.Get<Health>().Value);

                GameObject e3 = scene.Create();
                e3.OnComponentAdded += entityHandler;
                e3.Add(new Armor {Value = 20}, new Damage {Value = 30}, new Transform {X = 40, Y = 50, Rotation = 60});
                Assert.Equal(20, e3.Get<Armor>().Value);
                Assert.Equal(30, e3.Get<Damage>().Value);
                Assert.Equal(40f, e3.Get<Transform>().X);

                GameObject e4 = scene.Create();
                e4.OnComponentAdded += entityHandler;
                e4.Add(new TestComponent {Value = 1, Name = "a"}, new TestComponent2 {Value = 2},
                    new AnotherComponent {Name = "b", Data = 3, Y = 4}, new AnotherComponent2 {Name = "c", Data = 5});
                Assert.Equal(1, e4.Get<TestComponent>().Value);
                Assert.Equal(2, e4.Get<TestComponent2>().Value);
                Assert.Equal(3f, e4.Get<AnotherComponent>().Data);
                Assert.Equal(5, e4.Get<AnotherComponent2>().Data);

                GameObject e5 = scene.Create();
                e5.OnComponentAdded += entityHandler;
                e5.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 10},
                    new Armor {Value = 20}, new Damage {Value = 30});
                Assert.True(e5.Has<Damage>());

                GameObject e6 = scene.Create();
                e6.OnComponentAdded += entityHandler;
                e6.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 10},
                    new Armor {Value = 20}, new Damage {Value = 30}, new Transform {X = 40, Y = 50, Rotation = 60});
                Assert.True(e6.Has<Transform>());

                GameObject e7 = scene.Create();
                e7.OnComponentAdded += entityHandler;
                e7.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 10},
                    new Armor {Value = 20}, new Damage {Value = 30}, new Transform {X = 40, Y = 50, Rotation = 60},
                    new TestComponent {Value = 7, Name = "seven"});
                Assert.True(e7.Has<TestComponent>());

                GameObject e8 = scene.Create();
                e8.OnComponentAdded += entityHandler;
                e8.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 10},
                    new Armor {Value = 20}, new Damage {Value = 30}, new Transform {X = 40, Y = 50, Rotation = 60},
                    new TestComponent {Value = 7, Name = "seven"}, new AnotherComponent2 {Name = "eight", Data = 8});
                Assert.True(e8.Has<AnotherComponent2>());
                Assert.Equal(8, e8.Get<AnotherComponent2>().Data);

                Assert.Equal(36, worldCount);
                Assert.Equal(8, entityCount);
            }
        }

        /// <summary>
        ///     Tests that multi-arity <see cref="GameObject.Remove{T1,T2}" /> style calls remove
        ///     every component for arities 1 through 8.
        /// </summary>
        [Fact]
        public void Remove_AritiesOneThroughEight_RemoveEveryComponent()
        {
            {
                GameObject e1 = scene.Create();
                e1.Add(new Position {X = 1, Y = 2});
                e1.Remove<Position>();
                Assert.False(e1.Has<Position>());

                GameObject e2 = scene.Create();
                e2.Add(new Velocity {X = 3, Y = 4}, new Health {Value = 10});
                e2.Remove<Velocity, Health>();
                Assert.False(e2.Has<Velocity>());
                Assert.False(e2.Has<Health>());

                GameObject e3 = scene.Create();
                e3.Add(new Armor {Value = 20}, new Damage {Value = 30}, new Transform {X = 40, Y = 50, Rotation = 60});
                e3.Remove<Armor, Damage, Transform>();
                Assert.False(e3.Has<Armor>());
                Assert.False(e3.Has<Transform>());

                GameObject e4 = scene.Create();
                e4.Add(new TestComponent {Value = 1, Name = "a"}, new TestComponent2 {Value = 2},
                    new AnotherComponent {Name = "b", Data = 3, Y = 4}, new AnotherComponent2 {Name = "c", Data = 5});
                e4.Remove<TestComponent, TestComponent2, AnotherComponent, AnotherComponent2>();
                Assert.False(e4.Has<TestComponent>());
                Assert.False(e4.Has<AnotherComponent2>());

                GameObject e5 = scene.Create();
                e5.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 10},
                    new Armor {Value = 20}, new Damage {Value = 30});
                e5.Remove<Position, Velocity, Health, Armor, Damage>();
                Assert.False(e5.Has<Position>());
                Assert.False(e5.Has<Damage>());

                GameObject e6 = scene.Create();
                e6.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 10},
                    new Armor {Value = 20}, new Damage {Value = 30}, new Transform {X = 40, Y = 50, Rotation = 60});
                e6.Remove<Position, Velocity, Health, Armor, Damage, Transform>();
                Assert.False(e6.Has<Transform>());

                GameObject e7 = scene.Create();
                e7.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 10},
                    new Armor {Value = 20}, new Damage {Value = 30}, new Transform {X = 40, Y = 50, Rotation = 60},
                    new TestComponent {Value = 7, Name = "seven"});
                e7.Remove<Position, Velocity, Health, Armor, Damage, Transform, TestComponent>();
                Assert.False(e7.Has<TestComponent>());

                GameObject e8 = scene.Create();
                e8.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 10},
                    new Armor {Value = 20}, new Damage {Value = 30}, new Transform {X = 40, Y = 50, Rotation = 60},
                    new TestComponent {Value = 7, Name = "seven"}, new AnotherComponent2 {Name = "eight", Data = 8});
                e8.Remove<Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent2>();
                Assert.False(e8.Has<Position>());
                Assert.False(e8.Has<AnotherComponent2>());
            }
        }

        /// <summary>
        ///     Tests that multi-arity <see cref="GameObject.Add{T1,T2}" /> style calls made while
        ///     structural changes are disallowed are queued and applied on exit.
        /// </summary>
        [Fact]
        public void Add_WhileDisallowed_AppliesWhenStructuralChangesResume()
        {
            {
                GameObject e1 = scene.Create();
                GameObject e2 = scene.Create();
                GameObject e3 = scene.Create();
                GameObject e4 = scene.Create();
                GameObject e5 = scene.Create();
                GameObject e6 = scene.Create();
                GameObject e7 = scene.Create();
                GameObject e8 = scene.Create();

                scene.EnterDisallowState();
                e1.Add(new Position {X = 1, Y = 2});
                e2.Add(new Velocity {X = 3, Y = 4}, new Health {Value = 10});
                e3.Add(new Armor {Value = 20}, new Damage {Value = 30}, new Transform {X = 40, Y = 50, Rotation = 60});
                e4.Add(new TestComponent {Value = 1, Name = "a"}, new TestComponent2 {Value = 2},
                    new AnotherComponent {Name = "b", Data = 3, Y = 4}, new AnotherComponent2 {Name = "c", Data = 5});
                e5.Add(new Position {X = 5, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 10},
                    new Armor {Value = 20}, new Damage {Value = 30});
                e6.Add(new Position {X = 6, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 10},
                    new Armor {Value = 20}, new Damage {Value = 30}, new Transform {X = 40, Y = 50, Rotation = 60});
                e7.Add(new Position {X = 7, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 10},
                    new Armor {Value = 20}, new Damage {Value = 30}, new Transform {X = 40, Y = 50, Rotation = 60},
                    new TestComponent {Value = 7, Name = "seven"});
                e8.Add(new Position {X = 8, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 10},
                    new Armor {Value = 20}, new Damage {Value = 30}, new Transform {X = 40, Y = 50, Rotation = 60},
                    new TestComponent {Value = 7, Name = "seven"}, new AnotherComponent2 {Name = "eight", Data = 8});
                scene.ExitDisallowState(null, false);

                Assert.Equal(1f, e1.Get<Position>().X);
                Assert.True(e2.Has<Velocity>());
                Assert.True(e2.Has<Health>());
                Assert.True(e3.Has<Transform>());
                Assert.True(e4.Has<AnotherComponent2>());
                Assert.True(e5.Has<Damage>());
                Assert.True(e6.Has<Transform>());
                Assert.True(e7.Has<TestComponent>());
                Assert.Equal(8, e8.Get<Position>().X);
                Assert.True(e8.Has<AnotherComponent2>());
            }
        }

        /// <summary>
        ///     Tests that multi-arity <see cref="GameObject.Remove{T1,T2}" /> style calls made while
        ///     structural changes are disallowed are queued and applied on exit.
        /// </summary>
        [Fact]
        public void Remove_WhileDisallowed_AppliesWhenStructuralChangesResume()
        {
            {
                GameObject e1 = scene.Create();
                e1.Add(new Position {X = 1, Y = 2});
                GameObject e2 = scene.Create();
                e2.Add(new Velocity {X = 3, Y = 4}, new Health {Value = 10});
                GameObject e3 = scene.Create();
                e3.Add(new Armor {Value = 20}, new Damage {Value = 30}, new Transform {X = 40, Y = 50, Rotation = 60});
                GameObject e4 = scene.Create();
                e4.Add(new TestComponent {Value = 1, Name = "a"}, new TestComponent2 {Value = 2},
                    new AnotherComponent {Name = "b", Data = 3, Y = 4}, new AnotherComponent2 {Name = "c", Data = 5});
                GameObject e5 = scene.Create();
                e5.Add(new Position {X = 5, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 10},
                    new Armor {Value = 20}, new Damage {Value = 30});
                GameObject e6 = scene.Create();
                e6.Add(new Position {X = 6, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 10},
                    new Armor {Value = 20}, new Damage {Value = 30}, new Transform {X = 40, Y = 50, Rotation = 60});
                GameObject e7 = scene.Create();
                e7.Add(new Position {X = 7, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 10},
                    new Armor {Value = 20}, new Damage {Value = 30}, new Transform {X = 40, Y = 50, Rotation = 60},
                    new TestComponent {Value = 7, Name = "seven"});
                GameObject e8 = scene.Create();
                e8.Add(new Position {X = 8, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 10},
                    new Armor {Value = 20}, new Damage {Value = 30}, new Transform {X = 40, Y = 50, Rotation = 60},
                    new TestComponent {Value = 7, Name = "seven"}, new AnotherComponent2 {Name = "eight", Data = 8});

                scene.EnterDisallowState();
                e1.Remove<Position>();
                e2.Remove<Velocity, Health>();
                e3.Remove<Armor, Damage, Transform>();
                e4.Remove<TestComponent, TestComponent2, AnotherComponent, AnotherComponent2>();
                e5.Remove<Position, Velocity, Health, Armor, Damage>();
                e6.Remove<Position, Velocity, Health, Armor, Damage, Transform>();
                e7.Remove<Position, Velocity, Health, Armor, Damage, Transform, TestComponent>();
                e8.Remove<Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent2>();
                scene.ExitDisallowState(null, false);

                Assert.False(e1.Has<Position>());
                Assert.False(e2.Has<Velocity>());
                Assert.False(e2.Has<Health>());
                Assert.False(e3.Has<Transform>());
                Assert.False(e4.Has<AnotherComponent2>());
                Assert.False(e5.Has<Damage>());
                Assert.False(e6.Has<Transform>());
                Assert.False(e7.Has<TestComponent>());
                Assert.False(e8.Has<Position>());
                Assert.False(e8.Has<AnotherComponent2>());
            }
        }

        /// <summary>
        ///     Tests that <see cref="GameObject.AddBoxed(object)" /> and <see cref="GameObject.AddAs(Type, object)" />
        ///     add boxed components through their runtime type, explicit type and component id overloads.
        /// </summary>
        [Fact]
        public void AddBoxed_And_AddAs_AddComponents()
        {
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