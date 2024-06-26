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
    public readonly unsafe struct ImGuiViewportPtr
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
        public uint Id => (uint)Marshal.ReadInt32(NativePtr, 0);
        
        public ImGuiViewportFlags Flags => (ImGuiViewportFlags)Marshal.ReadInt32(NativePtr, sizeof(uint));
        
        public Vector2 Pos => Marshal.PtrToStructure<Vector2>(NativePtr + 2 * sizeof(uint));
        
        public Vector2 Size => Marshal.PtrToStructure<Vector2>(NativePtr + 2 * sizeof(uint) + sizeof(Vector2));

        /// <summary>
        ///     Gets the value of the work pos
        /// </summary>
        public Vector2 WorkPos => Marshal.PtrToStructure<Vector2>(NativePtr + 2 * sizeof(uint) + 2 * sizeof(Vector2));
        
        /// <summary>
        ///     Gets the value of the work size
        /// </summary>
        public Vector2 WorkSize => Marshal.PtrToStructure<Vector2>(NativePtr + 2 * sizeof(uint) + 3 * sizeof(Vector2));
        
        /// <summary>
        ///     Gets the value of the dpi scale
        /// </summary>
        public float DpiScale => Marshal.PtrToStructure<float>(NativePtr + 2 * sizeof(uint) + 4 * sizeof(Vector2));
        
        /// <summary>
        ///     Gets the value of the parent viewport id
        /// </summary>
        public uint ParentViewportId => (uint)Marshal.ReadInt32(NativePtr + 2 * sizeof(uint) + 4 * sizeof(Vector2) + sizeof(float));
        
        /// <summary>
        ///     Gets the value of the draw data
        /// </summary>
        public ImDrawData DrawData => new ImDrawData();
        
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
        public IntPtr PlatformHandle
        {
            get => Marshal.ReadIntPtr(NativePtr, Marshal.OffsetOf<ImGuiViewportPtr>("PlatformHandle").ToInt32());
            set => Marshal.WriteIntPtr(NativePtr, Marshal.OffsetOf<ImGuiViewportPtr>("PlatformHandle").ToInt32(), value);
        }

        /// <summary>
        ///     Gets or sets the value of the platform handle raw
        /// </summary>
        public IntPtr PlatformHandleRaw
        {
            get => Marshal.ReadIntPtr(NativePtr, Marshal.OffsetOf<ImGuiViewportPtr>("PlatformHandleRaw").ToInt32());
            set => Marshal.WriteIntPtr(NativePtr, Marshal.OffsetOf<ImGuiViewportPtr>("PlatformHandleRaw").ToInt32(), value);
        }
        
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
        
        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImGuiViewport_destroy((IntPtr)NativePtr);
        }
        
        /// <summary>
        ///     Gets the center
        /// </summary>
        /// <returns>The retval</returns>
        public Vector2 GetCenter()
        {
            Vector2 retval;
            ImGuiNative.ImGuiViewport_GetCenter(out retval, (IntPtr)NativePtr);
            return retval;
        }
        
        /// <summary>
        ///     Gets the work center
        /// </summary>
        /// <returns>The retval</returns>
        public Vector2 GetWorkCenter()
        {
            Vector2 retval;
            ImGuiNative.ImGuiViewport_GetWorkCenter(out retval, (IntPtr)NativePtr);
            return retval;
        }
    }
}