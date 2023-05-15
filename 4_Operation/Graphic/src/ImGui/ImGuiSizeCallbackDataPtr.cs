// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiSizeCallbackDataPtr.cs
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
using System.Numerics;

namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    ///     The im gui size callback data ptr
    /// </summary>
    public unsafe struct ImGuiSizeCallbackDataPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImGuiSizeCallbackData* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiSizeCallbackDataPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiSizeCallbackDataPtr(ImGuiSizeCallbackData* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiSizeCallbackDataPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiSizeCallbackDataPtr(IntPtr nativePtr) => NativePtr = (ImGuiSizeCallbackData*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiSizeCallbackDataPtr(ImGuiSizeCallbackData* nativePtr) => new ImGuiSizeCallbackDataPtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiSizeCallbackData*(ImGuiSizeCallbackDataPtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiSizeCallbackDataPtr(IntPtr nativePtr) => new ImGuiSizeCallbackDataPtr(nativePtr);

        /// <summary>
        ///     Gets or sets the value of the user data
        /// </summary>
        public IntPtr UserData
        {
            get => (IntPtr) NativePtr->UserData;
            set => NativePtr->UserData = (void*) value;
        }

        /// <summary>
        ///     Gets the value of the pos
        /// </summary>
        public ref Vector2 Pos => ref Unsafe.AsRef<Vector2>(&NativePtr->Pos);

        /// <summary>
        ///     Gets the value of the current size
        /// </summary>
        public ref Vector2 CurrentSize => ref Unsafe.AsRef<Vector2>(&NativePtr->CurrentSize);

        /// <summary>
        ///     Gets the value of the desired size
        /// </summary>
        public ref Vector2 DesiredSize => ref Unsafe.AsRef<Vector2>(&NativePtr->DesiredSize);
    }
}