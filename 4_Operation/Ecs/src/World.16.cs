




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
        public Entity Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(in T1 comp1, in T2 comp2, in T3 comp3, in T4 comp4, in T5 comp5, in T6 comp6, in T7 comp7, in T8 comp8, in T9 comp9, in T10 comp10, in T11 comp11, in T12 comp12, in T13 comp13, in T14 comp14, in T15 comp15, in T16 comp16)
        {
            var archetypes = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.CreateNewOrGetExistingArchetypes(this);

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
            ref T1 ref1 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T1>>(components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.OfComponent<T1>.Index))[eloc.Index]; ref1 = comp1;
        ref T2 ref2 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T2>>(components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.OfComponent<T2>.Index))[eloc.Index]; ref2 = comp2;
        ref T3 ref3 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T3>>(components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.OfComponent<T3>.Index))[eloc.Index]; ref3 = comp3;
        ref T4 ref4 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T4>>(components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.OfComponent<T4>.Index))[eloc.Index]; ref4 = comp4;
        ref T5 ref5 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T5>>(components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.OfComponent<T5>.Index))[eloc.Index]; ref5 = comp5;
        ref T6 ref6 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T6>>(components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.OfComponent<T6>.Index))[eloc.Index]; ref6 = comp6;
        ref T7 ref7 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T7>>(components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.OfComponent<T7>.Index))[eloc.Index]; ref7 = comp7;
        ref T8 ref8 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T8>>(components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.OfComponent<T8>.Index))[eloc.Index]; ref8 = comp8;
        ref T9 ref9 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T9>>(components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.OfComponent<T9>.Index))[eloc.Index]; ref9 = comp9;
        ref T10 ref10 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T10>>(components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.OfComponent<T10>.Index))[eloc.Index]; ref10 = comp10;
        ref T11 ref11 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T11>>(components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.OfComponent<T11>.Index))[eloc.Index]; ref11 = comp11;
        ref T12 ref12 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T12>>(components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.OfComponent<T12>.Index))[eloc.Index]; ref12 = comp12;
        ref T13 ref13 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T13>>(components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.OfComponent<T13>.Index))[eloc.Index]; ref13 = comp13;
        ref T14 ref14 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T14>>(components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.OfComponent<T14>.Index))[eloc.Index]; ref14 = comp14;
        ref T15 ref15 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T15>>(components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.OfComponent<T15>.Index))[eloc.Index]; ref15 = comp15;
        ref T16 ref16 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T16>>(components.UnsafeArrayIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.OfComponent<T16>.Index))[eloc.Index]; ref16 = comp16;


            Entity concreteEntity = new Entity(ID, version, id);
        
            Component<T1>.Initer?.Invoke(concreteEntity, ref ref1);
        Component<T2>.Initer?.Invoke(concreteEntity, ref ref2);
        Component<T3>.Initer?.Invoke(concreteEntity, ref ref3);
        Component<T4>.Initer?.Invoke(concreteEntity, ref ref4);
        Component<T5>.Initer?.Invoke(concreteEntity, ref ref5);
        Component<T6>.Initer?.Invoke(concreteEntity, ref ref6);
        Component<T7>.Initer?.Invoke(concreteEntity, ref ref7);
        Component<T8>.Initer?.Invoke(concreteEntity, ref ref8);
        Component<T9>.Initer?.Invoke(concreteEntity, ref ref9);
        Component<T10>.Initer?.Invoke(concreteEntity, ref ref10);
        Component<T11>.Initer?.Invoke(concreteEntity, ref ref11);
        Component<T12>.Initer?.Invoke(concreteEntity, ref ref12);
        Component<T13>.Initer?.Invoke(concreteEntity, ref ref13);
        Component<T14>.Initer?.Invoke(concreteEntity, ref ref14);
        Component<T15>.Initer?.Invoke(concreteEntity, ref ref15);
        Component<T16>.Initer?.Invoke(concreteEntity, ref ref16);

            EntityCreatedEvent.Invoke(concreteEntity);

            return concreteEntity;
        }

        /// <summary>
        /// Creates a large amount of entities quickly
        /// </summary>
        /// <param name="count">The number of entities to create</param>
        /// <returns>The entities created and their component spans</returns>
        public ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> CreateMany<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(int count)
        {
            if (count < 0)
                FrentExceptions.Throw_ArgumentOutOfRangeException("Must create at least 1 entity!");
            if (!AllowStructualChanges)
                FrentExceptions.Throw_InvalidOperationException("Cannot bulk create during world updates!");

            var archetypes = Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.CreateNewOrGetExistingArchetypes(this);
            int initalEntityCount = archetypes.Archetype.EntityCount;
        
            EntityTable.EnsureCapacity(EntityCount + count);
        
            Span<EntityIDOnly> entities = archetypes.Archetype.CreateEntityLocations(count, this);
        
            if (EntityCreatedEvent.HasListeners)
            {
                foreach (var entity in entities)
                    EntityCreatedEvent.Invoke(entity.ToEntity(this));
            }
        
            var chunks = new ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
            {
                Entities = new EntityEnumerator.EntityEnumerable(this, entities),
                Span1 = archetypes.Archetype.GetComponentSpan<T1>()[initalEntityCount..],
            Span2 = archetypes.Archetype.GetComponentSpan<T2>()[initalEntityCount..],
            Span3 = archetypes.Archetype.GetComponentSpan<T3>()[initalEntityCount..],
            Span4 = archetypes.Archetype.GetComponentSpan<T4>()[initalEntityCount..],
            Span5 = archetypes.Archetype.GetComponentSpan<T5>()[initalEntityCount..],
            Span6 = archetypes.Archetype.GetComponentSpan<T6>()[initalEntityCount..],
            Span7 = archetypes.Archetype.GetComponentSpan<T7>()[initalEntityCount..],
            Span8 = archetypes.Archetype.GetComponentSpan<T8>()[initalEntityCount..],
            Span9 = archetypes.Archetype.GetComponentSpan<T9>()[initalEntityCount..],
            Span10 = archetypes.Archetype.GetComponentSpan<T10>()[initalEntityCount..],
            Span11 = archetypes.Archetype.GetComponentSpan<T11>()[initalEntityCount..],
            Span12 = archetypes.Archetype.GetComponentSpan<T12>()[initalEntityCount..],
            Span13 = archetypes.Archetype.GetComponentSpan<T13>()[initalEntityCount..],
            Span14 = archetypes.Archetype.GetComponentSpan<T14>()[initalEntityCount..],
            Span15 = archetypes.Archetype.GetComponentSpan<T15>()[initalEntityCount..],
            Span16 = archetypes.Archetype.GetComponentSpan<T16>()[initalEntityCount..]
            };
        
            return chunks;
        }
    }
