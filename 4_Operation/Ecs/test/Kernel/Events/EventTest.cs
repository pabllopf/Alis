// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EventTest.cs
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
using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Events
{
    /// <summary>
    ///     Tests the <see cref="Event{T}"/> struct.
    /// </summary>
    /// <remarks>
    ///     The Event{T} is a generic event system that allows listeners to be added and removed,
    ///     and provides a way to invoke all registered listeners with a gameObject and argument.
    /// </remarks>
    public class EventTest
    {
        /// <summary>
        ///     Tests that a new event has no listeners.
        /// </summary>
        [Fact]
        public void Event_WhenCreated_ShouldHaveNoListeners()
        {
            // Arrange & Act
            Event<int> @event = new();

            // Assert
            Assert.False(@event.HasListeners);
        }

        /// <summary>
        ///     Tests that adding an action to the event works correctly.
        /// </summary>
        [Fact]
        public void Add_WithAction_ShouldMarkEventAsHavingListeners()
        {
            // Arrange
            Event<int> @event = new();
            Action<GameObject, int> action = (_, _) => { };

            // Act
            @event.Add(action);

            // Assert
            Assert.True(@event.HasListeners);
        }

        /// <summary>
        ///     Tests that invoking an event with a single listener invokes the listener.
        /// </summary>
        [Fact]
        public void Invoke_WithSingleListener_ShouldInvokeThatListener()
        {
            // Arrange
            Event<int> @event = new();
            bool invoked = false;
            int passedValue = 0;
            Action<GameObject, int> action = (_, value) =>
            {
                invoked = true;
                passedValue = value;
            };
            @event.Add(action);

            // Act
            @event.Invoke(default, 42);

            // Assert
            Assert.True(invoked);
            Assert.Equal(42, passedValue);
        }

        /// <summary>
        ///     Tests that invoking an event with multiple listeners invokes all listeners.
        /// </summary>
        [Fact]
        public void Invoke_WithMultipleListeners_ShouldInvokeAllListeners()
        {
            // Arrange
            Event<int> @event = new();
            int callCount = 0;
            Action<GameObject, int> action1 = (_, _) => callCount++;
            Action<GameObject, int> action2 = (_, _) => callCount++;
            Action<GameObject, int> action3 = (_, _) => callCount++;

            @event.Add(action1);
            @event.Add(action2);
            @event.Add(action3);

            // Act
            @event.Invoke(default, 0);

            // Assert
            Assert.Equal(3, callCount);
        }

        /// <summary>
        ///     Tests that removing a listener that exists works correctly.
        /// </summary>
        [Fact]
        public void Remove_WithExistingListener_ShouldRemoveListener()
        {
            // Arrange
            Event<int> @event = new();
            int callCount = 0;
            Action<GameObject, int> action1 = (_, _) => callCount++;
            Action<GameObject, int> action2 = (_, _) => callCount++;

            @event.Add(action1);
            @event.Add(action2);

            // Act
            @event.Remove(action1);
            @event.Invoke(default, 0);

            // Assert
            Assert.Equal(1, callCount);
        }

        /// <summary>
        ///     Tests that removing the only listener marks event as having no listeners.
        /// </summary>
        [Fact]
        public void Remove_WithOnlyListener_ShouldMarkEventAsHavingNoListeners()
        {
            // Arrange
            Event<int> @event = new();
            Action<GameObject, int> action = (_, _) => { };
            @event.Add(action);

            // Act
            @event.Remove(action);

            // Assert
            Assert.False(@event.HasListeners);
        }

        /// <summary>
        ///     Tests that removing the first listener from multiple listeners keeps others.
        /// </summary>
        [Fact]
        public void Remove_WithFirstListenerFromMultiple_ShouldKeepOthers()
        {
            // Arrange
            Event<int> @event = new();
            int callCount = 0;
            Action<GameObject, int> action1 = (_, _) => callCount++;
            Action<GameObject, int> action2 = (_, _) => callCount++;
            Action<GameObject, int> action3 = (_, _) => callCount++;

            @event.Add(action1);
            @event.Add(action2);
            @event.Add(action3);

            // Act
            @event.Remove(action1);
            @event.Invoke(default, 0);

            // Assert
            Assert.Equal(2, callCount);
        }

        /// <summary>
        ///     Tests that removing a non-existing listener doesn't affect the event.
        /// </summary>
        [Fact]
        public void Remove_WithNonExistingListener_ShouldNotAffectEvent()
        {
            // Arrange
            Event<int> @event = new();
            int callCount = 0;
            Action<GameObject, int> action1 = (_, _) => callCount++;
            Action<GameObject, int> action2 = (_, _) => callCount++;
            Action<GameObject, int> action3 = (_, _) => { };

            @event.Add(action1);
            @event.Add(action2);

            // Act
            @event.Remove(action3);
            @event.Invoke(default, 0);

            // Assert
            Assert.Equal(2, callCount);
        }

        /// <summary>
        ///     Tests that adding the same listener multiple times registers it multiple times.
        /// </summary>
        [Fact]
        public void Add_WithSameListenerMultipleTimes_ShouldRegisterMultipleTimes()
        {
            // Arrange
            Event<int> @event = new();
            int callCount = 0;
            Action<GameObject, int> action = (_, _) => callCount++;

            // Act
            @event.Add(action);
            @event.Add(action);
            @event.Add(action);
            @event.Invoke(default, 0);

            // Assert
            Assert.Equal(3, callCount);
        }

        /// <summary>
        ///     Tests that invoke passes the correct GameObject to listeners.
        /// </summary>
        [Fact]
        public void Invoke_ShouldPassCorrectGameObjectToListener()
        {
            // Arrange
            Scene scene = new();
            GameObject gameObject = scene.Create();
            Event<int> @event = new();
            GameObject passedGameObject = default;

            Action<GameObject, int> action = (go, _) =>
            {
                passedGameObject = go;
            };
            @event.Add(action);

            // Act
            @event.Invoke(gameObject, 0);

            // Assert
            Assert.Equal(gameObject, passedGameObject);
            
            // Cleanup
            scene.Dispose();
        }

        /// <summary>
        ///     Tests that invoke works with different argument types.
        /// </summary>
        [Fact]
        public void Invoke_WithDifferentArgumentTypes_ShouldPassArgumentCorrectly()
        {
            // Arrange
            Event<string> @event = new();
            string passedValue = null;

            Action<GameObject, string> action = (_, value) =>
            {
                passedValue = value;
            };
            @event.Add(action);

            // Act
            @event.Invoke(default, "test");

            // Assert
            Assert.Equal("test", passedValue);
        }

        /// <summary>
        ///     Tests that multiple removals and additions work correctly.
        /// </summary>
        [Fact]
        public void RemoveAndAdd_WithMultipleOperations_ShouldMaintainCorrectState()
        {
            // Arrange
            Event<int> @event = new();
            int callCount = 0;
            Action<GameObject, int> action1 = (_, _) => callCount++;
            Action<GameObject, int> action2 = (_, _) => callCount++;

            @event.Add(action1);
            @event.Add(action2);
            @event.Remove(action1);

            // Act
            @event.Add(action1);
            @event.Invoke(default, 0);

            // Assert
            Assert.Equal(2, callCount);
        }
    }
}

