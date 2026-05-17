// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NativeArray.cs
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

namespace Alis.Benchmark.CustomCollections.Arrays
{
    /// <summary>
    ///     A sealed native memory array wrapper for unmanaged types, providing direct access to unmanaged memory with span support.
    /// </summary>
    /// <typeparam name="T">The unmanaged element type.</typeparam>
    public sealed class NativeArray<T> : IDisposable where T : unmanaged
    {
        /// <summary>
        ///     The underlying safe memory handle for unmanaged allocation.
        /// </summary>
        private readonly SafeMemoryHandle _handle;

        /// <summary>
        ///     The number of elements in the array.
        /// </summary>
        private int _length;

        /// <summary>
        ///     Initializes a new instance of the <see cref="NativeArray{T}"/> class with the specified element count.
        /// </summary>
        /// <param name="length">The number of elements to allocate.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="length"/> is less than or equal to zero.</exception>
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
        ///     Gets the number of elements in the native array.
        /// </summary>
        public int Length => _length;

        /// <summary>
        ///     Gets a reference to the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to reference.</param>
        /// <returns>A reference to the element at the specified index.</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown when <paramref name="index"/> is out of range.</exception>
        public ref T this[int index]
        {
            get
            {
                if ((uint) index >= (uint) _length)
                {
                    throw new IndexOutOfRangeException();
                }

                return ref AsSpan()[index];
            }
        }

        /// <summary>
        ///     Releases the underlying unmanaged memory.
        /// </summary>
        public void Dispose() => _handle.Dispose();

        /// <summary>
        ///     Resizes the native array to the specified new element count.
        /// </summary>
        /// <param name="newSize">The new number of elements.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="newSize"/> is less than or equal to zero.</exception>
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
        ///     Returns a span over the entire native array.
        /// </summary>
        /// <returns>A span of <typeparamref name="T"/> covering the native memory.</returns>
        public Span<T> AsSpan() => MemoryMarshal.Cast<byte, T>(_handle.GetSpan(_length * Unsafe.SizeOf<T>()));

        /// <summary>
        ///     Returns a span containing the first <paramref name="len"/> elements of the native array.
        /// </summary>
        /// <param name="len">The number of elements to include in the span.</param>
        /// <returns>A span containing the specified number of elements from the start of the array.</returns>
        public Span<T> AsSpanLen(int len) => AsSpan().Slice(0, len);
    }

    /// <summary>
    ///     Provides a safe wrapper for unmanaged memory allocations using <see cref="Marshal"/> methods.
    /// </summary>
    internal sealed class SafeMemoryHandle : SafeHandle
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SafeMemoryHandle"/> class, allocating unmanaged memory of the specified size.
        /// </summary>
        /// <param name="byteSize">The number of bytes to allocate.</param>
        public SafeMemoryHandle(int byteSize) : base(IntPtr.Zero, true)
        {
            SetHandle(Marshal.AllocHGlobal(byteSize));
        }

        /// <summary>
        ///     Gets the pointer to the underlying unmanaged memory.
        /// </summary>
        public IntPtr Pointer => handle;

        /// <summary>
        ///     Gets a value indicating whether the handle is invalid.
        /// </summary>
        public override bool IsInvalid => handle == IntPtr.Zero;

        /// <summary>
        ///     Reallocates the unmanaged memory to the specified new size.
        /// </summary>
        /// <param name="newSize">The new size in bytes.</param>
        public void Realloc(int newSize)
        {
            SetHandle(Marshal.ReAllocHGlobal(handle, newSize));
        }

        /// <summary>
        ///     Copies the unmanaged memory into a managed byte span of the specified size.
        /// </summary>
        /// <param name="size">The number of bytes to copy.</param>
        /// <returns>A span containing the copied bytes.</returns>
        public Span<byte> GetSpan(int size)
        {
            byte[] tempArray = new byte[size];
            Marshal.Copy(handle, tempArray, 0, size);
            return tempArray;
        }

        /// <summary>
        ///     Releases the underlying unmanaged memory.
        /// </summary>
        /// <returns>True if the handle was released successfully.</returns>
        protected override bool ReleaseHandle()
        {
            if (!IsInvalid)
            {
                Marshal.FreeHGlobal(handle);
                SetHandle(IntPtr.Zero);
            }

            return true;
        }
    }
}