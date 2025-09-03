// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastestStack.cs
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
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Collections;

namespace Alis.Benchmark.CustomCollections.Stacks.Elements
{
    /// <summary>
    ///     The fastest stack class
    /// </summary>
    /// <seealso cref="ICollection" />
    /// <seealso cref="IReadOnlyCollection{T}" />
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FastestStack<T> : ICollection,
        IReadOnlyCollection<T>, IDisposable
    {
        /// <summary>
        ///     The array
        /// </summary>
        private T[] _array;

        /// <summary>
        ///     The size
        /// </summary>
        private int _size;

        /// <summary>
        ///     The version
        /// </summary>
        private int _version;

        /// <summary>
        ///     The default capacity
        /// </summary>
        private const int DefaultCapacity = 32;

        /// <summary>
        ///     The max array length
        /// </summary>
        private const int MaxArrayLength = 0X7FEFFFFF;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FastestStack{T}" /> class
        /// </summary>
        public FastestStack() => _array = Array.Empty<T>();

        // Create a stack with a specific initial capacity.  The initial capacity
        // must be a non-negative number.
        /// <summary>
        ///     Initializes a new instance of the <see cref="FastestStack{T}" /> class
        /// </summary>
        /// <param name="capacity">The capacity</param>
        public FastestStack(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "ArgumentOutOfRange_NeedNonNegNum");
            }

            if (capacity == 0)
            {
                _array = [];
                return;
            }

