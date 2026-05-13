// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IAddComponent.cs
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

using System;

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that adds a component on the target builder.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method for chaining.</typeparam>
    /// <typeparam name="TArgument">The argument type accepted by the fluent method.</typeparam>
    public interface IAddComponent<out TBuilder, in TType>
    {
        /// <summary>
        ///     Adds a component with the specified function to the builder.
        /// </summary>
        /// <typeparam name="T">The specific type parameter for this operation.</typeparam>
        /// <param name="value">The function that creates the component.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder AddComponent<T>(Func<T, TType> value) where T : TType;

        /// <summary>
        ///     Adds a component with the specified value to the builder.
        /// </summary>
        /// <typeparam name="T">The specific type parameter for this operation.</typeparam>
        /// <param name="value">The component to apply.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder AddComponent<T>(T value) where T : TType;
    }
}