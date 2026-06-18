// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectOnlyEventInvokeTest.cs
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
    ///     Tests for <see cref="GameObjectOnlyEvent.Invoke" /> and related execution paths.
    /// </summary>
    public class GameObjectOnlyEventInvokeTest
    {
        /// <summary>
        ///     Tests that invoke with no listeners does not throw.
        /// </summary>
        [Fact]
        public void Invoke_WithNoListeners_DoesNotThrow()
        {
            GameObjectOnlyEvent evt = new GameObjectOnlyEvent();

            evt.Invoke(default(GameObject));
        }

        /// <summary>
        ///     Tests that invoke with a single listener executes it.
        /// </summary>
        [Fact]
        public void Invoke_WithSingleListener_ExecutesIt()
        {
            GameObjectOnlyEvent evt = new GameObjectOnlyEvent();
            bool called = false;
            evt.Add(_ => called = true);

            evt.Invoke(default(GameObject));

            Assert.True(called);
        }

        /// <summary>
        ///     Tests that invoke with two listeners executes both.
        /// </summary>
        [Fact]
        public void Invoke_WithTwoListeners_ExecutesBoth()
        {
            GameObjectOnlyEvent evt = new GameObjectOnlyEvent();
            bool firstCalled = false;
            bool secondCalled = false;
            evt.Add(_ => firstCalled = true);
            evt.Add(_ => secondCalled = true);

            evt.Invoke(default(GameObject));

            Assert.True(firstCalled);
            Assert.True(secondCalled);
        }

        /// <summary>
        ///     Tests that invoke with many listeners executes all.
        /// </summary>
        [Fact]
        public void Invoke_WithManyListeners_ExecutesAll()
        {
            GameObjectOnlyEvent evt = new GameObjectOnlyEvent();
            int callCount = 0;
            Action<GameObject> listener = _ => callCount++;
            evt.Add(listener);
            evt.Add(listener);
            evt.Add(listener);
            evt.Add(listener);

            evt.Invoke(default(GameObject));

            Assert.Equal(4, callCount);
        }

        /// <summary>
        ///     Tests that remove promotes from stack when first is removed.
        /// </summary>
        [Fact]
        public void Remove_WithMultipleListeners_RemovingFirstPromotesFromStack()
        {
            GameObjectOnlyEvent evt = new GameObjectOnlyEvent();
            int callCount = 0;
            Action<GameObject> first = _ => callCount++;
            Action<GameObject> second = _ => callCount++;
            Action<GameObject> third = _ => callCount++;
            evt.Add(first);
            evt.Add(second);
            evt.Add(third);

            evt.Remove(first);

            evt.Invoke(default(GameObject));
            Assert.Equal(2, callCount);
        }

        /// <summary>
        ///     Tests that remove promotes from stack when second is removed.
        /// </summary>
        [Fact]
        public void Remove_WithMultipleListeners_RemovingSecondPromotesFromStack()
        {
            GameObjectOnlyEvent evt = new GameObjectOnlyEvent();
            int callCount = 0;
            Action<GameObject> first = _ => callCount++;
            Action<GameObject> second = _ => callCount++;
            Action<GameObject> third = _ => callCount++;
            Action<GameObject> fourth = _ => callCount++;
            evt.Add(first);
            evt.Add(second);
            evt.Add(third);
            evt.Add(fourth);

            evt.Remove(second);

            evt.Invoke(default(GameObject));
            Assert.Equal(3, callCount);
        }

        /// <summary>
        ///     Tests that remove promotes from stack and remaining listeners still fire.
        /// </summary>
        [Fact]
        public void Remove_WithMultipleListeners_RemovingAllLeavesNoListeners()
        {
            GameObjectOnlyEvent evt = new GameObjectOnlyEvent();
            Action<GameObject> first = _ => { };
            Action<GameObject> second = _ => { };
            Action<GameObject> third = _ => { };
            evt.Add(first);
            evt.Add(second);
            evt.Add(third);

            evt.Remove(first);
            evt.Remove(second);

            Assert.True(evt.HasListeners);

            evt.Remove(third);

            Assert.False(evt.HasListeners);
        }
    }
}
