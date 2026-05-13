// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOnExit.cs
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
    ///     Lifecycle hook called when the owning entity is deactivated or leaves the active game loop.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     <see cref="IOnExit"/> fires when an entity transitions from active to inactive state,
    ///     but before <see cref="IOnDestroy"/> is called. The entity is still logically present
    ///     in the scene but no longer receives update, draw, or physics callbacks.
    ///     </para>
    ///     <para>
    ///     Use this for cleanup that should happen on deactivation but not permanent destruction —
    ///     such as unsubscribing from active-only events, pausing animations, or saving transient state.
    ///     </para>
    /// </remarks>
    public interface IOnExit
    {
        /// <summary>
        ///     Called when the owning entity is deactivated or removed from the active update loop.
        /// </summary>
        /// <param name="self">The entity that owns this component.</param>
        void OnExit(IGameObject self);
    }
}