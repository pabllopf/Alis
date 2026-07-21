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
using System.Reflection;
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
        private struct OverflowTypeA { }

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

        /// <summary>
        ///     Tests that <see cref="Component.GetComponentId" /> throws
        ///     <see cref="InvalidOperationException" /> when the max component
        ///     count is exceeded. Uses reflection to set the internal counter to
        ///     <c>ushort.MaxValue - 1</c> so the next allocation attempt triggers
        ///     the overflow guard. Restores the original counter after the test.
        /// </summary>
        [Fact]
        public void GetComponentId_ExceedsMaxComponentCount_ThrowsOverflow()
        {
            Component.ResetForTests();

            FieldInfo field = typeof(Component).GetField("_nextComponentId",
                BindingFlags.Static | BindingFlags.NonPublic);

            Assert.NotNull(field);

            int saved = (int)field.GetValue(null)!;

            try
            {
                field.SetValue(null, (int)(ushort.MaxValue - 1));

                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
                    Component.GetComponentId(typeof(OverflowTypeA)));

                Assert.Contains("65535", ex.Message);
            }
            finally
            {
                field.SetValue(null, saved);
            }
        }

        /// <summary>
        ///     Tests that <see cref="Component.GetExistingOrSetupNewComponent{T}" /> throws
        ///     <see cref="InvalidOperationException" /> when the max component
        ///     count is exceeded. Uses reflection to set the internal counter to
        ///     <c>ushort.MaxValue - 1</c> so the next allocation attempt triggers
        ///     the overflow guard. Restores the original counter after the test.
        /// </summary>
        [Fact]
        public void GetExistingOrSetupNewComponent_ExceedsMaxComponentCount_ThrowsOverflow()
        {
            Component.ResetForTests();

            FieldInfo field = typeof(Component).GetField("_nextComponentId",
                BindingFlags.Static | BindingFlags.NonPublic);

            Assert.NotNull(field);

            int saved = (int)field.GetValue(null)!;

            try
            {
                field.SetValue(null, (int)(ushort.MaxValue - 1));

                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
                    Component.GetExistingOrSetupNewComponent<OverflowTypeB>());

                Assert.Contains("65535", ex.Message);
            }
            finally
            {
                field.SetValue(null, saved);
            }
        }
    }
}
