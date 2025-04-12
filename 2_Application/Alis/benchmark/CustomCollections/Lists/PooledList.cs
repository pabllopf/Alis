// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PooledList.cs
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
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;
using Collections.Pooled;

namespace Alis.Benchmark.CustomCollections.Lists
{
    /// <summary>
    ///     Implements a variable-size list that uses a pooled array to store the
    ///     elements. A PooledList has a capacity, which is the allocated length
    ///     of the internal array. As elements are added to a PooledList, the capacity
    ///     of the PooledList is automatically increased as required by reallocating the
    ///     internal array.
    /// </summary>
    /// <remarks>
    ///     This class is based on the code for <see cref="List{T}" /> but it supports <see cref="Span{T}" />
    ///     and uses <see cref="ArrayPool{T}" /> when allocating internal arrays.
    /// </remarks>
    [Serializable]
    public class PooledList<T> : IList<T>, IReadOnlyPooledList<T>, IList, IDisposable, IDeserializationCallback
    {
        // internal constant copied from Array.MaxArrayLength
        /// <summary>
        ///     The max array length
        /// </summary>
        private const int MaxArrayLength = 0x7FEFFFFF;

        /// <summary>
        ///     The default capacity
        /// </summary>
        private const int DefaultCapacity = 4;

        /// <summary>
        ///     The
        /// </summary>
        private static readonly T[] s_emptyArray = Array.Empty<T>();

        /// <summary>
        ///     The clear on free
        /// </summary>
        private readonly bool _clearOnFree;

        /// <summary>
        ///     The items
        /// </summary>
        private T[] _items; // Do not rename (binary serialization)

        /// <summary>
        ///     The pool
        /// </summary>
        [NonSerialized] private ArrayPool<T> _pool;

        /// <summary>
        ///     The size
        /// </summary>
        private int _size; // Do not rename (binary serialization)

        /// <summary>
        ///     The sync root
        /// </summary>
        [NonSerialized] private object _syncRoot;

        /// <summary>
        ///     The version
        /// </summary>
        private int _version; // Do not rename (binary serialization)

        /// <summary>
        ///     Constructs a PooledList. The list is initially empty and has a capacity
        ///     of zero. Upon adding the first element to the list the capacity is
        ///     increased to DefaultCapacity, and then increased in multiples of two
        ///     as required.
        /// </summary>
        public PooledList() : this(ClearMode.Auto, ArrayPool<T>.Shared)
        {
        }

        /// <summary>
        ///     Constructs a PooledList. The list is initially empty and has a capacity
        ///     of zero. Upon adding the first element to the list the capacity is
        ///     increased to DefaultCapacity, and then increased in multiples of two
        ///     as required.
        /// </summary>
        public PooledList(ClearMode clearMode) : this(clearMode, ArrayPool<T>.Shared)
        {
        }

        /// <summary>
        ///     Constructs a PooledList. The list is initially empty and has a capacity
        ///     of zero. Upon adding the first element to the list the capacity is
        ///     increased to DefaultCapacity, and then increased in multiples of two
        ///     as required.
        /// </summary>
        public PooledList(ArrayPool<T> customPool) : this(ClearMode.Auto, customPool)
        {
        }

        /// <summary>
        ///     Constructs a PooledList. The list is initially empty and has a capacity
        ///     of zero. Upon adding the first element to the list the capacity is
        ///     increased to DefaultCapacity, and then increased in multiples of two
        ///     as required.
        /// </summary>
        public PooledList(ClearMode clearMode, ArrayPool<T> customPool)
        {
            _items = s_emptyArray;
            _pool = customPool ?? ArrayPool<T>.Shared;
            _clearOnFree = ShouldClear(clearMode);
        }

        /// <summary>
        ///     Constructs a List with a given initial capacity. The list is
        ///     initially empty, but will have room for the given number of elements
        ///     before any reallocations are required.
        /// </summary>
        public PooledList(int capacity) : this(capacity, ClearMode.Auto, ArrayPool<T>.Shared)
        {
        }

        /// <summary>
        ///     Constructs a List with a given initial capacity. The list is
        ///     initially empty, but will have room for the given number of elements
        ///     before any reallocations are required.
        /// </summary>
        public PooledList(int capacity, bool sizeToCapacity) : this(capacity, ClearMode.Auto, ArrayPool<T>.Shared,
            sizeToCapacity)
        {
        }

        /// <summary>
        ///     Constructs a List with a given initial capacity. The list is
        ///     initially empty, but will have room for the given number of elements
        ///     before any reallocations are required.
        /// </summary>
        public PooledList(int capacity, ClearMode clearMode) : this(capacity, clearMode, ArrayPool<T>.Shared)
        {
        }

        /// <summary>
        ///     Constructs a List with a given initial capacity. The list is
        ///     initially empty, but will have room for the given number of elements
        ///     before any reallocations are required.
        /// </summary>
        public PooledList(int capacity, ClearMode clearMode, bool sizeToCapacity) : this(capacity, clearMode,
            ArrayPool<T>.Shared, sizeToCapacity)
        {
        }

        /// <summary>
        ///     Constructs a List with a given initial capacity. The list is
        ///     initially empty, but will have room for the given number of elements
        ///     before any reallocations are required.
        /// </summary>
        public PooledList(int capacity, ArrayPool<T> customPool) : this(capacity, ClearMode.Auto, customPool)
        {
        }

        /// <summary>
        ///     Constructs a List with a given initial capacity. The list is
        ///     initially empty, but will have room for the given number of elements
        ///     before any reallocations are required.
        /// </summary>
        public PooledList(int capacity, ArrayPool<T> customPool, bool sizeToCapacity) : this(capacity, ClearMode.Auto,
            customPool, sizeToCapacity)
        {
        }

