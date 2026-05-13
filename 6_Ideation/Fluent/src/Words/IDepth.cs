// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IDepth.cs
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
    ///     Fluent builder interface that sets the rendering depth (z-order)
    ///     for a sprite, UI element, or scene layer.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The depth value type, typically <see cref="float"/> or <see cref="int"/>.</typeparam>
    /// <remarks>
    ///     Depth controls the draw order of entities. Higher depth values are drawn
    ///     on top of lower values. For UI, this maps to z-order sorting; for 2D scenes,
    ///     it determines sprite layering. Related interfaces: <see cref="IOrder"/>.
    /// </remarks>
    public interface IDepth<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the rendering depth (z-order) on the builder.
        /// </summary>
        /// <param name="value">The depth value. Higher values render on top of lower values.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Depth(TArgument value);
    }
}