// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EntityData.cs
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

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The entity data
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    internal readonly struct EntityData(int entityId, ushort entityVersion, ushort worldId)
    {
        /// <summary>
        ///     The entity id
        /// </summary>
        [FieldOffset(0)] internal readonly int EntityID = entityId;

        /// <summary>
        ///     The entity version
        /// </summary>
        [FieldOffset(4)] internal readonly ushort EntityVersion = entityVersion;

        /// <summary>
        ///     The world id
        /// </summary>
        [FieldOffset(6)] internal readonly ushort WorldID = worldId;
    }
}