        /// <summary>
        ///     Constructs a List with a given initial capacity. The list is
        ///     initially empty, but will have room for the given number of elements
        ///     before any reallocations are required.
        /// </summary>
        public PooledList(int capacity, ClearMode clearMode, ArrayPool<T> customPool) : this(capacity, clearMode,
            customPool, false)
        {
        }

        /// <summary>
        ///     Constructs a List with a given initial capacity. The list is
        ///     initially empty, but will have room for the given number of elements
        ///     before any reallocations are required.
        /// </summary>
        /// <param name="sizeToCapacity">
        ///     If true, Count of list equals capacity. Depending on ClearMode, rented items may or may
        ///     not hold dirty values.
        /// </param>
        public PooledList(int capacity, ClearMode clearMode, ArrayPool<T> customPool, bool sizeToCapacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            _pool = customPool ?? ArrayPool<T>.Shared;
            _clearOnFree = ShouldClear(clearMode);

            if (capacity == 0)
            {
                _items = s_emptyArray;
            }
            else
            {
                _items = _pool.Rent(capacity);
            }

            if (sizeToCapacity)
            {
                _size = capacity;
                if (clearMode != ClearMode.Never)
                {
                    Array.Clear(_items, 0, _size);
                }
            }
        }

        /// <summary>
        ///     Constructs a PooledList, copying the contents of the given collection. The
        ///     size and capacity of the new list will both be equal to the size of the
        ///     given collection.
        /// </summary>
        public PooledList(T[] array) : this(array.AsSpan(), ClearMode.Auto, ArrayPool<T>.Shared)
        {
        }

        /// <summary>
        ///     Constructs a PooledList, copying the contents of the given collection. The
        ///     size and capacity of the new list will both be equal to the size of the
        ///     given collection.
        /// </summary>
        public PooledList(T[] array, ClearMode clearMode) : this(array.AsSpan(), clearMode, ArrayPool<T>.Shared)
        {
        }

        /// <summary>
        ///     Constructs a PooledList, copying the contents of the given collection. The
        ///     size and capacity of the new list will both be equal to the size of the
        ///     given collection.
        /// </summary>
        public PooledList(T[] array, ArrayPool<T> customPool) : this(array.AsSpan(), ClearMode.Auto, customPool)
        {
        }

        /// <summary>
        ///     Constructs a PooledList, copying the contents of the given collection. The
        ///     size and capacity of the new list will both be equal to the size of the
        ///     given collection.
        /// </summary>
        public PooledList(T[] array, ClearMode clearMode, ArrayPool<T> customPool) : this(array.AsSpan(), clearMode,
            customPool)
        {
        }

        /// <summary>
        ///     Constructs a PooledList, copying the contents of the given collection. The
        ///     size and capacity of the new list will both be equal to the size of the
        ///     given collection.
        /// </summary>
        public PooledList(ReadOnlySpan<T> span) : this(span, ClearMode.Auto, ArrayPool<T>.Shared)
        {
        }

        /// <summary>
        ///     Constructs a PooledList, copying the contents of the given collection. The
        ///     size and capacity of the new list will both be equal to the size of the
        ///     given collection.
        /// </summary>
        public PooledList(ReadOnlySpan<T> span, ClearMode clearMode) : this(span, clearMode, ArrayPool<T>.Shared)
        {
        }

        /// <summary>
        ///     Constructs a PooledList, copying the contents of the given collection. The
        ///     size and capacity of the new list will both be equal to the size of the
        ///     given collection.
        /// </summary>
        public PooledList(ReadOnlySpan<T> span, ArrayPool<T> customPool) : this(span, ClearMode.Auto, customPool)
        {
        }

        /// <summary>
        ///     Constructs a PooledList, copying the contents of the given collection. The
        ///     size and capacity of the new list will both be equal to the size of the
        ///     given collection.
        /// </summary>
        public PooledList(ReadOnlySpan<T> span, ClearMode clearMode, ArrayPool<T> customPool)
        {
            _pool = customPool ?? ArrayPool<T>.Shared;
            _clearOnFree = ShouldClear(clearMode);

            int count = span.Length;
            if (count == 0)
            {
                _items = s_emptyArray;
            }
            else
            {
                _items = _pool.Rent(count);
                span.CopyTo(_items);
                _size = count;
            }
        }

        /// <summary>
        ///     Constructs a PooledList, copying the contents of the given collection. The
        ///     size and capacity of the new list will both be equal to the size of the
        ///     given collection.
        /// </summary>
        public PooledList(IEnumerable<T> collection) : this(collection, ClearMode.Auto, ArrayPool<T>.Shared)
        {
        }

        /// <summary>
        ///     Constructs a PooledList, copying the contents of the given collection. The
        ///     size of the new list will be equal to the size of the given collection
        ///     and the capacity will be equal to suggestCapacity
        /// </summary>
        public PooledList(IEnumerable<T> collection, int suggestCapacity) : this(collection, ClearMode.Auto,
            ArrayPool<T>.Shared, suggestCapacity)
        {
        }

        /// <summary>
        ///     Constructs a PooledList, copying the contents of the given collection. The
        ///     size and capacity of the new list will both be equal to the size of the
        ///     given collection.
        /// </summary>
        public PooledList(IEnumerable<T> collection, ClearMode clearMode) : this(collection, clearMode,
            ArrayPool<T>.Shared)
        {
        }

        /// <summary>
        ///     Constructs a PooledList, copying the contents of the given collection. The
        ///     size and capacity of the new list will both be equal to the size of the
        ///     given collection.
        /// </summary>
        public PooledList(IEnumerable<T> collection, ArrayPool<T> customPool) : this(collection, ClearMode.Auto,
            customPool)
        {
        }

