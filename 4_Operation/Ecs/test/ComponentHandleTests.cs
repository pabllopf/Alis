// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentHandleTests.cs
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
using System.Linq;
using Alis.Core.Ecs.Kernel;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The component handle tests class
    /// </summary>
    public class ComponentHandleTests
    {
        /// <summary>
        ///     Tests that component handle stores component
        /// </summary>
        [Fact]
        public void ComponentHandle_StoresComponent()
        {
            using (ComponentHandle handle = ComponentHandle.Create(69))
            {
                Assert.Equal(69, handle.Retrieve<int>());
            }
        }

        /// <summary>
        ///     Tests that retrieve throws wrong type
        /// </summary>
        [Fact]
        public void Retrieve_ThrowsWrongType()
        {
            using (ComponentHandle handle = ComponentHandle.Create(69))
            {
                Assert.Throws<InvalidOperationException>(() => handle.Retrieve<double>());
            }
        }

        /// <summary>
        ///     Tests that retrieve boxed correct value
        /// </summary>
        [Fact]
        public void RetrieveBoxed_CorrectValue()
        {
            using (ComponentHandle handle = ComponentHandle.Create(69))
            {
                object box = handle.RetrieveBoxed();
                Assert.Equal(typeof(int), box.GetType());
                Assert.Equal(69, (int) box);
            }
        }

        /// <summary>
        ///     Tests that type correct type
        /// </summary>
        [Fact]
        public void Type_CorrectType()
        {
            ComponentHandle[] handle =
            {
                ComponentHandle.Create(0),
                ComponentHandle.Create(0.0),
                ComponentHandle.Create(0f)
            };

            Assert.Equal(new[] {typeof(int), typeof(double), typeof(float)}, handle.Select(c => c.Type));
            Assert.Equal(new[] {Component<int>.Id, Component<double>.Id, Component<float>.Id}, handle.Select(c => c.ComponentId));
        }
    }
}