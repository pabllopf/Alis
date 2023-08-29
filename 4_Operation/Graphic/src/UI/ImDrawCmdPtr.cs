// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawCmdPtr.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.UI.Utils;

namespace Alis.Core.Graphic.UI
{
    /// <summary>
    ///     The im draw cmd ptr
    /// </summary>
    public unsafe struct ImDrawCmdPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImDrawCmd* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImDrawCmdPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImDrawCmdPtr(ImDrawCmd* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImDrawCmdPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImDrawCmdPtr(IntPtr nativePtr) => NativePtr = (ImDrawCmd*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawCmdPtr(ImDrawCmd* nativePtr) => new ImDrawCmdPtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawCmd*(ImDrawCmdPtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawCmdPtr(IntPtr nativePtr) => new ImDrawCmdPtr(nativePtr);

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

        /// <summary>
        ///     Gets the value of the idx offset
        /// </summary>
        public ref uint IdxOffset => ref Unsafe.AsRef<uint>(&NativePtr->IdxOffset);

        /// <summary>
        ///     Gets the value of the elem count
        /// </summary>
        public ref uint ElemCount => ref Unsafe.AsRef<uint>(&NativePtr->ElemCount);

        /// <summary>
        ///     Gets the value of the user callback
        /// </summary>
        public ref IntPtr UserCallback => ref Unsafe.AsRef<IntPtr>(&NativePtr->UserCallback);

        /// <summary>
        ///     Gets or sets the value of the user callback data
        /// </summary>
        public IntPtr UserCallbackData
        {
            get => (IntPtr) NativePtr->UserCallbackData;
            set => NativePtr->UserCallbackData = (void*) value;
        }

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImDrawCmd_destroy(NativePtr);
        }

        /// <summary>
        ///     Gets the tex id
        /// </summary>
        /// <returns>The ret</returns>
        public IntPtr GetTexId()
        {
            IntPtr ret = ImGuiNative.ImDrawCmd_GetTexID(NativePtr);
            return ret;
        }
    }
}