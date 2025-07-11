using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Redifinition;

namespace Alis.Core.Ecs.Collections
{
    /// <summary>
    ///     The fastest table combining optimal performance traits, safe version.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FastestTable<T>
    {
        /// <summary>
        /// The buffer
        /// </summary>
        public T[] _buffer;

        /// <summary>
        /// Gets the value of the empty
        /// </summary>
        public static FastestTable<T> Empty => new() { _buffer = Array.Empty<T>() };

        /// <summary>
        /// Initializes a new instance of the <see cref="FastestTable"/> class
        /// </summary>
        /// <param name="size">The size</param>
        public FastestTable(int size)
        {
#if NET6_0_OR_GREATER
            _buffer = GC.AllocateUninitializedArray<T>((int)BitOperations.RoundUpToPowerOf2((uint)size));
#else
            _buffer = new T[(int)BitOperations.RoundUpToPowerOf2((uint)size)];
#endif
        }

#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
        /// <summary>
        /// The index
        /// </summary>
        public ref T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (index >= _buffer.Length) return ref ResizeGet(index);
                ref T r0 = ref _buffer[0];
                return ref Unsafe.Add(ref r0, index);
            }
        }
        #else
             /// <summary>
        /// The index
        /// </summary>
        public ref T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (index >= _buffer.Length) return ref ResizeGet(index);
                ref T r0 = ref MemoryMarshal.GetArrayDataReference(_buffer);
                return ref Unsafe.Add(ref r0, index);
            }
        }
        #endif
        
        /// <summary>
        ///     Resizes the get using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        private ref T ResizeGet(int index)
        {
            FastestArrayPool<T>.ResizeArrayFromPool(ref _buffer, (int)BitOperations.RoundUpToPowerOf2((uint)(index + 1)));
            return ref Unsafe.Add(ref _buffer[0], index);
        }

#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
        /// <summary>
        /// Unsafes the index no resize using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref T UnsafeIndexNoResize(int index)
        {
            ref T r0 = ref _buffer[0];
            return ref Unsafe.Add(ref r0, index);
        }
        
#else
/// <summary>
        /// Unsafes the index no resize using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref T UnsafeIndexNoResize(int index)
        {
            ref T r0 = ref MemoryMarshal.GetArrayDataReference(_buffer);
            return ref Unsafe.Add(ref r0, index);
        }

#endif
        /// <summary>
        /// Ensures the capacity using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        public void EnsureCapacity(int size)
        {
            if (_buffer.Length >= size)
                return;
            FastestArrayPool<T>.ResizeArrayFromPool(ref _buffer, size);
        }

        /// <summary>
        /// Converts the span
        /// </summary>
        /// <returns>A span of t</returns>
        public Span<T> AsSpan()
        {
#if NET6_0_OR_GREATER
            return MemoryMarshal.CreateSpan(ref MemoryMarshal.GetArrayDataReference(_buffer), _buffer.Length);
#else
            return _buffer.AsSpan();
#endif
        }


        /// <summary>
        /// Gets the value of the length
        /// </summary>
        public int Length => _buffer.Length;
    }
}