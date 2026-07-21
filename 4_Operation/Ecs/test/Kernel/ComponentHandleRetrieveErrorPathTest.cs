// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentHandleRetrieveErrorPathTest.cs
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
using Alis.Core.Ecs.Kernel;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     Tests the <see cref="ComponentHandle.Retrieve{T}" /> error path when the handle's
    ///     <see cref="ComponentId" /> does not match the requested type.
    /// </summary>
    public class ComponentHandleRetrieveErrorPathTest
    {

        /// <summary>
        /// Tests that retrieve mismatched type different index throws invalid operation exception
        /// </summary>
        [Fact]
        public void Retrieve_MismatchedTypeDifferentIndex_ThrowsInvalidOperationException()
        {
            ComponentHandle handle = new ComponentHandle(42, new ComponentId(ushort.MaxValue));
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => handle.Retrieve<int>());
            Assert.Equal("Wrong component handle type!", exception.Message);
        }

        /// <summary>
        /// Tests that retrieve mismatched type with string throws invalid operation exception
        /// </summary>
        [Fact]
        public void Retrieve_MismatchedTypeWithString_ThrowsInvalidOperationException()
        {
            ComponentHandle handle = new ComponentHandle(0, new ComponentId(0));
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => handle.Retrieve<string>());
            Assert.Equal("Wrong component handle type!", exception.Message);
        }
    }
}
