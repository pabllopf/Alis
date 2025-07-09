// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiPlatformIOPtr.cs
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

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui platform io ptr
    /// </summary>
    public readonly struct ImGuiPlatformIoPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public IntPtr NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiPlatformIoPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiPlatformIoPtr(IntPtr nativePtr) => NativePtr = nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator IntPtr(ImGuiPlatformIoPtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiPlatformIoPtr(IntPtr nativePtr) => new ImGuiPlatformIoPtr(nativePtr);


        /// <summary>
        ///     Gets the value of the platform createwindow
        /// </summary>
        public IntPtr PlatformCreateWindow => Marshal.PtrToStructure<ImGuiPlatformIo>(NativePtr).PlatformCreateWindow;

        /// <summary>
        ///     Gets the value of the platform destroywindow
        /// </summary>
        public IntPtr PlatformDestroyWindow => Marshal.PtrToStructure<ImGuiPlatformIo>(NativePtr).PlatformDestroyWindow;

        /// <summary>
        ///     Gets the value of the platform showwindow
        /// </summary>
        public IntPtr PlatformShowWindow => Marshal.PtrToStructure<ImGuiPlatformIo>(NativePtr).PlatformShowWindow;

        /// <summary>
        ///     Gets the value of the platform setwindowpos
        /// </summary>
        public IntPtr PlatformSetWindowPos => Marshal.PtrToStructure<ImGuiPlatformIo>(NativePtr).PlatformSetWindowPos;

        /// <summary>
        ///     Gets the value of the platform getwindowpos
        /// </summary>
        public IntPtr PlatformGetWindowPos => Marshal.PtrToStructure<ImGuiPlatformIo>(NativePtr).PlatformGetWindowPos;

        /// <summary>
        ///     Gets the value of the platform setwindowsize
        /// </summary>
        public IntPtr PlatformSetWindowSize => Marshal.PtrToStructure<ImGuiPlatformIo>(NativePtr).PlatformSetWindowSize;

        /// <summary>
        ///     Gets the value of the platform getwindowsize
        /// </summary>
        public IntPtr PlatformGetWindowSize => Marshal.PtrToStructure<ImGuiPlatformIo>(NativePtr).PlatformGetWindowSize;

        /// <summary>
        ///     Gets the value of the platform setwindowfocus
        /// </summary>
        public IntPtr PlatformSetWindowFocus => Marshal.PtrToStructure<ImGuiPlatformIo>(NativePtr).PlatformSetWindowFocus;

        /// <summary>
        ///     Gets the value of the platform getwindowfocus
        /// </summary>
        public IntPtr PlatformGetWindowFocus => Marshal.PtrToStructure<ImGuiPlatformIo>(NativePtr).PlatformGetWindowFocus;

        /// <summary>
        ///     Gets the value of the platform getwindowminimized
        /// </summary>
        public IntPtr PlatformGetWindowMinimized => Marshal.PtrToStructure<ImGuiPlatformIo>(NativePtr).PlatformGetWindowMinimized;

        /// <summary>
        ///     Gets the value of the platform setwindowtitle
        /// </summary>
        public IntPtr PlatformSetWindowTitle => Marshal.PtrToStructure<ImGuiPlatformIo>(NativePtr).PlatformSetWindowTitle;

        /// <summary>
        ///     Gets the value of the platform setwindowalpha
        /// </summary>
        public IntPtr PlatformSetWindowAlpha => Marshal.PtrToStructure<ImGuiPlatformIo>(NativePtr).PlatformSetWindowAlpha;

        /// <summary>
        ///     Gets the value of the platform updatewindow
        /// </summary>
        public IntPtr PlatformUpdateWindow => Marshal.PtrToStructure<ImGuiPlatformIo>(NativePtr).PlatformUpdateWindow;

        /// <summary>
        ///     Gets the value of the platform renderwindow
        /// </summary>
        public IntPtr PlatformRenderWindow => Marshal.PtrToStructure<ImGuiPlatformIo>(NativePtr).PlatformRenderWindow;

        /// <summary>
        ///     Gets the value of the platform swapbuffers
        /// </summary>
        public IntPtr PlatformSwapBuffers => Marshal.PtrToStructure<ImGuiPlatformIo>(NativePtr).PlatformSwapBuffers;

        /// <summary>
        ///     Gets the value of the platform getwindowdpiscale
        /// </summary>
        public IntPtr PlatformGetWindowDpiScale => Marshal.PtrToStructure<ImGuiPlatformIo>(NativePtr).PlatformGetWindowDpiScale;

        /// <summary>
        ///     Gets the value of the platform onchangedviewport
        /// </summary>
        public IntPtr PlatformOnChangedViewport => Marshal.PtrToStructure<ImGuiPlatformIo>(NativePtr).PlatformOnChangedViewport;

        /// <summary>
        ///     Gets the value of the platform createvksurface
        /// </summary>
        public IntPtr PlatformCreateVkSurface => Marshal.PtrToStructure<ImGuiPlatformIo>(NativePtr).PlatformCreateVkSurface;

        /// <summary>
        ///     Gets the value of the renderer createwindow
        /// </summary>
        public IntPtr RendererCreateWindow => Marshal.PtrToStructure<ImGuiPlatformIo>(NativePtr).RendererCreateWindow;

        /// <summary>
        ///     Gets the value of the renderer destroywindow
        /// </summary>
        public IntPtr RendererDestroyWindow => Marshal.PtrToStructure<ImGuiPlatformIo>(NativePtr).RendererDestroyWindow;

        /// <summary>
        ///     Gets the value of the renderer setwindowsize
        /// </summary>
        public IntPtr RendererSetWindowSize => Marshal.PtrToStructure<ImGuiPlatformIo>(NativePtr).RendererSetWindowSize;

        /// <summary>
        ///     Gets the value of the renderer renderwindow
        /// </summary>
        public IntPtr RendererRenderWindow => Marshal.PtrToStructure<ImGuiPlatformIo>(NativePtr).RendererRenderWindow;

        /// <summary>
        ///     Gets the value of the renderer swapbuffers
        /// </summary>
        public IntPtr RendererSwapBuffers => Marshal.PtrToStructure<ImGuiPlatformIo>(NativePtr).RendererSwapBuffers;

        /// <summary>
        ///     Gets the value of the monitors
        /// </summary>
        public ImVectorG<ImGuiPlatformMonitor> Monitors => new ImVectorG<ImGuiPlatformMonitor>(Marshal.PtrToStructure<ImGuiPlatformIo>(NativePtr).Monitors);

        /// <summary>
        ///     Gets the value of the viewports
        /// </summary>
        public ImVectorG<ImGuiViewportPtr> Viewports => new ImVectorG<ImGuiViewportPtr>(Marshal.PtrToStructure<ImGuiPlatformIo>(NativePtr).Viewports);
    }
}