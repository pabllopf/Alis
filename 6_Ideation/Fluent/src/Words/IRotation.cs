// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IRotation.cs
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
    ///     Fluent builder interface that sets the absolute rotation angle
    ///     of a game entity's transform.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The rotation angle type, typically <see cref="float"/> in degrees.</typeparam>
    /// <remarks>
    ///     Sets the entity's world-space rotation. For incremental rotation,
    ///     apply the delta to the current rotation value. Related interfaces:
    ///     <see cref="IFixedRotation"/>.
    /// </remarks>
    public interface IRotation<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the rotation angle on the builder.
        /// </summary>
        /// <param name="angle">The absolute rotation angle in degrees (0–360).</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Rotation(TArgument angle);
    }
}