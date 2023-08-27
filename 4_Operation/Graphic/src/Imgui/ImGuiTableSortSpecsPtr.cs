// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTableSortSpecsPtr.cs
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
using Alis.Core.Graphic.ImGui.Utils;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    ///     The im gui table sort specs ptr
    /// </summary>
    public unsafe struct ImGuiTableSortSpecsPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImGuiTableSortSpecs* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiTableSortSpecsPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiTableSortSpecsPtr(ImGuiTableSortSpecs* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiTableSortSpecsPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiTableSortSpecsPtr(IntPtr nativePtr) => NativePtr = (ImGuiTableSortSpecs*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiTableSortSpecsPtr(ImGuiTableSortSpecs* nativePtr) => new ImGuiTableSortSpecsPtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiTableSortSpecs*(ImGuiTableSortSpecsPtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiTableSortSpecsPtr(IntPtr nativePtr) => new ImGuiTableSortSpecsPtr(nativePtr);

        /// <summary>
        ///     Gets the value of the specs
        /// </summary>
        public ImGuiTableColumnSortSpecsPtr Specs => new ImGuiTableColumnSortSpecsPtr(NativePtr->Specs);

        /// <summary>
        ///     Gets the value of the specs count
        /// </summary>
        public ref int SpecsCount => ref Unsafe.AsRef<int>(&NativePtr->SpecsCount);

        /// <summary>
        ///     Gets the value of the specs dirty
        /// </summary>
        public ref bool SpecsDirty => ref Unsafe.AsRef<bool>(&NativePtr->SpecsDirty);

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImGuiTableSortSpecs_destroy(NativePtr);
        }
    }
}