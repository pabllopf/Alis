// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOPtr.cs
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
using Alis.Extension.Graphic.ImGui.Utils;

namespace Alis.Extension.Graphic.ImGui.Extras.Node
{
    /// <summary>
    ///     The io ptr
    /// </summary>
    public readonly unsafe struct IoPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public Io* NativePtr { get; }
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="IoPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public IoPtr(Io* nativePtr) => NativePtr = nativePtr;
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="IoPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public IoPtr(IntPtr nativePtr) => NativePtr = (Io*) nativePtr;
        
        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator IoPtr(Io* nativePtr) => new IoPtr(nativePtr);
        
        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator Io*(IoPtr wrappedPtr) => wrappedPtr.NativePtr;
        
        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator IoPtr(IntPtr nativePtr) => new IoPtr(nativePtr);
        
        /// <summary>
        ///     Gets the value of the emulate three button mouse
        /// </summary>
        public ref EmulateThreeButtonMouse EmulateThreeButtonMouse => ref Unsafe.AsRef<EmulateThreeButtonMouse>(&NativePtr->EmulateThreeButtonMouse);
        
        /// <summary>
        ///     Gets the value of the link detach with modifier click
        /// </summary>
        public ref LinkDetachWithModifierClick LinkDetachWithModifierClick => ref Unsafe.AsRef<LinkDetachWithModifierClick>(&NativePtr->LinkDetachWithModifierClick);
    }
}