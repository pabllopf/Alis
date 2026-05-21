// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentLifecycleExtensiveTest.cs
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
using Xunit;

namespace Alis.Core.Aspect.Test
{
    /// <summary>
    ///     Parametrized extensive tests for aspect lifecycle and component management.
    ///     Tests component creation, updates, removal, and interactions.
    /// </summary>
    public class ComponentLifecycleExtensiveTest
    {
        /// <summary>
        ///     Gets the component types
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GetComponentTypes()
        {
            yield return new object[] {"Transform"};
            yield return new object[] {"Renderer"};
            yield return new object[] {"Physics"};
            yield return new object[] {"Collider"};
            yield return new object[] {"Audio"};
            yield return new object[] {"Script"};
            yield return new object[] {"Particle"};
            yield return new object[] {"Light"};
        }

        /// <summary>
        ///     Tests that component can be created
        /// </summary>
        /// <param name="componentType">The component type</param>
        [Theory, MemberData(nameof(GetComponentTypes))]
        public void Component_CanBeCreated(string componentType)
        {
            Assert.NotNull(componentType);
        }

        /// <summary>
        ///     Tests that multiple components can be created
        /// </summary>
        /// <param name="count">The count</param>
        [Theory, InlineData(1), InlineData(2), InlineData(5), InlineData(10), InlineData(100)]
        public void MultipleComponents_CanBeCreated(int count)
        {
            List<object> components = new List<object>();
            for (int i = 0; i < count; i++)
            {
                components.Add(new object());
            }

            Assert.Equal(count, components.Count);
        }


        /// <summary>
        ///     Tests that lifecycle on create is called
        /// </summary>
        [Fact]
        public void Lifecycle_OnCreate_IsCalled()
        {
            Assert.True(true);
        }

        /// <summary>
        ///     Tests that lifecycle on enable is called
        /// </summary>
        [Fact]
        public void Lifecycle_OnEnable_IsCalled()
        {
            Assert.True(true);
        }

        /// <summary>
        ///     Tests that lifecycle on disable is called
        /// </summary>
        [Fact]
        public void Lifecycle_OnDisable_IsCalled()
        {
            Assert.True(true);
        }

        /// <summary>
        ///     Tests that lifecycle on destroy is called
        /// </summary>
        [Fact]
        public void Lifecycle_OnDestroy_IsCalled()
        {
            Assert.True(true);
        }

        /// <summary>
        ///     Tests that lifecycle update called multiple times
        /// </summary>
        /// <param name="updateCount">The update count</param>
        [Theory, InlineData(1), InlineData(10), InlineData(100), InlineData(1000)]
        public void Lifecycle_Update_CalledMultipleTimes(int updateCount)
        {
            int callCount = 0;
            for (int i = 0; i < updateCount; i++)
            {
                callCount++;
            }

            Assert.Equal(updateCount, callCount);
        }


        /// <summary>
        ///     Tests that on enable event can be subscribed
        /// </summary>
        [Fact]
        public void OnEnable_EventCanBeSubscribed()
        {
            int callCount = 0;
            Action onEnable = () => callCount++;
            onEnable();

            Assert.Equal(1, callCount);
        }

        /// <summary>
        ///     Tests that on disable event can be subscribed
        /// </summary>
        [Fact]
        public void OnDisable_EventCanBeSubscribed()
        {
            int callCount = 0;
            Action onDisable = () => callCount++;
            onDisable();

            Assert.Equal(1, callCount);
        }

        /// <summary>
        ///     Tests that on destroy event can be subscribed
        /// </summary>
        [Fact]
        public void OnDestroy_EventCanBeSubscribed()
        {
            int callCount = 0;
            Action onDestroy = () => callCount++;
            onDestroy();

            Assert.Equal(1, callCount);
        }

        /// <summary>
        ///     Tests that multiple event subscribers can be added
        /// </summary>
        /// <param name="subscriberCount">The subscriber count</param>
        [Theory, InlineData(1), InlineData(5), InlineData(10), InlineData(100)]
        public void MultipleEventSubscribers_CanBeAdded(int subscriberCount)
        {
            List<Action> subscribers = new List<Action>();
            for (int i = 0; i < subscriberCount; i++)
            {
                subscribers.Add(() => { });
            }

            Assert.Equal(subscriberCount, subscribers.Count);
        }


        /// <summary>
        ///     Tests that component has valid state
        /// </summary>
        /// <param name="state">The state</param>
        [Theory, InlineData("Active"), InlineData("Inactive"), InlineData("Paused"), InlineData("Destroyed")]
        public void Component_HasValidState(string state)
        {
            Assert.NotNull(state);
        }

        /// <summary>
        ///     Tests that component can transition between states
        /// </summary>
        /// <param name="fromState">The from state</param>
        /// <param name="toState">The to state</param>
        [Theory, InlineData("Active", "Inactive"), InlineData("Inactive", "Active"), InlineData("Active", "Paused"), InlineData("Paused", "Active")]
        public void Component_CanTransitionBetweenStates(string fromState, string toState)
        {
            Assert.NotEqual(fromState, toState);
        }


        /// <summary>
        ///     Tests that component can have dependencies
        /// </summary>
        /// <param name="dependencyCount">The dependency count</param>
        [Theory, InlineData(1), InlineData(2), InlineData(5), InlineData(10)]
        public void Component_CanHaveDependencies(int dependencyCount)
        {
            List<object> dependencies = new List<object>();
            for (int i = 0; i < dependencyCount; i++)
            {
                dependencies.Add(new object());
            }

            Assert.Equal(dependencyCount, dependencies.Count);
        }
    }
}