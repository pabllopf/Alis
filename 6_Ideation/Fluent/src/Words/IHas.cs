// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IHas.cs
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
    ///     Fluent builder interface that specifies ownership or a has-a relationship
    ///     between a game entity and a child object or component.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The type of the owned child object or component.</typeparam>
    /// <remarks>
    ///     Establishes a parent-child relationship. For example, an entity may "have"
    ///     a weapon, a UI element may "have" a child panel, or a scene may "have" a subsystem.
    /// </remarks>
    public interface IHas<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Assigns a child object or component to the builder's target entity.
        /// </summary>
        /// <param name="obj">The child object or component to assign ownership of.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Has(TArgument obj);
    }
}