using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetype;
using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Redifinition;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The scene class
    /// </summary>
    partial class Scene
    {
        /*
         *  This file contains all core functions related to structual changes on the scene
         *  The only core structual change function not here is the normal create function, since it needs to be source generated
         *  These functions take all the data it needs, with no validation that an gameObject is alive
         */

        /// <summary>
        ///     Removes the component using the specified gameObject
        /// </summary>
        /// <param name="gameObject">The gameObject</param>
        /// <param name="lookup">The lookup</param>
        /// <param name="componentId">The component id</param>
        internal void RemoveComponent(GameObject gameObject, ref GameObjectLocation lookup, ComponentId componentId)
        {
            Archetype destination = RemoveComponentLookup
                .FindAdjacentArchetypeId(componentId, lookup.ArchetypeId, this, ArchetypeEdgeType.RemoveComponent)
                .Archetype(this);

#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
        //array is allocated
        //Span<ComponentHandle> tmpHandleSpan = [default!];
        MoveEntityToArchetypeRemove(MemoryHelpers.SharedTempComponentHandleBuffer.AsSpan(0, 1), gameObject, ref lookup,
            destination);
#else
            Unsafe.SkipInit(out ComponentHandle tmpHandle);
            MemoryHelpers.Poison(ref tmpHandle);
            MoveEntityToArchetypeRemove(System.Runtime.InteropServices.MemoryMarshal.CreateSpan(ref tmpHandle, 1), gameObject, ref lookup, destination);
#endif
        }

        /// <summary>
        ///     Adds the component using the specified gameObject
        /// </summary>
        /// <param name="gameObject">The gameObject</param>
        /// <param name="lookup">The lookup</param>
        /// <param name="componentId">The component id</param>
        /// <param name="runner">The runner</param>
        /// <param name="gameObjectLocation">The gameObject location</param>
        internal void AddComponent(GameObject gameObject, ref GameObjectLocation lookup, ComponentId componentId,
            ref ComponentStorageBase runner, out GameObjectLocation gameObjectLocation)
        {
            Archetype destination = AddComponentLookup
                .FindAdjacentArchetypeId(componentId, lookup.ArchetypeId, this, ArchetypeEdgeType.AddComponent)
                .Archetype(this);
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
        MoveEntityToArchetypeAdd(MemoryHelpers.SharedTempComponentStorageBuffer.AsSpan(0, 1), gameObject, ref lookup,
            out gameObjectLocation, destination);
        runner = MemoryHelpers.SharedTempComponentStorageBuffer[0];
#else
            MoveEntityToArchetypeAdd(System.Runtime.InteropServices.MemoryMarshal.CreateSpan(ref runner, 1), gameObject, ref lookup, out gameObjectLocation, destination);
#endif
        }

        /// <summary>
        ///     Moves the gameObject to archetype add using the specified write to
        /// </summary>
        /// <param name="writeTo">The write to</param>
        /// <param name="gameObject">The gameObject</param>
        /// <param name="currentLookup">The current lookup</param>
        /// <param name="nextLocation">The next location</param>
        /// <param name="destination">The destination</param>
        internal void MoveEntityToArchetypeAdd(Span<ComponentStorageBase> writeTo, GameObject gameObject,
            ref GameObjectLocation currentLookup, out GameObjectLocation nextLocation, Archetype destination)
        {
            Archetype from = currentLookup.Archetype;

            destination.CreateEntityLocation(currentLookup.Flags, out nextLocation).Init(gameObject);
            nextLocation.Version = currentLookup.Version;

            GameObjectIdOnly movedDown = from.DeleteEntityFromStorage(currentLookup.Index, out int deletedIndex);

            ComponentStorageBase[] fromRunners = from.Components;
            ComponentStorageBase[] destRunners = destination.Components;
            byte[] fromMap = from.ComponentTagTable;

            FastImmutableArray<ComponentId> destinationComponents = destination.ArchetypeTypeArray;

            int writeToIndex = 0;
            for (int i = 0; i < destinationComponents.Length;)
            {
                ComponentId componentToMove = destinationComponents[i];
                int fromIndex = Unsafe.Add(ref fromMap[0], componentToMove.RawIndex) & GlobalWorldTables.IndexBits;

                //index for dest is offset by one for hardware trap
                i++;

                if (fromIndex == 0)
                    Unsafe.Add(ref MemoryMarshal.GetReference(writeTo), writeToIndex++) = destRunners[i];
                else
                    Unsafe.Add(ref destRunners[0], i).PullComponentFromAndClearTryDevirt(
                        Unsafe.Add(ref fromRunners[0], fromIndex), nextLocation.Index, currentLookup.Index, deletedIndex);
                
            }

            ref GameObjectLocation displacedGameObjectLocation = ref EntityTable.UnsafeIndexNoResize(movedDown.ID);
            displacedGameObjectLocation.Archetype = currentLookup.Archetype;
            displacedGameObjectLocation.Index = currentLookup.Index;

            currentLookup.Archetype = nextLocation.Archetype;
            currentLookup.Index = nextLocation.Index;
        }

        /// <summary>
        ///     Moves the gameObject to archetype remove using the specified component handles
        /// </summary>
        /// <param name="componentHandles">The component handles</param>
        /// <param name="gameObject">The gameObject</param>
        /// <param name="currentLookup">The current lookup</param>
        /// <param name="destination">The destination</param>
        internal void MoveEntityToArchetypeRemove(Span<ComponentHandle> componentHandles, GameObject gameObject,
            ref GameObjectLocation currentLookup, Archetype destination)
        {
            //NOTE: when moving GameObjectLocation between archetypes, version and flags cannot change
            Archetype from = currentLookup.Archetype;

            destination.CreateEntityLocation(currentLookup.Flags, out GameObjectLocation nextLocation).Init(gameObject);
            nextLocation.Version = currentLookup.Version;

            GameObjectIdOnly movedDown = from.DeleteEntityFromStorage(currentLookup.Index, out int deletedIndex);

            ComponentStorageBase[] fromRunners = from.Components;
            ComponentStorageBase[] destRunners = destination.Components;
            byte[] destMap = destination.ComponentTagTable;

            FastImmutableArray<ComponentId> fromComponents = from.ArchetypeTypeArray;

            bool hasGenericRemoveEvent = GameObjectLocation.HasEventFlag(currentLookup.Flags, GameObjectFlags.RemoveGenericComp);

            int writeToIndex = 0;

            DeleteComponentData deleteData = new DeleteComponentData(currentLookup.Index, deletedIndex);

            for (int i = 0; i < fromComponents.Length;)
            {
                ComponentId componentToMoveFromFromToTo = fromComponents[i];
                int toIndex = Unsafe.Add(ref destMap[0], componentToMoveFromFromToTo.RawIndex);

                i++;

                if (toIndex == 0)
                {
                    ComponentStorageBase runner = Unsafe.Add(ref fromRunners[0], i);
                    ref ComponentHandle writeTo = ref Unsafe.Add(ref MemoryMarshal.GetReference(componentHandles), writeToIndex++);
                    if (hasGenericRemoveEvent)
                        writeTo = runner.Store(currentLookup.Index);
                    else //kinda illegal but whatever
                        writeTo = new ComponentHandle(0, componentToMoveFromFromToTo);
                    runner.Delete(deleteData);
                }
                else
                {
                     Unsafe.Add(ref destRunners[0], toIndex).PullComponentFromAndClearTryDevirt(
                        Unsafe.Add(ref fromRunners[0], i), nextLocation.Index, currentLookup.Index, deletedIndex);
                }
            }

            //copy everything but 
            ref GameObjectLocation displacedGameObjectLocation = ref EntityTable.UnsafeIndexNoResize(movedDown.ID);
            displacedGameObjectLocation.Archetype = currentLookup.Archetype;
            displacedGameObjectLocation.Index = currentLookup.Index;

            currentLookup.Archetype = nextLocation.Archetype;
            currentLookup.Index = nextLocation.Index;

            if (GameObjectLocation.HasEventFlag(currentLookup.Flags | WorldEventFlags,
                    GameObjectFlags.RemoveComp | GameObjectFlags.RemoveGenericComp))
            {
                if (ComponentRemovedEvent.HasListeners)
                    foreach (ComponentHandle handle in componentHandles)
                        ComponentRemovedEvent.Invoke(gameObject, handle.ComponentId);

                if (GameObjectLocation.HasEventFlag(currentLookup.Flags,
                        GameObjectFlags.RemoveComp | GameObjectFlags.RemoveGenericComp))
                {
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
                EventRecord lookup = EventLookup[gameObject.EntityIdOnly];
#else
                    ref EventRecord lookup =
                        ref System.Runtime.InteropServices.CollectionsMarshal.GetValueRefOrNullRef(EventLookup, gameObject.EntityIdOnly);
#endif

                    if (hasGenericRemoveEvent)
                        foreach (ComponentHandle handle in componentHandles)
                        {
                            lookup.Remove.NormalEvent.Invoke(gameObject, handle.ComponentId);
                            handle.InvokeComponentEventAndConsume(gameObject, lookup.Remove.GenericEvent);
                        }
                    else
                        //no need to dispose here, as they were never created
                        foreach (ComponentHandle handle in componentHandles)
                            lookup.Remove.NormalEvent.Invoke(gameObject, handle.ComponentId);
                }
            }
        }

        /// <summary>
        ///     Moves the gameObject to archetype iso using the specified gameObject
        /// </summary>
        /// <param name="gameObject">The gameObject</param>
        /// <param name="currentLookup">The current lookup</param>
        /// <param name="destination">The destination</param>
        internal void MoveEntityToArchetypeIso(GameObject gameObject, ref GameObjectLocation currentLookup, Archetype destination)
        {
            Archetype from = currentLookup.Archetype;

            destination.CreateEntityLocation(currentLookup.Flags, out GameObjectLocation nextLocation).Init(gameObject);
            nextLocation.Version = currentLookup.Version;

            GameObjectIdOnly movedDown = from.DeleteEntityFromStorage(currentLookup.Index, out int deletedIndex);


            ComponentStorageBase[] fromRunners = from.Components;
            ComponentStorageBase[] destRunners = destination.Components;
            byte[] destMap = destination.ComponentTagTable;

            FastImmutableArray<ComponentId> fromComponents = from.ArchetypeTypeArray;

            for (int i = 0; i < fromComponents.Length;)
            {
                int toIndex = Unsafe.Add(ref destMap[0], fromComponents[i].RawIndex) & GlobalWorldTables.IndexBits;

                i++;

                destRunners[toIndex].PullComponentFromAndClearTryDevirt(fromRunners[i], nextLocation.Index,
                    currentLookup.Index, deletedIndex);
            }

            ref GameObjectLocation displacedGameObjectLocation = ref EntityTable.UnsafeIndexNoResize(movedDown.ID);
            displacedGameObjectLocation.Archetype = currentLookup.Archetype;
            displacedGameObjectLocation.Index = currentLookup.Index;

            currentLookup.Archetype = nextLocation.Archetype;
            currentLookup.Index = nextLocation.Index;
        }



        //Delete
        /// <summary>
        ///     Deletes the gameObject using the specified gameObject
        /// </summary>
        /// <param name="gameObject">The gameObject</param>
        /// <param name="gameObjectLocation">The gameObject location</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void DeleteEntity(GameObject gameObject, ref GameObjectLocation gameObjectLocation)
        {
            GameObjectFlags check = gameObjectLocation.Flags | WorldEventFlags;
            if ((check & GameObjectFlags.Events) != 0)
                InvokeDeleteEvents(gameObject, gameObjectLocation);
            DeleteEntityWithoutEvents(gameObject, ref gameObjectLocation);
        }

        //let the jit decide whether or not to inline
        /// <summary>
        ///     Invokes the delete events using the specified gameObject
        /// </summary>
        /// <param name="gameObject">The gameObject</param>
        /// <param name="gameObjectLocation">The gameObject location</param>
        private void InvokeDeleteEvents(GameObject gameObject, GameObjectLocation gameObjectLocation)
        {
            EntityDeletedEvent.Invoke(gameObject);
            if (gameObjectLocation.HasEvent(GameObjectFlags.OnDelete))
                foreach (Action<GameObject> @event in EventLookup[gameObject.EntityIdOnly].Delete.AsSpan())
                    @event.Invoke(gameObject);

            EventLookup.Remove(gameObject.EntityIdOnly);
        }

        /// <summary>
        ///     Deletes the gameObject without events using the specified gameObject
        /// </summary>
        /// <param name="gameObject">The gameObject</param>
        /// <param name="currentLookup">The current lookup</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void DeleteEntityWithoutEvents(GameObject gameObject, ref GameObjectLocation currentLookup)
        {
            //gameObject is guaranteed to be alive here
            GameObjectIdOnly replacedEntity = currentLookup.Archetype.DeleteEntity(currentLookup.Index);

            ref GameObjectLocation replaced = ref EntityTable.UnsafeIndexNoResize(replacedEntity.ID);
            replaced = currentLookup;
            replaced.Version = replacedEntity.Version;
            currentLookup.Version = ushort.MaxValue;

            if (gameObject.EntityVersion != ushort.MaxValue - 1)
            {
                // can't use max value as an ID, as it is used as a default value
                GameObjectIdOnly id = gameObject.EntityIdOnly;
                id.Version++;
                RecycledEntityIds.Push(id);
            }
        }


    }
}