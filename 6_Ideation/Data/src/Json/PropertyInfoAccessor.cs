// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PropertyInfoAccessor.cs
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
using System.Reflection;

namespace Alis.Core.Aspect.Data.Json
{
    /// <summary>
    ///     The property info accessor class
    /// </summary>
    /// <seealso cref="IMemberAccessor" />
    internal sealed class PropertyInfoAccessor<TComponent, TMember> : IMemberAccessor
    {
        /// <summary>
        ///     The get
        /// </summary>
        private readonly JFunc<TComponent, TMember> _get;

        /// <summary>
        ///     The set
        /// </summary>
        private readonly JAction<TComponent, TMember> _set;
        
        /// <summary>
        /// Initializes a new instance 
        /// </summary>
        /// <param name="pi">The pi</param>
        public PropertyInfoAccessor(PropertyInfo pi)
        {
            MethodInfo get = pi.GetGetMethod();
            if (get != null)
            {
                _get = (JFunc<TComponent, TMember>) Delegate.CreateDelegate(typeof(JFunc<TComponent, TMember>), get);
            }

            MethodInfo set = pi.GetSetMethod();
            if (set != null)
            {
                _set = (JAction<TComponent, TMember>) Delegate.CreateDelegate(typeof(JAction<TComponent, TMember>), set);
            }
        }

        /// <summary>
        ///     Gets the component
        /// </summary>
        /// <param name="component">The component</param>
        /// <returns>The object</returns>
        public object Get(object component)
        {
            return _get((TComponent) component);
        }

        /// <summary>
        ///     Sets the component
        /// </summary>
        /// <param name="component">The component</param>
        /// <param name="value">The value</param>
        public void Set(object component, object value)
        {
            _set((TComponent) component, (TMember) value);
        }
    }
}