// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IDelete.cs
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
    ///     Fluent builder interface that marks a game entity or component for deletion.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The identifier or reference of the entity/component to delete.</typeparam>
    /// <remarks>
    ///     Deletion is typically deferred to the end of the current update cycle to
    ///     maintain structural consistency. The actual removal is handled by the
    ///     <see cref="Scene"/> during its deferred operation resolution phase.
    /// </remarks>
    public interface IDelete<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Deletes the specified entity or component from the scene.
        /// </summary>
        /// <param name="obj">The entity or component reference to mark for deletion.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Delete(TArgument obj);
    }
}