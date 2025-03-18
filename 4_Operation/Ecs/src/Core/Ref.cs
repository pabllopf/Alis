// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Ref.cs
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
using Frent.Updating.Runners;

namespace Frent.Core
{
    /// <summary>
    ///     A wrapper ref struct over a reference to a <typeparamref name="T" />
    /// </summary>
    /// <typeparam name="T">The type this <see cref="Ref{T}" /> wraps over</typeparam>
    public ref struct Ref<T>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Ref" /> class
        /// </summary>
        /// <param name="compArr">The comp arr</param>
        /// <param name="index">The index</param>
        internal Ref(T[] compArr, int index)
        {
            _data = compArr;
            _offset = index;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Ref" /> class
        /// </summary>
        /// <param name="compSpan">The comp span</param>
        /// <param name="index">The index</param>
        internal Ref(Span<T> compSpan, int index)
        {
            _data = compSpan;
            _offset = index;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Ref" /> class
        /// </summary>
        /// <param name="compSpan">The comp span</param>
        /// <param name="index">The index</param>
        internal Ref(ComponentStorage<T> compSpan, int index)
        {
            _data = compSpan.AsSpan();
            _offset = index;
        }

        /// <summary>
        ///     The data
        /// </summary>
        private readonly Span<T> _data;

        /// <summary>
        ///     The offset
        /// </summary>
        private readonly int _offset;

        /// <summary>
        ///     The wrapped reference to <typeparamref name="T" />
        /// </summary>
        public readonly ref T Value => ref _data.UnsafeSpanIndex(_offset);

        /// <summary>
        ///     Extracts the wrapped <typeparamref name="T" /> from this <see cref="Ref{T}" />
        /// </summary>
        public static implicit operator T(Ref<T> @ref) => @ref.Value;

        /// <summary>
        ///     Calls the wrapped <typeparamref name="T" />'s ToString() function, or returns null.
        /// </summary>
        /// <returns>A string representation of the wrapped <typeparamref name="T" />'s</returns>
        public readonly override string? ToString() => Value?.ToString();
    }
}