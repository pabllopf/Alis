// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EglSurfaceTests.cs
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
    /// The egl surface tests class
    /// </summary>
    public class EglSurfaceTests
    {
        /// <summary>
        /// Tests that none is default value
        /// </summary>
        [Fact]
        public void None_IsDefaultValue()
        {
            EglSurface none = EglSurface.None;
            Assert.Equal(default(EglSurface), none);
        }

        /// <summary>
        /// Tests that implicit conversion to int ptr works
        /// </summary>
        [Fact]
        public void ImplicitConversion_ToIntPtr_Works()
        {
            IntPtr ptr = EglSurface.None;
            Assert.Equal(IntPtr.Zero, ptr);
        }

        /// <summary>
        /// Tests that to string returns handle string
        /// </summary>
        [Fact]
        public void ToString_ReturnsHandleString()
        {
            EglSurface surface = EglSurface.None;
            string result = surface.ToString();
            Assert.Equal(IntPtr.Zero.ToString(), result);
        }

        /// <summary>
        /// Tests that equals with same egl surface returns true
        /// </summary>
        [Fact]
        public void Equals_WithSameEglSurface_ReturnsTrue()
        {
            EglSurface surface1 = EglSurface.None;
            EglSurface surface2 = EglSurface.None;
            Assert.True(surface1.Equals(surface2));
        }

        /// <summary>
        /// Tests that equals with object returns correct result
        /// </summary>
        [Fact]
        public void Equals_WithObject_ReturnsCorrectResult()
        {
            EglSurface surface = EglSurface.None;
            object obj = EglSurface.None;
            Assert.True(surface.Equals(obj));
        }

        /// <summary>
        /// Tests that equals with non egl surface object returns false
        /// </summary>
        [Fact]
        public void Equals_WithNonEglSurfaceObject_ReturnsFalse()
        {
            EglSurface surface = EglSurface.None;
            object obj = new object();
            Assert.False(surface.Equals(obj));
        }

        /// <summary>
        /// Tests that get hash code returns same for equal surfaces
        /// </summary>
        [Fact]
        public void GetHashCode_ReturnsSameForEqualSurfaces()
        {
            EglSurface surface1 = EglSurface.None;
            EglSurface surface2 = EglSurface.None;
            Assert.Equal(surface1.GetHashCode(), surface2.GetHashCode());
        }

        /// <summary>
        /// Tests that equality operator with same surfaces returns true
        /// </summary>
        [Fact]
        public void EqualityOperator_WithSameSurfaces_ReturnsTrue()
        {
            EglSurface surface1 = EglSurface.None;
            EglSurface surface2 = EglSurface.None;
            Assert.True(surface1 == surface2);
        }

        /// <summary>
        /// Tests that inequality operator with same surfaces returns false
        /// </summary>
        [Fact]
        public void InequalityOperator_WithSameSurfaces_ReturnsFalse()
        {
            EglSurface surface1 = EglSurface.None;
            EglSurface surface2 = EglSurface.None;
            Assert.False(surface1 != surface2);
        }

        /// <summary>
        /// Tests that equals with i equatable interface works
        /// </summary>
        [Fact]
        public void Equals_WithIEquatableInterface_Works()
        {
            EglSurface surface1 = EglSurface.None;
            IEquatable<EglSurface> surface2 = EglSurface.None;
            Assert.True(surface1.Equals(surface2));
        }
    }
}
