// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentHandleExceptionTest.cs
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
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     Tests for exception and error paths in <see cref="ComponentHandle" />.
    /// </summary>
    public class ComponentHandleExceptionTest
    {
        /// <summary>
        ///     Tests that <see cref="ComponentHandle.Retrieve{T}" /> throws
        ///     <see cref="InvalidOperationException" /> when the requested type does not match.
        /// </summary>
        [Fact]
        public void Retrieve_WithMismatchedType_ThrowsInvalidOperationException()
        {
            Position position = new Position { X = 10, Y = 20 };
            ComponentHandle handle = ComponentHandle.Create(position);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => handle.Retrieve<Velocity>());

            Assert.Contains("Wrong component handle type", exception.Message);
        }

        /// <summary>
        ///     Tests that <see cref="ComponentHandle.Equals(object)" /> returns
        ///     <see langword="false" /> when comparing with an incompatible type.
        /// </summary>
        [Fact]
        public void Equals_WithIncompatibleType_ReturnsFalse()
        {
            Position position = new Position { X = 10, Y = 20 };
            ComponentHandle handle = ComponentHandle.Create(position);

            bool result = handle.Equals("not a component handle");

            Assert.False(result);
        }
    }
}
