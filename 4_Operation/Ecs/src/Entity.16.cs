




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
        public void Add<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(in T1 c1, in T2 c2, in T3 c3, in T4 c4, in T5 c5, in T6 c6, in T7 c7, in T8 c8, in T9 c9, in T10 c10, in T11 c11, in T12 c12, in T13 c13, in T14 c14, in T15 c15, in T16 c16)
        {
            ref EntityLocation thisLookup = ref AssertIsAlive(out World world);

            if (!world.AllowStructualChanges)
            {
                world.WorldUpdateCommandBuffer.AddComponent(this, c1);
            world.WorldUpdateCommandBuffer.AddComponent(this, c2);
            world.WorldUpdateCommandBuffer.AddComponent(this, c3);
            world.WorldUpdateCommandBuffer.AddComponent(this, c4);
            world.WorldUpdateCommandBuffer.AddComponent(this, c5);
            world.WorldUpdateCommandBuffer.AddComponent(this, c6);
            world.WorldUpdateCommandBuffer.AddComponent(this, c7);
            world.WorldUpdateCommandBuffer.AddComponent(this, c8);
            world.WorldUpdateCommandBuffer.AddComponent(this, c9);
            world.WorldUpdateCommandBuffer.AddComponent(this, c10);
            world.WorldUpdateCommandBuffer.AddComponent(this, c11);
            world.WorldUpdateCommandBuffer.AddComponent(this, c12);
            world.WorldUpdateCommandBuffer.AddComponent(this, c13);
            world.WorldUpdateCommandBuffer.AddComponent(this, c14);
            world.WorldUpdateCommandBuffer.AddComponent(this, c15);
            world.WorldUpdateCommandBuffer.AddComponent(this, c16);

                return;
            }

            Archetype to = TraverseThroughCacheOrCreate<ComponentID, NeighborCache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>>(
                world,
                ref NeighborCache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.Add.Lookup,
                ref thisLookup,
                true);

            Span<ComponentStorageBase> buff = [null!, null!, null!, null!, null!, null!, null!, null!, null!, null!, null!, null!, null!, null!, null!, null!];
            world.MoveEntityToArchetypeAdd(buff, this, ref thisLookup, out EntityLocation nextLocation, to);

            ref var c1ref = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T1>>(buff.UnsafeSpanIndex(1 - 1))[nextLocation.Index]; c1ref = c1;
        ref var c2ref = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T2>>(buff.UnsafeSpanIndex(2 - 1))[nextLocation.Index]; c2ref = c2;
        ref var c3ref = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T3>>(buff.UnsafeSpanIndex(3 - 1))[nextLocation.Index]; c3ref = c3;
        ref var c4ref = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T4>>(buff.UnsafeSpanIndex(4 - 1))[nextLocation.Index]; c4ref = c4;
        ref var c5ref = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T5>>(buff.UnsafeSpanIndex(5 - 1))[nextLocation.Index]; c5ref = c5;
        ref var c6ref = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T6>>(buff.UnsafeSpanIndex(6 - 1))[nextLocation.Index]; c6ref = c6;
        ref var c7ref = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T7>>(buff.UnsafeSpanIndex(7 - 1))[nextLocation.Index]; c7ref = c7;
        ref var c8ref = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T8>>(buff.UnsafeSpanIndex(8 - 1))[nextLocation.Index]; c8ref = c8;
        ref var c9ref = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T9>>(buff.UnsafeSpanIndex(9 - 1))[nextLocation.Index]; c9ref = c9;
        ref var c10ref = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T10>>(buff.UnsafeSpanIndex(10 - 1))[nextLocation.Index]; c10ref = c10;
        ref var c11ref = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T11>>(buff.UnsafeSpanIndex(11 - 1))[nextLocation.Index]; c11ref = c11;
        ref var c12ref = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T12>>(buff.UnsafeSpanIndex(12 - 1))[nextLocation.Index]; c12ref = c12;
        ref var c13ref = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T13>>(buff.UnsafeSpanIndex(13 - 1))[nextLocation.Index]; c13ref = c13;
        ref var c14ref = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T14>>(buff.UnsafeSpanIndex(14 - 1))[nextLocation.Index]; c14ref = c14;
        ref var c15ref = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T15>>(buff.UnsafeSpanIndex(15 - 1))[nextLocation.Index]; c15ref = c15;
        ref var c16ref = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T16>>(buff.UnsafeSpanIndex(16 - 1))[nextLocation.Index]; c16ref = c16;


            Component<T1>.Initer?.Invoke(this, ref c1ref);
        Component<T2>.Initer?.Invoke(this, ref c2ref);
        Component<T3>.Initer?.Invoke(this, ref c3ref);
        Component<T4>.Initer?.Invoke(this, ref c4ref);
        Component<T5>.Initer?.Invoke(this, ref c5ref);
        Component<T6>.Initer?.Invoke(this, ref c6ref);
        Component<T7>.Initer?.Invoke(this, ref c7ref);
        Component<T8>.Initer?.Invoke(this, ref c8ref);
        Component<T9>.Initer?.Invoke(this, ref c9ref);
        Component<T10>.Initer?.Invoke(this, ref c10ref);
        Component<T11>.Initer?.Invoke(this, ref c11ref);
        Component<T12>.Initer?.Invoke(this, ref c12ref);
        Component<T13>.Initer?.Invoke(this, ref c13ref);
        Component<T14>.Initer?.Invoke(this, ref c14ref);
        Component<T15>.Initer?.Invoke(this, ref c15ref);
        Component<T16>.Initer?.Invoke(this, ref c16ref);


            EntityFlags flags = thisLookup.Flags;
            if (EntityLocation.HasEventFlag(flags | world.WorldEventFlags, EntityFlags.AddComp | EntityFlags.AddGenericComp))
            {
                if (world.ComponentAddedEvent.HasListeners)
                    InvokeComponentWorldEvents<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(ref world.ComponentAddedEvent, this);

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
        public void Remove<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
        {
            ref EntityLocation thisLookup = ref AssertIsAlive(out World world);

            if (!world.AllowStructualChanges)
            {
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T1>.ID);
            world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T2>.ID);
            world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T3>.ID);
            world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T4>.ID);
            world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T5>.ID);
            world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T6>.ID);
            world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T7>.ID);
            world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T8>.ID);
            world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T9>.ID);
            world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T10>.ID);
            world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T11>.ID);
            world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T12>.ID);
            world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T13>.ID);
            world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T14>.ID);
            world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T15>.ID);
            world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T16>.ID);

                return;
            }

            Archetype to = TraverseThroughCacheOrCreate<ComponentID, NeighborCache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>>(
                world,
                ref NeighborCache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.Remove.Lookup,
                ref thisLookup,
                false);

            Span<ComponentHandle> runners = stackalloc ComponentHandle[16];
            world.MoveEntityToArchetypeRemove(runners, this, ref thisLookup, to);
            //world.MoveEntityToArchetypeRemove invokes the events for us
        }

        /// <summary>
        /// Adds a tag to this <see cref="Entity"/>
        /// </summary>
        /// <inheritdoc cref="Add{T}(in T)"/>
        [SkipLocalsInit]
        public void Tag<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
        {
            ref EntityLocation thisLookup = ref AssertIsAlive(out World world);

            if(!world.AllowStructualChanges)
            {
                world.WorldUpdateCommandBuffer.Tag<T1>(this);
            world.WorldUpdateCommandBuffer.Tag<T2>(this);
            world.WorldUpdateCommandBuffer.Tag<T3>(this);
            world.WorldUpdateCommandBuffer.Tag<T4>(this);
            world.WorldUpdateCommandBuffer.Tag<T5>(this);
            world.WorldUpdateCommandBuffer.Tag<T6>(this);
            world.WorldUpdateCommandBuffer.Tag<T7>(this);
            world.WorldUpdateCommandBuffer.Tag<T8>(this);
            world.WorldUpdateCommandBuffer.Tag<T9>(this);
            world.WorldUpdateCommandBuffer.Tag<T10>(this);
            world.WorldUpdateCommandBuffer.Tag<T11>(this);
            world.WorldUpdateCommandBuffer.Tag<T12>(this);
            world.WorldUpdateCommandBuffer.Tag<T13>(this);
            world.WorldUpdateCommandBuffer.Tag<T14>(this);
            world.WorldUpdateCommandBuffer.Tag<T15>(this);
            world.WorldUpdateCommandBuffer.Tag<T16>(this);

                return;
            }

            Archetype to = TraverseThroughCacheOrCreate<TagID, NeighborCache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>>(
                world,
                ref NeighborCache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.Tag.Lookup,
                ref thisLookup,
                true);

            world.MoveEntityToArchetypeIso(this, ref thisLookup, to);

            EntityFlags flags = thisLookup.Flags | world.WorldEventFlags;
            if (EntityLocation.HasEventFlag(flags, EntityFlags.Tagged))
            {
                if (world.Tagged.HasListeners)
                    InvokeTagWorldEvents<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(ref world.Tagged, this);

                if (EntityLocation.HasEventFlag(flags, EntityFlags.Tagged))
                {
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
                EventRecord events = world.EventLookup[EntityIDOnly];
#else
                    ref EventRecord events = ref CollectionsMarshal.GetValueRefOrNullRef(world.EventLookup, EntityIDOnly);
#endif
                    InvokePerEntityTagEvents<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this, ref events.Tag);
                }
            }
        }

        /// <summary>
        /// Removes a tag from this <see cref="Entity"/>
        /// </summary>
        /// <inheritdoc cref="Add{T}(in T)"/>
        [SkipLocalsInit]
        public void Detach<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
        {
            ref EntityLocation thisLookup = ref AssertIsAlive(out World world);

            if (!world.AllowStructualChanges)
            {
                world.WorldUpdateCommandBuffer.Detach<T1>(this);
            world.WorldUpdateCommandBuffer.Detach<T2>(this);
            world.WorldUpdateCommandBuffer.Detach<T3>(this);
            world.WorldUpdateCommandBuffer.Detach<T4>(this);
            world.WorldUpdateCommandBuffer.Detach<T5>(this);
            world.WorldUpdateCommandBuffer.Detach<T6>(this);
            world.WorldUpdateCommandBuffer.Detach<T7>(this);
            world.WorldUpdateCommandBuffer.Detach<T8>(this);
            world.WorldUpdateCommandBuffer.Detach<T9>(this);
            world.WorldUpdateCommandBuffer.Detach<T10>(this);
            world.WorldUpdateCommandBuffer.Detach<T11>(this);
            world.WorldUpdateCommandBuffer.Detach<T12>(this);
            world.WorldUpdateCommandBuffer.Detach<T13>(this);
            world.WorldUpdateCommandBuffer.Detach<T14>(this);
            world.WorldUpdateCommandBuffer.Detach<T15>(this);
            world.WorldUpdateCommandBuffer.Detach<T16>(this);

                return;
            }

            Archetype to = TraverseThroughCacheOrCreate<TagID, NeighborCache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>>(
                world,
                ref NeighborCache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.Detach.Lookup,
                ref thisLookup,
                false);

            world.MoveEntityToArchetypeIso(this, ref thisLookup, to);

            EntityFlags flags = thisLookup.Flags | world.WorldEventFlags;
            if (EntityLocation.HasEventFlag(flags, EntityFlags.Detach))
            {
                if (world.Detached.HasListeners)
                    InvokeTagWorldEvents<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(ref world.Detached, this);

                if (EntityLocation.HasEventFlag(flags, EntityFlags.Detach))
                {
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
                EventRecord events = world.EventLookup[EntityIDOnly];
#else
                    ref EventRecord events = ref CollectionsMarshal.GetValueRefOrNullRef(world.EventLookup, EntityIDOnly);
#endif
                    InvokePerEntityTagEvents<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this, ref events.Detach);
                }
            }
        }

        private static void InvokeComponentWorldEvents<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(ref Event<ComponentID> @event, Entity entity)
        {
            @event.InvokeInternal(entity, Component<T1>.ID);
        @event.InvokeInternal(entity, Component<T2>.ID);
        @event.InvokeInternal(entity, Component<T3>.ID);
        @event.InvokeInternal(entity, Component<T4>.ID);
        @event.InvokeInternal(entity, Component<T5>.ID);
        @event.InvokeInternal(entity, Component<T6>.ID);
        @event.InvokeInternal(entity, Component<T7>.ID);
        @event.InvokeInternal(entity, Component<T8>.ID);
        @event.InvokeInternal(entity, Component<T9>.ID);
        @event.InvokeInternal(entity, Component<T10>.ID);
        @event.InvokeInternal(entity, Component<T11>.ID);
        @event.InvokeInternal(entity, Component<T12>.ID);
        @event.InvokeInternal(entity, Component<T13>.ID);
        @event.InvokeInternal(entity, Component<T14>.ID);
        @event.InvokeInternal(entity, Component<T15>.ID);
        @event.InvokeInternal(entity, Component<T16>.ID);

        }

        private static void InvokePerEntityEvents<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Entity entity, bool hasGenericEvent, ref ComponentEvent events, ref T1 component1, ref T2 component2, ref T3 component3, ref T4 component4, ref T5 component5, ref T6 component6, ref T7 component7, ref T8 component8, ref T9 component9, ref T10 component10, ref T11 component11, ref T12 component12, ref T13 component13, ref T14 component14, ref T15 component15, ref T16 component16)
        {
            events.NormalEvent.Invoke(entity, Component<T1>.ID);
        events.NormalEvent.Invoke(entity, Component<T2>.ID);
        events.NormalEvent.Invoke(entity, Component<T3>.ID);
        events.NormalEvent.Invoke(entity, Component<T4>.ID);
        events.NormalEvent.Invoke(entity, Component<T5>.ID);
        events.NormalEvent.Invoke(entity, Component<T6>.ID);
        events.NormalEvent.Invoke(entity, Component<T7>.ID);
        events.NormalEvent.Invoke(entity, Component<T8>.ID);
        events.NormalEvent.Invoke(entity, Component<T9>.ID);
        events.NormalEvent.Invoke(entity, Component<T10>.ID);
        events.NormalEvent.Invoke(entity, Component<T11>.ID);
        events.NormalEvent.Invoke(entity, Component<T12>.ID);
        events.NormalEvent.Invoke(entity, Component<T13>.ID);
        events.NormalEvent.Invoke(entity, Component<T14>.ID);
        events.NormalEvent.Invoke(entity, Component<T15>.ID);
        events.NormalEvent.Invoke(entity, Component<T16>.ID);


            if (!hasGenericEvent)
                return;

            events.GenericEvent!.Invoke(entity, ref component1);
        events.GenericEvent!.Invoke(entity, ref component2);
        events.GenericEvent!.Invoke(entity, ref component3);
        events.GenericEvent!.Invoke(entity, ref component4);
        events.GenericEvent!.Invoke(entity, ref component5);
        events.GenericEvent!.Invoke(entity, ref component6);
        events.GenericEvent!.Invoke(entity, ref component7);
        events.GenericEvent!.Invoke(entity, ref component8);
        events.GenericEvent!.Invoke(entity, ref component9);
        events.GenericEvent!.Invoke(entity, ref component10);
        events.GenericEvent!.Invoke(entity, ref component11);
        events.GenericEvent!.Invoke(entity, ref component12);
        events.GenericEvent!.Invoke(entity, ref component13);
        events.GenericEvent!.Invoke(entity, ref component14);
        events.GenericEvent!.Invoke(entity, ref component15);
        events.GenericEvent!.Invoke(entity, ref component16);

        }

        private static void InvokeTagWorldEvents<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(ref TagEvent @event, Entity entity)
        {
            @event.InvokeInternal(entity, Core.Tag<T1>.ID);
        @event.InvokeInternal(entity, Core.Tag<T2>.ID);
        @event.InvokeInternal(entity, Core.Tag<T3>.ID);
        @event.InvokeInternal(entity, Core.Tag<T4>.ID);
        @event.InvokeInternal(entity, Core.Tag<T5>.ID);
        @event.InvokeInternal(entity, Core.Tag<T6>.ID);
        @event.InvokeInternal(entity, Core.Tag<T7>.ID);
        @event.InvokeInternal(entity, Core.Tag<T8>.ID);
        @event.InvokeInternal(entity, Core.Tag<T9>.ID);
        @event.InvokeInternal(entity, Core.Tag<T10>.ID);
        @event.InvokeInternal(entity, Core.Tag<T11>.ID);
        @event.InvokeInternal(entity, Core.Tag<T12>.ID);
        @event.InvokeInternal(entity, Core.Tag<T13>.ID);
        @event.InvokeInternal(entity, Core.Tag<T14>.ID);
        @event.InvokeInternal(entity, Core.Tag<T15>.ID);
        @event.InvokeInternal(entity, Core.Tag<T16>.ID);

        }

        private static void InvokePerEntityTagEvents<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Entity entity, ref TagEvent events)
        {
            events.Invoke(entity, Core.Tag<T1>.ID);
        events.Invoke(entity, Core.Tag<T2>.ID);
        events.Invoke(entity, Core.Tag<T3>.ID);
        events.Invoke(entity, Core.Tag<T4>.ID);
        events.Invoke(entity, Core.Tag<T5>.ID);
        events.Invoke(entity, Core.Tag<T6>.ID);
        events.Invoke(entity, Core.Tag<T7>.ID);
        events.Invoke(entity, Core.Tag<T8>.ID);
        events.Invoke(entity, Core.Tag<T9>.ID);
        events.Invoke(entity, Core.Tag<T10>.ID);
        events.Invoke(entity, Core.Tag<T11>.ID);
        events.Invoke(entity, Core.Tag<T12>.ID);
        events.Invoke(entity, Core.Tag<T13>.ID);
        events.Invoke(entity, Core.Tag<T14>.ID);
        events.Invoke(entity, Core.Tag<T15>.ID);
        events.Invoke(entity, Core.Tag<T16>.ID);

        }

        private struct NeighborCache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> : IArchetypeGraphEdge
        {
            public void ModifyTags(ref ImmutableArray<TagID> tags, bool add)
            {
                if (add)
                {
                    tags = MemoryHelpers.Concat(tags, [Core.Tag<T1>.ID, Core.Tag<T2>.ID, Core.Tag<T3>.ID, Core.Tag<T4>.ID, Core.Tag<T5>.ID, Core.Tag<T6>.ID, Core.Tag<T7>.ID, Core.Tag<T8>.ID, Core.Tag<T9>.ID, Core.Tag<T10>.ID, Core.Tag<T11>.ID, Core.Tag<T12>.ID, Core.Tag<T13>.ID, Core.Tag<T14>.ID, Core.Tag<T15>.ID, Core.Tag<T16>.ID]);
                }
                else
                {
                    tags = MemoryHelpers.Remove(tags, [Core.Tag<T1>.ID, Core.Tag<T2>.ID, Core.Tag<T3>.ID, Core.Tag<T4>.ID, Core.Tag<T5>.ID, Core.Tag<T6>.ID, Core.Tag<T7>.ID, Core.Tag<T8>.ID, Core.Tag<T9>.ID, Core.Tag<T10>.ID, Core.Tag<T11>.ID, Core.Tag<T12>.ID, Core.Tag<T13>.ID, Core.Tag<T14>.ID, Core.Tag<T15>.ID, Core.Tag<T16>.ID]);
                }
            }

            public void ModifyComponents(ref ImmutableArray<ComponentID> components, bool add)
            {
                if (add)
                {
                    components = MemoryHelpers.Concat(components, [Component<T1>.ID, Component<T2>.ID, Component<T3>.ID, Component<T4>.ID, Component<T5>.ID, Component<T6>.ID, Component<T7>.ID, Component<T8>.ID, Component<T9>.ID, Component<T10>.ID, Component<T11>.ID, Component<T12>.ID, Component<T13>.ID, Component<T14>.ID, Component<T15>.ID, Component<T16>.ID]);
                }
                else
                {
                    components = MemoryHelpers.Remove(components, [Component<T1>.ID, Component<T2>.ID, Component<T3>.ID, Component<T4>.ID, Component<T5>.ID, Component<T6>.ID, Component<T7>.ID, Component<T8>.ID, Component<T9>.ID, Component<T10>.ID, Component<T11>.ID, Component<T12>.ID, Component<T13>.ID, Component<T14>.ID, Component<T15>.ID, Component<T16>.ID]);
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
