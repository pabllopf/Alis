// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOnAwake.cs
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
    ///     Lifecycle hook called when a component is activated, before the first <see cref="IOnUpdate"/> call.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     <see cref="IOnAwake"/> fires after <see cref="IOnInit"/> and is the ideal place for
    ///     setup logic that requires other components to already exist and be initialized.
    ///     For example, acquiring references to sibling components, registering with managers,
    ///     or initializing subsystems.
    ///     </para>
    ///     <para>
    ///     This is called once per activation cycle — if the entity is deactivated and re-activated,
    ///     <see cref="IOnAwake"/> fires again.
    ///     </para>
    /// </remarks>
    public interface IOnAwake
    {
        /// <summary>
        ///     Called when the owning entity is awoken. Executes once after all <see cref="IOnInit" /> hooks have fired
        ///     and before any update loop begins.
        /// </summary>
        /// <param name="self">The entity that owns this component.</param>
        void OnAwake(IGameObject self);
    }
}