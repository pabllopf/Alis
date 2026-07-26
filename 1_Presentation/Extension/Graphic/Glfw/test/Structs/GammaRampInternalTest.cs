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

using System;
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

        /// <summary>
        ///     Tests that explicit operator with default instance returns GammaRamp with empty arrays.
        /// </summary>
        [Fact]
        public void ExplicitOperator_WithDefault_ReturnsEmptyArrays()
        {
            GammaRampInternal internalRamp = default;

            GammaRamp ramp = (GammaRamp)internalRamp;

            Assert.NotNull(ramp.Red);
            Assert.NotNull(ramp.Green);
            Assert.NotNull(ramp.Blue);
            Assert.Equal(0u, ramp.Size);
        }

        /// <summary>
        ///     Tests that explicit operator with allocated data converts correctly.
        /// </summary>
        [Fact]
        public void ExplicitOperator_WithAllocatedData_ConvertsCorrectly()
        {
            const int size = 3;
            ushort[] expectedRed = { 100, 200, 300 };
            ushort[] expectedGreen = { 400, 500, 600 };
            ushort[] expectedBlue = { 700, 800, 900 };

            int bytes = size * sizeof(ushort);
            IntPtr redPtr = Marshal.AllocHGlobal(bytes);
            IntPtr greenPtr = Marshal.AllocHGlobal(bytes);
            IntPtr bluePtr = Marshal.AllocHGlobal(bytes);

            try
            {
                for (int i = 0; i < size; i++)
                {
                    Marshal.WriteInt16(redPtr, i * sizeof(ushort), unchecked((short)expectedRed[i]));
                    Marshal.WriteInt16(greenPtr, i * sizeof(ushort), unchecked((short)expectedGreen[i]));
                    Marshal.WriteInt16(bluePtr, i * sizeof(ushort), unchecked((short)expectedBlue[i]));
                }

                GammaRampInternal internalRamp = CreateInternalRamp(redPtr, greenPtr, bluePtr, size);

                GammaRamp ramp = (GammaRamp)internalRamp;

                Assert.Equal(expectedRed, ramp.Red);
                Assert.Equal(expectedGreen, ramp.Green);
                Assert.Equal(expectedBlue, ramp.Blue);
                Assert.Equal((uint)size, ramp.Size);
            }
            finally
            {
                Marshal.FreeHGlobal(redPtr);
                Marshal.FreeHGlobal(greenPtr);
                Marshal.FreeHGlobal(bluePtr);
            }
        }

        /// <summary>
        ///     Tests that explicit operator with single element works correctly.
        /// </summary>
        [Fact]
        public void ExplicitOperator_WithSingleElement_ConvertsCorrectly()
        {
            const int size = 1;
            ushort[] expectedRed = { 42 };
            ushort[] expectedGreen = { 99 };
            ushort[] expectedBlue = { 255 };

            int bytes = size * sizeof(ushort);
            IntPtr redPtr = Marshal.AllocHGlobal(bytes);
            IntPtr greenPtr = Marshal.AllocHGlobal(bytes);
            IntPtr bluePtr = Marshal.AllocHGlobal(bytes);

            try
            {
                Marshal.WriteInt16(redPtr, 0, unchecked((short)expectedRed[0]));
                Marshal.WriteInt16(greenPtr, 0, unchecked((short)expectedGreen[0]));
                Marshal.WriteInt16(bluePtr, 0, unchecked((short)expectedBlue[0]));

                GammaRampInternal internalRamp = CreateInternalRamp(redPtr, greenPtr, bluePtr, size);

                GammaRamp ramp = (GammaRamp)internalRamp;

                Assert.Equal(expectedRed, ramp.Red);
                Assert.Equal(expectedGreen, ramp.Green);
                Assert.Equal(expectedBlue, ramp.Blue);
                Assert.Equal((uint)size, ramp.Size);
            }
            finally
            {
                Marshal.FreeHGlobal(redPtr);
                Marshal.FreeHGlobal(greenPtr);
                Marshal.FreeHGlobal(bluePtr);
            }
        }

        /// <summary>
        ///     Tests that explicit operator with max ushort values works correctly.
        /// </summary>
        [Fact]
        public void ExplicitOperator_WithMaxValues_ConvertsCorrectly()
        {
            const int size = 2;
            ushort[] expectedRed = { ushort.MaxValue, ushort.MinValue };
            ushort[] expectedGreen = { ushort.MaxValue, ushort.MinValue };
            ushort[] expectedBlue = { ushort.MaxValue, ushort.MinValue };

            int bytes = size * sizeof(ushort);
            IntPtr redPtr = Marshal.AllocHGlobal(bytes);
            IntPtr greenPtr = Marshal.AllocHGlobal(bytes);
            IntPtr bluePtr = Marshal.AllocHGlobal(bytes);

            try
            {
                for (int i = 0; i < size; i++)
                {
                    Marshal.WriteInt16(redPtr, i * sizeof(ushort), unchecked((short)expectedRed[i]));
                    Marshal.WriteInt16(greenPtr, i * sizeof(ushort), unchecked((short)expectedGreen[i]));
                    Marshal.WriteInt16(bluePtr, i * sizeof(ushort), unchecked((short)expectedBlue[i]));
                }

                GammaRampInternal internalRamp = CreateInternalRamp(redPtr, greenPtr, bluePtr, size);

                GammaRamp ramp = (GammaRamp)internalRamp;

                Assert.Equal(expectedRed, ramp.Red);
                Assert.Equal(expectedGreen, ramp.Green);
                Assert.Equal(expectedBlue, ramp.Blue);
                Assert.Equal((uint)size, ramp.Size);
            }
            finally
            {
                Marshal.FreeHGlobal(redPtr);
                Marshal.FreeHGlobal(greenPtr);
                Marshal.FreeHGlobal(bluePtr);
            }
        }

        /// <summary>
        ///     Creates a GammaRampInternal with the specified field values via boxing.
        /// </summary>
        private static GammaRampInternal CreateInternalRamp(IntPtr red, IntPtr green, IntPtr blue, int size)
        {
            object boxed = default(GammaRampInternal);
            System.Reflection.FieldInfo[] fields = typeof(GammaRampInternal).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            for (int i = 0; i < fields.Length; i++)
            {
                string name = fields[i].Name;
                if (name == "Red")
                {
                    fields[i].SetValue(boxed, red);
                }
                else if (name == "Green")
                {
                    fields[i].SetValue(boxed, green);
                }
                else if (name == "Blue")
                {
                    fields[i].SetValue(boxed, blue);
                }
                else if (name == "Size")
                {
                    fields[i].SetValue(boxed, size);
                }
            }

            return (GammaRampInternal)boxed;
        }
    }
}
