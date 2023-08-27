// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTableColumnSortSpecsPtr.cs
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
    ///     The im gui table column sort specs ptr
    /// </summary>
    public unsafe struct ImGuiTableColumnSortSpecsPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImGuiTableColumnSortSpecs* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiTableColumnSortSpecsPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiTableColumnSortSpecsPtr(ImGuiTableColumnSortSpecs* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiTableColumnSortSpecsPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiTableColumnSortSpecsPtr(IntPtr nativePtr) => NativePtr = (ImGuiTableColumnSortSpecs*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiTableColumnSortSpecsPtr(ImGuiTableColumnSortSpecs* nativePtr) => new ImGuiTableColumnSortSpecsPtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiTableColumnSortSpecs*(ImGuiTableColumnSortSpecsPtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiTableColumnSortSpecsPtr(IntPtr nativePtr) => new ImGuiTableColumnSortSpecsPtr(nativePtr);

        /// <summary>
        ///     Gets the value of the column user id
        /// </summary>
        public ref uint ColumnUserId => ref Unsafe.AsRef<uint>(&NativePtr->ColumnUserId);

        /// <summary>
        ///     Gets the value of the column index
        /// </summary>
        public ref short ColumnIndex => ref Unsafe.AsRef<short>(&NativePtr->ColumnIndex);

        /// <summary>
        ///     Gets the value of the sort order
        /// </summary>
        public ref short SortOrder => ref Unsafe.AsRef<short>(&NativePtr->SortOrder);

        /// <summary>
        ///     Gets the value of the sort direction
        /// </summary>
        public ref ImGuiSortDirection SortDirection => ref Unsafe.AsRef<ImGuiSortDirection>(&NativePtr->SortDirection);

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImGuiTableColumnSortSpecs_destroy(NativePtr);
        }
    }
}