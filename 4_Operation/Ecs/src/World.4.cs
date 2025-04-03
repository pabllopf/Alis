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
        /// Creates the comp 1
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <param name="comp1">The comp</param>
        /// <param name="comp2">The comp</param>
        /// <param name="comp3">The comp</param>
        /// <param name="comp4">The comp</param>
        /// <returns>The entity</returns>
        [SkipLocalsInit]
        public Entity Create<T1, T2, T3, T4>(in T1 comp1, in T2 comp2, in T3 comp3, in T4 comp4)
        {
            Archetype existingArchetype = Archetype<T1, T2, T3, T4>.CreateNewOrGetExistingArchetype(this);

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
            ref T1 local2 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T1>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4>.OfComponent<T1>.Index))[physicalIndex];
            local2 = comp1;
            ref T2 local3 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T2>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4>.OfComponent<T2>.Index))[physicalIndex];
            local3 = comp2;
            ref T3 local4 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T3>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4>.OfComponent<T3>.Index))[physicalIndex];
            local4 = comp3;
            ref T4 local5 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T4>>(writeStorage.UnsafeArrayIndex(Archetype<T1, T2, T3, T4>.OfComponent<T4>.Index))[physicalIndex];
            local5 = comp4;
            Entity entity = new Entity(this.ID, version, num);
            ComponentDelegates<T1>.InitDelegate initer1 = Component<T1>.Initer;
            initer1?.Invoke(entity, ref local2);

            ComponentDelegates<T2>.InitDelegate initer2 = Component<T2>.Initer;
            initer2?.Invoke(entity, ref local3);

            ComponentDelegates<T3>.InitDelegate initer3 = Component<T3>.Initer;
            initer3?.Invoke(entity, ref local4);

            ComponentDelegates<T4>.InitDelegate initer4 = Component<T4>.Initer;
            initer4?.Invoke(entity, ref local5);

            this.EntityCreatedEvent.Invoke(entity);
            return entity;
        }

        /// <summary>Creates a large amount of entities quickly</summary>
        /// <param name="count">The number of entities to create</param>
        /// <returns>The entities created and their component spans</returns>
        [SkipLocalsInit]
        public ChunkTuple<T1, T2, T3, T4> CreateMany<T1, T2, T3, T4>(int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("Must create at least 1 entity!");
            }

            Archetype existingArchetype = Archetype<T1, T2, T3, T4>.CreateNewOrGetExistingArchetype(this);
            int entityCount = existingArchetype.EntityCount;
            this.EntityTable.EnsureCapacity(this.EntityCount + count);
            Span<EntityIdOnly> entityLocations = existingArchetype.CreateEntityLocations(count, this);
            if (this.EntityCreatedEvent.HasListeners)
            {
                Span<EntityIdOnly> span = entityLocations;
                for (int index = 0; index < span.Length; ++index)
                    this.EntityCreatedEvent.Invoke(span[index].ToEntity(this));
            }

            ChunkTuple<T1, T2, T3, T4> many = new ChunkTuple<T1, T2, T3, T4>
            {
                Entities = new EntityEnumerator.EntityEnumerable(this, entityLocations)
            };
            ref ChunkTuple<T1, T2, T3, T4> local1 = ref many;
            Span<T1> componentSpan1 = existingArchetype.GetComponentSpan<T1>();
            ref Span<T1> local2 = ref componentSpan1;
            int start1 = entityCount;
            Span<T1> span1 = local2.Slice(start1, local2.Length - start1);
            local1.Span1 = span1;
            ref ChunkTuple<T1, T2, T3, T4> local3 = ref many;
            Span<T2> componentSpan2 = existingArchetype.GetComponentSpan<T2>();
            ref Span<T2> local4 = ref componentSpan2;
            int start2 = entityCount;
            Span<T2> span2 = local4.Slice(start2, local4.Length - start2);
            local3.Span2 = span2;
            ref ChunkTuple<T1, T2, T3, T4> local5 = ref many;
            Span<T3> componentSpan3 = existingArchetype.GetComponentSpan<T3>();
            ref Span<T3> local6 = ref componentSpan3;
            int start3 = entityCount;
            Span<T3> span3 = local6.Slice(start3, local6.Length - start3);
            local5.Span3 = span3;
            ref ChunkTuple<T1, T2, T3, T4> local7 = ref many;
            Span<T4> componentSpan4 = existingArchetype.GetComponentSpan<T4>();
            ref Span<T4> local8 = ref componentSpan4;
            int start4 = entityCount;
            Span<T4> span4 = local8.Slice(start4, local8.Length - start4);
            local7.Span4 = span4;
            return many;
        }
    }
}