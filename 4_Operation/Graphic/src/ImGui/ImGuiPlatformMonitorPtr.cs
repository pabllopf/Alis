// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiPlatformMonitorPtr.cs
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

namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    ///     The im gui platform monitor ptr
    /// </summary>
    public unsafe struct ImGuiPlatformMonitorPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImGuiPlatformMonitor* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiPlatformMonitorPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiPlatformMonitorPtr(ImGuiPlatformMonitor* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiPlatformMonitorPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiPlatformMonitorPtr(IntPtr nativePtr) => NativePtr = (ImGuiPlatformMonitor*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiPlatformMonitorPtr(ImGuiPlatformMonitor* nativePtr) => new ImGuiPlatformMonitorPtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiPlatformMonitor*(ImGuiPlatformMonitorPtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiPlatformMonitorPtr(IntPtr nativePtr) => new ImGuiPlatformMonitorPtr(nativePtr);

        /// <summary>
        ///     Gets the value of the main pos
        /// </summary>
        public ref Vector2 MainPos => ref Unsafe.AsRef<Vector2>(&NativePtr->MainPos);

        /// <summary>
        ///     Gets the value of the main size
        /// </summary>
        public ref Vector2 MainSize => ref Unsafe.AsRef<Vector2>(&NativePtr->MainSize);

        /// <summary>
        ///     Gets the value of the work pos
        /// </summary>
        public ref Vector2 WorkPos => ref Unsafe.AsRef<Vector2>(&NativePtr->WorkPos);

        /// <summary>
        ///     Gets the value of the work size
        /// </summary>
        public ref Vector2 WorkSize => ref Unsafe.AsRef<Vector2>(&NativePtr->WorkSize);

        /// <summary>
        ///     Gets the value of the dpi scale
        /// </summary>
        public ref float DpiScale => ref Unsafe.AsRef<float>(&NativePtr->DpiScale);

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImGuiPlatformMonitor_destroy(NativePtr);
        }
    }
}