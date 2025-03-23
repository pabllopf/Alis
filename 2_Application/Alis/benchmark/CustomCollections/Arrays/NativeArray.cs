using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Alis.Benchmark.CustomCollections.Arrays
{
    /// <summary>
    /// The native array class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public sealed class NativeArray<T> : IDisposable where T : unmanaged
    {
        /// <summary>
        /// The handle
        /// </summary>
        private SafeMemoryHandle _handle;
        
        /// <summary>
        /// The length
        /// </summary>
        private int _length;

        /// <summary>
        /// Gets the value of the length
        /// </summary>
        public int Length => _length;

        /// <summary>
        /// The index
        /// </summary>
        public ref T this[int index]
        {
            
            get
            {
                if ((uint)index >= (uint)_length)
                {
                    throw new IndexOutOfRangeException();
                }

                return ref AsSpan()[index];
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="NativeArray{T}"/> class
        /// </summary>
        /// <param name="length">The length</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public NativeArray(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            _length = length;
            _handle = new SafeMemoryHandle(length * Unsafe.SizeOf<T>());
        }

        /// <summary>
        /// Resizes the new size
        /// </summary>
        /// <param name="newSize">The new size</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Resize(int newSize)
        {
            if (newSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(newSize));
            }

            _handle.Realloc(newSize * Unsafe.SizeOf<T>());
            _length = newSize;
        }

        /// <summary>
        /// Converts the span
        /// </summary>
        /// <returns>A span of t</returns>
        public Span<T> AsSpan() => MemoryMarshal.Cast<byte, T>(_handle.GetSpan(_length * Unsafe.SizeOf<T>()));

        /// <summary>
        /// Converts the span len using the specified len
        /// </summary>
        /// <param name="len">The len</param>
        /// <returns>A span of t</returns>
        public Span<T> AsSpanLen(int len)
        {
            Debug.Assert(len <= _length);
            return AsSpan().Slice(0, len);
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose() => _handle.Dispose();
    }

    /// <summary>
    /// The safe memory handle class
    /// </summary>
    /// <seealso cref="SafeHandle"/>
    internal sealed class SafeMemoryHandle : SafeHandle
    {
        /// <summary>
        /// Gets the value of the pointer
        /// </summary>
        public IntPtr Pointer => handle;

        /// <summary>
        /// Initializes a new instance of the <see cref="SafeMemoryHandle"/> class
        /// </summary>
        /// <param name="byteSize">The byte size</param>
        public SafeMemoryHandle(int byteSize) : base(IntPtr.Zero, true)
        {
            SetHandle(Marshal.AllocHGlobal(byteSize));
        }

        /// <summary>
        /// Reallocs the new size
        /// </summary>
        /// <param name="newSize">The new size</param>
        /// <exception cref="ObjectDisposedException"></exception>
        public void Realloc(int newSize)
        {
            if (IsInvalid)
            {
                throw new ObjectDisposedException(nameof(SafeMemoryHandle));
            }

            SetHandle(Marshal.ReAllocHGlobal(handle, (IntPtr)newSize));
        }

        /// <summary>
        /// Gets the span using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        /// <exception cref="ObjectDisposedException"></exception>
        /// <returns>The temp array</returns>
        public Span<byte> GetSpan(int size)
        {
            if (IsInvalid)
            {
                throw new ObjectDisposedException(nameof(SafeMemoryHandle));
            }

            byte[] tempArray = new byte[size];
            Marshal.Copy(handle, tempArray, 0, size);
            return tempArray;
        }
        
        /// <summary>
        /// Releases the handle
        /// </summary>
        /// <returns>The bool</returns>
        protected override bool ReleaseHandle()
        {
            if (!IsInvalid)
            {
                Marshal.FreeHGlobal(handle);
                SetHandle(IntPtr.Zero);
            }
            return true;
        }

        /// <summary>
        /// Gets the value of the is invalid
        /// </summary>
        public override bool IsInvalid => handle == IntPtr.Zero;
    }
}
