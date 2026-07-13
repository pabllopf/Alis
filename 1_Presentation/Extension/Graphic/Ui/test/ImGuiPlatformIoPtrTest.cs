// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiPlatformIoPtrTest.cs
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
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui platform io ptr test class
    /// </summary>
    public class ImGuiPlatformIoPtrTest
    {
        /// <summary>
        ///     The native ptr should set and get correctly
        /// </summary>
        [RequireCImguiSystemFact]
        public void NativePtr_Should_SetAndGetCorrectly()
        {
            ImGuiPlatformIoPtr platformIoPtr = new ImGuiPlatformIoPtr(new IntPtr(1));
            Assert.Equal(new IntPtr(1), platformIoPtr.NativePtr);
        }

        /// <summary>
        ///     The implicit operator should set and get correctly
        /// </summary>
        [RequireCImguiSystemFact]
        public void ImplicitOperator_Should_SetAndGetCorrectly()
        {
            ImGuiPlatformIoPtr platformIoPtr = new ImGuiPlatformIoPtr(new IntPtr(1));
            IntPtr nativePtr = platformIoPtr;
            Assert.Equal(new IntPtr(1), nativePtr);
        }

        /// <summary>
        ///     Tests that native ptr should set and get correctly
        /// </summary>
        [RequireCImguiSystemFact]
        public void NativePtr_Should_SetAndGetCorrectly_v2()
        {
            IntPtr ptr = new IntPtr(123);
            ImGuiPlatformIoPtr platformIoPtr = new ImGuiPlatformIoPtr(ptr);
            Assert.Equal(ptr, platformIoPtr.NativePtr);
        }

        /// <summary>
        ///     Tests that implicit conversion to int ptr should work correctly
        /// </summary>
        [RequireCImguiSystemFact]
        public void ImplicitConversionToIntPtr_Should_WorkCorrectly()
        {
            IntPtr ptr = new IntPtr(123);
            ImGuiPlatformIoPtr platformIoPtr = new ImGuiPlatformIoPtr(ptr);
            IntPtr result = platformIoPtr;
            Assert.Equal(ptr, result);
        }

        /// <summary>
        ///     Tests that implicit conversion from int ptr should work correctly
        /// </summary>
        [RequireCImguiSystemFact]
        public void ImplicitConversionFromIntPtr_Should_WorkCorrectly()
        {
            IntPtr ptr = new IntPtr(123);
            ImGuiPlatformIoPtr platformIoPtr = ptr;
            Assert.Equal(ptr, platformIoPtr.NativePtr);
        }

        /// <summary>
        ///     Tests that platform create window should get correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformCreateWindow_Should_GetCorrectValue()
        {
            IntPtr expected = new IntPtr(42);
            ImGuiPlatformIo io = new ImGuiPlatformIo { PlatformCreateWindow = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImGuiPlatformIo>());
            try
            {
                Marshal.StructureToPtr(io, nativePtr, false);
                ImGuiPlatformIoPtr ptr = new ImGuiPlatformIoPtr(nativePtr);
                Assert.Equal(expected, ptr.PlatformCreateWindow);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that platform destroy window should get correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformDestroyWindow_Should_GetCorrectValue()
        {
            IntPtr expected = new IntPtr(43);
            ImGuiPlatformIo io = new ImGuiPlatformIo { PlatformDestroyWindow = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImGuiPlatformIo>());
            try
            {
                Marshal.StructureToPtr(io, nativePtr, false);
                ImGuiPlatformIoPtr ptr = new ImGuiPlatformIoPtr(nativePtr);
                Assert.Equal(expected, ptr.PlatformDestroyWindow);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that platform show window should get correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformShowWindow_Should_GetCorrectValue()
        {
            IntPtr expected = new IntPtr(44);
            ImGuiPlatformIo io = new ImGuiPlatformIo { PlatformShowWindow = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImGuiPlatformIo>());
            try
            {
                Marshal.StructureToPtr(io, nativePtr, false);
                ImGuiPlatformIoPtr ptr = new ImGuiPlatformIoPtr(nativePtr);
                Assert.Equal(expected, ptr.PlatformShowWindow);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that platform set window pos should get correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformSetWindowPos_Should_GetCorrectValue()
        {
            IntPtr expected = new IntPtr(45);
            ImGuiPlatformIo io = new ImGuiPlatformIo { PlatformSetWindowPos = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImGuiPlatformIo>());
            try
            {
                Marshal.StructureToPtr(io, nativePtr, false);
                ImGuiPlatformIoPtr ptr = new ImGuiPlatformIoPtr(nativePtr);
                Assert.Equal(expected, ptr.PlatformSetWindowPos);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that platform get window pos should get correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformGetWindowPos_Should_GetCorrectValue()
        {
            IntPtr expected = new IntPtr(46);
            ImGuiPlatformIo io = new ImGuiPlatformIo { PlatformGetWindowPos = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImGuiPlatformIo>());
            try
            {
                Marshal.StructureToPtr(io, nativePtr, false);
                ImGuiPlatformIoPtr ptr = new ImGuiPlatformIoPtr(nativePtr);
                Assert.Equal(expected, ptr.PlatformGetWindowPos);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that platform set window size should get correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformSetWindowSize_Should_GetCorrectValue()
        {
            IntPtr expected = new IntPtr(47);
            ImGuiPlatformIo io = new ImGuiPlatformIo { PlatformSetWindowSize = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImGuiPlatformIo>());
            try
            {
                Marshal.StructureToPtr(io, nativePtr, false);
                ImGuiPlatformIoPtr ptr = new ImGuiPlatformIoPtr(nativePtr);
                Assert.Equal(expected, ptr.PlatformSetWindowSize);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that platform get window size should get correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformGetWindowSize_Should_GetCorrectValue()
        {
            IntPtr expected = new IntPtr(48);
            ImGuiPlatformIo io = new ImGuiPlatformIo { PlatformGetWindowSize = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImGuiPlatformIo>());
            try
            {
                Marshal.StructureToPtr(io, nativePtr, false);
                ImGuiPlatformIoPtr ptr = new ImGuiPlatformIoPtr(nativePtr);
                Assert.Equal(expected, ptr.PlatformGetWindowSize);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that platform set window focus should get correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformSetWindowFocus_Should_GetCorrectValue()
        {
            IntPtr expected = new IntPtr(49);
            ImGuiPlatformIo io = new ImGuiPlatformIo { PlatformSetWindowFocus = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImGuiPlatformIo>());
            try
            {
                Marshal.StructureToPtr(io, nativePtr, false);
                ImGuiPlatformIoPtr ptr = new ImGuiPlatformIoPtr(nativePtr);
                Assert.Equal(expected, ptr.PlatformSetWindowFocus);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that platform get window focus should get correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformGetWindowFocus_Should_GetCorrectValue()
        {
            IntPtr expected = new IntPtr(50);
            ImGuiPlatformIo io = new ImGuiPlatformIo { PlatformGetWindowFocus = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImGuiPlatformIo>());
            try
            {
                Marshal.StructureToPtr(io, nativePtr, false);
                ImGuiPlatformIoPtr ptr = new ImGuiPlatformIoPtr(nativePtr);
                Assert.Equal(expected, ptr.PlatformGetWindowFocus);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that platform get window minimized should get correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformGetWindowMinimized_Should_GetCorrectValue()
        {
            IntPtr expected = new IntPtr(51);
            ImGuiPlatformIo io = new ImGuiPlatformIo { PlatformGetWindowMinimized = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImGuiPlatformIo>());
            try
            {
                Marshal.StructureToPtr(io, nativePtr, false);
                ImGuiPlatformIoPtr ptr = new ImGuiPlatformIoPtr(nativePtr);
                Assert.Equal(expected, ptr.PlatformGetWindowMinimized);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that platform set window title should get correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformSetWindowTitle_Should_GetCorrectValue()
        {
            IntPtr expected = new IntPtr(52);
            ImGuiPlatformIo io = new ImGuiPlatformIo { PlatformSetWindowTitle = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImGuiPlatformIo>());
            try
            {
                Marshal.StructureToPtr(io, nativePtr, false);
                ImGuiPlatformIoPtr ptr = new ImGuiPlatformIoPtr(nativePtr);
                Assert.Equal(expected, ptr.PlatformSetWindowTitle);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that platform set window alpha should get correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformSetWindowAlpha_Should_GetCorrectValue()
        {
            IntPtr expected = new IntPtr(53);
            ImGuiPlatformIo io = new ImGuiPlatformIo { PlatformSetWindowAlpha = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImGuiPlatformIo>());
            try
            {
                Marshal.StructureToPtr(io, nativePtr, false);
                ImGuiPlatformIoPtr ptr = new ImGuiPlatformIoPtr(nativePtr);
                Assert.Equal(expected, ptr.PlatformSetWindowAlpha);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that platform update window should get correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformUpdateWindow_Should_GetCorrectValue()
        {
            IntPtr expected = new IntPtr(54);
            ImGuiPlatformIo io = new ImGuiPlatformIo { PlatformUpdateWindow = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImGuiPlatformIo>());
            try
            {
                Marshal.StructureToPtr(io, nativePtr, false);
                ImGuiPlatformIoPtr ptr = new ImGuiPlatformIoPtr(nativePtr);
                Assert.Equal(expected, ptr.PlatformUpdateWindow);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that platform render window should get correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformRenderWindow_Should_GetCorrectValue()
        {
            IntPtr expected = new IntPtr(55);
            ImGuiPlatformIo io = new ImGuiPlatformIo { PlatformRenderWindow = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImGuiPlatformIo>());
            try
            {
                Marshal.StructureToPtr(io, nativePtr, false);
                ImGuiPlatformIoPtr ptr = new ImGuiPlatformIoPtr(nativePtr);
                Assert.Equal(expected, ptr.PlatformRenderWindow);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that platform swap buffers should get correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformSwapBuffers_Should_GetCorrectValue()
        {
            IntPtr expected = new IntPtr(56);
            ImGuiPlatformIo io = new ImGuiPlatformIo { PlatformSwapBuffers = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImGuiPlatformIo>());
            try
            {
                Marshal.StructureToPtr(io, nativePtr, false);
                ImGuiPlatformIoPtr ptr = new ImGuiPlatformIoPtr(nativePtr);
                Assert.Equal(expected, ptr.PlatformSwapBuffers);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that platform get window dpi scale should get correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformGetWindowDpiScale_Should_GetCorrectValue()
        {
            IntPtr expected = new IntPtr(57);
            ImGuiPlatformIo io = new ImGuiPlatformIo { PlatformGetWindowDpiScale = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImGuiPlatformIo>());
            try
            {
                Marshal.StructureToPtr(io, nativePtr, false);
                ImGuiPlatformIoPtr ptr = new ImGuiPlatformIoPtr(nativePtr);
                Assert.Equal(expected, ptr.PlatformGetWindowDpiScale);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that platform on changed viewport should get correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformOnChangedViewport_Should_GetCorrectValue()
        {
            IntPtr expected = new IntPtr(58);
            ImGuiPlatformIo io = new ImGuiPlatformIo { PlatformOnChangedViewport = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImGuiPlatformIo>());
            try
            {
                Marshal.StructureToPtr(io, nativePtr, false);
                ImGuiPlatformIoPtr ptr = new ImGuiPlatformIoPtr(nativePtr);
                Assert.Equal(expected, ptr.PlatformOnChangedViewport);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that platform create vk surface should get correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformCreateVkSurface_Should_GetCorrectValue()
        {
            IntPtr expected = new IntPtr(59);
            ImGuiPlatformIo io = new ImGuiPlatformIo { PlatformCreateVkSurface = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImGuiPlatformIo>());
            try
            {
                Marshal.StructureToPtr(io, nativePtr, false);
                ImGuiPlatformIoPtr ptr = new ImGuiPlatformIoPtr(nativePtr);
                Assert.Equal(expected, ptr.PlatformCreateVkSurface);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that renderer create window should get correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void RendererCreateWindow_Should_GetCorrectValue()
        {
            IntPtr expected = new IntPtr(60);
            ImGuiPlatformIo io = new ImGuiPlatformIo { RendererCreateWindow = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImGuiPlatformIo>());
            try
            {
                Marshal.StructureToPtr(io, nativePtr, false);
                ImGuiPlatformIoPtr ptr = new ImGuiPlatformIoPtr(nativePtr);
                Assert.Equal(expected, ptr.RendererCreateWindow);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that renderer destroy window should get correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void RendererDestroyWindow_Should_GetCorrectValue()
        {
            IntPtr expected = new IntPtr(61);
            ImGuiPlatformIo io = new ImGuiPlatformIo { RendererDestroyWindow = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImGuiPlatformIo>());
            try
            {
                Marshal.StructureToPtr(io, nativePtr, false);
                ImGuiPlatformIoPtr ptr = new ImGuiPlatformIoPtr(nativePtr);
                Assert.Equal(expected, ptr.RendererDestroyWindow);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that renderer set window size should get correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void RendererSetWindowSize_Should_GetCorrectValue()
        {
            IntPtr expected = new IntPtr(62);
            ImGuiPlatformIo io = new ImGuiPlatformIo { RendererSetWindowSize = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImGuiPlatformIo>());
            try
            {
                Marshal.StructureToPtr(io, nativePtr, false);
                ImGuiPlatformIoPtr ptr = new ImGuiPlatformIoPtr(nativePtr);
                Assert.Equal(expected, ptr.RendererSetWindowSize);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that renderer render window should get correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void RendererRenderWindow_Should_GetCorrectValue()
        {
            IntPtr expected = new IntPtr(63);
            ImGuiPlatformIo io = new ImGuiPlatformIo { RendererRenderWindow = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImGuiPlatformIo>());
            try
            {
                Marshal.StructureToPtr(io, nativePtr, false);
                ImGuiPlatformIoPtr ptr = new ImGuiPlatformIoPtr(nativePtr);
                Assert.Equal(expected, ptr.RendererRenderWindow);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that renderer swap buffers should get correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void RendererSwapBuffers_Should_GetCorrectValue()
        {
            IntPtr expected = new IntPtr(64);
            ImGuiPlatformIo io = new ImGuiPlatformIo { RendererSwapBuffers = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImGuiPlatformIo>());
            try
            {
                Marshal.StructureToPtr(io, nativePtr, false);
                ImGuiPlatformIoPtr ptr = new ImGuiPlatformIoPtr(nativePtr);
                Assert.Equal(expected, ptr.RendererSwapBuffers);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that monitors should get correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void Monitors_Should_GetCorrectValue()
        {
            ImVector expected = new ImVector(3, 5, new IntPtr(789));
            ImGuiPlatformIo plat = new ImGuiPlatformIo { Monitors = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImGuiPlatformIo>());
            try
            {
                Marshal.StructureToPtr(plat, nativePtr, false);
                ImGuiPlatformIoPtr ptr = new ImGuiPlatformIoPtr(nativePtr);
                ImVectorG<ImGuiPlatformMonitor> result = ptr.Monitors;
                Assert.Equal(expected.Size, result.Size);
                Assert.Equal(expected.Capacity, result.Capacity);
                Assert.Equal(expected.Data, result.Data);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that viewports should get correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void Viewports_Should_GetCorrectValue()
        {
            ImVector expected = new ImVector(1, 2, new IntPtr(111));
            ImGuiPlatformIo plat = new ImGuiPlatformIo { Viewports = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImGuiPlatformIo>());
            try
            {
                Marshal.StructureToPtr(plat, nativePtr, false);
                ImGuiPlatformIoPtr ptr = new ImGuiPlatformIoPtr(nativePtr);
                ImVectorG<ImGuiViewportPtr> result = ptr.Viewports;
                Assert.Equal(expected.Size, result.Size);
                Assert.Equal(expected.Capacity, result.Capacity);
                Assert.Equal(expected.Data, result.Data);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that platform create window throws null reference exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformCreateWindow_ThrowsNullReferenceException()
        {
            ImGuiPlatformIoPtr ioPtr = new ImGuiPlatformIoPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                IntPtr _ = ioPtr.PlatformCreateWindow;
            });
        }

        /// <summary>
        ///     Tests that platform destroy window throws null reference exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformDestroyWindow_ThrowsNullReferenceException()
        {
            ImGuiPlatformIoPtr ioPtr = new ImGuiPlatformIoPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                IntPtr _ = ioPtr.PlatformDestroyWindow;
            });
        }

        /// <summary>
        ///     Tests that platform show window throws null reference exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformShowWindow_ThrowsNullReferenceException()
        {
            ImGuiPlatformIoPtr ioPtr = new ImGuiPlatformIoPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                IntPtr _ = ioPtr.PlatformShowWindow;
            });
        }

        /// <summary>
        ///     Tests that platform set window pos throws null reference exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformSetWindowPos_ThrowsNullReferenceException()
        {
            ImGuiPlatformIoPtr ioPtr = new ImGuiPlatformIoPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                IntPtr _ = ioPtr.PlatformSetWindowPos;
            });
        }

        /// <summary>
        ///     Tests that platform get window pos throws null reference exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformGetWindowPos_ThrowsNullReferenceException()
        {
            ImGuiPlatformIoPtr ioPtr = new ImGuiPlatformIoPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                IntPtr _ = ioPtr.PlatformGetWindowPos;
            });
        }

        /// <summary>
        ///     Tests that platform set window size throws null reference exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformSetWindowSize_ThrowsNullReferenceException()
        {
            ImGuiPlatformIoPtr ioPtr = new ImGuiPlatformIoPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                IntPtr _ = ioPtr.PlatformSetWindowSize;
            });
        }

        /// <summary>
        ///     Tests that platform get window size throws null reference exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformGetWindowSize_ThrowsNullReferenceException()
        {
            ImGuiPlatformIoPtr ioPtr = new ImGuiPlatformIoPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                IntPtr _ = ioPtr.PlatformGetWindowSize;
            });
        }

        /// <summary>
        ///     Tests that platform set window focus throws null reference exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformSetWindowFocus_ThrowsNullReferenceException()
        {
            ImGuiPlatformIoPtr ioPtr = new ImGuiPlatformIoPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                IntPtr _ = ioPtr.PlatformSetWindowFocus;
            });
        }

        /// <summary>
        ///     Tests that platform get window focus throws null reference exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformGetWindowFocus_ThrowsNullReferenceException()
        {
            ImGuiPlatformIoPtr ioPtr = new ImGuiPlatformIoPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                IntPtr _ = ioPtr.PlatformGetWindowFocus;
            });
        }

        /// <summary>
        ///     Tests that platform get window minimized throws null reference exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformGetWindowMinimized_ThrowsNullReferenceException()
        {
            ImGuiPlatformIoPtr ioPtr = new ImGuiPlatformIoPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                IntPtr _ = ioPtr.PlatformGetWindowMinimized;
            });
        }

        /// <summary>
        ///     Tests that platform set window title throws null reference exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformSetWindowTitle_ThrowsNullReferenceException()
        {
            ImGuiPlatformIoPtr ioPtr = new ImGuiPlatformIoPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                IntPtr _ = ioPtr.PlatformSetWindowTitle;
            });
        }

        /// <summary>
        ///     Tests that platform set window alpha throws null reference exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformSetWindowAlpha_ThrowsNullReferenceException()
        {
            ImGuiPlatformIoPtr ioPtr = new ImGuiPlatformIoPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                IntPtr _ = ioPtr.PlatformSetWindowAlpha;
            });
        }

        /// <summary>
        ///     Tests that platform update window throws null reference exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformUpdateWindow_ThrowsNullReferenceException()
        {
            ImGuiPlatformIoPtr ioPtr = new ImGuiPlatformIoPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                IntPtr _ = ioPtr.PlatformUpdateWindow;
            });
        }

        /// <summary>
        ///     Tests that platform render window throws null reference exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformRenderWindow_ThrowsNullReferenceException()
        {
            ImGuiPlatformIoPtr ioPtr = new ImGuiPlatformIoPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                IntPtr _ = ioPtr.PlatformRenderWindow;
            });
        }

        /// <summary>
        ///     Tests that platform swap buffers throws null reference exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformSwapBuffers_ThrowsNullReferenceException()
        {
            ImGuiPlatformIoPtr ioPtr = new ImGuiPlatformIoPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                IntPtr _ = ioPtr.PlatformSwapBuffers;
            });
        }

        /// <summary>
        ///     Tests that platform get window dpi scale throws null reference exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformGetWindowDpiScale_ThrowsNullReferenceException()
        {
            ImGuiPlatformIoPtr ioPtr = new ImGuiPlatformIoPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                IntPtr _ = ioPtr.PlatformGetWindowDpiScale;
            });
        }

        /// <summary>
        ///     Tests that platform on changed viewport throws null reference exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformOnChangedViewport_ThrowsNullReferenceException()
        {
            ImGuiPlatformIoPtr ioPtr = new ImGuiPlatformIoPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                IntPtr _ = ioPtr.PlatformOnChangedViewport;
            });
        }

        /// <summary>
        ///     Tests that platform create vk surface throws null reference exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlatformCreateVkSurface_ThrowsNullReferenceException()
        {
            ImGuiPlatformIoPtr ioPtr = new ImGuiPlatformIoPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                IntPtr _ = ioPtr.PlatformCreateVkSurface;
            });
        }

        /// <summary>
        ///     Tests that renderer create window throws null reference exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void RendererCreateWindow_ThrowsNullReferenceException()
        {
            ImGuiPlatformIoPtr ioPtr = new ImGuiPlatformIoPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                IntPtr _ = ioPtr.RendererCreateWindow;
            });
        }

        /// <summary>
        ///     Tests that renderer destroy window throws null reference exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void RendererDestroyWindow_ThrowsNullReferenceException()
        {
            ImGuiPlatformIoPtr ioPtr = new ImGuiPlatformIoPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                IntPtr _ = ioPtr.RendererDestroyWindow;
            });
        }

        /// <summary>
        ///     Tests that renderer set window size throws null reference exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void RendererSetWindowSize_ThrowsNullReferenceException()
        {
            ImGuiPlatformIoPtr ioPtr = new ImGuiPlatformIoPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                IntPtr _ = ioPtr.RendererSetWindowSize;
            });
        }

        /// <summary>
        ///     Tests that renderer render window throws null reference exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void RendererRenderWindow_ThrowsNullReferenceException()
        {
            ImGuiPlatformIoPtr ioPtr = new ImGuiPlatformIoPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                IntPtr _ = ioPtr.RendererRenderWindow;
            });
        }

        /// <summary>
        ///     Tests that renderer swap buffers throws null reference exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void RendererSwapBuffers_ThrowsNullReferenceException()
        {
            ImGuiPlatformIoPtr ioPtr = new ImGuiPlatformIoPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                IntPtr _ = ioPtr.RendererSwapBuffers;
            });
        }

        /// <summary>
        ///     Tests that monitors throws null reference exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void Monitors_ThrowsNullReferenceException()
        {
            ImGuiPlatformIoPtr ioPtr = new ImGuiPlatformIoPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                ImVectorG<ImGuiPlatformMonitor> _ = ioPtr.Monitors;
            });
        }

        /// <summary>
        ///     Tests that viewports throws null reference exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void Viewports_ThrowsNullReferenceException()
        {
            ImGuiPlatformIoPtr ioPtr = new ImGuiPlatformIoPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                ImVectorG<ImGuiViewportPtr> _ = ioPtr.Viewports;
            });
        }
    }
}