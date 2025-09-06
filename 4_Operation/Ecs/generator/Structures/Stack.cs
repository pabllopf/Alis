// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Stack.cs
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

namespace Alis.Core.Ecs.Generator.Structures
{
    /// <summary>
    ///     The stack
    /// </summary>
    internal ref struct Stack<T>
    {
        /// <summary>
        ///     The array
        /// </summary>
        private T[] _array;

        /// <summary>
        ///     The index
        /// </summary>
        private int _index;

        /// <summary>
        ///     Initializes a new instance of the  class
        /// </summary>
        /// <param name="len">The len</param>
        public Stack(int len)
        {
            _array = len == 0 ? new T[0] : new T[len];
            _index = 0;
        }

        /// <summary>
        ///     Pushes the val
        /// </summary>
        /// <param name="val">The val</param>
        public void Push(T val)
        {
            if (_index >= _array.Length)
            {
                T[] newArr = new T[Math.Max(_array.Length * 2, 1)];
                _array.CopyTo(newArr.AsSpan());
                _array = newArr;
            }

            _array[_index++] = val;
        }

        /// <summary>
        ///     Returns the array
        /// </summary>
        /// <returns>The array</returns>
        public T[] ToArray() => _array?.Length == _index ? _array : _array.AsSpan().Slice(0, _index).ToArray();
    }
}