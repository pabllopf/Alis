// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IGame.cs
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

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     Defines the contract for a game instance in the Alis ECS framework.
    ///     Implementations of this interface provide the core game loop entry points for running and exiting.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         <see cref="IGame" /> is the top-level interface for any game built on the Alis framework.
    ///         It is typically implemented by the main <see cref="VideoGame" /> class and consumed
    ///         by the host platform to start, update, and tear down the game.
    ///     </para>
    ///     <para>
    ///         Call <see cref="Run" /> to start the game loop. Once the loop finishes,
    ///         call <see cref="Exit" /> to signal the game to shut down gracefully.
    ///     </para>
    /// </remarks>
    public interface IGame
    {
        /// <summary>
        ///     Starts the game loop, initializing all managers and subsystems,
        ///     then running the main update/render cycle until <see cref="Exit" /> is called.
        /// </summary>
        /// <remarks>
        ///     This method blocks the calling thread for the duration of the game session.
        ///     It orchestrates the lifecycle of all registered managers (init, awake, start,
        ///     fixed update, update, draw, etc.) and dispatches events each frame.
        /// </remarks>
        void Run();

        /// <summary>
        ///     Signals the game to stop running and perform cleanup.
        /// </summary>
        /// <remarks>
        ///     Sets the internal running flag to <see langword="false" /> so the game loop in
        ///     <see cref="Run" /> can exit gracefully. All managers receive their final
        ///     <c>OnStop</c>, <c>OnExit</c>, and <c>OnDestroy</c> lifecycle callbacks.
        /// </remarks>
        void Exit();
    }
}