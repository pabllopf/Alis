// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CreateCommandExtendedTest.cs
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
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     Extended tests for <see cref="CreateCommand" /> record struct
    /// </summary>
    public class CreateCommandExtendedTest
    {
        /// <summary>
        ///     Tests that create command is value type
        /// </summary>
        [Fact]
        public void CreateCommand_IsValueType()
        {
            Type type = typeof(CreateCommand);

            Assert.True(type.IsValueType);
        }

        /// <summary>
        ///     Tests that create command has sequential struct layout
        /// </summary>
        [Fact]
        public void CreateCommand_HasSequentialStructLayout()
        {
            StructLayoutAttribute layout = typeof(CreateCommand).StructLayoutAttribute;

            Assert.Equal(LayoutKind.Sequential, layout.Value);
        }

        /// <summary>
        ///     Tests that create command stores entity
        /// </summary>
        [Fact]
        public void CreateCommand_StoresEntity()
        {
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);

            CreateCommand cmd = new CreateCommand(entity, 0, 1);

            Assert.Equal(entity, cmd.Entity);
        }

        /// <summary>
        ///     Tests that create command stores buffer index
        /// </summary>
        [Fact]
        public void CreateCommand_StoresBufferIndex()
        {
            CreateCommand cmd = new CreateCommand(default, 42, 1);

            Assert.Equal(42, cmd.BufferIndex);
        }

        /// <summary>
        ///     Tests that create command stores buffer length
        /// </summary>
        [Fact]
        public void CreateCommand_StoresBufferLength()
        {
            CreateCommand cmd = new CreateCommand(default, 0, 10);

            Assert.Equal(10, cmd.BufferLength);
        }

        /// <summary>
        ///     Tests that create command equality works
        /// </summary>
        [Fact]
        public void CreateCommand_EqualityWorks()
        {
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);
            CreateCommand cmd1 = new CreateCommand(entity, 0, 1);
            CreateCommand cmd2 = new CreateCommand(entity, 0, 1);

            Assert.Equal(cmd1, cmd2);
        }

        /// <summary>
        ///     Tests that create command with different values are not equal
        /// </summary>
        [Fact]
        public void CreateCommand_DifferentValues_AreNotEqual()
        {
            CreateCommand cmd1 = new CreateCommand(default, 0, 1);
            CreateCommand cmd2 = new CreateCommand(default, 0, 2);

            Assert.NotEqual(cmd1, cmd2);
        }
    }
}
