// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RangeAccessor.cs
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

namespace Alis.Extension.Graphic.ImGui
{
    /// <summary>
    ///     The range accessor
    /// </summary>
    public readonly unsafe struct RangeAccessor<T> where T : unmanaged
    {
        /// <summary>
        ///     The
        /// </summary>
        private static readonly int SSizeOfT = Unsafe.SizeOf<T>();
        
        /// <summary>
        ///     The data
        /// </summary>
        public readonly void* Data;
        
        /// <summary>
        ///     The count
        /// </summary>
        public readonly int Count;
        
        /// <summary>
        ///     Initializes a new instance of the  class
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="count">The count</param>
        public RangeAccessor(IntPtr data, int count) : this(data.ToPointer(), count)
        {
        }
        
        /// <summary>
        ///     Initializes a new instance of the  class
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="count">The count</param>
        public RangeAccessor(void* data, int count)
        {
            Data = data;
            Count = count;
        }
        
        /// <summary>
        ///     The index
        /// </summary>
        public ref T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                
                return ref Unsafe.AsRef<T>((byte*) Data + SSizeOfT * index);
            }
        }
    }
}