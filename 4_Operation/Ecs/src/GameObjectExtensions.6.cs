// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectExtensions.6.cs
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
using Alis.Core.Ecs.Exceptions;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The gameObject extensions class
    /// </summary>
    public static partial class GameObjectExtensions
    {
        /// <summary>
        ///     Deconstructs the constituent components of an gameObject as reference(s).
        /// </summary>
        /// <exception cref="InvalidOperationException">The gameObject is not alive.</exception>
        /// <exception cref="ComponentNotFoundException">The gameObject does not have all the components specified.</exception>
        public static void Deconstruct<T1, T2, T3, T4, T5, T6>(this GameObject e, out Ref<T1> comp1, out Ref<T2> comp2,
            out Ref<T3> comp3, out Ref<T4> comp4, out Ref<T5> comp5, out Ref<T6> comp6)
        {
            GameObjectLocation eloc = e.AssertIsAlive(out _);

            ComponentStorageBase[] comps = eloc.Archetype.Components;
            byte[] archetypeTable = eloc.Archetype.ComponentTagTable;

            comp1 = GetComp<T1>(archetypeTable, comps, eloc.Index);
            comp2 = GetComp<T2>(archetypeTable, comps, eloc.Index);
            comp3 = GetComp<T3>(archetypeTable, comps, eloc.Index);
            comp4 = GetComp<T4>(archetypeTable, comps, eloc.Index);
            comp5 = GetComp<T5>(archetypeTable, comps, eloc.Index);
            comp6 = GetComp<T6>(archetypeTable, comps, eloc.Index);
        }
    }
}