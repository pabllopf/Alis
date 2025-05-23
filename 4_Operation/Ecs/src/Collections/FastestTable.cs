using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Core.Memory;

namespace Alis.Core.Ecs.Collections
{
    /// <summary>
    ///     The fastest table combining optimal performance traits, safe version.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FastestTable<T>
    {
        public T[] _buffer;

        public static FastestTable<T> Empty => new() { _buffer = Array.Empty<T>() };

        public FastestTable(int size)
        {
#if NET6_0_OR_GREATER
            _buffer = GC.AllocateUninitializedArray<T>((int)BitOperations.RoundUpToPowerOf2((uint)size));
#else
            _buffer = new T[(int)BitOperations.RoundUpToPowerOf2((uint)size)];
#endif
        }

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
        
        /// <summary>
        ///     Resizes the get using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        private ref T ResizeGet(int index)
        {
            FastestArrayPool<T>.ResizeArrayFromPool(ref _buffer, (int)BitOperations.RoundUpToPowerOf2((uint)(index + 1)));
            return ref _buffer.UnsafeArrayIndex(index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref T UnsafeIndexNoResize(int index)
        {
            ref T r0 = ref MemoryMarshal.GetArrayDataReference(_buffer);
            return ref Unsafe.Add(ref r0, index);
        }

        public void EnsureCapacity(int size)
        {
            if (_buffer.Length >= size)
                return;
            FastestArrayPool<T>.ResizeArrayFromPool(ref _buffer, size);
        }

        public Span<T> AsSpan()
        {
#if NET6_0_OR_GREATER
            return MemoryMarshal.CreateSpan(ref MemoryMarshal.GetArrayDataReference(_buffer), _buffer.Length);
#else
            return _buffer.AsSpan();
#endif
        }


        public int Length => _buffer.Length;
    }
}