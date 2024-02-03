// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ICollectionTObject.cs
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

using System.Collections.Generic;

namespace Alis.Core.Aspect.Data.Json
{
    /// <summary>
    ///     The collection object class
    /// </summary>
    internal sealed class CollectionTObject<T> : ListObject
    {
        /// <summary>
        ///     The coll
        /// </summary>
        private ICollection<T> _coll;

        /// <summary>
        ///     Gets or sets the value of the list
        /// </summary>
        public override object List
        {
            get => base.List;
            set
            {
                base.List = value;
                _coll = (ICollection<T>) value;
            }
        }

        /// <summary>
        ///     Clears this instance
        /// </summary>
        public override void Clear() => _coll.Clear();

        /// <summary>
        ///     Adds the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="options">The options</param>
        public override void Add(object value, JsonOptions options = null)
        {
            if ((value == null) && typeof(T).IsValueType)
            {
                JsonSerializer.HandleException(new JsonException("JSO0014: JSON error detected. Cannot add null to a collection of '" + typeof(T) + "' elements."), options);
            }

            _coll.Add((T) value);
        }
    }
}