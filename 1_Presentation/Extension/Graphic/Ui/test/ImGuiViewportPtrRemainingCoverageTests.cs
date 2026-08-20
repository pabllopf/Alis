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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui.Test.Attributes;
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
         [RequireCImguiSystemFact]
        public void Constructor_WithZeroIntPtr_ShouldSetNativePtrToZero()
        {
            ImGuiViewportPtr ptr = new ImGuiViewportPtr(IntPtr.Zero);
            Assert.Equal(IntPtr.Zero, ptr.NativePtr);
        }

        /// <summary>
        ///     Tests that constructor with im gui viewport should set native ptr
        /// </summary>
         [RequireCImguiSystemFact]
        public void Constructor_WithImGuiViewport_ShouldSetNativePtr()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            ImGuiViewportPtr ptr = new ImGuiViewportPtr(viewport);
            Assert.NotEqual(IntPtr.Zero, ptr.NativePtr);
        }

        /// <summary>
        ///     Tests that implicit operator from int ptr should return correct instance
        /// </summary>
         [RequireCImguiSystemFact]
        public void ImplicitOperator_FromIntPtr_ShouldReturnCorrectInstance()
        {
            IntPtr nativePtr = new IntPtr(42);
            ImGuiViewportPtr ptr = nativePtr;
            Assert.Equal(nativePtr, ptr.NativePtr);
        }

        /// <summary>
        ///     Tests that implicit operator to int ptr should return native pointer
        /// </summary>
         [RequireCImguiSystemFact]
        public void ImplicitOperator_ToIntPtr_ShouldReturnNativePointer()
        {
            IntPtr nativePtr = new IntPtr(99);
            ImGuiViewportPtr ptr = new ImGuiViewportPtr(nativePtr);
            IntPtr result = ptr;
            Assert.Equal(nativePtr, result);
        }

        /// <summary>
        ///     Tests that id should read correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void Id_ShouldReadCorrectValue()
        {
            const uint expected = 42u;
            IntPtr ptr = Marshal.AllocHGlobal(64);
            try
            {
                Marshal.WriteInt32(ptr, 0, (int)expected);
                ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(ptr);
                Assert.Equal(expected, viewportPtr.Id);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        ///     Tests that flags should read correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void Flags_ShouldReadCorrectValue()
        {
            const ImGuiViewportFlags expected = ImGuiViewportFlags.TopMost;
            IntPtr ptr = Marshal.AllocHGlobal(64);
            try
            {
                Marshal.WriteInt32(ptr, sizeof(uint), (int)expected);
                ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(ptr);
                Assert.Equal(expected, viewportPtr.Flags);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        ///     Tests that pos should read correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void Pos_ShouldReadCorrectValue()
        {
            Vector2F expected = new Vector2F(1.5f, 2.5f);
            IntPtr ptr = Marshal.AllocHGlobal(64);
            try
            {
                Marshal.StructureToPtr(expected, ptr + 2 * sizeof(uint), false);
                ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(ptr);
                Assert.Equal(expected, viewportPtr.Pos);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        ///     Tests that size should read correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void Size_ShouldReadCorrectValue()
        {
            Vector2F expected = new Vector2F(3.5f, 4.5f);
            IntPtr ptr = Marshal.AllocHGlobal(64);
            try
            {
                Marshal.StructureToPtr(expected, ptr + 2 * sizeof(uint) + Marshal.SizeOf<Vector2F>(), false);
                ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(ptr);
                Assert.Equal(expected, viewportPtr.Size);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        ///     Tests that work pos should read correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void WorkPos_ShouldReadCorrectValue()
        {
            Vector2F expected = new Vector2F(5.5f, 6.5f);
            IntPtr ptr = Marshal.AllocHGlobal(64);
            try
            {
                Marshal.StructureToPtr(expected, ptr + 2 * sizeof(uint) + 2 * Marshal.SizeOf<Vector2F>(), false);
                ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(ptr);
                Assert.Equal(expected, viewportPtr.WorkPos);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        ///     Tests that work size should read correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void WorkSize_ShouldReadCorrectValue()
        {
            Vector2F expected = new Vector2F(7.5f, 8.5f);
            IntPtr ptr = Marshal.AllocHGlobal(64);
            try
            {
                Marshal.StructureToPtr(expected, ptr + 2 * sizeof(uint) + 3 * Marshal.SizeOf<Vector2F>(), false);
                ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(ptr);
                Assert.Equal(expected, viewportPtr.WorkSize);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        ///     Tests that dpi scale should read correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void DpiScale_ShouldReadCorrectValue()
        {
            const float expected = 2.0f;
            IntPtr ptr = Marshal.AllocHGlobal(64);
            try
            {
                Marshal.StructureToPtr(expected, ptr + 2 * sizeof(uint) + 4 * Marshal.SizeOf<Vector2F>(), false);
                ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(ptr);
                Assert.Equal(expected, viewportPtr.DpiScale);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        ///     Tests that parent viewport id should read correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void ParentViewportId_ShouldReadCorrectValue()
        {
            const uint expected = 99u;
            IntPtr ptr = Marshal.AllocHGlobal(64);
            try
            {
                int offset = 2 * sizeof(uint) + 4 * Marshal.SizeOf<Vector2F>() + sizeof(float);
                Marshal.WriteInt32(ptr, offset, (int)expected);
                ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(ptr);
                Assert.Equal(expected, viewportPtr.ParentViewportId);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        ///     Tests that renderer user data get should throw argument exception
        /// </summary>
         [RequireCImguiSystemFact]
        public void RendererUserData_Get_ShouldThrowArgumentException()
        {
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(IntPtr.Zero);
            Assert.Throws<ArgumentException>(() => viewportPtr.RendererUserData);
        }

        /// <summary>
        ///     Tests that renderer user data set should throw argument exception
        /// </summary>
         [RequireCImguiSystemFact]
        public void RendererUserData_Set_ShouldThrowArgumentException()
        {
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(IntPtr.Zero);
            Assert.Throws<ArgumentException>(() => viewportPtr.RendererUserData = IntPtr.Zero);
        }

        /// <summary>
        ///     Tests that platform user data get should throw argument exception
        /// </summary>
         [RequireCImguiSystemFact]
        public void PlatformUserData_Get_ShouldThrowArgumentException()
        {
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(IntPtr.Zero);
            Assert.Throws<ArgumentException>(() => viewportPtr.PlatformUserData);
        }

        /// <summary>
        ///     Tests that platform user data set should throw argument exception
        /// </summary>
         [RequireCImguiSystemFact]
        public void PlatformUserData_Set_ShouldThrowArgumentException()
        {
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(IntPtr.Zero);
            Assert.Throws<ArgumentException>(() => viewportPtr.PlatformUserData = IntPtr.Zero);
        }

        /// <summary>
        ///     Tests that platform handle should throw argument exception
        /// </summary>
         [RequireCImguiSystemFact]
        public void PlatformHandle_ShouldThrowArgumentException()
        {
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(IntPtr.Zero);
            Assert.Throws<ArgumentException>(() => viewportPtr.PlatformHandle);
        }

        /// <summary>
        ///     Tests that platform handle raw should throw argument exception
        /// </summary>
         [RequireCImguiSystemFact]
        public void PlatformHandleRaw_ShouldThrowArgumentException()
        {
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(IntPtr.Zero);
            Assert.Throws<ArgumentException>(() => viewportPtr.PlatformHandleRaw);
        }

        /// <summary>
        ///     Tests that platform window created should throw argument exception
        /// </summary>
         [RequireCImguiSystemFact]
        public void PlatformWindowCreated_ShouldThrowArgumentException()
        {
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(IntPtr.Zero);
            Assert.Throws<ArgumentException>(() => viewportPtr.PlatformWindowCreated);
        }

        /// <summary>
        ///     Tests that platform request move should throw argument exception
        /// </summary>
         [RequireCImguiSystemFact]
        public void PlatformRequestMove_ShouldThrowArgumentException()
        {
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(IntPtr.Zero);
            Assert.Throws<ArgumentException>(() => viewportPtr.PlatformRequestMove);
        }

        /// <summary>
        ///     Tests that platform request resize should throw argument exception
        /// </summary>
         [RequireCImguiSystemFact]
        public void PlatformRequestResize_ShouldThrowArgumentException()
        {
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(IntPtr.Zero);
            Assert.Throws<ArgumentException>(() => viewportPtr.PlatformRequestResize);
        }

        /// <summary>
        ///     Tests that platform request close should throw argument exception
        /// </summary>
         [RequireCImguiSystemFact]
        public void PlatformRequestClose_ShouldThrowArgumentException()
        {
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(IntPtr.Zero);
            Assert.Throws<ArgumentException>(() => viewportPtr.PlatformRequestClose);
        }
    }
}
