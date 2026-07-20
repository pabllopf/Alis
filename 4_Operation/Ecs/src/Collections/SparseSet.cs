// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SparseSet.cs
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
using Alis.Core.Ecs.Redifinition;

namespace Alis.Core.Ecs.Collections
{
    /// <summary>
    ///     A sparse set data structure mapping integer IDs to values with O(1) access
    /// </summary>
    /// <typeparam name="T">The element type stored in the set</typeparam>
    public class SparseSet<T>
    {
        /// <summary>
        ///     The dense array storing elements in insertion order
        /// </summary>
        private T[] _dense;

        /// <summary>
        ///     The next available index in the dense array
        /// </summary>
        private int _nextIndex;

        /// <summary>
        ///     The sparse array mapping external IDs to dense indices
        /// </summary>
        private int[] _sparse;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SparseSet{T}" /> class with default capacity
        /// </summary>
        public SparseSet()
        {
            const int initialCapacity = 4;
            _dense = new T[initialCapacity];
            _sparse = new int[initialCapacity];
            _sparse.AsSpan().Fill(int.MaxValue);
        }

        /// <summary>
        ///     Gets or sets the element associated with the specified ID
        /// </summary>
        /// <param name="id">The external ID of the element</param>
        /// <returns>A reference to the element at the specified ID</returns>
        public ref T this[int id]
        {
            get
            {
                ref int index = ref EnsureSparseCapacityAndGetIndex(id);

                if (index == int.MaxValue)
                {
                    index = _nextIndex++;
                }

                return ref MemoryHelpers.GetValueOrResize(ref _dense, index);
            }
        }

        /// <summary>
        ///     Ensures the sparse array has capacity for the given ID and returns a reference to its entry
        /// </summary>
        /// <param name="id">The external ID to look up</param>
        /// <returns>A reference to the sparse array entry for the specified ID</returns>
        private ref int EnsureSparseCapacityAndGetIndex(int id)
        {
            int[] localSparse = _sparse;
            if (id < localSparse.Length)
            {
                return ref localSparse[id];
            }

            return ref ResizeArrayAndGet(ref _sparse, id);

            static ref int ResizeArrayAndGet(ref int[] arr, int index)
            {
                int prevLen = arr.Length;
                Array.Resize(ref arr, (int) BitOperations.RoundUpToPowerOf2((uint) index + 1));
                arr.AsSpan(prevLen).Fill(int.MaxValue);
                return ref arr[index];
            }
        }
    }
}