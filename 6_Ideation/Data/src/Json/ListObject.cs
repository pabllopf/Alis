// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ListObject.cs
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
    ///     Defines an object that handles list deserialization.
    /// </summary>
    public abstract class ListObject
    {
        /// <summary>
        ///     Gets or sets the list object.
        /// </summary>
        /// <value>
        ///     The list.
        /// </value>
        public virtual object List { get; set; }

        /// <summary>
        ///     Gets the current context.
        /// </summary>
        /// <value>
        ///     The context. May be null.
        /// </value>
        public virtual IDictionary<string, object> Context => null;

        /// <summary>
        ///     Clears the list object.
        /// </summary>
        public abstract void Clear();

        /// <summary>
        ///     Adds a value to the list object.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="options">The options.</param>
        public abstract void Add(object value, JsonOptions options = null);
    }
}