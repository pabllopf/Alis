// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectOnlyEventExtendedTest.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Kernel.Events;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Events
{
    /// <summary>
    ///     Extended tests for <see cref="GameObjectOnlyEvent" /> struct
    /// </summary>
    public class GameObjectOnlyEventExtendedTest
    {
        /// <summary>
        ///     Tests that game object only event is value type
        /// </summary>
        [Fact]
        public void GameObjectOnlyEvent_IsValueType()
        {
            Type type = typeof(GameObjectOnlyEvent);

            Assert.True(type.IsValueType);
        }

        /// <summary>
        ///     Tests that game object only event has sequential struct layout
        /// </summary>
        [Fact]
        public void GameObjectOnlyEvent_HasSequentialStructLayout()
        {
            StructLayoutAttribute layout = typeof(GameObjectOnlyEvent).StructLayoutAttribute;

            Assert.Equal(LayoutKind.Sequential, layout.Value);
        }

        /// <summary>
        ///     Tests that has listeners is false when no listeners added
        /// </summary>
        [Fact]
        public void HasListeners_FalseWhenNoListenersAdded()
        {
            GameObjectOnlyEvent evt = new GameObjectOnlyEvent();

            Assert.False(evt.HasListeners);
        }

        /// <summary>
        ///     Tests that has listeners is true after adding listener
        /// </summary>
        [Fact]
        public void HasListeners_TrueAfterAddingListener()
        {
            GameObjectOnlyEvent evt = new GameObjectOnlyEvent();
            evt.Add(_ => { });

            Assert.True(evt.HasListeners);
        }

        /// <summary>
        ///     Tests that add can add multiple listeners
        /// </summary>
        [Fact]
        public void Add_CanAddMultipleListeners()
        {
            GameObjectOnlyEvent evt = new GameObjectOnlyEvent();
            evt.Add(_ => { });
            evt.Add(_ => { });
            evt.Add(_ => { });

            Assert.True(evt.HasListeners);
        }

        /// <summary>
        ///     Tests that remove removes first listener
        /// </summary>
        [Fact]
        public void Remove_RemovesFirstListener()
        {
            GameObjectOnlyEvent evt = new GameObjectOnlyEvent();
            Action<GameObject> listener = _ => { };
            evt.Add(listener);

            evt.Remove(listener);

            Assert.False(evt.HasListeners);
        }

        /// <summary>
        ///     Tests that remove does nothing if listener not found
        /// </summary>
        [Fact]
        public void Remove_DoesNothingIfListenerNotFound()
        {
            GameObjectOnlyEvent evt = new GameObjectOnlyEvent();
            evt.Add(_ => { });
            Action<GameObject> notFound = _ => { };

            evt.Remove(notFound);

            Assert.True(evt.HasListeners);
        }

        /// <summary>
        ///     Tests that remove second listener preserves first
        /// </summary>
        [Fact]
        public void Remove_SecondListener_PreservesFirst()
        {
            GameObjectOnlyEvent evt = new GameObjectOnlyEvent();
            Action<GameObject> first = _ => { };
            Action<GameObject> second = _ => { };
            evt.Add(first);
            evt.Add(second);

            evt.Remove(second);

            Assert.True(evt.HasListeners);
        }

        /// <summary>
        ///     Tests that default event has no listeners
        /// </summary>
        [Fact]
        public void DefaultEvent_HasNoListeners()
        {
            GameObjectOnlyEvent defaultEvt = default(GameObjectOnlyEvent);

            Assert.False(defaultEvt.HasListeners);
        }

        /// <summary>
        ///     Tests that event can be copied
        /// </summary>
        [Fact]
        public void Event_CanBeCopied()
        {
            GameObjectOnlyEvent original = new GameObjectOnlyEvent();
            original.Add(_ => { });

            GameObjectOnlyEvent copy = original;

            Assert.True(copy.HasListeners);
        }
    }
}
