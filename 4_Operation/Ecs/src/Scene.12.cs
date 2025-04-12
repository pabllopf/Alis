// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Scene.12.cs
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
        public GameObject Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
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
            in T11 comp11,
            in T12 comp12)
        {
            Archetype existingArchetype = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.CreateNewOrGetExistingArchetype(this);

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
            ref T1 local2 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T1>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.OfComponent<T1>.Index))[physicalIndex];
            local2 = comp1;
            ref T2 local3 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T2>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.OfComponent<T2>.Index))[physicalIndex];
            local3 = comp2;
            ref T3 local4 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T3>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.OfComponent<T3>.Index))[physicalIndex];
            local4 = comp3;
            ref T4 local5 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T4>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.OfComponent<T4>.Index))[physicalIndex];
            local5 = comp4;
            ref T5 local6 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T5>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.OfComponent<T5>.Index))[physicalIndex];
            local6 = comp5;
            ref T6 local7 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T6>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.OfComponent<T6>.Index))[physicalIndex];
            local7 = comp6;
            ref T7 local8 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T7>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.OfComponent<T7>.Index))[physicalIndex];
            local8 = comp7;
            ref T8 local9 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T8>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.OfComponent<T8>.Index))[physicalIndex];
            local9 = comp8;
            ref T9 local10 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T9>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.OfComponent<T9>.Index))[physicalIndex];
            local10 = comp9;
            ref T10 local11 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T10>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.OfComponent<T10>.Index))[physicalIndex];
            local11 = comp10;
            ref T11 local12 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T11>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.OfComponent<T11>.Index))[physicalIndex];
            local12 = comp11;
            ref T12 local13 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T12>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.OfComponent<T12>.Index))[physicalIndex];
            local13 = comp12;
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

            ComponentDelegates<T12>.InitDelegate initer12 = Component<T12>.Initer;
            initer12?.Invoke(gameObject, ref local13);

            EntityCreatedEvent.Invoke(gameObject);
            return gameObject;
        }

        [SkipLocalsInit]
        public ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> CreateMany<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(int count)
        {
            if ((uint)count == 0) // Efficient validation for non-positive values
                throw new ArgumentOutOfRangeException(nameof(count));
        
            var archetype = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.CreateNewOrGetExistingArchetype(this);
            int entityCount = archetype.EntityCount;
        
            EntityTable.EnsureCapacity(EntityCount + count);
        
            // Create entity locations directly in a Span
            Span<EntityIdOnly> entityLocations = archetype.CreateEntityLocations(count, this);
        
            // Invoke events if listeners are present
            if (EntityCreatedEvent.HasListeners)
            {
                foreach (ref var entityId in entityLocations)
                {
                    EntityCreatedEvent.Invoke(entityId.ToEntity(this));
                }
            }
        
            // Return the result with calculated spans
            return new ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
            {
                Entities = new EntityEnumerator.EntityEnumerable(this, entityLocations),
                Span1 = archetype.GetComponentSpan<T1>().Slice(entityCount, count),
                Span2 = archetype.GetComponentSpan<T2>().Slice(entityCount, count),
                Span3 = archetype.GetComponentSpan<T3>().Slice(entityCount, count),
                Span4 = archetype.GetComponentSpan<T4>().Slice(entityCount, count),
                Span5 = archetype.GetComponentSpan<T5>().Slice(entityCount, count),
                Span6 = archetype.GetComponentSpan<T6>().Slice(entityCount, count),
                Span7 = archetype.GetComponentSpan<T7>().Slice(entityCount, count),
                Span8 = archetype.GetComponentSpan<T8>().Slice(entityCount, count),
                Span9 = archetype.GetComponentSpan<T9>().Slice(entityCount, count),
                Span10 = archetype.GetComponentSpan<T10>().Slice(entityCount, count),
                Span11 = archetype.GetComponentSpan<T11>().Slice(entityCount, count),
                Span12 = archetype.GetComponentSpan<T12>().Slice(entityCount, count)
            };
        }
    }
}