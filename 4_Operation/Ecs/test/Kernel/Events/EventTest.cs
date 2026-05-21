

using System;
using Alis.Core.Ecs.Kernel.Events;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Events
{
    /// <summary>
    ///     Tests the <see cref="Event{T}" /> struct.
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
            Event<int> @event = new();

            Assert.False(@event.HasListeners);
        }

        /// <summary>
        ///     Tests that adding an action to the event works correctly.
        /// </summary>
        [Fact]
        public void Add_WithAction_ShouldMarkEventAsHavingListeners()
        {
            Event<int> @event = new();
            Action<GameObject, int> action = (_, _) => { };

            @event.Add(action);

            Assert.True(@event.HasListeners);
        }

        /// <summary>
        ///     Tests that invoking an event with a single listener invokes the listener.
        /// </summary>
        [Fact]
        public void Invoke_WithSingleListener_ShouldInvokeThatListener()
        {
            Event<int> @event = new();
            bool invoked = false;
            int passedValue = 0;
            Action<GameObject, int> action = (_, value) =>
            {
                invoked = true;
                passedValue = value;
            };
            @event.Add(action);

            @event.Invoke(default(GameObject), 42);

            Assert.True(invoked);
            Assert.Equal(42, passedValue);
        }

        /// <summary>
        ///     Tests that invoking an event with multiple listeners invokes all listeners.
        /// </summary>
        [Fact]
        public void Invoke_WithMultipleListeners_ShouldInvokeAllListeners()
        {
            Event<int> @event = new();
            int callCount = 0;
            Action<GameObject, int> action1 = (_, _) => callCount++;
            Action<GameObject, int> action2 = (_, _) => callCount++;
            Action<GameObject, int> action3 = (_, _) => callCount++;

            @event.Add(action1);
            @event.Add(action2);
            @event.Add(action3);

            @event.Invoke(default(GameObject), 0);

            Assert.Equal(3, callCount);
        }

        /// <summary>
        ///     Tests that removing a listener that exists works correctly.
        /// </summary>
        [Fact]
        public void Remove_WithExistingListener_ShouldRemoveListener()
        {
            Event<int> @event = new();
            int callCount = 0;
            Action<GameObject, int> action1 = (_, _) => callCount++;
            Action<GameObject, int> action2 = (_, _) => callCount++;

            @event.Add(action1);
            @event.Add(action2);

            @event.Remove(action1);
            @event.Invoke(default(GameObject), 0);

            Assert.Equal(1, callCount);
        }

        /// <summary>
        ///     Tests that removing the only listener marks event as having no listeners.
        /// </summary>
        [Fact]
        public void Remove_WithOnlyListener_ShouldMarkEventAsHavingNoListeners()
        {
            Event<int> @event = new();
            Action<GameObject, int> action = (_, _) => { };
            @event.Add(action);

            @event.Remove(action);

            Assert.False(@event.HasListeners);
        }

        /// <summary>
        ///     Tests that removing the first listener from multiple listeners keeps others.
        /// </summary>
        [Fact]
        public void Remove_WithFirstListenerFromMultiple_ShouldKeepOthers()
        {
            Event<int> @event = new();
            int callCount = 0;
            Action<GameObject, int> action1 = (_, _) => callCount++;
            Action<GameObject, int> action2 = (_, _) => callCount++;
            Action<GameObject, int> action3 = (_, _) => callCount++;

            @event.Add(action1);
            @event.Add(action2);
            @event.Add(action3);

            @event.Remove(action1);
            @event.Invoke(default(GameObject), 0);

            Assert.Equal(2, callCount);
        }

        /// <summary>
        ///     Tests that removing a non-existing listener doesn't affect the event.
        /// </summary>
        [Fact]
        public void Remove_WithNonExistingListener_ShouldNotAffectEvent()
        {
            Event<int> @event = new();
            int callCount = 0;
            Action<GameObject, int> action1 = (_, _) => callCount++;
            Action<GameObject, int> action2 = (_, _) => callCount++;
            Action<GameObject, int> action3 = (_, _) => { };

            @event.Add(action1);
            @event.Add(action2);

            @event.Remove(action3);
            @event.Invoke(default(GameObject), 0);

            Assert.Equal(2, callCount);
        }

        /// <summary>
        ///     Tests that adding the same listener multiple times registers it multiple times.
        /// </summary>
        [Fact]
        public void Add_WithSameListenerMultipleTimes_ShouldRegisterMultipleTimes()
        {
            Event<int> @event = new();
            int callCount = 0;
            Action<GameObject, int> action = (_, _) => callCount++;

            @event.Add(action);
            @event.Add(action);
            @event.Add(action);
            @event.Invoke(default(GameObject), 0);

            Assert.Equal(3, callCount);
        }

        /// <summary>
        ///     Tests that invoke passes the correct GameObject to listeners.
        /// </summary>
        [Fact]
        public void Invoke_ShouldPassCorrectGameObjectToListener()
        {
            Scene scene = new();
            GameObject gameObject = scene.Create();
            Event<int> @event = new();
            GameObject passedGameObject = default(GameObject);

            Action<GameObject, int> action = (go, _) => { passedGameObject = go; };
            @event.Add(action);

            @event.Invoke(gameObject, 0);

            Assert.Equal(gameObject, passedGameObject);

            scene.Dispose();
        }

        /// <summary>
        ///     Tests that invoke works with different argument types.
        /// </summary>
        [Fact]
        public void Invoke_WithDifferentArgumentTypes_ShouldPassArgumentCorrectly()
        {
            Event<string> @event = new();
            string passedValue = null;

            Action<GameObject, string> action = (_, value) => { passedValue = value; };
            @event.Add(action);

            @event.Invoke(default(GameObject), "test");

            Assert.Equal("test", passedValue);
        }

        /// <summary>
        ///     Tests that multiple removals and additions work correctly.
        /// </summary>
        [Fact]
        public void RemoveAndAdd_WithMultipleOperations_ShouldMaintainCorrectState()
        {
            Event<int> @event = new();
            int callCount = 0;
            Action<GameObject, int> action1 = (_, _) => callCount++;
            Action<GameObject, int> action2 = (_, _) => callCount++;

            @event.Add(action1);
            @event.Add(action2);
            @event.Remove(action1);

            @event.Add(action1);
            @event.Invoke(default(GameObject), 0);

            Assert.Equal(2, callCount);
        }
    }
}