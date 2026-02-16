// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PooledStack.cs
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
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;
using Collections.Pooled;

namespace Alis.Benchmark.CustomCollections.Stacks.Elements
{
    /// <summary>
    ///     A simple stack of objects.  Internally it is implemented as an array,
    ///     so Push can be O(n).  Pop is O(1).
    /// </summary>
    public class PooledStack<T> : ICollection, IReadOnlyCollection<T>, IDisposable, IDeserializationCallback
    {
        /// <summary>
        ///     The default capacity
        /// </summary>
        private const int DefaultCapacity = 4;

        /// <summary>
        ///     The clear on free
        /// </summary>
        private readonly bool _clearOnFree;

        /// <summary>
        ///     The array
        /// </summary>
        private T[] _array; // Storage for stack elements. Do not rename (binary serialization)

        /// <summary>
        ///     The pool
        /// </summary>
        [NonSerialized] private ArrayPool<T> _pool;

        /// <summary>
        ///     The size
        /// </summary>
        private int _size; // Number of items in the stack. Do not rename (binary serialization)

        /// <summary>
        ///     The sync root
        /// </summary>
        [NonSerialized] private object _syncRoot;

        /// <summary>
        ///     The version
        /// </summary>
        private int _version; // Used to keep enumerator in sync w/ collection. Do not rename (binary serialization)


        /// <summary>
        ///     Create a stack with the default initial capacity.
        /// </summary>
        public PooledStack() : this(ClearMode.Auto, ArrayPool<T>.Shared)
        {
        }

        /// <summary>
        ///     Create a stack with the default initial capacity.
        /// </summary>
        public PooledStack(ClearMode clearMode) : this(clearMode, ArrayPool<T>.Shared)
        {
        }

        /// <summary>
        ///     Create a stack with the default initial capacity.
        /// </summary>
        public PooledStack(ArrayPool<T> customPool) : this(ClearMode.Auto, customPool)
        {
        }

        /// <summary>
        ///     Create a stack with the default initial capacity and a custom ArrayPool.
        /// </summary>
        public PooledStack(ClearMode clearMode, ArrayPool<T> customPool)
        {
            _pool = customPool ?? ArrayPool<T>.Shared;
            _array = Array.Empty<T>();
            _clearOnFree = ShouldClear(clearMode);
        }

        /// <summary>
        ///     Create a stack with a specific initial capacity.  The initial capacity
        ///     must be a non-negative number.
        /// </summary>
        public PooledStack(int capacity) : this(capacity, ClearMode.Auto, ArrayPool<T>.Shared)
        {
        }

        /// <summary>
        ///     Create a stack with a specific initial capacity.  The initial capacity
        ///     must be a non-negative number.
        /// </summary>
        public PooledStack(int capacity, ClearMode clearMode) : this(capacity, clearMode, ArrayPool<T>.Shared)
        {
        }

        /// <summary>
        ///     Create a stack with a specific initial capacity.  The initial capacity
        ///     must be a non-negative number.
        /// </summary>
        public PooledStack(int capacity, ArrayPool<T> customPool) : this(capacity, ClearMode.Auto, customPool)
        {
        }

        /// <summary>
        ///     Create a stack with a specific initial capacity.  The initial capacity
        ///     must be a non-negative number.
        /// </summary>
        public PooledStack(int capacity, ClearMode clearMode, ArrayPool<T> customPool)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            _pool = customPool ?? ArrayPool<T>.Shared;
            _array = _pool.Rent(capacity);
            _clearOnFree = ShouldClear(clearMode);
        }

        /// <summary>
        ///     Fills a Stack with the contents of a particular collection.  The items are
        ///     pushed onto the stack in the same order they are read by the enumerator.
        /// </summary>
        public PooledStack(IEnumerable<T> enumerable) : this(enumerable, ClearMode.Auto, ArrayPool<T>.Shared)
        {
        }

        /// <summary>
        ///     Fills a Stack with the contents of a particular collection.  The items are
        ///     pushed onto the stack in the same order they are read by the enumerator.
        /// </summary>
        public PooledStack(IEnumerable<T> enumerable, ClearMode clearMode) : this(enumerable, clearMode, ArrayPool<T>.Shared)
        {
        }

        /// <summary>
        ///     Fills a Stack with the contents of a particular collection.  The items are
        ///     pushed onto the stack in the same order they are read by the enumerator.
        /// </summary>
        public PooledStack(IEnumerable<T> enumerable, ArrayPool<T> customPool) : this(enumerable, ClearMode.Auto, customPool)
        {
        }