            _array = new T[capacity];
        }

        // Fills a Stack with the contents of a particular collection.  The items are
        // pushed onto the stack in the same order they are read by the enumerator.
        /// <summary>
        ///     Initializes a new instance of the <see cref="FastestStack{T}" /> class
        /// </summary>
        /// <param name="collection">The collection</param>
        public FastestStack(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            _array = EnumerableHelpers.ToArray(collection, out _size);
        }

        /// <summary>
        ///     Gets the value of the count
        /// </summary>
        public int Count => _size;


        /// <summary>
        ///     Gets the total numbers of elements the internal data structure can hold without resizing.
        /// </summary>
        public int Capacity => _array.Length;

        /// <inheritdoc cref="ICollection{T}" />
        bool ICollection.IsSynchronized => false;

        /// <summary>
        ///     Gets the value of the sync root
        /// </summary>
        object ICollection.SyncRoot => this;

        /// <summary>
        ///     Gets the value of the any
        /// </summary>
        public bool Any => _size > 0;

        // Removes all Objects from the Stack.
        /// <summary>
        ///     Clears this instance
        /// </summary>
        public void Clear()
        {
            if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
            {
                Array.Clear(_array, 0,
                    _size); // Don't need to doc this but we clear the elements so that the gc can reclaim the references.
            }

            _size = 0;
            _version++;
        }

        /// <summary>
        ///     Containses the item
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>The bool</returns>
        public bool Contains(T item) => (_size != 0) && (Array.LastIndexOf(_array, item, _size - 1) != -1);

        // Copies the stack into an array.
        /// <summary>
        ///     Copies the to using the specified array
        /// </summary>
        /// <param name="array">The array</param>
        /// <param name="arrayIndex">The array index</param>
        /// <exception cref="ArgumentOutOfRangeException">ArgumentOutOfRange_NeedNonNegNum</exception>
        /// <exception cref="ArgumentException">Argument_InvalidOffLen</exception>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (arrayIndex < 0 || arrayIndex > array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), arrayIndex, "ArgumentOutOfRange_NeedNonNegNum");
            }

            if (array.Length - arrayIndex < _size)
            {
                throw new ArgumentException("Argument_InvalidOffLen");
            }

            int srcIndex = 0;
            int dstIndex = arrayIndex + _size;
            while (srcIndex < _size)
            {
                array[--dstIndex] = _array[srcIndex++];
            }
        }

        /// <summary>
        ///     Copies the to using the specified array
        /// </summary>
        /// <param name="array">The array</param>
        /// <param name="arrayIndex">The array index</param>
        /// <exception cref="ArgumentException">Arg_NonZeroLowerBound </exception>
        /// <exception cref="ArgumentException">Arg_RankMultiDimNotSupported </exception>
        /// <exception cref="ArgumentOutOfRangeException">ArgumentOutOfRange_NeedNonNegNum</exception>
        /// <exception cref="ArgumentException">Argument_InvalidOffLen</exception>
        /// <exception cref="ArgumentException">Invalid array type</exception>
        void ICollection.CopyTo(Array array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Rank != 1)
            {
                throw new ArgumentException("Arg_RankMultiDimNotSupported", nameof(array));
            }

            if (array.GetLowerBound(0) != 0)
            {
                throw new ArgumentException("Arg_NonZeroLowerBound", nameof(array));
            }

            if (arrayIndex < 0 || arrayIndex > array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), arrayIndex, "ArgumentOutOfRange_NeedNonNegNum");
            }

            if (array.Length - arrayIndex < _size)
            {
                throw new ArgumentException("Argument_InvalidOffLen");
            }

            try
            {
                Array.Copy(_array, 0, array, arrayIndex, _size);
                Array.Reverse(array, arrayIndex, _size);
            }
            catch (ArrayTypeMismatchException)
            {
                throw new ArgumentException("Invalid array type");
            }
        }

        // Returns an IEnumerator for this Stack.
        /// <summary>
        ///     Gets the enumerator
        /// </summary>
        /// <returns>The enumerator</returns>
        public Enumerator GetEnumerator() => new Enumerator(this);


        /// <summary>
        ///     Gets the enumerator
        /// </summary>
        /// <returns>An enumerator of t</returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => Count == 0 ? EnumerableHelpers.GetEmptyEnumerator<T>() : GetEnumerator();

        /// <summary>
        ///     Gets the enumerator
        /// </summary>
        /// <returns>The enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<T>) this).GetEnumerator();

        /// <summary>
        ///     Trims the excess
        /// </summary>
        public void TrimExcess()
        {
            int threshold = (int) (_array.Length * 0.9);
            if (_size < threshold)
            {
                Array.Resize(ref _array, _size);
            }
        }

        /// <summary>
        ///     Sets the capacity of a <see cref="FastestStack{T}" /> object to a specified number of entries.
        /// </summary>
        /// <param name="capacity">The new capacity.</param>
        /// <exception cref="ArgumentOutOfRangeException">Passed capacity is lower than 0 or entries count.</exception>
        public void TrimExcess(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "Dont use negative values");
            }

            if (capacity < _size)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity is less than the current size");
            }

            if (capacity == _array.Length)
            {
                return;
            }

            Array.Resize(ref _array, capacity);
        }

        // Returns the top object on the stack without removing it.  If the stack
        // is empty, Peek throws an InvalidOperationException.
        /// <summary>
        ///     Peeks this instance
        /// </summary>
        /// <returns>The</returns>
        public T Peek()
        {
            int size = _size - 1;
            T[] array = _array;

            if ((uint) size >= (uint) array.Length)
            {
                ThrowForEmptyStack();
            }

            return array[size];
        }

        /// <summary>
        ///     Tries the peek using the specified result
        /// </summary>
        /// <param name="result">The result</param>
        /// <returns>The bool</returns>
        public bool TryPeek(out T result)
        {
            int size = _size - 1;
            T[] array = _array;

            if ((uint) size >= (uint) array.Length)
            {
                result = default(T)!;
                return false;
            }

            result = array[size];
            return true;
        }

        // Pops an item from the top of the stack.  If the stack is empty, Pop
        // throws an InvalidOperationException.
        /// <summary>
        ///     Pops this instance
        /// </summary>
        /// <returns>The item</returns>
        public T Pop()
        {
            int size = _size - 1;
            T[] array = _array;

            // if (_size == 0) is equivalent to if (size == -1), and this case
            // is covered with (uint)size, thus allowing bounds check elimination
            // https://github.com/dotnet/coreclr/pull/9773
            if ((uint) size >= (uint) array.Length)
            {
                ThrowForEmptyStack();
            }

            _version++;
            _size = size;
            T item = array[size];
            if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
            {
                array[size] = default(T)!; // Free memory quicker.
            }

            return item;
        }

        /// <summary>
        ///     Tries the pop using the specified result
        /// </summary>
        /// <param name="result">The result</param>
        /// <returns>The bool</returns>
        public bool TryPop(out T result)
        {
            int size = _size - 1;
            T[] array = _array;

            if ((uint) size >= (uint) array.Length)
            {
                result = default(T)!;
                return false;
            }

            _version++;
            _size = size;
            result = array[size];
            if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
            {
                array[size] = default(T)!;
            }

            return true;
        }

        // Pushes an item to the top of the stack.
        /// <summary>
        ///     Pushes the item
        /// </summary>
        /// <param name="item">The item</param>
        public void Push(T item)
        {
            int size = _size;
            T[] array = _array;

            if ((uint) size < (uint) array.Length)
            {
                array[size] = item;
                _version++;
                _size = size + 1;
            }
            else
            {
                PushWithResize(item);
            }
        }

        // Non-inline from Stack.Push to improve its code quality as uncommon path
        /// <summary>
        ///     Pushes the with resize using the specified item
        /// </summary>
        /// <param name="item">The item</param>
        [MethodImpl(MethodImplOptions.NoInlining)]
        private void PushWithResize(T item)
        {
            Grow(_size + 1);
            _array[_size] = item;
            _version++;
            _size++;
        }

        /// <summary>
        ///     Removes the item
        /// </summary>
        /// <param name="item">The item</param>
        public void Remove(T item)
        {
            Span<T> items = AsSpan();
            int count = items.Length;
            for (int i = 0; i < count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(items[i], item))
                {
                    items[i] = Pop();
                    break;
                }
            }
        }

        /// <summary>
        ///     Ensures that the capacity of this Stack is at least the specified <paramref name="capacity" />.
        ///     If the current capacity of the Stack is less than specified <paramref name="capacity" />,
        ///     the capacity is increased by continuously twice current capacity until it is at least the specified
        ///     <paramref name="capacity" />.
        /// </summary>
        /// <param name="capacity">The minimum capacity to ensure.</param>
        /// <returns>The new capacity of this stack.</returns>
        public int EnsureCapacity(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "ArgumentOutOfRange_NeedNonNegNum");
            }

            if (_array.Length < capacity)
            {
                Grow(capacity);
            }

            return _array.Length;
        }

        /// <summary>
        ///     Grows the capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        private void Grow(int capacity)
        {
            int newcapacity = _array.Length == 0 ? DefaultCapacity : 2 * _array.Length;

            // Allow the list to grow to maximum possible capacity (~2G elements) before encountering overflow.
            // Note that this check works even when _items.Length overflowed thanks to the (uint) cast.
            if ((uint) newcapacity > MaxArrayLength)
            {
                newcapacity = MaxArrayLength;
            }

            // If computed capacity is still less than specified, set to the original argument.
            // Capacities exceeding MaxArrayLength will be surfaced as OutOfMemoryException by Array.Resize.
            if (newcapacity < capacity)
            {
                newcapacity = capacity;
            }

            Array.Resize(ref _array, newcapacity);
        }

        // Copies the Stack to an array, in the same order Pop would return the items.
        /// <summary>
        ///     Returns the array
        /// </summary>
        /// <returns>The obj array</returns>
        public T[] ToArray()
        {
            if (_size == 0)
            {
                return Array.Empty<T>();
            }

            T[] objArray = new T[_size];
            int i = 0;
            while (i < _size)
            {
                objArray[i] = _array[_size - i - 1];
                i++;
            }

            return objArray;
        }

        /// <summary>
        ///     Throws the for empty stack
        /// </summary>
        /// <exception cref="InvalidOperationException">InvalidOperation_EmptyStack</exception>
        private void ThrowForEmptyStack()
        {
            throw new InvalidOperationException("InvalidOperation_EmptyStack");
        }

        /// <summary>
        ///     The enumerator
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Enumerator : IEnumerator<T>
        {
            /// <summary>
            ///     The fastest stack
            /// </summary>
            private readonly FastestStack<T> fastestStack;

            /// <summary>
            ///     The version
            /// </summary>
            private readonly int _version;

            /// <summary>
            ///     The index
            /// </summary>
            private int _index;

            /// <summary>
            ///     The current element
            /// </summary>
            private T _currentElement;

            /// <summary>
            ///     Initializes a new instance of the <see cref="Enumerator" /> class
            /// </summary>
            /// <param name="fastestStack">The fastest stack</param>
            internal Enumerator(FastestStack<T> fastestStack)
            {
                this.fastestStack = fastestStack;
                _version = fastestStack._version;
                _index = -2;
                _currentElement = default(T);
            }

            /// <summary>
            ///     Disposes this instance
            /// </summary>
            public void Dispose()
            {
                _index = -1;
            }

            /// <summary>
            ///     Moves the next
            /// </summary>
            /// <exception cref="InvalidOperationException">InvalidOperation_EnumFailedVersion</exception>
            /// <returns>The retval</returns>
            public bool MoveNext()
            {
                bool retval;
                if (_version != fastestStack._version)
                {
                    throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
                }

                if (_index == -2)
                {
                    // First call to enumerator.
                    _index = fastestStack._size - 1;
                    retval = _index >= 0;
                    if (retval)
                    {
                        _currentElement = fastestStack._array[_index];
                    }

                    return retval;
                }

                if (_index == -1)
                    // End of enumeration.
                {
                    return false;
                }

                retval = --_index >= 0;
                if (retval)
                {
                    _currentElement = fastestStack._array[_index];
                }
                else
                {
                    _currentElement = default(T);
                }

                return retval;
            }

            /// <summary>
            ///     Gets the value of the current
            /// </summary>
            public T Current
            {
                get
                {
                    if (_index < 0)
                    {
                        ThrowEnumerationNotStartedOrEnded();
                    }

                    return _currentElement!;
                }
            }

            /// <summary>
            ///     Throws the enumeration not started or ended
            /// </summary>
            /// <exception cref="InvalidOperationException"></exception>
            private void ThrowEnumerationNotStartedOrEnded()
            {
                throw new InvalidOperationException(_index == -2
                    ? "InvalidOperation_EnumNotStarted"
                    : "InvalidOperation_EnumEnded");
            }

            /// <summary>
            ///     Gets the value of the current
            /// </summary>
            object IEnumerator.Current => Current;

            /// <summary>
            ///     Resets this instance
            /// </summary>
            /// <exception cref="InvalidOperationException">InvalidOperation_EnumFailedVersion</exception>
            void IEnumerator.Reset()
            {
                if (_version != fastestStack._version)
                {
                    throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
                }

                _index = -2;
                _currentElement = default(T);
            }
        }

        /// <summary>
        ///     The value
        /// </summary>
        public T this[int i]
        {
            get => _array[i];
            set => _array[i] = value;
        }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            _array = Array.Empty<T>();
            _size = 0;
            _version = 0;
        }

        /// <summary>
        ///     Creates the i
        /// </summary>
        /// <param name="i">The </param>
        /// <returns>A fast stack of t</returns>
        public static FastestStack<T> Create(int i) => new FastestStack<T>(i);

        /// <summary>
        ///     Converts the span
        /// </summary>
        /// <returns>A span of t</returns>
#if NET6_0_OR_GREATER
        public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref _array[0], _size);
#else
        public Span<T> AsSpan() => _array.AsSpan(0, _size);
#endif

        /// <summary>
        ///     Cans the pop
        /// </summary>
        /// <returns>The bool</returns>
        public bool CanPop() => Count > 0;
    }
}