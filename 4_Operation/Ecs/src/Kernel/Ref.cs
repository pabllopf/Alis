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
///     A wrapper ref struct over a reference to a <typeparamref name="T" />.
///     This struct provides a safe way to hold a reference to a value type or reference type
///     without boxing allocations, useful for high-performance scenarios like ECS systems.
///     The ref struct ensures the reference lives only on the stack and cannot be escaped to the heap.
/// </summary>
/// <typeparam name="T">The type this wrapper references.</typeparam>
/// <remarks>
///     Memory layout optimized: Span (16 bytes) + int (4 bytes)
///     Total: 20 bytes + 4 bytes padding = 24 bytes aligned
///     Pack = 4 for optimal alignment with Span structure
///     
///     Usage example:
///     <code>
///     // Assuming we have a component array
///     Transform[] transforms = new Transform[100];
///     
///     // Create a Ref to access a specific element
///     Ref&lt;Transform&gt; transformRef = new Ref&lt;Transform&gt;(transforms, 42);
///     
///     // Access the value (returns a ref)
///     ref Transform transform = ref transformRef.Value;
///     
///     // Modify the value directly in the array
///     transform.Position = new Vector2F(10, 20);
///     </code>
/// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public ref struct Ref<T>
    {
        /// <summary>
        ///     Initializes a new instance of the  class
        /// </summary>
        /// <param name="compArr">The comp arr</param>
        /// <param name="index">The index</param>
        internal Ref(T[] compArr, int index)
        {
            _data = compArr;
            _offset = index;
        }

        /// <summary>
        ///     Initializes a new instance of the  class
        /// </summary>
        /// <param name="compSpan">The comp span</param>
        /// <param name="index">The index</param>
        internal Ref(Span<T> compSpan, int index)
        {
            _data = compSpan;
            _offset = index;
        }

        /// <summary>
        ///     Initializes a new instance of the  class
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
        public readonly ref T Value => ref Unsafe.Add(ref _data[0], _offset);

        /// <summary>
        ///     Extracts the wrapped <typeparamref name="T" /> from this  />
        /// </summary>
        public static implicit operator T(Ref<T> @ref) => @ref.Value;

        /// <summary>
        ///     Calls the wrapped <typeparamref name="T" />'s ToString() function, or returns null.
        /// </summary>
        /// <returns>A string representation of the wrapped <typeparamref name="T" />'s</returns>
        public readonly override string ToString() => Value?.ToString();
    }
}