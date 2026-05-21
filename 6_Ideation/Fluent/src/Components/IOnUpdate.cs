// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOnUpdate.cs
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
    ///     Lifecycle hook called every frame during the variable-timestep update loop.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     <see cref="IOnUpdate"/> is the primary per-frame logic hook. Components implementing
    ///     this interface receive the owning entity reference each frame for game logic execution.
    ///     </para>
    ///     <para>
    ///     Only implement one "Update" method across all update-related interfaces to avoid
    ///     duplicate logic. For physics-based updates at a fixed timestep, use
    ///     <see cref="IOnFixedUpdate"/> instead.
    ///     </para>
    /// </remarks>
    public partial interface IOnUpdate : IComponentBase
    {
        /// <summary>
        ///     Called every frame during the variable-timestep update loop with a reference to the owning entity.
        /// </summary>
        /// <param name="self">The entity that owns this component.</param>
        void OnUpdate(IGameObject self);
    }
}