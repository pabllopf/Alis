// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: ImGuiKeyDataPtr.cs
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

namespace Alis.App.Engine.UI
{
    /// <summary>
    ///     The im gui key data ptr
    /// </summary>
    public unsafe struct ImGuiKeyDataPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImGuiKeyData* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiKeyDataPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiKeyDataPtr(ImGuiKeyData* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiKeyDataPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiKeyDataPtr(IntPtr nativePtr) => NativePtr = (ImGuiKeyData*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiKeyDataPtr(ImGuiKeyData* nativePtr) => new ImGuiKeyDataPtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiKeyData*(ImGuiKeyDataPtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiKeyDataPtr(IntPtr nativePtr) => new ImGuiKeyDataPtr(nativePtr);

        /// <summary>
        ///     Gets the value of the down
        /// </summary>
        public ref bool Down => ref Unsafe.AsRef<bool>(&NativePtr->Down);

        /// <summary>
        ///     Gets the value of the down duration
        /// </summary>
        public ref float DownDuration => ref Unsafe.AsRef<float>(&NativePtr->DownDuration);

        /// <summary>
        ///     Gets the value of the down duration prev
        /// </summary>
        public ref float DownDurationPrev => ref Unsafe.AsRef<float>(&NativePtr->DownDurationPrev);

        /// <summary>
        ///     Gets the value of the analog value
        /// </summary>
        public ref float AnalogValue => ref Unsafe.AsRef<float>(&NativePtr->AnalogValue);
    }
}