// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentHandleCreateCoverageTests.cs
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

using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Events;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     Coverage tests for <see cref="ComponentHandle" /> methods not covered by other test files.
    ///     Tests <see cref="ComponentHandle.Create{T}" />, <see cref="ComponentHandle.CreateFromBoxed" />,
    ///     <see cref="ComponentHandle.ParentTable" />, and <see cref="ComponentHandle.InvokeComponentEventAndConsume" />.
    /// </summary>
    public class ComponentHandleCreateCoverageTests
    {
        [Fact]
        public void Create_WithValueType_StoresComponent()
        {
            ComponentHandle handle = ComponentHandle.Create<long>(42L);

            long result = handle.Retrieve<long>();

            Assert.Equal(42L, result);
            Assert.Equal(typeof(long), handle.Type);
        }

        [Fact]
        public void Create_WithReferenceType_StoresComponent()
        {
            ComponentHandle handle = ComponentHandle.Create<string>("hello");

            string result = handle.Retrieve<string>();

            Assert.Equal("hello", result);
        }

        [Fact]
        public void CreateFromBoxed_WithComponentId_StoresComponent()
        {
            ComponentHandle handle = ComponentHandle.CreateFromBoxed(Component<long>.Id, 42L);

            object result = handle.RetrieveBoxed();

            Assert.Equal(42L, result);
            Assert.Equal(typeof(long), handle.Type);
        }

        [Fact]
        public void CreateFromBoxed_WithoutComponentId_StoresComponent()
        {
            ComponentHandle handle = ComponentHandle.CreateFromBoxed(42L);

            object result = handle.RetrieveBoxed();

            Assert.Equal(42L, result);
            Assert.Equal(typeof(long), handle.Type);
        }

        [Fact]
        public void ParentTable_AfterCreate_ReturnsStorage()
        {
            ComponentHandle handle = ComponentHandle.Create<long>(42L);

            IdTable parentTable = handle.ParentTable;

            Assert.NotNull(parentTable);
        }

        [Fact]
        public void Dispose_AfterCreate_FreesHandle()
        {
            ComponentHandle handle = ComponentHandle.Create<long>(42L);

            handle.Dispose();
        }

        [Fact]
        public void Create_AndRetrieve_WithDifferentTypes()
        {
            ComponentHandle longHandle = ComponentHandle.Create<long>(99L);
            ComponentHandle stringHandle = ComponentHandle.Create<string>("world");

            Assert.Equal(99L, longHandle.Retrieve<long>());
            Assert.Equal("world", stringHandle.Retrieve<string>());
        }

        [Fact]
        public void InvokeComponentEventAndConsume_DispatchesEvent()
        {
            ComponentHandle handle = ComponentHandle.Create<long>(42L);
            GameObject gameObject = new GameObject();
            GenericEvent genericEvent = new GenericEvent();

            handle.InvokeComponentEventAndConsume(gameObject, genericEvent);
        }
    }
}
