// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IManagerOf.cs
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
    ///     Fluent builder interface that registers or configures a manager component
    ///     responsible for coordinating a specific subsystem or resource type.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The manager configuration or type parameter.</typeparam>
    /// <remarks>
    ///     Managers handle cross-cutting concerns like audio management,
    ///     entity pooling, event dispatching, or resource lifecycle.
    ///     This interface allows binding a manager to a specific context or scope.
    /// </remarks>
    public interface IManagerOf<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Configures a manager of a specific type on the builder.
        /// </summary>
        /// <typeparam name="T">The specific manager type to configure.</typeparam>
        /// <param name="value">The manager configuration instance or parameters.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder ManagerOf<T>(TArgument value);
    }
}