// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOnFixedUpdate.cs
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
    ///     Lifecycle hook called at a fixed timestep, independent of frame rate.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     <see cref="IOnFixedUpdate"/> is designed for physics calculations and other
    ///     simulation that requires deterministic, consistent timing. It executes at a
    ///     fixed interval regardless of render frame rate.
    ///     </para>
    ///     <para>
    ///     On slow machines, <see cref="IOnFixedUpdate"/> may fire multiple times per frame
    ///     to catch up. On fast machines, it may fire less frequently than <see cref="IOnUpdate"/>.
    ///     This ensures stable physics simulation across different hardware.
    ///     </para>
    /// </remarks>
    public interface IOnFixedUpdate
    {
        /// <summary>
        ///     Called at each fixed timestep interval with a reference to the owning entity.
        ///     Executes less frequently than <see cref="IOnUpdate.OnUpdate" /> on low-frame machines
        ///     and more frequently on high-frame machines, ensuring consistent simulation speed.
        /// </summary>
        /// <param name="self">The entity that owns this component.</param>
        void OnFixedUpdate(IGameObject self);
    }
}