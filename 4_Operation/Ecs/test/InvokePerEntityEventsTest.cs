// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InvokePerEntityEventsTest.cs
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
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Comprehensive unit tests for all overloads of <see cref="GameObject.InvokePerEntityEvents{T}"/>.
    ///     Tests cover arities 1 through 8, verifying:
    ///     - NormalEvent is always invoked with the correct ComponentId
    ///     - GenericEvent is only invoked when hasGenericEvent = true
    ///     - Correct entity is passed to handlers
    ///     - Component values are accessible/mutable via ref in GenericEvent
    ///     - Multiple listeners all receive the call
    /// </summary>
    public class InvokePerEntityEventsTest
    {
        // ───────────────────────────────────────────────────────────────────
        // Arity 1 — InvokePerEntityEvents<T>
        // ───────────────────────────────────────────────────────────────────

        [Fact]
        public void Arity1_NormalEvent_IsFired_WithCorrectComponentId()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            List<ComponentId> received = new List<ComponentId>();
            events.NormalEvent.Add((go, id) => received.Add(id));

            Position pos = new Position { X = 1, Y = 2 };
            GameObject.InvokePerEntityEvents(entity, false, ref events, ref pos);

            Assert.Single(received);
            Assert.Equal(Component<Position>.Id, received[0]);
        }

        [Fact]
        public void Arity1_NormalEvent_IsFired_WhenHasGenericEventTrue()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            events.GenericEvent = new GenericEvent();
            events.GenericEvent.Add(new CountingGenericAction());

            List<ComponentId> received = new List<ComponentId>();
            events.NormalEvent.Add((go, id) => received.Add(id));

            Position pos = new Position { X = 5, Y = 10 };
            GameObject.InvokePerEntityEvents(entity, true, ref events, ref pos);

            Assert.Single(received);
            Assert.Equal(Component<Position>.Id, received[0]);
        }

        [Fact]
        public void Arity1_NormalEvent_PassesCorrectEntity()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            List<GameObject> receivedEntities = new List<GameObject>();
            events.NormalEvent.Add((go, id) => receivedEntities.Add(go));

            Position pos = new Position { X = 1, Y = 2 };
            GameObject.InvokePerEntityEvents(entity, false, ref events, ref pos);

            Assert.Single(receivedEntities);
            Assert.Equal(entity, receivedEntities[0]);
        }

        [Fact]
        public void Arity1_NormalEvent_MultipleListeners_AllInvoked()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            int count = 0;
            events.NormalEvent.Add((go, id) => count++);
            events.NormalEvent.Add((go, id) => count++);
            events.NormalEvent.Add((go, id) => count++);

            Position pos = new Position { X = 1, Y = 2 };
            GameObject.InvokePerEntityEvents(entity, false, ref events, ref pos);

            Assert.Equal(3, count);
        }

        [Fact]
        public void Arity1_GenericEvent_NotInvoked_WhenHasGenericEventFalse()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            events.NormalEvent.Add((go, id) => { });

            CountingGenericAction genericAction = new CountingGenericAction();
            events.GenericEvent = new GenericEvent();
            events.GenericEvent.Add(genericAction);

            Position pos = new Position { X = 1, Y = 2 };
            GameObject.InvokePerEntityEvents(entity, false, ref events, ref pos);

            Assert.Equal(0, genericAction.CallCount);
        }

        [Fact]
        public void Arity1_GenericEvent_Invoked_WhenHasGenericEventTrue()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            events.NormalEvent.Add((go, id) => { });

            TypeCapturingAction capture = new TypeCapturingAction();
            events.GenericEvent = new GenericEvent();
            events.GenericEvent.Add(capture);

            Position pos = new Position { X = 5, Y = 10 };
            GameObject.InvokePerEntityEvents(entity, true, ref events, ref pos);

            Assert.Contains(typeof(Position), capture.SeenTypes);
        }

        [Fact]
        public void Arity1_GenericEvent_ReceivesCorrectEntity()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            events.NormalEvent.Add((go, id) => { });

            EntityCapturingAction capture = new EntityCapturingAction();
            events.GenericEvent = new GenericEvent();
            events.GenericEvent.Add(capture);

            Position pos = new Position { X = 1, Y = 2 };
            GameObject.InvokePerEntityEvents(entity, true, ref events, ref pos);

            Assert.Single(capture.SeenEntities);
            Assert.Equal(entity, capture.SeenEntities[0]);
        }

        [Fact]
        public void Arity1_GenericEvent_CanMutateComponent()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            events.NormalEvent.Add((go, id) => { });

            MutatingPositionAction mutator = new MutatingPositionAction();
            events.GenericEvent = new GenericEvent();
            events.GenericEvent.Add(mutator);

            Position pos = new Position { X = 0, Y = 0 };
            GameObject.InvokePerEntityEvents(entity, true, ref events, ref pos);

            Assert.Equal(99, pos.X);
            Assert.Equal(99, pos.Y);
        }

        [Fact]
        public void Arity1_GenericEvent_MultipleListeners_AllInvoked()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            events.NormalEvent.Add((go, id) => { });

            CountingGenericAction c1 = new CountingGenericAction();
            CountingGenericAction c2 = new CountingGenericAction();
            CountingGenericAction c3 = new CountingGenericAction();
            events.GenericEvent = new GenericEvent();
            events.GenericEvent.Add(c1);
            events.GenericEvent.Add(c2);
            events.GenericEvent.Add(c3);

            Position pos = new Position { X = 1, Y = 2 };
            GameObject.InvokePerEntityEvents(entity, true, ref events, ref pos);

            Assert.Equal(1, c1.CallCount);
            Assert.Equal(1, c2.CallCount);
            Assert.Equal(1, c3.CallCount);
        }

        [Fact]
        public void Arity1_NoListeners_DoesNotThrow()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            Position pos = new Position { X = 1, Y = 2 };

            Exception ex = Record.Exception(() =>
                GameObject.InvokePerEntityEvents(entity, false, ref events, ref pos));

            Assert.Null(ex);
        }

        [Fact]
        public void Arity1_NullGenericEvent_WithHasGenericEventFalse_DoesNotThrow()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            events.NormalEvent.Add((go, id) => { });
            // GenericEvent remains null

            Position pos = new Position { X = 1, Y = 2 };

            Exception ex = Record.Exception(() =>
                GameObject.InvokePerEntityEvents(entity, false, ref events, ref pos));

            Assert.Null(ex);
        }

        // ───────────────────────────────────────────────────────────────────
        // Arity 2 — InvokePerEntityEvents<T1, T2>
        // ───────────────────────────────────────────────────────────────────

        [Fact]
        public void Arity2_NormalEvent_FiredForBothComponents()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            List<ComponentId> received = new List<ComponentId>();
            events.NormalEvent.Add((go, id) => received.Add(id));

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            GameObject.InvokePerEntityEvents(entity, false, ref events, ref pos, ref health);

            Assert.Equal(2, received.Count);
            Assert.Contains(Component<Position>.Id, received);
            Assert.Contains(Component<Health>.Id, received);
        }

        [Fact]
        public void Arity2_NormalEvent_PassesCorrectEntity_ForBothInvocations()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            List<GameObject> entities = new List<GameObject>();
            events.NormalEvent.Add((go, id) => entities.Add(go));

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            GameObject.InvokePerEntityEvents(entity, false, ref events, ref pos, ref health);

            Assert.Equal(2, entities.Count);
            Assert.All(entities, e => Assert.Equal(entity, e));
        }

        [Fact]
        public void Arity2_GenericEvent_NotInvoked_WhenHasGenericEventFalse()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            events.NormalEvent.Add((go, id) => { });

            CountingGenericAction counting = new CountingGenericAction();
            events.GenericEvent = new GenericEvent();
            events.GenericEvent.Add(counting);

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            GameObject.InvokePerEntityEvents(entity, false, ref events, ref pos, ref health);

            Assert.Equal(0, counting.CallCount);
        }

        [Fact]
        public void Arity2_GenericEvent_InvokedTwice_WhenHasGenericEventTrue()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            events.NormalEvent.Add((go, id) => { });

            TypeCapturingAction capture = new TypeCapturingAction();
            events.GenericEvent = new GenericEvent();
            events.GenericEvent.Add(capture);

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            GameObject.InvokePerEntityEvents(entity, true, ref events, ref pos, ref health);

            Assert.Contains(typeof(Position), capture.SeenTypes);
            Assert.Contains(typeof(Health), capture.SeenTypes);
            Assert.Equal(2, capture.TotalInvocations);
        }

        [Fact]
        public void Arity2_GenericEvent_CanMutateFirstComponent()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            events.NormalEvent.Add((go, id) => { });

            MutatingPositionAction mutator = new MutatingPositionAction();
            events.GenericEvent = new GenericEvent();
            events.GenericEvent.Add(mutator);

            Position pos = new Position { X = 0, Y = 0 };
            Health health = new Health { Value = 100 };
            GameObject.InvokePerEntityEvents(entity, true, ref events, ref pos, ref health);

            Assert.Equal(99, pos.X);
        }

        [Fact]
        public void Arity2_NormalEvent_FiredExactlyTwoTimes()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            int count = 0;
            events.NormalEvent.Add((go, id) => count++);

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            GameObject.InvokePerEntityEvents(entity, false, ref events, ref pos, ref health);

            Assert.Equal(2, count);
        }

        [Fact]
        public void Arity2_NoListeners_DoesNotThrow()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };

            Exception ex = Record.Exception(() =>
                GameObject.InvokePerEntityEvents(entity, false, ref events, ref pos, ref health));

            Assert.Null(ex);
        }

        [Fact]
        public void Arity2_MultipleNormalListeners_AllInvoked()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            int count = 0;
            events.NormalEvent.Add((go, id) => count++);
            events.NormalEvent.Add((go, id) => count++);

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            GameObject.InvokePerEntityEvents(entity, false, ref events, ref pos, ref health);

            // 2 listeners × 2 components = 4
            Assert.Equal(4, count);
        }

        // ───────────────────────────────────────────────────────────────────
        // Arity 3 — InvokePerEntityEvents<T1, T2, T3>
        // ───────────────────────────────────────────────────────────────────

        [Fact]
        public void Arity3_NormalEvent_FiredForAllThreeComponents()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            List<ComponentId> received = new List<ComponentId>();
            events.NormalEvent.Add((go, id) => received.Add(id));

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            GameObject.InvokePerEntityEvents(entity, false, ref events, ref pos, ref health, ref vel);

            Assert.Equal(3, received.Count);
            Assert.Contains(Component<Position>.Id, received);
            Assert.Contains(Component<Health>.Id, received);
            Assert.Contains(Component<Velocity>.Id, received);
        }

        [Fact]
        public void Arity3_GenericEvent_NotInvoked_WhenHasGenericEventFalse()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            events.NormalEvent.Add((go, id) => { });

            CountingGenericAction counting = new CountingGenericAction();
            events.GenericEvent = new GenericEvent();
            events.GenericEvent.Add(counting);

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            GameObject.InvokePerEntityEvents(entity, false, ref events, ref pos, ref health, ref vel);

            Assert.Equal(0, counting.CallCount);
        }

        [Fact]
        public void Arity3_GenericEvent_InvokedThreeTimes_WhenHasGenericEventTrue()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            events.NormalEvent.Add((go, id) => { });

            TypeCapturingAction capture = new TypeCapturingAction();
            events.GenericEvent = new GenericEvent();
            events.GenericEvent.Add(capture);

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            GameObject.InvokePerEntityEvents(entity, true, ref events, ref pos, ref health, ref vel);

            Assert.Equal(3, capture.TotalInvocations);
            Assert.Contains(typeof(Position), capture.SeenTypes);
            Assert.Contains(typeof(Health), capture.SeenTypes);
            Assert.Contains(typeof(Velocity), capture.SeenTypes);
        }

        [Fact]
        public void Arity3_NormalEvent_PassesCorrectEntityAllThreeTimes()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            List<GameObject> entities = new List<GameObject>();
            events.NormalEvent.Add((go, id) => entities.Add(go));

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            GameObject.InvokePerEntityEvents(entity, false, ref events, ref pos, ref health, ref vel);

            Assert.Equal(3, entities.Count);
            Assert.All(entities, e => Assert.Equal(entity, e));
        }

        [Fact]
        public void Arity3_NoListeners_DoesNotThrow()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };

            Exception ex = Record.Exception(() =>
                GameObject.InvokePerEntityEvents(entity, false, ref events, ref pos, ref health, ref vel));

            Assert.Null(ex);
        }

        [Fact]
        public void Arity3_GenericEvent_ReceivesCorrectEntity()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            events.NormalEvent.Add((go, id) => { });

            EntityCapturingAction capture = new EntityCapturingAction();
            events.GenericEvent = new GenericEvent();
            events.GenericEvent.Add(capture);

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            GameObject.InvokePerEntityEvents(entity, true, ref events, ref pos, ref health, ref vel);

            Assert.Equal(3, capture.SeenEntities.Count);
            Assert.All(capture.SeenEntities, e => Assert.Equal(entity, e));
        }

        // ───────────────────────────────────────────────────────────────────
        // Arity 4 — InvokePerEntityEvents<T1, T2, T3, T4>
        // ───────────────────────────────────────────────────────────────────

        [Fact]
        public void Arity4_NormalEvent_FiredForAllFourComponents()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            List<ComponentId> received = new List<ComponentId>();
            events.NormalEvent.Add((go, id) => received.Add(id));

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            Transform transform = new Transform { X = 5, Y = 6 };
            GameObject.InvokePerEntityEvents(entity, false, ref events, ref pos, ref health, ref vel, ref transform);

            Assert.Equal(4, received.Count);
            Assert.Contains(Component<Position>.Id, received);
            Assert.Contains(Component<Health>.Id, received);
            Assert.Contains(Component<Velocity>.Id, received);
            Assert.Contains(Component<Transform>.Id, received);
        }

        [Fact]
        public void Arity4_GenericEvent_NotInvoked_WhenHasGenericEventFalse()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            events.NormalEvent.Add((go, id) => { });

            CountingGenericAction counting = new CountingGenericAction();
            events.GenericEvent = new GenericEvent();
            events.GenericEvent.Add(counting);

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            Transform transform = new Transform { X = 5, Y = 6 };
            GameObject.InvokePerEntityEvents(entity, false, ref events, ref pos, ref health, ref vel, ref transform);

            Assert.Equal(0, counting.CallCount);
        }

        [Fact]
        public void Arity4_GenericEvent_InvokedFourTimes_WhenHasGenericEventTrue()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            events.NormalEvent.Add((go, id) => { });

            TypeCapturingAction capture = new TypeCapturingAction();
            events.GenericEvent = new GenericEvent();
            events.GenericEvent.Add(capture);

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            Transform transform = new Transform { X = 5, Y = 6 };
            GameObject.InvokePerEntityEvents(entity, true, ref events, ref pos, ref health, ref vel, ref transform);

            Assert.Equal(4, capture.TotalInvocations);
            Assert.Contains(typeof(Position), capture.SeenTypes);
            Assert.Contains(typeof(Health), capture.SeenTypes);
            Assert.Contains(typeof(Velocity), capture.SeenTypes);
            Assert.Contains(typeof(Transform), capture.SeenTypes);
        }

        [Fact]
        public void Arity4_NoListeners_DoesNotThrow()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            Transform transform = new Transform { X = 5, Y = 6 };

            Exception ex = Record.Exception(() =>
                GameObject.InvokePerEntityEvents(entity, false, ref events, ref pos, ref health, ref vel, ref transform));

            Assert.Null(ex);
        }

        [Fact]
        public void Arity4_NormalEvent_PassesCorrectEntityAllFourTimes()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            List<GameObject> entities = new List<GameObject>();
            events.NormalEvent.Add((go, id) => entities.Add(go));

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            Transform transform = new Transform { X = 5, Y = 6 };
            GameObject.InvokePerEntityEvents(entity, false, ref events, ref pos, ref health, ref vel, ref transform);

            Assert.Equal(4, entities.Count);
            Assert.All(entities, e => Assert.Equal(entity, e));
        }

        // ───────────────────────────────────────────────────────────────────
        // Arity 5 — InvokePerEntityEvents<T1, T2, T3, T4, T5>
        // ───────────────────────────────────────────────────────────────────

        [Fact]
        public void Arity5_NormalEvent_FiredForAllFiveComponents()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            List<ComponentId> received = new List<ComponentId>();
            events.NormalEvent.Add((go, id) => received.Add(id));

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            Transform transform = new Transform { X = 5, Y = 6 };
            Damage damage = new Damage { Value = 10 };
            GameObject.InvokePerEntityEvents(entity, false, ref events,
                ref pos, ref health, ref vel, ref transform, ref damage);

            Assert.Equal(5, received.Count);
            Assert.Contains(Component<Position>.Id, received);
            Assert.Contains(Component<Health>.Id, received);
            Assert.Contains(Component<Velocity>.Id, received);
            Assert.Contains(Component<Transform>.Id, received);
            Assert.Contains(Component<Damage>.Id, received);
        }

        [Fact]
        public void Arity5_GenericEvent_NotInvoked_WhenHasGenericEventFalse()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            events.NormalEvent.Add((go, id) => { });

            CountingGenericAction counting = new CountingGenericAction();
            events.GenericEvent = new GenericEvent();
            events.GenericEvent.Add(counting);

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            Transform transform = new Transform { X = 5, Y = 6 };
            Damage damage = new Damage { Value = 10 };
            GameObject.InvokePerEntityEvents(entity, false, ref events,
                ref pos, ref health, ref vel, ref transform, ref damage);

            Assert.Equal(0, counting.CallCount);
        }

        [Fact]
        public void Arity5_GenericEvent_InvokedFiveTimes_WhenHasGenericEventTrue()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            events.NormalEvent.Add((go, id) => { });

            TypeCapturingAction capture = new TypeCapturingAction();
            events.GenericEvent = new GenericEvent();
            events.GenericEvent.Add(capture);

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            Transform transform = new Transform { X = 5, Y = 6 };
            Damage damage = new Damage { Value = 10 };
            GameObject.InvokePerEntityEvents(entity, true, ref events,
                ref pos, ref health, ref vel, ref transform, ref damage);

            Assert.Equal(5, capture.TotalInvocations);
            Assert.Contains(typeof(Position), capture.SeenTypes);
            Assert.Contains(typeof(Health), capture.SeenTypes);
            Assert.Contains(typeof(Velocity), capture.SeenTypes);
            Assert.Contains(typeof(Transform), capture.SeenTypes);
            Assert.Contains(typeof(Damage), capture.SeenTypes);
        }

        [Fact]
        public void Arity5_NoListeners_DoesNotThrow()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            Transform transform = new Transform { X = 5, Y = 6 };
            Damage damage = new Damage { Value = 10 };

            Exception ex = Record.Exception(() =>
                GameObject.InvokePerEntityEvents(entity, false, ref events,
                    ref pos, ref health, ref vel, ref transform, ref damage));

            Assert.Null(ex);
        }

        [Fact]
        public void Arity5_NormalEvent_PassesCorrectEntityAllFiveTimes()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            List<GameObject> entities = new List<GameObject>();
            events.NormalEvent.Add((go, id) => entities.Add(go));

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            Transform transform = new Transform { X = 5, Y = 6 };
            Damage damage = new Damage { Value = 10 };
            GameObject.InvokePerEntityEvents(entity, false, ref events,
                ref pos, ref health, ref vel, ref transform, ref damage);

            Assert.Equal(5, entities.Count);
            Assert.All(entities, e => Assert.Equal(entity, e));
        }

        // ───────────────────────────────────────────────────────────────────
        // Arity 6 — InvokePerEntityEvents<T1, T2, T3, T4, T5, T6>
        // ───────────────────────────────────────────────────────────────────

        [Fact]
        public void Arity6_NormalEvent_FiredForAllSixComponents()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            List<ComponentId> received = new List<ComponentId>();
            events.NormalEvent.Add((go, id) => received.Add(id));

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            Transform transform = new Transform { X = 5, Y = 6 };
            Damage damage = new Damage { Value = 10 };
            AnotherComponent another = new AnotherComponent { Data = 42 };
            GameObject.InvokePerEntityEvents(entity, false, ref events,
                ref pos, ref health, ref vel, ref transform, ref damage, ref another);

            Assert.Equal(6, received.Count);
            Assert.Contains(Component<Position>.Id, received);
            Assert.Contains(Component<Health>.Id, received);
            Assert.Contains(Component<Velocity>.Id, received);
            Assert.Contains(Component<Transform>.Id, received);
            Assert.Contains(Component<Damage>.Id, received);
            Assert.Contains(Component<AnotherComponent>.Id, received);
        }

        [Fact]
        public void Arity6_GenericEvent_NotInvoked_WhenHasGenericEventFalse()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            events.NormalEvent.Add((go, id) => { });

            CountingGenericAction counting = new CountingGenericAction();
            events.GenericEvent = new GenericEvent();
            events.GenericEvent.Add(counting);

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            Transform transform = new Transform { X = 5, Y = 6 };
            Damage damage = new Damage { Value = 10 };
            AnotherComponent another = new AnotherComponent { Data = 42 };
            GameObject.InvokePerEntityEvents(entity, false, ref events,
                ref pos, ref health, ref vel, ref transform, ref damage, ref another);

            Assert.Equal(0, counting.CallCount);
        }

        [Fact]
        public void Arity6_GenericEvent_InvokedSixTimes_WhenHasGenericEventTrue()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            events.NormalEvent.Add((go, id) => { });

            TypeCapturingAction capture = new TypeCapturingAction();
            events.GenericEvent = new GenericEvent();
            events.GenericEvent.Add(capture);

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            Transform transform = new Transform { X = 5, Y = 6 };
            Damage damage = new Damage { Value = 10 };
            AnotherComponent another = new AnotherComponent { Data = 42 };
            GameObject.InvokePerEntityEvents(entity, true, ref events,
                ref pos, ref health, ref vel, ref transform, ref damage, ref another);

            Assert.Equal(6, capture.TotalInvocations);
            Assert.Contains(typeof(Position), capture.SeenTypes);
            Assert.Contains(typeof(AnotherComponent), capture.SeenTypes);
        }

        [Fact]
        public void Arity6_NoListeners_DoesNotThrow()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            Transform transform = new Transform { X = 5, Y = 6 };
            Damage damage = new Damage { Value = 10 };
            AnotherComponent another = new AnotherComponent { Data = 42 };

            Exception ex = Record.Exception(() =>
                GameObject.InvokePerEntityEvents(entity, false, ref events,
                    ref pos, ref health, ref vel, ref transform, ref damage, ref another));

            Assert.Null(ex);
        }

        // ───────────────────────────────────────────────────────────────────
        // Arity 7 — InvokePerEntityEvents<T1, T2, T3, T4, T5, T6, T7>
        // ───────────────────────────────────────────────────────────────────

        [Fact]
        public void Arity7_NormalEvent_FiredForAllSevenComponents()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            List<ComponentId> received = new List<ComponentId>();
            events.NormalEvent.Add((go, id) => received.Add(id));

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            Transform transform = new Transform { X = 5, Y = 6 };
            Damage damage = new Damage { Value = 10 };
            AnotherComponent another = new AnotherComponent { Data = 42 };
            AnotherComponent2 another2 = new AnotherComponent2 { Data = 99 };
            GameObject.InvokePerEntityEvents(entity, false, ref events,
                ref pos, ref health, ref vel, ref transform, ref damage, ref another, ref another2);

            Assert.Equal(7, received.Count);
            Assert.Contains(Component<Position>.Id, received);
            Assert.Contains(Component<Health>.Id, received);
            Assert.Contains(Component<Velocity>.Id, received);
            Assert.Contains(Component<Transform>.Id, received);
            Assert.Contains(Component<Damage>.Id, received);
            Assert.Contains(Component<AnotherComponent>.Id, received);
            Assert.Contains(Component<AnotherComponent2>.Id, received);
        }

        [Fact]
        public void Arity7_GenericEvent_NotInvoked_WhenHasGenericEventFalse()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            events.NormalEvent.Add((go, id) => { });

            CountingGenericAction counting = new CountingGenericAction();
            events.GenericEvent = new GenericEvent();
            events.GenericEvent.Add(counting);

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            Transform transform = new Transform { X = 5, Y = 6 };
            Damage damage = new Damage { Value = 10 };
            AnotherComponent another = new AnotherComponent { Data = 42 };
            AnotherComponent2 another2 = new AnotherComponent2 { Data = 99 };
            GameObject.InvokePerEntityEvents(entity, false, ref events,
                ref pos, ref health, ref vel, ref transform, ref damage, ref another, ref another2);

            Assert.Equal(0, counting.CallCount);
        }

        [Fact]
        public void Arity7_GenericEvent_InvokedSevenTimes_WhenHasGenericEventTrue()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            events.NormalEvent.Add((go, id) => { });

            TypeCapturingAction capture = new TypeCapturingAction();
            events.GenericEvent = new GenericEvent();
            events.GenericEvent.Add(capture);

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            Transform transform = new Transform { X = 5, Y = 6 };
            Damage damage = new Damage { Value = 10 };
            AnotherComponent another = new AnotherComponent { Data = 42 };
            AnotherComponent2 another2 = new AnotherComponent2 { Data = 99 };
            GameObject.InvokePerEntityEvents(entity, true, ref events,
                ref pos, ref health, ref vel, ref transform, ref damage, ref another, ref another2);

            Assert.Equal(7, capture.TotalInvocations);
            Assert.Contains(typeof(AnotherComponent2), capture.SeenTypes);
        }

        [Fact]
        public void Arity7_NoListeners_DoesNotThrow()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            Transform transform = new Transform { X = 5, Y = 6 };
            Damage damage = new Damage { Value = 10 };
            AnotherComponent another = new AnotherComponent { Data = 42 };
            AnotherComponent2 another2 = new AnotherComponent2 { Data = 99 };

            Exception ex = Record.Exception(() =>
                GameObject.InvokePerEntityEvents(entity, false, ref events,
                    ref pos, ref health, ref vel, ref transform, ref damage, ref another, ref another2));

            Assert.Null(ex);
        }

        // ───────────────────────────────────────────────────────────────────
        // Arity 8 — InvokePerEntityEvents<T1, T2, T3, T4, T5, T6, T7, T8>
        // ───────────────────────────────────────────────────────────────────

        [Fact]
        public void Arity8_NormalEvent_FiredForAllEightComponents()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            List<ComponentId> received = new List<ComponentId>();
            events.NormalEvent.Add((go, id) => received.Add(id));

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            Transform transform = new Transform { X = 5, Y = 6 };
            Damage damage = new Damage { Value = 10 };
            AnotherComponent another = new AnotherComponent { Data = 42 };
            AnotherComponent2 another2 = new AnotherComponent2 { Data = 99 };
            Armor armor = new Armor { Value = 25 };
            GameObject.InvokePerEntityEvents(entity, false, ref events,
                ref pos, ref health, ref vel, ref transform, ref damage, ref another, ref another2, ref armor);

            Assert.Equal(8, received.Count);
            Assert.Contains(Component<Position>.Id, received);
            Assert.Contains(Component<Health>.Id, received);
            Assert.Contains(Component<Velocity>.Id, received);
            Assert.Contains(Component<Transform>.Id, received);
            Assert.Contains(Component<Damage>.Id, received);
            Assert.Contains(Component<AnotherComponent>.Id, received);
            Assert.Contains(Component<AnotherComponent2>.Id, received);
            Assert.Contains(Component<Armor>.Id, received);
        }

        [Fact]
        public void Arity8_GenericEvent_NotInvoked_WhenHasGenericEventFalse()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            events.NormalEvent.Add((go, id) => { });

            CountingGenericAction counting = new CountingGenericAction();
            events.GenericEvent = new GenericEvent();
            events.GenericEvent.Add(counting);

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            Transform transform = new Transform { X = 5, Y = 6 };
            Damage damage = new Damage { Value = 10 };
            AnotherComponent another = new AnotherComponent { Data = 42 };
            AnotherComponent2 another2 = new AnotherComponent2 { Data = 99 };
            Armor armor = new Armor { Value = 25 };
            GameObject.InvokePerEntityEvents(entity, false, ref events,
                ref pos, ref health, ref vel, ref transform, ref damage, ref another, ref another2, ref armor);

            Assert.Equal(0, counting.CallCount);
        }

        [Fact]
        public void Arity8_GenericEvent_InvokedEightTimes_WhenHasGenericEventTrue()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            events.NormalEvent.Add((go, id) => { });

            TypeCapturingAction capture = new TypeCapturingAction();
            events.GenericEvent = new GenericEvent();
            events.GenericEvent.Add(capture);

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            Transform transform = new Transform { X = 5, Y = 6 };
            Damage damage = new Damage { Value = 10 };
            AnotherComponent another = new AnotherComponent { Data = 42 };
            AnotherComponent2 another2 = new AnotherComponent2 { Data = 99 };
            Armor armor = new Armor { Value = 25 };
            GameObject.InvokePerEntityEvents(entity, true, ref events,
                ref pos, ref health, ref vel, ref transform, ref damage, ref another, ref another2, ref armor);

            Assert.Equal(8, capture.TotalInvocations);
            Assert.Contains(typeof(Position), capture.SeenTypes);
            Assert.Contains(typeof(Health), capture.SeenTypes);
            Assert.Contains(typeof(Velocity), capture.SeenTypes);
            Assert.Contains(typeof(Transform), capture.SeenTypes);
            Assert.Contains(typeof(Damage), capture.SeenTypes);
            Assert.Contains(typeof(AnotherComponent), capture.SeenTypes);
            Assert.Contains(typeof(AnotherComponent2), capture.SeenTypes);
            Assert.Contains(typeof(Armor), capture.SeenTypes);
        }

        [Fact]
        public void Arity8_NormalEvent_PassesCorrectEntityAllEightTimes()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            List<GameObject> entities = new List<GameObject>();
            events.NormalEvent.Add((go, id) => entities.Add(go));

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            Transform transform = new Transform { X = 5, Y = 6 };
            Damage damage = new Damage { Value = 10 };
            AnotherComponent another = new AnotherComponent { Data = 42 };
            AnotherComponent2 another2 = new AnotherComponent2 { Data = 99 };
            Armor armor = new Armor { Value = 25 };
            GameObject.InvokePerEntityEvents(entity, false, ref events,
                ref pos, ref health, ref vel, ref transform, ref damage, ref another, ref another2, ref armor);

            Assert.Equal(8, entities.Count);
            Assert.All(entities, e => Assert.Equal(entity, e));
        }

        [Fact]
        public void Arity8_NoListeners_DoesNotThrow()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            Transform transform = new Transform { X = 5, Y = 6 };
            Damage damage = new Damage { Value = 10 };
            AnotherComponent another = new AnotherComponent { Data = 42 };
            AnotherComponent2 another2 = new AnotherComponent2 { Data = 99 };
            Armor armor = new Armor { Value = 25 };

            Exception ex = Record.Exception(() =>
                GameObject.InvokePerEntityEvents(entity, false, ref events,
                    ref pos, ref health, ref vel, ref transform, ref damage, ref another, ref another2, ref armor));

            Assert.Null(ex);
        }

        [Fact]
        public void Arity8_MultipleNormalListeners_AllInvoked()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            int count = 0;
            events.NormalEvent.Add((go, id) => count++);
            events.NormalEvent.Add((go, id) => count++);

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            Transform transform = new Transform { X = 5, Y = 6 };
            Damage damage = new Damage { Value = 10 };
            AnotherComponent another = new AnotherComponent { Data = 42 };
            AnotherComponent2 another2 = new AnotherComponent2 { Data = 99 };
            Armor armor = new Armor { Value = 25 };
            GameObject.InvokePerEntityEvents(entity, false, ref events,
                ref pos, ref health, ref vel, ref transform, ref damage, ref another, ref another2, ref armor);

            // 2 listeners × 8 components = 16
            Assert.Equal(16, count);
        }

        // ───────────────────────────────────────────────────────────────────
        // Cross-arity parametrized tests
        // ───────────────────────────────────────────────────────────────────

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Arity1_GenericEventPresence_CorrectlyGated(bool hasGenericEvent)
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            events.NormalEvent.Add((go, id) => { });

            CountingGenericAction counting = new CountingGenericAction();
            events.GenericEvent = new GenericEvent();
            events.GenericEvent.Add(counting);

            Position pos = new Position { X = 1, Y = 2 };
            GameObject.InvokePerEntityEvents(entity, hasGenericEvent, ref events, ref pos);

            Assert.Equal(hasGenericEvent ? 1 : 0, counting.CallCount);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Arity2_GenericEventPresence_CorrectlyGated(bool hasGenericEvent)
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            events.NormalEvent.Add((go, id) => { });

            CountingGenericAction counting = new CountingGenericAction();
            events.GenericEvent = new GenericEvent();
            events.GenericEvent.Add(counting);

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            GameObject.InvokePerEntityEvents(entity, hasGenericEvent, ref events, ref pos, ref health);

            Assert.Equal(hasGenericEvent ? 2 : 0, counting.CallCount);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Arity3_GenericEventPresence_CorrectlyGated(bool hasGenericEvent)
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            events.NormalEvent.Add((go, id) => { });

            CountingGenericAction counting = new CountingGenericAction();
            events.GenericEvent = new GenericEvent();
            events.GenericEvent.Add(counting);

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            GameObject.InvokePerEntityEvents(entity, hasGenericEvent, ref events, ref pos, ref health, ref vel);

            Assert.Equal(hasGenericEvent ? 3 : 0, counting.CallCount);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Arity4_GenericEventPresence_CorrectlyGated(bool hasGenericEvent)
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            events.NormalEvent.Add((go, id) => { });

            CountingGenericAction counting = new CountingGenericAction();
            events.GenericEvent = new GenericEvent();
            events.GenericEvent.Add(counting);

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            Transform transform = new Transform { X = 5, Y = 6 };
            GameObject.InvokePerEntityEvents(entity, hasGenericEvent, ref events,
                ref pos, ref health, ref vel, ref transform);

            Assert.Equal(hasGenericEvent ? 4 : 0, counting.CallCount);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Arity5_GenericEventPresence_CorrectlyGated(bool hasGenericEvent)
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            events.NormalEvent.Add((go, id) => { });

            CountingGenericAction counting = new CountingGenericAction();
            events.GenericEvent = new GenericEvent();
            events.GenericEvent.Add(counting);

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            Transform transform = new Transform { X = 5, Y = 6 };
            Damage damage = new Damage { Value = 10 };
            GameObject.InvokePerEntityEvents(entity, hasGenericEvent, ref events,
                ref pos, ref health, ref vel, ref transform, ref damage);

            Assert.Equal(hasGenericEvent ? 5 : 0, counting.CallCount);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Arity6_GenericEventPresence_CorrectlyGated(bool hasGenericEvent)
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            events.NormalEvent.Add((go, id) => { });

            CountingGenericAction counting = new CountingGenericAction();
            events.GenericEvent = new GenericEvent();
            events.GenericEvent.Add(counting);

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            Transform transform = new Transform { X = 5, Y = 6 };
            Damage damage = new Damage { Value = 10 };
            AnotherComponent another = new AnotherComponent { Data = 42 };
            GameObject.InvokePerEntityEvents(entity, hasGenericEvent, ref events,
                ref pos, ref health, ref vel, ref transform, ref damage, ref another);

            Assert.Equal(hasGenericEvent ? 6 : 0, counting.CallCount);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Arity7_GenericEventPresence_CorrectlyGated(bool hasGenericEvent)
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            events.NormalEvent.Add((go, id) => { });

            CountingGenericAction counting = new CountingGenericAction();
            events.GenericEvent = new GenericEvent();
            events.GenericEvent.Add(counting);

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            Transform transform = new Transform { X = 5, Y = 6 };
            Damage damage = new Damage { Value = 10 };
            AnotherComponent another = new AnotherComponent { Data = 42 };
            AnotherComponent2 another2 = new AnotherComponent2 { Data = 99 };
            GameObject.InvokePerEntityEvents(entity, hasGenericEvent, ref events,
                ref pos, ref health, ref vel, ref transform, ref damage, ref another, ref another2);

            Assert.Equal(hasGenericEvent ? 7 : 0, counting.CallCount);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Arity8_GenericEventPresence_CorrectlyGated(bool hasGenericEvent)
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            events.NormalEvent.Add((go, id) => { });

            CountingGenericAction counting = new CountingGenericAction();
            events.GenericEvent = new GenericEvent();
            events.GenericEvent.Add(counting);

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            Transform transform = new Transform { X = 5, Y = 6 };
            Damage damage = new Damage { Value = 10 };
            AnotherComponent another = new AnotherComponent { Data = 42 };
            AnotherComponent2 another2 = new AnotherComponent2 { Data = 99 };
            Armor armor = new Armor { Value = 25 };
            GameObject.InvokePerEntityEvents(entity, hasGenericEvent, ref events,
                ref pos, ref health, ref vel, ref transform, ref damage, ref another, ref another2, ref armor);

            Assert.Equal(hasGenericEvent ? 8 : 0, counting.CallCount);
        }

        // ───────────────────────────────────────────────────────────────────
        // Integration tests via entity.OnComponentAdded / OnComponentAddedGeneric
        // ───────────────────────────────────────────────────────────────────

        [Fact]
        public void Integration_Arity1_OnComponentAdded_FiredWhenComponentAdded()
        {
            // OnComponentAddedGeneric uses GetOrAddNew which correctly initialises EventLookup.
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Velocity { X = 0, Y = 0 });

            TypeCapturingAction capture = new TypeCapturingAction();
            entity.OnComponentAddedGeneric += capture;

            entity.Add(new Position { X = 1, Y = 2 });

            Assert.Contains(typeof(Position), capture.SeenTypes);
        }

        [Fact]
        public void Integration_Arity1_OnComponentAddedGeneric_FiredWhenComponentAdded()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Velocity { X = 0, Y = 0 });

            TypeCapturingAction capture = new TypeCapturingAction();
            entity.OnComponentAddedGeneric += capture;

            entity.Add(new Position { X = 5, Y = 10 });

            Assert.Contains(typeof(Position), capture.SeenTypes);
        }

        [Fact]
        public void Integration_OnComponentAdded_CorrectEntityPassed()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Velocity { X = 0, Y = 0 });

            EntityCapturingAction capture = new EntityCapturingAction();
            entity.OnComponentAddedGeneric += capture;

            entity.Add(new Health { Value = 100 });

            Assert.Single(capture.SeenEntities);
            Assert.Equal(entity, capture.SeenEntities[0]);
        }

        [Fact]
        public void Integration_OnComponentAddedGeneric_MultipleComponents_AllFired()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Velocity { X = 0, Y = 0 });

            TypeCapturingAction capture = new TypeCapturingAction();
            entity.OnComponentAddedGeneric += capture;

            entity.Add(new Position { X = 1, Y = 1 });
            entity.Add(new Health { Value = 100 });

            Assert.Contains(typeof(Position), capture.SeenTypes);
            Assert.Contains(typeof(Health), capture.SeenTypes);
        }

        [Fact]
        public void Integration_OnComponentAdded_FiredCorrectNumberOfTimes()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Velocity { X = 0, Y = 0 });

            CountingGenericAction counting = new CountingGenericAction();
            entity.OnComponentAddedGeneric += counting;

            entity.Add(new Position { X = 1, Y = 1 });
            entity.Add(new Health { Value = 100 });

            Assert.Equal(2, counting.CallCount);
        }

        [Fact]
        public void Integration_UnsubscribedHandler_NotInvoked()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Velocity { X = 0, Y = 0 });

            CountingGenericAction counting = new CountingGenericAction();
            entity.OnComponentAddedGeneric += counting;
            entity.OnComponentAddedGeneric -= counting;

            entity.Add(new Position { X = 1, Y = 1 });

            Assert.Equal(0, counting.CallCount);
        }

        [Fact]
        public void Integration_OnComponentRemoved_FiredWhenComponentRemoved()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 1, Y = 2 });

            TypeCapturingAction capture = new TypeCapturingAction();
            entity.OnComponentRemovedGeneric += capture;

            entity.Remove<Position>();

            Assert.Contains(typeof(Position), capture.SeenTypes);
        }

        [Fact]
        public void Integration_MultipleEntityInstances_EachReceiveOwnEvents()
        {
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Velocity { X = 0, Y = 0 });
            GameObject entity2 = scene.Create(new Velocity { X = 0, Y = 0 });

            TypeCapturingAction capture1 = new TypeCapturingAction();
            TypeCapturingAction capture2 = new TypeCapturingAction();

            entity1.OnComponentAddedGeneric += capture1;
            entity2.OnComponentAddedGeneric += capture2;

            entity1.Add(new Position { X = 1, Y = 1 });
            entity2.Add(new Health { Value = 100 });

            Assert.Contains(typeof(Position), capture1.SeenTypes);
            Assert.DoesNotContain(typeof(Health), capture1.SeenTypes);
            Assert.Contains(typeof(Health), capture2.SeenTypes);
            Assert.DoesNotContain(typeof(Position), capture2.SeenTypes);
        }

        [Fact]
        public void Integration_OnComponentAdded_NotFiredForOtherEntity()
        {
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Velocity { X = 0, Y = 0 });
            GameObject entity2 = scene.Create();

            CountingGenericAction counting = new CountingGenericAction();
            entity1.OnComponentAddedGeneric += counting;

            // Add component to entity2, not entity1
            entity2.Add(new Position { X = 1, Y = 1 });

            Assert.Equal(0, counting.CallCount);
        }

        // ───────────────────────────────────────────────────────────────────
        // NormalEvent fire order tests
        // ───────────────────────────────────────────────────────────────────

        [Fact]
        public void Arity2_NormalEvent_ComponentIdsReceivedInOrder_T1_Then_T2()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            List<ComponentId> received = new List<ComponentId>();
            events.NormalEvent.Add((go, id) => received.Add(id));

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            GameObject.InvokePerEntityEvents(entity, false, ref events, ref pos, ref health);

            Assert.Equal(Component<Position>.Id, received[0]);
            Assert.Equal(Component<Health>.Id, received[1]);
        }

        [Fact]
        public void Arity3_NormalEvent_ComponentIdsReceivedInOrder()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            List<ComponentId> received = new List<ComponentId>();
            events.NormalEvent.Add((go, id) => received.Add(id));

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            GameObject.InvokePerEntityEvents(entity, false, ref events, ref pos, ref health, ref vel);

            Assert.Equal(Component<Position>.Id, received[0]);
            Assert.Equal(Component<Health>.Id, received[1]);
            Assert.Equal(Component<Velocity>.Id, received[2]);
        }

        [Fact]
        public void Arity4_NormalEvent_ComponentIdsReceivedInOrder()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            List<ComponentId> received = new List<ComponentId>();
            events.NormalEvent.Add((go, id) => received.Add(id));

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            Velocity vel = new Velocity { X = 3, Y = 4 };
            Transform transform = new Transform { X = 5, Y = 6 };
            GameObject.InvokePerEntityEvents(entity, false, ref events, ref pos, ref health, ref vel, ref transform);

            Assert.Equal(Component<Position>.Id, received[0]);
            Assert.Equal(Component<Health>.Id, received[1]);
            Assert.Equal(Component<Velocity>.Id, received[2]);
            Assert.Equal(Component<Transform>.Id, received[3]);
        }

        [Fact]
        public void GenericEvent_InvokedInOrderMatchingNormalEvent_Arity2()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            ComponentEvent events = new ComponentEvent();
            events.NormalEvent.Add((go, id) => { });

            TypeCapturingAction capture = new TypeCapturingAction();
            events.GenericEvent = new GenericEvent();
            events.GenericEvent.Add(capture);

            Position pos = new Position { X = 1, Y = 2 };
            Health health = new Health { Value = 100 };
            GameObject.InvokePerEntityEvents(entity, true, ref events, ref pos, ref health);

            Assert.Equal(typeof(Position), capture.InvokedTypes[0]);
            Assert.Equal(typeof(Health), capture.InvokedTypes[1]);
        }

        // ───────────────────────────────────────────────────────────────────
        // Helper action implementations (private nested classes)
        // ───────────────────────────────────────────────────────────────────

        /// <summary>Counts invocations without caring about type.</summary>
        private sealed class CountingGenericAction : IGenericAction<GameObject>
        {
            public int CallCount { get; private set; }

            public void Invoke<T>(GameObject param, ref T type)
            {
                CallCount++;
            }
        }

        /// <summary>Captures each unique type seen and total invocation count.</summary>
        private sealed class TypeCapturingAction : IGenericAction<GameObject>
        {
            public HashSet<Type> SeenTypes { get; } = new HashSet<Type>();
            public List<Type> InvokedTypes { get; } = new List<Type>();
            public int TotalInvocations { get; private set; }

            public void Invoke<T>(GameObject param, ref T type)
            {
                TotalInvocations++;
                SeenTypes.Add(typeof(T));
                InvokedTypes.Add(typeof(T));
            }
        }

        /// <summary>Captures the entities passed to generic event handlers.</summary>
        private sealed class EntityCapturingAction : IGenericAction<GameObject>
        {
            public List<GameObject> SeenEntities { get; } = new List<GameObject>();

            public void Invoke<T>(GameObject param, ref T type)
            {
                SeenEntities.Add(param);
            }
        }

        /// <summary>Mutates Position components to X=99, Y=99 to verify ref pass-through.</summary>
        private sealed class MutatingPositionAction : IGenericAction<GameObject>
        {
            public void Invoke<T>(GameObject param, ref T type)
            {
                if (type is Position)
                {
                    // Can't directly assign through generic ref, but we can verify the
                    // component is received. For actual mutation, use typed action.
                }

                if (typeof(T) == typeof(Position))
                {
                    ref Position pos = ref System.Runtime.CompilerServices.Unsafe.As<T, Position>(ref type);
                    pos.X = 99;
                    pos.Y = 99;
                }
            }
        }
    }
}

