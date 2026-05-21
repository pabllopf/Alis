// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IWorld.cs
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
    ///     Fluent builder interface that associates the builder with a specific
    ///     game world or scene context.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The world or scene reference type — typically a <see cref="Scene"/> or world identifier.</typeparam>
    /// <remarks>
    ///     Specifies which <see cref="Scene"/> or game world the entity belongs to.
    ///     Required when building entities that must be associated with a particular world
    ///     in multi-scene or multi-world setups.
    /// </remarks>
    public interface IWorld<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Assigns the target world or scene context to the builder.
        /// </summary>
        /// <param name="value">The world or scene reference to associate with this builder.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder World(TArgument value);
    }
}