        /// <summary>
        ///     Constructs a PooledList, copying the contents of the given collection. The
        ///     size and capacity of the new list will both be equal to the size of the
        ///     given collection.
        /// </summary>
        public PooledList(IEnumerable<T> collection, ClearMode clearMode, ArrayPool<T> customPool,
            int suggestCapacity = 0)
        {
            _pool = customPool ?? ArrayPool<T>.Shared;
            _clearOnFree = ShouldClear(clearMode);

            switch (collection)
            {
                case null:
                    throw new ArgumentNullException(nameof(collection));
                    break;

                case ICollection<T> c:
                {
                    int count = c.Count;
                    if (count == 0)
                    {
                        _items = s_emptyArray;
                    }
                    else
                    {
                        _items = _pool.Rent(count);
                        c.CopyTo(_items, 0);
                        _size = count;
                    }

                    break;
                }

                case ICollection c:
                {
                    int count = c.Count;
                    if (count == 0)
                    {
                        _items = s_emptyArray;
                    }
                    else
                    {
                        _items = _pool.Rent(count);
                        c.CopyTo(_items, 0);
                        _size = count;
                    }

                    break;
                }

                case IReadOnlyCollection<T> c:
                {
                    int count = c.Count;
                    if (count == 0)
                    {
                        _items = s_emptyArray;
                    }
                    else
                    {
                        _items = _pool.Rent(count);
                        _size = 0;
                        using (IEnumerator<T> en = c.GetEnumerator())
                        {
                            while (en.MoveNext())
                            {
                                Add(en.Current);
                            }
                        }
                    }

                    break;
                }

                default:

                    if (suggestCapacity < 0)
                    {
                        throw new ArgumentOutOfRangeException(nameof(suggestCapacity));
                    }

                    if (suggestCapacity == 0)
                    {
                        _items = s_emptyArray;
                    }
                    else
                    {
                        _items = _pool.Rent(suggestCapacity);
                    }

                    using (IEnumerator<T> en = collection.GetEnumerator())
                    {
                        while (en.MoveNext())
                        {
                            Add(en.Current);
                        }
                    }

                    break;
            }
        }

        /// <summary>
        ///     Gets a <see cref="System.Span{T}" /> for the items currently in the collection.
        /// </summary>
        public Span<T> Span => _items.AsSpan(0, _size);

        /// <summary>
        ///     Gets and sets the capacity of this list.  The capacity is the size of
        ///     the internal array used to hold items.  When set, the internal
        ///     Memory of the list is reallocated to the given capacity.
        ///     Note that the return value for this property may be larger than the property was set to.
        /// </summary>
        public int Capacity
        {
            get => _items.Length;
            set
            {
                if (value < _size)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                if (value != _items.Length)
                {
                    if (value > 0)
                    {
                        T[] newItems = _pool.Rent(value);
                        if (_size > 0)
                        {
                            Array.Copy(_items, newItems, _size);
                        }

                        ReturnArray();
                        _items = newItems;
                    }
                    else
                    {
                        ReturnArray();
                        _size = 0;
                    }
                }
            }
        }

        /// <summary>
        ///     Returns the ClearMode behavior for the collection, denoting whether values are
        ///     cleared from internal arrays before returning them to the pool.
        /// </summary>
        public ClearMode ClearMode => _clearOnFree ? ClearMode.Always : ClearMode.Never;

        /// <summary>
        ///     Ons the deserialization using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        void IDeserializationCallback.OnDeserialization(object sender)
        {
            // We can't serialize array pools, so deserialized PooledLists will
            // have to use the shared pool, even if they were using a custom pool
            // before serialization.
            _pool = ArrayPool<T>.Shared;
        }

        /// <summary>
        ///     Returns the internal buffers to the ArrayPool.
        /// </summary>
        public void Dispose()
        {
            ReturnArray();
            _size = 0;
            _version++;
        }

        /// <summary>
        ///     Gets the value of the is fixed size
        /// </summary>
        bool IList.IsFixedSize => false;

        /// <summary>
        ///     Gets the value of the is read only
        /// </summary>
        bool IList.IsReadOnly => false;

        /// <summary>
        ///     Gets the value of the count
        /// </summary>
        int ICollection.Count => _size;

        /// <summary>
        ///     Gets the value of the is synchronized
        /// </summary>
        bool ICollection.IsSynchronized => false;

        // Synchronization root for this object.
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
        ///     The argument exception
        /// </summary>
        object IList.this[int index]
        {
            get => this[index];
            set
            {
                try
                {
                    this[index] = (T) value;
                }
                catch (InvalidCastException)
                {
                    throw new ArgumentException("The value is of a type that cannot be assigned to the item in the list.");
                }
            }
        }

        /// <summary>
        ///     Adds the item
        /// </summary>
        /// <param name="item">The item</param>
        /// <exception cref="ArgumentException">The value is of a type that cannot be assigned to the item in the list.</exception>
        /// <returns>The int</returns>
        int IList.Add(object item)
        {
            try
            {
                Add((T) item);
            }
            catch (InvalidCastException)
            {
                throw new ArgumentException("The value is of a type that cannot be assigned to the item in the list.");
            }

            return Count - 1;
        }

        /// <summary>
        ///     Containses the item
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>The bool</returns>
        bool IList.Contains(object item)
        {
            if (IsCompatibleObject(item))
            {
                return Contains((T) item);
            }

            return false;
        }

        // Copies this List into array, which must be of a 
        // compatible array type.  
        /// <summary>
        ///     Copies the to using the specified array
        /// </summary>
        /// <param name="array">The array</param>
        /// <param name="arrayIndex">The array index</param>
        /// <exception cref="ArgumentException">Invalid array type.</exception>
        /// <exception cref="ArgumentException">Only single dimensional arrays are supported for the requested action.</exception>
        void ICollection.CopyTo(Array array, int arrayIndex)
        {
            if ((array != null) && (array.Rank != 1))
            {
                throw new ArgumentException("Only single dimensional arrays are supported for the requested action.");
            }

            try
            {
                // Array.Copy will check for NULL.
                Array.Copy(_items, 0, array, arrayIndex, _size);
            }
            catch (ArrayTypeMismatchException)
            {
                throw new ArgumentException("Invalid array type.");
            }
        }

