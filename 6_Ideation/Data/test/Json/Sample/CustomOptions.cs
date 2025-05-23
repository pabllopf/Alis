// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CustomOptions.cs
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
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Sample
{
    /// <summary>
    ///     The custom options class
    /// </summary>
    /// <seealso cref="JsonOptions" />
    internal class CustomOptions : JsonOptions
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CustomOptions" /> class
        /// </summary>
        public CustomOptions() => ObjectGraph = new CustomObjectGraph();

        /// <summary>
        ///     The custom object graph class
        /// </summary>
        /// <seealso cref="IDictionary{TKey,TValue}" />
        /// <seealso cref="IOptionsHolder" />
        private class CustomObjectGraph : IDictionary<object, object>, IOptionsHolder
        {
            /// <summary>
            ///     The dictionary
            /// </summary>
            private readonly Dictionary<object, int> _hash = new Dictionary<object, int>();

            /// <summary>
            ///     Adds the key
            /// </summary>
            /// <param name="key">The key</param>
            /// <param name="value">The value</param>
            public void Add(object key, object value)
            {
                _hash[key] = Options.SerializationLevel;
            }

            /// <summary>
            ///     Describes whether this instance contains key
            /// </summary>
            /// <param name="key">The key</param>
            /// <returns>The bool</returns>
            public bool ContainsKey(object key)
            {
                if (!_hash.TryGetValue(key, out int level))
                {
                    return false;
                }

                if (Options.SerializationLevel == level)
                {
                    return false;
                }

                return true;
            }

            /// <summary>
            ///     The not implemented exception
            /// </summary>
            public object this[object key]
            {
                get => throw new NotImplementedException();
                set => throw new NotImplementedException();
            }

            /// <summary>
            ///     Gets the value of the keys
            /// </summary>
            public ICollection<object> Keys => throw new NotImplementedException();

            /// <summary>
            ///     Gets the value of the values
            /// </summary>
            public ICollection<object> Values => throw new NotImplementedException();

            /// <summary>
            ///     Gets the value of the count
            /// </summary>
            public int Count => throw new NotImplementedException();

            /// <summary>
            ///     Gets the value of the is read only
            /// </summary>
            public bool IsReadOnly => throw new NotImplementedException();

            /// <summary>
            ///     Adds the item
            /// </summary>
            /// <param name="item">The item</param>
            public void Add(KeyValuePair<object, object> item) => throw new NotImplementedException();

            /// <summary>
            ///     Clears this instance
            /// </summary>
            public void Clear() => throw new NotImplementedException();

            /// <summary>
            ///     Describes whether this instance contains
            /// </summary>
            /// <param name="item">The item</param>
            /// <returns>The bool</returns>
            public bool Contains(KeyValuePair<object, object> item) => throw new NotImplementedException();

            /// <summary>
            ///     Copies the to using the specified array
            /// </summary>
            /// <param name="array">The array</param>
            /// <param name="arrayIndex">The array index</param>
            public void CopyTo(KeyValuePair<object, object>[] array, int arrayIndex) => throw new NotImplementedException();

            /// <summary>
            ///     Gets the enumerator
            /// </summary>
            /// <returns>An enumerator of key value pair object and object</returns>
            public IEnumerator<KeyValuePair<object, object>> GetEnumerator() => throw new NotImplementedException();

            /// <summary>
            ///     Describes whether this instance remove
            /// </summary>
            /// <param name="key">The key</param>
            /// <returns>The bool</returns>
            public bool Remove(object key) => throw new NotImplementedException();

            /// <summary>
            ///     Describes whether this instance remove
            /// </summary>
            /// <param name="item">The item</param>
            /// <returns>The bool</returns>
            public bool Remove(KeyValuePair<object, object> item) => throw new NotImplementedException();

            /// <summary>
            ///     Describes whether this instance try get value
            /// </summary>
            /// <param name="key">The key</param>
            /// <param name="value">The value</param>
            /// <returns>The bool</returns>
            public bool TryGetValue(object key, out object value) => throw new NotImplementedException();

            /// <summary>
            ///     Gets the enumerator
            /// </summary>
            /// <returns>The enumerator</returns>
            IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();

            /// <summary>
            ///     Gets or sets the value of the options
            /// </summary>
            public JsonOptions Options { get; set; }
        }
    }
}