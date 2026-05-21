// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IScript.cs
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
    ///     Fluent builder interface that attaches a script or behavior module
    ///     to a game entity.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The script type or instance — typically a <see cref="MonoBehaviour"/> subclass or scriptable object.</typeparam>
    /// <remarks>
    ///     Scripts define custom logic (AI, movement, interaction) for entities.
    ///     May accept either a type reference for instantiation or a pre-built instance
    ///     depending on the builder implementation.
    /// </remarks>
    public interface IScript<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Assigns a script to the builder's target entity.
        /// </summary>
        /// <param name="value">The script instance, type, or configuration to attach.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Script(TArgument value);
    }
}