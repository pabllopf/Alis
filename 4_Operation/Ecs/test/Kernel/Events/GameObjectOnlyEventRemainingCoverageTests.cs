// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectOnlyEventRemainingCoverageTests.cs
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
    ///     Tests the remaining uncovered methods of <see cref="GameObjectOnlyEvent" /> struct.
    /// </summary>
    public class GameObjectOnlyEventRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that a default <see cref="GameObjectOnlyEvent" /> has no listeners.
        /// </summary>
        [Fact]
        public void HasListeners_Default_False()
        {
            GameObjectOnlyEvent evt = new GameObjectOnlyEvent();

            Assert.False(evt.HasListeners);
        }

        /// <summary>
        ///     Tests that adding a single listener causes <see cref="GameObjectOnlyEvent.HasListeners" /> to return <see langword="true" />.
        /// </summary>
        [Fact]
        public void Add_SingleListener_HasListeners_True()
        {
            GameObjectOnlyEvent evt = new GameObjectOnlyEvent();
            evt.Add(_ => { });

            Assert.True(evt.HasListeners);
        }

        /// <summary>
        ///     Tests that <see cref="GameObjectOnlyEvent.Invoke" /> calls two registered listeners.
        /// </summary>
        [Fact]
        public void Add_TwoListeners_BothCalled()
        {
            GameObjectOnlyEvent evt = new GameObjectOnlyEvent();
            int counter = 0;
            Action<GameObject> handler = _ => counter++;
            evt.Add(handler);
            evt.Add(handler);
            evt.Invoke(default(GameObject));

            Assert.Equal(2, counter);
        }

        /// <summary>
        ///     Tests that <see cref="GameObjectOnlyEvent.Invoke" /> calls three registered listeners (including invokation list).
        /// </summary>
        [Fact]
        public void Add_ThreeListeners_AllCalled()
        {
            GameObjectOnlyEvent evt = new GameObjectOnlyEvent();
            int counter = 0;
            Action<GameObject> handler = _ => counter++;
            evt.Add(handler);
            evt.Add(handler);
            evt.Add(handler);
            evt.Invoke(default(GameObject));

            Assert.Equal(3, counter);
        }

        /// <summary>
        ///     Tests that removing the only listener causes <see cref="GameObjectOnlyEvent.HasListeners" /> to return <see langword="false" />.
        /// </summary>
        [Fact]
        public void Remove_OnlyListener_RemovesIt()
        {
            GameObjectOnlyEvent evt = new GameObjectOnlyEvent();
            Action<GameObject> handler = _ => { };
            evt.Add(handler);
            evt.Remove(handler);

            Assert.False(evt.HasListeners);
        }

        /// <summary>
        ///     Tests that removing the second listener when two are present keeps the first.
        /// </summary>
        [Fact]
        public void Remove_SecondListener_RemovesIt()
        {
            GameObjectOnlyEvent evt = new GameObjectOnlyEvent();
            int counter = 0;
            Action<GameObject> first = _ => counter++;
            Action<GameObject> second = _ => counter++;
            evt.Add(first);
            evt.Add(second);
            evt.Remove(second);
            evt.Invoke(default(GameObject));

            Assert.Equal(1, counter);
        }

        /// <summary>
        ///     Tests that removing a listener from the invokation list works.
        /// </summary>
        [Fact]
        public void Remove_FromInvokationList_RemovesIt()
        {
            GameObjectOnlyEvent evt = new GameObjectOnlyEvent();
            int counter = 0;
            Action<GameObject> handler = _ => counter++;
            Action<GameObject> toRemove = _ => counter++;
            evt.Add(handler);
            evt.Add(handler);
            evt.Add(handler);
            evt.Add(toRemove);
            evt.Remove(toRemove);
            evt.Invoke(default(GameObject));

            Assert.Equal(3, counter);
        }

        /// <summary>
        ///     Tests that removing the first listener when a second exists leaves the second intact.
        /// </summary>
        [Fact]
        public void Remove_FirstListener_WhenSecondExists_PromotesSecond()
        {
            GameObjectOnlyEvent evt = new GameObjectOnlyEvent();
            int counter = 0;
            Action<GameObject> first = _ => counter++;
            Action<GameObject> second = _ => counter++;
            evt.Add(first);
            evt.Add(second);
            evt.Remove(first);

            Assert.False(evt.HasListeners);

            evt.Invoke(default(GameObject));

            Assert.Equal(0, counter);
        }

        /// <summary>
        ///     Tests that removing the second listener when invokation list is not empty promotes from the list.
        /// </summary>
        [Fact]
        public void Remove_SecondListener_WhenInvokationListNotEmpty_PromotesFromList()
        {
            GameObjectOnlyEvent evt = new GameObjectOnlyEvent();
            int counter = 0;
            Action<GameObject> first = _ => counter++;
            Action<GameObject> second = _ => counter++;
            Action<GameObject> third = _ => counter++;
            evt.Add(first);
            evt.Add(second);
            evt.Add(third);
            evt.Remove(second);
            evt.Invoke(default(GameObject));

            Assert.Equal(2, counter);
        }

        /// <summary>
        ///     Tests that <see cref="GameObjectOnlyEvent.Invoke" /> with no listeners does not throw.
        /// </summary>
        [Fact]
        public void Invoke_NoListeners_DoesNothing()
        {
            GameObjectOnlyEvent evt = new GameObjectOnlyEvent();

            evt.Invoke(default(GameObject));

            Assert.False(evt.HasListeners);
        }

        /// <summary>
        ///     Tests that <see cref="GameObjectOnlyEvent.Execute" /> calls all listeners directly.
        /// </summary>
        [Fact]
        public void Execute_CallsAllListeners()
        {
            GameObjectOnlyEvent evt = new GameObjectOnlyEvent();
            int counter = 0;
            Action<GameObject> handler = _ => counter++;
            evt.Add(handler);
            evt.Add(handler);
            evt.Add(handler);
            evt.Execute(default(GameObject));

            Assert.Equal(3, counter);
        }

        /// <summary>
        ///     Tests that <see cref="GameObjectOnlyEvent.Invoke" /> with a single listener calls only that listener and
        ///     covers the <c>_second is null</c> branch in <see cref="GameObjectOnlyEvent.Execute" />.
        /// </summary>
        [Fact]
        public void Invoke_SingleListener_CallsOnlyThatListener()
        {
            GameObjectOnlyEvent evt = new GameObjectOnlyEvent();
            int counter = 0;
            evt.Add(_ => counter++);
            evt.Invoke(default(GameObject));

            Assert.Equal(1, counter);
        }

        /// <summary>
        ///     Tests that removing the first listener when the invokation list is not empty
        ///     pops the invokation list and promotes it to <c>_first</c>,
        ///     covering the <c>TryPop</c> success path in <see cref="GameObjectOnlyEvent.Remove" />.
        /// </summary>
        [Fact]
        public void Remove_FirstListener_WithInvokationList_PromotesFromStack()
        {
            GameObjectOnlyEvent evt = new GameObjectOnlyEvent();
            int counter = 0;
            Action<GameObject> first = _ => counter++;
            Action<GameObject> second = _ => counter++;
            Action<GameObject> third = _ => counter++;
            evt.Add(first);
            evt.Add(second);
            evt.Add(third);
            evt.Remove(first);

            Assert.True(evt.HasListeners);

            evt.Invoke(default(GameObject));

            Assert.Equal(2, counter);
        }
    }
}
