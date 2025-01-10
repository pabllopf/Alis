// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FixedArray3.cs
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

using System.Collections;
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Matrix;

namespace Alis.Core.Physic.Common.Decomposition.CDT.Util
{
    /// <summary>
    ///     The fixed array
    /// </summary>
    internal struct FixedArray3<T> : IEnumerable<T> where T : class
    {
        /// <summary>
        ///     The
        /// </summary>
        public T _0, _1, _2;

        /// <summary>
        ///     The index out of range exception
        /// </summary>
        public T this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return _0;
                    case 1:
                        return _1;
                    case 2:
                        return _2;
                    default:
                        throw new CustomIndexOutOfRangeException();
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        _0 = value;
                        break;
                    case 1:
                        _1 = value;
                        break;
                    case 2:
                        _2 = value;
                        break;
                    default:
                        throw new CustomIndexOutOfRangeException();
                }
            }
        }

        #region IEnumerable<T> Members

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

        #endregion

        /// <summary>
        ///     Describes whether this instance contains
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        public bool Contains(T value)
        {
            for (int i = 0; i < 3; ++i)
            {
                if (this[i] == value)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        ///     Indexes the of using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        public int IndexOf(T value)
        {
            for (int i = 0; i < 3; ++i)
            {
                if (this[i] == value)
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
            _0 = _1 = _2 = null;
        }

        /// <summary>
        ///     Clears the value
        /// </summary>
        /// <param name="value">The value</param>
        public void Clear(T value)
        {
            for (int i = 0; i < 3; ++i)
            {
                if (this[i] == value)
                {
                    this[i] = null;
                }
            }
        }

        /// <summary>
        ///     Enumerates this instance
        /// </summary>
        /// <returns>An enumerable of t</returns>
        private IEnumerable<T> Enumerate()
        {
            for (int i = 0; i < 3; ++i)
            {
                yield return this[i];
            }
        }
    }
}