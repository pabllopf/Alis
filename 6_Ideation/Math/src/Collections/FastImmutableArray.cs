// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastImmutableArray.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Alis.Core.Aspect.Math.Collections
{
    /// <summary>
    ///     A readonly array with O(1) indexable lookup time, wrapping a <typeparamref name="T" /> array without defensive copying.
    /// </summary>
    /// <typeparam name="T">The type of element stored by the array.</typeparam>
    [ExcludeFromCodeCoverage]
    public readonly struct FastImmutableArray<T> : IEnumerable<T>, IEquatable<FastImmutableArray<T>>, IFastImmutableArray
    {
        /// <summary>
        ///     A writable array accessor that can be converted into an <see cref="FastImmutableArray{T}" /> instance without allocating memory.
        /// </summary>
        [ExcludeFromCodeCoverage]
        public sealed class Builder : IList<T>, IReadOnlyList<T>
        {
            /// <summary>
            ///     The number of initialized elements in the array.
            /// </summary>
            private int _count;

            /// <summary>
            ///     The backing array for the builder.
            /// </summary>
            private T[] _elements;

            /// <summary>
            ///     Initializes a new instance of the <see cref="Builder" /> class with the specified initial capacity.
            /// </summary>
            /// <param name="capacity">The initial capacity of the internal array.</param>
            internal Builder(int capacity)
            {
                _elements = new T[capacity];
                _count = 0;
            }

            /// <summary>
            ///     Initializes a new instance of the <see cref="Builder" /> class with a default capacity of 8.
            /// </summary>
            internal Builder()
                : this(8)
            {
            }

            /// <summary>
            ///     Gets or sets the length of the internal backing array. When set, the internal array is reallocated to the given capacity if it is not already at the specified length.
            /// </summary>
            /// <exception cref="ArgumentException">Thrown when the value is less than <see cref="Count" />.</exception>
            public int Capacity
            {
                get => _elements.Length;
                set
                {
                    if (value < _count)
                    {
                        throw new ArgumentException("Capacity must be greater than or equal to Count.");
                    }

                    if (value != _elements.Length)
                    {
                        if (value > 0)
                        {
                            T[] temp = new T[value];
                            if (_count > 0)
                            {
                                System.Array.Copy(_elements, temp, _count);
                            }

                            _elements = temp;
                        }
                        else
                        {
                            _elements = Empty.Array!;
                        }
                    }
                }
            }

            /// <summary>
            ///     Gets or sets the number of initialized elements in the builder.
            /// </summary>
            /// <remarks>
            ///     If the value is decreased, the array contents are truncated.
            ///     If the value is increased, the added elements are initialized to the default value of type
            ///     <typeparamref name="T" />.
            /// </remarks>
            public int Count
            {
                get => _count;

                set
                {
                    if (value < _count)
                    {
                        // truncation mode
                        // Clear the elements of the elements that are effectively removed.

                        // PERF: Array.Clear works well for big arrays,
                        //       but may have too much overhead with small ones (which is the common case here)
                        if (_count - value > 64)
                        {
                            System.Array.Clear(_elements, value, _count - value);
                        }
                        else
                        {
                            for (int i = value; i < Count; i++)
                            {
                                _elements[i] = default(T)!;
                            }
                        }
                    }
                    else if (value > _count)
                    {
                        // expansion
                        EnsureCapacity(value);
                    }

                    _count = value;
                }
            }

            /// <summary>
            ///     Gets or sets the element at the specified index.
            /// </summary>
            /// <param name="index">The zero-based index of the element to get or set.</param>
            /// <returns>The element at the specified index.</returns>
            /// <exception cref="IndexOutOfRangeException">Thrown when <paramref name="index" /> is greater than or equal to <see cref="Count" />.</exception>
            public T this[int index]
            {
                get
                {
                    if (index >= Count)
                    {
                        ThrowIndexOutOfRangeException();
                    }

                    return _elements[index];
                }

                set
                {
                    if (index >= Count)
                    {
                        ThrowIndexOutOfRangeException();
                    }

                    _elements[index] = value;
                }
            }

            /// <summary>
            ///     Gets a value indicating whether the <see cref="ICollection{T}" /> is read-only.
            /// </summary>
            /// <returns>
            ///     <c>true</c> if the <see cref="ICollection{T}" /> is read-only; otherwise, <c>false</c>.
            /// </returns>
            bool ICollection<T>.IsReadOnly => false;

            /// <summary>
            ///     Removes all items from the builder, setting <see cref="Count" /> to zero.
            /// </summary>
            public void Clear()
            {
                Count = 0;
            }

            /// <summary>
            ///     Inserts an item at the specified index, shifting subsequent elements to the right.
            /// </summary>
            /// <param name="index">The zero-based index at which <paramref name="item" /> should be inserted.</param>
            /// <param name="item">The object to insert.</param>
            public void Insert(int index, T item)
            {
                EnsureCapacity(Count + 1);

                if (index < Count)
                {
                    System.Array.Copy(_elements, index, _elements, index + 1, Count - index);
                }

                _count++;
                _elements[index] = item;
            }

            /// <summary>
            ///     Adds an item to the end of the builder.
            /// </summary>
            /// <param name="item">The object to add.</param>
            public void Add(T item)
            {
                int newCount = _count + 1;
                EnsureCapacity(newCount);
                _elements[_count] = item;
                _count = newCount;
            }

            /// <summary>
            ///     Removes the first occurrence of the specified element from the builder.
            ///     If no match is found, the builder remains unchanged.
            /// </summary>
            /// <param name="element">The element to remove.</param>
            /// <returns><c>true</c> if the element was found and removed; otherwise, <c>false</c>.</returns>
            public bool Remove(T element)
            {
                int index = IndexOf(element);
                if (index >= 0)
                {
                    RemoveAt(index);
                    return true;
                }

                return false;
            }

            /// <summary>
            ///     Removes the element at the specified index, shifting subsequent elements to the left.
            /// </summary>
            /// <param name="index">The zero-based index of the item to remove.</param>
            public void RemoveAt(int index)
            {
                if (index < Count - 1)
                {
                    System.Array.Copy(_elements, index + 1, _elements, index, Count - index - 1);
                }

                Count--;
            }

            /// <summary>
            ///     Determines whether the builder contains a specific value.
            /// </summary>
            /// <param name="item">The object to locate.</param>
            /// <returns><c>true</c> if <paramref name="item" /> is found; otherwise, <c>false</c>.</returns>
            public bool Contains(T item) => IndexOf(item) >= 0;

            /// <summary>
            ///     Copies the current contents to the specified array starting at the given index.
            /// </summary>
            /// <param name="array">The destination array.</param>
            /// <param name="index">The starting index in the destination array.</param>
            public void CopyTo(T[] array, int index)
            {
                System.Array.Copy(_elements, 0, array, index, Count);
            }

            /// <summary>
            ///     Determines the index of a specific item in the builder.
            /// </summary>
            /// <param name="item">The object to locate.</param>
            /// <returns>The index of <paramref name="item" /> if found; otherwise, -1.</returns>
            public int IndexOf(T item) => IndexOf(item, 0, _count, EqualityComparer<T>.Default);

            /// <summary>
            ///     Returns an enumerator for the contents of the array.
            /// </summary>
            /// <returns>An enumerator.</returns>
            IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

            /// <summary>
            ///     Returns an enumerator for the contents of the array.
            /// </summary>
            /// <returns>An enumerator.</returns>
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            /// <summary>
            ///     Throws an <see cref="IndexOutOfRangeException" /> indicating that the index is out of valid range.
            /// </summary>
            private static void ThrowIndexOutOfRangeException() => throw new IndexOutOfRangeException();

            /// <summary>
            ///     Gets a read-only reference to the element at the specified index.
            /// </summary>
            /// <param name="index">The zero-based index of the element.</param>
            /// <returns>A read-only reference to the element at the specified index.</returns>
            /// <exception cref="IndexOutOfRangeException">Thrown when <paramref name="index" /> is greater than or equal to <see cref="Count" />.</exception>
            public ref readonly T ItemRef(int index)
            {
                if (index >= Count)
                {
                    ThrowIndexOutOfRangeException();
                }

                return ref _elements[index];
            }

            /// <summary>
            ///     Returns an immutable copy of the current contents of this builder.
            /// </summary>
            /// <returns>A new <see cref="FastImmutableArray{T}" /> containing a copy of the current data.</returns>
            public FastImmutableArray<T> ToImmutable() => new FastImmutableArray<T>(ToArray());

            /// <summary>
            ///     Extracts the internal array as an <see cref="FastImmutableArray{T}" /> and resets the builder to a zero-length array.
            /// </summary>
            /// <exception cref="InvalidOperationException">Thrown when <see cref="Builder.Count" /> does not equal <see cref="Builder.Capacity" />.</exception>
            /// <returns>An <see cref="FastImmutableArray{T}" /> wrapping the internal array.</returns>
            public FastImmutableArray<T> MoveToImmutable()
            {
                if (Capacity != Count)
                {
                    throw new InvalidOperationException("The capacity must equal the count to move the array.");
                }

                T[] temp = _elements;
                _elements = Empty.Array!;
                _count = 0;
                return new FastImmutableArray<T>(temp);
            }

            /// <summary>
            ///     Returns the current contents as an <see cref="FastImmutableArray{T}" /> and sets the collection to a zero-length array.
            /// </summary>
            /// <remarks>
            ///     If <see cref="Capacity" /> equals <see cref="Count" />, the internal array will be extracted
            ///     as an <see cref="FastImmutableArray{T}" /> without copying the contents. Otherwise, the contents
            ///     will be copied into a new array. The collection will then be set to a zero length array.
            /// </remarks>
            /// <returns>An immutable array.</returns>
            public FastImmutableArray<T> DrainToImmutable()
            {
                T[] result = _elements;

                if (result.Length != _count)
                {
                    result = ToArray();
                }

                _elements = Empty.Array!;
                _count = 0;

                return new FastImmutableArray<T>(result);
            }

            /// <summary>
            ///     Inserts the elements of the specified <see cref="FastImmutableArray{T}" /> at the given index.
            /// </summary>
            /// <param name="index">The zero-based index at which to insert the values.</param>
            /// <param name="items">The elements to insert.</param>
            public void InsertRange(int index, FastImmutableArray<T> items)
            {
                if (items.IsEmpty)
                {
                    return;
                }

                EnsureCapacity(Count + items.Length);

                if (index != Count)
                {
                    System.Array.Copy(_elements, index, _elements, index + items.Length, _count - index);
                }

                System.Array.Copy(items.Array!, 0, _elements, index, items.Length);

                _count += items.Length;
            }

            /// <summary>
            ///     Adds the specified items to the end of the array.
            /// </summary>
            /// <param name="items">The items to add.</param>
            public void AddRange(params T[] items)
            {
                int offset = Count;
                Count += items.Length;

                System.Array.Copy(items, 0, _elements, offset, items.Length);
            }

            /// <summary>
            ///     Adds the specified items derived from <typeparamref name="T" /> to the end of the array.
            /// </summary>
            /// <typeparam name="TDerived">The type that derives from <typeparamref name="T" />.</typeparam>
            /// <param name="items">The items to add.</param>
            public void AddRange<TDerived>(TDerived[] items) where TDerived : T
            {
                int offset = Count;
                Count += items.Length;

                System.Array.Copy(items, 0, _elements, offset, items.Length);
            }

            /// <summary>
            ///     Adds the specified items to the end of the array up to the given length.
            /// </summary>
            /// <param name="items">The items to add.</param>
            /// <param name="length">The number of elements from the source array to add.</param>
            public void AddRange(T[] items, int length)
            {
                int offset = Count;
                Count += length;

                System.Array.Copy(items, 0, _elements, offset, length);
            }

            /// <summary>
            ///     Adds the specified items to the end of the array from another <see cref="FastImmutableArray{T}" />.
            /// </summary>
            /// <param name="items">The items to add.</param>
            public void AddRange(FastImmutableArray<T> items)
            {
                AddRange(items, items.Length);
            }

            /// <summary>
            ///     Adds the specified items to the end of the array from another <see cref="FastImmutableArray{T}" /> up to a given length.
            /// </summary>
            /// <param name="items">The items to add.</param>
            /// <param name="length">The number of elements from the source array to add.</param>
            public void AddRange(FastImmutableArray<T> items, int length)
            {
                if (items.Array != null)
                {
                    AddRange(items.Array, length);
                }
            }

            /// <summary>
            ///     Adds the specified items derived from <typeparamref name="T" /> to the end of the array.
            /// </summary>
            /// <typeparam name="TDerived">The type that derives from <typeparamref name="T" />.</typeparam>
            /// <param name="items">The items to add at the end of the array.</param>
            public void AddRange<TDerived>(FastImmutableArray<TDerived> items) where TDerived : T
            {
                if (items.Array != null)
                {
                    AddRange(items.Array);
                }
            }

            /// <summary>
            ///     Adds the specified items from another builder to the end of the array.
            /// </summary>
            /// <param name="items">The builder whose items will be added.</param>
            public void AddRange(Builder items)
            {
                AddRange(items._elements, items.Count);
            }

            /// <summary>
            ///     Adds the specified items from a derived builder to the end of the array.
            /// </summary>
            /// <typeparam name="TDerived">The type that derives from <typeparamref name="T" />.</typeparam>
            /// <param name="items">The builder whose items will be added.</param>
            public void AddRange<TDerived>(FastImmutableArray<TDerived>.Builder items) where TDerived : T
            {
                AddRange(items._elements, items.Count);
            }

            /// <summary>
            ///     Removes the first occurrence of the specified element using a custom equality comparer.
            /// </summary>
            /// <param name="element">The element to remove.</param>
            /// <param name="equalityComparer">
            ///     The equality comparer to use. If <c>null</c>, <see cref="EqualityComparer{T}.Default" /> is used.
            /// </param>
            /// <returns><c>true</c> if the element was found and removed; otherwise, <c>false</c>.</returns>
            public bool Remove(T element, IEqualityComparer<T> equalityComparer)
            {
                int index = IndexOf(element, 0, _count, equalityComparer);

                if (index >= 0)
                {
                    RemoveAt(index);
                    return true;
                }

                return false;
            }

            /// <summary>
            ///     Removes all the elements that match the conditions defined by the specified predicate.
            /// </summary>
            /// <param name="match">The <see cref="Predicate{T}" /> that defines the conditions of elements to remove.</param>
            public void RemoveAll(Predicate<T> match)
            {
                List<int> removeIndices = null;
                for (int i = 0; i < _count; i++)
                {
                    if (match(_elements[i]))
                    {
                        removeIndices ??= new List<int>();
                        removeIndices.Add(i);
                    }
                }

                if (removeIndices != null)
                {
                    RemoveAtRange(removeIndices);
                }
            }

            /// <summary>
            ///     Removes a range of elements starting at the specified index.
            /// </summary>
            /// <param name="index">The zero-based index of the first element to remove.</param>
            /// <param name="length">The number of elements to remove.</param>
            public void RemoveRange(int index, int length)
            {
                if (length == 0)
                {
                    return;
                }

                if (index + length < _count)
                {
#if NET
                    if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
                    {
                        System.Array.Clear(_elements, index, length); // Clear the elements so that the gc can reclaim the references.
                    }
#endif
                    System.Array.Copy(_elements, index + length, _elements, index, Count - index - length);
                }

                _count -= length;
            }

            /// <summary>
            ///     Removes all occurrences of the specified items from this list.
            /// </summary>
            /// <param name="items">The items to remove.</param>
            public void RemoveRange(IEnumerable<T> items)
            {
                RemoveRange(items, EqualityComparer<T>.Default);
            }

            /// <summary>
            ///     Removes all occurrences of the specified items using a custom equality comparer.
            /// </summary>
            /// <param name="items">The items to remove.</param>
            /// <param name="equalityComparer">
            ///     The equality comparer to use. If <c>null</c>, <see cref="EqualityComparer{T}.Default" /> is used.
            /// </param>
            public void RemoveRange(IEnumerable<T> items, IEqualityComparer<T> equalityComparer)
            {
                SortedSet<int> indicesToRemove = new SortedSet<int>();
                foreach (T item in items)
                {
                    int index = IndexOf(item, 0, _count, equalityComparer);
                    while ((index >= 0) && !indicesToRemove.Add(index) && (index + 1 < _count))
                    {
                        index = IndexOf(item, index + 1, equalityComparer);
                    }
                }

                RemoveAtRange(indicesToRemove);
            }

            /// <summary>
            ///     Replaces the first equal element in the list with the specified element.
            /// </summary>
            /// <param name="oldValue">The element to replace.</param>
            /// <param name="newValue">The element to replace the old element with.</param>
            public void Replace(T oldValue, T newValue)
            {
                Replace(oldValue, newValue, EqualityComparer<T>.Default);
            }

            /// <summary>
            ///     Replaces the first equal element in the list with the specified element, using a custom equality comparer.
            /// </summary>
            /// <param name="oldValue">The element to replace.</param>
            /// <param name="newValue">The element to replace the old element with.</param>
            /// <param name="equalityComparer">
            ///     The equality comparer to use. If <c>null</c>, <see cref="EqualityComparer{T}.Default" /> is used.
            /// </param>
            public void Replace(T oldValue, T newValue, IEqualityComparer<T> equalityComparer)
            {
                int index = IndexOf(oldValue, 0, _count, equalityComparer);

                if (index >= 0)
                {
                    _elements[index] = newValue;
                }
            }

            /// <summary>
            ///     Creates a new array with the current contents of this Builder.
            /// </summary>
            /// <returns>A new <typeparamref name="T" /> array containing the current elements.</returns>
            public T[] ToArray()
            {
                if (Count == 0)
                {
                    return Empty.Array!;
                }

                T[] result = new T[Count];
                System.Array.Copy(_elements, result, Count);
                return result;
            }

            /// <summary>
            ///     Copies the contents of this array to the specified array.
            /// </summary>
            /// <param name="destination">The destination array.</param>
            public void CopyTo(T[] destination)
            {
                System.Array.Copy(_elements, 0, destination, 0, Count);
            }

            /// <summary>
            ///     Copies a range of elements from this array to the specified destination array.
            /// </summary>
            /// <param name="sourceIndex">The index into this collection of the first element to copy.</param>
            /// <param name="destination">The destination array.</param>
            /// <param name="destinationIndex">The index into the destination array where the first copied element is written.</param>
            /// <param name="length">The number of elements to copy.</param>
            public void CopyTo(int sourceIndex, T[] destination, int destinationIndex, int length)
            {
                System.Array.Copy(_elements, sourceIndex, destination, destinationIndex, length);
            }

            /// <summary>
            ///     Resizes the backing array to accommodate the specified capacity requirement.
            /// </summary>
            /// <param name="capacity">The minimum required capacity.</param>
            private void EnsureCapacity(int capacity)
            {
                if (_elements.Length < capacity)
                {
                    int newCapacity = System.Math.Max(_elements.Length * 2, capacity);
                    System.Array.Resize(ref _elements, newCapacity);
                }
            }

            /// <summary>
            ///     Searches the array for the specified item starting from a given index.
            /// </summary>
            /// <param name="item">The item to search for.</param>
            /// <param name="startIndex">The zero-based index at which to begin the search.</param>
            /// <returns>The zero-based index of the item if found; otherwise, -1.</returns>
            public int IndexOf(T item, int startIndex) => IndexOf(item, startIndex, Count - startIndex, EqualityComparer<T>.Default);

            /// <summary>
            ///     Searches the array for the specified item within a range.
            /// </summary>
            /// <param name="item">The item to search for.</param>
            /// <param name="startIndex">The zero-based index at which to begin the search.</param>
            /// <param name="count">The number of elements to search.</param>
            /// <returns>The zero-based index of the item if found; otherwise, -1.</returns>
            public int IndexOf(T item, int startIndex, int count) => IndexOf(item, startIndex, count, EqualityComparer<T>.Default);

            /// <summary>
            ///     Searches the array for the specified item within a range using a custom equality comparer.
            /// </summary>
            /// <param name="item">The item to search for.</param>
            /// <param name="startIndex">The zero-based index at which to begin the search.</param>
            /// <param name="count">The number of elements to search.</param>
            /// <param name="equalityComparer">
            ///     The equality comparer to use. If <c>null</c>, <see cref="EqualityComparer{T}.Default" /> is used.
            /// </param>
            /// <returns>The zero-based index of the item if found; otherwise, -1.</returns>
            public int IndexOf(T item, int startIndex, int count, IEqualityComparer<T> equalityComparer)
            {
                if ((count == 0) && (startIndex == 0))
                {
                    return -1;
                }


                equalityComparer ??= EqualityComparer<T>.Default;
                if (Equals(equalityComparer, EqualityComparer<T>.Default))
                {
                    return System.Array.IndexOf(_elements, item, startIndex, count);
                }

                for (int i = startIndex; i < startIndex + count; i++)
                {
                    if (equalityComparer.Equals(_elements[i], item))
                    {
                        return i;
                    }
                }

                return -1;
            }

            /// <summary>
            ///     Searches the array for the specified item starting from a given index with a custom equality comparer.
            /// </summary>
            /// <param name="item">The item to search for.</param>
            /// <param name="startIndex">The zero-based index at which to begin the search.</param>
            /// <param name="equalityComparer">
            ///     The equality comparer to use. If <c>null</c>, <see cref="EqualityComparer{T}.Default" /> is used.
            /// </param>
            /// <returns>The zero-based index of the item if found; otherwise, -1.</returns>
            public int IndexOf(T item, int startIndex, IEqualityComparer<T> equalityComparer) => IndexOf(item, startIndex, Count - startIndex, equalityComparer);

            /// <summary>
            ///     Searches the array for the specified item in reverse order.
            /// </summary>
            /// <param name="item">The item to search for.</param>
            /// <returns>The zero-based index of the item if found; otherwise, -1.</returns>
            public int LastIndexOf(T item)
            {
                if (Count == 0)
                {
                    return -1;
                }

                return LastIndexOf(item, Count - 1, Count, EqualityComparer<T>.Default);
            }

            /// <summary>
            ///     Searches the array for the specified item in reverse order starting from a given index.
            /// </summary>
            /// <param name="item">The item to search for.</param>
            /// <param name="startIndex">The zero-based index at which to begin the reverse search.</param>
            /// <returns>The zero-based index of the item if found; otherwise, -1.</returns>
            public int LastIndexOf(T item, int startIndex)
            {
                if ((Count == 0) && (startIndex == 0))
                {
                    return -1;
                }


                return LastIndexOf(item, startIndex, startIndex + 1, EqualityComparer<T>.Default);
            }

            /// <summary>
            ///     Searches the array for the specified item in reverse order within a range.
            /// </summary>
            /// <param name="item">The item to search for.</param>
            /// <param name="startIndex">The zero-based index at which to begin the reverse search.</param>
            /// <param name="count">The number of elements to search.</param>
            /// <returns>The zero-based index of the item if found; otherwise, -1.</returns>
            public int LastIndexOf(T item, int startIndex, int count) => LastIndexOf(item, startIndex, count, EqualityComparer<T>.Default);

            /// <summary>
            ///     Searches the array for the specified item in reverse order within a range using a custom equality comparer.
            /// </summary>
            /// <param name="item">The item to search for.</param>
            /// <param name="startIndex">The zero-based index at which to begin the reverse search.</param>
            /// <param name="count">The number of elements to search.</param>
            /// <param name="equalityComparer">The equality comparer to use. If <c>null</c>, <see cref="EqualityComparer{T}.Default" /> is used.</param>
            /// <returns>The zero-based index of the item if found; otherwise, -1.</returns>
            public int LastIndexOf(T item, int startIndex, int count, IEqualityComparer<T> equalityComparer)
            {
                if ((count == 0) && (startIndex == 0))
                {
                    return -1;
                }


                equalityComparer ??= EqualityComparer<T>.Default;
                if (Equals(equalityComparer, EqualityComparer<T>.Default))
                {
                    return System.Array.LastIndexOf(_elements, item, startIndex, count);
                }

                for (int i = startIndex; i >= startIndex - count + 1; i--)
                {
                    if (equalityComparer.Equals(item, _elements[i]))
                    {
                        return i;
                    }
                }

                return -1;
            }

            /// <summary>
            ///     Reverses the order of elements in the collection in-place.
            /// </summary>
            public void Reverse()
            {
#if NET || NETSTANDARD2_1_OR_GREATER
                System.Array.Reverse(_elements, 0, _count);
#else
                // The non-generic Array.Reverse is not used because it does not perform
                // well for non-primitive value types.
                int i = 0;
                int j = _count - 1;
                T[] array = _elements;
                while (i < j)
                {
                    (array[i], array[j]) = (array[j], array[i]);
                    i++;
                    j--;
                }
#endif
            }

            /// <summary>
            ///     Sorts the elements in the entire array using the default comparer.
            /// </summary>
            public void Sort()
            {
                if (Count > 1)
                {
                    System.Array.Sort(_elements, 0, Count, Comparer<T>.Default);
                }
            }

            /// <summary>
            ///     Sorts the elements using the specified <see cref="Comparison{T}" />.
            /// </summary>
            /// <param name="comparison">The <see cref="Comparison{T}" /> to use when comparing elements.</param>
            /// <exception cref="ArgumentNullException">Thrown when <paramref name="comparison" /> is null.</exception>
            public void Sort(Comparison<T> comparison)
            {
                if (Count > 1)
                {
#if NET
                    // MemoryExtensions.Sort is not available in .NET Framework / Standard 2.0.
                    // But the overload with a Comparison argument doesn't allocate.
                    _elements.AsSpan(0, _count).Sort(comparison);
#else
                    // Array.Sort does not have an overload that takes both bounds and a Comparison.
                    // We could special case _count == _elements.Length in order to try to avoid
                    // the IComparer allocation, but the Array.Sort overload that takes a Comparison
                    // allocates such an IComparer internally, anyway.
                    System.Array.Sort(_elements, 0, _count, Comparer<T>.Create(comparison));
#endif
                }
            }

            /// <summary>
            ///     Sorts the elements using the specified <see cref="IComparer{T}" />.
            /// </summary>
            /// <param name="comparer">The comparer to use. If <c>null</c>, the default comparer is used.</param>
            public void Sort(IComparer<T> comparer)
            {
                if (Count > 1)
                {
                    System.Array.Sort(_elements, 0, _count, comparer);
                }
            }

            /// <summary>
            ///     Sorts a range of elements using the specified comparer.
            /// </summary>
            /// <param name="index">The zero-based index of the first element to sort.</param>
            /// <param name="count">The number of elements to sort.</param>
            /// <param name="comparer">The comparer to use. If <c>null</c>, the default comparer is used.</param>
            public void Sort(int index, int count, IComparer<T> comparer)
            {
                // Don't rely on Array.Sort's argument validation since our internal array may exceed
                // the bounds of the publicly addressable region.


                if (count > 1)
                {
                    System.Array.Sort(_elements, index, count, comparer);
                }
            }

            /// <summary>
            ///     Copies the current contents to the specified <see cref="Span{T}" />.
            /// </summary>
            /// <param name="destination">The <see cref="Span{T}" /> to copy to.</param>
            public void CopyTo(Span<T> destination)
            {
                new ReadOnlySpan<T>(_elements, 0, Count).CopyTo(destination);
            }

            /// <summary>
            ///     Returns an enumerator that iterates through the collection.
            /// </summary>
            /// <returns>An enumerator for the contents of the array.</returns>
            public IEnumerator<T> GetEnumerator()
            {
                for (int i = 0; i < Count; i++)
                {
                    yield return this[i];
                }
            }

            /// <summary>
            ///     Adds items from a source array of a derived type to this collection.
            /// </summary>
            /// <typeparam name="TDerived">The type of source elements (must derive from <typeparamref name="T" />).</typeparam>
            /// <param name="items">The source array.</param>
            /// <param name="length">The number of elements to add.</param>
            private void AddRange<TDerived>(TDerived[] items, int length) where TDerived : T
            {
                EnsureCapacity(Count + length);

                int offset = Count;
                Count += length;

                T[] nodes = _elements;
                for (int i = 0; i < length; i++)
                {
                    nodes[offset + i] = items[i];
                }
            }

            /// <summary>
            ///     Removes elements at the specified sorted indices efficiently.
            /// </summary>
            /// <param name="indicesToRemove">The sorted collection of indices to remove.</param>
            private void RemoveAtRange(ICollection<int> indicesToRemove)
            {
                if (indicesToRemove.Count == 0)
                {
                    return;
                }

                int copied = 0;
                int removed = 0;
                int lastIndexRemoved = -1;
                foreach (int indexToRemove in indicesToRemove)
                {
                    int copyLength = lastIndexRemoved == -1 ? indexToRemove : indexToRemove - lastIndexRemoved - 1;
                    System.Array.Copy(_elements, copied + removed, _elements, copied, copyLength);
                    removed++;
                    copied += copyLength;
                    lastIndexRemoved = indexToRemove;
                }

                System.Array.Copy(_elements, copied + removed, _elements, copied, _elements.Length - (copied + removed));

                _count -= indicesToRemove.Count;
            }

            /// <summary>Gets a <see cref="Memory{T}" /> for the filled portion of the backing array.</summary>
            internal Memory<T> AsMemory() => new Memory<T>(_elements, 0, _count);
        }

        /// <summary>
        ///     Creates a new <see cref="Builder" /> with a specified initial capacity.
        /// </summary>
        /// <typeparam name="T1">The type parameter (unused, retained for signature compatibility).</typeparam>
        /// <param name="typesLength">The initial capacity of the builder.</param>
        /// <returns>A new <see cref="Builder" /> initialized with the given capacity.</returns>
        public static Builder CreateBuilder<T1>(int typesLength) => new Builder {Capacity = typesLength};


        /// <summary>
        ///     Returns a <see cref="ReadOnlySpan{T}" /> over the underlying array.
        /// </summary>
        /// <returns>A read-only span of <typeparamref name="T" /> representing the array contents.</returns>
        public ReadOnlySpan<T> AsSpan() => Array.AsSpan();

        /// <summary>
        ///     Searches for the specified element and returns the index of its first occurrence.
        /// </summary>
        /// <typeparam name="T1">The type parameter (unused).</typeparam>
        /// <param name="typeId">The element to locate.</param>
        /// <returns>The zero-based index of the element if found; otherwise, -1.</returns>
        public int IndexOf<T1>(T typeId) => System.Array.IndexOf(Array, typeId, 0, Length);


        /// <summary>
        ///     Returns a new <see cref="FastImmutableArray{T}" /> with the element at the specified index removed.
        /// </summary>
        /// <typeparam name="T1">The type parameter (unused).</typeparam>
        /// <param name="index">The zero-based index of the element to remove.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="index" /> is less than zero or greater than or equal to <see cref="Length" />.</exception>
        /// <returns>A new <see cref="FastImmutableArray{T}" /> with the element removed.</returns>
        public FastImmutableArray<T> RemoveAt<T1>(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            T[] newArray = new T[Length - 1];
            System.Array.Copy(Array, 0, newArray, 0, index);
            System.Array.Copy(Array, index + 1, newArray, index, Length - index - 1);
            return new FastImmutableArray<T>(newArray);
        }

        /// <summary>
        ///     An empty (initialized) instance of <see cref="FastImmutableArray{T}" />.
        /// </summary>
        public static readonly FastImmutableArray<T> Empty = new FastImmutableArray<T>(new T[0]);

        /// <summary>
        ///     The backing field for this instance. References to this value should never be shared with outside code.
        /// </summary>
        /// <remarks>
        ///     This would be private, but we make it internal so that our own extension methods can access it.
        /// </remarks>
        internal readonly T[] Array;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FastImmutableArray{T}" /> struct
        ///     *without making a defensive copy*.
        /// </summary>
        /// <param name="items">The array to use. May be null for "default" arrays.</param>
        public FastImmutableArray(T[] items) => Array = items;


        /// <summary>
        ///     Checks equality between two instances by comparing underlying array references.
        /// </summary>
        /// <param name="left">The instance to the left of the operator.</param>
        /// <param name="right">The instance to the right of the operator.</param>
        /// <returns><c>true</c> if the underlying arrays are reference equal; <c>false</c> otherwise.</returns>
        public static bool operator ==(FastImmutableArray<T> left, FastImmutableArray<T> right) => left.Equals(right);

        /// <summary>
        ///     Checks inequality between two instances by comparing underlying array references.
        /// </summary>
        /// <param name="left">The instance to the left of the operator.</param>
        /// <param name="right">The instance to the right of the operator.</param>
        /// <returns><c>true</c> if the underlying arrays are not reference equal; <c>false</c> otherwise.</returns>
        public static bool operator !=(FastImmutableArray<T> left, FastImmutableArray<T> right) => !left.Equals(right);

        /// <summary>
        ///     Checks equality between two nullable instances.
        /// </summary>
        /// <param name="left">The nullable instance to the left of the operator.</param>
        /// <param name="right">The nullable instance to the right of the operator.</param>
        /// <returns><c>true</c> if the underlying arrays are reference equal; <c>false</c> otherwise.</returns>
        public static bool operator ==(FastImmutableArray<T>? left, FastImmutableArray<T>? right) => left.GetValueOrDefault().Equals(right.GetValueOrDefault());

        /// <summary>
        ///     Checks inequality between two nullable instances.
        /// </summary>
        /// <param name="left">The nullable instance to the left of the operator.</param>
        /// <param name="right">The nullable instance to the right of the operator.</param>
        /// <returns><c>true</c> if the underlying arrays are not reference equal; <c>false</c> otherwise.</returns>
        public static bool operator !=(FastImmutableArray<T>? left, FastImmutableArray<T>? right) => !left.GetValueOrDefault().Equals(right.GetValueOrDefault());


        /// <summary>
        ///     Gets the element at the specified index in the read-only list.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get.</param>
        /// <returns>The element at the specified index.</returns>
        public T this[int index] =>
            // We intentionally do not check this.array != null, and throw NullReferenceException
            // if this is called while uninitialized.
            // The reason for this is perf.
            // Length and the indexer must be absolutely trivially implemented for the JIT optimization
            // of removing array bounds checking to work.
            Array![index];

        /// <summary>
        ///     Gets a read-only reference to the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get a reference to.</param>
        /// <returns>A read-only reference to the element at the specified index.</returns>
        public ref readonly T ItemRef(int index) =>
            // We intentionally do not check this.array != null, and throw NullReferenceException
            // if this is called while uninitialized.
            // The reason for this is perf.
            // Length and the indexer must be absolutely trivially implemented for the JIT optimization
            // of removing array bounds checking to work.
            ref Array![index];

        /// <summary>
        ///     Gets a value indicating whether this collection is empty.
        /// </summary>
        /// <value><c>true</c> if the underlying array length is zero; otherwise, <c>false</c>.</value>
        public bool IsEmpty => Array!.Length == 0;

        /// <summary>
        ///     Gets the number of elements in the array.
        /// </summary>
        /// <value>The total number of elements in the underlying array.</value>
        public int Length =>
            // We intentionally do not check this.array != null, and throw NullReferenceException
            // if this is called while uninitialized.
            // The reason for this is perf.
            // Length and the indexer must be absolutely trivially implemented for the JIT optimization
            // of removing array bounds checking to work.
            Array!.Length;

        /// <summary>
        ///     Gets a value indicating whether this struct was initialized without an actual array instance.
        /// </summary>
        /// <value><c>true</c> if the underlying array is null; otherwise, <c>false</c>.</value>
        public bool IsDefault => Array == null;

        /// <summary>
        ///     Gets a value indicating whether this struct is empty or uninitialized.
        /// </summary>
        public bool IsDefaultOrEmpty
        {
            get
            {
                FastImmutableArray<T> self = this;
                return self.Array == null || self.Array.Length == 0;
            }
        }

        /// <summary>
        ///     Gets an untyped reference to the underlying array.
        /// </summary>
        Array IFastImmutableArray.Array => Array;

        /// <summary>
        ///     Copies the contents of this array to the specified destination array.
        /// </summary>
        /// <param name="destination">The array to copy to.</param>
        public void CopyTo(T[] destination)
        {
            FastImmutableArray<T> self = this;
            self.ThrowNullRefIfNotInitialized();
            System.Array.Copy(self.Array!, destination, self.Length);
        }

        /// <summary>
        ///     Copies the contents of this array to the specified destination array starting at a given index.
        /// </summary>
        /// <param name="destination">The array to copy to.</param>
        /// <param name="destinationIndex">The index in the destination array where copying begins.</param>
        public void CopyTo(T[] destination, int destinationIndex)
        {
            FastImmutableArray<T> self = this;
            self.ThrowNullRefIfNotInitialized();
            System.Array.Copy(self.Array!, 0, destination, destinationIndex, self.Length);
        }

        /// <summary>
        ///     Copies a range of elements from this array to the specified destination array.
        /// </summary>
        /// <param name="sourceIndex">The index in this array where copying begins.</param>
        /// <param name="destination">The destination array.</param>
        /// <param name="destinationIndex">The index in the destination array where the first copied element is written.</param>
        /// <param name="length">The number of elements to copy.</param>
        public void CopyTo(int sourceIndex, T[] destination, int destinationIndex, int length)
        {
            FastImmutableArray<T> self = this;
            self.ThrowNullRefIfNotInitialized();
            System.Array.Copy(self.Array!, sourceIndex, destination, destinationIndex, length);
        }

        /// <summary>
        ///     Returns an enumerator for the contents of the array.
        /// </summary>
        /// <returns>An enumerator.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Enumerator GetEnumerator()
        {
            FastImmutableArray<T> self = this;
            self.ThrowNullRefIfNotInitialized();
            return new Enumerator(self.Array!);
        }

        /// <summary>
        ///     Returns a hash code for this instance based on the underlying array reference.
        /// </summary>
        /// <returns>A hash code for this instance.</returns>
        public override int GetHashCode()
        {
            FastImmutableArray<T> self = this;
            return self.Array == null ? 0 : self.Array.GetHashCode();
        }

        /// <summary>
        ///     Determines whether the specified <see cref="object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns><c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj) => obj is IFastImmutableArray other && (Array == other.Array);

        /// <summary>
        ///     Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns><c>true</c> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <c>false</c>.</returns>
        public bool Equals(FastImmutableArray<T> other) => Array == other.Array;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FastImmutableArray{T}" /> struct based on the contents
        ///     of an existing instance, allowing a covariant static cast to efficiently reuse the existing array.
        /// </summary>
        /// <param name="items">The array to initialize with. No copy is made.</param>
        /// <typeparam name="TDerived">The source element type that derives from <typeparamref name="T" />.</typeparam>
        /// <returns>A new <see cref="FastImmutableArray{T}" /> wrapping the same array.</returns>
        /// <remarks>
        ///     Covariant upcasts from this method may be reversed by calling the
        ///     <see cref="FastImmutableArray{T}.As{TOther}" /> or <see cref="FastImmutableArray{T}.CastArray{TOther}" /> method.
        /// </remarks>
        public static FastImmutableArray<T> CastUp<TDerived>(FastImmutableArray<TDerived> items)
            where TDerived : class, T
            => new FastImmutableArray<T>(items.Array);

        /// <summary>
        ///     Initializes a new instance of the <see cref="FastImmutableArray{T}" /> struct by casting the underlying
        ///     array to an array of type <typeparamref name="TOther" />.
        /// </summary>
        /// <typeparam name="TOther">The target element type for the cast.</typeparam>
        /// <returns>A new <see cref="FastImmutableArray{TOther}" /> wrapping the cast array.</returns>
        /// <exception cref="InvalidCastException">Thrown if the cast is illegal.</exception>
        public FastImmutableArray<TOther> CastArray<TOther>() where TOther : class => new FastImmutableArray<TOther>((TOther[]) (object) Array!);

        /// <summary>
        ///     Creates an immutable array for this array, cast to a different element type.
        /// </summary>
        /// <typeparam name="TOther">The type of array element to return.</typeparam>
        /// <returns>
        ///     A struct typed for the base element type. If the cast fails, an instance
        ///     is returned whose <see cref="IsDefault" /> property returns <c>true</c>.
        /// </returns>
        /// <remarks>
        ///     Arrays of derived elements types can be cast to arrays of base element types
        ///     without reallocating the array.
        ///     These upcasts can be reversed via this same method, casting an array of base
        ///     element types to their derived types. However, down casting is only successful
        ///     when it reverses a prior upcasting operation.
        /// </remarks>
        public FastImmutableArray<TOther> As<TOther>() where TOther : class => new FastImmutableArray<TOther>(Array as TOther[]);

        /// <summary>
        ///     Returns an enumerator for the contents of the array.
        /// </summary>
        /// <returns>An enumerator.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the <see cref="IsDefault" /> property returns true.</exception>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            FastImmutableArray<T> self = this;
            self.ThrowInvalidOperationIfNotInitialized();
            return EnumeratorObject.Create(self.Array!);
        }

        /// <summary>
        ///     Returns an enumerator for the contents of the array.
        /// </summary>
        /// <returns>An enumerator.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the <see cref="IsDefault" /> property returns true.</exception>
        IEnumerator IEnumerable.GetEnumerator()
        {
            FastImmutableArray<T> self = this;
            self.ThrowInvalidOperationIfNotInitialized();
            return EnumeratorObject.Create(self.Array!);
        }

        /// <summary>
        ///     Throws a null reference exception if the array field is null.
        /// </summary>
        internal void ThrowNullRefIfNotInitialized()
        {
            // Force NullReferenceException if array is null by touching its Length.
            // This way of checking has a nice property of requiring very little code
            // and not having any conditions/branches.
            // In a faulting scenario we are relying on hardware to generate the fault.
            // And in the non-faulting scenario (most common) the check is virtually free since
            // if we are going to do anything with the array, we will need Length anyway
            // so touching it, and potentially causing a cache miss, is not going to be an
            // extra expense.
            _ = Array!.Length;
        }

        /// <summary>
        ///     Throws an <see cref="InvalidOperationException" /> if the <see cref="Array" /> field is null, i.e. the
        ///     <see cref="IsDefault" /> property returns true.
        /// </summary>
        /// <remarks>
        ///     The <see cref="InvalidOperationException" /> message specifies that the operation cannot be performed
        ///     on a default instance of <see cref="FastImmutableArray{T}" />.
        ///     This is intended for explicitly implemented interface method and property implementations.
        /// </remarks>
        private void ThrowInvalidOperationIfNotInitialized()
        {
            if (IsDefault)
            {
                throw new InvalidOperationException("Operation cannot be performed on a default instance of FastImmutableArray<T>.");
            }
        }

        /// <summary>
        ///     An array enumerator struct that does NOT implement <see cref="IDisposable" /> for performance.
        /// </summary>
        /// <remarks>
        ///     It is important that this enumerator does NOT implement <see cref="IDisposable" />.
        ///     We want the iterator to inline when we do foreach and to not result in
        ///     a try/finally frame in the client.
        /// </remarks>
        public struct Enumerator
        {
            /// <summary>
            ///     The array being enumerated.
            /// </summary>
            private readonly T[] _array;

            /// <summary>
            ///     The currently enumerated position.
            /// </summary>
            /// <value>
            ///     -1 before the first call to <see cref="MoveNext" />.
            ///     >= this.array.Length after <see cref="MoveNext" /> returns false.
            /// </value>
            private int _index;

            /// <summary>
            ///     Initializes a new instance of the <see cref="Enumerator" /> struct.
            /// </summary>
            /// <param name="array">The array to enumerate.</param>
            internal Enumerator(T[] array)
            {
                _array = array;
                _index = -1;
            }

            /// <summary>
            ///     Gets the currently enumerated value.
            /// </summary>
            /// <remarks>No range check is performed here; <see cref="MoveNext" /> must be called first.</remarks>
            public T Current =>
                _array[_index];

            /// <summary>
            ///     Advances to the next value to be enumerated.
            /// </summary>
            /// <returns><c>true</c> if another item exists in the array; <c>false</c> otherwise.</returns>
            public bool MoveNext() => ++_index < _array.Length;
        }

        /// <summary>
        ///     An array enumerator that implements the <see cref="IEnumerator{T}" /> pattern (including <see cref="IDisposable" />).
        /// </summary>
        [ExcludeFromCodeCoverage]
        private sealed class EnumeratorObject : IEnumerator<T>
        {
            /// <summary>
            ///     A shareable singleton for enumerating empty arrays.
            /// </summary>
            private static readonly IEnumerator<T> SEmptyEnumerator =
                new EnumeratorObject(Empty.Array!);

            /// <summary>
            ///     The array being enumerated.
            /// </summary>
            private readonly T[] _array;

            /// <summary>
            ///     The currently enumerated position.
            /// </summary>
            /// <value>
            ///     -1 before the first call to <see cref="MoveNext" />.
            ///     this.array.Length - 1 after MoveNext returns false.
            /// </value>
            private int _index;

            /// <summary>
            ///     Initializes a new instance of the <see cref="Enumerator" /> class.
            /// </summary>
            private EnumeratorObject(T[] array)
            {
                _index = -1;
                _array = array;
            }

            /// <summary>
            ///     Gets the currently enumerated value.
            /// </summary>
            public T Current
            {
                get
                {
                    // this.index >= 0 && this.index < this.array.Length
                    // unsigned compare performs the range check above in one compare
                    if (unchecked((uint) _index) < (uint) _array.Length)
                    {
                        return _array[_index];
                    }

                    // Before first or after last MoveNext.
                    throw new InvalidOperationException();
                }
            }

            /// <summary>
            ///     Gets the currently enumerated value (boxed).
            /// </summary>
            object IEnumerator.Current => Current;

            /// <summary>
            ///     Advances to the next element in the array.
            /// </summary>
            /// <returns><c>true</c> if another element exists; <c>false</c> otherwise.</returns>
            public bool MoveNext()
            {
                int newIndex = _index + 1;
                int length = _array.Length;

                // unsigned math is used to prevent false positive if index + 1 overflows.
                if ((uint) newIndex <= (uint) length)
                {
                    _index = newIndex;
                    return (uint) newIndex < (uint) length;
                }

                return false;
            }

            /// <summary>
            ///     Resets the enumerator to the beginning of the array.
            /// </summary>
            void IEnumerator.Reset()
            {
                _index = -1;
            }

            /// <summary>
            ///     Disposes this enumerator. Currently has no action.
            /// </summary>
            public void Dispose()
            {
                // we do not have any native or disposable resources.
                // nothing to do here.
            }

            /// <summary>
            ///     Creates an enumerator for the specified array, returning a singleton for empty arrays.
            /// </summary>
            /// <param name="array">The array to enumerate.</param>
            /// <returns>An <see cref="IEnumerator{T}" /> for the array.</returns>
            internal static IEnumerator<T> Create(T[] array)
            {
                if (array.Length != 0)
                {
                    return new EnumeratorObject(array);
                }

                return SEmptyEnumerator;
            }
        }
    }
}
