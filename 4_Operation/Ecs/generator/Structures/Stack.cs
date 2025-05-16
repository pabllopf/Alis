﻿using System;

namespace Alis.Core.Ecs.Generator.Structures
{
    internal ref struct Stack<T>
    {
        private T[] _array;
        private int _index;

        public Stack(int len)
        {
            _array = len == 0 ? [] : new T[len];
        }

        public void Push(T val)
        {
            if (_index >= _array.Length)
            {
                var newArr = new T[Math.Max(_array.Length * 2, 1)];
                _array.CopyTo(newArr.AsSpan());
                _array = newArr;
            }

            _array[_index++] = val;
        }

        public T[] ToArray() => _array?.Length == _index ? _array : _array.AsSpan().Slice(0, _index).ToArray();
    }
}
