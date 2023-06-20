// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiWindowClassPtr.cs
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
using Alis.Core.Graphic.ImGui.Enums;
using Alis.Core.Graphic.ImGui.Utils;

namespace Alis.Core.Graphic.ImGui.Structs
{
    /// <summary>
    ///     The im gui window class ptr
    /// </summary>
    public unsafe struct ImGuiWindowClassPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImGuiWindowClass* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiWindowClassPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiWindowClassPtr(ImGuiWindowClass* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiWindowClassPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiWindowClassPtr(IntPtr nativePtr) => NativePtr = (ImGuiWindowClass*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiWindowClassPtr(ImGuiWindowClass* nativePtr) => new ImGuiWindowClassPtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiWindowClass*(ImGuiWindowClassPtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiWindowClassPtr(IntPtr nativePtr) => new ImGuiWindowClassPtr(nativePtr);

        /// <summary>
        ///     Gets the value of the class id
        /// </summary>
        public ref uint ClassId => ref Unsafe.AsRef<uint>(&NativePtr->ClassId);

        /// <summary>
        ///     Gets the value of the parent viewport id
        /// </summary>
        public ref uint ParentViewportId => ref Unsafe.AsRef<uint>(&NativePtr->ParentViewportId);

        /// <summary>
        ///     Gets the value of the viewport flags override set
        /// </summary>
        public ref ImGuiViewportFlag ViewportFlagOverrideSet => ref Unsafe.AsRef<ImGuiViewportFlag>(&NativePtr->ViewportFlagOverrideSet);

        /// <summary>
        ///     Gets the value of the viewport flags override clear
        /// </summary>
        public ref ImGuiViewportFlag ViewportFlagOverrideClear => ref Unsafe.AsRef<ImGuiViewportFlag>(&NativePtr->ViewportFlagOverrideClear);

        /// <summary>
        ///     Gets the value of the tab item flags override set
        /// </summary>
        public ref ImGuiTabItemFlag TabItemFlagOverrideSet => ref Unsafe.AsRef<ImGuiTabItemFlag>(&NativePtr->TabItemFlagOverrideSet);

        /// <summary>
        ///     Gets the value of the dock node flags override set
        /// </summary>
        public ref ImGuiDockNodeFlag DockNodeFlagOverrideSet => ref Unsafe.AsRef<ImGuiDockNodeFlag>(&NativePtr->DockNodeFlagOverrideSet);

        /// <summary>
        ///     Gets the value of the docking always tab bar
        /// </summary>
        public ref bool DockingAlwaysTabBar => ref Unsafe.AsRef<bool>(&NativePtr->DockingAlwaysTabBar);

        /// <summary>
        ///     Gets the value of the docking allow unclassed
        /// </summary>
        public ref bool DockingAllowUnclassed => ref Unsafe.AsRef<bool>(&NativePtr->DockingAllowUnclassed);

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImGuiWindowClass_destroy(NativePtr);
        }
    }
}