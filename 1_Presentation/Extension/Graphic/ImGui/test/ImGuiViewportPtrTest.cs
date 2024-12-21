// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiViewportPtrTest.cs
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
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test
{
    /// <summary>
    ///     The im gui viewport ptr test class
    /// </summary>
    public class ImGuiViewportPtrTest
    {
        /// <summary>
        ///     Tests that native ptr should be initialized
        /// </summary>
        [Fact]
        public void NativePtr_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(viewport);
            Assert.NotEqual(IntPtr.Zero, viewportPtr.NativePtr);
        }

        /// <summary>
        ///     Tests that id should be initialized
        /// </summary>
        [Fact]
        public void Id_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(viewport);
            Assert.Equal(default(uint), viewportPtr.Id);
        }

        /// <summary>
        ///     Tests that flags should be initialized
        /// </summary>
        [Fact]
        public void Flags_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(viewport);
            Assert.Equal(default(ImGuiViewportFlags), viewportPtr.Flags);
        }

        /// <summary>
        ///     Tests that pos should be initialized
        /// </summary>
        [Fact]
        public void Pos_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(viewport);
            Assert.Equal(default(Vector2F), viewportPtr.Pos);
        }

        /// <summary>
        ///     Tests that size should be initialized
        /// </summary>
        [Fact]
        public void Size_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(viewport);
            Assert.Equal(default(Vector2F), viewportPtr.Size);
        }

        /// <summary>
        ///     Tests that work pos should be initialized
        /// </summary>
        [Fact]
        public void WorkPos_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(viewport);
            Assert.Equal(default(Vector2F), viewportPtr.WorkPos);
        }

        /// <summary>
        ///     Tests that work size should be initialized
        /// </summary>
        [Fact]
        public void WorkSize_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(viewport);
            Assert.Equal(default(Vector2F), viewportPtr.WorkSize);
        }

        /// <summary>
        ///     Tests that dpi scale should be initialized
        /// </summary>
        [Fact]
        public void DpiScale_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(viewport);
            Assert.Equal(default(float), viewportPtr.DpiScale);
        }

        /// <summary>
        ///     Tests that parent viewport id should be initialized
        /// </summary>
        [Fact]
        public void ParentViewportId_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(viewport);
            Assert.Equal(default(uint), viewportPtr.ParentViewportId);
        }

        /// <summary>
        ///     Tests that renderer user data should be initialized
        /// </summary>
        [Fact]
        public void RendererUserData_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(viewport);
            Assert.Throws<ArgumentException>(() => viewportPtr.RendererUserData);
        }

        /// <summary>
        ///     Tests that platform user data should be initialized
        /// </summary>
        [Fact]
        public void PlatformUserData_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(viewport);
            Assert.Throws<ArgumentException>(() => viewportPtr.PlatformUserData);
        }

        /// <summary>
        ///     Tests that platform handle should be initialized
        /// </summary>
        [Fact]
        public void PlatformHandle_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(viewport);
            Assert.Throws<ArgumentException>(() => viewportPtr.PlatformHandle);
        }

        /// <summary>
        ///     Tests that platform handle raw should be initialized
        /// </summary>
        [Fact]
        public void PlatformHandleRaw_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(viewport);
            Assert.Throws<ArgumentException>(() => viewportPtr.PlatformHandleRaw);
        }

        /// <summary>
        ///     Tests that platform window created should be initialized
        /// </summary>
        [Fact]
        public void PlatformWindowCreated_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(viewport);
            Assert.Throws<ArgumentException>(() => viewportPtr.PlatformWindowCreated);
        }

        /// <summary>
        ///     Tests that platform request move should be initialized
        /// </summary>
        [Fact]
        public void PlatformRequestMove_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(viewport);
            Assert.Throws<ArgumentException>(() => viewportPtr.PlatformRequestMove);
        }

        /// <summary>
        ///     Tests that platform request resize should be initialized
        /// </summary>
        [Fact]
        public void PlatformRequestResize_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(viewport);
            Assert.Throws<ArgumentException>(() => viewportPtr.PlatformRequestResize);
        }

        /// <summary>
        ///     Tests that platform request close should be initialized
        /// </summary>
        [Fact]
        public void PlatformRequestClose_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(viewport);
            Assert.Throws<ArgumentException>(() => viewportPtr.PlatformRequestClose);
        }

        /// <summary>
        ///     Tests that renderer user data should set and get correctly
        /// </summary>
        [Fact]
        public void RendererUserData_Should_SetAndGetCorrectly()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(viewport);
            IntPtr value = new IntPtr(123);

            Assert.Throws<ArgumentException>(() => viewportPtr.RendererUserData = value);
        }

        /// <summary>
        ///     Tests that platform user data should set and get correctly
        /// </summary>
        [Fact]
        public void PlatformUserData_Should_SetAndGetCorrectly()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(viewport);
            IntPtr value = new IntPtr(123);

            Assert.Throws<ArgumentException>(() => viewportPtr.PlatformUserData = value);
        }

        /// <summary>
        ///     Tests that implicit operator from int ptr should return correct instance
        /// </summary>
        [Fact]
        public void ImplicitOperator_FromIntPtr_ShouldReturnCorrectInstance()
        {
            IntPtr nativePtr = new IntPtr(123);
            ImGuiViewportPtr viewportPtr = nativePtr;
            Assert.Equal(nativePtr, viewportPtr.NativePtr);
        }

        /// <summary>
        ///     Tests that implicit operator from im gui viewport ptr should return correct int ptr
        /// </summary>
        [Fact]
        public void ImplicitOperator_FromImGuiViewportPtr_ShouldReturnCorrectIntPtr()
        {
            IntPtr nativePtr = new IntPtr(123);
            ImGuiViewportPtr viewportPtr = new ImGuiViewportPtr(nativePtr);
            IntPtr result = viewportPtr;
            Assert.Equal(nativePtr, result);
        }
    }
}