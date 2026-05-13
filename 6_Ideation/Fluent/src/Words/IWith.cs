// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IWith.cs
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
    ///     Fluent builder interface that applies a general-purpose configuration or value
    ///     to the target builder using a context-dependent semantic.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The configuration or value type accepted by the builder.</typeparam>
    /// <remarks>
    ///     This is an extensible catch-all interface — the exact meaning of "with" depends on
    ///     the builder implementation. It can be used for dependency injection, state passing,
    ///     or any custom configuration that doesn't fit a more specific interface.
    /// </remarks>
    public interface IWith<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Applies a context-dependent configuration or value to the builder.
        /// </summary>
        /// <param name="value">The configuration or value to apply. Semantics depend on the builder type.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder With(TArgument value);
    }
}