// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EntityFlags.cs
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

using System;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The entity flags enum
    /// </summary>
    [Flags]
    internal enum EntityFlags : ushort
    {
        /// <summary>
        ///     The none entity flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The tagged entity flags
        /// </summary>
        Tagged = 1 << 0,

        /// <summary>
        ///     The detach entity flags
        /// </summary>
        Detach = 1 << 1,

        /// <summary>
        ///     The add comp entity flags
        /// </summary>
        AddComp = 1 << 2,

        /// <summary>
        ///     The add generic comp entity flags
        /// </summary>
        AddGenericComp = 1 << 3,

        /// <summary>
        ///     The remove comp entity flags
        /// </summary>
        RemoveComp = 1 << 4,

        /// <summary>
        ///     The remove generic comp entity flags
        /// </summary>
        RemoveGenericComp = 1 << 5,

        /// <summary>
        ///     The on delete entity flags
        /// </summary>
        OnDelete = 1 << 6,

        /// <summary>
        ///     The events entity flags
        /// </summary>
        Events = Tagged | Detach | AddComp | RemoveComp | OnDelete | WorldCreate,

        /// <summary>
        ///     The world create entity flags
        /// </summary>
        WorldCreate = 1 << 7,

        /// <summary>
        ///     The has world command buffer remove entity flags
        /// </summary>
        HasWorldCommandBufferRemove = 1 << 8,

        /// <summary>
        ///     The has world command buffer add entity flags
        /// </summary>
        HasWorldCommandBufferAdd = 1 << 9,

        /// <summary>
        ///     The has world command buffer delete entity flags
        /// </summary>
        HasWorldCommandBufferDelete = 1 << 10,

        /// <summary>
        ///     The is unmerged entity entity flags
        /// </summary>
        IsUnmergedEntity = 1 << 11
    }
}