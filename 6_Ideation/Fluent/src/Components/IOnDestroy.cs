// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOnDestroy.cs
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
    ///     Lifecycle hook called when the owning entity is destroyed and removed from the game loop.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     <see cref="IOnDestroy"/> is the last lifecycle event an entity receives.
    ///     Use this to release resources, unsubscribe from events, save state,
    ///     or perform cleanup that prevents memory leaks.
    ///     </para>
    ///     <para>
    ///     Destruction is deferred until after the current update cycle completes
    ///     to avoid structural changes during iteration.
    ///     </para>
    /// </remarks>
    public interface IOnDestroy : IComponentBase
    {
        /// <summary>
        ///     Called when the owning entity is destroyed and removed from the game loop.
        /// </summary>
        void OnDestroy();
    }
}