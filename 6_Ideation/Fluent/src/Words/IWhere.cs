// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IWhere.cs
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

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that applies a spatial or logical filter
    ///     to constrain which entities are affected by subsequent operations.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The filter criteria — a predicate, region, tag, or query descriptor.</typeparam>
    /// <remarks>
    ///     Used to narrow down entity sets before applying actions. The filter semantics
    ///     depend on context: spatial bounds, component presence, tag matching, or
    ///     custom predicates.
    /// </remarks>
    public interface IWhere<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Applies a filter condition on the builder.
        /// </summary>
        /// <param name="value">The filter criteria — predicate, region, tag, or query descriptor.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Where(TArgument value);
    }
}