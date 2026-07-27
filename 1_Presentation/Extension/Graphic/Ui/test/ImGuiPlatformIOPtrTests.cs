// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiPlatformIOPtrTests.cs
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
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui platform io ptr tests class
    /// </summary>
    public class ImGuiPlatformIOPtrTests : IDisposable
    {
        /// <summary>
        ///     The native ptr
        /// </summary>
        private readonly IntPtr nativePtr;

        /// <summary>
        ///     The ptr
        /// </summary>
        private readonly ImGuiPlatformIoPtr ptr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiPlatformIOPtrTests" /> class
        /// </summary>
        public ImGuiPlatformIOPtrTests()
        {
            nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImGuiPlatformIo>());

            ImGuiPlatformIo io = new ImGuiPlatformIo
            {
                PlatformCreateWindow = new IntPtr(1),
                PlatformDestroyWindow = new IntPtr(2),
                PlatformShowWindow = new IntPtr(3),
                PlatformSetWindowPos = new IntPtr(4),
                PlatformGetWindowPos = new IntPtr(5),
                PlatformSetWindowSize = new IntPtr(6),
                PlatformGetWindowSize = new IntPtr(7),
                PlatformSetWindowFocus = new IntPtr(8),
                PlatformGetWindowFocus = new IntPtr(9),
                PlatformGetWindowMinimized = new IntPtr(10),
                PlatformSetWindowTitle = new IntPtr(11),
                PlatformSetWindowAlpha = new IntPtr(12),
                PlatformUpdateWindow = new IntPtr(13),
                PlatformRenderWindow = new IntPtr(14),
                PlatformSwapBuffers = new IntPtr(15),
                PlatformGetWindowDpiScale = new IntPtr(16),
                PlatformOnChangedViewport = new IntPtr(17),
                PlatformCreateVkSurface = new IntPtr(18),
                RendererCreateWindow = new IntPtr(19),
                RendererDestroyWindow = new IntPtr(20),
                RendererSetWindowSize = new IntPtr(21),
                RendererRenderWindow = new IntPtr(22),
                RendererSwapBuffers = new IntPtr(23),
                Monitors = new ImVector(1, 1, new IntPtr(100)),
                Viewports = new ImVector(2, 2, new IntPtr(200))
            };

            Marshal.StructureToPtr(io, nativePtr, false);
            ptr = new ImGuiPlatformIoPtr(nativePtr);
        }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose() => Marshal.FreeHGlobal(nativePtr);

        /// <summary>
        ///     Tests that platform create window returns expected value
        /// </summary>
        [Fact]
        public void PlatformCreateWindow_ShouldReturnExpectedValue() => Assert.Equal(new IntPtr(1), ptr.PlatformCreateWindow);

        /// <summary>
        ///     Tests that platform destroy window returns expected value
        /// </summary>
        [Fact]
        public void PlatformDestroyWindow_ShouldReturnExpectedValue() => Assert.Equal(new IntPtr(2), ptr.PlatformDestroyWindow);

        /// <summary>
        ///     Tests that platform show window returns expected value
        /// </summary>
        [Fact]
        public void PlatformShowWindow_ShouldReturnExpectedValue() => Assert.Equal(new IntPtr(3), ptr.PlatformShowWindow);

        /// <summary>
        ///     Tests that platform set window pos returns expected value
        /// </summary>
        [Fact]
        public void PlatformSetWindowPos_ShouldReturnExpectedValue() => Assert.Equal(new IntPtr(4), ptr.PlatformSetWindowPos);

        /// <summary>
        ///     Tests that platform get window pos returns expected value
        /// </summary>
        [Fact]
        public void PlatformGetWindowPos_ShouldReturnExpectedValue() => Assert.Equal(new IntPtr(5), ptr.PlatformGetWindowPos);

        /// <summary>
        ///     Tests that platform set window size returns expected value
        /// </summary>
        [Fact]
        public void PlatformSetWindowSize_ShouldReturnExpectedValue() => Assert.Equal(new IntPtr(6), ptr.PlatformSetWindowSize);

        /// <summary>
        ///     Tests that platform get window size returns expected value
        /// </summary>
        [Fact]
        public void PlatformGetWindowSize_ShouldReturnExpectedValue() => Assert.Equal(new IntPtr(7), ptr.PlatformGetWindowSize);

        /// <summary>
        ///     Tests that platform set window focus returns expected value
        /// </summary>
        [Fact]
        public void PlatformSetWindowFocus_ShouldReturnExpectedValue() => Assert.Equal(new IntPtr(8), ptr.PlatformSetWindowFocus);

        /// <summary>
        ///     Tests that platform get window focus returns expected value
        /// </summary>
        [Fact]
        public void PlatformGetWindowFocus_ShouldReturnExpectedValue() => Assert.Equal(new IntPtr(9), ptr.PlatformGetWindowFocus);

        /// <summary>
        ///     Tests that platform get window minimized returns expected value
        /// </summary>
        [Fact]
        public void PlatformGetWindowMinimized_ShouldReturnExpectedValue() => Assert.Equal(new IntPtr(10), ptr.PlatformGetWindowMinimized);

        /// <summary>
        ///     Tests that platform set window title returns expected value
        /// </summary>
        [Fact]
        public void PlatformSetWindowTitle_ShouldReturnExpectedValue() => Assert.Equal(new IntPtr(11), ptr.PlatformSetWindowTitle);

        /// <summary>
        ///     Tests that platform set window alpha returns expected value
        /// </summary>
        [Fact]
        public void PlatformSetWindowAlpha_ShouldReturnExpectedValue() => Assert.Equal(new IntPtr(12), ptr.PlatformSetWindowAlpha);

        /// <summary>
        ///     Tests that platform update window returns expected value
        /// </summary>
        [Fact]
        public void PlatformUpdateWindow_ShouldReturnExpectedValue() => Assert.Equal(new IntPtr(13), ptr.PlatformUpdateWindow);

        /// <summary>
        ///     Tests that platform render window returns expected value
        /// </summary>
        [Fact]
        public void PlatformRenderWindow_ShouldReturnExpectedValue() => Assert.Equal(new IntPtr(14), ptr.PlatformRenderWindow);

        /// <summary>
        ///     Tests that platform swap buffers returns expected value
        /// </summary>
        [Fact]
        public void PlatformSwapBuffers_ShouldReturnExpectedValue() => Assert.Equal(new IntPtr(15), ptr.PlatformSwapBuffers);

        /// <summary>
        ///     Tests that platform get window dpi scale returns expected value
        /// </summary>
        [Fact]
        public void PlatformGetWindowDpiScale_ShouldReturnExpectedValue() => Assert.Equal(new IntPtr(16), ptr.PlatformGetWindowDpiScale);

        /// <summary>
        ///     Tests that platform on changed viewport returns expected value
        /// </summary>
        [Fact]
        public void PlatformOnChangedViewport_ShouldReturnExpectedValue() => Assert.Equal(new IntPtr(17), ptr.PlatformOnChangedViewport);

        /// <summary>
        ///     Tests that platform create vk surface returns expected value
        /// </summary>
        [Fact]
        public void PlatformCreateVkSurface_ShouldReturnExpectedValue() => Assert.Equal(new IntPtr(18), ptr.PlatformCreateVkSurface);

        /// <summary>
        ///     Tests that renderer create window returns expected value
        /// </summary>
        [Fact]
        public void RendererCreateWindow_ShouldReturnExpectedValue() => Assert.Equal(new IntPtr(19), ptr.RendererCreateWindow);

        /// <summary>
        ///     Tests that renderer destroy window returns expected value
        /// </summary>
        [Fact]
        public void RendererDestroyWindow_ShouldReturnExpectedValue() => Assert.Equal(new IntPtr(20), ptr.RendererDestroyWindow);

        /// <summary>
        ///     Tests that renderer set window size returns expected value
        /// </summary>
        [Fact]
        public void RendererSetWindowSize_ShouldReturnExpectedValue() => Assert.Equal(new IntPtr(21), ptr.RendererSetWindowSize);

        /// <summary>
        ///     Tests that renderer render window returns expected value
        /// </summary>
        [Fact]
        public void RendererRenderWindow_ShouldReturnExpectedValue() => Assert.Equal(new IntPtr(22), ptr.RendererRenderWindow);

        /// <summary>
        ///     Tests that renderer swap buffers returns expected value
        /// </summary>
        [Fact]
        public void RendererSwapBuffers_ShouldReturnExpectedValue() => Assert.Equal(new IntPtr(23), ptr.RendererSwapBuffers);

        /// <summary>
        ///     Tests that monitors returns expected value
        /// </summary>
        [Fact]
        public void Monitors_ShouldReturnExpectedValue()
        {
            ImVectorG<ImGuiPlatformMonitor> monitors = ptr.Monitors;

            Assert.Equal(1, monitors.Size);
            Assert.Equal(1, monitors.Capacity);
            Assert.Equal(new IntPtr(100), monitors.Data);
        }

        /// <summary>
        ///     Tests that viewports returns expected value
        /// </summary>
        [Fact]
        public void Viewports_ShouldReturnExpectedValue()
        {
            ImVectorG<ImGuiViewportPtr> viewports = ptr.Viewports;

            Assert.Equal(2, viewports.Size);
            Assert.Equal(2, viewports.Capacity);
            Assert.Equal(new IntPtr(200), viewports.Data);
        }
    }
}
