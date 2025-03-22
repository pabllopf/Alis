using System;
using System.Numerics;
using Alis.Core.Ecs.Buffers;
using Alis.Core.Ecs.Core.Memory;

namespace Alis.Core.Ecs.Collections
{
    /// <summary>
    /// The table
    /// </summary>
    internal struct Table<T>(int size)
    {
        /// <summary>
        /// Gets the value of the empty
        /// </summary>
        public static Table<T> Empty => new()
        {
            _buffer = []
        };

        /// <summary>
        /// The size
        /// </summary>
        internal T[] _buffer = new T[size];

        /// <summary>
        /// The index
        /// </summary>
        public ref T this[int index]
        {
            get
            {
                var buffer = _buffer;
                if ((uint)index < (uint)buffer.Length)
                    return ref buffer.UnsafeArrayIndex(index);
                return ref ResizeGet(index);
            }
        }

        /// <summary>
        /// Resizes the get using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        private ref T ResizeGet(int index)
        {
            FastStackArrayPool<T>.ResizeArrayFromPool(ref _buffer, (int)BitOperations.RoundUpToPowerOf2((uint)(index + 1)));
            return ref _buffer.UnsafeArrayIndex(index);
        }

        /// <summary>
        /// Unsafes the index no resize using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        public ref T UnsafeIndexNoResize(int index)
        {
            return ref _buffer.UnsafeArrayIndex(index);
        }

        /// <summary>
        /// Ensures the capacity using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        public void EnsureCapacity(int size)
        {
            if (_buffer.Length >= size)
                return;
            FastStackArrayPool<T>.ResizeArrayFromPool(ref _buffer, size);
        }

        /// <summary>
        /// Converts the span
        /// </summary>
        /// <returns>A span of t</returns>
        public Span<T> AsSpan() => _buffer.AsSpan();
    }
}