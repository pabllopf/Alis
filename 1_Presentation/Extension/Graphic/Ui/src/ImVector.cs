// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImVector.cs
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

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im vector
    /// </summary>
    public struct ImVector
    {
        /// <summary>
        ///     The size
        /// </summary>
        public int Size;

        /// <summary>
        ///     The capacity
        /// </summary>
        public int Capacity;

        /// <summary>
        ///     The data
        /// </summary>
        public IntPtr Data;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImVector" /> class
        /// </summary>
        /// <param name="size">The size</param>
        /// <param name="capacity">The capacity</param>
        /// <param name="data">The data</param>
        public ImVector(int size, int capacity, IntPtr data)
        {
            Size = size;
            Capacity = capacity;
            Data = data;
        }

        /// <summary>
        ///     Refs the index
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="index">The index</param>
        /// <returns>The</returns>
        public T Ref<T>(int index) where T : unmanaged
        {
            byte[] bytes = new byte[Marshal.SizeOf<T>()];
            Marshal.Copy(Data + index * Marshal.SizeOf<T>(), bytes, 0, bytes.Length);
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try
            {
                return (T) Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            }
            finally
            {
                handle.Free();
            }
        }

        /// <summary>
        ///     Addresses the index
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        public IntPtr Address<T>(int index) => Data + index * Marshal.SizeOf<T>();
    }
}