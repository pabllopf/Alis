// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EglContextTests.cs
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
    public class EglContextTests
    {
        [Fact]
        public void None_IsDefaultValue()
        {
            EglContext none = EglContext.None;
            Assert.Equal(default(EglContext), none);
        }

        [Fact]
        public void ImplicitConversion_ToIntPtr_Works()
        {
            IntPtr ptr = EglContext.None;
            Assert.Equal(IntPtr.Zero, ptr);
        }

        [Fact]
        public void ToString_ReturnsHandleString()
        {
            EglContext context = EglContext.None;
            string result = context.ToString();
            Assert.Equal(IntPtr.Zero.ToString(), result);
        }

        [Fact]
        public void Equals_WithSameEglContext_ReturnsTrue()
        {
            EglContext context1 = EglContext.None;
            EglContext context2 = EglContext.None;
            Assert.True(context1.Equals(context2));
        }

        [Fact]
        public void Equals_WithObject_ReturnsCorrectResult()
        {
            EglContext context = EglContext.None;
            object obj = EglContext.None;
            Assert.True(context.Equals(obj));
        }

        [Fact]
        public void Equals_WithNonEglContextObject_ReturnsFalse()
        {
            EglContext context = EglContext.None;
            object obj = new object();
            Assert.False(context.Equals(obj));
        }

        [Fact]
        public void GetHashCode_ReturnsSameForEqualContexts()
        {
            EglContext context1 = EglContext.None;
            EglContext context2 = EglContext.None;
            Assert.Equal(context1.GetHashCode(), context2.GetHashCode());
        }

        [Fact]
        public void EqualityOperator_WithSameContexts_ReturnsTrue()
        {
            EglContext context1 = EglContext.None;
            EglContext context2 = EglContext.None;
            Assert.True(context1 == context2);
        }

        [Fact]
        public void InequalityOperator_WithSameContexts_ReturnsFalse()
        {
            EglContext context1 = EglContext.None;
            EglContext context2 = EglContext.None;
            Assert.False(context1 != context2);
        }

        [Fact]
        public void Equals_WithIEquatableInterface_Works()
        {
            EglContext context1 = EglContext.None;
            IEquatable<EglContext> context2 = EglContext.None;
            Assert.True(context1.Equals(context2));
        }
    }
}
