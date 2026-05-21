// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IAdd.cs
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
    ///     Fluent builder interface that appends or adds an element to a collection
    ///     or composite property on the target builder.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The argument type being added to the builder's target collection or property.</typeparam>
    /// <remarks>
    ///     Commonly used to add components, children, or configuration entries to a game entity or system.
    ///     The exact semantics depend on the builder implementation.
    /// </remarks>
    public interface IAdd<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Adds the specified value to the builder's target collection or property.
        /// </summary>
        /// <param name="value">The value to append or add. Must not be null unless the argument type is nullable.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Add(TArgument value);
    }
}