        /// <summary>
        ///     Fills a Stack with the contents of a particular collection.  The items are
        ///     pushed onto the stack in the same order they are read by the enumerator.
        /// </summary>
        public PooledStack(IEnumerable<T> enumerable, ClearMode clearMode, ArrayPool<T> customPool)
        {
            _pool = customPool ?? ArrayPool<T>.Shared;
            _clearOnFree = ShouldClear(clearMode);

            switch (enumerable)
            {
                case null:
                    throw new ArgumentNullException(nameof(enumerable));

                case ICollection<T> collection:
                    if (collection.Count == 0)
                    {
                        _array = Array.Empty<T>();
                    }
                    else
                    {
                        _array = _pool.Rent(collection.Count);
                        collection.CopyTo(_array, 0);
                        _size = collection.Count;
                    }

                    break;

                default:
                    using (PooledList<T> list = new PooledList<T>(enumerable))
                    {
                        _array = _pool.Rent(list.Count);
                        list.Span.CopyTo(_array);
                        _size = list.Count;
                    }

                    break;
            }
        }

        /// <summary>
        ///     Fills a Stack with the contents of a particular collection.  The items are
        ///     pushed onto the stack in the same order they are read by the enumerator.
        /// </summary>
        public PooledStack(T[] array) : this(array.AsSpan(), ClearMode.Auto, ArrayPool<T>.Shared)
        {
        }

        /// <summary>
        ///     Fills a Stack with the contents of a particular collection.  The items are
        ///     pushed onto the stack in the same order they are read by the enumerator.
        /// </summary>
        public PooledStack(T[] array, ClearMode clearMode) : this(array.AsSpan(), clearMode, ArrayPool<T>.Shared)
        {
        }

        /// <summary>
        ///     Fills a Stack with the contents of a particular collection.  The items are
        ///     pushed onto the stack in the same order they are read by the enumerator.
        /// </summary>
        public PooledStack(T[] array, ArrayPool<T> customPool) : this(array.AsSpan(), ClearMode.Auto, customPool)
        {
        }

        /// <summary>
        ///     Fills a Stack with the contents of a particular collection.  The items are
        ///     pushed onto the stack in the same order they are read by the enumerator.
        /// </summary>
        public PooledStack(T[] array, ClearMode clearMode, ArrayPool<T> customPool) : this(array.AsSpan(), clearMode, customPool)
        {
        }

        /// <summary>
        ///     Fills a Stack with the contents of a particular collection.  The items are
        ///     pushed onto the stack in the same order they are read by the enumerator.
        /// </summary>
        public PooledStack(ReadOnlySpan<T> span) : this(span, ClearMode.Auto, ArrayPool<T>.Shared)
        {
        }

        /// <summary>
        ///     Fills a Stack with the contents of a particular collection.  The items are
        ///     pushed onto the stack in the same order they are read by the enumerator.
        /// </summary>
        public PooledStack(ReadOnlySpan<T> span, ClearMode clearMode) : this(span, clearMode, ArrayPool<T>.Shared)
        {
        }

        /// <summary>
        ///     Fills a Stack with the contents of a particular collection.  The items are
        ///     pushed onto the stack in the same order they are read by the enumerator.
        /// </summary>
        public PooledStack(ReadOnlySpan<T> span, ArrayPool<T> customPool) : this(span, ClearMode.Auto, customPool)
        {
        }

        /// <summary>
        ///     Fills a Stack with the contents of a particular collection.  The items are
        ///     pushed onto the stack in the same order they are read by the enumerator.
        /// </summary>
        public PooledStack(ReadOnlySpan<T> span, ClearMode clearMode, ArrayPool<T> customPool)
        {
            _pool = customPool ?? ArrayPool<T>.Shared;
            _clearOnFree = ShouldClear(clearMode);
            _array = _pool.Rent(span.Length);
            span.CopyTo(_array);
            _size = span.Length;
        }

        /// <summary>
        ///     Returns the ClearMode behavior for the collection, denoting whether values are
        ///     cleared from internal arrays before returning them to the pool.
        /// </summary>
        public ClearMode ClearMode => _clearOnFree ? ClearMode.Always : ClearMode.Never;

        /// <summary>
        ///     The value
        /// </summary>
        public T this[int i]
        {
            get => _array[i];
            set => _array[i] = value;
        }

        /// <summary>
        ///     The number of items in the stack.
        /// </summary>
        public int Count => _size;

        /// <summary>
        ///     Gets the value of the is synchronized
        /// </summary>
        bool ICollection.IsSynchronized => false;

        /// <summary>
        ///     Gets the value of the sync root
        /// </summary>
        object ICollection.SyncRoot
        {
            get
            {
                if (_syncRoot == null)
                {
                    Interlocked.CompareExchange<object>(ref _syncRoot, new object(), null);
                }

                return _syncRoot;
            }
        }

