// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Scene.11.cs
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
using Alis.Core.Ecs.Arch;
using Alis.Core.Ecs.Marshalling;
using Alis.Core.Ecs.Operations;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs
{
    /// <summary>
    /// The scene class
    /// </summary>
    partial class Scene
    {
        /// <summary>
        ///     Creates an <see cref="T:Alis.Entity" /> with the given component(s)
        /// </summary>
        /// <returns>An <see cref="T:Alis.Entity" /> that can be used to acsess the component data</returns>
        [SkipLocalsInit]
        public GameObject Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
            in T1 comp1,
            in T2 comp2,
            in T3 comp3,
            in T4 comp4,
            in T5 comp5,
            in T6 comp6,
            in T7 comp7,
            in T8 comp8,
            in T9 comp9,
            in T10 comp10,
            in T11 comp11)
        {
            Archetype existingArchetype = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.CreateNewOrGetExistingArchetype(this);

            EntityLocation entityLocation = new EntityLocation();
            Unsafe.SkipInit(out int physicalIndex);
            ComponentStorageBase[] writeStorage;

            ref EntityIdOnly local1 = ref Unsafe.NullRef<EntityIdOnly>();
            if (AllowStructualChanges)
            {
                writeStorage = existingArchetype.Components;
                local1 = ref existingArchetype.CreateEntityLocation(EntityFlags.None, out entityLocation);
                physicalIndex = entityLocation.Index;
            }
            else
            {
                local1 = ref existingArchetype.CreateDeferredEntityLocation(this, ref entityLocation, out physicalIndex, out writeStorage);
                entityLocation.Archetype = DeferredCreateArchetype;
            }

            (int num, ushort version) = local1 = RecycledEntityIds.CanPop() ? RecycledEntityIds.Pop() : new EntityIdOnly(NextEntityID++, 0);
            entityLocation.Version = version;
            EntityTable[num] = entityLocation;
            ref T1 local2 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T1>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.OfComponent<T1>.Index))[physicalIndex];
            local2 = comp1;
            ref T2 local3 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T2>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.OfComponent<T2>.Index))[physicalIndex];
            local3 = comp2;
            ref T3 local4 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T3>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.OfComponent<T3>.Index))[physicalIndex];
            local4 = comp3;
            ref T4 local5 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T4>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.OfComponent<T4>.Index))[physicalIndex];
            local5 = comp4;
            ref T5 local6 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T5>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.OfComponent<T5>.Index))[physicalIndex];
            local6 = comp5;
            ref T6 local7 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T6>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.OfComponent<T6>.Index))[physicalIndex];
            local7 = comp6;
            ref T7 local8 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T7>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.OfComponent<T7>.Index))[physicalIndex];
            local8 = comp7;
            ref T8 local9 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T8>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.OfComponent<T8>.Index))[physicalIndex];
            local9 = comp8;
            ref T9 local10 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T9>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.OfComponent<T9>.Index))[physicalIndex];
            local10 = comp9;
            ref T10 local11 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T10>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.OfComponent<T10>.Index))[physicalIndex];
            local11 = comp10;
            ref T11 local12 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T11>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.OfComponent<T11>.Index))[physicalIndex];
            local12 = comp11;
            GameObject gameObject = new GameObject(ID, version, num);
            ComponentDelegates<T1>.InitDelegate initer1 = Component<T1>.Initer;
            initer1?.Invoke(gameObject, ref local2);

            ComponentDelegates<T2>.InitDelegate initer2 = Component<T2>.Initer;
            initer2?.Invoke(gameObject, ref local3);

            ComponentDelegates<T3>.InitDelegate initer3 = Component<T3>.Initer;
            initer3?.Invoke(gameObject, ref local4);

            ComponentDelegates<T4>.InitDelegate initer4 = Component<T4>.Initer;
            initer4?.Invoke(gameObject, ref local5);

            ComponentDelegates<T5>.InitDelegate initer5 = Component<T5>.Initer;
            initer5?.Invoke(gameObject, ref local6);

            ComponentDelegates<T6>.InitDelegate initer6 = Component<T6>.Initer;
            initer6?.Invoke(gameObject, ref local7);

            ComponentDelegates<T7>.InitDelegate initer7 = Component<T7>.Initer;
            initer7?.Invoke(gameObject, ref local8);

            ComponentDelegates<T8>.InitDelegate initer8 = Component<T8>.Initer;
            initer8?.Invoke(gameObject, ref local9);

            ComponentDelegates<T9>.InitDelegate initer9 = Component<T9>.Initer;
            initer9?.Invoke(gameObject, ref local10);

            ComponentDelegates<T10>.InitDelegate initer10 = Component<T10>.Initer;
            initer10?.Invoke(gameObject, ref local11);

            ComponentDelegates<T11>.InitDelegate initer11 = Component<T11>.Initer;
            initer11?.Invoke(gameObject, ref local12);

            EntityCreatedEvent.Invoke(gameObject);
            return gameObject;
        }

        /// <summary>Creates a large amount of entities quickly</summary>
        /// <param name="count">The number of entities to create</param>
        /// <returns>The entities created and their component spans</returns>
        [SkipLocalsInit]
        public ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> CreateMany<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
            int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("Must create at least 1 entity!");
            }

            Archetype existingArchetype = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.CreateNewOrGetExistingArchetype(this);
            int entityCount = existingArchetype.EntityCount;
            EntityTable.EnsureCapacity(EntityCount + count);
            Span<EntityIdOnly> entityLocations = existingArchetype.CreateEntityLocations(count, this);
            if (EntityCreatedEvent.HasListeners)
            {
                Span<EntityIdOnly> span = entityLocations;
                for (int index = 0; index < span.Length; ++index)
                {
                    EntityCreatedEvent.Invoke(span[index].ToEntity(this));
                }
            }

            ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> many = new ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
            {
                Entities = new EntityEnumerator.EntityEnumerable(this, entityLocations)
            };
            ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> local1 = ref many;
            Span<T1> componentSpan1 = existingArchetype.GetComponentSpan<T1>();
            ref Span<T1> local2 = ref componentSpan1;
            int start1 = entityCount;
            Span<T1> span1 = local2.Slice(start1, local2.Length - start1);
            local1.Span1 = span1;
            ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> local3 = ref many;
            Span<T2> componentSpan2 = existingArchetype.GetComponentSpan<T2>();
            ref Span<T2> local4 = ref componentSpan2;
            int start2 = entityCount;
            Span<T2> span2 = local4.Slice(start2, local4.Length - start2);
            local3.Span2 = span2;
            ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> local5 = ref many;
            Span<T3> componentSpan3 = existingArchetype.GetComponentSpan<T3>();
            ref Span<T3> local6 = ref componentSpan3;
            int start3 = entityCount;
            Span<T3> span3 = local6.Slice(start3, local6.Length - start3);
            local5.Span3 = span3;
            ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> local7 = ref many;
            Span<T4> componentSpan4 = existingArchetype.GetComponentSpan<T4>();
            ref Span<T4> local8 = ref componentSpan4;
            int start4 = entityCount;
            Span<T4> span4 = local8.Slice(start4, local8.Length - start4);
            local7.Span4 = span4;
            ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> local9 = ref many;
            Span<T5> componentSpan5 = existingArchetype.GetComponentSpan<T5>();
            ref Span<T5> local10 = ref componentSpan5;
            int start5 = entityCount;
            Span<T5> span5 = local10.Slice(start5, local10.Length - start5);
            local9.Span5 = span5;
            ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> local11 = ref many;
            Span<T6> componentSpan6 = existingArchetype.GetComponentSpan<T6>();
            ref Span<T6> local12 = ref componentSpan6;
            int start6 = entityCount;
            Span<T6> span6 = local12.Slice(start6, local12.Length - start6);
            local11.Span6 = span6;
            ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> local13 = ref many;
            Span<T7> componentSpan7 = existingArchetype.GetComponentSpan<T7>();
            ref Span<T7> local14 = ref componentSpan7;
            int start7 = entityCount;
            Span<T7> span7 = local14.Slice(start7, local14.Length - start7);
            local13.Span7 = span7;
            ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> local15 = ref many;
            Span<T8> componentSpan8 = existingArchetype.GetComponentSpan<T8>();
            ref Span<T8> local16 = ref componentSpan8;
            int start8 = entityCount;
            Span<T8> span8 = local16.Slice(start8, local16.Length - start8);
            local15.Span8 = span8;
            ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> local17 = ref many;
            Span<T9> componentSpan9 = existingArchetype.GetComponentSpan<T9>();
            ref Span<T9> local18 = ref componentSpan9;
            int start9 = entityCount;
            Span<T9> span9 = local18.Slice(start9, local18.Length - start9);
            local17.Span9 = span9;
            ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> local19 = ref many;
            Span<T10> componentSpan10 = existingArchetype.GetComponentSpan<T10>();
            ref Span<T10> local20 = ref componentSpan10;
            int start10 = entityCount;
            Span<T10> span10 = local20.Slice(start10, local20.Length - start10);
            local19.Span10 = span10;
            ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> local21 = ref many;
            Span<T11> componentSpan11 = existingArchetype.GetComponentSpan<T11>();
            ref Span<T11> local22 = ref componentSpan11;
            int start11 = entityCount;
            Span<T11> span11 = local22.Slice(start11, local22.Length - start11);
            local21.Span11 = span11;
            return many;
        }
    }
}