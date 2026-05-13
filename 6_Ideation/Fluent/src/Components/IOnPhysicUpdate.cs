// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOnPhysicUpdate.cs
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
    ///     Lifecycle hook called during the dedicated physics update pass.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     <see cref="IOnPhysicUpdate"/> runs in the physics loop, separate from the standard
    ///     <see cref="IOnUpdate"/> and <see cref="IOnFixedUpdate"/> cycles. Use this for
    ///     collision detection callbacks, physics-based movement, raycasting, or any logic
    ///     that must execute within the physics simulation step.
    ///     </para>
    ///     <para>
    ///     This hook receives a reference to the owning <see cref="IGameObject"/> for
    ///     accessing sibling components or performing entity-level operations.
    ///     </para>
    /// </remarks>
    public interface IOnPhysicUpdate
    {
        /// <summary>
        ///     Called during the physics update pass with a reference to the owning entity.
        /// </summary>
        /// <param name="self">The entity that owns this component.</param>
        void OnPhysicUpdate(IGameObject self);
    }
}