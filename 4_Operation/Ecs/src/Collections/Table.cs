﻿using System;
using Alis.Core.Ecs.Buffers;
using Alis.Core.Ecs.Core;
using System.Numerics;
using Alis.Core.Ecs.Core.Memory;

namespace Alis.Core.Ecs.Collections
{
    public struct Table<T>(int size)
    {
        public static Table<T> Empty => new()
        {
            _buffer = []
        };

        internal T[] _buffer = new T[size];

        public ref T this[int index]
        {
            get
            {
                var buffer = _buffer;
                if ((uint)index < (uint)buffer.Length)
                    return ref buffer[index];
                return ref ResizeGet(index);
            }
        }

        private ref T ResizeGet(int index)
        {
            FastStackArrayPool<T>.ResizeArrayFromPool(ref _buffer, (int)BitOperations.RoundUpToPowerOf2((uint)(index + 1)));
            return ref _buffer.UnsafeArrayIndex(index);
        }

        public ref T UnsafeIndexNoResize(int index)
        {
            return ref _buffer.UnsafeArrayIndex(index);
        }

        public void EnsureCapacity(int size)
        {
            if (_buffer.Length >= size)
                return;
            FastStackArrayPool<T>.ResizeArrayFromPool(ref _buffer, size);
        }

        public Span<T> AsSpan() => _buffer.AsSpan();
    }
}