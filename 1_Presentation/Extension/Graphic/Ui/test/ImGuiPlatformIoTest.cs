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

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui platform io test class
    /// </summary>
    public class ImGuiPlatformIoTest
    {
        /// <summary>
        ///     Tests that platform create window should be initialized
        /// </summary>
        [Fact]
        public void PlatformCreateWindow_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformCreateWindow);
        }

        /// <summary>
        ///     Tests that platform destroy window should be initialized
        /// </summary>
        [Fact]
        public void PlatformDestroyWindow_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformDestroyWindow);
        }

        /// <summary>
        ///     Tests that platform show window should be initialized
        /// </summary>
        [Fact]
        public void PlatformShowWindow_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformShowWindow);
        }

        /// <summary>
        ///     Tests that platform set window pos should be initialized
        /// </summary>
        [Fact]
        public void PlatformSetWindowPos_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformSetWindowPos);
        }

        /// <summary>
        ///     Tests that platform get window pos should be initialized
        /// </summary>
        [Fact]
        public void PlatformGetWindowPos_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformGetWindowPos);
        }

        /// <summary>
        ///     Tests that platform set window size should be initialized
        /// </summary>
        [Fact]
        public void PlatformSetWindowSize_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformSetWindowSize);
        }

        /// <summary>
        ///     Tests that platform get window size should be initialized
        /// </summary>
        [Fact]
        public void PlatformGetWindowSize_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformGetWindowSize);
        }

        /// <summary>
        ///     Tests that platform set window focus should be initialized
        /// </summary>
        [Fact]
        public void PlatformSetWindowFocus_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformSetWindowFocus);
        }

        /// <summary>
        ///     Tests that platform get window focus should be initialized
        /// </summary>
        [Fact]
        public void PlatformGetWindowFocus_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformGetWindowFocus);
        }

        /// <summary>
        ///     Tests that platform get window minimized should be initialized
        /// </summary>
        [Fact]
        public void PlatformGetWindowMinimized_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformGetWindowMinimized);
        }

        /// <summary>
        ///     Tests that platform set window title should be initialized
        /// </summary>
        [Fact]
        public void PlatformSetWindowTitle_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformSetWindowTitle);
        }

        /// <summary>
        ///     Tests that platform set window alpha should be initialized
        /// </summary>
        [Fact]
        public void PlatformSetWindowAlpha_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformSetWindowAlpha);
        }

        /// <summary>
        ///     Tests that platform update window should be initialized
        /// </summary>
        [Fact]
        public void PlatformUpdateWindow_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformUpdateWindow);
        }

        /// <summary>
        ///     Tests that platform render window should be initialized
        /// </summary>
        [Fact]
        public void PlatformRenderWindow_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformRenderWindow);
        }

        /// <summary>
        ///     Tests that platform swap buffers should be initialized
        /// </summary>
        [Fact]
        public void PlatformSwapBuffers_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformSwapBuffers);
        }

        /// <summary>
        ///     Tests that platform get window dpi scale should be initialized
        /// </summary>
        [Fact]
        public void PlatformGetWindowDpiScale_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformGetWindowDpiScale);
        }

        /// <summary>
        ///     Tests that platform on changed viewport should be initialized
        /// </summary>
        [Fact]
        public void PlatformOnChangedViewport_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformOnChangedViewport);
        }

        /// <summary>
        ///     Tests that platform create vk surface should be initialized
        /// </summary>
        [Fact]
        public void PlatformCreateVkSurface_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.PlatformCreateVkSurface);
        }

        /// <summary>
        ///     Tests that renderer create window should be initialized
        /// </summary>
        [Fact]
        public void RendererCreateWindow_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.RendererCreateWindow);
        }

        /// <summary>
        ///     Tests that renderer destroy window should be initialized
        /// </summary>
        [Fact]
        public void RendererDestroyWindow_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.RendererDestroyWindow);
        }

        /// <summary>
        ///     Tests that renderer set window size should be initialized
        /// </summary>
        [Fact]
        public void RendererSetWindowSize_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.RendererSetWindowSize);
        }

        /// <summary>
        ///     Tests that renderer render window should be initialized
        /// </summary>
        [Fact]
        public void RendererRenderWindow_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.RendererRenderWindow);
        }

        /// <summary>
        ///     Tests that renderer swap buffers should be initialized
        /// </summary>
        [Fact]
        public void RendererSwapBuffers_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(IntPtr.Zero, io.RendererSwapBuffers);
        }

        /// <summary>
        ///     Tests that monitors should be initialized
        /// </summary>
        [Fact]
        public void Monitors_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(default(ImVector), io.Monitors);
        }

        /// <summary>
        ///     Tests that viewports should be initialized
        /// </summary>
        [Fact]
        public void Viewports_ShouldBeInitialized()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            Assert.Equal(default(ImVector), io.Viewports);
        }

        /// <summary>
        ///     Tests that platform create window set and get returns correct value
        /// </summary>
        [Fact]
        public void PlatformCreateWindow_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            IntPtr value = new IntPtr(123);
            io.PlatformCreateWindow = value;
            Assert.Equal(value, io.PlatformCreateWindow);
        }

        /// <summary>
        ///     Tests that platform destroy window set and get returns correct value
        /// </summary>
        [Fact]
        public void PlatformDestroyWindow_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            IntPtr value = new IntPtr(456);
            io.PlatformDestroyWindow = value;
            Assert.Equal(value, io.PlatformDestroyWindow);
        }

        /// <summary>
        ///     Tests that platform show window set and get returns correct value
        /// </summary>
        [Fact]
        public void PlatformShowWindow_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            IntPtr value = new IntPtr(789);
            io.PlatformShowWindow = value;
            Assert.Equal(value, io.PlatformShowWindow);
        }

        /// <summary>
        ///     Tests that platform set window pos set and get returns correct value
        /// </summary>
        [Fact]
        public void PlatformSetWindowPos_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            IntPtr value = new IntPtr(101112);
            io.PlatformSetWindowPos = value;
            Assert.Equal(value, io.PlatformSetWindowPos);
        }

        /// <summary>
        ///     Tests that platform get window pos set and get returns correct value
        /// </summary>
        [Fact]
        public void PlatformGetWindowPos_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            IntPtr value = new IntPtr(131415);
            io.PlatformGetWindowPos = value;
            Assert.Equal(value, io.PlatformGetWindowPos);
        }

        /// <summary>
        ///     Tests that platform set window size set and get returns correct value
        /// </summary>
        [Fact]
        public void PlatformSetWindowSize_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            IntPtr value = new IntPtr(161718);
            io.PlatformSetWindowSize = value;
            Assert.Equal(value, io.PlatformSetWindowSize);
        }

        /// <summary>
        ///     Tests that platform get window size set and get returns correct value
        /// </summary>
        [Fact]
        public void PlatformGetWindowSize_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            IntPtr value = new IntPtr(192021);
            io.PlatformGetWindowSize = value;
            Assert.Equal(value, io.PlatformGetWindowSize);
        }

        /// <summary>
        ///     Tests that platform set window focus set and get returns correct value
        /// </summary>
        [Fact]
        public void PlatformSetWindowFocus_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            IntPtr value = new IntPtr(222324);
            io.PlatformSetWindowFocus = value;
            Assert.Equal(value, io.PlatformSetWindowFocus);
        }

        /// <summary>
        ///     Tests that platform get window focus set and get returns correct value
        /// </summary>
        [Fact]
        public void PlatformGetWindowFocus_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            IntPtr value = new IntPtr(252627);
            io.PlatformGetWindowFocus = value;
            Assert.Equal(value, io.PlatformGetWindowFocus);
        }

        /// <summary>
        ///     Tests that platform get window minimized set and get returns correct value
        /// </summary>
        [Fact]
        public void PlatformGetWindowMinimized_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            IntPtr value = new IntPtr(282930);
            io.PlatformGetWindowMinimized = value;
            Assert.Equal(value, io.PlatformGetWindowMinimized);
        }

        /// <summary>
        ///     Tests that platform set window title set and get returns correct value
        /// </summary>
        [Fact]
        public void PlatformSetWindowTitle_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            IntPtr value = new IntPtr(313233);
            io.PlatformSetWindowTitle = value;
            Assert.Equal(value, io.PlatformSetWindowTitle);
        }

        /// <summary>
        ///     Tests that platform set window alpha set and get returns correct value
        /// </summary>
        [Fact]
        public void PlatformSetWindowAlpha_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            IntPtr value = new IntPtr(343536);
            io.PlatformSetWindowAlpha = value;
            Assert.Equal(value, io.PlatformSetWindowAlpha);
        }

        /// <summary>
        ///     Tests that platform update window set and get returns correct value
        /// </summary>
        [Fact]
        public void PlatformUpdateWindow_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            IntPtr value = new IntPtr(373839);
            io.PlatformUpdateWindow = value;
            Assert.Equal(value, io.PlatformUpdateWindow);
        }

        /// <summary>
        ///     Tests that platform render window set and get returns correct value
        /// </summary>
        [Fact]
        public void PlatformRenderWindow_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            IntPtr value = new IntPtr(404142);
            io.PlatformRenderWindow = value;
            Assert.Equal(value, io.PlatformRenderWindow);
        }

        /// <summary>
        ///     Tests that platform swap buffers set and get returns correct value
        /// </summary>
        [Fact]
        public void PlatformSwapBuffers_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            IntPtr value = new IntPtr(434445);
            io.PlatformSwapBuffers = value;
            Assert.Equal(value, io.PlatformSwapBuffers);
        }

        /// <summary>
        ///     Tests that platform get window dpi scale set and get returns correct value
        /// </summary>
        [Fact]
        public void PlatformGetWindowDpiScale_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            IntPtr value = new IntPtr(464748);
            io.PlatformGetWindowDpiScale = value;
            Assert.Equal(value, io.PlatformGetWindowDpiScale);
        }

        /// <summary>
        ///     Tests that platform on changed viewport set and get returns correct value
        /// </summary>
        [Fact]
        public void PlatformOnChangedViewport_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            IntPtr value = new IntPtr(495051);
            io.PlatformOnChangedViewport = value;
            Assert.Equal(value, io.PlatformOnChangedViewport);
        }

        /// <summary>
        ///     Tests that platform create vk surface set and get returns correct value
        /// </summary>
        [Fact]
        public void PlatformCreateVkSurface_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            IntPtr value = new IntPtr(525354);
            io.PlatformCreateVkSurface = value;
            Assert.Equal(value, io.PlatformCreateVkSurface);
        }

        /// <summary>
        ///     Tests that renderer create window set and get returns correct value
        /// </summary>
        [Fact]
        public void RendererCreateWindow_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            IntPtr value = new IntPtr(555657);
            io.RendererCreateWindow = value;
            Assert.Equal(value, io.RendererCreateWindow);
        }

        /// <summary>
        ///     Tests that renderer destroy window set and get returns correct value
        /// </summary>
        [Fact]
        public void RendererDestroyWindow_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            IntPtr value = new IntPtr(585960);
            io.RendererDestroyWindow = value;
            Assert.Equal(value, io.RendererDestroyWindow);
        }

        /// <summary>
        ///     Tests that renderer set window size set and get returns correct value
        /// </summary>
        [Fact]
        public void RendererSetWindowSize_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            IntPtr value = new IntPtr(616263);
            io.RendererSetWindowSize = value;
            Assert.Equal(value, io.RendererSetWindowSize);
        }

        /// <summary>
        ///     Tests that renderer render window set and get returns correct value
        /// </summary>
        [Fact]
        public void RendererRenderWindow_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            IntPtr value = new IntPtr(646566);
            io.RendererRenderWindow = value;
            Assert.Equal(value, io.RendererRenderWindow);
        }

        /// <summary>
        ///     Tests that renderer swap buffers set and get returns correct value
        /// </summary>
        [Fact]
        public void RendererSwapBuffers_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            IntPtr value = new IntPtr(676869);
            io.RendererSwapBuffers = value;
            Assert.Equal(value, io.RendererSwapBuffers);
        }

        /// <summary>
        ///     Tests that monitors set and get returns correct value
        /// </summary>
        [Fact]
        public void Monitors_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            ImVector value = new ImVector();
            io.Monitors = value;
            Assert.Equal(value, io.Monitors);
        }

        /// <summary>
        ///     Tests that viewports set and get returns correct value
        /// </summary>
        [Fact]
        public void Viewports_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiPlatformIo io = new ImGuiPlatformIo();
            ImVector value = new ImVector();
            io.Viewports = value;
            Assert.Equal(value, io.Viewports);
        }
    }
}