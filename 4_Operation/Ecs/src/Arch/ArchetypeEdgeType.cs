// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ArchetypeEdgeType.cs
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

namespace Alis.Core.Ecs.Arch
{
    /// <summary>
    ///     The archetype edge type enum
    /// </summary>
    internal enum ArchetypeEdgeType : ushort
    {
        /// <summary>
        ///     The add component archetype edge type
        /// </summary>
        AddComponent = 49157,

        /// <summary>
        ///     The remove component archetype edge type
        /// </summary>
        RemoveComponent = 24593,

        /// <summary>
        ///     The add tag archetype edge type
        /// </summary>
        AddTag = 12289,

        /// <summary>
        ///     The remove tag archetype edge type
        /// </summary>
        RemoveTag = 6151
    }
}