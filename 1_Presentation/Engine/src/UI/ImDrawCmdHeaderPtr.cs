// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: ImDrawCmdHeaderPtr.cs
// 
//  Author: Pablo Perdomo Falcón
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
using Alis.App.Engine.UI.Utils;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.App.Engine.UI
{
    /// <summary>
    ///     The im draw cmd header ptr
    /// </summary>
    public unsafe struct ImDrawCmdHeaderPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImDrawCmdHeader* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImDrawCmdHeaderPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImDrawCmdHeaderPtr(ImDrawCmdHeader* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImDrawCmdHeaderPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImDrawCmdHeaderPtr(IntPtr nativePtr) => NativePtr = (ImDrawCmdHeader*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawCmdHeaderPtr(ImDrawCmdHeader* nativePtr) => new ImDrawCmdHeaderPtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawCmdHeader*(ImDrawCmdHeaderPtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawCmdHeaderPtr(IntPtr nativePtr) => new ImDrawCmdHeaderPtr(nativePtr);

        /// <summary>
        ///     Gets the value of the clip rect
        /// </summary>
        public ref Vector4 ClipRect => ref Unsafe.AsRef<Vector4>(&NativePtr->ClipRect);

        /// <summary>
        ///     Gets the value of the texture id
        /// </summary>
        public ref IntPtr TextureId => ref Unsafe.AsRef<IntPtr>(&NativePtr->TextureId);

        /// <summary>
        ///     Gets the value of the vtx offset
        /// </summary>
        public ref uint VtxOffset => ref Unsafe.AsRef<uint>(&NativePtr->VtxOffset);
    }
}