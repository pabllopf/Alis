

using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Collections
{
    /// <summary>
    ///     The fastest table combining optimal performance traits, safe version.
    /// </summary>
    /// <remarks>
    ///     Memory layout optimized: 8 bytes total (T[] reference)
    ///     Pack = 8 for optimal alignment with reference types on 64-bit architectures
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct FastestTable<T>
    {
        /// <summary>
        ///     The buffer
        /// </summary>
        public T[] _buffer;

        /// <summary>
        ///     Gets the value of the empty
        /// </summary>
        public static FastestTable<T> Empty => new FastestTable<T> {_buffer = Array.Empty<T>()};

        /// <summary>
        ///     Initializes a new instance of the  class
        /// </summary>
        /// <param name="size">The size</param>
        public FastestTable(int size) => _buffer = new T[(int) BitOperations.RoundUpToPowerOf2((uint) size)];


        /// <summary>
        ///     The index
        /// </summary>
        public ref T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (index >= _buffer.Length)
                {
                    return ref ResizeGet(index);
                }

                ref T r0 = ref _buffer[0];
                return ref Unsafe.Add(ref r0, index);
            }
        }

        /// <summary>
        ///     Resizes the get using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        private ref T ResizeGet(int index)
        {
            FastestArrayPool<T>.ResizeArrayFromPool(ref _buffer, (int) BitOperations.RoundUpToPowerOf2((uint) (index + 1)));
            return ref Unsafe.Add(ref _buffer[0], index);
        }

        /// <summary>
        ///     Unsafes the index no resize using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref T UnsafeIndexNoResize(int index)
        {
            ref T r0 = ref _buffer[0];
            return ref Unsafe.Add(ref r0, index);
        }

        /// <summary>
        ///     Ensures the capacity using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        public void EnsureCapacity(int size)
        {
            if (_buffer.Length >= size)
            {
                return;
            }

            FastestArrayPool<T>.ResizeArrayFromPool(ref _buffer, size);
        }

        /// <summary>
        ///     Converts the span
        /// </summary>
        /// <returns>A span of t</returns>
        public Span<T> AsSpan() => _buffer.AsSpan();


        /// <summary>
        ///     Gets the value of the length
        /// </summary>
        public int Length => _buffer.Length;
    }
}