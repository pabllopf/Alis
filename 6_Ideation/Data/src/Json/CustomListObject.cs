// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CustomListObject.cs
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

namespace Alis.Core.Aspect.Data.Json
{
    /// <summary>
    ///     The list object class
    /// </summary>
    /// <seealso cref="ListObject" />
    internal sealed class CustomListObject : ListObject
    {
        /// <summary>
        ///     The list
        /// </summary>
        private IList _list = new ArrayList();
        
        /// <summary>
        ///     Gets or sets the value of the list
        /// </summary>
        public override object List
        {
            get => base.List;
            set
            {
                base.List = value;
                _list = (IList) value;
            }
        }
        
        /// <summary>
        ///     Clears this instance
        /// </summary>
        public override void Clear() => _list.Clear();
        
        /// <summary>
        ///     Adds the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="options">The options</param>
        public override void Add(object value, JsonOptions options = null) => _list.Add(value);
    }
}