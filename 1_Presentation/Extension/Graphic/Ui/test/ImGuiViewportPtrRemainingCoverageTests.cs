// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiViewportPtrRemainingCoverageTests.cs
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
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui viewport ptr remaining coverage tests class
    /// </summary>
    public class ImGuiViewportPtrRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that constructor with zero int ptr should set native ptr to zero
        /// </summary>
        [Fact]
        public void Constructor_WithZeroIntPtr_ShouldSetNativePtrToZero()
        {
            ImGuiViewportPtr ptr = new ImGuiViewportPtr(IntPtr.Zero);
            Assert.Equal(IntPtr.Zero, ptr.NativePtr);
        }

        /// <summary>
        ///     Tests that implicit operator from int ptr should return correct instance
        /// </summary>
        [Fact]
        public void ImplicitOperator_FromIntPtr_ShouldReturnCorrectInstance()
        {
            IntPtr nativePtr = new IntPtr(42);
            ImGuiViewportPtr ptr = nativePtr;
            Assert.Equal(nativePtr, ptr.NativePtr);
        }

        /// <summary>
        ///     Tests that implicit operator to int ptr should return native pointer
        /// </summary>
        [Fact]
        public void ImplicitOperator_ToIntPtr_ShouldReturnNativePointer()
        {
            IntPtr nativePtr = new IntPtr(99);
            ImGuiViewportPtr ptr = new ImGuiViewportPtr(nativePtr);
            IntPtr result = ptr;
            Assert.Equal(nativePtr, result);
        }
    }
}
