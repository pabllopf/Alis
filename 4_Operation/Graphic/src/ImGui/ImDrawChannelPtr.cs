// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawChannelPtr.cs
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
    ///     The im draw channel ptr
    /// </summary>
    public unsafe struct ImDrawChannelPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImDrawChannel* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImDrawChannelPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImDrawChannelPtr(ImDrawChannel* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImDrawChannelPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImDrawChannelPtr(IntPtr nativePtr) => NativePtr = (ImDrawChannel*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawChannelPtr(ImDrawChannel* nativePtr) => new ImDrawChannelPtr(nativePtr);

        /// <summary>
        ///     /
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawChannel*(ImDrawChannelPtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawChannelPtr(IntPtr nativePtr) => new ImDrawChannelPtr(nativePtr);

        /// <summary>
        ///     Gets the value of the  cmdbuffer
        /// </summary>
        public ImPtrVector<ImDrawCmdPtr> _CmdBuffer => new ImPtrVector<ImDrawCmdPtr>(NativePtr->_CmdBuffer, Unsafe.SizeOf<ImDrawCmd>());

        /// <summary>
        ///     Gets the value of the  idxbuffer
        /// </summary>
        public ImVector<ushort> _IdxBuffer => new ImVector<ushort>(NativePtr->_IdxBuffer);
    }
}