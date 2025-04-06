using System;
using System.Runtime.CompilerServices;
using Alis.Core.Ecs.Arch;
using Alis.Core.Ecs.Memory;
using Alis.Core.Ecs.Operations;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs
{
    
    partial class World
    {
           /// <summary>
        /// Creates an <see cref="T:Alis.Entity" /> with the given component(s)
        /// </summary>
        /// <returns>An <see cref="T:Alis.Entity" /> that can be used to acsess the component data</returns>
        [SkipLocalsInit]
        public Entity Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
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
            in T12 comp12,
            in T13 comp13,
            in T14 comp14)
        {
            Archetype existingArchetype = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.CreateNewOrGetExistingArchetype(this);

            EntityLocation entityLocation = new EntityLocation();
            Unsafe.SkipInit(out int physicalIndex);
            ComponentStorageBase[] writeStorage;

            ref EntityIdOnly local1 = ref Unsafe.NullRef<EntityIdOnly>();
            if (this.AllowStructualChanges)
            {
                writeStorage = existingArchetype.Components;
                local1 = ref existingArchetype.CreateEntityLocation(EntityFlags.None, out entityLocation);
                physicalIndex = entityLocation.Index;
            }
            else
            {
                local1 = ref existingArchetype.CreateDeferredEntityLocation(this, ref entityLocation, out physicalIndex, out writeStorage);
                entityLocation.Archetype = this.DeferredCreateArchetype;
            }

            (int num, ushort version) = local1 = this.RecycledEntityIds.CanPop() ? this.RecycledEntityIds.Pop() : new EntityIdOnly(this.NextEntityID++, 0);
            entityLocation.Version = version;
            this.EntityTable[num] = entityLocation;
            ref T1 local2 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T1>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.OfComponent<T1>.Index))[physicalIndex];
            local2 = comp1;
            ref T2 local3 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T2>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.OfComponent<T2>.Index))[physicalIndex];
            local3 = comp2;
            ref T3 local4 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T3>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.OfComponent<T3>.Index))[physicalIndex];
            local4 = comp3;
            ref T4 local5 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T4>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.OfComponent<T4>.Index))[physicalIndex];
            local5 = comp4;
            ref T5 local6 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T5>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.OfComponent<T5>.Index))[physicalIndex];
            local6 = comp5;
            ref T6 local7 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T6>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.OfComponent<T6>.Index))[physicalIndex];
            local7 = comp6;
            ref T7 local8 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T7>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.OfComponent<T7>.Index))[physicalIndex];
            local8 = comp7;
            ref T8 local9 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T8>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.OfComponent<T8>.Index))[physicalIndex];
            local9 = comp8;
            ref T9 local10 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T9>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.OfComponent<T9>.Index))[physicalIndex];
            local10 = comp9;
            ref T10 local11 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T10>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.OfComponent<T10>.Index))[physicalIndex];
            local11 = comp10;
            ref T11 local12 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T11>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.OfComponent<T11>.Index))[physicalIndex];
            local12 = comp11;
            ref T12 local13 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T12>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.OfComponent<T12>.Index))[physicalIndex];
            local13 = comp12;
            ref T13 local14 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T13>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.OfComponent<T13>.Index))[physicalIndex];
            local14 = comp13;
            ref T14 local15 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T14>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.OfComponent<T14>.Index))[physicalIndex];
            local15 = comp14;
            Entity entity = new Entity(this.ID, version, num);
            ComponentDelegates<T1>.InitDelegate initer1 = Component<T1>.Initer;
            initer1?.Invoke(entity, ref local2);

            ComponentDelegates<T2>.InitDelegate initer2 = Component<T2>.Initer;
            initer2?.Invoke(entity, ref local3);

            ComponentDelegates<T3>.InitDelegate initer3 = Component<T3>.Initer;
            initer3?.Invoke(entity, ref local4);

            ComponentDelegates<T4>.InitDelegate initer4 = Component<T4>.Initer;
            initer4?.Invoke(entity, ref local5);

            ComponentDelegates<T5>.InitDelegate initer5 = Component<T5>.Initer;
            initer5?.Invoke(entity, ref local6);

            ComponentDelegates<T6>.InitDelegate initer6 = Component<T6>.Initer;
            initer6?.Invoke(entity, ref local7);

            ComponentDelegates<T7>.InitDelegate initer7 = Component<T7>.Initer;
            initer7?.Invoke(entity, ref local8);

            ComponentDelegates<T8>.InitDelegate initer8 = Component<T8>.Initer;
            initer8?.Invoke(entity, ref local9);

            ComponentDelegates<T9>.InitDelegate initer9 = Component<T9>.Initer;
            initer9?.Invoke(entity, ref local10);

            ComponentDelegates<T10>.InitDelegate initer10 = Component<T10>.Initer;
            initer10?.Invoke(entity, ref local11);

            ComponentDelegates<T11>.InitDelegate initer11 = Component<T11>.Initer;
            initer11?.Invoke(entity, ref local12);

            ComponentDelegates<T12>.InitDelegate initer12 = Component<T12>.Initer;
            initer12?.Invoke(entity, ref local13);

            ComponentDelegates<T13>.InitDelegate initer13 = Component<T13>.Initer;
            initer13?.Invoke(entity, ref local14);

            ComponentDelegates<T14>.InitDelegate initer14 = Component<T14>.Initer;
            initer14?.Invoke(entity, ref local15);

            this.EntityCreatedEvent.Invoke(entity);
            return entity;
        }

        /// <summary>Creates a large amount of entities quickly</summary>
        /// <param name="count">The number of entities to create</param>
        /// <returns>The entities created and their component spans</returns>
        public ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> CreateMany<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
            int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("Must create at least 1 entity!");
            }

            Archetype existingArchetype = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.CreateNewOrGetExistingArchetype(this);
            int entityCount = existingArchetype.EntityCount;
            this.EntityTable.EnsureCapacity(this.EntityCount + count);
            Span<EntityIdOnly> entityLocations = existingArchetype.CreateEntityLocations(count, this);
            if (this.EntityCreatedEvent.HasListeners)
            {
                Span<EntityIdOnly> span = entityLocations;
                for (int index = 0; index < span.Length; ++index)
                    this.EntityCreatedEvent.Invoke(span[index].ToEntity(this));
            }

            ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> many = new ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
            {
                Entities = new EntityEnumerator.EntityEnumerable(this, entityLocations)
            };
            ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> local1 = ref many;
            Span<T1> componentSpan1 = existingArchetype.GetComponentSpan<T1>();
            ref Span<T1> local2 = ref componentSpan1;
            int start1 = entityCount;
            Span<T1> span1 = local2.Slice(start1, local2.Length - start1);
            local1.Span1 = span1;
            ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> local3 = ref many;
            Span<T2> componentSpan2 = existingArchetype.GetComponentSpan<T2>();
            ref Span<T2> local4 = ref componentSpan2;
            int start2 = entityCount;
            Span<T2> span2 = local4.Slice(start2, local4.Length - start2);
            local3.Span2 = span2;
            ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> local5 = ref many;
            Span<T3> componentSpan3 = existingArchetype.GetComponentSpan<T3>();
            ref Span<T3> local6 = ref componentSpan3;
            int start3 = entityCount;
            Span<T3> span3 = local6.Slice(start3, local6.Length - start3);
            local5.Span3 = span3;
            ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> local7 = ref many;
            Span<T4> componentSpan4 = existingArchetype.GetComponentSpan<T4>();
            ref Span<T4> local8 = ref componentSpan4;
            int start4 = entityCount;
            Span<T4> span4 = local8.Slice(start4, local8.Length - start4);
            local7.Span4 = span4;
            ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> local9 = ref many;
            Span<T5> componentSpan5 = existingArchetype.GetComponentSpan<T5>();
            ref Span<T5> local10 = ref componentSpan5;
            int start5 = entityCount;
            Span<T5> span5 = local10.Slice(start5, local10.Length - start5);
            local9.Span5 = span5;
            ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> local11 = ref many;
            Span<T6> componentSpan6 = existingArchetype.GetComponentSpan<T6>();
            ref Span<T6> local12 = ref componentSpan6;
            int start6 = entityCount;
            Span<T6> span6 = local12.Slice(start6, local12.Length - start6);
            local11.Span6 = span6;
            ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> local13 = ref many;
            Span<T7> componentSpan7 = existingArchetype.GetComponentSpan<T7>();
            ref Span<T7> local14 = ref componentSpan7;
            int start7 = entityCount;
            Span<T7> span7 = local14.Slice(start7, local14.Length - start7);
            local13.Span7 = span7;
            ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> local15 = ref many;
            Span<T8> componentSpan8 = existingArchetype.GetComponentSpan<T8>();
            ref Span<T8> local16 = ref componentSpan8;
            int start8 = entityCount;
            Span<T8> span8 = local16.Slice(start8, local16.Length - start8);
            local15.Span8 = span8;
            ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> local17 = ref many;
            Span<T9> componentSpan9 = existingArchetype.GetComponentSpan<T9>();
            ref Span<T9> local18 = ref componentSpan9;
            int start9 = entityCount;
            Span<T9> span9 = local18.Slice(start9, local18.Length - start9);
            local17.Span9 = span9;
            ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> local19 = ref many;
            Span<T10> componentSpan10 = existingArchetype.GetComponentSpan<T10>();
            ref Span<T10> local20 = ref componentSpan10;
            int start10 = entityCount;
            Span<T10> span10 = local20.Slice(start10, local20.Length - start10);
            local19.Span10 = span10;
            ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> local21 = ref many;
            Span<T11> componentSpan11 = existingArchetype.GetComponentSpan<T11>();
            ref Span<T11> local22 = ref componentSpan11;
            int start11 = entityCount;
            Span<T11> span11 = local22.Slice(start11, local22.Length - start11);
            local21.Span11 = span11;
            ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> local23 = ref many;
            Span<T12> componentSpan12 = existingArchetype.GetComponentSpan<T12>();
            ref Span<T12> local24 = ref componentSpan12;
            int start12 = entityCount;
            Span<T12> span12 = local24.Slice(start12, local24.Length - start12);
            local23.Span12 = span12;
            ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> local25 = ref many;
            Span<T13> componentSpan13 = existingArchetype.GetComponentSpan<T13>();
            ref Span<T13> local26 = ref componentSpan13;
            int start13 = entityCount;
            Span<T13> span13 = local26.Slice(start13, local26.Length - start13);
            local25.Span13 = span13;
            ref ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> local27 = ref many;
            Span<T14> componentSpan14 = existingArchetype.GetComponentSpan<T14>();
            ref Span<T14> local28 = ref componentSpan14;
            int start14 = entityCount;
            Span<T14> span14 = local28.Slice(start14, local28.Length - start14);
            local27.Span14 = span14;
            return many;
        }
    }
}