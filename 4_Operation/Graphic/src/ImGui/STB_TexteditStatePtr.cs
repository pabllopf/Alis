// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:STB_TexteditStatePtr.cs
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
    ///     The stb texteditstateptr
    /// </summary>
    public unsafe struct STB_TexteditStatePtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public STB_TexteditState* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="STB_TexteditStatePtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public STB_TexteditStatePtr(STB_TexteditState* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="STB_TexteditStatePtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public STB_TexteditStatePtr(IntPtr nativePtr) => NativePtr = (STB_TexteditState*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator STB_TexteditStatePtr(STB_TexteditState* nativePtr) => new STB_TexteditStatePtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator STB_TexteditState*(STB_TexteditStatePtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator STB_TexteditStatePtr(IntPtr nativePtr) => new STB_TexteditStatePtr(nativePtr);

        /// <summary>
        ///     Gets the value of the cursor
        /// </summary>
        public ref int cursor => ref Unsafe.AsRef<int>(&NativePtr->cursor);

        /// <summary>
        ///     Gets the value of the select start
        /// </summary>
        public ref int select_start => ref Unsafe.AsRef<int>(&NativePtr->select_start);

        /// <summary>
        ///     Gets the value of the select end
        /// </summary>
        public ref int select_end => ref Unsafe.AsRef<int>(&NativePtr->select_end);

        /// <summary>
        ///     Gets the value of the insert mode
        /// </summary>
        public ref byte insert_mode => ref Unsafe.AsRef<byte>(&NativePtr->insert_mode);

        /// <summary>
        ///     Gets the value of the row count per page
        /// </summary>
        public ref int row_count_per_page => ref Unsafe.AsRef<int>(&NativePtr->row_count_per_page);

        /// <summary>
        ///     Gets the value of the cursor at end of line
        /// </summary>
        public ref byte cursor_at_end_of_line => ref Unsafe.AsRef<byte>(&NativePtr->cursor_at_end_of_line);

        /// <summary>
        ///     Gets the value of the initialized
        /// </summary>
        public ref byte initialized => ref Unsafe.AsRef<byte>(&NativePtr->initialized);

        /// <summary>
        ///     Gets the value of the has preferred x
        /// </summary>
        public ref byte has_preferred_x => ref Unsafe.AsRef<byte>(&NativePtr->has_preferred_x);

        /// <summary>
        ///     Gets the value of the single line
        /// </summary>
        public ref byte single_line => ref Unsafe.AsRef<byte>(&NativePtr->single_line);

        /// <summary>
        ///     Gets the value of the padding 1
        /// </summary>
        public ref byte padding1 => ref Unsafe.AsRef<byte>(&NativePtr->padding1);

        /// <summary>
        ///     Gets the value of the padding 2
        /// </summary>
        public ref byte padding2 => ref Unsafe.AsRef<byte>(&NativePtr->padding2);

        /// <summary>
        ///     Gets the value of the padding 3
        /// </summary>
        public ref byte padding3 => ref Unsafe.AsRef<byte>(&NativePtr->padding3);

        /// <summary>
        ///     Gets the value of the preferred x
        /// </summary>
        public ref float preferred_x => ref Unsafe.AsRef<float>(&NativePtr->preferred_x);

        /// <summary>
        ///     Gets the value of the undostate
        /// </summary>
        public ref StbUndoState undostate => ref Unsafe.AsRef<StbUndoState>(&NativePtr->undostate);
    }
}