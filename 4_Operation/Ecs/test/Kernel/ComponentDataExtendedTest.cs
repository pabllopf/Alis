// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentDataExtendedTest.cs
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
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     Extended tests for <see cref="ComponentData" /> record struct
    /// </summary>
    public class ComponentDataExtendedTest
    {
        /// <summary>
        ///     Tests that component data is value type
        /// </summary>
        [Fact]
        public void ComponentData_IsValueType()
        {
            Type type = typeof(ComponentData);

            Assert.True(type.IsValueType);
        }

        /// <summary>
        ///     Tests that component data has sequential struct layout
        /// </summary>
        [Fact]
        public void ComponentData_HasSequentialStructLayout()
        {
            StructLayoutAttribute layout = typeof(ComponentData).StructLayoutAttribute;

            Assert.Equal(LayoutKind.Sequential, layout.Value);
        }

        /// <summary>
        ///     Tests that component data stores type
        /// </summary>
        [Fact]
        public void ComponentData_StoresType()
        {
            ComponentData data = new ComponentData(typeof(Position), null, null, null);

            Assert.Equal(typeof(Position), data.Type);
        }

        /// <summary>
        ///     Tests that component data equality works
        /// </summary>
        [Fact]
        public void ComponentData_EqualityWorks()
        {
            ComponentData data1 = new ComponentData(typeof(Position), null, null, null);
            ComponentData data2 = new ComponentData(typeof(Position), null, null, null);

            Assert.Equal(data1, data2);
        }

        /// <summary>
        ///     Tests that component data with different types are not equal
        /// </summary>
        [Fact]
        public void ComponentData_DifferentTypes_AreNotEqual()
        {
            ComponentData data1 = new ComponentData(typeof(Position), null, null, null);
            ComponentData data2 = new ComponentData(typeof(Velocity), null, null, null);

            Assert.NotEqual(data1, data2);
        }
    }
}
