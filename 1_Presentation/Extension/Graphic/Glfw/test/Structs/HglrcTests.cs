// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:HglrcTests.cs
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
    /// The hglrc tests class
    /// </summary>
    public class HglrcTests
    {
        /// <summary>
        /// Tests that none is default value
        /// </summary>
        [Fact]
        public void None_IsDefaultValue()
        {
            Hglrc none = Hglrc.None;
            Assert.Equal(default(Hglrc), none);
        }

        /// <summary>
        /// Tests that implicit conversion to int ptr works
        /// </summary>
        [Fact]
        public void ImplicitConversion_ToIntPtr_Works()
        {
            IntPtr ptr = Hglrc.None;
            Assert.Equal(IntPtr.Zero, ptr);
        }

        /// <summary>
        /// Tests that to string returns handle string
        /// </summary>
        [Fact]
        public void ToString_ReturnsHandleString()
        {
            Hglrc hglrc = Hglrc.None;
            string result = hglrc.ToString();
            Assert.Equal(IntPtr.Zero.ToString(), result);
        }

        /// <summary>
        /// Tests that equals with same hglrc returns true
        /// </summary>
        [Fact]
        public void Equals_WithSameHglrc_ReturnsTrue()
        {
            Hglrc hglrc1 = Hglrc.None;
            Hglrc hglrc2 = Hglrc.None;
            Assert.True(hglrc1.Equals(hglrc2));
        }

        /// <summary>
        /// Tests that equals with object returns correct result
        /// </summary>
        [Fact]
        public void Equals_WithObject_ReturnsCorrectResult()
        {
            Hglrc hglrc = Hglrc.None;
            object obj = Hglrc.None;
            Assert.True(hglrc.Equals(obj));
        }

        /// <summary>
        /// Tests that equals with non hglrc object returns false
        /// </summary>
        [Fact]
        public void Equals_WithNonHglrcObject_ReturnsFalse()
        {
            Hglrc hglrc = Hglrc.None;
            object obj = new object();
            Assert.False(hglrc.Equals(obj));
        }

        /// <summary>
        /// Tests that get hash code returns same for equal hglrc
        /// </summary>
        [Fact]
        public void GetHashCode_ReturnsSameForEqualHglrc()
        {
            Hglrc hglrc1 = Hglrc.None;
            Hglrc hglrc2 = Hglrc.None;
            Assert.Equal(hglrc1.GetHashCode(), hglrc2.GetHashCode());
        }

        /// <summary>
        /// Tests that equality operator with same hglrc returns true
        /// </summary>
        [Fact]
        public void EqualityOperator_WithSameHglrc_ReturnsTrue()
        {
            Hglrc hglrc1 = Hglrc.None;
            Hglrc hglrc2 = Hglrc.None;
            Assert.True(hglrc1 == hglrc2);
        }

        /// <summary>
        /// Tests that inequality operator with same hglrc returns false
        /// </summary>
        [Fact]
        public void InequalityOperator_WithSameHglrc_ReturnsFalse()
        {
            Hglrc hglrc1 = Hglrc.None;
            Hglrc hglrc2 = Hglrc.None;
            Assert.False(hglrc1 != hglrc2);
        }

        /// <summary>
        /// Tests that equals with i equatable interface works
        /// </summary>
        [Fact]
        public void Equals_WithIEquatableInterface_Works()
        {
            Hglrc hglrc1 = Hglrc.None;
            IEquatable<Hglrc> hglrc2 = Hglrc.None;
            Assert.True(hglrc1.Equals(hglrc2));
        }
    }
}
