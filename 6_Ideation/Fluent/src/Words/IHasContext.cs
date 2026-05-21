// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IHasContext.cs
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
    ///     Fluent builder interface that provides access to a shared context object
    ///     during the entity construction pipeline.
    /// </summary>
    /// <typeparam name="T">The type of context object shared across the build pipeline.</typeparam>
    /// <remarks>
    ///     The context can carry shared state between different fluent builder stages
    ///     (e.g., a level editor reference, a shared resource manager, or a build accumulator).
    ///     This interface exposes the context as a mutable property for read/write access.
    /// </remarks>
    public interface IHasContext<T>
    {
        /// <summary>
        ///     Gets or sets the shared context value available during entity construction.
        /// </summary>
        /// <value>The context object. Can be read or modified by the builder pipeline.</value>
        T Context { get; set; }
    }
}