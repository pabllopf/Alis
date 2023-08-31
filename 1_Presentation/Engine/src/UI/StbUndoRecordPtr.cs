// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StbUndoRecordPtr.cs
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
using Alis.Core.Graphic.UI.Utils;

namespace Alis.Core.Graphic.UI
{
    /// <summary>
    ///     The stb undo record ptr
    /// </summary>
    public unsafe struct StbUndoRecordPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public StbUndoRecord* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="StbUndoRecordPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public StbUndoRecordPtr(StbUndoRecord* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="StbUndoRecordPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public StbUndoRecordPtr(IntPtr nativePtr) => NativePtr = (StbUndoRecord*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator StbUndoRecordPtr(StbUndoRecord* nativePtr) => new StbUndoRecordPtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator StbUndoRecord*(StbUndoRecordPtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator StbUndoRecordPtr(IntPtr nativePtr) => new StbUndoRecordPtr(nativePtr);

        /// <summary>
        ///     Gets the value of the where
        /// </summary>
        public ref int Where => ref Unsafe.AsRef<int>(&NativePtr->Where);

        /// <summary>
        ///     Gets the value of the insert length
        /// </summary>
        public ref int InsertLength => ref Unsafe.AsRef<int>(&NativePtr->InsertLength);

        /// <summary>
        ///     Gets the value of the delete length
        /// </summary>
        public ref int DeleteLength => ref Unsafe.AsRef<int>(&NativePtr->DeleteLength);

        /// <summary>
        ///     Gets the value of the char storage
        /// </summary>
        public ref int CharStorage => ref Unsafe.AsRef<int>(&NativePtr->CharStorage);
    }
}