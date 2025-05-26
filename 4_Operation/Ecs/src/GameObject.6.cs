using System;
using Alis.Core.Aspect.Memory.Collections;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Core;
using Alis.Core.Ecs.Core.Archetype;
using Alis.Core.Ecs.Core.Events;
using Alis.Core.Ecs.Core.Memory;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The gameObject
    /// </summary>
    partial struct GameObject
    {
        // traversing archetype graph strategy:
        //1. hit small & fast static per type cache - 1 branch
        //2. dictionary lookup
        //3. find existing archetype
        //4. create new archetype

        /// <summary>
        ///     Adds a component to this <see cref="GameObject" />.
        /// </summary>
        /// <remarks>If the scene is being updated, changed are deffered to the end of the scene update.</remarks>
        public void Add<T1, T2, T3, T4, T5, T6>(in T1 c1, in T2 c2, in T3 c3, in T4 c4, in T5 c5, in T6 c6)
        {
            ref GameObjectLocation thisLookup = ref AssertIsAlive(out Scene world);

            if (!world.AllowStructualChanges)
            {
                world.WorldUpdateCommandBuffer.AddComponent(this, c1);
                world.WorldUpdateCommandBuffer.AddComponent(this, c2);
                world.WorldUpdateCommandBuffer.AddComponent(this, c3);
                world.WorldUpdateCommandBuffer.AddComponent(this, c4);
                world.WorldUpdateCommandBuffer.AddComponent(this, c5);
                world.WorldUpdateCommandBuffer.AddComponent(this, c6);

                return;
            }

            Archetype to = TraverseThroughCacheOrCreate<ComponentId, NeighborCache<T1, T2, T3, T4, T5, T6>>(
                world,
                ref NeighborCache<T1, T2, T3, T4, T5, T6>.Add.Lookup,
                ref thisLookup,
                true);

            Span<ComponentStorageBase> buff = [null!, null!, null!, null!, null!, null!];
            world.MoveEntityToArchetypeAdd(buff, this, ref thisLookup, out GameObjectLocation nextLocation, to);

            ref T1 c1Ref =
                ref UnsafeExtensions.UnsafeCast<ComponentStorage<T1>>(buff.UnsafeSpanIndex(1 - 1))[nextLocation.Index];
            c1Ref = c1;
            ref T2 c2Ref =
                ref UnsafeExtensions.UnsafeCast<ComponentStorage<T2>>(buff.UnsafeSpanIndex(2 - 1))[nextLocation.Index];
            c2Ref = c2;
            ref T3 c3Ref =
                ref UnsafeExtensions.UnsafeCast<ComponentStorage<T3>>(buff.UnsafeSpanIndex(3 - 1))[nextLocation.Index];
            c3Ref = c3;
            ref T4 c4Ref =
                ref UnsafeExtensions.UnsafeCast<ComponentStorage<T4>>(buff.UnsafeSpanIndex(4 - 1))[nextLocation.Index];
            c4Ref = c4;
            ref T5 c5Ref =
                ref UnsafeExtensions.UnsafeCast<ComponentStorage<T5>>(buff.UnsafeSpanIndex(5 - 1))[nextLocation.Index];
            c5Ref = c5;
            ref T6 c6Ref =
                ref UnsafeExtensions.UnsafeCast<ComponentStorage<T6>>(buff.UnsafeSpanIndex(6 - 1))[nextLocation.Index];
            c6Ref = c6;


            Component<T1>.Initer?.Invoke(this, ref c1Ref);
            Component<T2>.Initer?.Invoke(this, ref c2Ref);
            Component<T3>.Initer?.Invoke(this, ref c3Ref);
            Component<T4>.Initer?.Invoke(this, ref c4Ref);
            Component<T5>.Initer?.Invoke(this, ref c5Ref);
            Component<T6>.Initer?.Invoke(this, ref c6Ref);


            GameObjectFlags flags = thisLookup.Flags;
            if (GameObjectLocation.HasEventFlag(flags | world.WorldEventFlags,
                    GameObjectFlags.AddComp | GameObjectFlags.AddGenericComp))
            {
                if (world.ComponentAddedEvent.HasListeners)
                    InvokeComponentWorldEvents<T1, T2, T3, T4, T5, T6>(ref world.ComponentAddedEvent, this);

                if (GameObjectLocation.HasEventFlag(flags, GameObjectFlags.AddComp | GameObjectFlags.AddGenericComp))
                {
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
                    EventRecord events = world.EventLookup[EntityIdOnly];
#else
                ref EventRecord events =
                    ref System.Runtime.InteropServices.CollectionsMarshal.GetValueRefOrNullRef(world.EventLookup, EntityIdOnly);
#endif
                    InvokePerEntityEvents(this, GameObjectLocation.HasEventFlag(thisLookup.Flags, GameObjectFlags.AddGenericComp),
                        ref events.Add, ref c1Ref);
                }
            }
        }

        /// <summary>
        ///     Removes a component from this <see cref="GameObject" />
        /// </summary>
        /// <inheritdoc cref="Add{T}(in T)" />
        public void Remove<T1, T2, T3, T4, T5, T6>()
        {
            ref GameObjectLocation thisLookup = ref AssertIsAlive(out Scene world);

            if (!world.AllowStructualChanges)
            {
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T1>.Id);
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T2>.Id);
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T3>.Id);
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T4>.Id);
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T5>.Id);
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T6>.Id);

                return;
            }

            Archetype to = TraverseThroughCacheOrCreate<ComponentId, NeighborCache<T1, T2, T3, T4, T5, T6>>(
                world,
                ref NeighborCache<T1, T2, T3, T4, T5, T6>.Remove.Lookup,
                ref thisLookup,
                false);

            Span<ComponentHandle> runners = stackalloc ComponentHandle[6];
            world.MoveEntityToArchetypeRemove(runners, this, ref thisLookup, to);
            //scene.MoveEntityToArchetypeRemove invokes the events for us
        }

        /// <summary>
        ///     Adds a tag to this <see cref="GameObject" />
        /// </summary>
        /// <inheritdoc cref="Add{T}(in T)" />
        public void Tag<T1, T2, T3, T4, T5, T6>()
        {
            ref GameObjectLocation thisLookup = ref AssertIsAlive(out Scene world);

            if (!world.AllowStructualChanges)
            {
                world.WorldUpdateCommandBuffer.Tag<T1>(this);
                world.WorldUpdateCommandBuffer.Tag<T2>(this);
                world.WorldUpdateCommandBuffer.Tag<T3>(this);
                world.WorldUpdateCommandBuffer.Tag<T4>(this);
                world.WorldUpdateCommandBuffer.Tag<T5>(this);
                world.WorldUpdateCommandBuffer.Tag<T6>(this);

                return;
            }

            Archetype to = TraverseThroughCacheOrCreate<TagId, NeighborCache<T1, T2, T3, T4, T5, T6>>(
                world,
                ref NeighborCache<T1, T2, T3, T4, T5, T6>.Tag.Lookup,
                ref thisLookup,
                true);

            world.MoveEntityToArchetypeIso(this, ref thisLookup, to);

            GameObjectFlags flags = thisLookup.Flags | world.WorldEventFlags;
            if (GameObjectLocation.HasEventFlag(flags, GameObjectFlags.Tagged))
            {
                if (world.Tagged.HasListeners)
                    InvokeTagWorldEvents<T1, T2, T3, T4, T5, T6>(ref world.Tagged, this);

                if (GameObjectLocation.HasEventFlag(flags, GameObjectFlags.Tagged))
                {
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
                    EventRecord events = world.EventLookup[EntityIdOnly];
#else
                ref EventRecord events =
                    ref System.Runtime.InteropServices.CollectionsMarshal.GetValueRefOrNullRef(world.EventLookup, EntityIdOnly);
#endif
                    InvokePerEntityTagEvents<T1, T2, T3, T4, T5, T6>(this, ref events.Tag);
                }
            }
        }

        /// <summary>
        ///     Removes a tag from this <see cref="GameObject" />
        /// </summary>
        /// <inheritdoc cref="Add{T}(in T)" />
        public void Detach<T1, T2, T3, T4, T5, T6>()
        {
            ref GameObjectLocation thisLookup = ref AssertIsAlive(out Scene world);

            if (!world.AllowStructualChanges)
            {
                world.WorldUpdateCommandBuffer.Detach<T1>(this);
                world.WorldUpdateCommandBuffer.Detach<T2>(this);
                world.WorldUpdateCommandBuffer.Detach<T3>(this);
                world.WorldUpdateCommandBuffer.Detach<T4>(this);
                world.WorldUpdateCommandBuffer.Detach<T5>(this);
                world.WorldUpdateCommandBuffer.Detach<T6>(this);

                return;
            }

            Archetype to = TraverseThroughCacheOrCreate<TagId, NeighborCache<T1, T2, T3, T4, T5, T6>>(
                world,
                ref NeighborCache<T1, T2, T3, T4, T5, T6>.Detach.Lookup,
                ref thisLookup,
                false);

            world.MoveEntityToArchetypeIso(this, ref thisLookup, to);

            GameObjectFlags flags = thisLookup.Flags | world.WorldEventFlags;
            if (GameObjectLocation.HasEventFlag(flags, GameObjectFlags.Detach))
            {
                if (world.Detached.HasListeners)
                    InvokeTagWorldEvents<T1, T2, T3, T4, T5, T6>(ref world.Detached, this);

                if (GameObjectLocation.HasEventFlag(flags, GameObjectFlags.Detach))
                {
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
                    EventRecord events = world.EventLookup[EntityIdOnly];
#else
                ref EventRecord events =
                    ref System.Runtime.InteropServices.CollectionsMarshal.GetValueRefOrNullRef(world.EventLookup, EntityIdOnly);
#endif
                    InvokePerEntityTagEvents<T1, T2, T3, T4, T5, T6>(this, ref events.Detach);
                }
            }
        }

        /// <summary>
        ///     Invokes the component scene events using the specified event
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <param name="@event">The event</param>
        /// <param name="gameObject">The gameObject</param>
        private static void InvokeComponentWorldEvents<T1, T2, T3, T4, T5, T6>(ref Event<ComponentId> @event, GameObject gameObject)
        {
            @event.InvokeInternal(gameObject, Component<T1>.Id);
            @event.InvokeInternal(gameObject, Component<T2>.Id);
            @event.InvokeInternal(gameObject, Component<T3>.Id);
            @event.InvokeInternal(gameObject, Component<T4>.Id);
            @event.InvokeInternal(gameObject, Component<T5>.Id);
            @event.InvokeInternal(gameObject, Component<T6>.Id);
        }

        /// <summary>
        ///     Invokes the per gameObject events using the specified gameObject
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <param name="gameObject">The gameObject</param>
        /// <param name="hasGenericEvent">The has generic event</param>
        /// <param name="events">The events</param>
        /// <param name="component1">The component</param>
        /// <param name="component2">The component</param>
        /// <param name="component3">The component</param>
        /// <param name="component4">The component</param>
        /// <param name="component5">The component</param>
        /// <param name="component6">The component</param>
        private static void InvokePerEntityEvents<T1, T2, T3, T4, T5, T6>(GameObject gameObject, bool hasGenericEvent,
            ref ComponentEvent events, ref T1 component1, ref T2 component2, ref T3 component3, ref T4 component4,
            ref T5 component5, ref T6 component6)
        {
            events.NormalEvent.Invoke(gameObject, Component<T1>.Id);
            events.NormalEvent.Invoke(gameObject, Component<T2>.Id);
            events.NormalEvent.Invoke(gameObject, Component<T3>.Id);
            events.NormalEvent.Invoke(gameObject, Component<T4>.Id);
            events.NormalEvent.Invoke(gameObject, Component<T5>.Id);
            events.NormalEvent.Invoke(gameObject, Component<T6>.Id);


            if (!hasGenericEvent)
                return;

            events.GenericEvent!.Invoke(gameObject, ref component1);
            events.GenericEvent!.Invoke(gameObject, ref component2);
            events.GenericEvent!.Invoke(gameObject, ref component3);
            events.GenericEvent!.Invoke(gameObject, ref component4);
            events.GenericEvent!.Invoke(gameObject, ref component5);
            events.GenericEvent!.Invoke(gameObject, ref component6);
        }

        /// <summary>
        ///     Invokes the tag scene events using the specified event
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <param name="@event">The event</param>
        /// <param name="gameObject">The gameObject</param>
        private static void InvokeTagWorldEvents<T1, T2, T3, T4, T5, T6>(ref TagEvent @event, GameObject gameObject)
        {
            @event.InvokeInternal(gameObject, Core.Tag<T1>.Id);
            @event.InvokeInternal(gameObject, Core.Tag<T2>.Id);
            @event.InvokeInternal(gameObject, Core.Tag<T3>.Id);
            @event.InvokeInternal(gameObject, Core.Tag<T4>.Id);
            @event.InvokeInternal(gameObject, Core.Tag<T5>.Id);
            @event.InvokeInternal(gameObject, Core.Tag<T6>.Id);
        }

        /// <summary>
        ///     Invokes the per gameObject tag events using the specified gameObject
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <param name="gameObject">The gameObject</param>
        /// <param name="events">The events</param>
        private static void InvokePerEntityTagEvents<T1, T2, T3, T4, T5, T6>(GameObject gameObject, ref TagEvent events)
        {
            events.Invoke(gameObject, Core.Tag<T1>.Id);
            events.Invoke(gameObject, Core.Tag<T2>.Id);
            events.Invoke(gameObject, Core.Tag<T3>.Id);
            events.Invoke(gameObject, Core.Tag<T4>.Id);
            events.Invoke(gameObject, Core.Tag<T5>.Id);
            events.Invoke(gameObject, Core.Tag<T6>.Id);
        }

        /// <summary>
        ///     The neighbor cache
        /// </summary>
        public struct NeighborCache<T1, T2, T3, T4, T5, T6> : IArchetypeGraphEdge
        {
            /// <summary>
            ///     Modifies the tags using the specified tags
            /// </summary>
            /// <param name="tags">The tags</param>
            /// <param name="add">The add</param>
            public void ModifyTags(ref FastImmutableArray<TagId> tags, bool add)
            {
                if (add)
                    tags = MemoryHelpers.Concat(tags,
                    [
                        Core.Tag<T1>.Id, Core.Tag<T2>.Id, Core.Tag<T3>.Id, Core.Tag<T4>.Id, Core.Tag<T5>.Id, Core.Tag<T6>.Id
                    ]);
                else
                    tags = MemoryHelpers.Remove(tags,
                    [
                        Core.Tag<T1>.Id, Core.Tag<T2>.Id, Core.Tag<T3>.Id, Core.Tag<T4>.Id, Core.Tag<T5>.Id, Core.Tag<T6>.Id
                    ]);
            }

            /// <summary>
            ///     Modifies the components using the specified components
            /// </summary>
            /// <param name="components">The components</param>
            /// <param name="add">The add</param>
            public void ModifyComponents(ref FastImmutableArray<ComponentId> components, bool add)
            {
                if (add)
                    components = MemoryHelpers.Concat(components,
                    [
                        Component<T1>.Id, Component<T2>.Id, Component<T3>.Id, Component<T4>.Id, Component<T5>.Id,
                        Component<T6>.Id
                    ]);
                else
                    components = MemoryHelpers.Remove(components,
                    [
                        Component<T1>.Id, Component<T2>.Id, Component<T3>.Id, Component<T4>.Id, Component<T5>.Id,
                        Component<T6>.Id
                    ]);
            }

            //separate into individual classes to avoid creating uneccecary static classes.

            /// <summary>
            ///     The add class
            /// </summary>
            internal static class Add
            {
                /// <summary>
                ///     The lookup
                /// </summary>
                internal static ArchetypeNeighborCache Lookup;
            }

            /// <summary>
            ///     The remove class
            /// </summary>
            internal static class Remove
            {
                /// <summary>
                ///     The lookup
                /// </summary>
                internal static ArchetypeNeighborCache Lookup;
            }

            /// <summary>
            ///     The tag class
            /// </summary>
            internal static class Tag
            {
                /// <summary>
                ///     The lookup
                /// </summary>
                internal static ArchetypeNeighborCache Lookup;
            }

            /// <summary>
            ///     The detach class
            /// </summary>
            internal static class Detach
            {
                /// <summary>
                ///     The lookup
                /// </summary>
                internal static ArchetypeNeighborCache Lookup;
            }
        }
    }
}