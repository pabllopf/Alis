// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawListSplitterPtr.cs
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
    ///     The im draw list splitter ptr
    /// </summary>
    public unsafe struct ImDrawListSplitterPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImDrawListSplitter* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImDrawListSplitterPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImDrawListSplitterPtr(ImDrawListSplitter* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImDrawListSplitterPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImDrawListSplitterPtr(IntPtr nativePtr) => NativePtr = (ImDrawListSplitter*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawListSplitterPtr(ImDrawListSplitter* nativePtr) => new ImDrawListSplitterPtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawListSplitter*(ImDrawListSplitterPtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawListSplitterPtr(IntPtr nativePtr) => new ImDrawListSplitterPtr(nativePtr);

        /// <summary>
        ///     Gets the value of the  current
        /// </summary>
        public ref int _Current => ref Unsafe.AsRef<int>(&NativePtr->_Current);

        /// <summary>
        ///     Gets the value of the  count
        /// </summary>
        public ref int _Count => ref Unsafe.AsRef<int>(&NativePtr->_Count);

        /// <summary>
        ///     Gets the value of the  channels
        /// </summary>
        public ImPtrVector<ImDrawChannelPtr> _Channels => new ImPtrVector<ImDrawChannelPtr>(NativePtr->_Channels, Unsafe.SizeOf<ImDrawChannel>());

        /// <summary>
        ///     Clears this instance
        /// </summary>
        public void Clear()
        {
            ImGuiNative.ImDrawListSplitter_Clear(NativePtr);
        }

        /// <summary>
        ///     Clears the free memory
        /// </summary>
        public void ClearFreeMemory()
        {
            ImGuiNative.ImDrawListSplitter_ClearFreeMemory(NativePtr);
        }

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImDrawListSplitter_destroy(NativePtr);
        }

        /// <summary>
        ///     Merges the draw list
        /// </summary>
        /// <param name="draw_list">The draw list</param>
        public void Merge(ImDrawListPtr draw_list)
        {
            ImDrawList* native_draw_list = draw_list.NativePtr;
            ImGuiNative.ImDrawListSplitter_Merge(NativePtr, native_draw_list);
        }

        /// <summary>
        ///     Sets the current channel using the specified draw list
        /// </summary>
        /// <param name="draw_list">The draw list</param>
        /// <param name="channel_idx">The channel idx</param>
        public void SetCurrentChannel(ImDrawListPtr draw_list, int channel_idx)
        {
            ImDrawList* native_draw_list = draw_list.NativePtr;
            ImGuiNative.ImDrawListSplitter_SetCurrentChannel(NativePtr, native_draw_list, channel_idx);
        }

        /// <summary>
        ///     Splits the draw list
        /// </summary>
        /// <param name="draw_list">The draw list</param>
        /// <param name="count">The count</param>
        public void Split(ImDrawListPtr draw_list, int count)
        {
            ImDrawList* native_draw_list = draw_list.NativePtr;
            ImGuiNative.ImDrawListSplitter_Split(NativePtr, native_draw_list, count);
        }
    }
}