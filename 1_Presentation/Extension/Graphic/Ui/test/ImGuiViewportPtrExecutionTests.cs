// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiViewportPtrExecutionTests.cs
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
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui viewport ptr execution tests class
    /// </summary>
    public class ImGuiViewportPtrExecutionTests
    {
        /// <summary>
        ///     Tests that the int ptr constructor sets the native pointer
        /// </summary>
        [Fact]
        public void ImGuiViewportPtr_IntPtrConstructor_SetsNativePtr()
        {
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(new IntPtr(42));

            Assert.Equal(new IntPtr(42), viewportPtr.NativePtr);
        }

        /// <summary>
        ///     Tests that the viewport constructor pins and captures a non-zero pointer
        /// </summary>
        [Fact]
        public void ImGuiViewportPtr_ViewportConstructor_PinsNonZeroPointer()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(viewport);

            Assert.NotEqual(IntPtr.Zero, viewportPtr.NativePtr);
        }

        /// <summary>
        ///     Tests that the implicit operator converts from int ptr
        /// </summary>
        [Fact]
        public void ImGuiViewportPtr_ImplicitFromIntPtr_ReturnsInstance()
        {
            IntPtr nativePtr = new IntPtr(42);
            ImGuiViewportPtr viewportPtr = nativePtr;

            Assert.Equal(nativePtr, viewportPtr.NativePtr);
        }

        /// <summary>
        ///     Tests that the implicit operator converts to int ptr
        /// </summary>
        [Fact]
        public void ImGuiViewportPtr_ImplicitToIntPtr_ReturnsNativePointer()
        {
            IntPtr nativePtr = new IntPtr(99);
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(nativePtr);

            IntPtr result = viewportPtr;

            Assert.Equal(nativePtr, result);
        }

        /// <summary>
        ///     Tests that the id getter reads at offset zero
        /// </summary>
        [Fact]
        public void ImGuiViewportPtr_Id_ReadsAtOffsetZero()
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
        ///     Tests that the flags getter reads at the flags offset
        /// </summary>
        [Fact]
        public void ImGuiViewportPtr_Flags_ReadsAtFlagsOffset()
        {
            ImGuiViewportFlags expected = ImGuiViewportFlags.TopMost;
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
        ///     Tests that the pos getter reads the position vector
        /// </summary>
        [Fact]
        public void ImGuiViewportPtr_Pos_ReadsPositionVector()
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
        ///     Tests that the size getter reads the size vector
        /// </summary>
        [Fact]
        public void ImGuiViewportPtr_Size_ReadsSizeVector()
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
        ///     Tests that the work pos getter reads the work position vector
        /// </summary>
        [Fact]
        public void ImGuiViewportPtr_WorkPos_ReadsWorkPositionVector()
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
        ///     Tests that the work size getter reads the work size vector
        /// </summary>
        [Fact]
        public void ImGuiViewportPtr_WorkSize_ReadsWorkSizeVector()
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
        ///     Tests that the dpi scale getter reads the dpi value
        /// </summary>
        [Fact]
        public void ImGuiViewportPtr_DpiScale_ReadsDpiValue()
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
        ///     Tests that the parent viewport id getter reads its value
        /// </summary>
        [Fact]
        public void ImGuiViewportPtr_ParentViewportId_ReadsValue()
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
        ///     Tests that the renderer user data getter throws due to a missing field
        /// </summary>
        [Fact]
        public void ImGuiViewportPtr_RendererUserData_Get_ThrowsArgumentException()
        {
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(IntPtr.Zero);

            Assert.Throws<ArgumentException>(() => viewportPtr.RendererUserData);
        }

        /// <summary>
        ///     Tests that the renderer user data setter throws due to a missing field
        /// </summary>
        [Fact]
        public void ImGuiViewportPtr_RendererUserData_Set_ThrowsArgumentException()
        {
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(IntPtr.Zero);

            Assert.Throws<ArgumentException>(() => viewportPtr.RendererUserData = IntPtr.Zero);
        }

        /// <summary>
        ///     Tests that the platform user data getter throws due to a missing field
        /// </summary>
        [Fact]
        public void ImGuiViewportPtr_PlatformUserData_Get_ThrowsArgumentException()
        {
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(IntPtr.Zero);

            Assert.Throws<ArgumentException>(() => viewportPtr.PlatformUserData);
        }

        /// <summary>
        ///     Tests that the platform user data setter throws due to a missing field
        /// </summary>
        [Fact]
        public void ImGuiViewportPtr_PlatformUserData_Set_ThrowsArgumentException()
        {
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(IntPtr.Zero);

            Assert.Throws<ArgumentException>(() => viewportPtr.PlatformUserData = IntPtr.Zero);
        }

        /// <summary>
        ///     Tests that the platform handle getter throws due to a missing field
        /// </summary>
        [Fact]
        public void ImGuiViewportPtr_PlatformHandle_ThrowsArgumentException()
        {
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(IntPtr.Zero);

            Assert.Throws<ArgumentException>(() => viewportPtr.PlatformHandle);
        }

        /// <summary>
        ///     Tests that the platform handle raw getter throws due to a missing field
        /// </summary>
        [Fact]
        public void ImGuiViewportPtr_PlatformHandleRaw_ThrowsArgumentException()
        {
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(IntPtr.Zero);

            Assert.Throws<ArgumentException>(() => viewportPtr.PlatformHandleRaw);
        }

        /// <summary>
        ///     Tests that the platform window created getter throws due to a missing field
        /// </summary>
        [Fact]
        public void ImGuiViewportPtr_PlatformWindowCreated_ThrowsArgumentException()
        {
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(IntPtr.Zero);

            Assert.Throws<ArgumentException>(() => viewportPtr.PlatformWindowCreated);
        }

        /// <summary>
        ///     Tests that the platform request move getter throws due to a missing field
        /// </summary>
        [Fact]
        public void ImGuiViewportPtr_PlatformRequestMove_ThrowsArgumentException()
        {
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(IntPtr.Zero);

            Assert.Throws<ArgumentException>(() => viewportPtr.PlatformRequestMove);
        }

        /// <summary>
        ///     Tests that the platform request resize getter throws due to a missing field
        /// </summary>
        [Fact]
        public void ImGuiViewportPtr_PlatformRequestResize_ThrowsArgumentException()
        {
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(IntPtr.Zero);

            Assert.Throws<ArgumentException>(() => viewportPtr.PlatformRequestResize);
        }

        /// <summary>
        ///     Tests that the platform request close getter throws due to a missing field
        /// </summary>
        [Fact]
        public void ImGuiViewportPtr_PlatformRequestClose_ThrowsArgumentException()
        {
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(IntPtr.Zero);

            Assert.Throws<ArgumentException>(() => viewportPtr.PlatformRequestClose);
        }
    }
}
