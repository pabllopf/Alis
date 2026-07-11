// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EglDisplayTests.cs
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
    public class EglDisplayTests
    {
        [Fact]
        public void None_IsDefaultValue()
        {
            EglDisplay none = EglDisplay.None;
            Assert.Equal(default(EglDisplay), none);
        }

        [Fact]
        public void ImplicitConversion_ToIntPtr_Works()
        {
            IntPtr ptr = EglDisplay.None;
            Assert.Equal(IntPtr.Zero, ptr);
        }

        [Fact]
        public void ToString_ReturnsHandleString()
        {
            EglDisplay display = EglDisplay.None;
            string result = display.ToString();
            Assert.Equal(IntPtr.Zero.ToString(), result);
        }

        [Fact]
        public void Equals_WithSameEglDisplay_ReturnsTrue()
        {
            EglDisplay display1 = EglDisplay.None;
            EglDisplay display2 = EglDisplay.None;
            Assert.True(display1.Equals(display2));
        }

        [Fact]
        public void Equals_WithObject_ReturnsCorrectResult()
        {
            EglDisplay display = EglDisplay.None;
            object obj = EglDisplay.None;
            Assert.True(display.Equals(obj));
        }

        [Fact]
        public void Equals_WithNonEglDisplayObject_ReturnsFalse()
        {
            EglDisplay display = EglDisplay.None;
            object obj = new object();
            Assert.False(display.Equals(obj));
        }

        [Fact]
        public void GetHashCode_ReturnsSameForEqualDisplays()
        {
            EglDisplay display1 = EglDisplay.None;
            EglDisplay display2 = EglDisplay.None;
            Assert.Equal(display1.GetHashCode(), display2.GetHashCode());
        }

        [Fact]
        public void EqualityOperator_WithSameDisplays_ReturnsTrue()
        {
            EglDisplay display1 = EglDisplay.None;
            EglDisplay display2 = EglDisplay.None;
            Assert.True(display1 == display2);
        }

        [Fact]
        public void InequalityOperator_WithSameDisplays_ReturnsFalse()
        {
            EglDisplay display1 = EglDisplay.None;
            EglDisplay display2 = EglDisplay.None;
            Assert.False(display1 != display2);
        }

        [Fact]
        public void Equals_WithIEquatableInterface_Works()
        {
            EglDisplay display1 = EglDisplay.None;
            IEquatable<EglDisplay> display2 = EglDisplay.None;
            Assert.True(display1.Equals(display2));
        }
    }
}
