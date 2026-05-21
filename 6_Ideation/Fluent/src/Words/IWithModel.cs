// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IWithModel.cs
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
    ///     Fluent builder interface that assigns a 3D model or mesh asset
    ///     to a game entity for rendering.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The model reference type — typically a mesh asset, model descriptor, or resource key.</typeparam>
    /// <remarks>
    ///     Used to attach 3D geometry to an entity for rendering. The model is usually
    ///     loaded from the asset pipeline and may include materials, bones (for skinning),
    ///     and LOD (Level of Detail) configurations.
    ///     Related interfaces: <see cref="IGraphic"/>.
    /// </remarks>
    public interface IWithModel<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Attaches a 3D model or mesh asset to the builder's target entity.
        /// </summary>
        /// <param name="value">The model asset reference, descriptor, or resource key.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder WithModel(TArgument value);
    }
}