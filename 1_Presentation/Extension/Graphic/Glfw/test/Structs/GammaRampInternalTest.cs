// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GammaRampInternalTest.cs
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

using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Glfw.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test.Structs
{
    /// <summary>
    ///     Contract tests for the <see cref="GammaRampInternal" /> struct.
    /// </summary>
    public class GammaRampInternalTest
    {
        /// <summary>
        ///     Verifies that GammaRampInternal is a value type.
        /// </summary>
        [Fact]
        public void GammaRampInternal_ShouldBeValueType()
        {
            Assert.True(typeof(GammaRampInternal).IsValueType);
        }

        /// <summary>
        ///     Verifies that GammaRampInternal has sequential layout.
        /// </summary>
        [Fact]
        public void GammaRampInternal_ShouldHaveSequentialLayout()
        {
            StructLayoutAttribute attribute = typeof(GammaRampInternal).StructLayoutAttribute;

            Assert.NotNull(attribute);
            Assert.Equal(LayoutKind.Sequential, attribute.Value);
        }

        /// <summary>
        ///     Verifies that Red field is an IntPtr.
        /// </summary>
        [Fact]
        public void Red_Field_ShouldBeIntPtr()
        {
            System.Reflection.FieldInfo field = typeof(GammaRampInternal).GetField("Red", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            Assert.NotNull(field);
            Assert.Equal(typeof(System.IntPtr), field.FieldType);
        }

        /// <summary>
        ///     Verifies that Green field is an IntPtr.
        /// </summary>
        [Fact]
        public void Green_Field_ShouldBeIntPtr()
        {
            System.Reflection.FieldInfo field = typeof(GammaRampInternal).GetField("Green", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            Assert.NotNull(field);
            Assert.Equal(typeof(System.IntPtr), field.FieldType);
        }

        /// <summary>
        ///     Verifies that Blue field is an IntPtr.
        /// </summary>
        [Fact]
        public void Blue_Field_ShouldBeIntPtr()
        {
            System.Reflection.FieldInfo field = typeof(GammaRampInternal).GetField("Blue", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            Assert.NotNull(field);
            Assert.Equal(typeof(System.IntPtr), field.FieldType);
        }

        /// <summary>
        ///     Verifies that Size field is an integer.
        /// </summary>
        [Fact]
        public void Size_Field_ShouldBeInt()
        {
            System.Reflection.FieldInfo field = typeof(GammaRampInternal).GetField("Size", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            Assert.NotNull(field);
            Assert.Equal(typeof(int), field.FieldType);
        }

        /// <summary>
        ///     Verifies the default values of GammaRampInternal.
        /// </summary>
        [Fact]
        public void DefaultInstance_ShouldHaveZeroValues()
        {
            GammaRampInternal ramp = default;

            Assert.Equal(System.IntPtr.Zero, ramp.Red);
            Assert.Equal(System.IntPtr.Zero, ramp.Green);
            Assert.Equal(System.IntPtr.Zero, ramp.Blue);
            Assert.Equal(0, ramp.Size);
        }
    }
}
