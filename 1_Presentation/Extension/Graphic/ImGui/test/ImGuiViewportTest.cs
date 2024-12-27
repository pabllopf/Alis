// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiViewportTest.cs
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
using System.Diagnostics.CodeAnalysis;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test
{
    /// <summary>
    ///     The im gui viewport test class
    /// </summary>
    	  
	 public class ImGuiViewportTest 
    {
        /// <summary>
        ///     Tests that id should be initialized
        /// </summary>
        [Fact]
        public void Id_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal(0u, viewport.Id);
        }

        /// <summary>
        ///     Tests that flags should be initialized
        /// </summary>
        [Fact]
        public void Flags_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal(default(ImGuiViewportFlags), viewport.Flags);
        }

        /// <summary>
        ///     Tests that pos should be initialized
        /// </summary>
        [Fact]
        public void Pos_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal(default(Vector2F), viewport.Pos);
        }

        /// <summary>
        ///     Tests that size should be initialized
        /// </summary>
        [Fact]
        public void Size_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal(default(Vector2F), viewport.Size);
        }

        /// <summary>
        ///     Tests that work pos should be initialized
        /// </summary>
        [Fact]
        public void WorkPos_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal(default(Vector2F), viewport.WorkPos);
        }

        /// <summary>
        ///     Tests that work size should be initialized
        /// </summary>
        [Fact]
        public void WorkSize_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal(default(Vector2F), viewport.WorkSize);
        }

        /// <summary>
        ///     Tests that dpi scale should be initialized
        /// </summary>
        [Fact]
        public void DpiScale_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal(0f, viewport.DpiScale);
        }

        /// <summary>
        ///     Tests that parent viewport id should be initialized
        /// </summary>
        [Fact]
        public void ParentViewportId_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal(0u, viewport.ParentViewportId);
        }

        /// <summary>
        ///     Tests that draw data should be initialized
        /// </summary>
        [Fact]
        public void DrawData_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal(IntPtr.Zero, viewport.DrawData);
        }

        /// <summary>
        ///     Tests that renderer user data should be initialized
        /// </summary>
        [Fact]
        public void RendererUserData_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal(IntPtr.Zero, viewport.RendererUserData);
        }

        /// <summary>
        ///     Tests that platform user data should be initialized
        /// </summary>
        [Fact]
        public void PlatformUserData_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal(IntPtr.Zero, viewport.PlatformUserData);
        }

        /// <summary>
        ///     Tests that platform handle should be initialized
        /// </summary>
        [Fact]
        public void PlatformHandle_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal(IntPtr.Zero, viewport.PlatformHandle);
        }

        /// <summary>
        ///     Tests that platform handle raw should be initialized
        /// </summary>
        [Fact]
        public void PlatformHandleRaw_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal(IntPtr.Zero, viewport.PlatformHandleRaw);
        }

        /// <summary>
        ///     Tests that platform window created should be initialized
        /// </summary>
        [Fact]
        public void PlatformWindowCreated_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal((byte) 0, viewport.PlatformWindowCreated);
        }

        /// <summary>
        ///     Tests that platform request move should be initialized
        /// </summary>
        [Fact]
        public void PlatformRequestMove_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal((byte) 0, viewport.PlatformRequestMove);
        }

        /// <summary>
        ///     Tests that platform request resize should be initialized
        /// </summary>
        [Fact]
        public void PlatformRequestResize_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal((byte) 0, viewport.PlatformRequestResize);
        }

        /// <summary>
        ///     Tests that platform request close should be initialized
        /// </summary>
        [Fact]
        public void PlatformRequestClose_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal((byte) 0, viewport.PlatformRequestClose);
        }

        /// <summary>
        ///     Tests that id set and get returns correct value
        /// </summary>
        [Fact]
        public void Id_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport obj = new ImGuiViewport();
            uint value = 123;
            obj.Id = value;
            Assert.Equal(value, obj.Id);
        }

        /// <summary>
        ///     Tests that flags set and get returns correct value
        /// </summary>
        [Fact]
        public void Flags_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport obj = new ImGuiViewport();
            ImGuiViewportFlags value = ImGuiViewportFlags.None;
            obj.Flags = value;
            Assert.Equal(value, obj.Flags);
        }

        /// <summary>
        ///     Tests that pos set and get returns correct value
        /// </summary>
        [Fact]
        public void Pos_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport obj = new ImGuiViewport();
            Vector2F value = new Vector2F(1.0f, 2.0f);
            obj.Pos = value;
            Assert.Equal(value, obj.Pos);
        }

        /// <summary>
        ///     Tests that size set and get returns correct value
        /// </summary>
        [Fact]
        public void Size_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport obj = new ImGuiViewport();
            Vector2F value = new Vector2F(3.0f, 4.0f);
            obj.Size = value;
            Assert.Equal(value, obj.Size);
        }

        /// <summary>
        ///     Tests that work pos set and get returns correct value
        /// </summary>
        [Fact]
        public void WorkPos_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport obj = new ImGuiViewport();
            Vector2F value = new Vector2F(5.0f, 6.0f);
            obj.WorkPos = value;
            Assert.Equal(value, obj.WorkPos);
        }

        /// <summary>
        ///     Tests that work size set and get returns correct value
        /// </summary>
        [Fact]
        public void WorkSize_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport obj = new ImGuiViewport();
            Vector2F value = new Vector2F(7.0f, 8.0f);
            obj.WorkSize = value;
            Assert.Equal(value, obj.WorkSize);
        }

        /// <summary>
        ///     Tests that dpi scale set and get returns correct value
        /// </summary>
        [Fact]
        public void DpiScale_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport obj = new ImGuiViewport();
            float value = 1.5f;
            obj.DpiScale = value;
            Assert.Equal(value, obj.DpiScale);
        }

        /// <summary>
        ///     Tests that parent viewport id set and get returns correct value
        /// </summary>
        [Fact]
        public void ParentViewportId_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport obj = new ImGuiViewport();
            uint value = 456;
            obj.ParentViewportId = value;
            Assert.Equal(value, obj.ParentViewportId);
        }

        /// <summary>
        ///     Tests that draw data set and get returns correct value
        /// </summary>
        [Fact]
        public void DrawData_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport obj = new ImGuiViewport();
            IntPtr value = new IntPtr(789);
            obj.DrawData = value;
            Assert.Equal(value, obj.DrawData);
        }

        /// <summary>
        ///     Tests that renderer user data set and get returns correct value
        /// </summary>
        [Fact]
        public void RendererUserData_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport obj = new ImGuiViewport();
            IntPtr value = new IntPtr(101112);
            obj.RendererUserData = value;
            Assert.Equal(value, obj.RendererUserData);
        }

        /// <summary>
        ///     Tests that platform user data set and get returns correct value
        /// </summary>
        [Fact]
        public void PlatformUserData_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport obj = new ImGuiViewport();
            IntPtr value = new IntPtr(131415);
            obj.PlatformUserData = value;
            Assert.Equal(value, obj.PlatformUserData);
        }

        /// <summary>
        ///     Tests that platform handle set and get returns correct value
        /// </summary>
        [Fact]
        public void PlatformHandle_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport obj = new ImGuiViewport();
            IntPtr value = new IntPtr(161718);
            obj.PlatformHandle = value;
            Assert.Equal(value, obj.PlatformHandle);
        }

        /// <summary>
        ///     Tests that platform handle raw set and get returns correct value
        /// </summary>
        [Fact]
        public void PlatformHandleRaw_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport obj = new ImGuiViewport();
            IntPtr value = new IntPtr(192021);
            obj.PlatformHandleRaw = value;
            Assert.Equal(value, obj.PlatformHandleRaw);
        }

        /// <summary>
        ///     Tests that platform window created set and get returns correct value
        /// </summary>
        [Fact]
        public void PlatformWindowCreated_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport obj = new ImGuiViewport();
            byte value = 1;
            obj.PlatformWindowCreated = value;
            Assert.Equal(value, obj.PlatformWindowCreated);
        }

        /// <summary>
        ///     Tests that platform request move set and get returns correct value
        /// </summary>
        [Fact]
        public void PlatformRequestMove_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport obj = new ImGuiViewport();
            byte value = 1;
            obj.PlatformRequestMove = value;
            Assert.Equal(value, obj.PlatformRequestMove);
        }

        /// <summary>
        ///     Tests that platform request resize set and get returns correct value
        /// </summary>
        [Fact]
        public void PlatformRequestResize_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport obj = new ImGuiViewport();
            byte value = 1;
            obj.PlatformRequestResize = value;
            Assert.Equal(value, obj.PlatformRequestResize);
        }

        /// <summary>
        ///     Tests that platform request close set and get returns correct value
        /// </summary>
        [Fact]
        public void PlatformRequestClose_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport obj = new ImGuiViewport();
            byte value = 1;
            obj.PlatformRequestClose = value;
            Assert.Equal(value, obj.PlatformRequestClose);
        }
    }
}