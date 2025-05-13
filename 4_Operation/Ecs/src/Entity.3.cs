




using System;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Core;
using Alis.Core.Ecs.Core.Events;
using Alis.Core.Ecs.Updating;
using Alis.Core.Ecs.Updating.Runners;
using Alis.Variadic.Generator;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Core.Archetype;
using Alis.Core.Ecs.Core.Memory;

namespace Alis.Core.Ecs;
    partial struct Entity
    {
        // traversing archetype graph strategy:
        //1. hit small & fast static per type cache - 1 branch
        //2. dictionary lookup
        //3. find existing archetype
        //4. create new archetype

        /// <summary>
        /// Adds a component to this <see cref="Entity"/>.
        /// </summary>
        /// <remarks>If the world is being updated, changed are deffered to the end of the world update.</remarks>
        [SkipLocalsInit]
        public void Add<T1, T2, T3>(in T1 c1, in T2 c2, in T3 c3)
        {
            ref EntityLocation thisLookup = ref AssertIsAlive(out World world);

            if (!world.AllowStructualChanges)
            {
                world.WorldUpdateCommandBuffer.AddComponent(this, c1);
            world.WorldUpdateCommandBuffer.AddComponent(this, c2);
            world.WorldUpdateCommandBuffer.AddComponent(this, c3);

                return;
            }

            Archetype to = TraverseThroughCacheOrCreate<ComponentID, NeighborCache<T1, T2, T3>>(
                world,
                ref NeighborCache<T1, T2, T3>.Add.Lookup,
                ref thisLookup,
                true);

            Span<ComponentStorageBase> buff = [null!, null!, null!];
            world.MoveEntityToArchetypeAdd(buff, this, ref thisLookup, out EntityLocation nextLocation, to);

            ref var c1ref = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T1>>(buff.UnsafeSpanIndex(1 - 1))[nextLocation.Index]; c1ref = c1;
        ref var c2ref = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T2>>(buff.UnsafeSpanIndex(2 - 1))[nextLocation.Index]; c2ref = c2;
        ref var c3ref = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T3>>(buff.UnsafeSpanIndex(3 - 1))[nextLocation.Index]; c3ref = c3;


            Component<T1>.Initer?.Invoke(this, ref c1ref);
        Component<T2>.Initer?.Invoke(this, ref c2ref);
        Component<T3>.Initer?.Invoke(this, ref c3ref);


            EntityFlags flags = thisLookup.Flags;
            if (EntityLocation.HasEventFlag(flags | world.WorldEventFlags, EntityFlags.AddComp | EntityFlags.AddGenericComp))
            {
                if (world.ComponentAddedEvent.HasListeners)
                    InvokeComponentWorldEvents<T1, T2, T3>(ref world.ComponentAddedEvent, this);

                if (EntityLocation.HasEventFlag(flags, EntityFlags.AddComp | EntityFlags.AddGenericComp))
                {
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
                EventRecord events = world.EventLookup[EntityIDOnly];
#else
                    ref EventRecord events = ref CollectionsMarshal.GetValueRefOrNullRef(world.EventLookup, EntityIDOnly);
#endif
                    InvokePerEntityEvents(this, EntityLocation.HasEventFlag(thisLookup.Flags, EntityFlags.AddGenericComp), ref events.Add, ref c1ref);
                }
            }
        }

        /// <summary>
        /// Removes a component from this <see cref="Entity"/>
        /// </summary>
        /// <inheritdoc cref="Add{T}(in T)"/>
        [SkipLocalsInit]
        public void Remove<T1, T2, T3>()
        {
            ref EntityLocation thisLookup = ref AssertIsAlive(out World world);

            if (!world.AllowStructualChanges)
            {
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T1>.ID);
            world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T2>.ID);
            world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T3>.ID);

                return;
            }

            Archetype to = TraverseThroughCacheOrCreate<ComponentID, NeighborCache<T1, T2, T3>>(
                world,
                ref NeighborCache<T1, T2, T3>.Remove.Lookup,
                ref thisLookup,
                false);

            Span<ComponentHandle> runners = stackalloc ComponentHandle[3];
            world.MoveEntityToArchetypeRemove(runners, this, ref thisLookup, to);
            //world.MoveEntityToArchetypeRemove invokes the events for us
        }

        /// <summary>
        /// Adds a tag to this <see cref="Entity"/>
        /// </summary>
        /// <inheritdoc cref="Add{T}(in T)"/>
        [SkipLocalsInit]
        public void Tag<T1, T2, T3>()
        {
            ref EntityLocation thisLookup = ref AssertIsAlive(out World world);

            if(!world.AllowStructualChanges)
            {
                world.WorldUpdateCommandBuffer.Tag<T1>(this);
            world.WorldUpdateCommandBuffer.Tag<T2>(this);
            world.WorldUpdateCommandBuffer.Tag<T3>(this);

                return;
            }

            Archetype to = TraverseThroughCacheOrCreate<TagID, NeighborCache<T1, T2, T3>>(
                world,
                ref NeighborCache<T1, T2, T3>.Tag.Lookup,
                ref thisLookup,
                true);

            world.MoveEntityToArchetypeIso(this, ref thisLookup, to);

            EntityFlags flags = thisLookup.Flags | world.WorldEventFlags;
            if (EntityLocation.HasEventFlag(flags, EntityFlags.Tagged))
            {
                if (world.Tagged.HasListeners)
                    InvokeTagWorldEvents<T1, T2, T3>(ref world.Tagged, this);

                if (EntityLocation.HasEventFlag(flags, EntityFlags.Tagged))
                {
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
                EventRecord events = world.EventLookup[EntityIDOnly];
#else
                    ref EventRecord events = ref CollectionsMarshal.GetValueRefOrNullRef(world.EventLookup, EntityIDOnly);
#endif
                    InvokePerEntityTagEvents<T1, T2, T3>(this, ref events.Tag);
                }
            }
        }

        /// <summary>
        /// Removes a tag from this <see cref="Entity"/>
        /// </summary>
        /// <inheritdoc cref="Add{T}(in T)"/>
        [SkipLocalsInit]
        public void Detach<T1, T2, T3>()
        {
            ref EntityLocation thisLookup = ref AssertIsAlive(out World world);

            if (!world.AllowStructualChanges)
            {
                world.WorldUpdateCommandBuffer.Detach<T1>(this);
            world.WorldUpdateCommandBuffer.Detach<T2>(this);
            world.WorldUpdateCommandBuffer.Detach<T3>(this);

                return;
            }

            Archetype to = TraverseThroughCacheOrCreate<TagID, NeighborCache<T1, T2, T3>>(
                world,
                ref NeighborCache<T1, T2, T3>.Detach.Lookup,
                ref thisLookup,
                false);

            world.MoveEntityToArchetypeIso(this, ref thisLookup, to);

            EntityFlags flags = thisLookup.Flags | world.WorldEventFlags;
            if (EntityLocation.HasEventFlag(flags, EntityFlags.Detach))
            {
                if (world.Detached.HasListeners)
                    InvokeTagWorldEvents<T1, T2, T3>(ref world.Detached, this);

                if (EntityLocation.HasEventFlag(flags, EntityFlags.Detach))
                {
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
                EventRecord events = world.EventLookup[EntityIDOnly];
#else
                    ref EventRecord events = ref CollectionsMarshal.GetValueRefOrNullRef(world.EventLookup, EntityIDOnly);
#endif
                    InvokePerEntityTagEvents<T1, T2, T3>(this, ref events.Detach);
                }
            }
        }

        private static void InvokeComponentWorldEvents<T1, T2, T3>(ref Event<ComponentID> @event, Entity entity)
        {
            @event.InvokeInternal(entity, Component<T1>.ID);
        @event.InvokeInternal(entity, Component<T2>.ID);
        @event.InvokeInternal(entity, Component<T3>.ID);

        }

        private static void InvokePerEntityEvents<T1, T2, T3>(Entity entity, bool hasGenericEvent, ref ComponentEvent events, ref T1 component1, ref T2 component2, ref T3 component3)
        {
            events.NormalEvent.Invoke(entity, Component<T1>.ID);
        events.NormalEvent.Invoke(entity, Component<T2>.ID);
        events.NormalEvent.Invoke(entity, Component<T3>.ID);


            if (!hasGenericEvent)
                return;

            events.GenericEvent!.Invoke(entity, ref component1);
        events.GenericEvent!.Invoke(entity, ref component2);
        events.GenericEvent!.Invoke(entity, ref component3);

        }

        private static void InvokeTagWorldEvents<T1, T2, T3>(ref TagEvent @event, Entity entity)
        {
            @event.InvokeInternal(entity, Core.Tag<T1>.ID);
        @event.InvokeInternal(entity, Core.Tag<T2>.ID);
        @event.InvokeInternal(entity, Core.Tag<T3>.ID);

        }

        private static void InvokePerEntityTagEvents<T1, T2, T3>(Entity entity, ref TagEvent events)
        {
            events.Invoke(entity, Core.Tag<T1>.ID);
        events.Invoke(entity, Core.Tag<T2>.ID);
        events.Invoke(entity, Core.Tag<T3>.ID);

        }

        private struct NeighborCache<T1, T2, T3> : IArchetypeGraphEdge
        {
            public void ModifyTags(ref ImmutableArray<TagID> tags, bool add)
            {
                if (add)
                {
                    tags = MemoryHelpers.Concat(tags, [Core.Tag<T1>.ID, Core.Tag<T2>.ID, Core.Tag<T3>.ID]);
                }
                else
                {
                    tags = MemoryHelpers.Remove(tags, [Core.Tag<T1>.ID, Core.Tag<T2>.ID, Core.Tag<T3>.ID]);
                }
            }

            public void ModifyComponents(ref ImmutableArray<ComponentID> components, bool add)
            {
                if (add)
                {
                    components = MemoryHelpers.Concat(components, [Component<T1>.ID, Component<T2>.ID, Component<T3>.ID]);
                }
                else
                {
                    components = MemoryHelpers.Remove(components, [Component<T1>.ID, Component<T2>.ID, Component<T3>.ID]);
                }
            }

            //separate into individual classes to avoid creating uneccecary static classes.

            internal static class Add
            {
                internal static ArchetypeNeighborCache Lookup;
            }

            internal static class Remove
            {
                internal static ArchetypeNeighborCache Lookup;
            }

            internal static class Tag
            {
                internal static ArchetypeNeighborCache Lookup;
            }

            internal static class Detach
            {
                internal static ArchetypeNeighborCache Lookup;
            }
        }
    }
