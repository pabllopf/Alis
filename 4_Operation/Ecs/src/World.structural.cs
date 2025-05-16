﻿using System;
using Alis.Core.Ecs.Core;
using Alis.Core.Ecs.Updating;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Core.Archetype;
using Alis.Core.Ecs.Core.Memory;

namespace Alis.Core.Ecs
{
    partial class World
    {
        /*
         *  This file contains all core functions related to structual changes on the world
         *  The only core structual change function not here is the normal create function, since it needs to be source generated
         *  These functions take all the data it needs, with no validation that an entity is alive
         */

        internal void RemoveComponent(Entity entity, ref EntityLocation lookup, ComponentID componentID)
        {
            Archetype destination = RemoveComponentLookup.FindAdjacentArchetypeID(componentID, lookup.ArchetypeID, this, ArchetypeEdgeType.RemoveComponent)
                .Archetype(this);

#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
        //array is allocated
        //Span<ComponentHandle> tmpHandleSpan = [default!];
        MoveEntityToArchetypeRemove(MemoryHelpers.SharedTempComponentHandleBuffer.AsSpan(0, 1), entity, ref lookup, destination);
#else
            Unsafe.SkipInit(out ComponentHandle tmpHandle);
            MemoryHelpers.Poison(ref tmpHandle);
            MoveEntityToArchetypeRemove(MemoryMarshal.CreateSpan(ref tmpHandle, 1), entity, ref lookup, destination);
#endif
        }

        internal void AddComponent(Entity entity, ref EntityLocation lookup, ComponentID componentID, ref ComponentStorageBase runner, out EntityLocation entityLocation)
        {
            Archetype destination = AddComponentLookup.FindAdjacentArchetypeID(componentID, lookup.ArchetypeID, this, ArchetypeEdgeType.AddComponent)
                .Archetype(this);
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
        MoveEntityToArchetypeAdd(MemoryHelpers.SharedTempComponentStorageBuffer.AsSpan(0, 1), entity, ref lookup, out entityLocation, destination);
        runner = MemoryHelpers.SharedTempComponentStorageBuffer[0];
#else
            MoveEntityToArchetypeAdd(MemoryMarshal.CreateSpan(ref runner, 1), entity, ref lookup, out entityLocation, destination);
#endif
        }

        [SkipLocalsInit]
        internal void MoveEntityToArchetypeAdd(Span<ComponentStorageBase> writeTo, Entity entity, ref EntityLocation currentLookup, out EntityLocation nextLocation, Archetype destination)
        {
            Archetype from = currentLookup.Archetype;

            Debug.Assert(from.Components.Length < destination.Components.Length);

            destination.CreateEntityLocation(currentLookup.Flags, out nextLocation).Init(entity);
            nextLocation.Version = currentLookup.Version;

            EntityIDOnly movedDown = from.DeleteEntityFromStorage(currentLookup.Index, out int deletedIndex);

            ComponentStorageBase[] fromRunners = from.Components;
            ComponentStorageBase[] destRunners = destination.Components;
            byte[] fromMap = from.ComponentTagTable;

            ImmutableArray<ComponentID> destinationComponents = destination.ArchetypeTypeArray;

            int writeToIndex = 0;
            for (int i = 0; i < destinationComponents.Length;)
            {
                ComponentID componentToMove = destinationComponents[i];
                int fromIndex = fromMap.UnsafeArrayIndex(componentToMove.RawIndex) & GlobalWorldTables.IndexBits;

                //index for dest is offset by one for hardware trap
                i++;

                if (fromIndex == 0)
                {
                    writeTo.UnsafeSpanIndex(writeToIndex++) = destRunners[i];
                }
                else
                {
                    destRunners.UnsafeArrayIndex(i).PullComponentFromAndClearTryDevirt(fromRunners.UnsafeArrayIndex(fromIndex), nextLocation.Index, currentLookup.Index, deletedIndex);
                }
            }

            ref var displacedEntityLocation = ref EntityTable.UnsafeIndexNoResize(movedDown.ID);
            displacedEntityLocation.Archetype = currentLookup.Archetype;
            displacedEntityLocation.Index = currentLookup.Index;

            currentLookup.Archetype = nextLocation.Archetype;
            currentLookup.Index = nextLocation.Index;
        }

