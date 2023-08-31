// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EmulateThreeButtonMousePtr.cs
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

namespace Alis.Core.Graphic.UI.Extras.Node
{
    /// <summary>
    ///     The emulate three button mouse ptr
    /// </summary>
    public unsafe struct EmulateThreeButtonMousePtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public EmulateThreeButtonMouse* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EmulateThreeButtonMousePtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public EmulateThreeButtonMousePtr(EmulateThreeButtonMouse* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EmulateThreeButtonMousePtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public EmulateThreeButtonMousePtr(IntPtr nativePtr) => NativePtr = (EmulateThreeButtonMouse*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator EmulateThreeButtonMousePtr(EmulateThreeButtonMouse* nativePtr) => new EmulateThreeButtonMousePtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator EmulateThreeButtonMouse*(EmulateThreeButtonMousePtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator EmulateThreeButtonMousePtr(IntPtr nativePtr) => new EmulateThreeButtonMousePtr(nativePtr);

        /// <summary>
        ///     Gets or sets the value of the modifier
        /// </summary>
        public IntPtr Modifier
        {
            get => (IntPtr) NativePtr->Modifier;
            set => NativePtr->Modifier = (byte*) value;
        }

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImNodesNative.EmulateThreeButtonMouse_destroy(NativePtr);
        }
    }
}