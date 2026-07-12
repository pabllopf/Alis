// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentEventBasicTest.cs
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
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Events
{
    /// <summary>
    ///     The component event test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="ComponentEvent" /> and related event structures
    ///     which are used to notify systems when components are added or removed.
    /// </remarks>
    public class ComponentEventTest
    {
        /// <summary>
        ///     Tests that HasListeners is false by default.
        /// </summary>
        [Fact]
        public void HasListeners_DefaultIsFalse()
        {
            ComponentEvent evt = new ComponentEvent();

            Assert.False(evt.HasListeners);
        }

        /// <summary>
        ///     Tests that HasListeners is true when NormalEvent has listeners.
        /// </summary>
        [Fact]
        public void HasListeners_TrueWhenNormalEventHasListeners()
        {
            ComponentEvent evt = new ComponentEvent();
            evt.NormalEvent.Add(OnEvent);

            Assert.True(evt.HasListeners);
        }

        /// <summary>
        ///     Tests that HasListeners is true when GenericEvent has listeners.
        /// </summary>
        [Fact]
        public void HasListeners_TrueWhenGenericEventHasListeners()
        {
            ComponentEvent evt = new ComponentEvent();
            GenericEvent genericEvent = new GenericEvent();
            genericEvent.Add(new NoOpGenericAction());
            evt.GenericEvent = genericEvent;

            Assert.True(evt.HasListeners);
        }

        /// <summary>
        ///     Tests that HasListeners is false when GenericEvent is null.
        /// </summary>
        [Fact]
        public void HasListeners_FalseWhenGenericEventIsNull()
        {
            ComponentEvent evt = new ComponentEvent();
            evt.GenericEvent = null;

            Assert.False(evt.HasListeners);
        }

        /// <summary>
        ///     Called on event
        /// </summary>
        /// <param name="gameObject">The gameObject</param>
        /// <param name="componentId">The componentId</param>
        private static void OnEvent(GameObject gameObject, ComponentId componentId)
        {
        }

        /// <summary>
        ///     A noop IGenericAction for testing
        /// </summary>
        private sealed class NoOpGenericAction : IGenericAction<GameObject>
        {
            /// <summary>
            ///     Invokes the specified gameObject
            /// </summary>
            /// <param name="gameObject">The gameObject</param>
            /// <param name="arg">The arg</param>
            public void Invoke<T>(GameObject gameObject, ref T arg)
            {
            }
        }
    }
}