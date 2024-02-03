// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:KeyValueTypeEnumerator.cs
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

using System.Collections;
using System.Reflection;

namespace Alis.Core.Aspect.Data.Json
{
    /// <summary>
    ///     The key value type enumerator class
    /// </summary>
    /// <seealso cref="IDictionaryEnumerator" />
    internal sealed class KeyValueTypeEnumerator : IDictionaryEnumerator
    {
        /// <summary>
        ///     The enumerator
        /// </summary>
        private readonly IEnumerator _enumerator;

        /// <summary>
        ///     The key prop
        /// </summary>
        private PropertyInfo _keyProp;

        /// <summary>
        ///     The value prop
        /// </summary>
        private PropertyInfo _valueProp;

        /// <summary>
        ///     Initializes a new instance of the <see cref="KeyValueTypeEnumerator" /> class
        /// </summary>
        /// <param name="value">The value</param>
        public KeyValueTypeEnumerator(object value) => _enumerator = ((IEnumerable) value).GetEnumerator();

        /// <summary>
        ///     Gets the value of the entry
        /// </summary>
        public DictionaryEntry Entry
        {
            get
            {
                if (_keyProp == null)
                {
                    _keyProp = _enumerator.Current.GetType().GetProperty("Key");
                    _valueProp = _enumerator.Current.GetType().GetProperty("Value");
                }

                return new DictionaryEntry(_keyProp.GetValue(_enumerator.Current, null), _valueProp.GetValue(_enumerator.Current, null));
            }
        }

        /// <summary>
        ///     Gets the value of the key
        /// </summary>
        public object Key => Entry.Key;

        /// <summary>
        ///     Gets the value of the value
        /// </summary>
        public object Value => Entry.Value;

        /// <summary>
        ///     Gets the value of the current
        /// </summary>
        public object Current => Entry;

        /// <summary>
        ///     Describes whether this instance move next
        /// </summary>
        /// <returns>The bool</returns>
        public bool MoveNext() => _enumerator.MoveNext();

        /// <summary>
        ///     Resets this instance
        /// </summary>
        public void Reset() => _enumerator.Reset();
    }
}