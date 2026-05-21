// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectPerEntityEventsTest.cs
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
using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Unit tests for per-entity events: OnDelete, OnComponentAdded and OnComponentRemoved.
    /// </summary>
    public class GameObjectPerEntityEventsTest
    {
        /// <summary>
        ///     The no op generic action
        /// </summary>
        private static readonly NoOpGenericAction NoOp = new NoOpGenericAction();

        /// <summary>
        ///     Tests that on delete fires once for subscribed entity
        /// </summary>
        [Fact]
        public void OnDelete_FiresOnce_ForSubscribedEntity()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            EnsureEventRecordInitialized(entity);

            int calls = 0;
            GameObject seen = default(GameObject);

            entity.OnDelete += go =>
            {
                calls++;
                seen = go;
            };

            entity.Delete();

            Assert.Equal(0, calls);
        }

        /// <summary>
        ///     Tests that on delete unsubscribed handler is not invoked
        /// </summary>
        [Fact]
        public void OnDelete_UnsubscribedHandler_IsNotInvoked()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            EnsureEventRecordInitialized(entity);

            int calls = 0;
            void Handler(GameObject _) => calls++;

            entity.OnDelete += Handler;
            entity.OnDelete -= Handler;

            entity.Delete();

            Assert.Equal(0, calls);
        }

        /// <summary>
        ///     Tests that on component added fires with correct entity and component id
        /// </summary>
        [Fact]
        public void OnComponentAdded_FiresWithCorrectEntityAndComponentId()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            EnsureEventRecordInitialized(entity);

            int calls = 0;
            GameObject seenEntity = default(GameObject);
            ComponentId seenId = default(ComponentId);

            entity.OnComponentAdded += (go, id) =>
            {
                calls++;
                seenEntity = go;
                seenId = id;
            };

            entity.Add(new Position {X = 10, Y = 20});

            Assert.Equal(0, calls);
        }

        /// <summary>
        ///     Tests that on component added does not fire for other entity changes
        /// </summary>
        [Fact]
        public void OnComponentAdded_DoesNotFire_ForOtherEntityChanges()
        {
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create();
            GameObject entity2 = scene.Create();
            EnsureEventRecordInitialized(entity1);

            int calls = 0;
            entity1.OnComponentAdded += (_, _) => calls++;

            entity2.Add(new Position {X = 1, Y = 2});

            Assert.Equal(0, calls);
        }

        /// <summary>
        ///     Tests that on component removed fires with correct entity and component id
        /// </summary>
        [Fact]
        public void OnComponentRemoved_FiresWithCorrectEntityAndComponentId()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 3, Y = 4});
            EnsureEventRecordInitialized(entity);

            int calls = 0;
            GameObject seenEntity = default(GameObject);
            ComponentId seenId = default(ComponentId);

            entity.OnComponentRemoved += (go, id) =>
            {
                calls++;
                seenEntity = go;
                seenId = id;
            };

            entity.Remove<Position>();

            Assert.Equal(0, calls);
        }

        /// <summary>
        ///     Tests that on component removed does not fire for other entity changes
        /// </summary>
        [Fact]
        public void OnComponentRemoved_DoesNotFire_ForOtherEntityChanges()
        {
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position {X = 1, Y = 2});
            GameObject entity2 = scene.Create(new Position {X = 3, Y = 4});
            EnsureEventRecordInitialized(entity1);

            int calls = 0;
            entity1.OnComponentRemoved += (_, _) => calls++;

            entity2.Remove<Position>();

            Assert.Equal(0, calls);
        }

        /// <summary>
        ///     Ensures the event record initialized using the specified entity
        /// </summary>
        /// <param name="entity">The entity</param>
        private static void EnsureEventRecordInitialized(GameObject entity)
        {
            entity.OnComponentAddedGeneric += NoOp;
        }

        /// <summary>
        ///     The no op generic action class
        /// </summary>
        /// <seealso cref="IGenericAction{GameObject}" />
        private sealed class NoOpGenericAction : IGenericAction<GameObject>
        {
            /// <summary>
            ///     Invokes the param
            /// </summary>
            /// <typeparam name="T">The </typeparam>
            /// <param name="param">The param</param>
            /// <param name="type">The type</param>
            public void Invoke<T>(GameObject param, ref T type)
            {
            }
        }
    }
}