        /// <summary>
        ///     Copies the to using the specified array
        /// </summary>
        /// <param name="array">The array</param>
        /// <param name="arrayIndex">The array index</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException">Argument_InvalidOffLen</exception>
        /// <exception cref="ArgumentException">Argument_InvalidOffLen</exception>
        /// <exception cref="ArgumentException">Argument_InvalidOffLen</exception>
        void ICollection.CopyTo(Array array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Rank != 1)
            {
                throw new ArgumentException("Argument_InvalidOffLen");
            }

            if (array.GetLowerBound(0) != 0)
            {
                throw new ArgumentException("Argument_InvalidOffLen");
            }

            if (arrayIndex < 0 || arrayIndex > array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
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
                throw new ArgumentException(nameof(array));
            }
        }

        /// <summary>
        ///     Gets the enumerator
        /// </summary>
        /// <returns>The enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
            => new Enumerator(this);

        /// <summary>
        ///     Ons the deserialization using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        void IDeserializationCallback.OnDeserialization(object sender)
        {
            // We can't serialize array pools, so deserialized PooledStacks will
            // have to use the shared pool, even if they were using a custom pool
            // before serialization.
            _pool = ArrayPool<T>.Shared;
        }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            ReturnArray(Array.Empty<T>());
            _size = 0;
            _version++;
        }

        /// <summary>
        ///     Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns></returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
            => new Enumerator(this);

        /// <summary>
        ///     Removes all Objects from the Stack.
        /// </summary>
        public void Clear()
        {
            if (_clearOnFree)
            {
                Array.Clear(_array, 0, _size); // clear the elements so that the gc can reclaim the references.
            }

            _size = 0;
            _version++;
        }

        /// <summary>
        ///     Compares items using the default equality comparer
        /// </summary>
        public bool Contains(T item) =>
            // PERF: Internally Array.LastIndexOf calls
            // EqualityComparer<T>.Default.LastIndexOf, which
            // is specialized for different types. This
            // boosts performance since instead of making a
            // virtual method call each iteration of the loop,
            // via EqualityComparer<T>.Default.Equals, we
            // only make one virtual call to EqualityComparer.LastIndexOf.
            (_size != 0) && (Array.LastIndexOf(_array, item, _size - 1) != -1);

        /// <summary>
        ///     This method removes all items which match the predicate.
        ///     The complexity is O(n).
        /// </summary>
        public int RemoveWhere(Func<T, bool> match)
        {
            if (match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }

            int freeIndex = 0; // the first free slot in items array

            // Find the first item which needs to be removed.
            while ((freeIndex < _size) && !match(_array[freeIndex]))
            {
                freeIndex++;
            }

            if (freeIndex >= _size)
            {
                return 0;
            }

            int current = freeIndex + 1;
            while (current < _size)
            {
                // Find the first item which needs to be kept.
                while ((current < _size) && match(_array[current]))
                {
                    current++;
                }

                if (current < _size)
                {
                    // copy item to the free slot.
                    _array[freeIndex++] = _array[current++];
                }
            }

            if (_clearOnFree)
            {
                // Clear the removed elements so that the gc can reclaim the references.
                Array.Clear(_array, freeIndex, _size - freeIndex);
            }

            int result = _size - freeIndex;
            _size = freeIndex;
            _version++;
            return result;
        }

        // Copies the stack into an array.
        /// <summary>
        ///     Copies the to using the specified array
        /// </summary>
        /// <param name="array">The array</param>
        /// <param name="arrayIndex">The array index</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException">Argument_InvalidOffLen</exception>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (arrayIndex < 0 || arrayIndex > array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
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
        ///     Copies the to using the specified span
        /// </summary>
        /// <param name="span">The span</param>
        /// <exception cref="ArgumentException">Argument_InvalidOffLen</exception>
        public void CopyTo(Span<T> span)
        {
            if (span.Length < _size)
            {
                throw new ArgumentException("Argument_InvalidOffLen");
            }

            int srcIndex = 0;
            int dstIndex = _size;
            while (srcIndex < _size)
            {
                span[--dstIndex] = _array[srcIndex++];
            }
        }

        /// <summary>
        ///     Returns an IEnumerator for this PooledStackWithIndex.
        /// </summary>
        /// <returns></returns>
        public Enumerator GetEnumerator()
            => new Enumerator(this);

        /// <summary>
        ///     Trims the excess
        /// </summary>
        public void TrimExcess()
        {
            if (_size == 0)
            {
                ReturnArray(Array.Empty<T>());
                _version++;
                return;
            }

            int threshold = (int) (_array.Length * 0.9);
            if (_size < threshold)
            {
                T[] newArray = _pool.Rent(_size);
                if (newArray.Length < _array.Length)
                {
                    Array.Copy(_array, newArray, _size);
                    ReturnArray(newArray);
                    _version++;
                }
                else
                {
                    // The array from the pool wasn't any smaller than the one we already had,
                    // (we can only control minimum size) so return it and do nothing.
                    // If we create an exact-sized array not from the pool, we'll
                    // get an exception when returning it to the pool.
                    _pool.Return(newArray);
                }
            }
        }

        /// <summary>
        ///     Returns the top object on the stack without removing it.  If the stack
        ///     is empty, Peek throws an InvalidOperationException.
        /// </summary>
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
                result = default(T);
                return false;
            }

            result = array[size];
            return true;
        }

        /// <summary>
        ///     Pops an item from the top of the stack.  If the stack is empty, Pop
        ///     throws an InvalidOperationException.
        /// </summary>
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
            if (_clearOnFree)
            {
                array[size] = default(T); // Free memory quicker.
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
                result = default(T);
                return false;
            }

            _version++;
            _size = size;
            result = array[size];
            if (_clearOnFree)
            {
                array[size] = default(T); // Free memory quicker.
            }

            return true;
        }

        /// <summary>
        ///     Pushes an item to the top of the stack.
        /// </summary>
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
            T[] newArray = _pool.Rent(_array.Length == 0 ? DefaultCapacity : 2 * _array.Length);
            Array.Copy(_array, newArray, _size);
            ReturnArray(newArray);
            _array[_size] = item;
            _version++;
            _size++;
        }

        /// <summary>
        ///     Copies the Stack to an array, in the same order Pop would return the items.
        /// </summary>
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
        /// <exception cref="InvalidOperationException">Stack was empty.</exception>
        private void ThrowForEmptyStack()
        {
            throw new InvalidOperationException("Stack was empty.");
        }

        /// <summary>
        ///     Returns the array using the specified replace with
        /// </summary>
        /// <param name="replaceWith">The replace with</param>
        private void ReturnArray(T[] replaceWith = null)
        {
            if (_array?.Length > 0)
            {
                try
                {
                    _pool.Return(_array, _clearOnFree);
                }
                catch (ArgumentException)
                {
                    // oh well, the array pool didn't like our array
                }
            }

            if (!(replaceWith is null))
            {
                _array = replaceWith;
            }
        }

        /// <summary>
        ///     Shoulds the clear using the specified mode
        /// </summary>
        /// <param name="mode">The mode</param>
        /// <returns>The bool</returns>
        private static bool ShouldClear(ClearMode mode)
        {
#if NETCOREAPP2_1
            return mode == ClearMode.Always
                   || (mode == ClearMode.Auto && RuntimeHelpers.IsReferenceOrContainsReferences<T>());
#else
            return mode != ClearMode.Never;
#endif
        }

        /// <summary>
        ///     The enumerator
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes", Justification = "not an expected scenario")]
        public struct Enumerator : IEnumerator<T>, IEnumerator
        {
            /// <summary>
            ///     The stack
            /// </summary>
            private readonly PooledStack<T> _stack;

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
            /// <param name="stack">The stack</param>
            internal Enumerator(PooledStack<T> stack)
            {
                _stack = stack;
                _version = stack._version;
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
            /// <exception cref="InvalidOperationException">Collection was modified during enumeration.</exception>
            /// <returns>The retval</returns>
            public bool MoveNext()
            {
                bool retval;
                if (_version != _stack._version)
                {
                    throw new InvalidOperationException("Collection was modified during enumeration.");
                }

                if (_index == -2)
                {
                    // First call to enumerator.
                    _index = _stack._size - 1;
                    retval = _index >= 0;
                    if (retval)
                    {
                        _currentElement = _stack._array[_index];
                    }

                    return retval;
                }

                if (_index == -1)
                {
                    // End of enumeration.
                    return false;
                }

                retval = --_index >= 0;
                if (retval)
                {
                    _currentElement = _stack._array[_index];
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

                    return _currentElement;
                }
            }

            /// <summary>
            ///     Throws the enumeration not started or ended
            /// </summary>
            /// <exception cref="InvalidOperationException"></exception>
            private void ThrowEnumerationNotStartedOrEnded()
            {
                throw new InvalidOperationException(_index == -2 ? "Enumeration was not started." : "Enumeration has ended.");
            }

            /// <summary>
            ///     Gets the value of the current
            /// </summary>
            object IEnumerator.Current => Current;

            /// <summary>
            ///     Resets this instance
            /// </summary>
            /// <exception cref="InvalidOperationException">Collection was modified during enumeration.</exception>
            void IEnumerator.Reset()
            {
                if (_version != _stack._version)
                {
                    throw new InvalidOperationException("Collection was modified during enumeration.");
                }

                _index = -2;
                _currentElement = default(T);
            }
        }
    }
}