        /// <summary>
        ///     Indexes the of using the specified item
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>The int</returns>
        int IList.IndexOf(object item)
        {
            if (IsCompatibleObject(item))
            {
                return IndexOf((T) item);
            }

            return -1;
        }

        /// <summary>
        ///     Inserts the index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="item">The item</param>
        /// <exception cref="ArgumentException">The value couldn't be cast to type T. </exception>
        void IList.Insert(int index, object item)
        {
            try
            {
                Insert(index, (T) item);
            }
            catch (InvalidCastException)
            {
                throw new ArgumentException("The value couldn't be cast to type T.", nameof(item));
            }
        }

        /// <summary>
        ///     Removes the item
        /// </summary>
        /// <param name="item">The item</param>
        void IList.Remove(object item)
        {
            if (IsCompatibleObject(item))
            {
                Remove((T) item);
            }
        }

        /// <summary>
        ///     Read-only property describing how many elements are in the List.
        /// </summary>
        public int Count => _size;

        /// <summary>
        ///     Gets the value of the is read only
        /// </summary>
        bool ICollection<T>.IsReadOnly => false;

        /// <summary>
        ///     Gets or sets the element at the given index.
        /// </summary>
        public T this[int index]
        {
            get
            {
                // Following trick can reduce the range check by one
                if ((uint) index >= (uint) _size)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                return _items[index];
            }

            set
            {
                if ((uint) index >= (uint) _size)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                _items[index] = value;
                _version++;
            }
        }

        /// <summary>
        ///     Adds the given object to the end of this list. The size of the list is
        ///     increased by one. If required, the capacity of the list is doubled
        ///     before adding the new element.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(T item)
        {
            _version++;
            int size = _size;
            if ((uint) size < (uint) _items.Length)
            {
                _size = size + 1;
                _items[size] = item;
            }
            else
            {
                AddWithResize(item);
            }
        }

        /// <summary>
        ///     Clears the contents of the PooledList.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear()
        {
            _version++;
            int size = _size;
            _size = 0;

            if ((size > 0) && _clearOnFree)
            {
                // Clear the elements so that the gc can reclaim the references.
                Array.Clear(_items, 0, size);
            }
        }

        /// <summary>
        ///     Contains returns true if the specified element is in the List.
        ///     It does a linear, O(n) search.  Equality is determined by calling
        ///     EqualityComparer{T}.Default.Equals.
        /// </summary>
        public bool Contains(T item) =>
            // PERF: IndexOf calls Array.IndexOf, which internally
            // calls EqualityComparer<T>.Default.IndexOf, which
            // is specialized for different types. This
            // boosts performance since instead of making a
            // virtual method call each iteration of the loop,
            // via EqualityComparer<T>.Default.Equals, we
            // only make one virtual call to EqualityComparer.IndexOf.
            (_size != 0) && (IndexOf(item) != -1);

        /// <summary>
        ///     Copies the to using the specified array
        /// </summary>
        /// <param name="array">The array</param>
        /// <param name="arrayIndex">The array index</param>
        void ICollection<T>.CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(_items, 0, array, arrayIndex, _size);
        }

        /// <summary>
        ///     Gets the enumerator
        /// </summary>
        /// <returns>An enumerator of t</returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
            => new Enumerator(this);

        /// <summary>
        ///     Gets the enumerator
        /// </summary>
        /// <returns>The enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
            => new Enumerator(this);

        /// <summary>
        ///     Returns the index of the first occurrence of a given value in
        ///     this list. The list is searched forwards from beginning to end.
        /// </summary>
        public int IndexOf(T item)
            => Array.IndexOf(_items, item, 0, _size);

        /// <summary>
        ///     Inserts an element into this list at a given index. The size of the list
        ///     is increased by one. If required, the capacity of the list is doubled
        ///     before inserting the new element.
        /// </summary>
        public void Insert(int index, T item)
        {
            // Note that insertions at the end are legal.
            if ((uint) index > (uint) _size)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (_size == _items.Length)
            {
                EnsureCapacity(_size + 1);
            }

            if (index < _size)
            {
                Array.Copy(_items, index, _items, index + 1, _size - index);
            }

            _items[index] = item;
            _size++;
            _version++;
        }

        // Removes the element at the given index. The size of the list is
        // decreased by one.
        /// <summary>
        ///     Removes the item
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>The bool</returns>
        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

        /// <summary>
        ///     Removes the element at the given index. The size of the list is
        ///     decreased by one.
        /// </summary>
        public void RemoveAt(int index)
        {
            if ((uint) index >= (uint) _size)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            _size--;
            if (index < _size)
            {
                Array.Copy(_items, index + 1, _items, index, _size - index);
            }

            _version++;

            if (_clearOnFree)
            {
                // Clear the removed element so that the gc can reclaim the reference.
                _items[_size] = default(T);
            }
        }

        /// <inheritdoc />
        ReadOnlySpan<T> IReadOnlyPooledList<T>.Span => Span;

        /// <summary>
        ///     Ises the compatible object using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        private static bool IsCompatibleObject(object value) =>
            // Non-null values are fine.  Only accept nulls if T is a class or Nullable<U>.
            // Note that default(T) is not equal to null for value types except when T is Nullable<U>. 
            value is T || ((value == null) && (default(T) == null));

        // Non-inline from List.Add to improve its code quality as uncommon path
        /// <summary>
        ///     Adds the with resize using the specified item
        /// </summary>
        /// <param name="item">The item</param>
        [MethodImpl(MethodImplOptions.NoInlining)]
        private void AddWithResize(T item)
        {
            int size = _size;
            EnsureCapacity(size + 1);
            _size = size + 1;
            _items[size] = item;
        }

        /// <summary>
        ///     Adds the elements of the given collection to the end of this list. If
        ///     required, the capacity of the list is increased to twice the previous
        ///     capacity or the new size, whichever is larger.
        /// </summary>
        public void AddRange(IEnumerable<T> collection)
            => InsertRange(_size, collection);

