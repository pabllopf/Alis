using System;
using Frent.Collections;
using Frent.Core;
using Frent.Core.Events;
using Frent.Updating;
using Frent.Updating.Runners;

using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Frent;



















/// <summary>
/// The entity
/// </summary>
partial struct Entity
{
    //traversing archetype graph strategy:
    //1. hit small & fast static per type cache - 1 branch
    //2. dictionary lookup
    //3. find existing archetype
    //4. create new archetype

    /// <summary>
    /// Adds a component to this <see cref="Entity"/>.
    /// </summary>
    /// <remarks>If the world is being updated, changed are deffered to the end of the world update.</remarks>
    [Frent.SkipLocalsInit]
    public void Add<T>(in T c1)
    {
        ref EntityLocation thisLookup = ref AssertIsAlive(out World world);

        if (!world.AllowStructualChanges)
        {
            world.WorldUpdateCommandBuffer.AddComponent(this, c1);
            return;
        }

        Archetype to = TraverseThroughCacheOrCreate<ComponentID, NeighborCache<T>>(
            world,
            ref NeighborCache<T>.Add.Lookup,
            ref thisLookup,
            true);

        Span<ComponentStorageBase> buff = [null!];
        world.MoveEntityToArchetypeAdd(buff, this, ref thisLookup, out EntityLocation nextLocation, to);

        ref var c1ref = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T>>(buff.UnsafeSpanIndex(0))[nextLocation.Index]; c1ref = c1;

        Component<T>.Initer?.Invoke(this, ref c1ref);

        EntityFlags flags = thisLookup.Flags;
        if (EntityLocation.HasEventFlag(flags | world.WorldEventFlags, EntityFlags.AddComp | EntityFlags.AddGenericComp))
        {
            if (world.ComponentAddedEvent.HasListeners)
                InvokeComponentWorldEvents<T>(ref world.ComponentAddedEvent, this);

            if (EntityLocation.HasEventFlag(flags, EntityFlags.AddComp | EntityFlags.AddGenericComp))
            {
                EventRecord events = world.EventLookup[EntityIDOnly];
                InvokePerEntityEvents(this, EntityLocation.HasEventFlag(thisLookup.Flags, EntityFlags.AddGenericComp), ref events.Add, ref c1ref);
            }
        }
    }

    /// <summary>
    /// Removes a component from this <see cref="Entity"/>
    /// </summary>
    /// <inheritdoc cref="Add{T}(in T)"/>
    [Frent.SkipLocalsInit]
    public void Remove<T>()
    {
        ref EntityLocation thisLookup = ref AssertIsAlive(out World world);

        if (!world.AllowStructualChanges)
        {
            world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T>.ID);
            return;
        }

        Archetype to = TraverseThroughCacheOrCreate<ComponentID, NeighborCache<T>>(
            world,
            ref NeighborCache<T>.Remove.Lookup,
            ref thisLookup,
            false);

