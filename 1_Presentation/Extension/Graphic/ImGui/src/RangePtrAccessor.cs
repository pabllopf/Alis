// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RangePtrAccessor.cs
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
using Alis.Extension.Graphic.ImGui.Utils;

namespace Alis.Extension.Graphic.ImGui
{
    /// <summary>
    ///     The range ptr accessor
    /// </summary>
    public readonly struct RangePtrAccessor<T> where T : unmanaged
    {
        /// <summary>
        ///     The data
        /// </summary>
        public readonly IntPtr Data;
        
        /// <summary>
        ///     The count
        /// </summary>
        public readonly int Count;
        
        /// <summary>
        ///     Initializes a new instance of the  class
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="count">The count</param>
        public RangePtrAccessor(IntPtr data, int count)
        {
            Data = data;
            Count = count;
        }
        
        /// <summary>
        /// The free
        /// </summary>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                
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
        }
    }
}