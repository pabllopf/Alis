// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOnAfterUpdate.cs
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
    ///     Lifecycle hook called once per frame after the variable-timestep <see cref="IOnUpdate"/> loop completes.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     Use <see cref="IOnAfterUpdate"/> for logic that must execute after all update
    ///     calculations are complete — for example, synchronizing transform hierarchies,
    ///     applying accumulated forces, or resolving post-update constraints.
    ///     </para>
    ///     <para>
    ///     This hook also executes during deferred entity creation frames, allowing
    ///     newly created entities to receive their first post-update processing.
    ///     </para>
    /// </remarks>
    public interface IOnAfterUpdate
    {
        /// <summary>
        ///     Called every frame after <see cref="IOnUpdate.OnUpdate" /> hooks finish executing.
        /// </summary>
        /// <param name="self">The entity that owns this component.</param>
        void OnAfterUpdate(IGameObject self);
    }
}