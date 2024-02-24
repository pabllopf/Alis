// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FixedArray2.cs
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
using System.Collections;
using System.Collections.Generic;

namespace Alis.Core.Physic.Shared.Optimization
{
    /// <summary>
    ///     The fixed array
    /// </summary>
    public struct FixedArray2<T> : IEnumerable<T>
    {
        /// <summary>
        ///     The value
        /// </summary>
        public T Value0;

        /// <summary>
        ///     The value
        /// </summary>
        public T Value1;

        /// <summary>
        ///     The index
        /// </summary>
        public T this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return Value0;
                    case 1:
                        return Value1;
                    default:
                        throw new IndexOutOfRangeException(nameof(index));
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        Value0 = value;
                        break;
                    case 1:
                        Value1 = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException(nameof(index));
                }
            }
        }

        /// <summary>
        ///     Gets the enumerator
        /// </summary>
        /// <returns>An enumerator of t</returns>
        public IEnumerator<T> GetEnumerator() => Enumerate().GetEnumerator();

        /// <summary>
        ///     Gets the enumerator
        /// </summary>
        /// <returns>The enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        ///     Indexes the of using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        public int IndexOf(T value)
        {
            for (int i = 0; i < 2; ++i)
            {
                if (this[i].Equals(value))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        ///     Clears this instance
        /// </summary>
        public void Clear()
        {
            Value0 = Value1 = default(T);
        }

        /// <summary>
        ///     Enumerates this instance
        /// </summary>
        /// <returns>An enumerable of t</returns>
        private IEnumerable<T> Enumerate()
        {
            for (int i = 0; i < 2; ++i)
            {
                yield return this[i];
            }
        }
    }
}