using System;

namespace Alis.Core.Ecs.Generator.Structures
{
    /// <summary>
    /// The stack
    /// </summary>
    internal ref struct Stack<T>
    {
        /// <summary>
        /// The array
        /// </summary>
        private T[] _array;
        /// <summary>
        /// The index
        /// </summary>
        private int _index;

        /// <summary>
        /// Initializes a new instance of the <see cref="Stack"/> class
        /// </summary>
        /// <param name="len">The len</param>
        public Stack(int len)
        {
            _array = len == 0 ? [] : new T[len];
        }

        /// <summary>
        /// Pushes the val
        /// </summary>
        /// <param name="val">The val</param>
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

        /// <summary>
        /// Returns the array
        /// </summary>
        /// <returns>The array</returns>
        public T[] ToArray() => _array?.Length == _index ? _array : _array.AsSpan().Slice(0, _index).ToArray();
    }
}
