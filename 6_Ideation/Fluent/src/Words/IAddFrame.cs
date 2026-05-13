// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IAddFrame.cs
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
    ///     Fluent builder interface that adds an animation frame or sprite frame
    ///     to a game entity's animation sequence.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The frame data type, typically a texture region, sprite rectangle, or frame index.</typeparam>
    /// <remarks>
    ///     Used in conjunction with <see cref="IAddAnimation{out TBuilder, in TArgument}"/>
    ///     to build multi-frame sprite animations. Each frame typically references a
    ///     region of a sprite sheet or an individual texture.
    /// </remarks>
    public interface IAddFrame<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Appends a single frame to the entity's animation sequence.
        /// </summary>
        /// <param name="value">The frame data to append. Represents a sprite region, texture reference, or frame descriptor.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder AddFrame(TArgument value);
    }
}