// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentEventExtendedTest.cs
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
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Events
{
    /// <summary>
    ///     Extended tests for <see cref="ComponentEvent" /> struct
    /// </summary>
    public class ComponentEventExtendedTest
    {
        /// <summary>
        ///     Tests that component event is value type
        /// </summary>
        [Fact]
        public void ComponentEvent_IsValueType()
        {
            Type type = typeof(ComponentEvent);

            Assert.True(type.IsValueType);
        }

        /// <summary>
        ///     Tests that component event has sequential struct layout
        /// </summary>
        [Fact]
        public void ComponentEvent_HasSequentialStructLayout()
        {
            StructLayoutAttribute layout = typeof(ComponentEvent).StructLayoutAttribute;

            Assert.Equal(LayoutKind.Sequential, layout.Value);
        }

        /// <summary>
        ///     Tests that has listeners is false when no listeners
        /// </summary>
        [Fact]
        public void HasListeners_FalseWhenNoListeners()
        {
            ComponentEvent evt = new ComponentEvent();

            Assert.False(evt.HasListeners);
        }

        /// <summary>
        ///     Tests that default component event has no listeners
        /// </summary>
        [Fact]
        public void DefaultComponentEvent_HasNoListeners()
        {
            ComponentEvent defaultEvt = default(ComponentEvent);

            Assert.False(defaultEvt.HasListeners);
        }

        /// <summary>
        ///     Tests that component event can be copied
        /// </summary>
        [Fact]
        public void ComponentEvent_CanBeCopied()
        {
            ComponentEvent original = new ComponentEvent();
            ComponentEvent copy = original;

            Assert.False(copy.HasListeners);
        }
    }
}