        [SkipLocalsInit]
        internal void MoveEntityToArchetypeRemove(Span<ComponentHandle> componentHandles, Entity entity, ref EntityLocation currentLookup, Archetype destination)
        {
            //NOTE: when moving EntityLocation between archetypes, version and flags cannot change
            Archetype from = currentLookup.Archetype;

            Debug.Assert(from.Components.Length > destination.Components.Length);

            destination.CreateEntityLocation(currentLookup.Flags, out var nextLocation).Init(entity);
            nextLocation.Version = currentLookup.Version;

            EntityIDOnly movedDown = from.DeleteEntityFromStorage(currentLookup.Index, out int deletedIndex);

            ComponentStorageBase[] fromRunners = from.Components;
            ComponentStorageBase[] destRunners = destination.Components;
            byte[] destMap = destination.ComponentTagTable;

            ImmutableArray<ComponentID> fromComponents = from.ArchetypeTypeArray;

            bool hasGenericRemoveEvent = EntityLocation.HasEventFlag(currentLookup.Flags, EntityFlags.RemoveGenericComp);

            int writeToIndex = 0;

            DeleteComponentData deleteData = new DeleteComponentData(currentLookup.Index, deletedIndex);

            for (int i = 0; i < fromComponents.Length;)
            {
                ComponentID componentToMoveFromFromToTo = fromComponents[i];
                int toIndex = destMap.UnsafeArrayIndex(componentToMoveFromFromToTo.RawIndex);

                i++;

                if (toIndex == 0)
                {
                    var runner = fromRunners.UnsafeArrayIndex(i);
                    ref ComponentHandle writeTo = ref componentHandles.UnsafeSpanIndex(writeToIndex++);
                    if (hasGenericRemoveEvent)
                        writeTo = runner.Store(currentLookup.Index);
                    else//kinda illegal but whatever
                        writeTo = new ComponentHandle(0, componentToMoveFromFromToTo);
                    runner.Delete(deleteData);
                }
                else
                {
                    destRunners.UnsafeArrayIndex(toIndex).PullComponentFromAndClearTryDevirt(fromRunners.UnsafeArrayIndex(i), nextLocation.Index, currentLookup.Index, deletedIndex);
                }
            }

            //copy everything but 
            ref var displacedEntityLocation = ref EntityTable.UnsafeIndexNoResize(movedDown.ID);
            displacedEntityLocation.Archetype = currentLookup.Archetype;
            displacedEntityLocation.Index = currentLookup.Index;

            currentLookup.Archetype = nextLocation.Archetype;
            currentLookup.Index = nextLocation.Index;

            if (EntityLocation.HasEventFlag(currentLookup.Flags | WorldEventFlags, EntityFlags.RemoveComp | EntityFlags.RemoveGenericComp))
            {
                if (ComponentRemovedEvent.HasListeners)
                {
                    foreach (var handle in componentHandles)
                        ComponentRemovedEvent.Invoke(entity, handle.ComponentID);
                }

                if (EntityLocation.HasEventFlag(currentLookup.Flags, EntityFlags.RemoveComp | EntityFlags.RemoveGenericComp))
                {
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
                var lookup = EventLookup[entity.EntityIDOnly];
#else
                    ref var lookup = ref CollectionsMarshal.GetValueRefOrNullRef(EventLookup, entity.EntityIDOnly);
#endif

                    if (hasGenericRemoveEvent)
                    {
                        foreach (var handle in componentHandles)
                        {
                            lookup.Remove.NormalEvent.Invoke(entity, handle.ComponentID);
                            handle.InvokeComponentEventAndConsume(entity, lookup.Remove.GenericEvent);
                        }
                    }
                    else
                    {
                        //no need to dispose here, as they were never created
                        foreach (var handle in componentHandles)
                        {
                            lookup.Remove.NormalEvent.Invoke(entity, handle.ComponentID);
                        }
                    }
                }

            }
        }

        [SkipLocalsInit]
        internal void MoveEntityToArchetypeIso(Entity entity, ref EntityLocation currentLookup, Archetype destination)
        {
            Archetype from = currentLookup.Archetype;

            Debug.Assert(from.Components.Length == destination.Components.Length);

            destination.CreateEntityLocation(currentLookup.Flags, out var nextLocation).Init(entity);
            nextLocation.Version = currentLookup.Version;

            EntityIDOnly movedDown = from.DeleteEntityFromStorage(currentLookup.Index, out int deletedIndex);


            ComponentStorageBase[] fromRunners = from.Components;
            ComponentStorageBase[] destRunners = destination.Components;
            byte[] destMap = destination.ComponentTagTable;

            ImmutableArray<ComponentID> fromComponents = from.ArchetypeTypeArray;

            for (int i = 0; i < fromComponents.Length;)
            {
                int toIndex = destMap.UnsafeArrayIndex(fromComponents[i].RawIndex) & GlobalWorldTables.IndexBits;

                i++;

                destRunners[toIndex].PullComponentFromAndClearTryDevirt(fromRunners[i], nextLocation.Index, currentLookup.Index, deletedIndex);
            }

            ref var displacedEntityLocation = ref EntityTable.UnsafeIndexNoResize(movedDown.ID);
            displacedEntityLocation.Archetype = currentLookup.Archetype;
            displacedEntityLocation.Index = currentLookup.Index;

            currentLookup.Archetype = nextLocation.Archetype;
            currentLookup.Index = nextLocation.Index;
        }

        #region Delete
        //Delete
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void DeleteEntity(Entity entity, ref EntityLocation entityLocation)
        {
            EntityFlags check = entityLocation.Flags | WorldEventFlags;
            if ((check & EntityFlags.Events) != 0)
                InvokeDeleteEvents(entity, entityLocation);
            DeleteEntityWithoutEvents(entity, ref entityLocation);
        }

        //let the jit decide whether or not to inline
        private void InvokeDeleteEvents(Entity entity, EntityLocation entityLocation)
        {
            EntityDeletedEvent.Invoke(entity);
            if (entityLocation.HasEvent(EntityFlags.OnDelete))
            {
                foreach (var @event in EventLookup[entity.EntityIDOnly].Delete.AsSpan())
                {
                    @event.Invoke(entity);
                }
            }
            EventLookup.Remove(entity.EntityIDOnly);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void DeleteEntityWithoutEvents(Entity entity, ref EntityLocation currentLookup)
        {
            //entity is guaranteed to be alive here
            EntityIDOnly replacedEntity = currentLookup.Archetype.DeleteEntity(currentLookup.Index);

            Debug.Assert(replacedEntity.ID < EntityTable._buffer.Length);
            Debug.Assert(entity.EntityID < EntityTable._buffer.Length);

            ref var replaced = ref EntityTable.UnsafeIndexNoResize(replacedEntity.ID);
            replaced = currentLookup;
            replaced.Version = replacedEntity.Version;
            currentLookup.Version = ushort.MaxValue;

            if (entity.EntityVersion != ushort.MaxValue - 1)
            {
                //can't use max value as an ID, as it is used as a default value
                ref var id = ref RecycledEntityIds.Push();
                id = entity.EntityIDOnly;
                id.Version++;
            }
        }
        #endregion
    }
}