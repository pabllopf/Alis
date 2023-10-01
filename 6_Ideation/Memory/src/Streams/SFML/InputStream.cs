// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InputStream.cs
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
using System.Runtime.InteropServices;

namespace Alis.Core.Aspect.Memory.Streams.SFML
{
    /// <summary>
    ///     Structure that contains InputStream callbacks
    ///     (directly maps to a CSFML sfInputStream)
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct InputStream
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Type of callback to read data from the current stream
        /// </summary>
        ////////////////////////////////////////////////////////////
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate long ReadCallbackType(IntPtr data, long size, IntPtr userData);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Type of callback to seek the current stream's position
        /// </summary>
        ////////////////////////////////////////////////////////////
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate long SeekCallbackType(long position, IntPtr userData);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Type of callback to return the current stream's position
        /// </summary>
        ////////////////////////////////////////////////////////////
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate long TellCallbackType(IntPtr userData);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Type of callback to return the current stream's size
        /// </summary>
        ////////////////////////////////////////////////////////////
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate long GetSizeCallbackType(IntPtr userData);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Function that is called to read data from the stream
        /// </summary>
        ////////////////////////////////////////////////////////////
        public ReadCallbackType Read;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Function that is called to seek the stream
        /// </summary>
        ////////////////////////////////////////////////////////////
        public SeekCallbackType Seek;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Function that is called to return the positon
        /// </summary>
        ////////////////////////////////////////////////////////////
        public TellCallbackType Tell;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Function that is called to return the size
        /// </summary>
        ////////////////////////////////////////////////////////////
        public GetSizeCallbackType GetSize;
    }
}