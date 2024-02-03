// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PropertyDescriptorAccessor.cs
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

using System.ComponentModel;

namespace Alis.Core.Aspect.Data.Json
{
    /// <summary>
    ///     The property descriptor accessor class
    /// </summary>
    /// <seealso cref="IMemberAccessor" />
    internal sealed class PropertyDescriptorAccessor : IMemberAccessor
    {
        /// <summary>
        ///     The pd
        /// </summary>
        private readonly PropertyDescriptor _pd;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyDescriptorAccessor" /> class
        /// </summary>
        /// <param name="pd">The pd</param>
        public PropertyDescriptorAccessor(PropertyDescriptor pd) => _pd = pd;

        /// <summary>
        ///     Gets the component
        /// </summary>
        /// <param name="component">The component</param>
        /// <returns>The object</returns>
        public object Get(object component) => _pd.GetValue(component);

        /// <summary>
        ///     Sets the component
        /// </summary>
        /// <param name="component">The component</param>
        /// <param name="value">The value</param>
        public void Set(object component, object value)
        {
            if (_pd.IsReadOnly)
                return;

            _pd.SetValue(component, value);
        }
    }
}