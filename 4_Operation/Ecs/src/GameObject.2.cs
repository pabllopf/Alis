using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Arch;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Events;
using Alis.Core.Ecs.Memory;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs
{
    partial struct GameObject
    {
        

        /// <summary>
        /// Adds a component to this <see cref="GameObject"/>.
        /// </summary>
        /// <remarks>If the world is being updated, changed are deffered to the end of the world update.</remarks>
        [SkipLocalsInit]
        public void Add<T1, T2>(in T1 c1, in T2 c2)
        {
            ref EntityLocation thisLookup = ref AssertIsAlive(out Scene world);

            if (!world.AllowStructualChanges)
            {
                world.WorldUpdateCommandBuffer.AddComponent(this, c1);
                world.WorldUpdateCommandBuffer.AddComponent(this, c2);

                return;
            }

            Archetype to = TraverseThroughCacheOrCreate<ComponentID, NeighborCache<T1, T2>>(
                world,
                ref NeighborCache<T1, T2>.Add.Lookup,
                ref thisLookup,
                true);

            Span<ComponentStorageBase> buff = [null!, null!];
            world.MoveEntityToArchetypeAdd(buff, this, ref thisLookup, out EntityLocation nextLocation, to);

            ref var c1ref = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T1>>(buff.UnsafeSpanIndex(1 - 1))[nextLocation.Index]; c1ref = c1;
            ref var c2ref = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T2>>(buff.UnsafeSpanIndex(2 - 1))[nextLocation.Index]; c2ref = c2;


            Component<T1>.Initer?.Invoke(this, ref c1ref);
            Component<T2>.Initer?.Invoke(this, ref c2ref);


            EntityFlags flags = thisLookup.Flags;
            if (EntityLocation.HasEventFlag(flags | world.WorldEventFlags, EntityFlags.AddComp | EntityFlags.AddGenericComp))
            {
                if (world.ComponentAddedEvent.HasListeners)
                    InvokeComponentWorldEvents<T1, T2>(ref world.ComponentAddedEvent, this);

                if (EntityLocation.HasEventFlag(flags, EntityFlags.AddComp | EntityFlags.AddGenericComp))
                {
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && !NET6_0_OR_GREATER
                EventRecord events = world.EventLookup[EntityIdOnly];
#else
                    ref EventRecord events = ref CollectionsMarshal.GetValueRefOrNullRef(world.EventLookup, EntityIdOnly);
#endif
                    InvokePerEntityEvents(this, EntityLocation.HasEventFlag(thisLookup.Flags, EntityFlags.AddGenericComp), ref events.Add, ref c1ref);
                }
            }
        }

        /// <summary>
        /// Removes a component from this <see cref="GameObject"/>
        /// </summary>
        /// <inheritdoc cref="Add{T}(in T)"/>
        [SkipLocalsInit]
        public void Remove<T1, T2>()
        {
            ref EntityLocation thisLookup = ref AssertIsAlive(out Scene world);

            if (!world.AllowStructualChanges)
            {
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T1>.ID);
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T2>.ID);

                return;
            }

            Archetype to = TraverseThroughCacheOrCreate<ComponentID, NeighborCache<T1, T2>>(
                world,
                ref NeighborCache<T1, T2>.Remove.Lookup,
                ref thisLookup,
                false);

            Span<ComponentHandle> runners = stackalloc ComponentHandle[2];
            world.MoveEntityToArchetypeRemove(runners, this, ref thisLookup, to);
            //world.MoveEntityToArchetypeRemove invokes the events for us
        }

        private static void InvokeComponentWorldEvents<T1, T2>(ref Event<ComponentID> @event, GameObject gameObject)
        {
            @event.InvokeInternal(gameObject, Component<T1>.ID);
            @event.InvokeInternal(gameObject, Component<T2>.ID);

        }

        private static void InvokePerEntityEvents<T1, T2>(GameObject gameObject, bool hasGenericEvent, ref ComponentEvent events, ref T1 component1, ref T2 component2)
        {
            events.NormalEvent.Invoke(gameObject, Component<T1>.ID);
            events.NormalEvent.Invoke(gameObject, Component<T2>.ID);


            if (!hasGenericEvent)
                return;

            events.GenericEvent!.Invoke(gameObject, ref component1);
            events.GenericEvent!.Invoke(gameObject, ref component2);

        }


        private struct NeighborCache<T1, T2> : IArchetypeGraphEdge
        {
            public void ModifyTags(ref FastImmutableArray<TagId> tags, bool add)
            {
                if (add)
                {
                    tags = MemoryHelpers.Concat(tags, [Ecs.Tag<T1>.ID, Ecs.Tag<T2>.ID]);
                }
                else
                {
                    tags = MemoryHelpers.Remove(tags, [Ecs.Tag<T1>.ID, Ecs.Tag<T2>.ID]);
                }
            }

            public void ModifyComponents(ref FastImmutableArray<ComponentID> components, bool add)
            {
                if (add)
                {
                    components = MemoryHelpers.Concat(components, [Component<T1>.ID, Component<T2>.ID]);
                }
                else
                {
                    components = MemoryHelpers.Remove(components, [Component<T1>.ID, Component<T2>.ID]);
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
}
