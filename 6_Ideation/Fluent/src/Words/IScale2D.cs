// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IScale2D.cs
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
    ///     Fluent builder interface that sets the 2D scale (width and height)
    ///     of a game entity's transform or visual representation.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The scale component type, typically <see cref="float"/>.</typeparam>
    /// <remarks>
    ///     Sets the local scale along the X and Y axes. This affects rendering size
    ///     and physics collider dimensions. A scale of (1, 1) is the default (identity).
    ///     For 3D scaling, additional overloads or interfaces may be required.
    /// </remarks>
    public interface IScale2D<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the 2D non-uniform scale on the builder.
        /// </summary>
        /// <param name="x">The horizontal (X-axis) scale factor.</param>
        /// <param name="y">The vertical (Y-axis) scale factor.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Scale(TArgument x, TArgument y);
    }
}