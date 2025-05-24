using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Benchmark.CustomCollections.Frugals.Elements.Tests;

namespace Alis.Benchmark.CustomCollections.Frugals.Elements
{
    /// <summary>
    ///     The frugal stack
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FastestFrugalStack<T>
    {
        /// <summary>
        ///     The buffer
        /// </summary>
        private T[] _buffer = [];

        /// <summary>
        ///     The next index
        /// </summary>
        private int _nextIndex = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="FastestFrugalStack"/> class
        /// </summary>
        public FastestFrugalStack()
        {
            _buffer = Array.Empty<T>();
            _nextIndex = 0;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="FastestFrugalStack"/> class
        /// </summary>
        /// <param name="capacity">The capacity</param>
        public FastestFrugalStack(int capacity)
        {
            if (capacity == 0)
            {
                _buffer = [];
                return;
            }

            _buffer = new T[capacity];
        }

        /// <summary>
        ///     Gets the value of the any
        /// </summary>
        public bool Any => _nextIndex != 0;


        /// <summary>
        ///     Pushes the comp
        /// </summary>
        /// <param name="comp">The comp</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Push(T comp)
        {
            T[] buffer = _buffer;
            if ((uint)_nextIndex < (uint)buffer.Length)
                buffer[_nextIndex++] = comp;
            else
                ResizeAndPush(comp);
        }

        /// <summary>
        ///     Resizes the and push using the specified comp
        /// </summary>
        /// <param name="comp">The comp</param>
        private void ResizeAndPush(in T comp)
        {
            FastTestArrayPool<T>.ResizeArrayFromPool(ref _buffer,
                _buffer.Length > 16 ? _buffer.Length << 1 : _buffer.Length + 2);
            _buffer[_nextIndex++] = comp;
        }

        /// <summary>
        ///     Tries the pop using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        public bool TryPop(out T value)
        {
            if (_nextIndex == 0)
            {
                value = default!;
                return false;
            }

            value = Pop();
            return true;
        }

        /// <summary>
        ///     Pops this instance
        /// </summary>
        /// <returns>The next</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Pop()
        {
            T next = _buffer[--_nextIndex];
            if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
                _buffer[_nextIndex] = default!;
            return next;
        }

        /// <summary>
        /// Removes the item
        /// </summary>
        /// <param name="item">The item</param>
        public void Remove(T item)
        {
            for (int i = 0; i < _nextIndex; i++)
                if (EqualityComparer<T>.Default.Equals(_buffer[i], item))
                {
                    _buffer[i] = Pop();
                    break;
                }
        }
        
        /// <summary>
        /// Converts the span
        /// </summary>
        /// <returns>A span of t</returns>
        public readonly Span<T> AsSpan()
        {
            return _buffer.AsSpan(0, _nextIndex);
        }

        /// <summary>
        /// The value
        /// </summary>
        public T this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _buffer[i];
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _buffer[i] = value;
        }
    }
}