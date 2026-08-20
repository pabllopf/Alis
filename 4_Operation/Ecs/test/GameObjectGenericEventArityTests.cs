// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectGenericEventArityTests.cs
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

using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Tests the multi-arity generic event invocation paths of <see cref="GameObject" />.
    /// </summary>
    public class GameObjectGenericEventArityTests
    {
        /// <summary>
        ///     The no op generic action
        /// </summary>
        private static readonly NoOpGenericAction NoOp = new NoOpGenericAction();

        /// <summary>
        ///     Tests that the arity 2 per entity event invocation fires the generic event.
        /// </summary>
        [Fact]
        public void InvokePerEntityEvents_Arity2_WithGenericEvent_FiresGenericEvent()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();
                ComponentEvent events = new ComponentEvent {GenericEvent = CreateGenericEvent()};
                Position position = new Position {X = 1, Y = 2};
                Velocity velocity = new Velocity {X = 3, Y = 4};

                GameObject.InvokePerEntityEvents(entity, true, ref events, ref position, ref velocity);
            }
        }

        /// <summary>
        ///     Tests that the arity 3 per entity event invocation fires the generic event.
        /// </summary>
        [Fact]
        public void InvokePerEntityEvents_Arity3_WithGenericEvent_FiresGenericEvent()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();
                ComponentEvent events = new ComponentEvent {GenericEvent = CreateGenericEvent()};
                Position position = new Position {X = 1, Y = 2};
                Velocity velocity = new Velocity {X = 3, Y = 4};
                Health health = new Health {Value = 100};

                GameObject.InvokePerEntityEvents(entity, true, ref events, ref position, ref velocity, ref health);
            }
        }

        /// <summary>
        ///     Tests that the arity 4 per entity event invocation fires the generic event.
        /// </summary>
        [Fact]
        public void InvokePerEntityEvents_Arity4_WithGenericEvent_FiresGenericEvent()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();
                ComponentEvent events = new ComponentEvent {GenericEvent = CreateGenericEvent()};
                Position position = new Position {X = 1, Y = 2};
                Velocity velocity = new Velocity {X = 3, Y = 4};
                Health health = new Health {Value = 100};
                Armor armor = new Armor {Value = 30};

                GameObject.InvokePerEntityEvents(entity, true, ref events, ref position, ref velocity, ref health, ref armor);
            }
        }

        /// <summary>
        ///     Tests that the arity 5 per entity event invocation fires the generic event.
        /// </summary>
        [Fact]
        public void InvokePerEntityEvents_Arity5_WithGenericEvent_FiresGenericEvent()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();
                ComponentEvent events = new ComponentEvent {GenericEvent = CreateGenericEvent()};
                Position position = new Position {X = 1, Y = 2};
                Velocity velocity = new Velocity {X = 3, Y = 4};
                Health health = new Health {Value = 100};
                Armor armor = new Armor {Value = 30};
                Damage damage = new Damage {Value = 7};

                GameObject.InvokePerEntityEvents(entity, true, ref events, ref position, ref velocity, ref health, ref armor,
                    ref damage);
            }
        }

        /// <summary>
        ///     Tests that the arity 6 per entity event invocation fires the generic event.
        /// </summary>
        [Fact]
        public void InvokePerEntityEvents_Arity6_WithGenericEvent_FiresGenericEvent()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();
                ComponentEvent events = new ComponentEvent {GenericEvent = CreateGenericEvent()};
                Position position = new Position {X = 1, Y = 2};
                Velocity velocity = new Velocity {X = 3, Y = 4};
                Health health = new Health {Value = 100};
                Armor armor = new Armor {Value = 30};
                Damage damage = new Damage {Value = 7};
                Transform transform = new Transform {X = 0, Y = 0, Rotation = 0};

                GameObject.InvokePerEntityEvents(entity, true, ref events, ref position, ref velocity, ref health, ref armor,
                    ref damage, ref transform);
            }
        }

        /// <summary>
        ///     Tests that the arity 7 per entity event invocation fires the generic event.
        /// </summary>
        [Fact]
        public void InvokePerEntityEvents_Arity7_WithGenericEvent_FiresGenericEvent()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();
                ComponentEvent events = new ComponentEvent {GenericEvent = CreateGenericEvent()};
                Position position = new Position {X = 1, Y = 2};
                Velocity velocity = new Velocity {X = 3, Y = 4};
                Health health = new Health {Value = 100};
                Armor armor = new Armor {Value = 30};
                Damage damage = new Damage {Value = 7};
                Transform transform = new Transform {X = 0, Y = 0, Rotation = 0};
                TestComponent test = new TestComponent {Value = 5};

                GameObject.InvokePerEntityEvents(entity, true, ref events, ref position, ref velocity, ref health, ref armor,
                    ref damage, ref transform, ref test);
            }
        }

        /// <summary>
        ///     Tests that the arity 8 per entity event invocation fires the generic event.
        /// </summary>
        [Fact]
        public void InvokePerEntityEvents_Arity8_WithGenericEvent_FiresGenericEvent()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();
                ComponentEvent events = new ComponentEvent {GenericEvent = CreateGenericEvent()};
                Position position = new Position {X = 1, Y = 2};
                Velocity velocity = new Velocity {X = 3, Y = 4};
                Health health = new Health {Value = 100};
                Armor armor = new Armor {Value = 30};
                Damage damage = new Damage {Value = 7};
                Transform transform = new Transform {X = 0, Y = 0, Rotation = 0};
                TestComponent test = new TestComponent {Value = 5};
                AnotherComponent another = new AnotherComponent {Data = 10, Y = 3};

                GameObject.InvokePerEntityEvents(entity, true, ref events, ref position, ref velocity, ref health, ref armor,
                    ref damage, ref transform, ref test, ref another);
            }
        }

        /// <summary>
        ///     Creates a generic event with the no op action registered
        /// </summary>
        /// <returns>The generic event</returns>
        private static GenericEvent CreateGenericEvent()
        {
            GenericEvent genericEvent = new GenericEvent();
            genericEvent.Add(NoOp);
            return genericEvent;
        }

        /// <summary>
        ///     The no op generic action class
        /// </summary>
        /// <seealso cref="IGenericAction" />
        internal sealed class NoOpGenericAction : IGenericAction<GameObject>
        {
            /// <summary>
            ///     Invokes the action using the specified game object and component
            /// </summary>
            /// <typeparam name="T">The component type</typeparam>
            /// <param name="gameObject">The game object</param>
            /// <param name="component">The component</param>
            public void Invoke<T>(GameObject gameObject, ref T component)
            {
            }
        }
    }
}
