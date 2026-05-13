// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectExtensions.cs
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

using System.Runtime.CompilerServices;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     Deconstruction extensions for entities.
    /// </summary>
    public static class GameObjectExtensions
    {
        /// <summary>
        ///     Deconstructs the entity into a component reference
        /// </summary>
        /// <typeparam name="T">The component type to extract</typeparam>
        /// <param name="e">The gameObject to deconstruct</param>
        /// <param name="comp">The extracted component reference</param>
        public static void Deconstruct<T>(this GameObject e, out Ref<T> comp)
        {
            GameObjectLocation eloc = e.AssertIsAlive(out _);

            ComponentStorageBase[] comps = eloc.Archetype.Components;
            byte[] archetypeTable = eloc.Archetype.ComponentTagTable;

            comp = GetComp<T>(archetypeTable, comps, eloc.Index);
        }

        /// <summary>
        ///     Deconstructs the entity into two component references
        /// </summary>
        /// <typeparam name="T1">The first component type</typeparam>
        /// <typeparam name="T2">The second component type</typeparam>
        /// <param name="e">The gameObject to deconstruct</param>
        /// <param name="comp1">The first extracted component reference</param>
        /// <param name="comp2">The second extracted component reference</param>
        public static void Deconstruct<T1, T2>(this GameObject e, out Ref<T1> comp1, out Ref<T2> comp2)
        {
            GameObjectLocation eloc = e.AssertIsAlive(out _);

            ComponentStorageBase[] comps = eloc.Archetype.Components;
            byte[] archetypeTable = eloc.Archetype.ComponentTagTable;

            comp1 = GetComp<T1>(archetypeTable, comps, eloc.Index);
            comp2 = GetComp<T2>(archetypeTable, comps, eloc.Index);
        }

        /// <summary>
        ///     Deconstructs the entity into three component references
        /// </summary>
        /// <typeparam name="T1">The first component type</typeparam>
        /// <typeparam name="T2">The second component type</typeparam>
        /// <typeparam name="T3">The third component type</typeparam>
        /// <param name="e">The gameObject to deconstruct</param>
        /// <param name="comp1">The first extracted component reference</param>
        /// <param name="comp2">The second extracted component reference</param>
        /// <param name="comp3">The third extracted component reference</param>
        public static void Deconstruct<T1, T2, T3>(this GameObject e, out Ref<T1> comp1, out Ref<T2> comp2, out Ref<T3> comp3)
        {
            GameObjectLocation eloc = e.AssertIsAlive(out _);

            ComponentStorageBase[] comps = eloc.Archetype.Components;
            byte[] archetypeTable = eloc.Archetype.ComponentTagTable;

            comp1 = GetComp<T1>(archetypeTable, comps, eloc.Index);
            comp2 = GetComp<T2>(archetypeTable, comps, eloc.Index);
            comp3 = GetComp<T3>(archetypeTable, comps, eloc.Index);
        }

        /// <summary>
        ///     Deconstructs the entity into four component references
        /// </summary>
        /// <typeparam name="T1">The first component type</typeparam>
        /// <typeparam name="T2">The second component type</typeparam>
        /// <typeparam name="T3">The third component type</typeparam>
        /// <typeparam name="T4">The fourth component type</typeparam>
        /// <param name="e">The gameObject to deconstruct</param>
        /// <param name="comp1">The first extracted component reference</param>
        /// <param name="comp2">The second extracted component reference</param>
        /// <param name="comp3">The third extracted component reference</param>
        /// <param name="comp4">The fourth extracted component reference</param>
        public static void Deconstruct<T1, T2, T3, T4>(this GameObject e, out Ref<T1> comp1, out Ref<T2> comp2,
            out Ref<T3> comp3, out Ref<T4> comp4)
        {
            GameObjectLocation eloc = e.AssertIsAlive(out _);

            ComponentStorageBase[] comps = eloc.Archetype.Components;
            byte[] archetypeTable = eloc.Archetype.ComponentTagTable;

            comp1 = GetComp<T1>(archetypeTable, comps, eloc.Index);
            comp2 = GetComp<T2>(archetypeTable, comps, eloc.Index);
            comp3 = GetComp<T3>(archetypeTable, comps, eloc.Index);
            comp4 = GetComp<T4>(archetypeTable, comps, eloc.Index);
        }

        /// <summary>
        ///     Deconstructs the entity into five component references
        /// </summary>
        /// <typeparam name="T1">The first component type</typeparam>
        /// <typeparam name="T2">The second component type</typeparam>
        /// <typeparam name="T3">The third component type</typeparam>
        /// <typeparam name="T4">The fourth component type</typeparam>
        /// <typeparam name="T5">The fifth component type</typeparam>
        /// <param name="e">The gameObject to deconstruct</param>
        /// <param name="comp1">The first extracted component reference</param>
        /// <param name="comp2">The second extracted component reference</param>
        /// <param name="comp3">The third extracted component reference</param>
        /// <param name="comp4">The fourth extracted component reference</param>
        /// <param name="comp5">The fifth extracted component reference</param>
        public static void Deconstruct<T1, T2, T3, T4, T5>(this GameObject e, out Ref<T1> comp1, out Ref<T2> comp2,
            out Ref<T3> comp3, out Ref<T4> comp4, out Ref<T5> comp5)
        {
            GameObjectLocation eloc = e.AssertIsAlive(out _);

            ComponentStorageBase[] comps = eloc.Archetype.Components;
            byte[] archetypeTable = eloc.Archetype.ComponentTagTable;

            comp1 = GetComp<T1>(archetypeTable, comps, eloc.Index);
            comp2 = GetComp<T2>(archetypeTable, comps, eloc.Index);
            comp3 = GetComp<T3>(archetypeTable, comps, eloc.Index);
            comp4 = GetComp<T4>(archetypeTable, comps, eloc.Index);
            comp5 = GetComp<T5>(archetypeTable, comps, eloc.Index);
        }

        /// <summary>
        ///     Deconstructs the entity into six component references
        /// </summary>
        /// <typeparam name="T1">The first component type</typeparam>
        /// <typeparam name="T2">The second component type</typeparam>
        /// <typeparam name="T3">The third component type</typeparam>
        /// <typeparam name="T4">The fourth component type</typeparam>
        /// <typeparam name="T5">The fifth component type</typeparam>
        /// <typeparam name="T6">The sixth component type</typeparam>
        /// <param name="e">The gameObject to deconstruct</param>
        /// <param name="comp1">The first extracted component reference</param>
        /// <param name="comp2">The second extracted component reference</param>
        /// <param name="comp3">The third extracted component reference</param>
        /// <param name="comp4">The fourth extracted component reference</param>
        /// <param name="comp5">The fifth extracted component reference</param>
        /// <param name="comp6">The sixth extracted component reference</param>
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

        /// <summary>
        ///     Deconstructs the entity into seven component references
        /// </summary>
        /// <typeparam name="T1">The first component type</typeparam>
        /// <typeparam name="T2">The second component type</typeparam>
        /// <typeparam name="T3">The third component type</typeparam>
        /// <typeparam name="T4">The fourth component type</typeparam>
        /// <typeparam name="T5">The fifth component type</typeparam>
        /// <typeparam name="T6">The sixth component type</typeparam>
        /// <typeparam name="T7">The seventh component type</typeparam>
        /// <param name="e">The gameObject to deconstruct</param>
        /// <param name="comp1">The first extracted component reference</param>
        /// <param name="comp2">The second extracted component reference</param>
        /// <param name="comp3">The third extracted component reference</param>
        /// <param name="comp4">The fourth extracted component reference</param>
        /// <param name="comp5">The fifth extracted component reference</param>
        /// <param name="comp6">The sixth extracted component reference</param>
        /// <param name="comp7">The seventh extracted component reference</param>
        public static void Deconstruct<T1, T2, T3, T4, T5, T6, T7>(this GameObject e, out Ref<T1> comp1, out Ref<T2> comp2,
            out Ref<T3> comp3, out Ref<T4> comp4, out Ref<T5> comp5, out Ref<T6> comp6, out Ref<T7> comp7)
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
            comp7 = GetComp<T7>(archetypeTable, comps, eloc.Index);
        }

        /// <summary>
        ///     Deconstructs the entity into eight component references
        /// </summary>
        /// <typeparam name="T1">The first component type</typeparam>
        /// <typeparam name="T2">The second component type</typeparam>
        /// <typeparam name="T3">The third component type</typeparam>
        /// <typeparam name="T4">The fourth component type</typeparam>
        /// <typeparam name="T5">The fifth component type</typeparam>
        /// <typeparam name="T6">The sixth component type</typeparam>
        /// <typeparam name="T7">The seventh component type</typeparam>
        /// <typeparam name="T8">The eighth component type</typeparam>
        /// <param name="e">The gameObject to deconstruct</param>
        /// <param name="comp1">The first extracted component reference</param>
        /// <param name="comp2">The second extracted component reference</param>
        /// <param name="comp3">The third extracted component reference</param>
        /// <param name="comp4">The fourth extracted component reference</param>
        /// <param name="comp5">The fifth extracted component reference</param>
        /// <param name="comp6">The sixth extracted component reference</param>
        /// <param name="comp7">The seventh extracted component reference</param>
        /// <param name="comp8">The eighth extracted component reference</param>
        public static void Deconstruct<T1, T2, T3, T4, T5, T6, T7, T8>(this GameObject e, out Ref<T1> comp1, out Ref<T2> comp2,
            out Ref<T3> comp3, out Ref<T4> comp4, out Ref<T5> comp5, out Ref<T6> comp6, out Ref<T7> comp7,
            out Ref<T8> comp8)
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
            comp7 = GetComp<T7>(archetypeTable, comps, eloc.Index);
            comp8 = GetComp<T8>(archetypeTable, comps, eloc.Index);
        }

        /// <summary>
        ///     Gets a component reference using the archetype's tag table and component list
        /// </summary>
        /// <typeparam name="TC">The component type to retrieve</typeparam>
        /// <param name="archetypeTable">The component tag table of the archetype</param>
        /// <param name="comps">The component storage array of the archetype</param>
        /// <param name="index">The entity index within the archetype</param>
        /// <returns>A reference to the component of type <typeparamref name="TC" /></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Ref<TC> GetComp<TC>(byte[] archetypeTable, ComponentStorageBase[] comps, int index)
        {
            int compIndex = Unsafe.Add(ref archetypeTable[0], Component<TC>.Id.RawIndex) & GlobalWorldTables.IndexBits;
            return new Ref<TC>(Unsafe.As<ComponentStorage<TC>>(Unsafe.Add(ref comps[0], compIndex)), index);
        }
    }
}