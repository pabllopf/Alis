// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ArchetypeNeighborCache.cs
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

using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Alis.Core.Ecs.Collections
{
    //160 bits, 20 bytes
    /// <summary>
    ///     The archetype neighbor cache
    /// </summary>
    internal struct ArchetypeNeighborCache
    {
        //128 bits
        /// <summary>
        ///     The keys and values
        /// </summary>
        private InlineArray8<ushort> _keysAndValues;

        //32
        /// <summary>
        ///     The next index
        /// </summary>
        private int _nextIndex;

        /// <summary>
        ///     Traverses the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Traverse(ushort value)
        {
            //my simd code is garbage
            //#if NET7_0_OR_GREATER
            //        if(Vector256.IsHardwareAccelerated)
            //        {
            //            Vector256<ushort> bits = Vector256.Equals(Vector256.LoadUnsafe(ref _keysAndValues._0), Vector256.Create(value));
            //            int index = BitOperations.TrailingZeroCount(bits.ExtractMostSignificantBits());
            //            return index;
            //        }
            //#endif
            //TODO: better impl
            if (value == _keysAndValues._0)
                return 0;
            if (value == _keysAndValues._1)
                return 1;
            if (value == _keysAndValues._2)
                return 2;
            if (value == _keysAndValues._3)
                return 3;

            return 32;
        }

        /// <summary>
        ///     Lookups the index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The ushort</returns>
        public ushort Lookup(int index)
        {
            Debug.Assert(index < 4);
            return Unsafe.Add(ref _keysAndValues._4, index);
        }

        /// <summary>
        ///     Sets the key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="value">The value</param>
        public void Set(ushort key, ushort value)
        {
            Unsafe.Add(ref _keysAndValues._4, _nextIndex) = value;
            Unsafe.Add(ref _keysAndValues._0, _nextIndex) = key;
            _nextIndex = (_nextIndex + 1) & 3;
        }
    }
}