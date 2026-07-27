// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectTests.cs
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
    ///     Deep coverage tests for GameObject uncovered paths.
    /// </summary>
    public class GameObjectTests
    {
        [Fact] public void Set_ByComponentId_WhenMissing_ThrowsComponentNotFoundException()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            Assert.Throws<ComponentNotFoundException>(() => entity.Set(Component<Velocity>.Id, new Velocity {X = 3, Y = 4}));
        }

        [Fact] public void Set_ByType_WhenMissing_ThrowsComponentNotFoundException()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            Assert.Throws<ComponentNotFoundException>(() => entity.Set(typeof(Velocity), new Velocity {X = 3, Y = 4}));
        }

        [Fact] public void Delete_OnAlreadyDeletedEntity_DoesNotThrow()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            entity.Delete();
            Exception ex = Record.Exception(() => entity.Delete());
            Assert.Null(ex);
        }

        [Fact] public void Delete_OnAlreadyDeletedEntity_ReturnsIsAliveFalse()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            entity.Delete();
            entity.Delete();
            Assert.False(entity.IsAlive);
        }

        [Fact] public void Add_Arity2_WithWorldEvent_FiresForBothComponents()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            List<ComponentId> addedIds = new List<ComponentId>();
            scene.ComponentAdded += (go, id) => addedIds.Add(id);

            entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4});

            Assert.Contains(Component<Position>.Id, addedIds);
            Assert.Contains(Component<Velocity>.Id, addedIds);
        }

        [Fact] public void Add_Arity3_WithWorldEvent_FiresForAllComponents()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            List<ComponentId> addedIds = new List<ComponentId>();
            scene.ComponentAdded += (go, id) => addedIds.Add(id);

            entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5});

            Assert.Contains(Component<Position>.Id, addedIds);
            Assert.Contains(Component<Velocity>.Id, addedIds);
            Assert.Contains(Component<Health>.Id, addedIds);
        }

        [Fact] public void Add_Arity4_WithWorldEvent_FiresForAllComponents()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            List<ComponentId> addedIds = new List<ComponentId>();
            scene.ComponentAdded += (go, id) => addedIds.Add(id);

            entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6});

            Assert.Contains(Component<Position>.Id, addedIds);
            Assert.Contains(Component<Velocity>.Id, addedIds);
            Assert.Contains(Component<Health>.Id, addedIds);
            Assert.Contains(Component<Armor>.Id, addedIds);
        }

        [Fact] public void Add_Arity5_WithWorldEvent_FiresForAllComponents()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            List<ComponentId> addedIds = new List<ComponentId>();
            scene.ComponentAdded += (go, id) => addedIds.Add(id);

            entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6}, new Damage {Value = 7});

            Assert.Equal(5, addedIds.Count);
            Assert.Contains(Component<Position>.Id, addedIds);
            Assert.Contains(Component<Damage>.Id, addedIds);
        }

        [Fact] public void Add_Arity6_WithWorldEvent_FiresForAllComponents()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            List<ComponentId> addedIds = new List<ComponentId>();
            scene.ComponentAdded += (go, id) => addedIds.Add(id);

            entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6}, new Damage {Value = 7}, new Transform {X = 8, Y = 9});

            Assert.Equal(6, addedIds.Count);
            Assert.Contains(Component<Transform>.Id, addedIds);
        }

        [Fact] public void Add_Arity7_WithWorldEvent_FiresForAllComponents()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            List<ComponentId> addedIds = new List<ComponentId>();
            scene.ComponentAdded += (go, id) => addedIds.Add(id);

            entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6}, new Damage {Value = 7}, new Transform {X = 8, Y = 9}, new TestComponent {Value = 10});

            Assert.Equal(7, addedIds.Count);
            Assert.Contains(Component<TestComponent>.Id, addedIds);
        }

        [Fact] public void Add_Arity8_WithWorldEvent_FiresForAllComponents()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            List<ComponentId> addedIds = new List<ComponentId>();
            scene.ComponentAdded += (go, id) => addedIds.Add(id);

            entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6}, new Damage {Value = 7}, new Transform {X = 8, Y = 9}, new TestComponent {Value = 10}, new AnotherComponent {Name = "a", Data = 11, Y = 12});

            Assert.Equal(8, addedIds.Count);
            Assert.Contains(Component<AnotherComponent>.Id, addedIds);
        }

        [Fact] public void OnComponentAdded_SubscribeAndUnsubscribe_ClearsFlagProperly()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            void Handler(GameObject _, ComponentId __) { }

            entity.OnComponentAdded += Handler;
            entity.OnComponentAdded -= Handler;

            Assert.True(entity.Has<Position>());
        }

        [Fact] public void OnComponentRemoved_SubscribeAndUnsubscribe_ClearsFlagProperly()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4});

            void Handler(GameObject _, ComponentId __) { }

            entity.OnComponentRemoved += Handler;
            entity.OnComponentRemoved -= Handler;

            Assert.True(entity.Has<Position>());
        }

        [Fact] public void Add_Arity2_WithPerEntityNormalEvent_FiresForFirstComponent()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            int calls = 0;
            entity.OnComponentAdded += (go, id) => calls++;

            entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4});

            Assert.Equal(1, calls);
        }

        [Fact] public void Add_Arity3_WithPerEntityNormalEvent_FiresForFirstComponent()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            int calls = 0;
            entity.OnComponentAdded += (go, id) => calls++;

            entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5});

            Assert.Equal(1, calls);
        }

        [Fact] public void Add_Arity4_WithPerEntityNormalEvent_FiresForFirstComponent()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            int calls = 0;
            entity.OnComponentAdded += (go, id) => calls++;

            entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6});

            Assert.Equal(1, calls);
        }

        [Fact] public void Add_Arity5_WithPerEntityNormalEvent_FiresForFirstComponent()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            int calls = 0;
            entity.OnComponentAdded += (go, id) => calls++;

            entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6}, new Damage {Value = 7});

            Assert.Equal(1, calls);
        }

        [Fact] public void Add_Arity6_WithPerEntityNormalEvent_FiresForFirstComponent()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            int calls = 0;
            entity.OnComponentAdded += (go, id) => calls++;

            entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6}, new Damage {Value = 7}, new Transform {X = 8, Y = 9});

            Assert.Equal(1, calls);
        }

        [Fact] public void Add_Arity7_WithPerEntityNormalEvent_FiresForFirstComponent()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            int calls = 0;
            entity.OnComponentAdded += (go, id) => calls++;

            entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6}, new Damage {Value = 7}, new Transform {X = 8, Y = 9}, new TestComponent {Value = 10});

            Assert.Equal(1, calls);
        }

        [Fact] public void Add_Arity8_WithPerEntityNormalEvent_FiresForFirstComponent()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            int calls = 0;
            entity.OnComponentAdded += (go, id) => calls++;

            entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6}, new Damage {Value = 7}, new Transform {X = 8, Y = 9}, new TestComponent {Value = 10}, new AnotherComponent {Name = "a", Data = 11, Y = 12});

            Assert.Equal(1, calls);
        }

        [Fact] public void Remove_Arity2_AllowStructualChangesTrue_RemovesBoth()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4});

            entity.Remove<Position, Velocity>();

            Assert.False(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
        }

        [Fact] public void Remove_Arity3_AllowStructualChangesTrue_RemovesAll()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5});

            entity.Remove<Position, Velocity, Health>();

            Assert.False(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
        }

        [Fact] public void Remove_Arity4_AllowStructualChangesTrue_RemovesAll()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6});

            entity.Remove<Position, Velocity, Health, Armor>();

            Assert.False(entity.Has<Position>());
            Assert.False(entity.Has<Armor>());
        }

        [Fact] public void Remove_Arity5_AllowStructualChangesTrue_RemovesAll()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6}, new Damage {Value = 7});

            entity.Remove<Position, Velocity, Health, Armor, Damage>();

            Assert.False(entity.Has<Position>());
            Assert.False(entity.Has<Damage>());
        }

        [Fact] public void Remove_Arity6_AllowStructualChangesTrue_RemovesAll()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6}, new Damage {Value = 7}, new Transform {X = 8, Y = 9});

            entity.Remove<Position, Velocity, Health, Armor, Damage, Transform>();

            Assert.False(entity.Has<Position>());
            Assert.False(entity.Has<Transform>());
        }

        [Fact] public void Remove_Arity7_AllowStructualChangesTrue_RemovesAll()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6}, new Damage {Value = 7}, new Transform {X = 8, Y = 9}, new TestComponent {Value = 10});

            entity.Remove<Position, Velocity, Health, Armor, Damage, Transform, TestComponent>();

            Assert.False(entity.Has<Position>());
            Assert.False(entity.Has<TestComponent>());
        }

        [Fact] public void Remove_Arity8_AllowStructualChangesTrue_RemovesAll()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6}, new Damage {Value = 7}, new Transform {X = 8, Y = 9}, new TestComponent {Value = 10});

            entity.Add(new AnotherComponent {Name = "x"});

            entity.Remove<Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent>();

            Assert.False(entity.Has<Position>());
            Assert.False(entity.Has<AnotherComponent>());
        }

        [Fact] public void InvokePerEntityEvents_Arity1_HasGenericFalse_DoesNotThrow()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            ComponentEvent ce = new ComponentEvent();
            Position pos = new Position {X = 5, Y = 6};

            Exception ex = Record.Exception(() =>
                GameObject.InvokePerEntityEvents(entity, false, ref ce, ref pos));

            Assert.Null(ex);
        }

        [Fact] public void InvokePerEntityEvents_Arity2_HasGenericFalse_DoesNotThrow()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            ComponentEvent ce = new ComponentEvent();
            Position pos = new Position {X = 5, Y = 6};
            Velocity vel = new Velocity {X = 10, Y = 20};

            Exception ex = Record.Exception(() =>
                GameObject.InvokePerEntityEvents<Position, Velocity>(entity, false, ref ce, ref pos, ref vel));

            Assert.Null(ex);
        }

        [Fact] public void InvokePerEntityEvents_Arity3_HasGenericFalse_DoesNotThrow()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            ComponentEvent ce = new ComponentEvent();
            Position pos = new Position {X = 5, Y = 6};
            Velocity vel = new Velocity {X = 10, Y = 20};
            Health h = new Health {Value = 100};

            Exception ex = Record.Exception(() =>
                GameObject.InvokePerEntityEvents<Position, Velocity, Health>(entity, false, ref ce, ref pos, ref vel, ref h));

            Assert.Null(ex);
        }

        [Fact] public void InvokePerEntityEvents_Arity4_HasGenericFalse_DoesNotThrow()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            ComponentEvent ce = new ComponentEvent();
            Position pos = new Position {X = 5, Y = 6};
            Velocity vel = new Velocity {X = 10, Y = 20};
            Health h = new Health {Value = 100};
            Armor a = new Armor {Value = 50};

            Exception ex = Record.Exception(() =>
                GameObject.InvokePerEntityEvents<Position, Velocity, Health, Armor>(entity, false, ref ce, ref pos, ref vel, ref h, ref a));

            Assert.Null(ex);
        }

        [Fact] public void InvokePerEntityEvents_Arity5_HasGenericFalse_DoesNotThrow()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            ComponentEvent ce = new ComponentEvent();
            Position pos = new Position {X = 5, Y = 6};
            Velocity vel = new Velocity {X = 10, Y = 20};
            Health h = new Health {Value = 100};
            Armor a = new Armor {Value = 50};
            Damage d = new Damage {Value = 25};

            Exception ex = Record.Exception(() =>
                GameObject.InvokePerEntityEvents<Position, Velocity, Health, Armor, Damage>(entity, false, ref ce, ref pos, ref vel, ref h, ref a, ref d));

            Assert.Null(ex);
        }

        [Fact] public void InvokePerEntityEvents_Arity6_HasGenericFalse_DoesNotThrow()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            ComponentEvent ce = new ComponentEvent();
            Position pos = new Position {X = 5, Y = 6};
            Velocity vel = new Velocity {X = 10, Y = 20};
            Health h = new Health {Value = 100};
            Armor a = new Armor {Value = 50};
            Damage d = new Damage {Value = 25};
            Transform t = new Transform {X = 1, Y = 2, Rotation = 3};

            Exception ex = Record.Exception(() =>
                GameObject.InvokePerEntityEvents<Position, Velocity, Health, Armor, Damage, Transform>(entity, false, ref ce, ref pos, ref vel, ref h, ref a, ref d, ref t));

            Assert.Null(ex);
        }

        [Fact] public void InvokePerEntityEvents_Arity7_HasGenericFalse_DoesNotThrow()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            ComponentEvent ce = new ComponentEvent();
            Position pos = new Position {X = 5, Y = 6};
            Velocity vel = new Velocity {X = 10, Y = 20};
            Health h = new Health {Value = 100};
            Armor a = new Armor {Value = 50};
            Damage d = new Damage {Value = 25};
            Transform t = new Transform {X = 1, Y = 2, Rotation = 3};
            TestComponent tc = new TestComponent {Value = 99};

            Exception ex = Record.Exception(() =>
                GameObject.InvokePerEntityEvents<Position, Velocity, Health, Armor, Damage, Transform, TestComponent>(entity, false, ref ce, ref pos, ref vel, ref h, ref a, ref d, ref t, ref tc));

            Assert.Null(ex);
        }

        [Fact] public void InvokePerEntityEvents_Arity8_HasGenericFalse_DoesNotThrow()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            ComponentEvent ce = new ComponentEvent();
            Position pos = new Position {X = 5, Y = 6};
            Velocity vel = new Velocity {X = 10, Y = 20};
            Health h = new Health {Value = 100};
            Armor a = new Armor {Value = 50};
            Damage d = new Damage {Value = 25};
            Transform t = new Transform {X = 1, Y = 2, Rotation = 3};
            TestComponent tc = new TestComponent {Value = 99};
            AnotherComponent ac = new AnotherComponent {Name = "test", Data = 42};

            Exception ex = Record.Exception(() =>
                GameObject.InvokePerEntityEvents<Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent>(entity, false, ref ce, ref pos, ref vel, ref h, ref a, ref d, ref t, ref tc, ref ac));

            Assert.Null(ex);
        }

        [Fact] public void InitalizeEventRecord_AddComp_WithIsGenericEventTrue_DoesNotThrow()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            GenericEvent ge = entity.OnComponentAddedGeneric;

            Exception ex = Record.Exception(() =>
                entity.InitalizeEventRecord(ge, GameObjectFlags.AddComp, true));

            Assert.Null(ex);
        }

        [Fact] public void InitalizeEventRecord_RemoveComp_WithIsGenericEventTrue_DoesNotThrow()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            GenericEvent ge = entity.OnComponentAddedGeneric;

            Exception ex = Record.Exception(() =>
                entity.InitalizeEventRecord(ge, GameObjectFlags.RemoveComp, true));

            Assert.Null(ex);
        }
    }
}
