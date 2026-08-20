// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiPlatformIOPtrTest.cs
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
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Contract and behavior tests for <see cref="ImGuiPlatformIoPtr" />.
    /// </summary>
    public class ImGuiPlatformIOPtrTest
    {
        /// <summary>
        ///     Verifies that ImGuiPlatformIoPtr is a value type.
        /// </summary>
         [RequireCImguiSystemFact]
        public void ImGuiPlatformIoPtr_ShouldBeValueType()
        {
            Assert.True(typeof(ImGuiPlatformIoPtr).IsValueType);
        }

        /// <summary>
        ///     Verifies that ImGuiPlatformIoPtr has sequential layout.
        /// </summary>
         [RequireCImguiSystemFact]
        public void ImGuiPlatformIoPtr_ShouldHaveSequentialLayout()
        {
            StructLayoutAttribute attribute = typeof(ImGuiPlatformIoPtr).StructLayoutAttribute;

            Assert.NotNull(attribute);
            Assert.Equal(LayoutKind.Sequential, attribute.Value);
        }

        /// <summary>
        ///     Verifies that the constructor stores the native pointer.
        /// </summary>
         [RequireCImguiSystemFact]
        public void Constructor_ShouldStoreNativePtr()
        {
            IntPtr expected = new IntPtr(12345);
            ImGuiPlatformIoPtr ptr = new ImGuiPlatformIoPtr(expected);

            Assert.Equal(expected, ptr.NativePtr);
        }

        /// <summary>
        ///     Verifies the implicit conversion from ImGuiPlatformIoPtr to IntPtr.
        /// </summary>
         [RequireCImguiSystemFact]
        public void ImplicitConversion_ToIntPtr_ShouldReturnNativePtr()
        {
            IntPtr expected = new IntPtr(67890);
            ImGuiPlatformIoPtr ptr = new ImGuiPlatformIoPtr(expected);

            IntPtr result = ptr;

            Assert.Equal(expected, result);
        }

        /// <summary>
        ///     Verifies the explicit conversion from IntPtr to ImGuiPlatformIoPtr.
        /// </summary>
         [RequireCImguiSystemFact]
        public void ExplicitConversion_FromIntPtr_ShouldCreateInstance()
        {
            IntPtr expected = new IntPtr(11111);
            ImGuiPlatformIoPtr ptr = (ImGuiPlatformIoPtr)expected;

            Assert.Equal(expected, ptr.NativePtr);
        }

        /// <summary>
        ///     Verifies that Equals compares NativePtr values.
        /// </summary>
         [RequireCImguiSystemFact]
        public void Equals_SameNativePtr_ShouldReturnTrue()
        {
            IntPtr nativePtr = new IntPtr(33333);
            ImGuiPlatformIoPtr ptr1 = new ImGuiPlatformIoPtr(nativePtr);
            ImGuiPlatformIoPtr ptr2 = new ImGuiPlatformIoPtr(nativePtr);

            Assert.True(ptr1.Equals(ptr2));
        }

        /// <summary>
        ///     Verifies that Equals returns false for different NativePtr values.
        /// </summary>
         [RequireCImguiSystemFact]
        public void Equals_DifferentNativePtr_ShouldReturnFalse()
        {
            ImGuiPlatformIoPtr ptr1 = new ImGuiPlatformIoPtr(new IntPtr(44444));
            ImGuiPlatformIoPtr ptr2 = new ImGuiPlatformIoPtr(new IntPtr(55555));

            Assert.False(ptr1.Equals(ptr2));
        }

        /// <summary>
        ///     Verifies that Equals with null returns false.
        /// </summary>
         [RequireCImguiSystemFact]
        public void Equals_NullObject_ShouldReturnFalse()
        {
            ImGuiPlatformIoPtr ptr = new ImGuiPlatformIoPtr(new IntPtr(66666));

            Assert.False(ptr.Equals(null));
        }

        /// <summary>
        ///     Verifies that GetHashCode is consistent across calls.
        /// </summary>
         [RequireCImguiSystemFact]
        public void GetHashCode_ShouldBeConsistent()
        {
            ImGuiPlatformIoPtr ptr = new ImGuiPlatformIoPtr(new IntPtr(77777));

            int hash1 = ptr.GetHashCode();
            int hash2 = ptr.GetHashCode();

            Assert.Equal(hash1, hash2);
        }
    }
}
