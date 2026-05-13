// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOnCollisionExit.cs
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
    ///     Collision lifecycle hook called when the owning entity's collider
    ///     ceases contact with another entity's collider.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     <see cref="IOnCollisionExit"/> fires during the physics update pass when
    ///     collision detection determines two previously overlapping colliders are
    ///     no longer in contact. This signals the end of a collision interaction.
    ///     </para>
    ///     <para>
    ///     Use this for cleanup of collision-specific state — such as removing
    ///     contact damage cooldowns, stopping collision sounds, or resetting
    ///     physical responses that were initiated in <see cref="IOnCollisionEnter"/>.
    ///     </para>
    /// </remarks>
    public interface IOnCollisionExit
    {
        /// <summary>
        ///     Called when this entity's collider stops contacting another entity's collider.
        /// </summary>
        /// <param name="other">The entity that was previously collided with.</param>
        void OnCollisionExit(IGameObject other);
    }
}