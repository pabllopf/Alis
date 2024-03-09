// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImNodesIOPtr.cs
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

namespace Alis.Core.Extension.ImGui.Extras.Node
{
    /// <summary>
    ///     The im nodes io ptr
    /// </summary>
    public readonly unsafe struct ImNodesIoPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImNodesIo* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImNodesIoPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImNodesIoPtr(ImNodesIo* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImNodesIoPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImNodesIoPtr(IntPtr nativePtr) => NativePtr = (ImNodesIo*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImNodesIoPtr(ImNodesIo* nativePtr) => new ImNodesIoPtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImNodesIo*(ImNodesIoPtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImNodesIoPtr(IntPtr nativePtr) => new ImNodesIoPtr(nativePtr);

        /// <summary>
        ///     Gets the value of the emulate three button mouse
        /// </summary>
        public ref EmulateThreeButtonMouse EmulateThreeButtonMouse => ref Unsafe.AsRef<EmulateThreeButtonMouse>(&NativePtr->EmulateThreeButtonMouse);

        /// <summary>
        ///     Gets the value of the link detach with modifier click
        /// </summary>
        public ref LinkDetachWithModifierClick LinkDetachWithModifierClick => ref Unsafe.AsRef<LinkDetachWithModifierClick>(&NativePtr->LinkDetachWithModifierClick);

        /// <summary>
        ///     Gets the value of the multiple select modifier
        /// </summary>
        public ref MultipleSelectModifier MultipleSelectModifier => ref Unsafe.AsRef<MultipleSelectModifier>(&NativePtr->MultipleSelectModifier);

        /// <summary>
        ///     Gets the value of the alt mouse button
        /// </summary>
        public ref int AltMouseButton => ref Unsafe.AsRef<int>(&NativePtr->AltMouseButton);

        /// <summary>
        ///     Gets the value of the auto panning speed
        /// </summary>
        public ref float AutoPanningSpeed => ref Unsafe.AsRef<float>(&NativePtr->AutoPanningSpeed);

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImNodesNative.ImNodesIO_destroy(NativePtr);
        }
    }
}