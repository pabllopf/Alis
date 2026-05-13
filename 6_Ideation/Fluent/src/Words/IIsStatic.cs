// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IIsStatic.cs
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
    ///     Fluent builder interface that sets static body state on the target builder.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method for chaining.</typeparam>
    /// <typeparam name="TArgument">The argument type accepted by the fluent method.</typeparam>
    public interface IIsStatic<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets static body state to <c>true</c> on the builder (no argument overload).
        /// </summary>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder IsStatic();

        /// <summary>
        ///     Sets static body state on the builder using the provided value.
        /// </summary>
        /// <param name="value">The static setting to apply.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder IsStatic(TArgument value);
    }
}