        Span<ComponentHandle> runners = stackalloc ComponentHandle[1];
        world.MoveEntityToArchetypeRemove(runners, this, ref thisLookup, to);
        //world.MoveEntityToArchetypeRemove invokes the events for us
    }

    /// <summary>
    /// Adds a tag to this <see cref="Entity"/>
    /// </summary>
    /// <inheritdoc cref="Add{T}(in T)"/>
    [Frent.SkipLocalsInit]
    public void Tag<T>()
    {
        ref EntityLocation thisLookup = ref AssertIsAlive(out World world);

        Archetype to = TraverseThroughCacheOrCreate<TagID, NeighborCache<T>>(
            world,
            ref NeighborCache<T>.Tag.Lookup,
            ref thisLookup,
            true);

        world.MoveEntityToArchetypeIso(this, ref thisLookup, to);

        EntityFlags flags = thisLookup.Flags | world.WorldEventFlags;
        if (EntityLocation.HasEventFlag(flags, EntityFlags.Tagged))
        {
            if (world.Tagged.HasListeners)
                InvokeTagWorldEvents<T>(ref world.Tagged, this);

            if (EntityLocation.HasEventFlag(flags, EntityFlags.Tagged))
            {
                EventRecord events = world.EventLookup[EntityIDOnly];
                InvokePerEntityTagEvents<T>(this, ref events.Tag);
            }
        }
    }

    /// <summary>
    /// Removes a tag from this <see cref="Entity"/>
    /// </summary>
    /// <inheritdoc cref="Add{T}(in T)"/>
    [Frent.SkipLocalsInit]
    public void Detach<T>()
    {
        ref EntityLocation thisLookup = ref AssertIsAlive(out World world);

        Archetype to = TraverseThroughCacheOrCreate<TagID, NeighborCache<T>>(
            world,
            ref NeighborCache<T>.Detach.Lookup,
            ref thisLookup,
            false);

        world.MoveEntityToArchetypeIso(this, ref thisLookup, to);

        EntityFlags flags = thisLookup.Flags | world.WorldEventFlags;
        if (EntityLocation.HasEventFlag(flags, EntityFlags.Detach))
        {
            if (world.Detached.HasListeners)
                InvokeTagWorldEvents<T>(ref world.Detached, this);

            if (EntityLocation.HasEventFlag(flags, EntityFlags.Detach))
            {
                EventRecord events = world.EventLookup[EntityIDOnly];
                InvokePerEntityTagEvents<T>(this, ref events.Detach);
            }
        }
    }

    /// <summary>
    /// Invokes the component world events using the specified event
    /// </summary>
    /// <typeparam name="T">The </typeparam>
    /// <param name="@event">The event</param>
    /// <param name="entity">The entity</param>
    private static void InvokeComponentWorldEvents<T>(ref Event<ComponentID> @event, Entity entity)
    {
        @event.InvokeInternal(entity, Component<T>.ID);
    }

    /// <summary>
    /// Invokes the per entity events using the specified entity
    /// </summary>
    /// <typeparam name="T">The </typeparam>
    /// <param name="entity">The entity</param>
    /// <param name="hasGenericEvent">The has generic event</param>
    /// <param name="events">The events</param>
    /// <param name="component">The component</param>
    private static void InvokePerEntityEvents<T>(Entity entity, bool hasGenericEvent, ref ComponentEvent events, ref T component)
    {
        events.NormalEvent.Invoke(entity, Component<T>.ID);

        if (!hasGenericEvent)
            return;

        events.GenericEvent!.Invoke(entity, ref component);
    }

    /// <summary>
    /// Invokes the tag world events using the specified event
    /// </summary>
    /// <typeparam name="T">The </typeparam>
    /// <param name="@event">The event</param>
    /// <param name="entity">The entity</param>
    private static void InvokeTagWorldEvents<T>(ref TagEvent @event, Entity entity)
    {
        @event.InvokeInternal(entity, Core.Tag<T>.ID);
    }

    /// <summary>
    /// Invokes the per entity tag events using the specified entity
    /// </summary>
    /// <typeparam name="T">The </typeparam>
    /// <param name="entity">The entity</param>
    /// <param name="events">The events</param>
    private static void InvokePerEntityTagEvents<T>(Entity entity, ref TagEvent events)
    {
        events.Invoke(entity, Core.Tag<T>.ID);
    }

    /// <summary>
    /// The neighbor cache
    /// </summary>
    private struct NeighborCache<T> : IArchetypeGraphEdge
    {
        /// <summary>
        /// Modifies the tags using the specified tags
        /// </summary>
        /// <param name="tags">The tags</param>
        /// <param name="add">The add</param>
        public void ModifyTags(ref ImmutableArray<TagID> tags, bool add)
        {
            if (add)
            {
                tags = MemoryHelpers.Concat(tags, Core.Tag<T>.ID);
            }
            else
            {
                tags = MemoryHelpers.Remove(tags, Core.Tag<T>.ID);
            }
        }

        /// <summary>
        /// Modifies the components using the specified components
        /// </summary>
        /// <param name="components">The components</param>
        /// <param name="add">The add</param>
        public void ModifyComponents(ref ImmutableArray<ComponentID> components, bool add)
        {
            if (add)
            {
                components = MemoryHelpers.Concat(components, Component<T>.ID);
            }
            else
            {
                components = MemoryHelpers.Remove(components, Component<T>.ID);
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

/// <summary>
/// The entity
/// </summary>
partial struct Entity
{
    /// <summary>
    /// Traverses the through cache or create using the specified world
    /// </summary>
    /// <typeparam name="T">The </typeparam>
    /// <typeparam name="TEdge">The edge</typeparam>
    /// <param name="world">The world</param>
    /// <param name="cache">The cache</param>
    /// <param name="currentLookup">The current lookup</param>
    /// <param name="add">The add</param>
    /// <returns>The archetype</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static Archetype TraverseThroughCacheOrCreate<T, TEdge>(
        World world,
        ref ArchetypeNeighborCache cache,
        ref EntityLocation currentLookup,
        bool add)
            where T : ITypeID
            where TEdge : struct, IArchetypeGraphEdge
    {
        ArchetypeID archetypeFromID = currentLookup.ArchetypeID;
        int index = cache.Traverse(archetypeFromID.RawIndex);

        if (index == 32)
        {
            return NotInCache(world, ref cache, archetypeFromID, add);
        }
        else
        {
            return Archetype.CreateOrGetExistingArchetype(new EntityType(cache.Lookup(index)), world);
        }

        static Archetype NotInCache(World world, ref ArchetypeNeighborCache cache, ArchetypeID archetypeFromID, bool add)
        {
            ImmutableArray<ComponentID> componentIDs = archetypeFromID.Types;
            ImmutableArray<TagID> tagIDs = archetypeFromID.Tags;

            if (typeof(T) == typeof(ComponentID))
            {
                default(TEdge).ModifyComponents(ref componentIDs, add);
            }
            else
            {
                default(TEdge).ModifyTags(ref tagIDs, add);
            }

            Archetype archetype = Archetype.CreateOrGetExistingArchetype(
                componentIDs.AsSpan(),
                tagIDs.AsSpan(),
                world,
                componentIDs,
                tagIDs);

            cache.Set(archetypeFromID.RawIndex, archetype.ID.RawIndex);

            return archetype;
        }
    }

    /// <summary>
    /// The archetype graph edge interface
    /// </summary>
    internal interface IArchetypeGraphEdge
    {
        /// <summary>
        /// Modifies the tags using the specified tags
        /// </summary>
        /// <param name="tags">The tags</param>
        /// <param name="add">The add</param>
        void ModifyTags(ref ImmutableArray<TagID> tags, bool add);
        /// <summary>
        /// Modifies the components using the specified components
        /// </summary>
        /// <param name="components">The components</param>
        /// <param name="add">The add</param>
        void ModifyComponents(ref ImmutableArray<ComponentID> components, bool add);
    }
}