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

namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    ///     The im gui platform io ptr
    /// </summary>
    public unsafe struct ImGuiPlatformIOPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImGuiPlatformIO* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiPlatformIOPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiPlatformIOPtr(ImGuiPlatformIO* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiPlatformIOPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiPlatformIOPtr(IntPtr nativePtr) => NativePtr = (ImGuiPlatformIO*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiPlatformIOPtr(ImGuiPlatformIO* nativePtr) => new ImGuiPlatformIOPtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiPlatformIO*(ImGuiPlatformIOPtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiPlatformIOPtr(IntPtr nativePtr) => new ImGuiPlatformIOPtr(nativePtr);

        /// <summary>
        ///     Gets the value of the platform createwindow
        /// </summary>
        public ref IntPtr Platform_CreateWindow => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_CreateWindow);

        /// <summary>
        ///     Gets the value of the platform destroywindow
        /// </summary>
        public ref IntPtr Platform_DestroyWindow => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_DestroyWindow);

        /// <summary>
        ///     Gets the value of the platform showwindow
        /// </summary>
        public ref IntPtr Platform_ShowWindow => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_ShowWindow);

        /// <summary>
        ///     Gets the value of the platform setwindowpos
        /// </summary>
        public ref IntPtr Platform_SetWindowPos => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_SetWindowPos);

        /// <summary>
        ///     Gets the value of the platform getwindowpos
        /// </summary>
        public ref IntPtr Platform_GetWindowPos => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_GetWindowPos);

        /// <summary>
        ///     Gets the value of the platform setwindowsize
        /// </summary>
        public ref IntPtr Platform_SetWindowSize => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_SetWindowSize);

        /// <summary>
        ///     Gets the value of the platform getwindowsize
        /// </summary>
        public ref IntPtr Platform_GetWindowSize => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_GetWindowSize);

        /// <summary>
        ///     Gets the value of the platform setwindowfocus
        /// </summary>
        public ref IntPtr Platform_SetWindowFocus => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_SetWindowFocus);

        /// <summary>
        ///     Gets the value of the platform getwindowfocus
        /// </summary>
        public ref IntPtr Platform_GetWindowFocus => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_GetWindowFocus);

        /// <summary>
        ///     Gets the value of the platform getwindowminimized
        /// </summary>
        public ref IntPtr Platform_GetWindowMinimized => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_GetWindowMinimized);

        /// <summary>
        ///     Gets the value of the platform setwindowtitle
        /// </summary>
        public ref IntPtr Platform_SetWindowTitle => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_SetWindowTitle);

        /// <summary>
        ///     Gets the value of the platform setwindowalpha
        /// </summary>
        public ref IntPtr Platform_SetWindowAlpha => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_SetWindowAlpha);

        /// <summary>
        ///     Gets the value of the platform updatewindow
        /// </summary>
        public ref IntPtr Platform_UpdateWindow => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_UpdateWindow);

        /// <summary>
        ///     Gets the value of the platform renderwindow
        /// </summary>
        public ref IntPtr Platform_RenderWindow => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_RenderWindow);

        /// <summary>
        ///     Gets the value of the platform swapbuffers
        /// </summary>
        public ref IntPtr Platform_SwapBuffers => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_SwapBuffers);

        /// <summary>
        ///     Gets the value of the platform getwindowdpiscale
        /// </summary>
        public ref IntPtr Platform_GetWindowDpiScale => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_GetWindowDpiScale);

        /// <summary>
        ///     Gets the value of the platform onchangedviewport
        /// </summary>
        public ref IntPtr Platform_OnChangedViewport => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_OnChangedViewport);

        /// <summary>
        ///     Gets the value of the platform createvksurface
        /// </summary>
        public ref IntPtr Platform_CreateVkSurface => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_CreateVkSurface);

        /// <summary>
        ///     Gets the value of the renderer createwindow
        /// </summary>
        public ref IntPtr Renderer_CreateWindow => ref Unsafe.AsRef<IntPtr>(&NativePtr->Renderer_CreateWindow);

        /// <summary>
        ///     Gets the value of the renderer destroywindow
        /// </summary>
        public ref IntPtr Renderer_DestroyWindow => ref Unsafe.AsRef<IntPtr>(&NativePtr->Renderer_DestroyWindow);

        /// <summary>
        ///     Gets the value of the renderer setwindowsize
        /// </summary>
        public ref IntPtr Renderer_SetWindowSize => ref Unsafe.AsRef<IntPtr>(&NativePtr->Renderer_SetWindowSize);

        /// <summary>
        ///     Gets the value of the renderer renderwindow
        /// </summary>
        public ref IntPtr Renderer_RenderWindow => ref Unsafe.AsRef<IntPtr>(&NativePtr->Renderer_RenderWindow);

        /// <summary>
        ///     Gets the value of the renderer swapbuffers
        /// </summary>
        public ref IntPtr Renderer_SwapBuffers => ref Unsafe.AsRef<IntPtr>(&NativePtr->Renderer_SwapBuffers);

        /// <summary>
        ///     Gets the value of the monitors
        /// </summary>
        public ImPtrVector<ImGuiPlatformMonitorPtr> Monitors => new ImPtrVector<ImGuiPlatformMonitorPtr>(NativePtr->Monitors, Unsafe.SizeOf<ImGuiPlatformMonitor>());

        /// <summary>
        ///     Gets the value of the viewports
        /// </summary>
        public ImVector<ImGuiViewportPtr> Viewports => new ImVector<ImGuiViewportPtr>(NativePtr->Viewports);

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImGuiPlatformIO_destroy(NativePtr);
        }
    }
}