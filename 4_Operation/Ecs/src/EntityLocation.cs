// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EntityLocation.cs
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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Core.Archetype;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The entity location
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct EntityLocation
    {
        //128 bits
        /// <summary>
        ///     The archetype
        /// </summary>
        internal Archetype Archetype;

        /// <summary>
        ///     The index
        /// </summary>
        internal int Index;

        /// <summary>
        ///     The flags
        /// </summary>
        internal EntityFlags Flags;

        /// <summary>
        ///     The version
        /// </summary>
        internal ushort Version;

        /// <summary>
        ///     Gets the value of the archetype id
        /// </summary>
        internal readonly ArchetypeID ArchetypeID => Archetype.ID;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntityLocation" /> class
        /// </summary>
        /// <param name="archetype">The archetype</param>
        /// <param name="index">The index</param>
        public EntityLocation(Archetype archetype, int index)
        {
            Archetype = archetype;
            Index = index;
            Flags = EntityFlags.None;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntityLocation" /> class
        /// </summary>
        /// <param name="archetype">The archetype</param>
        /// <param name="index">The index</param>
        /// <param name="flags">The flags</param>
        public EntityLocation(Archetype archetype, int index, EntityFlags flags)
        {
            Archetype = archetype;
            Index = index;
            Flags = flags;
        }

        /// <summary>
        ///     Gets the value of the default
        /// </summary>
        public static EntityLocation Default { get; } = new EntityLocation(null!, int.MaxValue);

        /// <summary>
        ///     Hases the event using the specified entity flags
        /// </summary>
        /// <param name="entityFlags">The entity flags</param>
        /// <returns>The res</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool HasEvent(EntityFlags entityFlags)
        {
            var res = (Flags & entityFlags) != EntityFlags.None;
            return res;
        }

        /// <summary>
        ///     Hases the event flag using the specified entity flags
        /// </summary>
        /// <param name="entityFlags">The entity flags</param>
        /// <param name="target">The target</param>
        /// <returns>The res</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasEventFlag(EntityFlags entityFlags, EntityFlags target)
        {
            var res = (entityFlags & target) != EntityFlags.None;
            return res;
        }
    }

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