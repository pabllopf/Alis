// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectBranchCoverageTest.cs
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
using Alis.Core.Ecs.Exceptions;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Targeted branch coverage for <see cref="GameObject" /> methods
    ///     covering event system paths, Delete version mismatch, and Set exception path.
    /// </summary>
    public class GameObjectBranchCoverageTest
    {
        /// <summary>
        ///     Tests that OnComponentAddedGeneric getter on an alive entity returns a non-null GenericEvent
        ///     and sets the AddGenericComp flag on the entity table.
        /// </summary>
        [Fact] public void OnComponentAddedGeneric_OnAliveEntity_ReturnsGenericEvent()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});

                GenericEvent result = entity.OnComponentAddedGeneric;

                Assert.NotNull(result);
            }
        }

        /// <summary>
        ///     Tests that OnComponentRemovedGeneric getter on an alive entity returns a non-null GenericEvent
        ///     and sets the RemoveGenericComp flag on the entity table.
        /// </summary>
        [Fact] public void OnComponentRemovedGeneric_OnAliveEntity_ReturnsGenericEvent()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});

                GenericEvent result = entity.OnComponentRemovedGeneric;

                Assert.NotNull(result);
            }
        }

        /// <summary>
        ///     Tests that subscribing to OnComponentAddedGeneric and adding a component fires the generic event.
        /// </summary>
        [Fact] public void OnComponentAddedGeneric_Handler_FiresOnComponentAdd()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});

                bool fired = false;
                IGenericAction<GameObject> handler = new CallbackGenericAction(() => fired = true);
                entity.OnComponentAddedGeneric += handler;

                entity.Add(new Health {Value = 100});

                Assert.True(fired);
            }
        }

        /// <summary>
        ///     Tests that subscribing to OnComponentRemovedGeneric and removing a component fires the generic event.
        /// </summary>
        [Fact] public void OnComponentRemovedGeneric_Handler_FiresOnComponentRemove()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2}, new Health {Value = 100});

                bool fired = false;
                IGenericAction<GameObject> handler = new CallbackGenericAction(() => fired = true);
                entity.OnComponentRemovedGeneric += handler;

                entity.Remove<Health>();

                Assert.True(fired);
            }
        }

        /// <summary>
        ///     Tests that calling Delete twice does not throw (version mismatch early return).
        /// </summary>
        [Fact] public void Delete_OnAlreadyDeletedEntity_DoesNotThrow()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});

                entity.Delete();

                Exception ex = Record.Exception(() => entity.Delete());
                Assert.Null(ex);
            }
        }

        /// <summary>
        ///     Tests that Set(ComponentId, object) throws ComponentNotFoundException when the entity
        ///     does not have the specified component.
        /// </summary>
        [Fact] public void Set_WithComponentId_ThrowsComponentNotFoundException_WhenComponentDoesNotExist()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});

                Assert.Throws<ComponentNotFoundException>(() =>
                    entity.Set(Component<Velocity>.Id, new Velocity {X = 3, Y = 4}));
            }
        }

        /// <summary>
        ///     Tests that Set(Type, object) throws ComponentNotFoundException when the entity
        ///     does not have the specified component type.
        /// </summary>
        [Fact] public void Set_WithType_ThrowsComponentNotFoundException_WhenComponentDoesNotExist()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});

                Assert.Throws<ComponentNotFoundException>(() =>
                    entity.Set(typeof(Velocity), new Velocity {X = 3, Y = 4}));
            }
        }

        /// <summary>
        ///     Tests that subscribing and unsubscribing OnComponentAdded removes the handler
        ///     and it no longer fires.
        /// </summary>
        [Fact] public void OnComponentAdded_SubscribeAndUnsubscribe_HandlerNotInvoked()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});

                int calls = 0;
                void Handler(GameObject _, ComponentId __) => calls++;

                entity.OnComponentAdded += Handler;
                entity.OnComponentAdded -= Handler;

                entity.Add(new Health {Value = 100});

                Assert.Equal(0, calls);
            }
        }

        /// <summary>
        ///     Tests that subscribing and unsubscribing OnDelete removes the handler
        ///     and it no longer fires.
        /// </summary>
        [Fact] public void OnDelete_SubscribeAndUnsubscribe_HandlerNotInvoked()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});

                int calls = 0;
                void Handler(GameObject _) => calls++;

                entity.OnDelete += Handler;
                entity.OnDelete -= Handler;

                entity.Delete();

                Assert.Equal(0, calls);
            }
        }

        /// <summary>
        ///     Tests that GetHashCode is consistent for the same entity.
        /// </summary>
        [Fact] public void GetHashCode_IsConsistent_ForSameEntity()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});

                int hash1 = entity.GetHashCode();
                int hash2 = entity.GetHashCode();

                Assert.Equal(hash1, hash2);
            }
        }

        /// <summary>
        ///     Tests that InternalIsAlive returns false when scene is null (WorldID doesn't match any scene).
        ///     This exercises the first branch in InternalIsAlive (scene is null).
        /// </summary>
        [Fact] public void IsAlive_WithInvalidWorldId_ReturnsFalse()
        {
            GameObject invalidEntity = new GameObject();

            Assert.False(invalidEntity.IsAlive);
        }

        /// <summary>
        ///     Tests that TryGetCore returns exists=false when entity is dead (InternalIsAlive fails).
        /// </summary>
        [Fact] public void TryGetCore_OnDeadEntity_ReturnsExistsFalse()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 2});
                entity.Delete();

                entity.TryGetCore<Position>(out bool exists);

                Assert.False(exists);
            }
        }

        /// <summary>
        ///     A simple <see cref="IGenericAction{GameObject}" /> that invokes a callback.
        /// </summary>
        internal sealed class CallbackGenericAction : IGenericAction<GameObject>
        {
            /// <summary>
            /// The callback
            /// </summary>
            internal readonly Action _callback;

            /// <summary>
            /// Initializes a new instance of the <see cref="CallbackGenericAction"/> class
            /// </summary>
            /// <param name="callback">The callback</param>
            public CallbackGenericAction(Action callback) => _callback = callback;

            /// <summary>
            /// Invokes the param
            /// </summary>
            /// <typeparam name="T">The </typeparam>
            /// <param name="param">The param</param>
            /// <param name="type">The type</param>
            public void Invoke<T>(GameObject param, ref T type) => _callback();
        }
    }
}
