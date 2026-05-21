// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOnProcessPendingChanges.cs
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
    ///     Lifecycle hook called when the entity has accumulated pending state changes
    ///     that need to be processed in a batch.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     <see cref="IOnProcessPendingChanges"/> is invoked during the deferred operation
    ///     resolution phase, allowing entities to apply batched modifications, deferred
    ///     actions, or queued state transitions in a controlled manner.
    ///     </para>
    ///     <para>
    ///     This is especially useful for bulk updates that would be expensive if processed
    ///     one-by-one during the normal update loop.
    ///     </para>
    /// </remarks>
    public interface IOnProcessPendingChanges
    {
        /// <summary>
        ///     Called when the owning entity has pending state changes to process.
        /// </summary>
        /// <param name="self">The entity that owns this component.</param>
        void OnProcessPendingChanges(IGameObject self);
    }
}