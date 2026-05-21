// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IName.cs
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
    ///     Fluent builder interface that assigns a human-readable name
    ///     to a game entity, component, or configuration object.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The name type, typically <see cref="string"/>.</typeparam>
    /// <remarks>
    ///     Entity names are used for debugging, scene hierarchy display, and runtime lookups.
    ///     Names are not required to be unique but are highly recommended for editor workflows.
    /// </remarks>
    public interface IName<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Assigns a name to the builder's target entity or configuration.
        /// </summary>
        /// <param name="value">The name string to assign.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Name(TArgument value);
    }
}