// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AddComponentRecordTest.cs
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
    ///     Extended tests for <see cref="AddComponent" /> record struct
    /// </summary>
    public class AddComponentRecordTest
    {
        /// <summary>
        ///     Tests that add component is value type
        /// </summary>
        [Fact]
        public void AddComponent_IsValueType()
        {
            Type type = typeof(AddComponent);

            Assert.True(type.IsValueType);
        }

        /// <summary>
        ///     Tests that add component has sequential struct layout
        /// </summary>
        [Fact]
        public void AddComponent_HasSequentialStructLayout()
        {
            StructLayoutAttribute layout = typeof(AddComponent).StructLayoutAttribute;

            Assert.Equal(LayoutKind.Sequential, layout.Value);
        }

        /// <summary>
        ///     Tests that add component stores entity
        /// </summary>
        [Fact]
        public void AddComponent_StoresEntity()
        {
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);

            AddComponent cmd = new AddComponent(entity, default);

            Assert.Equal(entity, cmd.Entity);
        }

        /// <summary>
        ///     Tests that add component stores component handle
        /// </summary>
        [Fact]
        public void AddComponent_StoresComponentHandle()
        {
            ComponentHandle handle = ComponentHandle.Create(new Position {X = 1, Y = 2});

            AddComponent cmd = new AddComponent(default, handle);

            Assert.Equal(handle, cmd.ComponentHandle);
        }

        /// <summary>
        ///     Tests that add component equality works
        /// </summary>
        [Fact]
        public void AddComponent_EqualityWorks()
        {
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);
            ComponentHandle handle = ComponentHandle.Create(new Position {X = 1, Y = 2});
            AddComponent cmd1 = new AddComponent(entity, handle);
            AddComponent cmd2 = new AddComponent(entity, handle);

            Assert.Equal(cmd1, cmd2);
        }
    }
}
