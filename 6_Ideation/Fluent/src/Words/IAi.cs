// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IAi.cs
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
    ///     Fluent builder interface that configures artificial intelligence behavior
    ///     parameters for a game entity.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The AI configuration type, typically containing behavior parameters or state machine definitions.</typeparam>
    /// <remarks>
    ///     Use this interface to set up pathfinding parameters, decision-making logic,
    ///     FSM (Finite State Machine) configurations, or behavior tree references
    ///     for NPCs and other AI-driven entities.
    /// </remarks>
    public interface IAi<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Configures AI behavior parameters on the builder.
        /// </summary>
        /// <param name="value">The AI configuration object specifying behavior parameters, state machine, or decision logic.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Ai(TArgument value);
    }
}