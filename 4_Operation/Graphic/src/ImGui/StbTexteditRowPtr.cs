// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StbTexteditRowPtr.cs
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
    ///     The stb textedit row ptr
    /// </summary>
    public unsafe struct StbTexteditRowPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public StbTexteditRow* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="StbTexteditRowPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public StbTexteditRowPtr(StbTexteditRow* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="StbTexteditRowPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public StbTexteditRowPtr(IntPtr nativePtr) => NativePtr = (StbTexteditRow*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator StbTexteditRowPtr(StbTexteditRow* nativePtr) => new StbTexteditRowPtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator StbTexteditRow*(StbTexteditRowPtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator StbTexteditRowPtr(IntPtr nativePtr) => new StbTexteditRowPtr(nativePtr);

        /// <summary>
        ///     Gets the value of the x 0
        /// </summary>
        public ref float x0 => ref Unsafe.AsRef<float>(&NativePtr->x0);

        /// <summary>
        ///     Gets the value of the x 1
        /// </summary>
        public ref float x1 => ref Unsafe.AsRef<float>(&NativePtr->x1);

        /// <summary>
        ///     Gets the value of the baseline y delta
        /// </summary>
        public ref float baseline_y_delta => ref Unsafe.AsRef<float>(&NativePtr->baseline_y_delta);

        /// <summary>
        ///     Gets the value of the ymin
        /// </summary>
        public ref float ymin => ref Unsafe.AsRef<float>(&NativePtr->ymin);

        /// <summary>
        ///     Gets the value of the ymax
        /// </summary>
        public ref float ymax => ref Unsafe.AsRef<float>(&NativePtr->ymax);

        /// <summary>
        ///     Gets the value of the num chars
        /// </summary>
        public ref int num_chars => ref Unsafe.AsRef<int>(&NativePtr->num_chars);
    }
}