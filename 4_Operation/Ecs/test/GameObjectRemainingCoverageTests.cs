// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectRemainingCoverageTests.cs
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
using System.Collections.Generic;
using Alis.Core.Ecs.Exceptions;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    /// The game object remaining coverage tests class
    /// </summary>
    public class GameObjectRemainingCoverageTests
    {
        /// <summary>
        /// Tests that add when allow structual changes false deferred via command buffer
        /// </summary>
        [Fact] public void Add_WhenAllowStructualChangesFalse_DeferredViaCommandBuffer()
        {
            using (Scene scene = new Scene())
            {
                scene.EnterDisallowState();
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});

                entity.Add(new Velocity {X = 3, Y = 4});

                scene.ExitDisallowState(null);
                scene.Update();

                Assert.True(entity.Has<Velocity>());
                Assert.Equal(3, entity.Get<Velocity>().X);
            }
        }

        /// <summary>
        /// Tests that remove when allow structual changes false deferred via command buffer
        /// </summary>
        [Fact] public void Remove_WhenAllowStructualChangesFalse_DeferredViaCommandBuffer()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4});
                scene.EnterDisallowState();

                entity.Remove<Velocity>();

                scene.ExitDisallowState(null);
                scene.Update();

                Assert.False(entity.Has<Velocity>());
                Assert.True(entity.Has<Position>());
            }
        }

        /// <summary>
        /// Tests that add as when allow structual changes false deferred via command buffer
        /// </summary>
        [Fact] public void AddAs_WhenAllowStructualChangesFalse_DeferredViaCommandBuffer()
        {
            using (Scene scene = new Scene())
            {
                scene.EnterDisallowState();
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});

                entity.AddAs(Component<Velocity>.Id, new Velocity {X = 5, Y = 10});

                scene.ExitDisallowState(null);
                scene.Update();

                Assert.True(entity.Has<Velocity>());
                Assert.Equal(5, entity.Get<Velocity>().X);
            }
        }

        /// <summary>
        /// Tests that add as by type when allow structual changes false deferred
        /// </summary>
        [Fact] public void AddAs_ByType_WhenAllowStructualChangesFalse_Deferred()
        {
            using (Scene scene = new Scene())
            {
                scene.EnterDisallowState();
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});

                entity.AddAs(typeof(Velocity), new Velocity {X = 7, Y = 14});

                scene.ExitDisallowState(null);
                scene.Update();

                Assert.True(entity.Has<Velocity>());
                Assert.Equal(7, entity.Get<Velocity>().X);
            }
        }

        /// <summary>
        /// Tests that delete when allow structual changes false deferred via command buffer
        /// </summary>
        [Fact] public void Delete_WhenAllowStructualChangesFalse_DeferredViaCommandBuffer()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});
                scene.EnterDisallowState();

                entity.Delete();

                scene.ExitDisallowState(null);
                scene.Update();

                Assert.False(entity.IsAlive);
            }
        }

        /// <summary>
        /// Tests that has on dead entity throws invalid operation exception
        /// </summary>
        [Fact] public void Has_OnDeadEntity_ThrowsInvalidOperationException()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});
                entity.Delete();

                Assert.Throws<InvalidOperationException>(() => entity.Has<Position>());
            }
        }

        /// <summary>
        /// Tests that has with component id on dead entity throws invalid operation exception
        /// </summary>
        [Fact] public void Has_WithComponentId_OnDeadEntity_ThrowsInvalidOperationException()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});
                entity.Delete();

                Assert.Throws<InvalidOperationException>(() => entity.Has(Component<Position>.Id));
            }
        }

        /// <summary>
        /// Tests that has with type on dead entity throws invalid operation exception
        /// </summary>
        [Fact] public void Has_WithType_OnDeadEntity_ThrowsInvalidOperationException()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});
                entity.Delete();

                Assert.Throws<InvalidOperationException>(() => entity.Has(typeof(Position)));
            }
        }

        /// <summary>
        /// Tests that try get unsafe on dead entity throws invalid operation exception
        /// </summary>
        [Fact] public void TryGet_Unsafe_OnDeadEntity_ThrowsInvalidOperationException()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});
                entity.Delete();

                Assert.Throws<InvalidOperationException>(() => entity.TryGet(typeof(Position), out _));
            }
        }

        /// <summary>
        /// Tests that scene getter on dead entity returns scene
        /// </summary>
        [Fact] public void SceneGetter_OnDeadEntity_ReturnsScene()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});
                entity.Delete();

                Assert.Equal(scene, entity.Scene);
            }
        }

        /// <summary>
        /// Tests that component types on dead entity throws invalid operation exception
        /// </summary>
        [Fact] public void ComponentTypes_OnDeadEntity_ThrowsInvalidOperationException()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});
                entity.Delete();

                Assert.Throws<InvalidOperationException>(() => _ = entity.ComponentTypes);
            }
        }

        /// <summary>
        /// Tests that type on dead entity throws invalid operation exception
        /// </summary>
        [Fact] public void Type_OnDeadEntity_ThrowsInvalidOperationException()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});
                entity.Delete();

                Assert.Throws<InvalidOperationException>(() => _ = entity.Type);
            }
        }

        /// <summary>
        /// Tests that get by component id throws component not found exception when missing
        /// </summary>
        [Fact] public void Get_ByComponentId_ThrowsComponentNotFoundException_WhenMissing()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});

                Assert.Throws<ComponentNotFoundException>(() => entity.Get(Component<Velocity>.Id));
            }
        }

        /// <summary>
        /// Tests that get by type throws component not found exception when missing
        /// </summary>
        [Fact] public void Get_ByType_ThrowsComponentNotFoundException_WhenMissing()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});

                Assert.Throws<ComponentNotFoundException>(() => entity.Get(typeof(Velocity)));
            }
        }

        /// <summary>
        /// Tests that enumerate components with one component visits one
        /// </summary>
        [Fact] public void EnumerateComponents_WithOneComponent_VisitsOne()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});

                CountingGenericActionPlain counter = new CountingGenericActionPlain();
                entity.EnumerateComponents(counter);

                Assert.Equal(1, counter.CallCount);
            }
        }

        /// <summary>
        /// Tests that add with world event fires component added event
        /// </summary>
        [Fact] public void Add_WithWorldEvent_FiresComponentAddedEvent()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});

                List<ComponentId> addedIds = new List<ComponentId>();
                scene.ComponentAdded += (_, id) => addedIds.Add(id);

                entity.Add(new Velocity {X = 3, Y = 4});

                Assert.Contains(Component<Velocity>.Id, addedIds);
            }
        }

        /// <summary>
        /// Tests that remove with world event fires component removed event
        /// </summary>
        [Fact] public void Remove_WithWorldEvent_FiresComponentRemovedEvent()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4});

                List<ComponentId> removedIds = new List<ComponentId>();
                scene.ComponentRemoved += (_, id) => removedIds.Add(id);

                entity.Remove<Velocity>();

                Assert.Contains(Component<Velocity>.Id, removedIds);
            }
        }

        /// <summary>
        /// Tests that add with per entity event fires on component added
        /// </summary>
        [Fact] public void Add_WithPerEntityEvent_FiresOnComponentAdded()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});

                int calls = 0;
                entity.OnComponentAdded += (_, _) => calls++;

                entity.Add(new Velocity {X = 3, Y = 4});

                Assert.Equal(1, calls);
            }
        }

        /// <summary>
        /// Tests that remove with per entity event fires on component removed
        /// </summary>
        [Fact] public void Remove_WithPerEntityEvent_FiresOnComponentRemoved()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4});

                int calls = 0;
                entity.OnComponentRemoved += (_, _) => calls++;

                entity.Remove<Velocity>();

                Assert.Equal(1, calls);
            }
        }

        /// <summary>
        /// Tests that delete with per entity event fires on delete
        /// </summary>
        [Fact] public void Delete_WithPerEntityEvent_FiresOnDelete()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});

                int calls = 0;
                entity.OnDelete += (_) => calls++;

                entity.Delete();

                Assert.Equal(1, calls);
            }
        }

        /// <summary>
        /// Tests that add multi component with world event fires for each
        /// </summary>
        [Fact] public void Add_MultiComponent_WithWorldEvent_FiresForEach()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});

                List<ComponentId> addedIds = new List<ComponentId>();
                scene.ComponentAdded += (_, id) => addedIds.Add(id);

                entity.Add(new Velocity {X = 3, Y = 4});

                Assert.Single(addedIds);
            }
        }

        /// <summary>
        /// Tests that remove multi component with world event fires for each
        /// </summary>
        [Fact] public void Remove_MultiComponent_WithWorldEvent_FiresForEach()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5});

                List<ComponentId> removedIds = new List<ComponentId>();
                scene.ComponentRemoved += (_, id) => removedIds.Add(id);

                entity.Remove<Velocity>();

                Assert.Contains(Component<Velocity>.Id, removedIds);
            }
        }

        /// <summary>
        /// Tests that unsubscribe event when last listener removed clears flag
        /// </summary>
        [Fact] public void UnsubscribeEvent_WhenLastListenerRemoved_ClearsFlag()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});

                Action<GameObject, ComponentId> handler = (_, _) => { };
                entity.OnComponentAdded += handler;
                entity.OnComponentAdded -= handler;

                int calls = 0;
                entity.OnComponentAdded += (_, _) => calls++;
                entity.Add(new Velocity {X = 3, Y = 4});

                Assert.Equal(1, calls);
            }
        }

        /// <summary>
        /// Tests that unsubscribe event on delete when last listener removed clears flag
        /// </summary>
        [Fact] public void UnsubscribeEvent_OnDelete_WhenLastListenerRemoved_ClearsFlag()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});

                Action<GameObject> handler = (_) => { };
                entity.OnDelete += handler;
                entity.OnDelete -= handler;

                int calls = 0;
                entity.OnDelete += (_) => calls++;
                entity.Delete();

                Assert.Equal(1, calls);
            }
        }

        /// <summary>
        /// Tests that initalize event record for on delete adds handler
        /// </summary>
        [Fact] public void InitalizeEventRecord_ForOnDelete_AddsHandler()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});

                int calls = 0;
                entity.OnDelete += (_) => calls++;

                entity.Delete();

                Assert.Equal(1, calls);
            }
        }

        /// <summary>
        /// Tests that initalize event record for on component added generic adds generic handler
        /// </summary>
        [Fact] public void InitalizeEventRecord_ForOnComponentAddedGeneric_AddsGenericHandler()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});

                CountingGenericAction action = new CountingGenericAction();
                entity.OnComponentAddedGeneric += action;

                entity.Add(new Health {Value = 10});

                Assert.Equal(1, action.CallCount);
            }
        }

        /// <summary>
        /// Tests that initalize event record for on component removed generic adds generic handler
        /// </summary>
        [Fact] public void InitalizeEventRecord_ForOnComponentRemovedGeneric_AddsGenericHandler()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2}, new Health {Value = 10});

                CountingGenericAction action = new CountingGenericAction();
                entity.OnComponentRemovedGeneric += action;

                entity.Remove<Health>();

                Assert.Equal(1, action.CallCount);
            }
        }

        /// <summary>
        /// Tests that remove non generic by component id with allow structual changes false deferred
        /// </summary>
        [Fact] public void Remove_NonGeneric_ByComponentId_WithAllowStructualChangesFalse_Deferred()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4});
                scene.EnterDisallowState();

                entity.Remove(Component<Velocity>.Id);

                scene.ExitDisallowState(null);
                scene.Update();

                Assert.False(entity.Has<Velocity>());
                Assert.True(entity.Has<Position>());
            }
        }

        /// <summary>
        /// Tests that remove non generic by type with allow structual changes false deferred
        /// </summary>
        [Fact] public void Remove_NonGeneric_ByType_WithAllowStructualChangesFalse_Deferred()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4});
                scene.EnterDisallowState();

                entity.Remove(typeof(Velocity));

                scene.ExitDisallowState(null);
                scene.Update();

                Assert.False(entity.Has<Velocity>());
                Assert.True(entity.Has<Position>());
            }
        }

        /// <summary>
        /// Tests that add t 1 t 2 deferred when allow structual changes false
        /// </summary>
        [Fact] public void Add_T1T2_Deferred_WhenAllowStructualChangesFalse()
        {
            using (Scene scene = new Scene())
            {
                scene.EnterDisallowState();
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});

                entity.Add(new Velocity {X = 3, Y = 4}, new Health {Value = 5});

                scene.ExitDisallowState(null);
                scene.Update();

                Assert.True(entity.Has<Velocity>());
                Assert.True(entity.Has<Health>());
            }
        }

        
        /// <summary>
        /// Tests that remove t 1 t 2 deferred when allow structual changes false
        /// </summary>
        [Fact] public void Remove_T1T2_Deferred_WhenAllowStructualChangesFalse()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5});
                scene.EnterDisallowState();

                entity.Remove<Velocity, Health>();

                scene.ExitDisallowState(null);
                scene.Update();

                Assert.False(entity.Has<Velocity>());
                Assert.False(entity.Has<Health>());
                Assert.True(entity.Has<Position>());
            }
        }

        /// <summary>
        /// Tests that remove t 1 t 2 t 3 deferred when allow structual changes false
        /// </summary>
        [Fact] public void Remove_T1T2T3_Deferred_WhenAllowStructualChangesFalse()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(
                    new Position {X = 1, Y = 2},
                    new Velocity {X = 3, Y = 4},
                    new Health {Value = 5},
                    new Armor {Value = 6});
                scene.EnterDisallowState();

                entity.Remove<Velocity, Health, Armor>();

                scene.ExitDisallowState(null);
                scene.Update();

                Assert.False(entity.Has<Velocity>());
                Assert.False(entity.Has<Health>());
                Assert.False(entity.Has<Armor>());
                Assert.True(entity.Has<Position>());
            }
        }

        /// <summary>
        /// Tests that remove t 1 t 2 t 3 t 4 deferred when allow structual changes false
        /// </summary>
        [Fact] public void Remove_T1T2T3T4_Deferred_WhenAllowStructualChangesFalse()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(
                    new Position {X = 1, Y = 2},
                    new Velocity {X = 3, Y = 4},
                    new Health {Value = 5},
                    new Armor {Value = 6},
                    new Damage {Value = 7});
                scene.EnterDisallowState();

                entity.Remove<Velocity, Health, Armor, Damage>();

                scene.ExitDisallowState(null);
                scene.Update();

                Assert.False(entity.Has<Velocity>());
                Assert.False(entity.Has<Health>());
                Assert.False(entity.Has<Armor>());
                Assert.False(entity.Has<Damage>());
                Assert.True(entity.Has<Position>());
            }
        }

        /// <summary>
        /// Tests that remove t 1 t 2 t 3 t 4 t 5 deferred when allow structual changes false
        /// </summary>
        [Fact] public void Remove_T1T2T3T4T5_Deferred_WhenAllowStructualChangesFalse()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(
                    new Position {X = 1, Y = 2},
                    new Velocity {X = 3, Y = 4},
                    new Health {Value = 5},
                    new Armor {Value = 6},
                    new Damage {Value = 7},
                    new Transform {X = 8, Y = 9});
                scene.EnterDisallowState();

                entity.Remove<Velocity, Health, Armor, Damage, Transform>();

                scene.ExitDisallowState(null);
                scene.Update();

                Assert.False(entity.Has<Velocity>());
                Assert.False(entity.Has<Health>());
                Assert.False(entity.Has<Armor>());
                Assert.False(entity.Has<Damage>());
                Assert.False(entity.Has<Transform>());
                Assert.True(entity.Has<Position>());
            }
        }

        /// <summary>
        /// Tests that remove t 1 t 2 t 3 t 4 t 5 t 6 deferred when allow structual changes false
        /// </summary>
        [Fact] public void Remove_T1T2T3T4T5T6_Deferred_WhenAllowStructualChangesFalse()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(
                    new Position {X = 1, Y = 2},
                    new Velocity {X = 3, Y = 4},
                    new Health {Value = 5},
                    new Armor {Value = 6},
                    new Damage {Value = 7},
                    new Transform {X = 8, Y = 9},
                    new TestComponent {Value = 10});
                scene.EnterDisallowState();

                entity.Remove<Velocity, Health, Armor, Damage, Transform, TestComponent>();

                scene.ExitDisallowState(null);
                scene.Update();

                Assert.False(entity.Has<Velocity>());
                Assert.False(entity.Has<Health>());
                Assert.False(entity.Has<Armor>());
                Assert.False(entity.Has<Damage>());
                Assert.False(entity.Has<Transform>());
                Assert.False(entity.Has<TestComponent>());
                Assert.True(entity.Has<Position>());
            }
        }

        /// <summary>
        /// Tests that remove t 1 t 2 t 3 t 4 t 5 t 6 t 7 deferred when allow structual changes false
        /// </summary>
        [Fact] public void Remove_T1T2T3T4T5T6T7_Deferred_WhenAllowStructualChangesFalse()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(
                    new Position {X = 1, Y = 2},
                    new Velocity {X = 3, Y = 4},
                    new Health {Value = 5},
                    new Armor {Value = 6},
                    new Damage {Value = 7},
                    new Transform {X = 8, Y = 9},
                    new TestComponent {Value = 10});
                entity.Add(new AnotherComponent {Name = "a"});
                scene.EnterDisallowState();

                entity.Remove<Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent>();

                scene.ExitDisallowState(null);
                scene.Update();

                Assert.False(entity.Has<Velocity>());
                Assert.False(entity.Has<Health>());
                Assert.False(entity.Has<Armor>());
                Assert.False(entity.Has<Damage>());
                Assert.False(entity.Has<Transform>());
                Assert.False(entity.Has<TestComponent>());
                Assert.False(entity.Has<AnotherComponent>());
                Assert.True(entity.Has<Position>());
            }
        }

        
        /// <summary>
        /// Tests that invoke component world events arity 1 through add fires world event
        /// </summary>
        [Fact] public void InvokeComponentWorldEvents_Arity1_ThroughAdd_FiresWorldEvent()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});

                int calls = 0;
                scene.ComponentAdded += (_, _) => calls++;

                entity.Add(new Velocity {X = 3, Y = 4});

                Assert.Equal(1, calls);
            }
        }

        /// <summary>
        /// Tests that on component added then remove last listener event no longer fires
        /// </summary>
        [Fact] public void OnComponentAdded_ThenRemoveLastListener_EventNoLongerFires()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});

                int calls = 0;
                void Handler(GameObject _, ComponentId __) => calls++;

                entity.OnComponentAdded += Handler;
                entity.OnComponentAdded -= Handler;

                entity.Add(new Velocity {X = 3, Y = 4});

                Assert.Equal(0, calls);
            }
        }

        /// <summary>
        /// Tests that try get with type on entity without component returns false
        /// </summary>
        [Fact] public void TryGet_WithType_OnEntityWithoutComponent_ReturnsFalse()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});

                bool found = entity.TryGet(typeof(Velocity), out object value);

                Assert.False(found);
                Assert.Null(value);
            }
        }

        /// <summary>
        /// Tests that try get with type on entity with component returns true
        /// </summary>
        [Fact] public void TryGet_WithType_OnEntityWithComponent_ReturnsTrue()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});

                bool found = entity.TryGet(typeof(Position), out object value);

                Assert.True(found);
                Assert.IsType<Position>(value);
            }
        }

        /// <summary>
        /// Tests that get by type returns boxed component
        /// </summary>
        [Fact] public void Get_ByType_ReturnsBoxedComponent()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 5, Y = 10});

                object boxed = entity.Get(typeof(Position));

                Assert.IsType<Position>(boxed);
                Assert.Equal(5, ((Position) boxed).X);
                Assert.Equal(10, ((Position) boxed).Y);
            }
        }

        /// <summary>
        /// Tests that add as with component id when allow structual changes adds component
        /// </summary>
        [Fact] public void AddAs_WithComponentId_WhenAllowStructualChanges_AddsComponent()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});

                entity.AddAs(Component<Velocity>.Id, new Velocity {X = 10, Y = 20});

                Assert.True(entity.Has<Velocity>());
                Assert.Equal(10, entity.Get<Velocity>().X);
            }
        }

        /// <summary>
        /// Tests that add as with type when allow structual changes adds component
        /// </summary>
        [Fact] public void AddAs_WithType_WhenAllowStructualChanges_AddsComponent()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});

                entity.AddAs(typeof(Velocity), new Velocity {X = 15, Y = 25});

                Assert.True(entity.Has<Velocity>());
                Assert.Equal(15, entity.Get<Velocity>().X);
            }
        }

        /// <summary>
        /// The counting generic action class
        /// </summary>
        /// <seealso cref="IGenericAction{GameObject}"/>
        internal sealed class CountingGenericAction : IGenericAction<GameObject>
        {
            /// <summary>
            /// Gets or sets the value of the call count
            /// </summary>
            public int CallCount { get; private set; }

            /// <summary>
            /// Invokes the param
            /// </summary>
            /// <typeparam name="T">The </typeparam>
            /// <param name="param">The param</param>
            /// <param name="type">The type</param>
            public void Invoke<T>(GameObject param, ref T type)
            {
                CallCount++;
            }
        }

        /// <summary>
        /// The counting generic action plain class
        /// </summary>
        /// <seealso cref="IGenericAction"/>
        internal sealed class CountingGenericActionPlain : IGenericAction
        {
            /// <summary>
            /// Gets or sets the value of the call count
            /// </summary>
            public int CallCount { get; private set; }

            /// <summary>
            /// Invokes the type
            /// </summary>
            /// <typeparam name="T">The </typeparam>
            /// <param name="type">The type</param>
            public void Invoke<T>(ref T type)
            {
                CallCount++;
            }
        }
    }
}
