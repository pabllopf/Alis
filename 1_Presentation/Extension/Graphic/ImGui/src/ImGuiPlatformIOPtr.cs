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
using Alis.Extension.Graphic.ImGui.Utils;

namespace Alis.Extension.Graphic.ImGui
{
    /// <summary>
    ///     The im gui platform io ptr
    /// </summary>
    public readonly unsafe struct ImGuiPlatformIoPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImGuiPlatformIo* NativePtr { get; }
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiPlatformIoPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiPlatformIoPtr(ImGuiPlatformIo* nativePtr) => NativePtr = nativePtr;
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiPlatformIoPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiPlatformIoPtr(IntPtr nativePtr) => NativePtr = (ImGuiPlatformIo*) nativePtr;
        
        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiPlatformIoPtr(ImGuiPlatformIo* nativePtr) => new ImGuiPlatformIoPtr(nativePtr);
        
        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiPlatformIo*(ImGuiPlatformIoPtr wrappedPtr) => wrappedPtr.NativePtr;
        
        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiPlatformIoPtr(IntPtr nativePtr) => new ImGuiPlatformIoPtr(nativePtr);
        
        
        /// <summary>
        ///     Gets the value of the platform createwindow
        /// </summary>
        public ref IntPtr PlatformCreateWindow => ref Unsafe.AsRef<IntPtr>(&NativePtr->PlatformCreateWindow);
        
        /// <summary>
        ///     Gets the value of the platform destroywindow
        /// </summary>
        public ref IntPtr PlatformDestroyWindow => ref Unsafe.AsRef<IntPtr>(&NativePtr->PlatformDestroyWindow);
        
        /// <summary>
        ///     Gets the value of the platform showwindow
        /// </summary>
        public ref IntPtr PlatformShowWindow => ref Unsafe.AsRef<IntPtr>(&NativePtr->PlatformShowWindow);
        
        /// <summary>
        ///     Gets the value of the platform setwindowpos
        /// </summary>
        public ref IntPtr PlatformSetWindowPos => ref Unsafe.AsRef<IntPtr>(&NativePtr->PlatformSetWindowPos);
        
        /// <summary>
        ///     Gets the value of the platform getwindowpos
        /// </summary>
        public ref IntPtr PlatformGetWindowPos => ref Unsafe.AsRef<IntPtr>(&NativePtr->PlatformGetWindowPos);
        
        /// <summary>
        ///     Gets the value of the platform setwindowsize
        /// </summary>
        public ref IntPtr PlatformSetWindowSize => ref Unsafe.AsRef<IntPtr>(&NativePtr->PlatformSetWindowSize);
        
        /// <summary>
        ///     Gets the value of the platform getwindowsize
        /// </summary>
        public ref IntPtr PlatformGetWindowSize => ref Unsafe.AsRef<IntPtr>(&NativePtr->PlatformGetWindowSize);
        
        /// <summary>
        ///     Gets the value of the platform setwindowfocus
        /// </summary>
        public ref IntPtr PlatformSetWindowFocus => ref Unsafe.AsRef<IntPtr>(&NativePtr->PlatformSetWindowFocus);
        
        /// <summary>
        ///     Gets the value of the platform getwindowfocus
        /// </summary>
        public ref IntPtr PlatformGetWindowFocus => ref Unsafe.AsRef<IntPtr>(&NativePtr->PlatformGetWindowFocus);
        
        /// <summary>
        ///     Gets the value of the platform getwindowminimized
        /// </summary>
        public ref IntPtr PlatformGetWindowMinimized => ref Unsafe.AsRef<IntPtr>(&NativePtr->PlatformGetWindowMinimized);
        
        /// <summary>
        ///     Gets the value of the platform setwindowtitle
        /// </summary>
        public ref IntPtr PlatformSetWindowTitle => ref Unsafe.AsRef<IntPtr>(&NativePtr->PlatformSetWindowTitle);
        
        /// <summary>
        ///     Gets the value of the platform setwindowalpha
        /// </summary>
        public ref IntPtr PlatformSetWindowAlpha => ref Unsafe.AsRef<IntPtr>(&NativePtr->PlatformSetWindowAlpha);
        
        /// <summary>
        ///     Gets the value of the platform updatewindow
        /// </summary>
        public ref IntPtr PlatformUpdateWindow => ref Unsafe.AsRef<IntPtr>(&NativePtr->PlatformUpdateWindow);
        
        /// <summary>
        ///     Gets the value of the platform renderwindow
        /// </summary>
        public ref IntPtr PlatformRenderWindow => ref Unsafe.AsRef<IntPtr>(&NativePtr->PlatformRenderWindow);
        
        /// <summary>
        ///     Gets the value of the platform swapbuffers
        /// </summary>
        public ref IntPtr PlatformSwapBuffers => ref Unsafe.AsRef<IntPtr>(&NativePtr->PlatformSwapBuffers);
        
        /// <summary>
        ///     Gets the value of the platform getwindowdpiscale
        /// </summary>
        public ref IntPtr PlatformGetWindowDpiScale => ref Unsafe.AsRef<IntPtr>(&NativePtr->PlatformGetWindowDpiScale);
        
        /// <summary>
        ///     Gets the value of the platform onchangedviewport
        /// </summary>
        public ref IntPtr PlatformOnChangedViewport => ref Unsafe.AsRef<IntPtr>(&NativePtr->PlatformOnChangedViewport);
        
        /// <summary>
        ///     Gets the value of the platform createvksurface
        /// </summary>
        public ref IntPtr PlatformCreateVkSurface => ref Unsafe.AsRef<IntPtr>(&NativePtr->PlatformCreateVkSurface);
        
        /// <summary>
        ///     Gets the value of the renderer createwindow
        /// </summary>
        public ref IntPtr RendererCreateWindow => ref Unsafe.AsRef<IntPtr>(&NativePtr->RendererCreateWindow);
        
        /// <summary>
        ///     Gets the value of the renderer destroywindow
        /// </summary>
        public ref IntPtr RendererDestroyWindow => ref Unsafe.AsRef<IntPtr>(&NativePtr->RendererDestroyWindow);
        
        /// <summary>
        ///     Gets the value of the renderer setwindowsize
        /// </summary>
        public ref IntPtr RendererSetWindowSize => ref Unsafe.AsRef<IntPtr>(&NativePtr->RendererSetWindowSize);
        
        /// <summary>
        ///     Gets the value of the renderer renderwindow
        /// </summary>
        public ref IntPtr RendererRenderWindow => ref Unsafe.AsRef<IntPtr>(&NativePtr->RendererRenderWindow);
        
        /// <summary>
        ///     Gets the value of the renderer swapbuffers
        /// </summary>
        public ref IntPtr RendererSwapBuffers => ref Unsafe.AsRef<IntPtr>(&NativePtr->RendererSwapBuffers);
        
        /// <summary>
        ///     Gets the value of the monitors
        /// </summary>
        public ImVectorG<ImGuiPlatformMonitor> Monitors => new ImVectorG<ImGuiPlatformMonitor>(NativePtr->Monitors);
        
        /// <summary>
        ///     Gets the value of the viewports
        /// </summary>
        public ImVectorG<ImGuiViewportPtr> Viewports => new ImVectorG<ImGuiViewportPtr>(NativePtr->Viewports);
        
        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImGuiPlatformIO_destroy(NativePtr);
        }
    }
}