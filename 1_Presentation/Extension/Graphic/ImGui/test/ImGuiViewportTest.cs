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
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test
{
    /// <summary>
    /// The im gui viewport test class
    /// </summary>
    public class ImGuiViewportTest
    {
        /// <summary>
        /// Tests that id should be initialized
        /// </summary>
        [Fact]
        public void Id_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal(0u, viewport.Id);
        }

        /// <summary>
        /// Tests that flags should be initialized
        /// </summary>
        [Fact]
        public void Flags_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal(default(ImGuiViewportFlags), viewport.Flags);
        }

        /// <summary>
        /// Tests that pos should be initialized
        /// </summary>
        [Fact]
        public void Pos_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal(default(Vector2), viewport.Pos);
        }

        /// <summary>
        /// Tests that size should be initialized
        /// </summary>
        [Fact]
        public void Size_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal(default(Vector2), viewport.Size);
        }

        /// <summary>
        /// Tests that work pos should be initialized
        /// </summary>
        [Fact]
        public void WorkPos_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal(default(Vector2), viewport.WorkPos);
        }

        /// <summary>
        /// Tests that work size should be initialized
        /// </summary>
        [Fact]
        public void WorkSize_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal(default(Vector2), viewport.WorkSize);
        }

        /// <summary>
        /// Tests that dpi scale should be initialized
        /// </summary>
        [Fact]
        public void DpiScale_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal(0f, viewport.DpiScale);
        }

        /// <summary>
        /// Tests that parent viewport id should be initialized
        /// </summary>
        [Fact]
        public void ParentViewportId_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal(0u, viewport.ParentViewportId);
        }

        /// <summary>
        /// Tests that draw data should be initialized
        /// </summary>
        [Fact]
        public void DrawData_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal(IntPtr.Zero, viewport.DrawData);
        }

        /// <summary>
        /// Tests that renderer user data should be initialized
        /// </summary>
        [Fact]
        public void RendererUserData_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal(IntPtr.Zero, viewport.RendererUserData);
        }

        /// <summary>
        /// Tests that platform user data should be initialized
        /// </summary>
        [Fact]
        public void PlatformUserData_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal(IntPtr.Zero, viewport.PlatformUserData);
        }

        /// <summary>
        /// Tests that platform handle should be initialized
        /// </summary>
        [Fact]
        public void PlatformHandle_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal(IntPtr.Zero, viewport.PlatformHandle);
        }

        /// <summary>
        /// Tests that platform handle raw should be initialized
        /// </summary>
        [Fact]
        public void PlatformHandleRaw_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal(IntPtr.Zero, viewport.PlatformHandleRaw);
        }

        /// <summary>
        /// Tests that platform window created should be initialized
        /// </summary>
        [Fact]
        public void PlatformWindowCreated_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal((byte) 0, viewport.PlatformWindowCreated);
        }

        /// <summary>
        /// Tests that platform request move should be initialized
        /// </summary>
        [Fact]
        public void PlatformRequestMove_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal((byte) 0, viewport.PlatformRequestMove);
        }

        /// <summary>
        /// Tests that platform request resize should be initialized
        /// </summary>
        [Fact]
        public void PlatformRequestResize_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal((byte) 0, viewport.PlatformRequestResize);
        }

        /// <summary>
        /// Tests that platform request close should be initialized
        /// </summary>
        [Fact]
        public void PlatformRequestClose_ShouldBeInitialized()
        {
            ImGuiViewport viewport = new ImGuiViewport();
            Assert.Equal((byte) 0, viewport.PlatformRequestClose);
        }
    }
}