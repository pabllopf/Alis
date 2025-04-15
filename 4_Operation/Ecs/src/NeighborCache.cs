// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NeighborCache.cs
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
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Marshalling;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The neighbor cache
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct NeighborCache<T> : IArchetypeGraphEdge
    {
        /// <summary>
        ///     Modifies the tags using the specified tags
        /// </summary>
        /// <param name="tags">The tags</param>
        /// <param name="add">The add</param>
        public void ModifyTags(ref FastImmutableArray<TagId> tags, bool add)
        {
            if (add)
            {
                tags = MemoryHelpers.Concat(tags, Tag<T>.ID);
            }
            else
            {
                tags = MemoryHelpers.Remove(tags, Tag<T>.ID);
            }
        }

        /// <summary>
        ///     Modifies the components using the specified components
        /// </summary>
        /// <param name="components">The components</param>
        /// <param name="add">The add</param>
        public void ModifyComponents(ref FastImmutableArray<ComponentID> components, bool add)
        {
            if (add)
            {
                components = MemoryHelpers.Concat(components, Component<T>.ID);
            }
            else
            {
                components = MemoryHelpers.Remove(components, Component<T>.ID);
            }
        }

        //separate into individual classes to avoid creating uneccecary static classes.

        /// <summary>
        ///     The add class
        /// </summary>
        internal static class Add
        {
            /// <summary>
            ///     The lookup
            /// </summary>
            internal static ArchetypeNeighborCache Lookup;
        }

        /// <summary>
        ///     The remove class
        /// </summary>
        internal static class Remove
        {
            /// <summary>
            ///     The lookup
            /// </summary>
            internal static ArchetypeNeighborCache Lookup;
        }

        /// <summary>
        ///     The tag class
        /// </summary>
        internal static class Tag
        {
            /// <summary>
            ///     The lookup
            /// </summary>
            internal static ArchetypeNeighborCache Lookup;
        }

        /// <summary>
        ///     The detach class
        /// </summary>
        internal static class Detach
        {
            /// <summary>
            ///     The lookup
            /// </summary>
            internal static ArchetypeNeighborCache Lookup;
        }
    }
}