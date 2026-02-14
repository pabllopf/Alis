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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs.Kernel
{
    /// <summary>
    ///     A wrapper ref struct over a reference to a <typeparamref name="T" />
    /// </summary>
    /// <typeparam name="T">The type this <see cref="Ref{T}" /> wraps over</typeparam>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct Ref<T>
    {
#if NET7_0_OR_GREATER
        internal Ref(T[] compArr, int index) => _comp = ref Unsafe.Add(ref compArr[0], index);
        internal Ref(Span<T> compSpan, int index) => _comp = ref Unsafe.Add(ref MemoryMarshal.GetReference(compSpan), index);
        internal Ref(ComponentStorage<T> compSpan, int index) => _comp = ref compSpan[index];

        private ref T _comp;

        /// <summary>
        ///     The wrapped reference to <typeparamref name="T" />
        /// </summary>
        public readonly ref T Value => ref _comp;

        /// <summary>
        ///     Extracts the wrapped <typeparamref name="T" /> from this <see cref="Ref{T}" />
        /// </summary>
        public static implicit operator T(Ref<T> @ref) => @ref.Value;

        /// <summary>
        ///     Calls the wrapped <typeparamref name="T" />'s ToString() function, or returns null.
        /// </summary>
        /// <returns>A string representation of the wrapped <typeparamref name="T" />'s</returns>
        public readonly override string ToString() => Value?.ToString();
#elif (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && !NET7_0_OR_GREATER
        internal Ref(T[] compArr, int index)
        {
            _data = compArr;
            _offset = index;
        }

        internal Ref(Span<T> compSpan, int index)
        {
            _data = compSpan;
            _offset = index;
        }

        internal Ref(ComponentStorage<T> compSpan, int index)
        {
            _data = compSpan.AsSpan();
            _offset = index;
        }

        private readonly Span<T> _data;
        private readonly int _offset;

        /// <summary>
        ///     The wrapped reference to <typeparamref name="T" />
        /// </summary>
        public readonly ref T Value => ref Unsafe.Add(ref _data[0], _offset);

        /// <summary>
        ///     Extracts the wrapped <typeparamref name="T" /> from this <see cref="Ref{T}" />
        /// </summary>
        public static implicit operator T(Ref<T> @ref)
        {
            return @ref.Value;
        }

        /// <summary>
        ///     Calls the wrapped <typeparamref name="T" />'s ToString() function, or returns null.
        /// </summary>
        /// <returns>A string representation of the wrapped <typeparamref name="T" />'s</returns>
        public readonly override string ToString()
        {
            return Value?.ToString();
        }
#endif
    }
}