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

using Alis.Core.Aspect.Math.Matrix;

namespace Alis.Core.Physic.Common
{
    /// <summary>
    ///     A fixed-size array of three elements of type T, optimized for performance.
    /// </summary>
    /// <typeparam name="T">The type of elements stored in the array.</typeparam>
    /// <remarks>
    ///     This struct provides a memory-efficient alternative to standard .NET arrays
    ///     for small fixed-size collections. It avoids heap allocations and provides
    ///     bounds-checked access with zero-overhead indexer when possible.
    ///     Ideal for use in performance-critical physics calculations where allocation
    ///     overhead must be minimized. Commonly used for representing 3D vectors or
    ///     collision manifold points.
    /// </remarks>
    /// <example>
    ///     <code>
    ///     FixedArray3&lt;Vector2F&gt; points = new FixedArray3&lt;Vector2F&gt;();
    ///     points[0] = new Vector2F(0, 0);
    ///     points[1] = new Vector2F(1, 0);
    ///     points[2] = new Vector2F(0, 1);
    ///     </code>
    /// </example>
    public struct FixedArray3<T>
    {
        /// <summary>
        ///     The first element at index 0.
        /// </summary>
        internal T _value0;

        /// <summary>
        ///     The second element at index 1.
        /// </summary>
        internal T _value1;

        /// <summary>
        ///     The third element at index 2.
        /// </summary>
        internal T _value2;

        /// <summary>
        ///     Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element (must be 0, 1, or 2).</param>
        /// <value>
        ///     The element at the specified index.
        /// </value>
        /// <returns>The element at the specified index.</returns>
        /// <exception cref="CustomIndexOutOfRangeException">
        ///     Thrown when index is less than 0 or greater than 2.
        /// </exception>
        public T this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return _value0;
                    case 1:
                        return _value1;
                    case 2:
                        return _value2;
                    default:
                        throw new CustomIndexOutOfRangeException();
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        _value0 = value;
                        break;
                    case 1:
                        _value1 = value;
                        break;
                    case 2:
                        _value2 = value;
                        break;
                    default:
                        throw new CustomIndexOutOfRangeException();
                }
            }
        }
    }
}