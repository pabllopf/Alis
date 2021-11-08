// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   CurveKeyCollection.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

// ReSharper disable once CheckNamespace
namespace Alis.Core.Systems.Physics2D.Extensions.Controllers.Wind.Curve
{
    /// <summary>The collection of the <see cref="CurveKey" /> elements and a part of the <see cref="Curve" /> class.</summary>

    // TODO : [TypeConverter(typeof(ExpandableObjectConverter))]
    [DataContract]
    public class CurveKeyCollection : ICollection<CurveKey>
    {
        /// <summary>
        ///     The keys
        /// </summary>
        private readonly List<CurveKey> _keys;

        /// <summary>Creates a new instance of <see cref="CurveKeyCollection" /> class.</summary>
        public CurveKeyCollection() => _keys = new List<CurveKey>();

        /// <summary>Indexer.</summary>
        /// <param name="index">The index of key in this collection.</param>
        /// <returns><see cref="CurveKey" /> at <paramref name="index" /> position.</returns>
        [DataMember(Name = "Items")]
        public CurveKey this[int index]
        {
            get => _keys[index];
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                if (index >= _keys.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                if (_keys[index].Position == value.Position)
                {
                    _keys[index] = value;
                }
                else
                {
                    _keys.RemoveAt(index);
                    _keys.Add(value);
                }
            }
        }

        /// <summary>
        ///     Gets the enumerator
        /// </summary>
        /// <returns>The enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator() => _keys.GetEnumerator();

        /// <summary>Adds a key to this collection.</summary>
        /// <param name="item">New key for the collection.</param>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="item" /> is null.</exception>
        /// <remarks>The new key would be added respectively to a position of that key and the position of other keys.</remarks>
        public void Add(CurveKey item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (_keys.Count == 0)
            {
                _keys.Add(item);
                return;
            }

            for (int i = 0; i < _keys.Count; i++)
            {
                if (item.Position < _keys[i].Position)
                {
                    _keys.Insert(i, item);
                    return;
                }
            }

            _keys.Add(item);
        }

        /// <summary>Removes all keys from this collection.</summary>
        public void Clear()
        {
            _keys.Clear();
        }

        /// <summary>Determines whether this collection contains a specific key.</summary>
        /// <param name="item">The key to locate in this collection.</param>
        /// <returns><c>true</c> if the key is found; <c>false</c> otherwise.</returns>
        public bool Contains(CurveKey item) => _keys.Contains(item);

        /// <summary>Copies the keys of this collection to an array, starting at the array index provided.</summary>
        /// <param name="array">Destination array where elements will be copied.</param>
        /// <param name="arrayIndex">The zero-based index in the array to start copying from.</param>
        public void CopyTo(CurveKey[] array, int arrayIndex)
        {
            _keys.CopyTo(array, arrayIndex);
        }

        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>An enumerator for the <see cref="CurveKeyCollection" />.</returns>
        public IEnumerator<CurveKey> GetEnumerator() => _keys.GetEnumerator();

        /// <summary>Removes specific element.</summary>
        /// <param name="item">The element</param>
        /// <returns>
        ///     <c>true</c> if item is successfully removed; <c>false</c> otherwise. This method also returns <c>false</c> if
        ///     item was not found.
        /// </returns>
        public bool Remove(CurveKey item) => _keys.Remove(item);

        /// <summary>Returns the count of keys in this collection.</summary>
        [DataMember]
        public int Count => _keys.Count;

        /// <summary>Returns false because it is not a read-only collection.</summary>
        [DataMember]
        public bool IsReadOnly => false;

        /// <summary>Creates a copy of this collection.</summary>
        /// <returns>A copy of this collection.</returns>
        public CurveKeyCollection Clone()
        {
            CurveKeyCollection ckc = new CurveKeyCollection();
            foreach (CurveKey key in _keys)
            {
                ckc.Add(key);
            }

            return ckc;
        }

        /// <summary>Finds element in the collection and returns its index.</summary>
        /// <param name="item">Element for the search.</param>
        /// <returns>Index of the element; or -1 if item is not found.</returns>
        public int IndexOf(CurveKey item) => _keys.IndexOf(item);

        /// <summary>Removes element at the specified index.</summary>
        /// <param name="index">The index which element will be removed.</param>
        public void RemoveAt(int index)
        {
            _keys.RemoveAt(index);
        }
    }
}