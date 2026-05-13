// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IGraphic.cs
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
    ///     Fluent builder interface that configures the visual rendering properties
    ///     of a game entity, including sprite, mesh, material, and shader settings.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The graphics configuration type — typically a sprite reference, mesh descriptor, or rendering settings object.</typeparam>
    /// <remarks>
    ///     Use this to assign visual representations to entities. The argument may reference
    ///     a sprite, a 3D mesh, a procedural shape, or a rendering material.
    ///     Related interfaces: <see cref="IScale2D"/>, <see cref="IColor"/>.
    /// </remarks>
    public interface IGraphic<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Configures visual rendering properties on the builder.
        /// </summary>
        /// <param name="value">The graphics configuration — a sprite, mesh reference, material, or rendering descriptor.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Graphic(TArgument value);
    }
}