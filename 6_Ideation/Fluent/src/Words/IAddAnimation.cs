// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IAddAnimation.cs
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
    ///     Fluent builder interface that attaches an animation clip or animation name
    ///     to a game entity for playback during the rendering loop.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The animation identifier, clip reference, or configuration object.</typeparam>
    /// <remarks>
    ///     Use this interface to assign sprite-sheet animations, skeletal animations,
    ///     or procedural animations to an entity. The argument type typically maps
    ///     to an <see cref="IAnimation"/> or a string-based animation key.
    /// </remarks>
    public interface IAddAnimation<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Adds the specified animation to the builder's target entity.
        /// </summary>
        /// <param name="value">The animation clip, key, or configuration to apply. Must not be null.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder AddAnimation(TArgument value);
    }
}