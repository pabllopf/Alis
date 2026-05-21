// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EntityWorldInfoAccess.cs
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

using System.Runtime.InteropServices;
using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     A compact representation of an entity's identification and ownership information.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     This struct provides a memory-optimized view (8 bytes total) combining entity ID
    ///     and scene identifier for efficient lookup operations in the ECS architecture.
    ///     </para>
    ///     <para>
    ///     Memory layout: <c>GameObjectIdOnly</c> (6 bytes) + <c>WorldID</c> (2 bytes) = 8 bytes total.
    ///     Uses <c>Pack = 1</c> to eliminate padding and minimize memory footprint.
    ///     </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct EntityWorldInfoAccess
    {
        /// <summary>
        ///     Gets or sets the combined entity ID and version.
        /// </summary>
        /// <value>
        ///     A <see cref="GameObjectIdOnly"/> containing the entity's unique identifier and
        ///     version counter for stale reference detection.
        /// </value>
        internal GameObjectIdOnly EntityIDOnly;

        /// <summary>
        ///     Gets or sets the identifier of the scene that owns this entity.
        /// </summary>
        /// <value>
        ///     The unique identifier of the <see cref="Scene"/> that contains the entity.
        /// </value>
        internal ushort WorldID;
    }
}