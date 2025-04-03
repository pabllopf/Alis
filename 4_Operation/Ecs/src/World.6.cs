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
        public Entity Create<T1, T2, T3, T4, T5, T6>(
            in T1 comp1,
            in T2 comp2,
            in T3 comp3,
            in T4 comp4,
            in T5 comp5,
            in T6 comp6)
        {
            Archetype existingArchetype = Archetype<T1, T2, T3, T4, T5, T6>.CreateNewOrGetExistingArchetype(this);

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
            ref T1 local2 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T1>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6>.OfComponent<T1>.Index))[physicalIndex];
            local2 = comp1;
            ref T2 local3 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T2>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6>.OfComponent<T2>.Index))[physicalIndex];
            local3 = comp2;
            ref T3 local4 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T3>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6>.OfComponent<T3>.Index))[physicalIndex];
            local4 = comp3;
            ref T4 local5 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T4>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6>.OfComponent<T4>.Index))[physicalIndex];
            local5 = comp4;
            ref T5 local6 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T5>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6>.OfComponent<T5>.Index))[physicalIndex];
            local6 = comp5;
            ref T6 local7 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T6>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6>.OfComponent<T6>.Index))[physicalIndex];
            local7 = comp6;
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

            this.EntityCreatedEvent.Invoke(entity);
            return entity;
        }

        /// <summary>Creates a large amount of entities quickly</summary>
        /// <param name="count">The number of entities to create</param>
        /// <returns>The entities created and their component spans</returns>
        [SkipLocalsInit]
        public ChunkTuple<T1, T2, T3, T4, T5, T6> CreateMany<T1, T2, T3, T4, T5, T6>(int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("Must create at least 1 entity!");
            }

            Archetype existingArchetype = Archetype<T1, T2, T3, T4, T5, T6>.CreateNewOrGetExistingArchetype(this);
            int entityCount = existingArchetype.EntityCount;
            this.EntityTable.EnsureCapacity(this.EntityCount + count);
            Span<EntityIdOnly> entityLocations = existingArchetype.CreateEntityLocations(count, this);
            if (this.EntityCreatedEvent.HasListeners)
            {
                Span<EntityIdOnly> span = entityLocations;
                for (int index = 0; index < span.Length; ++index)
                    this.EntityCreatedEvent.Invoke(span[index].ToEntity(this));
            }

            ChunkTuple<T1, T2, T3, T4, T5, T6> many = new ChunkTuple<T1, T2, T3, T4, T5, T6>
            {
                Entities = new EntityEnumerator.EntityEnumerable(this, entityLocations)
            };
            ref ChunkTuple<T1, T2, T3, T4, T5, T6> local1 = ref many;
            Span<T1> componentSpan1 = existingArchetype.GetComponentSpan<T1>();
            ref Span<T1> local2 = ref componentSpan1;
            int start1 = entityCount;
            Span<T1> span1 = local2.Slice(start1, local2.Length - start1);
            local1.Span1 = span1;
            ref ChunkTuple<T1, T2, T3, T4, T5, T6> local3 = ref many;
            Span<T2> componentSpan2 = existingArchetype.GetComponentSpan<T2>();
            ref Span<T2> local4 = ref componentSpan2;
            int start2 = entityCount;
            Span<T2> span2 = local4.Slice(start2, local4.Length - start2);
            local3.Span2 = span2;
            ref ChunkTuple<T1, T2, T3, T4, T5, T6> local5 = ref many;
            Span<T3> componentSpan3 = existingArchetype.GetComponentSpan<T3>();
            ref Span<T3> local6 = ref componentSpan3;
            int start3 = entityCount;
            Span<T3> span3 = local6.Slice(start3, local6.Length - start3);
            local5.Span3 = span3;
            ref ChunkTuple<T1, T2, T3, T4, T5, T6> local7 = ref many;
            Span<T4> componentSpan4 = existingArchetype.GetComponentSpan<T4>();
            ref Span<T4> local8 = ref componentSpan4;
            int start4 = entityCount;
            Span<T4> span4 = local8.Slice(start4, local8.Length - start4);
            local7.Span4 = span4;
            ref ChunkTuple<T1, T2, T3, T4, T5, T6> local9 = ref many;
            Span<T5> componentSpan5 = existingArchetype.GetComponentSpan<T5>();
            ref Span<T5> local10 = ref componentSpan5;
            int start5 = entityCount;
            Span<T5> span5 = local10.Slice(start5, local10.Length - start5);
            local9.Span5 = span5;
            ref ChunkTuple<T1, T2, T3, T4, T5, T6> local11 = ref many;
            Span<T6> componentSpan6 = existingArchetype.GetComponentSpan<T6>();
            ref Span<T6> local12 = ref componentSpan6;
            int start6 = entityCount;
            Span<T6> span6 = local12.Slice(start6, local12.Length - start6);
            local11.Span6 = span6;
            return many;
        }
    }
}