using System;
using Alis.Core.Ecs.Core;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Updating;
using Alis.Core.Ecs.Updating.Runners;
using Alis.Variadic.Generator;
using System.Runtime.CompilerServices;
using Alis.Core.Ecs.Core.Archetype;
using Alis.Core.Ecs.Core.Memory;

namespace Alis.Core.Ecs
{
    [Variadic("        ref T ref1 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T>>(components.UnsafeArrayIndex(Archetype<T>.OfComponent<T>.Index))[eloc.Index]; ref1 = comp;",
        "|        ref T$ ref$ = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T$>>(components.UnsafeArrayIndex(Archetype<T>.OfComponent<T$>.Index))[eloc.Index]; ref$ = comp$;\n|")]
    [Variadic("        Component<T>.Initer?.Invoke(concreteEntity, ref ref1);",
        "|        Component<T$>.Initer?.Invoke(concreteEntity, ref ref$);\n|")]
    
    
    
    
//it just so happens Archetype and Create both end with "e"
    partial class World
    {
        /// <summary>
        /// Creates an <see cref="Entity"/> with the given component(s)
        /// </summary>
        /// <returns>An <see cref="Entity"/> that can be used to acsess the component data</returns>
        [SkipLocalsInit]
        public Entity Create<T>(in T comp)
        {
            var archetypes = Archetype<T>.CreateNewOrGetExistingArchetypes(this);

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
            ref T ref1 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T>>(components.UnsafeArrayIndex(Archetype<T>.OfComponent<T>.Index))[eloc.Index]; ref1 = comp;

            Entity concreteEntity = new Entity(ID, version, id);
        
            Component<T>.Initer?.Invoke(concreteEntity, ref ref1);
            EntityCreatedEvent.Invoke(concreteEntity);

            return concreteEntity;
        }

        /// <summary>
        /// Creates a large amount of entities quickly
        /// </summary>
        /// <param name="count">The number of entities to create</param>
        /// <returns>The entities created and their component spans</returns>
        public ChunkTuple<T> CreateMany<T>(int count)
        {
            if (count < 0)
                FrentExceptions.Throw_ArgumentOutOfRangeException("Must create at least 1 entity!");
            if (!AllowStructualChanges)
                FrentExceptions.Throw_InvalidOperationException("Cannot bulk create during world updates!");

            var archetypes = Archetype<T>.CreateNewOrGetExistingArchetypes(this);
            int initalEntityCount = archetypes.Archetype.EntityCount;
        
            EntityTable.EnsureCapacity(EntityCount + count);
        
            Span<EntityIDOnly> entities = archetypes.Archetype.CreateEntityLocations(count, this);
        
            if (EntityCreatedEvent.HasListeners)
            {
                foreach (var entity in entities)
                    EntityCreatedEvent.Invoke(entity.ToEntity(this));
            }
        
            var chunks = new ChunkTuple<T>()
            {
                Entities = new EntityEnumerator.EntityEnumerable(this, entities),
                Span = archetypes.Archetype.GetComponentSpan<T>()[initalEntityCount..],
            };
        
            return chunks;
        }
    }
}