        /// <summary>
        ///     Adds the elements of the given array to the end of this list. If
        ///     required, the capacity of the list is increased to twice the previous
        ///     capacity or the new size, whichever is larger.
        /// </summary>
        public void AddRange(T[] array)
            => AddRange(array.AsSpan());

        /// <summary>
        ///     Adds the elements of the given <see cref="ReadOnlySpan{T}" /> to the end of this list. If
        ///     required, the capacity of the list is increased to twice the previous
        ///     capacity or the new size, whichever is larger.
        /// </summary>
        public void AddRange(ReadOnlySpan<T> span)
        {
            Span<T> newSpan = InsertSpan(_size, span.Length, false);
            span.CopyTo(newSpan);
        }

        /// <summary>
        ///     Advances the <see cref="Count" /> by the number of items specified,
        ///     increasing the capacity if required, then returns a Span representing
        ///     the set of items to be added, allowing direct writes to that section
        ///     of the collection.
        /// </summary>
        /// <param name="count">The number of items to add.</param>
        public Span<T> AddSpan(int count)
            => InsertSpan(_size, count);

        /// <summary>
        ///     Converts the read only
        /// </summary>
        /// <returns>A read only collection of t</returns>
        public ReadOnlyCollection<T> AsReadOnly()
            => new ReadOnlyCollection<T>(this);

        /// <summary>
        ///     Searches a section of the list for a given element using a binary search
        ///     algorithm.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Elements of the list are compared to the search value using
        ///         the given IComparer interface. If comparer is null, elements of
        ///         the list are compared to the search value using the IComparable
        ///         interface, which in that case must be implemented by all elements of the
        ///         list and the given search value. This method assumes that the given
        ///         section of the list is already sorted; if this is not the case, the
        ///         result will be incorrect.
        ///     </para>
        ///     <para>
        ///         The method returns the index of the given value in the list. If the
        ///         list does not contain the given value, the method returns a negative
        ///         integer. The bitwise complement operator (~) can be applied to a
        ///         negative result to produce the index of the first element (if any) that
        ///         is larger than the given search value. This is also the index at which
        ///         the search value should be inserted into the list in order for the list
        ///         to remain sorted.
        ///     </para>
        /// </remarks>
        public int BinarySearch(int index, int count, T item, IComparer<T> comparer)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            if (_size - index < count)
            {
                throw new ArgumentException("Invalid offset length.");
            }

