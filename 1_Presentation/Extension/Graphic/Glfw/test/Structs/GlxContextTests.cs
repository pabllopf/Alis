// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlxContextTests.cs
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
    /// The glx context tests class
    /// </summary>
    public class GlxContextTests
    {
        /// <summary>
        /// Tests that none is default value
        /// </summary>
        [Fact]
        public void None_IsDefaultValue()
        {
            GlxContext none = GlxContext.None;
            Assert.Equal(default(GlxContext), none);
        }

        /// <summary>
        /// Tests that implicit conversion to int ptr works
        /// </summary>
        [Fact]
        public void ImplicitConversion_ToIntPtr_Works()
        {
            IntPtr ptr = GlxContext.None;
            Assert.Equal(IntPtr.Zero, ptr);
        }

        /// <summary>
        /// Tests that to string returns handle string
        /// </summary>
        [Fact]
        public void ToString_ReturnsHandleString()
        {
            GlxContext context = GlxContext.None;
            string result = context.ToString();
            Assert.Equal(IntPtr.Zero.ToString(), result);
        }

        /// <summary>
        /// Tests that equals with same glx context returns true
        /// </summary>
        [Fact]
        public void Equals_WithSameGlxContext_ReturnsTrue()
        {
            GlxContext context1 = GlxContext.None;
            GlxContext context2 = GlxContext.None;
            Assert.True(context1.Equals(context2));
        }

        /// <summary>
        /// Tests that equals with object returns correct result
        /// </summary>
        [Fact]
        public void Equals_WithObject_ReturnsCorrectResult()
        {
            GlxContext context = GlxContext.None;
            object obj = GlxContext.None;
            Assert.True(context.Equals(obj));
        }

        /// <summary>
        /// Tests that equals with non glx context object returns false
        /// </summary>
        [Fact]
        public void Equals_WithNonGlxContextObject_ReturnsFalse()
        {
            GlxContext context = GlxContext.None;
            object obj = new object();
            Assert.False(context.Equals(obj));
        }

        /// <summary>
        /// Tests that get hash code returns same for equal contexts
        /// </summary>
        [Fact]
        public void GetHashCode_ReturnsSameForEqualContexts()
        {
            GlxContext context1 = GlxContext.None;
            GlxContext context2 = GlxContext.None;
            Assert.Equal(context1.GetHashCode(), context2.GetHashCode());
        }

        /// <summary>
        /// Tests that equality operator with same contexts returns true
        /// </summary>
        [Fact]
        public void EqualityOperator_WithSameContexts_ReturnsTrue()
        {
            GlxContext context1 = GlxContext.None;
            GlxContext context2 = GlxContext.None;
            Assert.True(context1 == context2);
        }

        /// <summary>
        /// Tests that inequality operator with same contexts returns false
        /// </summary>
        [Fact]
        public void InequalityOperator_WithSameContexts_ReturnsFalse()
        {
            GlxContext context1 = GlxContext.None;
            GlxContext context2 = GlxContext.None;
            Assert.False(context1 != context2);
        }

        /// <summary>
        /// Tests that equals with i equatable interface works
        /// </summary>
        [Fact]
        public void Equals_WithIEquatableInterface_Works()
        {
            GlxContext context1 = GlxContext.None;
            IEquatable<GlxContext> context2 = GlxContext.None;
            Assert.True(context1.Equals(context2));
        }
    }
}
