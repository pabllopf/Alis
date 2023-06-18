// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPtrVector.cs
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
using Alis.Core.Graphic.ImGui.Utils;

namespace Alis.Core.Graphic.ImGui.Structs
{
    /// <summary>
    ///     The im ptr vector
    /// </summary>
    public unsafe struct ImPtrVector<T> where T : unmanaged
    {
        /// <summary>
        ///     The size
        /// </summary>
        public readonly int Size;

        /// <summary>
        ///     The capacity
        /// </summary>
        public readonly int Capacity;

        /// <summary>
        ///     The data
        /// </summary>
        public readonly IntPtr Data;

        /// <summary>
        ///     The stride
        /// </summary>
        private readonly int _stride;

        /// <summary>
        ///     Initializes a new instance of the  class
        /// </summary>
        /// <param name="vector">The vector</param>
        /// <param name="stride">The stride</param>
        public ImPtrVector(ImVector vector, int stride)
            : this(vector.Size, vector.Capacity, vector.Data, stride)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the class
        /// </summary>
        /// <param name="size">The size</param>
        /// <param name="capacity">The capacity</param>
        /// <param name="data">The data</param>
        /// <param name="stride">The stride</param>
        public ImPtrVector(int size, int capacity, IntPtr data, int stride)
        {
            Size = size;
            Capacity = capacity;
            Data = data;
            _stride = stride;
        }

        /// <summary>
        ///     The ret
        /// </summary>
        public T this[int index]
        {
            get
            {
                byte* address = (byte*) Data + index * _stride;
                T ret = Unsafe.Read<T>(&address);
                return ret;
            }
        }
    }
}