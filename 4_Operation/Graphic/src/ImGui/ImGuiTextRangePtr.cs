// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTextRangePtr.cs
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
    ///     The im gui text range ptr
    /// </summary>
    public struct ImGuiTextRangePtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImGuiTextRange NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiTextRangePtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiTextRangePtr(ImGuiTextRange* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiTextRangePtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiTextRangePtr(IntPtr nativePtr) => NativePtr = (ImGuiTextRange*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiTextRangePtr(ImGuiTextRange* nativePtr) => new ImGuiTextRangePtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiTextRange*(ImGuiTextRangePtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiTextRangePtr(IntPtr nativePtr) => new ImGuiTextRangePtr(nativePtr);

        /// <summary>
        ///     Gets or sets the value of the b
        /// </summary>
        public IntPtr B
        {
            get => (IntPtr) NativePtr->B;
            set => NativePtr->B = (byte*) value;
        }

        /// <summary>
        ///     Gets or sets the value of the e
        /// </summary>
        public IntPtr E
        {
            get => (IntPtr) NativePtr->E;
            set => NativePtr->E = (byte*) value;
        }

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImGuiTextRange_destroy(NativePtr);
        }

        /// <summary>
        ///     Describes whether this instance empty
        /// </summary>
        /// <returns>The bool</returns>
        public bool Empty()
        {
            byte ret = ImGuiNative.ImGuiTextRange_empty(NativePtr);
            return ret != 0;
        }

        /// <summary>
        /// </summary>
        /// <param name="separator"></param>
        /// <param name="out"></param>
        public void Split(byte separator, out ImVector @out)
        {
            fixed (ImVector* nativeOut = &@out)
            {
                ImGuiNative.ImGuiTextRange_split(NativePtr, separator, nativeOut);
            }
        }
    }
}