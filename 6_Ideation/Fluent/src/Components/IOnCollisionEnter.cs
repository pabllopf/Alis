// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOnCollisionEnter.cs
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
    ///     Collision lifecycle hook called when the owning entity's collider first
    ///     makes contact with another entity's collider.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     <see cref="IOnCollisionEnter"/> fires during the physics update pass when
    ///     collision detection determines two colliders are overlapping for the first time.
    ///     For continuous collision response, use <see cref="IOnCollisionExit"/> for separation.
    ///     </para>
    ///     <para>
    ///     The <paramref name="other"/> parameter provides access to the colliding entity,
    ///     allowing inspection of its components or triggering reactions like damage, bouncing,
    ///     or sound effects.
    ///     </para>
    /// </remarks>
    public interface IOnCollisionEnter
    {
        /// <summary>
        ///     Called when this entity's collider first contacts another entity's collider.
        /// </summary>
        /// <param name="other">The entity that was collided with.</param>
        void OnCollisionEnter(IGameObject other);
    }
}