            return Array.BinarySearch(_items, index, count, item, comparer);
        }

        /// <summary>
        ///     Searches the list for a given element using a binary search
        ///     algorithm. If the item implements <see cref="IComparable{T}" />
        ///     then that is used for comparison, otherwise <see cref="Comparer{T}.Default" /> is used.
        /// </summary>
        public int BinarySearch(T item)
            => BinarySearch(0, Count, item, null);

        /// <summary>
        ///     Searches the list for a given element using a binary search
        ///     algorithm. If the item implements <see cref="IComparable{T}" />
        ///     then that is used for comparison, otherwise <see cref="Comparer{T}.Default" /> is used.
        /// </summary>
        public int BinarySearch(T item, IComparer<T> comparer)
            => BinarySearch(0, Count, item, comparer);

        /// <summary>
        ///     Converts the all using the specified converter
        /// </summary>
        /// <typeparam name="TOutput">The output</typeparam>
        /// <param name="converter">The converter</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>The list</returns>
        public PooledList<TOutput> ConvertAll<TOutput>(Func<T, TOutput> converter)
        {
            if (converter == null)
            {
                throw new ArgumentNullException(nameof(converter));
            }

            PooledList<TOutput> list = new PooledList<TOutput>(_size);
            for (int i = 0; i < _size; i++)
            {
                list._items[i] = converter(_items[i]);
            }

            list._size = _size;
            return list;
        }

        /// <summary>
        ///     Copies this list to the given span.
        /// </summary>
        public void CopyTo(Span<T> span)
        {
            if (span.Length < Count)
            {
                throw new ArgumentException("Destination span is shorter than the list to be copied.");
            }

            Span.CopyTo(span);
        }

        /// <summary>
        ///     Ensures that the capacity of this list is at least the given minimum
        ///     value. If the current capacity of the list is less than min, the
        ///     capacity is increased to twice the current capacity or to min,
        ///     whichever is larger.
        /// </summary>
        private void EnsureCapacity(int min)
        {
            if (_items.Length < min)
            {
                int newCapacity = _items.Length == 0 ? DefaultCapacity : _items.Length * 2;
                // Allow the list to grow to maximum possible capacity (~2G elements) before encountering overflow.
                // Note that this check works even when _items.Length overflowed thanks to the (uint) cast
                if ((uint) newCapacity > MaxArrayLength)
                {
                    newCapacity = MaxArrayLength;
                }

                if (newCapacity < min)
                {
                    newCapacity = min;
                }

                Capacity = newCapacity;
            }
        }

        /// <summary>
        ///     Existses the match
        /// </summary>
        /// <param name="match">The match</param>
        /// <returns>The bool</returns>
        public bool Exists(Func<T, bool> match)
            => FindIndex(match) != -1;

        /// <summary>
        ///     Tries the find using the specified match
        /// </summary>
        /// <param name="match">The match</param>
        /// <param name="result">The result</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>The bool</returns>
        public bool TryFind(Func<T, bool> match, out T result)
        {
            if (match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }

            for (int i = 0; i < _size; i++)
            {
                if (match(_items[i]))
                {
                    result = _items[i];
                    return true;
                }
            }

            result = default(T);
            return false;
        }

        /// <summary>
        ///     Finds the all using the specified match
        /// </summary>
        /// <param name="match">The match</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>The list</returns>
        public PooledList<T> FindAll(Func<T, bool> match)
        {
            if (match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }

            PooledList<T> list = new PooledList<T>();
            for (int i = 0; i < _size; i++)
            {
                if (match(_items[i]))
                {
                    list.Add(_items[i]);
                }
            }

            return list;
        }

        /// <summary>
        ///     Finds the index using the specified match
        /// </summary>
        /// <param name="match">The match</param>
        /// <returns>The int</returns>
        public int FindIndex(Func<T, bool> match)
            => FindIndex(0, _size, match);

        /// <summary>
        ///     Finds the index using the specified start index
        /// </summary>
        /// <param name="startIndex">The start index</param>
        /// <param name="match">The match</param>
        /// <returns>The int</returns>
        public int FindIndex(int startIndex, Func<T, bool> match)
            => FindIndex(startIndex, _size - startIndex, match);

        /// <summary>
        ///     Finds the index using the specified start index
        /// </summary>
        /// <param name="startIndex">The start index</param>
        /// <param name="count">The count</param>
        /// <param name="match">The match</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>The int</returns>
        public int FindIndex(int startIndex, int count, Func<T, bool> match)
        {
            if ((uint) startIndex > (uint) _size)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (count < 0 || startIndex > _size - count)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            if (match is null)
            {
                throw new ArgumentNullException(nameof(match));
            }

            int endIndex = startIndex + count;
            for (int i = startIndex; i < endIndex; i++)
            {
                if (match(_items[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        ///     Tries the find last using the specified match
        /// </summary>
        /// <param name="match">The match</param>
        /// <param name="result">The result</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>The bool</returns>
        public bool TryFindLast(Func<T, bool> match, out T result)
        {
            if (match is null)
            {
                throw new ArgumentNullException(nameof(match));
            }

            for (int i = _size - 1; i >= 0; i--)
            {
                if (match(_items[i]))
                {
                    result = _items[i];
                    return true;
                }
            }

            result = default(T);
            return false;
        }

        /// <summary>
        ///     Finds the last index using the specified match
        /// </summary>
        /// <param name="match">The match</param>
        /// <returns>The int</returns>
        public int FindLastIndex(Func<T, bool> match)
            => FindLastIndex(_size - 1, _size, match);

        /// <summary>
        ///     Finds the last index using the specified start index
        /// </summary>
        /// <param name="startIndex">The start index</param>
        /// <param name="match">The match</param>
        /// <returns>The int</returns>
        public int FindLastIndex(int startIndex, Func<T, bool> match)
            => FindLastIndex(startIndex, startIndex + 1, match);

        /// <summary>
        ///     Finds the last index using the specified start index
        /// </summary>
        /// <param name="startIndex">The start index</param>
        /// <param name="count">The count</param>
        /// <param name="match">The match</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>The int</returns>
        public int FindLastIndex(int startIndex, int count, Func<T, bool> match)
        {
            if (match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }

            if (_size == 0)
            {
                // Special case for 0 length List
                if (startIndex != -1)
                {
                    throw new ArgumentOutOfRangeException(nameof(startIndex));
                }
            }
            else
            {
                // Make sure we're not out of range
                if ((uint) startIndex >= (uint) _size)
                {
                    throw new ArgumentOutOfRangeException(nameof(startIndex));
                }
            }

            // 2nd half of this also catches when startIndex == MAXINT, so MAXINT - 0 + 1 == -1, which is < 0.
            if (count < 0 || startIndex - count + 1 < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            int endIndex = startIndex - count;
            for (int i = startIndex; i > endIndex; i--)
            {
                if (match(_items[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        ///     Fors the each using the specified action
        /// </summary>
        /// <param name="action">The action</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public void ForEach(Action<T> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            int version = _version;
            for (int i = 0; i < _size; i++)
            {
                if (version != _version)
                {
                    break;
                }

                action(_items[i]);
            }

            if (version != _version)
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        ///     Returns an enumerator for this list with the given
        ///     permission for removal of elements. If modifications made to the list
        ///     while an enumeration is in progress, the MoveNext and
        ///     GetObject methods of the enumerator will throw an exception.
        /// </summary>
        public Enumerator GetEnumerator()
            => new Enumerator(this);

        /// <summary>
        ///     Equivalent to PooledList.Span.Slice(index, count).
        /// </summary>
        public Span<T> GetRange(int index, int count)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            if (_size - index < count)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            return Span.Slice(index, count);
        }

        /// <summary>
        ///     Returns the index of the first occurrence of a given value in a range of
        ///     this list. The list is searched forwards, starting at index
        ///     index and ending at count number of elements.
        /// </summary>
        public int IndexOf(T item, int index)
        {
            if (index > _size)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return Array.IndexOf(_items, item, index, _size - index);
        }

        /// <summary>
        ///     Returns the index of the first occurrence of a given value in a range of
        ///     this list. The list is searched forwards, starting at index
        ///     index and upto count number of elements.
        /// </summary>
        public int IndexOf(T item, int index, int count)
        {
            if (index > _size)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (count < 0 || index > _size - count)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            return Array.IndexOf(_items, item, index, count);
        }

        /// <summary>
        ///     Inserts the elements of the given collection at a given index. If
        ///     required, the capacity of the list is increased to twice the previous
        ///     capacity or the new size, whichever is larger.  Ranges may be added
        ///     to the end of the list by setting index to the List's size.
        /// </summary>
        public void InsertRange(int index, IEnumerable<T> collection)
        {
            if ((uint) index > (uint) _size)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            switch (collection)
            {
                case null:
                    throw new ArgumentNullException(nameof(collection));
                    break;

                case ICollection<T> c:
                    int count = c.Count;
                    if (count > 0)
                    {
                        EnsureCapacity(_size + count);
                        if (index < _size)
                        {
                            Array.Copy(_items, index, _items, index + count, _size - index);
                        }

                        // If we're inserting a List into itself, we want to be able to deal with that.
                        if (Equals(this, c))
                        {
                            // Copy first part of _items to insert location
                            Array.Copy(_items, 0, _items, index, index);
                            // Copy last part of _items back to inserted location
                            Array.Copy(_items, index + count, _items, index * 2, _size - index);
                        }
                        else
                        {
                            c.CopyTo(_items, index);
                        }

                        _size += count;
                    }

                    break;

                default:
                    using (IEnumerator<T> en = collection.GetEnumerator())
                    {
                        while (en.MoveNext())
                        {
                            Insert(index++, en.Current);
                        }
                    }

                    break;
            }

            _version++;
        }

        /// <summary>
        ///     Inserts the elements of the given collection at a given index. If
        ///     required, the capacity of the list is increased to twice the previous
        ///     capacity or the new size, whichever is larger.  Ranges may be added
        ///     to the end of the list by setting index to the List's size.
        /// </summary>
        public void InsertRange(int index, ReadOnlySpan<T> span)
        {
            Span<T> newSpan = InsertSpan(index, span.Length, false);
            span.CopyTo(newSpan);
        }

        /// <summary>
        ///     Inserts the elements of the given collection at a given index. If
        ///     required, the capacity of the list is increased to twice the previous
        ///     capacity or the new size, whichever is larger.  Ranges may be added
        ///     to the end of the list by setting index to the List's size.
        /// </summary>
        public void InsertRange(int index, T[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            InsertRange(index, array.AsSpan());
        }

        /// <summary>
        ///     Advances the <see cref="Count" /> by the number of items specified,
        ///     increasing the capacity if required, then returns a Span representing
        ///     the set of items to be added, allowing direct writes to that section
        ///     of the collection.
        /// </summary>
        public Span<T> InsertSpan(int index, int count)
            => InsertSpan(index, count, true);

        /// <summary>
        ///     Inserts the span using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="count">The count</param>
        /// <param name="clearOutput">The clear output</param>
        /// <returns>The output</returns>
        private Span<T> InsertSpan(int index, int count, bool clearOutput)
        {
            EnsureCapacity(_size + count);

            if (index < _size)
            {
                Array.Copy(_items, index, _items, index + count, _size - index);
            }

            _size += count;
            _version++;

            Span<T> output = _items.AsSpan(index, count);

            if (clearOutput && _clearOnFree)
            {
                output.Clear();
            }

            return output;
        }

        /// <summary>
        ///     Returns the index of the last occurrence of a given value in a range of
        ///     this list. The list is searched backwards, starting at the end
        ///     and ending at the first element in the list.
        /// </summary>
        public int LastIndexOf(T item)
        {
            if (_size == 0)
            {
                // Special case for empty list
                return -1;
            }

            return LastIndexOf(item, _size - 1, _size);
        }

        /// <summary>
        ///     Returns the index of the last occurrence of a given value in a range of
        ///     this list. The list is searched backwards, starting at index
        ///     index and ending at the first element in the list.
        /// </summary>
        public int LastIndexOf(T item, int index)
        {
            if (index >= _size)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return LastIndexOf(item, index, index + 1);
        }

        /// <summary>
        ///     Returns the index of the last occurrence of a given value in a range of
        ///     this list. The list is searched backwards, starting at index
        ///     index and upto count elements
        /// </summary>
        public int LastIndexOf(T item, int index, int count)
        {
            if ((Count != 0) && (index < 0))
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if ((Count != 0) && (count < 0))
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            if (_size == 0)
            {
                // Special case for empty list
                return -1;
            }

            if (index >= _size)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (count > index + 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            return Array.LastIndexOf(_items, item, index, count);
        }

        /// <summary>
        ///     This method removes all items which match the predicate.
        ///     The complexity is O(n).
        /// </summary>
        public int RemoveAll(Func<T, bool> match)
        {
            if (match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }

            int freeIndex = 0; // the first free slot in items array

            // Find the first item which needs to be removed.
            while ((freeIndex < _size) && !match(_items[freeIndex]))
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
                while ((current < _size) && match(_items[current]))
                {
                    current++;
                }

                if (current < _size)
                {
                    // copy item to the free slot.
                    _items[freeIndex++] = _items[current++];
                }
            }

            if (_clearOnFree)
            {
                // Clear the removed elements so that the gc can reclaim the references.
                Array.Clear(_items, freeIndex, _size - freeIndex);
            }

            int result = _size - freeIndex;
            _size = freeIndex;
            _version++;
            return result;
        }

        /// <summary>
        ///     Removes a range of elements from this list.
        /// </summary>
        public void RemoveRange(int index, int count)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            if (_size - index < count)
            {
                throw new ArgumentException("Invalid offset length.");
            }

            if (count > 0)
            {
                _size -= count;
                if (index < _size)
                {
                    Array.Copy(_items, index + count, _items, index, _size - index);
                }

                _version++;

                if (_clearOnFree)
                {
                    // Clear the removed elements so that the gc can reclaim the references.
                    Array.Clear(_items, _size, count);
                }
            }
        }

        /// <summary>
        ///     Reverses the elements in this list.
        /// </summary>
        public void Reverse()
            => Reverse(0, _size);

        /// <summary>
        ///     Reverses the elements in a range of this list. Following a call to this
        ///     method, an element in the range given by index and count
        ///     which was previously located at index i will now be located at
        ///     index index + (index + count - i - 1).
        /// </summary>
        public void Reverse(int index, int count)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            if (_size - index < count)
            {
                throw new ArgumentException("Invalid offset length.");
            }

            if (count > 1)
            {
                Array.Reverse(_items, index, count);
            }

            _version++;
        }

        /// <summary>
        ///     Sorts the elements in this list.  Uses the default comparer and
        ///     Array.Sort.
        /// </summary>
        public void Sort()
            => Sort(0, Count, null);

        /// <summary>
        ///     Sorts the elements in this list.  Uses Array.Sort with the
        ///     provided comparer.
        /// </summary>
        /// <param name="comparer"></param>
        public void Sort(IComparer<T> comparer)
            => Sort(0, Count, comparer);

        /// <summary>
        ///     Sorts the elements in a section of this list. The sort compares the
        ///     elements to each other using the given IComparer interface. If
        ///     comparer is null, the elements are compared to each other using
        ///     the IComparable interface, which in that case must be implemented by all
        ///     elements of the list.
        ///     This method uses the Array.Sort method to sort the elements.
        /// </summary>
        public void Sort(int index, int count, IComparer<T> comparer)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            if (_size - index < count)
            {
                throw new ArgumentException("Invalid offset length.");
            }

            if (count > 1)
            {
                Array.Sort(_items, index, count, comparer);
            }

            _version++;
        }

        /// <summary>
        ///     Sorts the comparison
        /// </summary>
        /// <param name="comparison">The comparison</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Sort(Func<T, T, int> comparison)
        {
            if (comparison == null)
            {
                throw new ArgumentNullException(nameof(comparison));
            }

            if (_size > 1)
            {
                // List<T> uses ArraySortHelper here but since it's an internal class,
                // we're creating an IComparer<T> using the comparison function to avoid
                // duplicating all that code.
                Array.Sort(_items, 0, _size, new Comparer(comparison));
            }

            _version++;
        }

        /// <summary>
        ///     ToArray returns an array containing the contents of the List.
        ///     This requires copying the List, which is an O(n) operation.
        /// </summary>
        public T[] ToArray()
        {
            if (_size == 0)
            {
                return s_emptyArray;
            }

            return Span.ToArray();
        }

        /// <summary>
        ///     Sets the capacity of this list to the size of the list. This method can
        ///     be used to minimize a list's memory overhead once it is known that no
        ///     new elements will be added to the list. To completely clear a list and
        ///     release all memory referenced by the list, execute the following
        ///     statements:
        ///     <code>
        /// list.Clear();
        /// list.TrimExcess();
        /// </code>
        /// </summary>
        public void TrimExcess()
        {
            int threshold = (int) (_items.Length * 0.9);
            if (_size < threshold)
            {
                Capacity = _size;
            }
        }

        /// <summary>
        ///     Trues the for all using the specified match
        /// </summary>
        /// <param name="match">The match</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>The bool</returns>
        public bool TrueForAll(Func<T, bool> match)
        {
            if (match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }

            for (int i = 0; i < _size; i++)
            {
                if (!match(_items[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Returns the array
        /// </summary>
        private void ReturnArray()
        {
            if (_items.Length == 0)
            {
                return;
            }

            try
            {
                // Clear the elements so that the gc can reclaim the references.
                _pool.Return(_items, _clearOnFree);
            }
            catch (ArgumentException)
            {
                // oh well, the array pool didn't like our array
            }

            _items = s_emptyArray;
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
        public struct Enumerator : IEnumerator<T>, IEnumerator
        {
            /// <summary>
            ///     The list
            /// </summary>
            private readonly PooledList<T> _list;

            /// <summary>
            ///     The index
            /// </summary>
            private int _index;

            /// <summary>
            ///     The version
            /// </summary>
            private readonly int _version;

            /// <summary>
            ///     The current
            /// </summary>
            private T _current;

            /// <summary>
            ///     Initializes a new instance of the <see cref="Enumerator" /> class
            /// </summary>
            /// <param name="list">The list</param>
            internal Enumerator(PooledList<T> list)
            {
                _list = list;
                _index = 0;
                _version = list._version;
                _current = default(T);
            }

            /// <summary>
            ///     Disposes this instance
            /// </summary>
            public void Dispose()
            {
            }

            /// <summary>
            ///     Moves the next
            /// </summary>
            /// <returns>The bool</returns>
            public bool MoveNext()
            {
                PooledList<T> localList = _list;

                if ((_version == localList._version) && ((uint) _index < (uint) localList._size))
                {
                    _current = localList._items[_index];
                    _index++;
                    return true;
                }

                return MoveNextRare();
            }

            /// <summary>
            ///     Moves the next rare
            /// </summary>
            /// <exception cref="InvalidOperationException">Collection was modified; enumeration operation may not execute.</exception>
            /// <returns>The bool</returns>
            private bool MoveNextRare()
            {
                if (_version != _list._version)
                {
                    throw new InvalidOperationException("Collection was modified; enumeration operation may not execute.");
                }

                _index = _list._size + 1;
                _current = default(T);
                return false;
            }

            /// <summary>
            ///     Gets the value of the current
            /// </summary>
            public T Current => _current;

            /// <summary>
            ///     Gets the value of the current
            /// </summary>
            object IEnumerator.Current
            {
                get
                {
                    if (_index == 0 || _index == _list._size + 1)
                    {
                        throw new InvalidOperationException("Enumeration has either not started or has already finished.");
                    }

                    return Current;
                }
            }

            /// <summary>
            ///     Resets this instance
            /// </summary>
            /// <exception cref="InvalidOperationException">Collection was modified; enumeration operation may not execute.</exception>
            void IEnumerator.Reset()
            {
                if (_version != _list._version)
                {
                    throw new InvalidOperationException("Collection was modified; enumeration operation may not execute.");
                }

                _index = 0;
                _current = default(T);
            }
        }

        /// <summary>
        ///     The comparer
        /// </summary>
        private readonly struct Comparer : IComparer<T>
        {
            /// <summary>
            ///     The comparison
            /// </summary>
            private readonly Func<T, T, int> _comparison;

            /// <summary>
            ///     Initializes a new instance of the <see cref="Comparer" /> class
            /// </summary>
            /// <param name="comparison">The comparison</param>
            public Comparer(Func<T, T, int> comparison) => _comparison = comparison;

            /// <summary>
            ///     Compares the x
            /// </summary>
            /// <param name="x">The </param>
            /// <param name="y">The </param>
            /// <returns>The int</returns>
            public int Compare(T x, T y) => _comparison(x, y);
        }
    }
}