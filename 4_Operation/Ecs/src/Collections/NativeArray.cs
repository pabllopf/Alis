using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Collections
{
#if (!NETSTANDARD && !NETFRAMEWORK && !NETCOREAPP) || NET6_0_OR_GREATER
//Do not pass around this struct by value!!!
//You must use the constructor when initalizating!!!

#pragma warning disable CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
//As long as the user always uses the ctor, it would throw when managed type is used
    /// <summary>
    /// The native array
    /// </summary>
    internal unsafe struct NativeArray<T> : IDisposable
    {
        /// <summary>
        /// Gets the value of the length
        /// </summary>
        public int Length => _length;

        /// <summary>
        /// The 
        /// </summary>
        private static readonly nuint Size = (nuint)Unsafe.SizeOf<T>();
        /// <summary>
        /// The array
        /// </summary>
        private T* _array;
        /// <summary>
        /// The length
        /// </summary>
        private int _length;

        /// <summary>
        /// The index
        /// </summary>
        public ref T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return ref _array[index];
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NativeArray"/> class
        /// </summary>
        /// <param name="length">The length</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="InvalidOperationException">Cannot store managed objects in native code</exception>
        public NativeArray(int length)
        {
            if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
                throw new InvalidOperationException("Cannot store managed objects in native code");
            if (length < 1)
                throw new ArgumentOutOfRangeException();

            _length = length;
            _array = (T*)NativeMemory.Alloc((nuint)length * Size);
        }

        /// <summary>
        /// Resizes the size
        /// </summary>
        /// <param name="size">The size</param>
        public void Resize(int size)
        {
            _length = size;
            _array = (T*)NativeMemory.Realloc(_array, Size * (nuint)size);
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            NativeMemory.Free(_array);
            //null reference isnt as bad as a use after free, right?
            _array = (T*)0;
        }

        /// <summary>
        /// Converts the span
        /// </summary>
        /// <returns>A span of t</returns>
        public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref Unsafe.AsRef<T>(_array), _length);
        /// <summary>
        /// Converts the span len using the specified len
        /// </summary>
        /// <param name="len">The len</param>
        /// <returns>A span of t</returns>
        public Span<T> AsSpanLen(int len)
        {
            System.Diagnostics.Debug.Assert(len <= _length);
            return MemoryMarshal.CreateSpan(ref Unsafe.AsRef<T>(_array), len);
        }
    }
#endif
}