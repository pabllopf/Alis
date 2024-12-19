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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.ImGui
{
    /// <summary>
    ///     The im gui viewport ptr
    /// </summary>
    public readonly struct ImGuiViewportPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public IntPtr NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiViewportPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiViewportPtr(IntPtr nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiViewportPtr" /> class
        /// </summary>
        /// <param name="viewport">The viewport</param>
        public ImGuiViewportPtr(ImGuiViewport viewport)
        {
            GCHandle handle = GCHandle.Alloc(viewport, GCHandleType.Pinned);
            NativePtr = handle.AddrOfPinnedObject();
        }

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiViewportPtr(IntPtr nativePtr) => new ImGuiViewportPtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator IntPtr(ImGuiViewportPtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        ///     Gets the value of the id
        /// </summary>
        public uint Id => (uint) Marshal.ReadInt32(NativePtr, 0);

        /// <summary>
        ///     Gets the value of the flags
        /// </summary>
        public ImGuiViewportFlags Flags => (ImGuiViewportFlags) Marshal.ReadInt32(NativePtr, sizeof(uint));

        /// <summary>
        ///     Gets the value of the pos
        /// </summary>
        public Vector2F Pos => Marshal.PtrToStructure<Vector2F>(NativePtr + 2 * sizeof(uint));

        /// <summary>
        ///     Gets the value of the size
        /// </summary>
        public Vector2F Size => Marshal.PtrToStructure<Vector2F>(NativePtr + 2 * sizeof(uint) + Marshal.SizeOf<Vector2F>());

        /// <summary>
        ///     Gets the value of the work pos
        /// </summary>
        public Vector2F WorkPos => Marshal.PtrToStructure<Vector2F>(NativePtr + 2 * sizeof(uint) + 2 * Marshal.SizeOf<Vector2F>());

        /// <summary>
        ///     Gets the value of the work size
        /// </summary>
        public Vector2F WorkSize => Marshal.PtrToStructure<Vector2F>(NativePtr + 2 * sizeof(uint) + 3 * Marshal.SizeOf<Vector2F>());

        /// <summary>
        ///     Gets the value of the dpi scale
        /// </summary>
        public float DpiScale => Marshal.PtrToStructure<float>(NativePtr + 2 * sizeof(uint) + 4 * Marshal.SizeOf<Vector2F>());

        /// <summary>
        ///     Gets the value of the parent viewport id
        /// </summary>
        public uint ParentViewportId => (uint) Marshal.ReadInt32(NativePtr + 2 * sizeof(uint) + 4 * Marshal.SizeOf<Vector2F>() + sizeof(float));

        /// <summary>
        ///     Gets or sets the value of the renderer user data
        /// </summary>
        public IntPtr RendererUserData
        {
            get => Marshal.ReadIntPtr(NativePtr, Marshal.OffsetOf<ImGuiViewportPtr>("RendererUserData").ToInt32());
            set => Marshal.WriteIntPtr(NativePtr, Marshal.OffsetOf<ImGuiViewportPtr>("RendererUserData").ToInt32(), value);
        }

        /// <summary>
        ///     Gets or sets the value of the platform user data
        /// </summary>
        public IntPtr PlatformUserData
        {
            get => Marshal.ReadIntPtr(NativePtr, Marshal.OffsetOf<ImGuiViewportPtr>("PlatformUserData").ToInt32());
            set => Marshal.WriteIntPtr(NativePtr, Marshal.OffsetOf<ImGuiViewportPtr>("PlatformUserData").ToInt32(), value);
        }

        /// <summary>
        ///     Gets or sets the value of the platform handle
        /// </summary>
        public IntPtr PlatformHandle => Marshal.ReadIntPtr(NativePtr, Marshal.OffsetOf<ImGuiViewportPtr>("PlatformHandle").ToInt32());

        /// <summary>
        ///     Gets or sets the value of the platform handle raw
        /// </summary>
        public IntPtr PlatformHandleRaw => Marshal.ReadIntPtr(NativePtr, Marshal.OffsetOf<ImGuiViewportPtr>("PlatformHandleRaw").ToInt32());

        /// <summary>
        ///     Gets the value of the platform window created
        /// </summary>
        public bool PlatformWindowCreated => Marshal.ReadByte(NativePtr, Marshal.OffsetOf<ImGuiViewportPtr>("PlatformWindowCreated").ToInt32()) != 0;

        /// <summary>
        ///     Gets the value of the platform request move
        /// </summary>
        public bool PlatformRequestMove => Marshal.ReadByte(NativePtr, Marshal.OffsetOf<ImGuiViewportPtr>("PlatformRequestMove").ToInt32()) != 0;

        /// <summary>
        ///     Gets the value of the platform request resize
        /// </summary>
        public bool PlatformRequestResize => Marshal.ReadByte(NativePtr, Marshal.OffsetOf<ImGuiViewportPtr>("PlatformRequestResize").ToInt32()) != 0;

        /// <summary>
        ///     Gets the value of the platform request close
        /// </summary>
        public bool PlatformRequestClose => Marshal.ReadByte(NativePtr, Marshal.OffsetOf<ImGuiViewportPtr>("PlatformRequestClose").ToInt32()) != 0;
    }
}