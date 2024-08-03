// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiPlatformIoTest.cs
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

namespace Alis.Extension.Graphic.ImGui.Test
{
    /// <summary>
    /// The im gui platform io test class
    /// </summary>
    public class ImGuiPlatformIoTest
    {
        /// <summary>
        /// Tests that platform create window should be initialized
        /// </summary>
        [Fact]
        public void PlatformCreateWindow_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformCreateWindow);
        }

        /// <summary>
        /// Tests that platform destroy window should be initialized
        /// </summary>
        [Fact]
        public void PlatformDestroyWindow_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformDestroyWindow);
        }

        /// <summary>
        /// Tests that platform show window should be initialized
        /// </summary>
        [Fact]
        public void PlatformShowWindow_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformShowWindow);
        }

        /// <summary>
        /// Tests that platform set window pos should be initialized
        /// </summary>
        [Fact]
        public void PlatformSetWindowPos_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformSetWindowPos);
        }

        /// <summary>
        /// Tests that platform get window pos should be initialized
        /// </summary>
        [Fact]
        public void PlatformGetWindowPos_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformGetWindowPos);
        }

        /// <summary>
        /// Tests that platform set window size should be initialized
        /// </summary>
        [Fact]
        public void PlatformSetWindowSize_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformSetWindowSize);
        }

        /// <summary>
        /// Tests that platform get window size should be initialized
        /// </summary>
        [Fact]
        public void PlatformGetWindowSize_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformGetWindowSize);
        }

        /// <summary>
        /// Tests that platform set window focus should be initialized
        /// </summary>
        [Fact]
        public void PlatformSetWindowFocus_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformSetWindowFocus);
        }

        /// <summary>
        /// Tests that platform get window focus should be initialized
        /// </summary>
        [Fact]
        public void PlatformGetWindowFocus_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformGetWindowFocus);
        }

        /// <summary>
        /// Tests that platform get window minimized should be initialized
        /// </summary>
        [Fact]
        public void PlatformGetWindowMinimized_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformGetWindowMinimized);
        }

        /// <summary>
        /// Tests that platform set window title should be initialized
        /// </summary>
        [Fact]
        public void PlatformSetWindowTitle_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformSetWindowTitle);
        }

        /// <summary>
        /// Tests that platform set window alpha should be initialized
        /// </summary>
        [Fact]
        public void PlatformSetWindowAlpha_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformSetWindowAlpha);
        }

        /// <summary>
        /// Tests that platform update window should be initialized
        /// </summary>
        [Fact]
        public void PlatformUpdateWindow_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformUpdateWindow);
        }

        /// <summary>
        /// Tests that platform render window should be initialized
        /// </summary>
        [Fact]
        public void PlatformRenderWindow_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformRenderWindow);
        }

        /// <summary>
        /// Tests that platform swap buffers should be initialized
        /// </summary>
        [Fact]
        public void PlatformSwapBuffers_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformSwapBuffers);
        }

        /// <summary>
        /// Tests that platform get window dpi scale should be initialized
        /// </summary>
        [Fact]
        public void PlatformGetWindowDpiScale_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformGetWindowDpiScale);
        }

        /// <summary>
        /// Tests that platform on changed viewport should be initialized
        /// </summary>
        [Fact]
        public void PlatformOnChangedViewport_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformOnChangedViewport);
        }

        /// <summary>
        /// Tests that platform create vk surface should be initialized
        /// </summary>
        [Fact]
        public void PlatformCreateVkSurface_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformCreateVkSurface);
        }

        /// <summary>
        /// Tests that renderer create window should be initialized
        /// </summary>
        [Fact]
        public void RendererCreateWindow_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.RendererCreateWindow);
        }

        /// <summary>
        /// Tests that renderer destroy window should be initialized
        /// </summary>
        [Fact]
        public void RendererDestroyWindow_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.RendererDestroyWindow);
        }

        /// <summary>
        /// Tests that renderer set window size should be initialized
        /// </summary>
        [Fact]
        public void RendererSetWindowSize_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.RendererSetWindowSize);
        }

        /// <summary>
        /// Tests that renderer render window should be initialized
        /// </summary>
        [Fact]
        public void RendererRenderWindow_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.RendererRenderWindow);
        }

        /// <summary>
        /// Tests that renderer swap buffers should be initialized
        /// </summary>
        [Fact]
        public void RendererSwapBuffers_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.RendererSwapBuffers);
        }

        /// <summary>
        /// Tests that monitors should be initialized
        /// </summary>
        [Fact]
        public void Monitors_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(default(ImVector), io.Monitors);
        }

        /// <summary>
        /// Tests that viewports should be initialized
        /// </summary>
        [Fact]
        public void Viewports_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(default(ImVector), io.Viewports);
        }
    }
}