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
using Alis.Core.Extension.ImGui.Utils;

namespace Alis.Core.Extension.ImGui
{
    /// <summary>
    ///     The stb texteditstateptr
    /// </summary>
    public readonly unsafe struct StbTexteditStatePtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public StbTexteditState* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="StbTexteditStatePtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public StbTexteditStatePtr(StbTexteditState* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="StbTexteditStatePtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public StbTexteditStatePtr(IntPtr nativePtr) => NativePtr = (StbTexteditState*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator StbTexteditStatePtr(StbTexteditState* nativePtr) => new StbTexteditStatePtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator StbTexteditState*(StbTexteditStatePtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator StbTexteditStatePtr(IntPtr nativePtr) => new StbTexteditStatePtr(nativePtr);

        /// <summary>
        ///     Gets the value of the cursor
        /// </summary>
        public ref int Cursor => ref Unsafe.AsRef<int>(&NativePtr->Cursor);

        /// <summary>
        ///     Gets the value of the select start
        /// </summary>
        public ref int SelectStart => ref Unsafe.AsRef<int>(&NativePtr->SelectStart);

        /// <summary>
        ///     Gets the value of the select end
        /// </summary>
        public ref int SelectEnd => ref Unsafe.AsRef<int>(&NativePtr->SelectEnd);

        /// <summary>
        ///     Gets the value of the insert mode
        /// </summary>
        public ref byte InsertMode => ref Unsafe.AsRef<byte>(&NativePtr->InsertMode);

        /// <summary>
        ///     Gets the value of the row count per page
        /// </summary>
        public ref int RowCountPerPage => ref Unsafe.AsRef<int>(&NativePtr->RowCountPerPage);

        /// <summary>
        ///     Gets the value of the cursor at end of line
        /// </summary>
        public ref byte CursorAtEndOfLine => ref Unsafe.AsRef<byte>(&NativePtr->CursorAtEndOfLine);

        /// <summary>
        ///     Gets the value of the initialized
        /// </summary>
        public ref byte Initialized => ref Unsafe.AsRef<byte>(&NativePtr->Initialized);

        /// <summary>
        ///     Gets the value of the has preferred x
        /// </summary>
        public ref byte HasPreferredX => ref Unsafe.AsRef<byte>(&NativePtr->HasPreferredX);

        /// <summary>
        ///     Gets the value of the single line
        /// </summary>
        public ref byte SingleLine => ref Unsafe.AsRef<byte>(&NativePtr->SingleLine);

        /// <summary>
        ///     Gets the value of the padding 1
        /// </summary>
        public ref byte Padding1 => ref Unsafe.AsRef<byte>(&NativePtr->Padding1);

        /// <summary>
        ///     Gets the value of the padding 2
        /// </summary>
        public ref byte Padding2 => ref Unsafe.AsRef<byte>(&NativePtr->Padding2);

        /// <summary>
        ///     Gets the value of the padding 3
        /// </summary>
        public ref byte Padding3 => ref Unsafe.AsRef<byte>(&NativePtr->Padding3);

        /// <summary>
        ///     Gets the value of the preferred x
        /// </summary>
        public ref float PreferredX => ref Unsafe.AsRef<float>(&NativePtr->PreferredX);

        /// <summary>
        ///     Gets the value of the undostate
        /// </summary>
        public ref StbUndoState Undostate => ref Unsafe.AsRef<StbUndoState>(&NativePtr->Undostate);
    }
}