// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOnStart.cs
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
    ///     Lifecycle hook called once when the entity is first activated and enters the main game loop.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     <see cref="IOnStart"/> fires after <see cref="IOnAwake.OnAwake" /> and <see cref="IOnInit.OnInit" />,
    ///     and before any <see cref="IOnUpdate.OnUpdate" /> calls. It is the ideal place for one-time
    ///     initialization that depends on other systems being ready (e.g., registering with managers,
    ///     acquiring references, or starting coroutines).
    ///     </para>
    ///     <para>
    ///     Unlike <see cref="IOnInit"/>, <see cref="IOnStart"/> is called only when the entity
    ///     transitions from inactive to active state, not during initial scene population.
    ///     </para>
    /// </remarks>
    public interface IOnStart
    {
        /// <summary>
        ///     Called once when the owning entity becomes active and enters the main update loop.
        /// </summary>
        /// <param name="self">The entity that owns this component.</param>
        void OnStart(IGameObject self);
    }
}