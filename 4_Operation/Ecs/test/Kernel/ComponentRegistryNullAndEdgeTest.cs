// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentRegistryNullAndEdgeTest.cs
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
    ///     Edge-case tests for the Component registry targeting null type
    ///     and max component ID overflow branches.
    /// </summary>
    public class ComponentRegistryNullAndEdgeTest
    {
        /// <summary>
        /// The overflow type
        /// </summary>
        private struct OverflowTypeA { }

        /// <summary>
        /// The overflow type
        /// </summary>
        private struct OverflowTypeB { }

        /// <summary>
        ///     Tests that <see cref="Component.GetComponentFactoryFromType" /> throws
        ///     <see cref="InvalidOperationException" /> with "null or void" message
        ///     when called with a null type.
        ///     Covers null check in <c>GetComponentFactoryFromType</c> and
        ///     <c>Throw_ComponentTypeNotInit</c>.
        /// </summary>
        [Fact]
        public void GetComponentFactoryFromType_NullType_ThrowsNullMessage()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
                Component.GetComponentFactoryFromType(null));

            Assert.Contains("null", ex.Message);
        }

    }
}
