// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOnInit.cs
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
    ///     Lifecycle hook called during initial component construction, before <see cref="IOnAwake.OnAwake" />.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     <see cref="IOnInit"/> is the earliest lifecycle point — it fires during entity creation,
    ///     before the entity enters the active game loop. Use this for allocating resources,
    ///     initializing internal state, or establishing references that other components may not
    ///     yet have.
    ///     </para>
    ///     <para>
    ///     To ensure proper ordering, implement <see cref="IOnInit"/> rather than putting
    ///     initialization logic in constructors, which may run before the entity is fully
    ///     registered in the scene.
    ///     </para>
    /// </remarks>
    /// <seealso cref="IComponentBase"/>
    public interface IOnInit : IComponentBase
    {
        /// <summary>
        ///     Called once during initial component setup, before <see cref="IOnAwake.OnAwake" />.
        /// </summary>
        /// <param name="self">The entity that owns this component.</param>
        void OnInit(IGameObject self);
    }
}