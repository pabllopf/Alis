// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOnBeforeUpdate.cs
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

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     Lifecycle hook called once per frame before the variable-timestep <see cref="IOnUpdate"/> loop begins.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     <see cref="IOnBeforeUpdate"/> executes before any <see cref="IOnUpdate"/> hooks fire.
    ///     Use this for time-critical setup that must happen before all game logic — such as
    ///     processing input, updating global state machines, or preparing data for the update pass.
    ///     </para>
    ///     <para>
    ///     This hook is well-suited for frame-time accumulation (e.g., fixed timestep accumulators)
    ///     or batch preparation operations.
    ///     </para>
    /// </remarks>
    public interface IOnBeforeUpdate
    {
        /// <summary>
        ///     Called every frame before <see cref="IOnUpdate.OnUpdate" /> hooks execute.
        /// </summary>
        /// <param name="self">The entity that owns this component.</param>
        void OnBeforeUpdate(IGameObject self);
    }
}