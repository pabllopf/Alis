// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastList.cs
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

namespace Alis.Core.Aspect.Memory
{

    /// <summary>
    /// The fast list class
    /// </summary>
    /// <seealso cref="IList{T}"/>
    public class FastList<T> : IList<T>
    {
        /// <summary>
        /// The items
        /// </summary>
        private T[] items;

        /// <summary>
        /// The count
        /// </summary>
        private int count;

        /// <summary>
        /// Initializes a new instance of the class
        /// </summary>
        /// <param name="i"></param>
        public FastList(int i)
        {
            items = new T[i];
            count = 0;
        }
        
        /// <summary>
        /// Initializes a new instance of the class
        /// </summary>
        public FastList()
        {
            items = new T[4];
            count = 0;
        }

        /// <summary>
        /// Gets the value of the count
        /// </summary>
        public int Count => count;

        /// <summary>
        /// Gets the value of the is read only
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// The value
        /// </summary>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                    throw new ArgumentOutOfRangeException(nameof(index));
                return items[index];
            }
            set
            {
                if (index < 0 || index >= count)
                    throw new ArgumentOutOfRangeException(nameof(index));
                items[index] = value;
            }
        }

        /// <summary>
        /// Adds the item
        /// </summary>
        /// <param name="item">The item</param>
        public void Add(T item)
        {
            if (count == items.Length)
            {
                int newCapacity = items.Length == 0 ? 4 : items.Length * 2;
                T[] newItems = new T[newCapacity];
                Array.Copy(items, 0, newItems, 0, count);
                items = newItems;
            }
            items[count++] = item;
        }

        /// <summary>
        /// Clears this instance
        /// </summary>
        public void Clear()
        {
            Array.Clear(items, 0, count);
            count = 0;
        }

        /// <summary>
        /// Describes whether this instance contains
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>The bool</returns>
        public bool Contains(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(items[i], item))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Copies the to using the specified array
        /// </summary>
        /// <param name="array">The array</param>
        /// <param name="arrayIndex">The array index</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(items, 0, array, arrayIndex, count);
        }

        /// <summary>
        /// Gets the enumerator
        /// </summary>
        /// <returns>An enumerator of t</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return items[i];
            }
        }

        /// <summary>
        /// Indexes the of using the specified item
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>The int</returns>
        public int IndexOf(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(items[i], item))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Inserts the index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="item">The item</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Insert(int index, T item)
        {
            if (index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (count == items.Length)
            {
                unsafe
                {
                    int newCapacity = items.Length == 0 ? 4 : items.Length * 2;
                    T[] newItems = new T[newCapacity];

                    Unsafe.CopyBlock(
                        ref Unsafe.As<T, byte>(ref newItems[0]),
                        ref Unsafe.As<T, byte>(ref items[0]),
                        (uint)(index * Unsafe.SizeOf<T>())
                    );
                    
                    Unsafe.Write((void*) Unsafe.As<T, byte>(ref newItems[index]), item);
                    
                    
                    
                    Unsafe.CopyBlock(
                        ref Unsafe.As<T, byte>(ref newItems[index + 1]),
                        ref Unsafe.As<T, byte>(ref items[index]),
                        (uint)((count - index) * Unsafe.SizeOf<T>())
                    );

                    items = newItems;
                }
                count++;
                return;
            }
            
            
            ShiftRight(index, 1);
            items[index] = item;
            count++;
        }

        /// <summary>
        /// Shifts the right using the specified start
        /// </summary>
        /// <param name="start">The start</param>
        /// <param name="shift">The shift</param>
        private void ShiftRight(int start, int shift)
        {
            int end = count - 1;
            for (int i = end; i >= start; i--)
            {
                items[i + shift] = items[i];
            }
        }
        
        
        /// <summary>
        /// Describes whether this instance remove
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>The bool</returns>
        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index < 0)
            {
                return false;
            }

            RemoveAt(index);
            return true;
        }

        /// <summary>
        /// Removes the at using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException(nameof(index));
            Array.Copy(items, index + 1, items, index, count - index - 1);
            count--;
            items[count] = default(T);
        }
        
        /// <summary>
        /// Gets the items
        /// </summary>
        /// <returns>The items</returns>
        public ref T[] GetRefNativeArray()
        {
            return ref items;
        }

        /// <summary>
        /// Gets the enumerator
        /// </summary>
        /// <returns>The enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// For the each using the specified action
        /// </summary>
        /// <param name="action">The action</param>
        public void ForEach(Action<T> action)
        {
            ref T start = ref Unsafe.As<byte, T>(ref Unsafe.As<RawArrayData>(items).Data);
            ref T end = ref Unsafe.Add(ref start, items.Length);
            while (Unsafe.IsAddressLessThan(ref start, ref end))
            {
                if (start is not null)
                {
                    action(start); 
                }
                
                start = ref Unsafe.Add(ref start, 1);
            }
        }
    }
}