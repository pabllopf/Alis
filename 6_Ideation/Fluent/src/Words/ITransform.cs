// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ITransform.cs
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
    ///     Fluent builder interface that configures the local or world transform
    ///     (position, rotation, and scale) of a game entity.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The transform configuration type — typically a <see cref="Transform"/> struct or descriptor.</typeparam>
    /// <remarks>
    ///     This applies a complete transform. For individual properties,
    ///     use <see cref="IPosition2D"/>, <see cref="IRotation"/>, or <see cref="IScale2D"/>.
    /// </remarks>
    public interface ITransform<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Configures the transform on the builder.
        /// </summary>
        /// <param name="value">The transform descriptor containing position, rotation, and/or scale.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Transform(TArgument value);
    }
}