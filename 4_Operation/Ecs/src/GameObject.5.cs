// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObject.5.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Arch;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Events;
using Alis.Core.Ecs.Marshalling;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs
{
    /// <summary>
    /// The game object
    /// </summary>
    partial struct GameObject
    {
        /// <summary>
        ///     Adds a component to this <see cref="GameObject" />.
        /// </summary>
        /// <remarks>If the world is being updated, changed are deffered to the end of the world update.</remarks>
        [SkipLocalsInit]
        public void Add<T1, T2, T3, T4, T5>(in T1 c1, in T2 c2, in T3 c3, in T4 c4, in T5 c5)
        {
            ref EntityLocation thisLookup = ref AssertIsAlive(out Scene world);

            if (!world.AllowStructualChanges)
            {
                world.WorldUpdateCommandBuffer.AddComponent(this, c1);
                world.WorldUpdateCommandBuffer.AddComponent(this, c2);
                world.WorldUpdateCommandBuffer.AddComponent(this, c3);
                world.WorldUpdateCommandBuffer.AddComponent(this, c4);
                world.WorldUpdateCommandBuffer.AddComponent(this, c5);

                return;
            }

            Archetype to = TraverseThroughCacheOrCreate<ComponentID, NeighborCache<T1, T2, T3, T4, T5>>(
                world,
                ref NeighborCache<T1, T2, T3, T4, T5>.Add.Lookup,
                ref thisLookup,
                true);

            Span<ComponentStorageBase> buff = [null!, null!, null!, null!, null!];
            world.MoveEntityToArchetypeAdd(buff, this, ref thisLookup, out EntityLocation nextLocation, to);

            ref var c1ref = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T1>>(buff.UnsafeSpanIndex(1 - 1))[nextLocation.Index];
            c1ref = c1;
            ref var c2ref = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T2>>(buff.UnsafeSpanIndex(2 - 1))[nextLocation.Index];
            c2ref = c2;
            ref var c3ref = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T3>>(buff.UnsafeSpanIndex(3 - 1))[nextLocation.Index];
            c3ref = c3;
            ref var c4ref = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T4>>(buff.UnsafeSpanIndex(4 - 1))[nextLocation.Index];
            c4ref = c4;
            ref var c5ref = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T5>>(buff.UnsafeSpanIndex(5 - 1))[nextLocation.Index];
            c5ref = c5;


            Component<T1>.Initer?.Invoke(this, ref c1ref);
            Component<T2>.Initer?.Invoke(this, ref c2ref);
            Component<T3>.Initer?.Invoke(this, ref c3ref);
            Component<T4>.Initer?.Invoke(this, ref c4ref);
            Component<T5>.Initer?.Invoke(this, ref c5ref);


            EntityFlags flags = thisLookup.Flags;
            if (EntityLocation.HasEventFlag(flags | world.WorldEventFlags, EntityFlags.AddComp | EntityFlags.AddGenericComp))
            {
                if (world.ComponentAddedEvent.HasListeners)
                {
                    InvokeComponentWorldEvents<T1, T2, T3, T4, T5>(ref world.ComponentAddedEvent, this);
                }

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
        ///     Removes a component from this <see cref="GameObject" />
        /// </summary>
        /// <inheritdoc cref="NeighborCache{T}.Add" />
        [SkipLocalsInit]
        public void Remove<T1, T2, T3, T4, T5>()
        {
            ref EntityLocation thisLookup = ref AssertIsAlive(out Scene world);

            if (!world.AllowStructualChanges)
            {
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T1>.ID);
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T2>.ID);
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T3>.ID);
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T4>.ID);
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T5>.ID);

                return;
            }

            Archetype to = TraverseThroughCacheOrCreate<ComponentID, NeighborCache<T1, T2, T3, T4, T5>>(
                world,
                ref NeighborCache<T1, T2, T3, T4, T5>.Remove.Lookup,
                ref thisLookup,
                false);

            Span<ComponentHandle> runners = stackalloc ComponentHandle[5];
            world.MoveEntityToArchetypeRemove(runners, this, ref thisLookup, to);
            //world.MoveEntityToArchetypeRemove invokes the events for us
        }

        /// <summary>
        /// Invokes the component world events using the specified event
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <param name="@event">The event</param>
        /// <param name="gameObject">The game object</param>
        private static void InvokeComponentWorldEvents<T1, T2, T3, T4, T5>(ref Event<ComponentID> @event, GameObject gameObject)
        {
            @event.InvokeInternal(gameObject, Component<T1>.ID);
            @event.InvokeInternal(gameObject, Component<T2>.ID);
            @event.InvokeInternal(gameObject, Component<T3>.ID);
            @event.InvokeInternal(gameObject, Component<T4>.ID);
            @event.InvokeInternal(gameObject, Component<T5>.ID);
        }

        /// <summary>
        /// Invokes the per entity events using the specified game object
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <param name="gameObject">The game object</param>
        /// <param name="hasGenericEvent">The has generic event</param>
        /// <param name="events">The events</param>
        /// <param name="component1">The component</param>
        /// <param name="component2">The component</param>
        /// <param name="component3">The component</param>
        /// <param name="component4">The component</param>
        /// <param name="component5">The component</param>
        private static void InvokePerEntityEvents<T1, T2, T3, T4, T5>(GameObject gameObject, bool hasGenericEvent, ref ComponentEvent events, ref T1 component1, ref T2 component2, ref T3 component3, ref T4 component4, ref T5 component5)
        {
            events.NormalEvent.Invoke(gameObject, Component<T1>.ID);
            events.NormalEvent.Invoke(gameObject, Component<T2>.ID);
            events.NormalEvent.Invoke(gameObject, Component<T3>.ID);
            events.NormalEvent.Invoke(gameObject, Component<T4>.ID);
            events.NormalEvent.Invoke(gameObject, Component<T5>.ID);


            if (!hasGenericEvent)
            {
                return;
            }

            events.GenericEvent!.Invoke(gameObject, ref component1);
            events.GenericEvent!.Invoke(gameObject, ref component2);
            events.GenericEvent!.Invoke(gameObject, ref component3);
            events.GenericEvent!.Invoke(gameObject, ref component4);
            events.GenericEvent!.Invoke(gameObject, ref component5);
        }

        /// <summary>
        /// The neighbor cache
        /// </summary>
        private struct NeighborCache<T1, T2, T3, T4, T5> : IArchetypeGraphEdge
        {
            /// <summary>
            /// Modifies the tags using the specified tags
            /// </summary>
            /// <param name="tags">The tags</param>
            /// <param name="add">The add</param>
            public void ModifyTags(ref FastImmutableArray<TagId> tags, bool add)
            {
                if (add)
                {
                    tags = MemoryHelpers.Concat(tags, [Ecs.Tag<T1>.ID, Ecs.Tag<T2>.ID, Ecs.Tag<T3>.ID, Ecs.Tag<T4>.ID, Ecs.Tag<T5>.ID]);
                }
                else
                {
                    tags = MemoryHelpers.Remove(tags, [Ecs.Tag<T1>.ID, Ecs.Tag<T2>.ID, Ecs.Tag<T3>.ID, Ecs.Tag<T4>.ID, Ecs.Tag<T5>.ID]);
                }
            }

            /// <summary>
            /// Modifies the components using the specified components
            /// </summary>
            /// <param name="components">The components</param>
            /// <param name="add">The add</param>
            public void ModifyComponents(ref FastImmutableArray<ComponentID> components, bool add)
            {
                if (add)
                {
                    components = MemoryHelpers.Concat(components, [Component<T1>.ID, Component<T2>.ID, Component<T3>.ID, Component<T4>.ID, Component<T5>.ID]);
                }
                else
                {
                    components = MemoryHelpers.Remove(components, [Component<T1>.ID, Component<T2>.ID, Component<T3>.ID, Component<T4>.ID, Component<T5>.ID]);
                }
            }

            //separate into individual classes to avoid creating uneccecary static classes.

            /// <summary>
            /// The add class
            /// </summary>
            internal static class Add
            {
                /// <summary>
                /// The lookup
                /// </summary>
                internal static ArchetypeNeighborCache Lookup;
            }

            /// <summary>
            /// The remove class
            /// </summary>
            internal static class Remove
            {
                /// <summary>
                /// The lookup
                /// </summary>
                internal static ArchetypeNeighborCache Lookup;
            }

            /// <summary>
            /// The tag class
            /// </summary>
            internal static class Tag
            {
                /// <summary>
                /// The lookup
                /// </summary>
                internal static ArchetypeNeighborCache Lookup;
            }

            /// <summary>
            /// The detach class
            /// </summary>
            internal static class Detach
            {
                /// <summary>
                /// The lookup
                /// </summary>
                internal static ArchetypeNeighborCache Lookup;
            }
        }
    }
}