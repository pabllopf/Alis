// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:OSMesaContextTests.cs
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
using Alis.Extension.Graphic.Glfw.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test.Structs
{
    /// <summary>
    /// The os mesa context tests class
    /// </summary>
    public class OSMesaContextTests
    {
        /// <summary>
        /// Tests that none is default value
        /// </summary>
        [Fact]
        public void None_IsDefaultValue()
        {
            OSMesaContext none = OSMesaContext.None;
            Assert.Equal(default(OSMesaContext), none);
        }

        /// <summary>
        /// Tests that implicit conversion to int ptr works
        /// </summary>
        [Fact]
        public void ImplicitConversion_ToIntPtr_Works()
        {
            IntPtr ptr = OSMesaContext.None;
            Assert.Equal(IntPtr.Zero, ptr);
        }

        /// <summary>
        /// Tests that to string returns handle string
        /// </summary>
        [Fact]
        public void ToString_ReturnsHandleString()
        {
            OSMesaContext context = OSMesaContext.None;
            string result = context.ToString();
            Assert.Equal(IntPtr.Zero.ToString(), result);
        }

        /// <summary>
        /// Tests that equals with same os mesa context returns true
        /// </summary>
        [Fact]
        public void Equals_WithSameOSMesaContext_ReturnsTrue()
        {
            OSMesaContext context1 = OSMesaContext.None;
            OSMesaContext context2 = OSMesaContext.None;
            Assert.True(context1.Equals(context2));
        }

        /// <summary>
        /// Tests that equals with object returns correct result
        /// </summary>
        [Fact]
        public void Equals_WithObject_ReturnsCorrectResult()
        {
            OSMesaContext context = OSMesaContext.None;
            object obj = OSMesaContext.None;
            Assert.True(context.Equals(obj));
        }

        /// <summary>
        /// Tests that equals with non os mesa context object returns false
        /// </summary>
        [Fact]
        public void Equals_WithNonOSMesaContextObject_ReturnsFalse()
        {
            OSMesaContext context = OSMesaContext.None;
            object obj = new object();
            Assert.False(context.Equals(obj));
        }

        /// <summary>
        /// Tests that get hash code returns same for equal contexts
        /// </summary>
        [Fact]
        public void GetHashCode_ReturnsSameForEqualContexts()
        {
            OSMesaContext context1 = OSMesaContext.None;
            OSMesaContext context2 = OSMesaContext.None;
            Assert.Equal(context1.GetHashCode(), context2.GetHashCode());
        }

        /// <summary>
        /// Tests that equality operator with same contexts returns true
        /// </summary>
        [Fact]
        public void EqualityOperator_WithSameContexts_ReturnsTrue()
        {
            OSMesaContext context1 = OSMesaContext.None;
            OSMesaContext context2 = OSMesaContext.None;
            Assert.True(context1 == context2);
        }

        /// <summary>
        /// Tests that inequality operator with same contexts returns false
        /// </summary>
        [Fact]
        public void InequalityOperator_WithSameContexts_ReturnsFalse()
        {
            OSMesaContext context1 = OSMesaContext.None;
            OSMesaContext context2 = OSMesaContext.None;
            Assert.False(context1 != context2);
        }

        /// <summary>
        /// Tests that equals with i equatable interface works
        /// </summary>
        [Fact]
        public void Equals_WithIEquatableInterface_Works()
        {
            OSMesaContext context1 = OSMesaContext.None;
            IEquatable<OSMesaContext> context2 = OSMesaContext.None;
            Assert.True(context1.Equals(context2));
        }
    }
}
