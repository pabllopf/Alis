// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiPlatformIOTests.cs
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
    ///     The im gui platform io tests class
    /// </summary>
    public class ImGuiPlatformIOTests
    {
        /// <summary>
        ///     Tests that default values are zero
        /// </summary>
        [Fact]
        public void Default_ValuesAreZero()
        {
            ImGuiPlatformIo io = default;

            Assert.Equal(IntPtr.Zero, io.PlatformCreateWindow);
            Assert.Equal(IntPtr.Zero, io.PlatformDestroyWindow);
            Assert.Equal(IntPtr.Zero, io.PlatformShowWindow);
            Assert.Equal(IntPtr.Zero, io.PlatformSetWindowPos);
            Assert.Equal(IntPtr.Zero, io.PlatformGetWindowPos);
            Assert.Equal(IntPtr.Zero, io.PlatformSetWindowSize);
            Assert.Equal(IntPtr.Zero, io.PlatformGetWindowSize);
            Assert.Equal(IntPtr.Zero, io.PlatformSetWindowFocus);
            Assert.Equal(IntPtr.Zero, io.PlatformGetWindowFocus);
            Assert.Equal(IntPtr.Zero, io.PlatformGetWindowMinimized);
            Assert.Equal(IntPtr.Zero, io.PlatformSetWindowTitle);
            Assert.Equal(IntPtr.Zero, io.PlatformSetWindowAlpha);
            Assert.Equal(IntPtr.Zero, io.PlatformUpdateWindow);
            Assert.Equal(IntPtr.Zero, io.PlatformRenderWindow);
            Assert.Equal(IntPtr.Zero, io.PlatformSwapBuffers);
            Assert.Equal(IntPtr.Zero, io.PlatformGetWindowDpiScale);
            Assert.Equal(IntPtr.Zero, io.PlatformOnChangedViewport);
            Assert.Equal(IntPtr.Zero, io.PlatformCreateVkSurface);
            Assert.Equal(IntPtr.Zero, io.RendererCreateWindow);
            Assert.Equal(IntPtr.Zero, io.RendererDestroyWindow);
            Assert.Equal(IntPtr.Zero, io.RendererSetWindowSize);
            Assert.Equal(IntPtr.Zero, io.RendererRenderWindow);
            Assert.Equal(IntPtr.Zero, io.RendererSwapBuffers);
            Assert.Equal(0, io.Monitors.Size);
            Assert.Equal(0, io.Monitors.Capacity);
            Assert.Equal(IntPtr.Zero, io.Monitors.Data);
            Assert.Equal(0, io.Viewports.Size);
            Assert.Equal(0, io.Viewports.Capacity);
            Assert.Equal(IntPtr.Zero, io.Viewports.Data);
        }

        /// <summary>
        ///     Tests that platform create window round trips
        /// </summary>
        [Fact]
        public void PlatformCreateWindow_RoundTrip()
        {
            ImGuiPlatformIo io = default;
            IntPtr expected = new IntPtr(1);
            io.PlatformCreateWindow = expected;
            Assert.Equal(expected, io.PlatformCreateWindow);
        }

        /// <summary>
        ///     Tests that platform destroy window round trips
        /// </summary>
        [Fact]
        public void PlatformDestroyWindow_RoundTrip()
        {
            ImGuiPlatformIo io = default;
            IntPtr expected = new IntPtr(2);
            io.PlatformDestroyWindow = expected;
            Assert.Equal(expected, io.PlatformDestroyWindow);
        }

        /// <summary>
        ///     Tests that platform show window round trips
        /// </summary>
        [Fact]
        public void PlatformShowWindow_RoundTrip()
        {
            ImGuiPlatformIo io = default;
            IntPtr expected = new IntPtr(3);
            io.PlatformShowWindow = expected;
            Assert.Equal(expected, io.PlatformShowWindow);
        }

        /// <summary>
        ///     Tests that platform set window pos round trips
        /// </summary>
        [Fact]
        public void PlatformSetWindowPos_RoundTrip()
        {
            ImGuiPlatformIo io = default;
            IntPtr expected = new IntPtr(4);
            io.PlatformSetWindowPos = expected;
            Assert.Equal(expected, io.PlatformSetWindowPos);
        }

        /// <summary>
        ///     Tests that platform get window pos round trips
        /// </summary>
        [Fact]
        public void PlatformGetWindowPos_RoundTrip()
        {
            ImGuiPlatformIo io = default;
            IntPtr expected = new IntPtr(5);
            io.PlatformGetWindowPos = expected;
            Assert.Equal(expected, io.PlatformGetWindowPos);
        }

        /// <summary>
        ///     Tests that platform set window size round trips
        /// </summary>
        [Fact]
        public void PlatformSetWindowSize_RoundTrip()
        {
            ImGuiPlatformIo io = default;
            IntPtr expected = new IntPtr(6);
            io.PlatformSetWindowSize = expected;
            Assert.Equal(expected, io.PlatformSetWindowSize);
        }

        /// <summary>
        ///     Tests that platform get window size round trips
        /// </summary>
        [Fact]
        public void PlatformGetWindowSize_RoundTrip()
        {
            ImGuiPlatformIo io = default;
            IntPtr expected = new IntPtr(7);
            io.PlatformGetWindowSize = expected;
            Assert.Equal(expected, io.PlatformGetWindowSize);
        }

        /// <summary>
        ///     Tests that platform set window focus round trips
        /// </summary>
        [Fact]
        public void PlatformSetWindowFocus_RoundTrip()
        {
            ImGuiPlatformIo io = default;
            IntPtr expected = new IntPtr(8);
            io.PlatformSetWindowFocus = expected;
            Assert.Equal(expected, io.PlatformSetWindowFocus);
        }

        /// <summary>
        ///     Tests that platform get window focus round trips
        /// </summary>
        [Fact]
        public void PlatformGetWindowFocus_RoundTrip()
        {
            ImGuiPlatformIo io = default;
            IntPtr expected = new IntPtr(9);
            io.PlatformGetWindowFocus = expected;
            Assert.Equal(expected, io.PlatformGetWindowFocus);
        }

        /// <summary>
        ///     Tests that platform get window minimized round trips
        /// </summary>
        [Fact]
        public void PlatformGetWindowMinimized_RoundTrip()
        {
            ImGuiPlatformIo io = default;
            IntPtr expected = new IntPtr(10);
            io.PlatformGetWindowMinimized = expected;
            Assert.Equal(expected, io.PlatformGetWindowMinimized);
        }

        /// <summary>
        ///     Tests that platform set window title round trips
        /// </summary>
        [Fact]
        public void PlatformSetWindowTitle_RoundTrip()
        {
            ImGuiPlatformIo io = default;
            IntPtr expected = new IntPtr(11);
            io.PlatformSetWindowTitle = expected;
            Assert.Equal(expected, io.PlatformSetWindowTitle);
        }

        /// <summary>
        ///     Tests that platform set window alpha round trips
        /// </summary>
        [Fact]
        public void PlatformSetWindowAlpha_RoundTrip()
        {
            ImGuiPlatformIo io = default;
            IntPtr expected = new IntPtr(12);
            io.PlatformSetWindowAlpha = expected;
            Assert.Equal(expected, io.PlatformSetWindowAlpha);
        }

        /// <summary>
        ///     Tests that platform update window round trips
        /// </summary>
        [Fact]
        public void PlatformUpdateWindow_RoundTrip()
        {
            ImGuiPlatformIo io = default;
            IntPtr expected = new IntPtr(13);
            io.PlatformUpdateWindow = expected;
            Assert.Equal(expected, io.PlatformUpdateWindow);
        }

        /// <summary>
        ///     Tests that platform render window round trips
        /// </summary>
        [Fact]
        public void PlatformRenderWindow_RoundTrip()
        {
            ImGuiPlatformIo io = default;
            IntPtr expected = new IntPtr(14);
            io.PlatformRenderWindow = expected;
            Assert.Equal(expected, io.PlatformRenderWindow);
        }

        /// <summary>
        ///     Tests that platform swap buffers round trips
        /// </summary>
        [Fact]
        public void PlatformSwapBuffers_RoundTrip()
        {
            ImGuiPlatformIo io = default;
            IntPtr expected = new IntPtr(15);
            io.PlatformSwapBuffers = expected;
            Assert.Equal(expected, io.PlatformSwapBuffers);
        }

        /// <summary>
        ///     Tests that platform get window dpi scale round trips
        /// </summary>
        [Fact]
        public void PlatformGetWindowDpiScale_RoundTrip()
        {
            ImGuiPlatformIo io = default;
            IntPtr expected = new IntPtr(16);
            io.PlatformGetWindowDpiScale = expected;
            Assert.Equal(expected, io.PlatformGetWindowDpiScale);
        }

        /// <summary>
        ///     Tests that platform on changed viewport round trips
        /// </summary>
        [Fact]
        public void PlatformOnChangedViewport_RoundTrip()
        {
            ImGuiPlatformIo io = default;
            IntPtr expected = new IntPtr(17);
            io.PlatformOnChangedViewport = expected;
            Assert.Equal(expected, io.PlatformOnChangedViewport);
        }

        /// <summary>
        ///     Tests that platform create vk surface round trips
        /// </summary>
        [Fact]
        public void PlatformCreateVkSurface_RoundTrip()
        {
            ImGuiPlatformIo io = default;
            IntPtr expected = new IntPtr(18);
            io.PlatformCreateVkSurface = expected;
            Assert.Equal(expected, io.PlatformCreateVkSurface);
        }

        /// <summary>
        ///     Tests that renderer create window round trips
        /// </summary>
        [Fact]
        public void RendererCreateWindow_RoundTrip()
        {
            ImGuiPlatformIo io = default;
            IntPtr expected = new IntPtr(19);
            io.RendererCreateWindow = expected;
            Assert.Equal(expected, io.RendererCreateWindow);
        }

        /// <summary>
        ///     Tests that renderer destroy window round trips
        /// </summary>
        [Fact]
        public void RendererDestroyWindow_RoundTrip()
        {
            ImGuiPlatformIo io = default;
            IntPtr expected = new IntPtr(20);
            io.RendererDestroyWindow = expected;
            Assert.Equal(expected, io.RendererDestroyWindow);
        }

        /// <summary>
        ///     Tests that renderer set window size round trips
        /// </summary>
        [Fact]
        public void RendererSetWindowSize_RoundTrip()
        {
            ImGuiPlatformIo io = default;
            IntPtr expected = new IntPtr(21);
            io.RendererSetWindowSize = expected;
            Assert.Equal(expected, io.RendererSetWindowSize);
        }

        /// <summary>
        ///     Tests that renderer render window round trips
        /// </summary>
        [Fact]
        public void RendererRenderWindow_RoundTrip()
        {
            ImGuiPlatformIo io = default;
            IntPtr expected = new IntPtr(22);
            io.RendererRenderWindow = expected;
            Assert.Equal(expected, io.RendererRenderWindow);
        }

        /// <summary>
        ///     Tests that renderer swap buffers round trips
        /// </summary>
        [Fact]
        public void RendererSwapBuffers_RoundTrip()
        {
            ImGuiPlatformIo io = default;
            IntPtr expected = new IntPtr(23);
            io.RendererSwapBuffers = expected;
            Assert.Equal(expected, io.RendererSwapBuffers);
        }

        /// <summary>
        ///     Tests that monitors round trips
        /// </summary>
        [Fact]
        public void Monitors_RoundTrip()
        {
            ImGuiPlatformIo io = default;
            ImVector expected = new ImVector(1, 2, new IntPtr(100));
            io.Monitors = expected;
            Assert.Equal(expected.Size, io.Monitors.Size);
            Assert.Equal(expected.Capacity, io.Monitors.Capacity);
            Assert.Equal(expected.Data, io.Monitors.Data);
        }

        /// <summary>
        ///     Tests that viewports round trips
        /// </summary>
        [Fact]
        public void Viewports_RoundTrip()
        {
            ImGuiPlatformIo io = default;
            ImVector expected = new ImVector(3, 4, new IntPtr(200));
            io.Viewports = expected;
            Assert.Equal(expected.Size, io.Viewports.Size);
            Assert.Equal(expected.Capacity, io.Viewports.Capacity);
            Assert.Equal(expected.Data, io.Viewports.Data);
        }
    }
}
