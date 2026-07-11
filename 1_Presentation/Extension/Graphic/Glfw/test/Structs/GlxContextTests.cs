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
    public class GlxContextTests
    {
        [Fact]
        public void None_IsDefaultValue()
        {
            GlxContext none = GlxContext.None;
            Assert.Equal(default(GlxContext), none);
        }

        [Fact]
        public void ImplicitConversion_ToIntPtr_Works()
        {
            IntPtr ptr = GlxContext.None;
            Assert.Equal(IntPtr.Zero, ptr);
        }

        [Fact]
        public void ToString_ReturnsHandleString()
        {
            GlxContext context = GlxContext.None;
            string result = context.ToString();
            Assert.Equal(IntPtr.Zero.ToString(), result);
        }

        [Fact]
        public void Equals_WithSameGlxContext_ReturnsTrue()
        {
            GlxContext context1 = GlxContext.None;
            GlxContext context2 = GlxContext.None;
            Assert.True(context1.Equals(context2));
        }

        [Fact]
        public void Equals_WithObject_ReturnsCorrectResult()
        {
            GlxContext context = GlxContext.None;
            object obj = GlxContext.None;
            Assert.True(context.Equals(obj));
        }

        [Fact]
        public void Equals_WithNonGlxContextObject_ReturnsFalse()
        {
            GlxContext context = GlxContext.None;
            object obj = new object();
            Assert.False(context.Equals(obj));
        }

        [Fact]
        public void GetHashCode_ReturnsSameForEqualContexts()
        {
            GlxContext context1 = GlxContext.None;
            GlxContext context2 = GlxContext.None;
            Assert.Equal(context1.GetHashCode(), context2.GetHashCode());
        }

        [Fact]
        public void EqualityOperator_WithSameContexts_ReturnsTrue()
        {
            GlxContext context1 = GlxContext.None;
            GlxContext context2 = GlxContext.None;
            Assert.True(context1 == context2);
        }

        [Fact]
        public void InequalityOperator_WithSameContexts_ReturnsFalse()
        {
            GlxContext context1 = GlxContext.None;
            GlxContext context2 = GlxContext.None;
            Assert.False(context1 != context2);
        }

        [Fact]
        public void Equals_WithIEquatableInterface_Works()
        {
            GlxContext context1 = GlxContext.None;
            IEquatable<GlxContext> context2 = GlxContext.None;
            Assert.True(context1.Equals(context2));
        }
    }
}
