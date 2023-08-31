// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StbUndoStatePtr.cs
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
    ///     The stb undo state ptr
    /// </summary>
    public unsafe struct StbUndoStatePtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public StbUndoState* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="StbUndoStatePtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public StbUndoStatePtr(StbUndoState* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="StbUndoStatePtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public StbUndoStatePtr(IntPtr nativePtr) => NativePtr = (StbUndoState*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator StbUndoStatePtr(StbUndoState* nativePtr) => new StbUndoStatePtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator StbUndoState*(StbUndoStatePtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator StbUndoStatePtr(IntPtr nativePtr) => new StbUndoStatePtr(nativePtr);

        /// <summary>
        ///     Gets the value of the undo rec
        /// </summary>
        public RangeAccessor<StbUndoRecord> UndoRec => new RangeAccessor<StbUndoRecord>(&NativePtr->UndoRec0, 99);

        /// <summary>
        ///     Gets the value of the undo char
        /// </summary>
        public RangeAccessor<ushort> UndoChar => new RangeAccessor<ushort>(NativePtr->UndoChar, 999);

        /// <summary>
        ///     Gets the value of the undo point
        /// </summary>
        public ref short UndoPoint => ref Unsafe.AsRef<short>(&NativePtr->UndoPoint);

        /// <summary>
        ///     Gets the value of the redo point
        /// </summary>
        public ref short RedoPoint => ref Unsafe.AsRef<short>(&NativePtr->RedoPoint);

        /// <summary>
        ///     Gets the value of the undo char point
        /// </summary>
        public ref int UndoCharPoint => ref Unsafe.AsRef<int>(&NativePtr->UndoCharPoint);

        /// <summary>
        ///     Gets the value of the redo char point
        /// </summary>
        public ref int RedoCharPoint => ref Unsafe.AsRef<int>(&NativePtr->RedoCharPoint);
    }
}