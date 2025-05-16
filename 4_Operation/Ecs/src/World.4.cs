




using System;
using Alis.Core.Ecs.Core;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Updating;
using Alis.Core.Ecs.Updating.Runners;
using Alis.Variadic.Generator;
using System.Runtime.CompilerServices;
using Alis.Core.Ecs.Core.Archetype;
using Alis.Core.Ecs.Core.Memory;

namespace Alis.Core.Ecs;
//it just so happens Archetype and Create both end with "e"
    partial class World
    {
        /// <summary>
        /// Creates an <see cref="Entity"/> with the given component(s)
        /// </summary>
        /// <returns>An <see cref="Entity"/> that can be used to acsess the component data</returns>
        [SkipLocalsInit]
        public Entity Create<T1, T2, T3, T4>(in T1 comp1, in T2 comp2, in T3 comp3, in T4 comp4)
        {
            var archetypes = Archetype<T1, T2, T3, T4>.CreateNewOrGetExistingArchetypes(this);

            ref var entity = ref Unsafe.NullRef<EntityIDOnly>();
            EntityLocation eloc = default;

            ComponentStorageBase[] components;

            if (AllowStructualChanges)
            {
                components = archetypes.Archetype.Components;
                entity = ref archetypes.Archetype.CreateEntityLocation(EntityFlags.None, out eloc);
            }
            else
            {
                // we don't need to manually set flags, they are already zeroed
                entity = ref archetypes.Archetype.CreateDeferredEntityLocation(this, archetypes.DeferredCreationArchetype, ref eloc, out components);
            }

            //manually inlined from World.CreateEntityFromLocation
            //The jit likes to inline the outer create function and not inline
            //the inner functions - benchmarked to improve perf by 10-20%
            var (id, version) = entity = RecycledEntityIds.CanPop() ? RecycledEntityIds.PopUnsafe() : new(NextEntityID++, 0);
            eloc.Version = version;
            EntityTable[id] = eloc;

            //1x array lookup per component
            ref T1 ref1 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T1>>(components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4>.OfComponent<T1>.Index))[eloc.Index]; ref1 = comp1;
        ref T2 ref2 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T2>>(components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4>.OfComponent<T2>.Index))[eloc.Index]; ref2 = comp2;
        ref T3 ref3 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T3>>(components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4>.OfComponent<T3>.Index))[eloc.Index]; ref3 = comp3;
        ref T4 ref4 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T4>>(components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4>.OfComponent<T4>.Index))[eloc.Index]; ref4 = comp4;


            Entity concreteEntity = new Entity(ID, version, id);
        
            Component<T1>.Initer?.Invoke(concreteEntity, ref ref1);
        Component<T2>.Initer?.Invoke(concreteEntity, ref ref2);
        Component<T3>.Initer?.Invoke(concreteEntity, ref ref3);
        Component<T4>.Initer?.Invoke(concreteEntity, ref ref4);

            EntityCreatedEvent.Invoke(concreteEntity);

            return concreteEntity;
        }

        /// <summary>
        /// Creates a large amount of entities quickly
        /// </summary>
        /// <param name="count">The number of entities to create</param>
        /// <returns>The entities created and their component spans</returns>
        public ChunkTuple<T1, T2, T3, T4> CreateMany<T1, T2, T3, T4>(int count)
        {
            if (count < 0)
                FrentExceptions.Throw_ArgumentOutOfRangeException("Must create at least 1 entity!");
            if (!AllowStructualChanges)
                FrentExceptions.Throw_InvalidOperationException("Cannot bulk create during world updates!");

            var archetypes = Archetype<T1, T2, T3, T4>.CreateNewOrGetExistingArchetypes(this);
            int initalEntityCount = archetypes.Archetype.EntityCount;
        
            EntityTable.EnsureCapacity(EntityCount + count);
        
            Span<EntityIDOnly> entities = archetypes.Archetype.CreateEntityLocations(count, this);
        
            if (EntityCreatedEvent.HasListeners)
            {
                foreach (var entity in entities)
                    EntityCreatedEvent.Invoke(entity.ToEntity(this));
            }
        
            var chunks = new ChunkTuple<T1, T2, T3, T4>()
            {
                Entities = new EntityEnumerator.EntityEnumerable(this, entities),
                Span1 = archetypes.Archetype.GetComponentSpan<T1>()[initalEntityCount..],
            Span2 = archetypes.Archetype.GetComponentSpan<T2>()[initalEntityCount..],
            Span3 = archetypes.Archetype.GetComponentSpan<T3>()[initalEntityCount..],
            Span4 = archetypes.Archetype.GetComponentSpan<T4>()[initalEntityCount..]
            };
        
            return chunks;
        }
    }
