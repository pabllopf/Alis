using System;
using System.Numerics;
using System.Runtime.InteropServices;
using Alis.Benchmark.CustomCollections.ArrayPools.Elements;
using Alis.Core.Ecs.Redifinition;

namespace Alis.Benchmark.CustomCollections.Tables.Elements
{
    /// <summary>
    ///     The table
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    
    public struct NormalTable<T>(int size)
    {
        /// <summary>
        ///     Gets the value of the empty
        /// </summary>
        public static NormalTable<T> Empty => new()
        {
            Buffer = []
        };

        /// <summary>
        ///     The size
        /// </summary>
        internal T[] Buffer = new T[size];

        /// <summary>
        ///     The index
        /// </summary>
        public ref T this[int index]
        {
            get
            {
                T[] buffer = Buffer;
                if ((uint)index < (uint)buffer.Length)
                    return ref buffer[index];
                return ref ResizeGet(index);
            }
        }

        /// <summary>
        ///     Resizes the get using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        private ref T ResizeGet(int index)
        {
            FastArrayPool<T>.ResizeArrayFromPool(ref Buffer, (int)BitOperations.RoundUpToPowerOf2((uint)(index + 1)));
            return ref Buffer.UnsafeArrayIndex(index);
        }

        /// <summary>
        ///     Unsafes the index no resize using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        public ref T UnsafeIndexNoResize(int index)
        {
            return ref Buffer.UnsafeArrayIndex(index);
        }

        /// <summary>
        ///     Ensures the capacity using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        public void EnsureCapacity(int size)
        {
            if (Buffer.Length >= size)
                return;
            FastArrayPool<T>.ResizeArrayFromPool(ref Buffer, size);
        }

        /// <summary>
        ///     Converts the span
        /// </summary>
        /// <returns>A span of t</returns>
        public Span<T> AsSpan()
        {
            return Buffer.AsSpan();
        }
    }
}