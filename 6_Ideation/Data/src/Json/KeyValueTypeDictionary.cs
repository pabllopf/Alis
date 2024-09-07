// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:KeyValueTypeDictionary.cs
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

namespace Alis.Core.Aspect.Data.Json
{
    /// <summary>
    ///     The key value type dictionary class
    /// </summary>
    /// <seealso cref="IDictionary" />
    internal sealed class KeyValueTypeDictionary : IDictionary
    {
        /// <summary>
        ///     The enumerator
        /// </summary>
        private readonly KeyValueTypeEnumerator _enumerator;

        /// <summary>
        ///     Initializes a new instance of the <see cref="KeyValueTypeDictionary" /> class
        /// </summary>
        /// <param name="value">The value</param>
        public KeyValueTypeDictionary(object value) => _enumerator = new KeyValueTypeEnumerator(value);

        /// <summary>
        ///     Gets the value of the count
        /// </summary>
        public int Count => throw new NotSupportedException();

        /// <summary>
        ///     Gets the value of the is synchronized
        /// </summary>
        public bool IsSynchronized => throw new NotSupportedException();

        /// <summary>
        ///     Gets the value of the sync root
        /// </summary>
        public object SyncRoot => throw new NotSupportedException();

        /// <summary>
        ///     Gets the value of the is fixed size
        /// </summary>
        public bool IsFixedSize => throw new NotSupportedException();

        /// <summary>
        ///     Gets the value of the is read only
        /// </summary>
        public bool IsReadOnly => throw new NotSupportedException();

        /// <summary>
        ///     Gets the value of the keys
        /// </summary>
        public ICollection Keys => throw new NotSupportedException();

        /// <summary>
        ///     Gets the value of the values
        /// </summary>
        public ICollection Values => throw new NotSupportedException();

        /// <summary>
        ///     The not supported exception
        /// </summary>
        public object this[object key]
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }

        /// <summary>
        ///     Adds the key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="value">The value</param>
        public void Add(object key, object value) => throw new NotSupportedException();

        /// <summary>
        ///     Clears this instance
        /// </summary>
        public void Clear() => throw new NotSupportedException();

        /// <summary>
        ///     Describes whether this instance contains
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The bool</returns>
        public bool Contains(object key) => throw new NotSupportedException();

        /// <summary>
        ///     Gets the enumerator
        /// </summary>
        /// <returns>The dictionary enumerator</returns>
        public IDictionaryEnumerator GetEnumerator() => _enumerator;

        /// <summary>
        ///     Removes the key
        /// </summary>
        /// <param name="key">The key</param>
        public void Remove(object key) => throw new NotSupportedException();

        /// <summary>
        ///     Copies the to using the specified array
        /// </summary>
        /// <param name="array">The array</param>
        /// <param name="index">The index</param>
        public void CopyTo(Array array, int index) => throw new NotSupportedException();

        /// <summary>
        ///     Gets the enumerator
        /// </summary>
        /// <returns>The enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
    }
}