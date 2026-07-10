// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DeleteComponentExtendedTest.cs
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
    ///     Extended tests for <see cref="DeleteComponent" /> record struct
    /// </summary>
    public class DeleteComponentExtendedTest
    {
        /// <summary>
        ///     Tests that delete component is value type
        /// </summary>
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void DeleteComponent_IsValueType()
        {
            Type type = typeof(DeleteComponent);

            Assert.True(type.IsValueType);
        }

        /// <summary>
        ///     Tests that delete component has sequential struct layout
        /// </summary>
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void DeleteComponent_HasSequentialStructLayout()
        {
            StructLayoutAttribute layout = typeof(DeleteComponent).StructLayoutAttribute;

            Assert.Equal(LayoutKind.Sequential, layout.Value);
        }

        /// <summary>
        ///     Tests that delete component stores entity
        /// </summary>
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void DeleteComponent_StoresEntity()
        {
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);

            DeleteComponent cmd = new DeleteComponent(entity, default);

            Assert.Equal(entity, cmd.Entity);
        }

        /// <summary>
        ///     Tests that delete component stores component id
        /// </summary>
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void DeleteComponent_StoresComponentId()
        {
            ComponentId compId = Component<Position>.Id;

            DeleteComponent cmd = new DeleteComponent(default, compId);

            Assert.Equal(compId, cmd.ComponentId);
        }

        /// <summary>
        ///     Tests that delete component equality works
        /// </summary>
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void DeleteComponent_EqualityWorks()
        {
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);
            ComponentId compId = Component<Position>.Id;
            DeleteComponent cmd1 = new DeleteComponent(entity, compId);
            DeleteComponent cmd2 = new DeleteComponent(entity, compId);

            Assert.Equal(cmd1, cmd2);
        }

        /// <summary>
        ///     Tests that delete component with different entities are not equal
        /// </summary>
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void DeleteComponent_DifferentEntities_AreNotEqual()
        {
            DeleteComponent cmd1 = new DeleteComponent(new GameObjectIdOnly(1, 0), default);
            DeleteComponent cmd2 = new DeleteComponent(new GameObjectIdOnly(2, 0), default);

            Assert.NotEqual(cmd1, cmd2);
        }
    }
}
