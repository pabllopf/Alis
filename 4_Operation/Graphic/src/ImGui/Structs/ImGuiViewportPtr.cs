// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiViewportPtr.cs
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
using Alis.Core.Graphic.ImGui.Enums;
using Alis.Core.Graphic.ImGui.Utils;

namespace Alis.Core.Graphic.ImGui.Structs
{
    /// <summary>
    ///     The im gui viewport ptr
    /// </summary>
    public unsafe struct ImGuiViewportPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImGuiViewport* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiViewportPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiViewportPtr(ImGuiViewport* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiViewportPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiViewportPtr(IntPtr nativePtr) => NativePtr = (ImGuiViewport*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiViewportPtr(ImGuiViewport* nativePtr) => new ImGuiViewportPtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiViewport*(ImGuiViewportPtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiViewportPtr(IntPtr nativePtr) => new ImGuiViewportPtr(nativePtr);

        /// <summary>
        ///     Gets the value of the id
        /// </summary>
        public ref uint Id => ref Unsafe.AsRef<uint>(&NativePtr->Id);

        /// <summary>
        ///     Gets the value of the flags
        /// </summary>
        public ref ImGuiViewports Flag => ref Unsafe.AsRef<ImGuiViewports>(&NativePtr->Flag);

        /// <summary>
        ///     Gets the value of the pos
        /// </summary>
        public ref Vector2F Pos => ref Unsafe.AsRef<Vector2F>(&NativePtr->Pos);

        /// <summary>
        ///     Gets the value of the size
        /// </summary>
        public ref Vector2F Size => ref Unsafe.AsRef<Vector2F>(&NativePtr->Size);

        /// <summary>
        ///     Gets the value of the work pos
        /// </summary>
        public ref Vector2F WorkPos => ref Unsafe.AsRef<Vector2F>(&NativePtr->WorkPos);

        /// <summary>
        ///     Gets the value of the work size
        /// </summary>
        public ref Vector2F WorkSize => ref Unsafe.AsRef<Vector2F>(&NativePtr->WorkSize);

        /// <summary>
        ///     Gets the value of the dpi scale
        /// </summary>
        public ref float DpiScale => ref Unsafe.AsRef<float>(&NativePtr->DpiScale);

        /// <summary>
        ///     Gets the value of the parent viewport id
        /// </summary>
        public ref uint ParentViewportId => ref Unsafe.AsRef<uint>(&NativePtr->ParentViewportId);

        /// <summary>
        ///     Gets the value of the draw data
        /// </summary>
        public ImDrawDataPtr DrawData => new ImDrawDataPtr(NativePtr->DrawData);

        /// <summary>
        ///     Gets or sets the value of the renderer user data
        /// </summary>
        public IntPtr RendererUserData
        {
            get => (IntPtr) NativePtr->RendererUserData;
            set => NativePtr->RendererUserData = (void*) value;
        }

        /// <summary>
        ///     Gets or sets the value of the platform user data
        /// </summary>
        public IntPtr PlatformUserData
        {
            get => (IntPtr) NativePtr->PlatformUserData;
            set => NativePtr->PlatformUserData = (void*) value;
        }

        /// <summary>
        ///     Gets or sets the value of the platform handle
        /// </summary>
        public IntPtr PlatformHandle
        {
            get => (IntPtr) NativePtr->PlatformHandle;
            set => NativePtr->PlatformHandle = (void*) value;
        }

        /// <summary>
        ///     Gets or sets the value of the platform handle raw
        /// </summary>
        public IntPtr PlatformHandleRaw
        {
            get => (IntPtr) NativePtr->PlatformHandleRaw;
            set => NativePtr->PlatformHandleRaw = (void*) value;
        }

        /// <summary>
        ///     Gets the value of the platform window created
        /// </summary>
        public ref bool PlatformWindowCreated => ref Unsafe.AsRef<bool>(&NativePtr->PlatformWindowCreated);

        /// <summary>
        ///     Gets the value of the platform request move
        /// </summary>
        public ref bool PlatformRequestMove => ref Unsafe.AsRef<bool>(&NativePtr->PlatformRequestMove);

        /// <summary>
        ///     Gets the value of the platform request resize
        /// </summary>
        public ref bool PlatformRequestResize => ref Unsafe.AsRef<bool>(&NativePtr->PlatformRequestResize);

        /// <summary>
        ///     Gets the value of the platform request close
        /// </summary>
        public ref bool PlatformRequestClose => ref Unsafe.AsRef<bool>(&NativePtr->PlatformRequestClose);

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImGuiViewport_destroy(NativePtr);
        }

        /// <summary>
        ///     Gets the center
        /// </summary>
        /// <returns>The retval</returns>
        public Vector2F GetCenter()
        {
            Vector2F retval;
            ImGuiNative.ImGuiViewport_GetCenter(&retval, NativePtr);
            return retval;
        }

        /// <summary>
        ///     Gets the work center
        /// </summary>
        /// <returns>The retval</returns>
        public Vector2F GetWorkCenter()
        {
            Vector2F retval;
            ImGuiNative.ImGuiViewport_GetWorkCenter(&retval, NativePtr);
            return retval;
        }
    }
}