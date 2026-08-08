// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiViewportRemainingCoverageTests.cs
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

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui viewport remaining coverage tests class
    /// </summary>
    public class ImGuiViewportRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that default id should be zero
        /// </summary>
        [Fact]
        public void DefaultId_ShouldBeZero()
        {
            ImGuiViewport viewport = default;
            Assert.Equal(0u, viewport.Id);
        }

        /// <summary>
        ///     Tests that default flags should be none
        /// </summary>
        [Fact]
        public void DefaultFlags_ShouldBeNone()
        {
            ImGuiViewport viewport = default;
            Assert.Equal(default(ImGuiViewportFlags), viewport.Flags);
        }

        /// <summary>
        ///     Tests that default pos should be zero
        /// </summary>
        [Fact]
        public void DefaultPos_ShouldBeZero()
        {
            ImGuiViewport viewport = default;
            Assert.Equal(default(Vector2F), viewport.Pos);
        }

        /// <summary>
        ///     Tests that default size should be zero
        /// </summary>
        [Fact]
        public void DefaultSize_ShouldBeZero()
        {
            ImGuiViewport viewport = default;
            Assert.Equal(default(Vector2F), viewport.Size);
        }

        /// <summary>
        ///     Tests that default dpi scale should be zero
        /// </summary>
        [Fact]
        public void DefaultDpiScale_ShouldBeZero()
        {
            ImGuiViewport viewport = default;
            Assert.Equal(0f, viewport.DpiScale, 5);
        }

        /// <summary>
        ///     Tests that id set and get returns correct value
        /// </summary>
        [Fact]
        public void Id_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport viewport = default;
            viewport.Id = 42u;
            Assert.Equal(42u, viewport.Id);
        }

        /// <summary>
        ///     Tests that flags set and get returns correct value
        /// </summary>
        [Fact]
        public void Flags_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport viewport = default;
            viewport.Flags = ImGuiViewportFlags.TopMost;
            Assert.Equal(ImGuiViewportFlags.TopMost, viewport.Flags);
        }

        /// <summary>
        ///     Tests that pos set and get returns correct value
        /// </summary>
        [Fact]
        public void Pos_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport viewport = default;
            Vector2F value = new Vector2F(1.0f, 2.0f);
            viewport.Pos = value;
            Assert.Equal(value, viewport.Pos);
        }

        /// <summary>
        ///     Tests that size set and get returns correct value
        /// </summary>
        [Fact]
        public void Size_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport viewport = default;
            Vector2F value = new Vector2F(3.0f, 4.0f);
            viewport.Size = value;
            Assert.Equal(value, viewport.Size);
        }

        /// <summary>
        ///     Tests that dpi scale set and get returns correct value
        /// </summary>
        [Fact]
        public void DpiScale_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport viewport = default;
            viewport.DpiScale = 1.5f;
            Assert.Equal(1.5f, viewport.DpiScale, 5);
        }
        /// <summary>
        ///     Tests that default work pos should be zero
        /// </summary>
        [Fact]
        public void DefaultWorkPos_ShouldBeZero()
        {
            ImGuiViewport viewport = default;
            Assert.Equal(default(Vector2F), viewport.WorkPos);
        }

        /// <summary>
        ///     Tests that work pos set and get returns correct value
        /// </summary>
        [Fact]
        public void WorkPos_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport viewport = default;
            Vector2F value = new Vector2F(5.0f, 6.0f);
            viewport.WorkPos = value;
            Assert.Equal(value, viewport.WorkPos);
        }

        /// <summary>
        ///     Tests that default work size should be zero
        /// </summary>
        [Fact]
        public void DefaultWorkSize_ShouldBeZero()
        {
            ImGuiViewport viewport = default;
            Assert.Equal(default(Vector2F), viewport.WorkSize);
        }

        /// <summary>
        ///     Tests that work size set and get returns correct value
        /// </summary>
        [Fact]
        public void WorkSize_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport viewport = default;
            Vector2F value = new Vector2F(7.0f, 8.0f);
            viewport.WorkSize = value;
            Assert.Equal(value, viewport.WorkSize);
        }

        /// <summary>
        ///     Tests that default parent viewport id should be zero
        /// </summary>
        [Fact]
        public void DefaultParentViewportId_ShouldBeZero()
        {
            ImGuiViewport viewport = default;
            Assert.Equal(0u, viewport.ParentViewportId);
        }

        /// <summary>
        ///     Tests that parent viewport id set and get returns correct value
        /// </summary>
        [Fact]
        public void ParentViewportId_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport viewport = default;
            viewport.ParentViewportId = 456u;
            Assert.Equal(456u, viewport.ParentViewportId);
        }

        /// <summary>
        ///     Tests that default draw data should be zero
        /// </summary>
        [Fact]
        public void DefaultDrawData_ShouldBeZero()
        {
            ImGuiViewport viewport = default;
            Assert.Equal(IntPtr.Zero, viewport.DrawData);
        }

        /// <summary>
        ///     Tests that draw data set and get returns correct value
        /// </summary>
        [Fact]
        public void DrawData_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport viewport = default;
            IntPtr value = new IntPtr(789);
            viewport.DrawData = value;
            Assert.Equal(value, viewport.DrawData);
        }

        /// <summary>
        ///     Tests that default renderer user data should be zero
        /// </summary>
        [Fact]
        public void DefaultRendererUserData_ShouldBeZero()
        {
            ImGuiViewport viewport = default;
            Assert.Equal(IntPtr.Zero, viewport.RendererUserData);
        }

        /// <summary>
        ///     Tests that renderer user data set and get returns correct value
        /// </summary>
        [Fact]
        public void RendererUserData_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport viewport = default;
            IntPtr value = new IntPtr(101112);
            viewport.RendererUserData = value;
            Assert.Equal(value, viewport.RendererUserData);
        }

        /// <summary>
        ///     Tests that default platform user data should be zero
        /// </summary>
        [Fact]
        public void DefaultPlatformUserData_ShouldBeZero()
        {
            ImGuiViewport viewport = default;
            Assert.Equal(IntPtr.Zero, viewport.PlatformUserData);
        }

        /// <summary>
        ///     Tests that platform user data set and get returns correct value
        /// </summary>
        [Fact]
        public void PlatformUserData_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport viewport = default;
            IntPtr value = new IntPtr(131415);
            viewport.PlatformUserData = value;
            Assert.Equal(value, viewport.PlatformUserData);
        }

        /// <summary>
        ///     Tests that default platform handle should be zero
        /// </summary>
        [Fact]
        public void DefaultPlatformHandle_ShouldBeZero()
        {
            ImGuiViewport viewport = default;
            Assert.Equal(IntPtr.Zero, viewport.PlatformHandle);
        }

        /// <summary>
        ///     Tests that platform handle set and get returns correct value
        /// </summary>
        [Fact]
        public void PlatformHandle_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport viewport = default;
            IntPtr value = new IntPtr(161718);
            viewport.PlatformHandle = value;
            Assert.Equal(value, viewport.PlatformHandle);
        }

        /// <summary>
        ///     Tests that default platform handle raw should be zero
        /// </summary>
        [Fact]
        public void DefaultPlatformHandleRaw_ShouldBeZero()
        {
            ImGuiViewport viewport = default;
            Assert.Equal(IntPtr.Zero, viewport.PlatformHandleRaw);
        }

        /// <summary>
        ///     Tests that platform handle raw set and get returns correct value
        /// </summary>
        [Fact]
        public void PlatformHandleRaw_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport viewport = default;
            IntPtr value = new IntPtr(192021);
            viewport.PlatformHandleRaw = value;
            Assert.Equal(value, viewport.PlatformHandleRaw);
        }

        /// <summary>
        ///     Tests that default platform window created should be zero
        /// </summary>
        [Fact]
        public void DefaultPlatformWindowCreated_ShouldBeZero()
        {
            ImGuiViewport viewport = default;
            Assert.Equal((byte)0, viewport.PlatformWindowCreated);
        }

        /// <summary>
        ///     Tests that platform window created set and get returns correct value
        /// </summary>
        [Fact]
        public void PlatformWindowCreated_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport viewport = default;
            viewport.PlatformWindowCreated = 1;
            Assert.Equal((byte)1, viewport.PlatformWindowCreated);
        }

        /// <summary>
        ///     Tests that default platform request move should be zero
        /// </summary>
        [Fact]
        public void DefaultPlatformRequestMove_ShouldBeZero()
        {
            ImGuiViewport viewport = default;
            Assert.Equal((byte)0, viewport.PlatformRequestMove);
        }

        /// <summary>
        ///     Tests that platform request move set and get returns correct value
        /// </summary>
        [Fact]
        public void PlatformRequestMove_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport viewport = default;
            viewport.PlatformRequestMove = 1;
            Assert.Equal((byte)1, viewport.PlatformRequestMove);
        }

        /// <summary>
        ///     Tests that default platform request resize should be zero
        /// </summary>
        [Fact]
        public void DefaultPlatformRequestResize_ShouldBeZero()
        {
            ImGuiViewport viewport = default;
            Assert.Equal((byte)0, viewport.PlatformRequestResize);
        }

        /// <summary>
        ///     Tests that platform request resize set and get returns correct value
        /// </summary>
        [Fact]
        public void PlatformRequestResize_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport viewport = default;
            viewport.PlatformRequestResize = 1;
            Assert.Equal((byte)1, viewport.PlatformRequestResize);
        }

        /// <summary>
        ///     Tests that default platform request close should be zero
        /// </summary>
        [Fact]
        public void DefaultPlatformRequestClose_ShouldBeZero()
        {
            ImGuiViewport viewport = default;
            Assert.Equal((byte)0, viewport.PlatformRequestClose);
        }

        /// <summary>
        ///     Tests that platform request close set and get returns correct value
        /// </summary>
        [Fact]
        public void PlatformRequestClose_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport viewport = default;
            viewport.PlatformRequestClose = 1;
            Assert.Equal((byte)1, viewport.PlatformRequestClose);
        }
    }
}
