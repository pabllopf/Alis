using System;
using Frent.Core;
using Frent.Core.Structures;
using Frent.Updating;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Frent.Core.Events;

namespace Frent
{
    /// <summary>
    /// The world class
    /// </summary>
    partial class World
    {
        /*
         *  This file contains all core functions related to structual changes on the world
         *  The only core structual change function not here is the normal create function, since it needs to be source generated
         *  These functions take all the data it needs, with no validation that an entity is alive
         */

        /// <summary>
        /// Removes the component using the specified entity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <param name="lookup">The lookup</param>
        /// <param name="componentID">The component id</param>
        internal void RemoveComponent(Entity entity, ref EntityLocation lookup, ComponentID componentID)
        {
            Archetype destination = RemoveComponentLookup.FindAdjacentArchetypeID(componentID, lookup.ArchetypeID, this, ArchetypeEdgeType.RemoveComponent)
                .Archetype(this);
        
            Span<ComponentHandle> tmpHandleSpan = [default!];
            MoveEntityToArchetypeRemove(tmpHandleSpan, entity, ref lookup, destination);

        }

        /// <summary>
        /// Adds the component using the specified entity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <param name="lookup">The lookup</param>
        /// <param name="componentID">The component id</param>
        /// <param name="runner">The runner</param>
        /// <param name="entityLocation">The entity location</param>
        internal void AddComponent(Entity entity, ref EntityLocation lookup, ComponentID componentID, ref ComponentStorageBase runner, out EntityLocation entityLocation)
        {
            Archetype destination = AddComponentLookup.FindAdjacentArchetypeID(componentID, lookup.ArchetypeID, this, ArchetypeEdgeType.AddComponent)
                .Archetype(this);
            Span<ComponentStorageBase> runnerSpan = [null!];
            MoveEntityToArchetypeAdd(runnerSpan, entity, ref lookup, out entityLocation, destination);
            runner = MemoryMarshal.GetReference(runnerSpan);

        }

        /// <summary>
        /// Moves the entity to archetype add using the specified write to
        /// </summary>
        /// <param name="writeTo">The write to</param>
        /// <param name="entity">The entity</param>
        /// <param name="currentLookup">The current lookup</param>
        /// <param name="nextLocation">The next location</param>
        /// <param name="destination">The destination</param>
        [Frent.SkipLocalsInit]
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

            EntityTable.UnsafeIndexNoResize(movedDown.ID) = currentLookup;
            currentLookup = nextLocation;
        }

        /// <summary>
        /// Moves the entity to archetype remove using the specified component handles
        /// </summary>
        /// <param name="componentHandles">The component handles</param>
        /// <param name="entity">The entity</param>
        /// <param name="currentLookup">The current lookup</param>
        /// <param name="destination">The destination</param>
        [Frent.SkipLocalsInit]
        internal void MoveEntityToArchetypeRemove(Span<ComponentHandle> componentHandles, Entity entity, ref EntityLocation currentLookup, Archetype destination)
        {
            Archetype from = currentLookup.Archetype;

            Debug.Assert(from.Components.Length > destination.Components.Length);

            destination.CreateEntityLocation(currentLookup.Flags, out EntityLocation nextLocation).Init(entity);
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
                    ComponentStorageBase? runner = fromRunners.UnsafeArrayIndex(i);
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

            EntityTable.UnsafeIndexNoResize(movedDown.ID) = currentLookup;
            currentLookup = nextLocation;

            if (EntityLocation.HasEventFlag(currentLookup.Flags | WorldEventFlags, EntityFlags.RemoveComp | EntityFlags.RemoveGenericComp))
            {
                if (ComponentRemovedEvent.HasListeners)
                {
                    foreach (ComponentHandle handle in componentHandles)
                        ComponentRemovedEvent.Invoke(entity, handle.ComponentID);
                }

                if (EntityLocation.HasEventFlag(currentLookup.Flags, EntityFlags.RemoveComp | EntityFlags.RemoveGenericComp))
                {

                    EventRecord? lookup = EventLookup[entity.EntityIDOnly];


                    if (hasGenericRemoveEvent)
                    {
                        foreach (ComponentHandle handle in componentHandles)
                        {
                            lookup.Remove.NormalEvent.Invoke(entity, handle.ComponentID);
                            handle.InvokeComponentEventAndConsume(entity, lookup.Remove.GenericEvent);
                        }
                    }
                    else
                    {
                        //no need to dispose here, as they were never created
                        foreach (ComponentHandle handle in componentHandles)
                        {
                            lookup.Remove.NormalEvent.Invoke(entity, handle.ComponentID);
                        }
                    }
                }

            }
        }

        /// <summary>
        /// Moves the entity to archetype iso using the specified entity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <param name="currentLookup">The current lookup</param>
        /// <param name="destination">The destination</param>
        [Frent.SkipLocalsInit]
        internal void MoveEntityToArchetypeIso(Entity entity, ref EntityLocation currentLookup, Archetype destination)
        {
            Archetype from = currentLookup.Archetype;

            Debug.Assert(from.Components.Length == destination.Components.Length);

            destination.CreateEntityLocation(currentLookup.Flags, out EntityLocation nextLocation).Init(entity);
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

            EntityTable.UnsafeIndexNoResize(movedDown.ID) = currentLookup;
            currentLookup = nextLocation;
        }

        
        //Delete
        /// <summary>
        /// Deletes the entity using the specified entity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <param name="entityLocation">The entity location</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void DeleteEntity(Entity entity, ref EntityLocation entityLocation)
        {
            EntityFlags check = entityLocation.Flags | WorldEventFlags;
            if ((check & EntityFlags.Events) != 0)
                InvokeDeleteEvents(entity, entityLocation);
            DeleteEntityWithoutEvents(entity, ref entityLocation);
        }

        //let the jit decide whether or not to inline
        /// <summary>
        /// Invokes the delete events using the specified entity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <param name="entityLocation">The entity location</param>
        private void InvokeDeleteEvents(Entity entity, EntityLocation entityLocation)
        {
            EntityDeletedEvent.Invoke(entity);
            if (entityLocation.HasEvent(EntityFlags.OnDelete))
            {
                foreach (Action<Entity>? @event in EventLookup[entity.EntityIDOnly].Delete.AsSpan())
                {
                    @event.Invoke(entity);
                }
            }
            EventLookup.Remove(entity.EntityIDOnly);
        }

        /// <summary>
        /// Deletes the entity without events using the specified entity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <param name="currentLookup">The current lookup</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void DeleteEntityWithoutEvents(Entity entity, ref EntityLocation currentLookup)
        {
            //entity is guaranteed to be alive here
            EntityIDOnly replacedEntity = currentLookup.Archetype.DeleteEntity(currentLookup.Index);

            Debug.Assert(replacedEntity.ID < EntityTable._buffer.Length);
            Debug.Assert(entity.EntityID < EntityTable._buffer.Length);

            ref EntityLocation replaced = ref EntityTable.UnsafeIndexNoResize(replacedEntity.ID);
            replaced = currentLookup;
            replaced.Version = replacedEntity.Version;
            currentLookup.Version = ushort.MaxValue;

            if (entity.EntityVersion != ushort.MaxValue - 1)
            {
                //can't use max value as an ID, as it is used as a default value
                ref EntityIDOnly id = ref RecycledEntityIds.Push();
                id = entity.EntityIDOnly;
                id.Version++;
            }
        }
        
    }
}