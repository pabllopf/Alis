// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EventRemainingCoverageTests.cs
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
using Alis.Core.Ecs.Kernel.Events;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Events
{
    /// <summary>
    ///     Tests the remaining uncovered methods of <see cref="Event{T}" /> struct.
    /// </summary>
    public class EventRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that a default <see cref="Event{T}" /> has no listeners.
        /// </summary>
        [Fact]
        public void Default_HasNoListeners()
        {
            Event<int> e = new Event<int>();

            Assert.False(e.HasListeners);
        }

        /// <summary>
        ///     Tests that adding a single listener causes <see cref="Event{T}.HasListeners" /> to return <see langword="true" />.
        /// </summary>
        [Fact]
        public void Add_SingleListener_HasListeners()
        {
            Event<int> e = new Event<int>();
            e.Add((go, arg) => { });

            Assert.True(e.HasListeners);
        }

        /// <summary>
        ///     Tests that <see cref="Event{T}.Invoke" /> calls a single registered listener.
        /// </summary>
        [Fact]
        public void Add_AndInvoke_CallsListener()
        {
            Event<int> e = new Event<int>();
            bool flag = false;
            e.Add((go, arg) => flag = true);
            e.Invoke(default(GameObject), 42);

            Assert.True(flag);
        }

        /// <summary>
        ///     Tests that <see cref="Event{T}.Invoke" /> calls all registered listeners.
        /// </summary>
        [Fact]
        public void Add_MultipleListeners_AllCalled()
        {
            Event<int> e = new Event<int>();
            int counter = 0;
            Action<GameObject, int> handler = (go, arg) => counter++;
            e.Add(handler);
            e.Add(handler);
            e.Add(handler);
            e.Invoke(default(GameObject), 0);

            Assert.Equal(3, counter);
        }

        /// <summary>
        ///     Tests that removing the only listener causes <see cref="Event{T}.HasListeners" /> to return <see langword="false" />.
        /// </summary>
        [Fact]
        public void Remove_OnlyListener_RemovesIt()
        {
            Event<int> e = new Event<int>();
            Action<GameObject, int> handler = (go, arg) => { };
            e.Add(handler);
            e.Remove(handler);

            Assert.False(e.HasListeners);
        }

        /// <summary>
        ///     Tests that removing one of multiple listeners removes only that listener.
        /// </summary>
        [Fact]
        public void Remove_OneOfMultipleListeners_RemovesIt()
        {
            Event<int> e = new Event<int>();
            int counter = 0;
            Action<GameObject, int> handler1 = (go, arg) => counter++;
            Action<GameObject, int> handler2 = (go, arg) => counter++;
            Action<GameObject, int> handler3 = (go, arg) => counter++;
            e.Add(handler1);
            e.Add(handler2);
            e.Add(handler3);
            e.Remove(handler2);
            e.Invoke(default(GameObject), 0);

            Assert.Equal(2, counter);
        }

        /// <summary>
        ///     Tests that removing the first of multiple listeners correctly promotes the next listener.
        /// </summary>
        [Fact]
        public void Remove_FirstOfMultipleListeners_RemovesIt()
        {
            Event<int> e = new Event<int>();
            int counter = 0;
            Action<GameObject, int> handler1 = (go, arg) => counter++;
            Action<GameObject, int> handler2 = (go, arg) => counter++;
            Action<GameObject, int> handler3 = (go, arg) => counter++;
            e.Add(handler1);
            e.Add(handler2);
            e.Add(handler3);
            e.Remove(handler1);
            e.Invoke(default(GameObject), 0);

            Assert.Equal(2, counter);
        }

        /// <summary>
        ///     Tests that removing a listener that was never added does not affect the event state.
        /// </summary>
        [Fact]
        public void Remove_ListenerNotPresent_DoesNothing()
        {
            Event<int> e = new Event<int>();
            Action<GameObject, int> handler1 = (go, arg) => { };
            Action<GameObject, int> handler2 = (go, arg) => { };
            e.Add(handler1);
            e.Remove(handler2);

            Assert.True(e.HasListeners);
        }

        /// <summary>
        ///     Tests that <see cref="Event{T}.InvokeInternal" /> calls all listeners without throwing.
        /// </summary>
        [Fact]
        public void InvokeInternal_CallsAllListeners()
        {
            Event<int> e = new Event<int>();
            bool flag = false;
            e.Add((go, arg) => flag = true);

            e.InvokeInternal(default(GameObject), 0);

            Assert.True(flag);
        }

        /// <summary>
        ///     Tests that <see cref="Event{T}.Invoke" /> with no listeners does nothing and does not throw.
        /// </summary>
        [Fact]
        public void Invoke_WithNoListeners_DoesNothing()
        {
            Event<int> e = new Event<int>();

            e.Invoke(default(GameObject), 0);

            Assert.False(e.HasListeners);
        }
    }
}
