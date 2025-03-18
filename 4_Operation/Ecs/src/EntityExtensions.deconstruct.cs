// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EntityExtensions.deconstruct.cs
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
using Frent.Core;
using Frent.Core.Structures;
using Frent.Updating;
using Frent.Updating.Runners;

namespace Frent
{
    /// <summary>
    ///     Deconstruction extensions for entities.
    /// </summary>
    public static partial class EntityExtensions
    {
        /// <summary>
        ///     Deconstructs the constituent components of an entity as reference(s).
        /// </summary>
        /// <exception cref="InvalidOperationException">The entity is not alive.</exception>
        /// <exception cref="ComponentNotFoundException">The entity does not have all the components specified.</exception>
        public static void Deconstruct<T>(this Entity e, out Ref<T> comp)
        {
            EntityLocation eloc = e.AssertIsAlive(out _);

            ComponentStorageBase[] comps = eloc.Archetype.Components;
            byte[] archetypeTable = eloc.Archetype.ComponentTagTable;

            comp = GetComp<T>(archetypeTable, comps, eloc.Index);
        }
    }

    /// <summary>
    ///     The entity extensions class
    /// </summary>
    partial class EntityExtensions
    {
        /// <summary>
        ///     Gets the comp using the specified archetype table
        /// </summary>
        /// <typeparam name="TC">The tc</typeparam>
        /// <param name="archetypeTable">The archetype table</param>
        /// <param name="comps">The comps</param>
        /// <param name="index">The index</param>
        /// <returns>A ref of tc</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Ref<TC> GetComp<TC>(byte[] archetypeTable, ComponentStorageBase[] comps, int index)
        {
            int compIndex = archetypeTable.UnsafeArrayIndex(Component<TC>.ID.RawIndex) & GlobalWorldTables.IndexBits;
            return new Ref<TC>(UnsafeExtensions.UnsafeCast<ComponentStorage<TC>>(comps.UnsafeArrayIndex(compIndex)), index);
        }
    }
}