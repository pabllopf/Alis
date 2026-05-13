// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObject.cs
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
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Exceptions;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Redifinition;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     A lightweight identifier that represents an entity in the ECS (Entity Component System) architecture.
    /// </summary>
    /// <typeparam name="GameObject">The GameObject type parameter.</typeparam>
    /// <remarks>
    ///     <para>
    ///     In the ECS pattern, an entity is simply an ID that identifies a collection of components.
    ///     Components hold data, while systems provide logic. This struct serves as the primary handle
    ///     for accessing and manipulating game objects within a <see cref="Scene" />.
    ///     </para>
    ///     <para>
    ///     The struct is designed for value-type performance: 8 bytes total (int + ushort + ushort),
    ///     with no padding due to <c>Pack = 1</c>. The fields are laid out as: EntityID (4 bytes),
    ///     EntityVersion (2 bytes), WorldID (2 bytes).
    ///     </para>
    ///     <para>
    ///     The version field enables safe handling of recycled entity IDs, preventing access to
    ///     deleted entities through compile-time and runtime validation.
    ///     </para>
    ///     <example>
    ///     <code>
    ///     // Create a new entity with components
    ///     var scene = new Scene();
    ///     var player = scene.Create(new Transform(), new Health { Value = 100 });
    ///     
    ///     // Add a component
    ///     player.Add(new Velocity { X = 5, Y = 10 });
    ///     
    ///     // Get a component (returns default if not present)
    ///     ref var health = ref player.Get&lt;Health&gt;();
    ///     
    ///     // Check if entity is alive
    ///     if (player.IsAlive())
    ///     {
    ///         // Modify components
    ///     }
    ///     </code>
    ///     </example>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GameObject : IEquatable<GameObject>, IGameObject
    {
        /// <summary>
        ///     Creates an <see cref="GameObject" /> identical to <see cref="GameObject.Null" />
        /// </summary>
        /// <remarks><see cref="GameObject" /> generally shouldn't manually constructed</remarks>
        public GameObject()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameObject" /> class
        /// </summary>
        /// <param name="worldId">The scene id</param>
        /// <param name="version">The version</param>
        /// <param name="entityId">The gameObject id</param>
        internal GameObject(ushort worldId, ushort version, int entityId)
        {
            WorldID = worldId;
            EntityVersion = version;
            EntityID = entityId;
        }

        //WARNING
        //DO NOT CHANGE STRUCT LAYOUT
        /// <summary>
        ///     Gets or sets the unique identifier for this entity within its scene.
        /// </summary>
        /// <value>
        ///     An integer that uniquely identifies the entity. When the entity is deleted,
        ///     this ID may be recycled for new entities.
        /// </value>
        internal int EntityID;

        /// <summary>
        ///     Gets or sets the version number of this entity.
        /// </summary>
        /// <value>
        ///     A version counter that increments each time the entity is deleted. This enables
        ///     detecting stale references to recycled entity IDs.
        /// </value>
        internal ushort EntityVersion;

        /// <summary>
        ///     Gets or sets the scene identifier that owns this entity.
        /// </summary>
        /// <value>
        ///     The unique identifier of the <see cref="Scene" /> that contains this entity.
        /// </value>
        internal ushort WorldID;


        /// <summary>
        ///     Gets the value of the gameObject id only
        /// </summary>
        internal GameObjectIdOnly EntityIdOnly => Unsafe.As<GameObject, EntityWorldInfoAccess>(ref this).EntityIDOnly;

        /// <summary>
        ///     Gets the value of the packed value
        /// </summary>
        internal long PackedValue => Unsafe.As<GameObject, long>(ref this);

        /// <summary>
        ///     Gets the value of the gameObject low
        /// </summary>
        internal int EntityLow => Unsafe.As<GameObject, EntityHighLow>(ref this).EntityLow;


        /// <summary>
        ///     Checks if this entity is still valid and alive in its scene.
        /// </summary>
        /// <param name="scene">When this method returns, contains the <see cref="Scene"/> this entity belongs to, or <see langword="null"/> if invalid.</param>
        /// <param name="gameObjectLocation">When this method returns, contains the entity's location data if alive; otherwise, default.</param>
        /// <returns>
        ///     <see langword="true"/> if the entity is alive and belongs to a valid scene;
        ///     <see langword="false"/> if the entity has been deleted or its scene no longer exists.
        /// </returns>
        /// <remarks>
        ///     This method verifies both that the scene exists and that the entity's version matches
        ///     the current version in the scene's entity table. This handles the case where entity
        ///     IDs are recycled after deletion.
        /// </remarks>
        internal bool InternalIsAlive(out Scene scene, out GameObjectLocation gameObjectLocation)
        {
            scene = GlobalWorldTables.Worlds.UnsafeIndexNoResize(WorldID);
            if (scene is null)
            {
                gameObjectLocation = default(GameObjectLocation);
                return false;
            }

            gameObjectLocation = scene.EntityTable.UnsafeIndexNoResize(EntityID);
            return gameObjectLocation.Version == EntityVersion;
        }

        /// <exception cref="InvalidOperationException">This <see cref="GameObject" /> has been deleted.</exception>
        /// <returns>The result of the operation.</returns>
        internal ref GameObjectLocation AssertIsAlive(out Scene scene)
        {
            scene = GlobalWorldTables.Worlds.UnsafeIndexNoResize(WorldID);
            //hardware trap
            ref GameObjectLocation lookup = ref scene.EntityTable.UnsafeIndexNoResize(EntityID);
            if (lookup.Version != EntityVersion)
            {
                Throw_EntityIsDead();
            }

            return ref lookup;
        }


        /// <summary>
        ///     Attempts to retrieve a reference to the component of type <typeparamref name="T"/> attached to this entity.
        /// </summary>
        /// <typeparam name="T">The type of component to retrieve.</typeparam>
        /// <param name="exists">
        ///     When this method returns, contains <see langword="true"/> if the component exists;
        ///     otherwise, <see langword="false"/>.
        /// </param>
        /// <returns>
        ///     A <see cref="Ref{T}"/> that provides direct access to the component data.
        ///     If the component does not exist, returns a default <see cref="Ref{T}"/> and <paramref name="exists"/> is <see langword="false"/>.
        /// </returns>
        /// <remarks>
        ///     This method is safe to call on destroyed entities - it will return with <paramref name="exists"/> set to <see langword="false"/>
        ///     rather than throwing an exception.
        /// </remarks>
        /// <example>
        /// <code>
        /// if (player.TryGetCore&lt;Health&gt;(out bool hasHealth))
        /// {
        ///     ref var health = ref player.Get&lt;Health&gt;();
        ///     health.Value -= damage;
        /// }
        /// </code>
        /// </example>
        public Ref<T> TryGetCore<T>(out bool exists)
        {
            if (!InternalIsAlive(out Scene _, out GameObjectLocation entityLocation))
            {
                goto doesntExist;
            }

            int compIndex = GlobalWorldTables.ComponentIndex(entityLocation.ArchetypeId, Component<T>.Id);

            if (compIndex == 0)
            {
                goto doesntExist;
            }

            exists = true;
            ComponentStorage<T> storage = Unsafe.As<ComponentStorage<T>>(
                Unsafe.Add(ref entityLocation.Archetype.Components[0], compIndex));

            return new Ref<T>(storage, entityLocation.Index);

            doesntExist:
            exists = false;
            return default(Ref<T>);
        }

        /// <summary>
        ///     Throws the gameObject is dead
        /// </summary>
        public static void Throw_EntityIsDead()
        {
            throw new InvalidOperationException(EntityIsDeadMessage);
        }

        /// <summary>
        ///     The gameObject is dead message
        /// </summary>
        internal const string EntityIsDeadMessage = "GameObject is dead.";

        /// <summary>
        ///     The does not have tag message
        /// </summary>
        internal const string DoesNotHaveTagMessage = "This gameObject does not have this tag";


        /// <summary>
        ///     Checks if two <see cref="GameObject" /> structs refer to the same gameObject.
        /// </summary>
        /// <param name="a">The first gameObject to compare.</param>
        /// <param name="b">The second gameObject to compare.</param>
        /// <returns><see langword="true" /> if the entities refer to the same gameObject; otherwise, <see langword="false" />.</returns>
        public static bool operator ==(GameObject a, GameObject b) => a.Equals(b);

        /// <summary>
        ///     Checks if two <see cref="GameObject" /> structs do not refer to the same gameObject.
        /// </summary>
        /// <param name="a">The first gameObject to compare.</param>
        /// <param name="b">The second gameObject to compare.</param>
        /// <returns>
        ///     <see langword="true" /> if the entities do not refer to the same gameObject; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        public static bool operator !=(GameObject a, GameObject b) => !a.Equals(b);

        /// <summary>
        ///     Determines whether the specified object is equal to the current <see cref="GameObject" />.
        /// </summary>
        /// <param name="obj">The object to compare with the current gameObject.</param>
        /// <returns>
        ///     <see langword="true" /> if the specified object is an <see cref="GameObject" /> and is equal to the current
        ///     gameObject; otherwise, <see langword="false" />.
        /// </returns>
        public override bool Equals(object obj) => obj is GameObject entity && Equals(entity);

        /// <summary>
        ///     Determines whether the specified <see cref="GameObject" /> is equal to the current <see cref="GameObject" />.
        /// </summary>
        /// <param name="other">The gameObject to compare with the current gameObject.</param>
        /// <returns>
        ///     <see langword="true" /> if the specified gameObject is equal to the current gameObject; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        public bool Equals(GameObject other) => other.PackedValue == PackedValue;

        /// <summary>
        ///     Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current <see cref="GameObject" />.</returns>
        public override int GetHashCode() => PackedValue.GetHashCode();


        /// <summary>
        ///     Adds a component to this <see cref="GameObject" />.
        /// </summary>
        /// <remarks>If the scene is being updated, changed are deffered to the end of the scene update.</remarks>
        public void Add<T>(in T c1)
        {
            ref GameObjectLocation thisLookup = ref AssertIsAlive(out Scene world);

            if (!world.AllowStructualChanges)
            {
                world.WorldUpdateCommandBuffer.AddComponent(this, c1);
                return;
            }

            Archetype to = TraverseThroughCacheOrCreate<NeighborCache<T>>(
                world,
                ref NeighborCacheAdd<T>.Lookup,
                ref thisLookup,
                true);

            Span<ComponentStorageBase> buff = [null!];
            world.MoveEntityToArchetypeAdd(buff, this, ref thisLookup, out GameObjectLocation nextLocation, to);

            ref T c1Ref = ref Unsafe.As<ComponentStorage<T>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 0))[nextLocation.Index];
            c1Ref = c1;

            Component<T>.Initer?.Invoke(this, ref c1Ref);

            GameObjectFlags flags = thisLookup.Flags;
            if (GameObjectLocation.HasEventFlag(flags | world.WorldEventFlags,
                    GameObjectFlags.AddComp | GameObjectFlags.AddGenericComp))
            {
                if (world.ComponentAddedEvent.HasListeners)
                {
                    InvokeComponentWorldEvents<T>(ref world.ComponentAddedEvent, this);
                }

                if (GameObjectLocation.HasEventFlag(flags, GameObjectFlags.AddComp | GameObjectFlags.AddGenericComp))
                {
                    EventRecord events = world.EventLookup[EntityIdOnly];

                    InvokePerEntityEvents(this, GameObjectLocation.HasEventFlag(thisLookup.Flags, GameObjectFlags.AddGenericComp),
                        ref events.Add, ref c1Ref);
                }
            }
        }

        /// <summary>
        ///     Removes a component from this <see cref="GameObject" />
        /// </summary>
        /// <inheritdoc cref="Add{T}(in T)" />
        public void Remove<T>()
        {
            ref GameObjectLocation thisLookup = ref AssertIsAlive(out Scene world);

            if (!world.AllowStructualChanges)
            {
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T>.Id);
                return;
            }

            Archetype to = TraverseThroughCacheOrCreate<NeighborCache<T>>(
                world,
                ref NeighborCacheRemove<T>.Lookup,
                ref thisLookup,
                false);

            Span<ComponentHandle> runners = stackalloc ComponentHandle[1];
            world.MoveEntityToArchetypeRemove(runners, this, ref thisLookup, to);
        }

        /// <summary>
        ///     Invokes the component scene events using the specified event
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="e">The event</param>
        /// <param name="gameObject">The gameObject</param>
        public static void InvokeComponentWorldEvents<T>(ref Event<ComponentId> e, GameObject gameObject)
        {
            e.InvokeInternal(gameObject, Component<T>.Id);
        }

        /// <summary>
        ///     Invokes the per gameObject events using the specified gameObject
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="gameObject">The gameObject</param>
        /// <param name="hasGenericEvent">The has generic event</param>
        /// <param name="events">The events</param>
        /// <param name="component">The component</param>
        public static void InvokePerEntityEvents<T>(GameObject gameObject, bool hasGenericEvent, ref ComponentEvent events,
            ref T component)
        {
            events.NormalEvent.Invoke(gameObject, Component<T>.Id);

            if (!hasGenericEvent)
            {
                return;
            }

            events.GenericEvent!.Invoke(gameObject, ref component);
        }


        /// <summary>
        ///     Traverses the through cache or create using the specified scene
        /// </summary>
        /// <typeparam name="TEdge">The edge</typeparam>
        /// <param name="scene">The scene</param>
        /// <param name="cache">The cache</param>
        /// <param name="currentLookup">The current lookup</param>
        /// <param name="add">The add</param>
        /// <returns>The archetype</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Archetype TraverseThroughCacheOrCreate<TEdge>(
            Scene scene,
            ref ArchetypeNeighborCache cache,
            ref GameObjectLocation currentLookup,
            bool add)
            where TEdge : struct, IArchetypeGraphEdge
        {
            GameObjectType archetypeFromId = currentLookup.ArchetypeId;
            int index = cache.Traverse(archetypeFromId.RawIndex);

            if (index == 32)
            {
                return NotInCache(scene, ref cache, archetypeFromId, add);
            }

            return Archetype.CreateOrGetExistingArchetype(new GameObjectType(cache.Lookup(index)), scene);

            static Archetype NotInCache(Scene scene, ref ArchetypeNeighborCache cache, GameObjectType archetypeFromId,
                bool add)
            {
                FastImmutableArray<ComponentId> componentIDs = archetypeFromId.Types;

                default(TEdge).ModifyComponents(ref componentIDs, add);

                Archetype archetype = Archetype.CreateOrGetExistingArchetype(
                    componentIDs.AsSpan(),
                    scene,
                    componentIDs);

                cache.Set(archetypeFromId.RawIndex, archetype.Id.RawIndex);

                return archetype;
            }
        }


        /// <summary>
        ///     Adds a component to this <see cref="GameObject" />.
        /// </summary>
        /// <remarks>If the scene is being updated, changed are deffered to the end of the scene update.</remarks>
        public void Add<T1, T2>(in T1 c1, in T2 c2)
        {
            ref GameObjectLocation thisLookup = ref AssertIsAlive(out Scene world);

            if (!world.AllowStructualChanges)
            {
                world.WorldUpdateCommandBuffer.AddComponent(this, c1);
                world.WorldUpdateCommandBuffer.AddComponent(this, c2);

                return;
            }

            Archetype to = TraverseThroughCacheOrCreate<NeighborCache<T1, T2>>(
                world,
                ref NeighborCacheAdd<T1, T2>.Lookup,
                ref thisLookup,
                true);

            Span<ComponentStorageBase> buff = [null!, null!];
            world.MoveEntityToArchetypeAdd(buff, this, ref thisLookup, out GameObjectLocation nextLocation, to);

            ref T1 c1Ref =
                ref Unsafe.As<ComponentStorage<T1>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 0))[nextLocation.Index];
            c1Ref = c1;
            ref T2 c2Ref =
                ref Unsafe.As<ComponentStorage<T2>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 1))[nextLocation.Index];
            c2Ref = c2;


            Component<T1>.Initer?.Invoke(this, ref c1Ref);
            Component<T2>.Initer?.Invoke(this, ref c2Ref);


            GameObjectFlags flags = thisLookup.Flags;
            if (GameObjectLocation.HasEventFlag(flags | world.WorldEventFlags,
                    GameObjectFlags.AddComp | GameObjectFlags.AddGenericComp))
            {
                if (world.ComponentAddedEvent.HasListeners)
                {
                    InvokeComponentWorldEvents<T1, T2>(ref world.ComponentAddedEvent, this);
                }

                if (GameObjectLocation.HasEventFlag(flags, GameObjectFlags.AddComp | GameObjectFlags.AddGenericComp))
                {
                    EventRecord events = world.EventLookup[EntityIdOnly];

                    InvokePerEntityEvents(this, GameObjectLocation.HasEventFlag(thisLookup.Flags, GameObjectFlags.AddGenericComp),
                        ref events.Add, ref c1Ref);
                }
            }
        }

        /// <summary>
        ///     Removes a component from this <see cref="GameObject" />
        /// </summary>
        /// <inheritdoc cref="Add{T}(in T)" />
        public void Remove<T1, T2>()
        {
            ref GameObjectLocation thisLookup = ref AssertIsAlive(out Scene world);

            if (!world.AllowStructualChanges)
            {
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T1>.Id);
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T2>.Id);

                return;
            }

            Archetype to = TraverseThroughCacheOrCreate<NeighborCache<T1, T2>>(
                world,
                ref NeighborCacheRemove<T1, T2>.Lookup,
                ref thisLookup,
                false);

            Span<ComponentHandle> runners = stackalloc ComponentHandle[2];
            world.MoveEntityToArchetypeRemove(runners, this, ref thisLookup, to);
            //scene.MoveEntityToArchetypeRemove invokes the events for us
        }


        /// <summary>
        ///     Invokes the component scene events using the specified event
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <param name="e">The event</param>
        /// <param name="gameObject">The gameObject</param>
        public static void InvokeComponentWorldEvents<T1, T2>(ref Event<ComponentId> e, GameObject gameObject)
        {
            e.InvokeInternal(gameObject, Component<T1>.Id);
            e.InvokeInternal(gameObject, Component<T2>.Id);
        }

        /// <summary>
        ///     Invokes the per gameObject events using the specified gameObject
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <param name="gameObject">The gameObject</param>
        /// <param name="hasGenericEvent">The has generic event</param>
        /// <param name="events">The events</param>
        /// <param name="component1">The component</param>
        /// <param name="component2">The component</param>
        public static void InvokePerEntityEvents<T1, T2>(GameObject gameObject, bool hasGenericEvent, ref ComponentEvent events,
            ref T1 component1, ref T2 component2)
        {
            events.NormalEvent.Invoke(gameObject, Component<T1>.Id);
            events.NormalEvent.Invoke(gameObject, Component<T2>.Id);


            if (!hasGenericEvent)
            {
                return;
            }

            events.GenericEvent!.Invoke(gameObject, ref component1);
            events.GenericEvent!.Invoke(gameObject, ref component2);
        }


        /// <summary>
        ///     Adds a component to this <see cref="GameObject" />.
        /// </summary>
        /// <remarks>If the scene is being updated, changed are deffered to the end of the scene update.</remarks>
        public void Add<T1, T2, T3>(in T1 c1, in T2 c2, in T3 c3)
        {
            ref GameObjectLocation thisLookup = ref AssertIsAlive(out Scene world);

            if (!world.AllowStructualChanges)
            {
                world.WorldUpdateCommandBuffer.AddComponent(this, c1);
                world.WorldUpdateCommandBuffer.AddComponent(this, c2);
                world.WorldUpdateCommandBuffer.AddComponent(this, c3);

                return;
            }

            Archetype to = TraverseThroughCacheOrCreate<NeighborCache<T1, T2, T3>>(
                world,
                ref NeighborCacheAdd<T1, T2, T3>.Lookup,
                ref thisLookup,
                true);

            Span<ComponentStorageBase> buff = [null!, null!, null!];
            world.MoveEntityToArchetypeAdd(buff, this, ref thisLookup, out GameObjectLocation nextLocation, to);

            ref T1 c1Ref =
                ref Unsafe.As<ComponentStorage<T1>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 0))[nextLocation.Index];
            c1Ref = c1;
            ref T2 c2Ref =
                ref Unsafe.As<ComponentStorage<T2>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 1))[nextLocation.Index];
            c2Ref = c2;
            ref T3 c3Ref =
                ref Unsafe.As<ComponentStorage<T3>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 2))[nextLocation.Index];
            c3Ref = c3;


            Component<T1>.Initer?.Invoke(this, ref c1Ref);
            Component<T2>.Initer?.Invoke(this, ref c2Ref);
            Component<T3>.Initer?.Invoke(this, ref c3Ref);


            GameObjectFlags flags = thisLookup.Flags;
            if (GameObjectLocation.HasEventFlag(flags | world.WorldEventFlags,
                    GameObjectFlags.AddComp | GameObjectFlags.AddGenericComp))
            {
                if (world.ComponentAddedEvent.HasListeners)
                {
                    InvokeComponentWorldEvents<T1, T2, T3>(ref world.ComponentAddedEvent, this);
                }

                if (GameObjectLocation.HasEventFlag(flags, GameObjectFlags.AddComp | GameObjectFlags.AddGenericComp))
                {
                    EventRecord events = world.EventLookup[EntityIdOnly];

                    InvokePerEntityEvents(this, GameObjectLocation.HasEventFlag(thisLookup.Flags, GameObjectFlags.AddGenericComp),
                        ref events.Add, ref c1Ref);
                }
            }
        }

        /// <summary>
        ///     Removes a component from this <see cref="GameObject" />
        /// </summary>
        /// <inheritdoc cref="Add{T}(in T)" />
        public void Remove<T1, T2, T3>()
        {
            ref GameObjectLocation thisLookup = ref AssertIsAlive(out Scene world);

            if (!world.AllowStructualChanges)
            {
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T1>.Id);
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T2>.Id);
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T3>.Id);

                return;
            }

            Archetype to = TraverseThroughCacheOrCreate<NeighborCache<T1, T2, T3>>(
                world,
                ref NeighborCacheRemove<T1, T2, T3>.Lookup,
                ref thisLookup,
                false);

            Span<ComponentHandle> runners = stackalloc ComponentHandle[3];
            world.MoveEntityToArchetypeRemove(runners, this, ref thisLookup, to);
            //scene.MoveEntityToArchetypeRemove invokes the events for us
        }

        /// <summary>
        ///     Invokes the component scene events using the specified event
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <param name="e">The event</param>
        /// <param name="gameObject">The gameObject</param>
        public static void InvokeComponentWorldEvents<T1, T2, T3>(ref Event<ComponentId> e, GameObject gameObject)
        {
            e.InvokeInternal(gameObject, Component<T1>.Id);
            e.InvokeInternal(gameObject, Component<T2>.Id);
            e.InvokeInternal(gameObject, Component<T3>.Id);
        }

        /// <summary>
        ///     Invokes the per gameObject events using the specified gameObject
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <param name="gameObject">The gameObject</param>
        /// <param name="hasGenericEvent">The has generic event</param>
        /// <param name="events">The events</param>
        /// <param name="component1">The component</param>
        /// <param name="component2">The component</param>
        /// <param name="component3">The component</param>
        public static void InvokePerEntityEvents<T1, T2, T3>(GameObject gameObject, bool hasGenericEvent,
            ref ComponentEvent events, ref T1 component1, ref T2 component2, ref T3 component3)
        {
            events.NormalEvent.Invoke(gameObject, Component<T1>.Id);
            events.NormalEvent.Invoke(gameObject, Component<T2>.Id);
            events.NormalEvent.Invoke(gameObject, Component<T3>.Id);


            if (!hasGenericEvent)
            {
                return;
            }

            events.GenericEvent!.Invoke(gameObject, ref component1);
            events.GenericEvent!.Invoke(gameObject, ref component2);
            events.GenericEvent!.Invoke(gameObject, ref component3);
        }

        /// <summary>
        ///     Adds a component to this <see cref="GameObject" />.
        /// </summary>
        /// <remarks>If the scene is being updated, changed are deffered to the end of the scene update.</remarks>
        public void Add<T1, T2, T3, T4>(in T1 c1, in T2 c2, in T3 c3, in T4 c4)
        {
            ref GameObjectLocation thisLookup = ref AssertIsAlive(out Scene world);

            if (!world.AllowStructualChanges)
            {
                world.WorldUpdateCommandBuffer.AddComponent(this, c1);
                world.WorldUpdateCommandBuffer.AddComponent(this, c2);
                world.WorldUpdateCommandBuffer.AddComponent(this, c3);
                world.WorldUpdateCommandBuffer.AddComponent(this, c4);

                return;
            }

            Archetype to = TraverseThroughCacheOrCreate<NeighborCache<T1, T2, T3, T4>>(
                world,
                ref NeighborCacheAdd<T1, T2, T3, T4>.Lookup,
                ref thisLookup,
                true);

            Span<ComponentStorageBase> buff = [null!, null!, null!, null!];
            world.MoveEntityToArchetypeAdd(buff, this, ref thisLookup, out GameObjectLocation nextLocation, to);

            ref T1 c1Ref =
                ref Unsafe.As<ComponentStorage<T1>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 0))[nextLocation.Index];
            c1Ref = c1;
            ref T2 c2Ref =
                ref Unsafe.As<ComponentStorage<T2>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 1))[nextLocation.Index];
            c2Ref = c2;
            ref T3 c3Ref =
                ref Unsafe.As<ComponentStorage<T3>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 2))[nextLocation.Index];
            c3Ref = c3;
            ref T4 c4Ref =
                ref Unsafe.As<ComponentStorage<T4>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 3))[nextLocation.Index];
            c4Ref = c4;


            Component<T1>.Initer?.Invoke(this, ref c1Ref);
            Component<T2>.Initer?.Invoke(this, ref c2Ref);
            Component<T3>.Initer?.Invoke(this, ref c3Ref);
            Component<T4>.Initer?.Invoke(this, ref c4Ref);


            GameObjectFlags flags = thisLookup.Flags;
            if (GameObjectLocation.HasEventFlag(flags | world.WorldEventFlags,
                    GameObjectFlags.AddComp | GameObjectFlags.AddGenericComp))
            {
                if (world.ComponentAddedEvent.HasListeners)
                {
                    InvokeComponentWorldEvents<T1, T2, T3, T4>(ref world.ComponentAddedEvent, this);
                }

                if (GameObjectLocation.HasEventFlag(flags, GameObjectFlags.AddComp | GameObjectFlags.AddGenericComp))
                {
                    EventRecord events = world.EventLookup[EntityIdOnly];

                    InvokePerEntityEvents(this, GameObjectLocation.HasEventFlag(thisLookup.Flags, GameObjectFlags.AddGenericComp),
                        ref events.Add, ref c1Ref);
                }
            }
        }

        /// <summary>
        ///     Removes a component from this <see cref="GameObject" />
        /// </summary>
        /// <inheritdoc cref="Add{T}(in T)" />
        public void Remove<T1, T2, T3, T4>()
        {
            ref GameObjectLocation thisLookup = ref AssertIsAlive(out Scene world);

            if (!world.AllowStructualChanges)
            {
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T1>.Id);
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T2>.Id);
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T3>.Id);
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T4>.Id);

                return;
            }

            Archetype to = TraverseThroughCacheOrCreate<NeighborCache<T1, T2, T3, T4>>(
                world,
                ref NeighborCacheRemove<T1, T2, T3, T4>.Lookup,
                ref thisLookup,
                false);

            Span<ComponentHandle> runners = stackalloc ComponentHandle[4];
            world.MoveEntityToArchetypeRemove(runners, this, ref thisLookup, to);
            //scene.MoveEntityToArchetypeRemove invokes the events for us
        }


        /// <summary>
        ///     Invokes the component scene events using the specified event
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <param name="e">The event</param>
        /// <param name="gameObject">The gameObject</param>
        public static void InvokeComponentWorldEvents<T1, T2, T3, T4>(ref Event<ComponentId> e, GameObject gameObject)
        {
            e.InvokeInternal(gameObject, Component<T1>.Id);
            e.InvokeInternal(gameObject, Component<T2>.Id);
            e.InvokeInternal(gameObject, Component<T3>.Id);
            e.InvokeInternal(gameObject, Component<T4>.Id);
        }

        /// <summary>
        ///     Invokes the per gameObject events using the specified gameObject
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <param name="gameObject">The gameObject</param>
        /// <param name="hasGenericEvent">The has generic event</param>
        /// <param name="events">The events</param>
        /// <param name="component1">The component</param>
        /// <param name="component2">The component</param>
        /// <param name="component3">The component</param>
        /// <param name="component4">The component</param>
        public static void InvokePerEntityEvents<T1, T2, T3, T4>(GameObject gameObject, bool hasGenericEvent,
            ref ComponentEvent events, ref T1 component1, ref T2 component2, ref T3 component3, ref T4 component4)
        {
            events.NormalEvent.Invoke(gameObject, Component<T1>.Id);
            events.NormalEvent.Invoke(gameObject, Component<T2>.Id);
            events.NormalEvent.Invoke(gameObject, Component<T3>.Id);
            events.NormalEvent.Invoke(gameObject, Component<T4>.Id);


            if (!hasGenericEvent)
            {
                return;
            }

            events.GenericEvent!.Invoke(gameObject, ref component1);
            events.GenericEvent!.Invoke(gameObject, ref component2);
            events.GenericEvent!.Invoke(gameObject, ref component3);
            events.GenericEvent!.Invoke(gameObject, ref component4);
        }


        /// <summary>
        ///     Adds a component to this <see cref="GameObject" />.
        /// </summary>
        /// <remarks>If the scene is being updated, changed are deffered to the end of the scene update.</remarks>
        public void Add<T1, T2, T3, T4, T5>(in T1 c1, in T2 c2, in T3 c3, in T4 c4, in T5 c5)
        {
            ref GameObjectLocation thisLookup = ref AssertIsAlive(out Scene world);

            if (!world.AllowStructualChanges)
            {
                world.WorldUpdateCommandBuffer.AddComponent(this, c1);
                world.WorldUpdateCommandBuffer.AddComponent(this, c2);
                world.WorldUpdateCommandBuffer.AddComponent(this, c3);
                world.WorldUpdateCommandBuffer.AddComponent(this, c4);
                world.WorldUpdateCommandBuffer.AddComponent(this, c5);

                return;
            }

            Archetype to = TraverseThroughCacheOrCreate<NeighborCache<T1, T2, T3, T4, T5>>(
                world,
                ref NeighborCacheAdd<T1, T2, T3, T4, T5>.Lookup,
                ref thisLookup,
                true);

            Span<ComponentStorageBase> buff = [null!, null!, null!, null!, null!];
            world.MoveEntityToArchetypeAdd(buff, this, ref thisLookup, out GameObjectLocation nextLocation, to);

            ref T1 c1Ref =
                ref Unsafe.As<ComponentStorage<T1>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 0))[nextLocation.Index];
            c1Ref = c1;
            ref T2 c2Ref =
                ref Unsafe.As<ComponentStorage<T2>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 1))[nextLocation.Index];
            c2Ref = c2;
            ref T3 c3Ref =
                ref Unsafe.As<ComponentStorage<T3>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 2))[nextLocation.Index];
            c3Ref = c3;
            ref T4 c4Ref =
                ref Unsafe.As<ComponentStorage<T4>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 3))[nextLocation.Index];
            c4Ref = c4;
            ref T5 c5Ref =
                ref Unsafe.As<ComponentStorage<T5>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 4))[nextLocation.Index];
            c5Ref = c5;


            Component<T1>.Initer?.Invoke(this, ref c1Ref);
            Component<T2>.Initer?.Invoke(this, ref c2Ref);
            Component<T3>.Initer?.Invoke(this, ref c3Ref);
            Component<T4>.Initer?.Invoke(this, ref c4Ref);
            Component<T5>.Initer?.Invoke(this, ref c5Ref);


            GameObjectFlags flags = thisLookup.Flags;
            if (GameObjectLocation.HasEventFlag(flags | world.WorldEventFlags,
                    GameObjectFlags.AddComp | GameObjectFlags.AddGenericComp))
            {
                if (world.ComponentAddedEvent.HasListeners)
                {
                    InvokeComponentWorldEvents<T1, T2, T3, T4, T5>(ref world.ComponentAddedEvent, this);
                }

                if (GameObjectLocation.HasEventFlag(flags, GameObjectFlags.AddComp | GameObjectFlags.AddGenericComp))
                {
                    EventRecord events = world.EventLookup[EntityIdOnly];
                    InvokePerEntityEvents(this, GameObjectLocation.HasEventFlag(thisLookup.Flags, GameObjectFlags.AddGenericComp),
                        ref events.Add, ref c1Ref);
                }
            }
        }

        /// <summary>
        ///     Removes a component from this <see cref="GameObject" />
        /// </summary>
        /// <inheritdoc cref="Add{T}(in T)" />
        public void Remove<T1, T2, T3, T4, T5>()
        {
            ref GameObjectLocation thisLookup = ref AssertIsAlive(out Scene world);

            if (!world.AllowStructualChanges)
            {
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T1>.Id);
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T2>.Id);
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T3>.Id);
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T4>.Id);
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T5>.Id);

                return;
            }

            Archetype to = TraverseThroughCacheOrCreate<NeighborCache<T1, T2, T3, T4, T5>>(
                world,
                ref NeighborCacheRemove<T1, T2, T3, T4, T5>.Lookup,
                ref thisLookup,
                false);

            Span<ComponentHandle> runners = stackalloc ComponentHandle[5];
            world.MoveEntityToArchetypeRemove(runners, this, ref thisLookup, to);
            //scene.MoveEntityToArchetypeRemove invokes the events for us
        }


        /// <summary>
        ///     Invokes the component scene events using the specified event
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <param name="e">The event</param>
        /// <param name="gameObject">The gameObject</param>
        public static void InvokeComponentWorldEvents<T1, T2, T3, T4, T5>(ref Event<ComponentId> e, GameObject gameObject)
        {
            e.InvokeInternal(gameObject, Component<T1>.Id);
            e.InvokeInternal(gameObject, Component<T2>.Id);
            e.InvokeInternal(gameObject, Component<T3>.Id);
            e.InvokeInternal(gameObject, Component<T4>.Id);
            e.InvokeInternal(gameObject, Component<T5>.Id);
        }

        /// <summary>
        ///     Invokes the per gameObject events using the specified gameObject
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <param name="gameObject">The gameObject</param>
        /// <param name="hasGenericEvent">The has generic event</param>
        /// <param name="events">The events</param>
        /// <param name="component1">The component</param>
        /// <param name="component2">The component</param>
        /// <param name="component3">The component</param>
        /// <param name="component4">The component</param>
        /// <param name="component5">The component</param>
        public static void InvokePerEntityEvents<T1, T2, T3, T4, T5>(GameObject gameObject, bool hasGenericEvent,
            ref ComponentEvent events, ref T1 component1, ref T2 component2, ref T3 component3, ref T4 component4,
            ref T5 component5)
        {
            events.NormalEvent.Invoke(gameObject, Component<T1>.Id);
            events.NormalEvent.Invoke(gameObject, Component<T2>.Id);
            events.NormalEvent.Invoke(gameObject, Component<T3>.Id);
            events.NormalEvent.Invoke(gameObject, Component<T4>.Id);
            events.NormalEvent.Invoke(gameObject, Component<T5>.Id);


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

            Archetype to = TraverseThroughCacheOrCreate<NeighborCache<T1, T2, T3, T4, T5, T6>>(
                world,
                ref NeighborCacheAdd<T1, T2, T3, T4, T5, T6>.Lookup,
                ref thisLookup,
                true);

            Span<ComponentStorageBase> buff = [null!, null!, null!, null!, null!, null!];
            world.MoveEntityToArchetypeAdd(buff, this, ref thisLookup, out GameObjectLocation nextLocation, to);

            ref T1 c1Ref =
                ref Unsafe.As<ComponentStorage<T1>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 0))[nextLocation.Index];
            c1Ref = c1;
            ref T2 c2Ref =
                ref Unsafe.As<ComponentStorage<T2>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 1))[nextLocation.Index];
            c2Ref = c2;
            ref T3 c3Ref =
                ref Unsafe.As<ComponentStorage<T3>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 2))[nextLocation.Index];
            c3Ref = c3;
            ref T4 c4Ref =
                ref Unsafe.As<ComponentStorage<T4>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 3))[nextLocation.Index];
            c4Ref = c4;
            ref T5 c5Ref =
                ref Unsafe.As<ComponentStorage<T5>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 4))[nextLocation.Index];
            c5Ref = c5;
            ref T6 c6Ref =
                ref Unsafe.As<ComponentStorage<T6>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 5))[nextLocation.Index];
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
                {
                    InvokeComponentWorldEvents<T1, T2, T3, T4, T5, T6>(ref world.ComponentAddedEvent, this);
                }

                if (GameObjectLocation.HasEventFlag(flags, GameObjectFlags.AddComp | GameObjectFlags.AddGenericComp))
                {
                    EventRecord events = world.EventLookup[EntityIdOnly];
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

            Archetype to = TraverseThroughCacheOrCreate<NeighborCache<T1, T2, T3, T4, T5, T6>>(
                world,
                ref NeighborCacheRemove<T1, T2, T3, T4, T5, T6>.Lookup,
                ref thisLookup,
                false);

            Span<ComponentHandle> runners = stackalloc ComponentHandle[6];
            world.MoveEntityToArchetypeRemove(runners, this, ref thisLookup, to);
            //scene.MoveEntityToArchetypeRemove invokes the events for us
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
        /// <param name="e">The event</param>
        /// <param name="gameObject">The gameObject</param>
        public static void InvokeComponentWorldEvents<T1, T2, T3, T4, T5, T6>(ref Event<ComponentId> e, GameObject gameObject)
        {
            e.InvokeInternal(gameObject, Component<T1>.Id);
            e.InvokeInternal(gameObject, Component<T2>.Id);
            e.InvokeInternal(gameObject, Component<T3>.Id);
            e.InvokeInternal(gameObject, Component<T4>.Id);
            e.InvokeInternal(gameObject, Component<T5>.Id);
            e.InvokeInternal(gameObject, Component<T6>.Id);
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
        public static void InvokePerEntityEvents<T1, T2, T3, T4, T5, T6>(GameObject gameObject, bool hasGenericEvent,
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
            {
                return;
            }

            events.GenericEvent!.Invoke(gameObject, ref component1);
            events.GenericEvent!.Invoke(gameObject, ref component2);
            events.GenericEvent!.Invoke(gameObject, ref component3);
            events.GenericEvent!.Invoke(gameObject, ref component4);
            events.GenericEvent!.Invoke(gameObject, ref component5);
            events.GenericEvent!.Invoke(gameObject, ref component6);
        }


        /// <summary>
        ///     Adds a component to this <see cref="GameObject" />.
        /// </summary>
        /// <remarks>If the scene is being updated, changed are deffered to the end of the scene update.</remarks>
        public void Add<T1, T2, T3, T4, T5, T6, T7>(in T1 c1, in T2 c2, in T3 c3, in T4 c4, in T5 c5, in T6 c6, in T7 c7)
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
                world.WorldUpdateCommandBuffer.AddComponent(this, c7);

                return;
            }

            Archetype to = TraverseThroughCacheOrCreate<NeighborCache<T1, T2, T3, T4, T5, T6, T7>>(
                world,
                ref NeighborCacheAdd<T1, T2, T3, T4, T5, T6, T7>.Lookup,
                ref thisLookup,
                true);

            Span<ComponentStorageBase> buff = [null!, null!, null!, null!, null!, null!, null!];
            world.MoveEntityToArchetypeAdd(buff, this, ref thisLookup, out GameObjectLocation nextLocation, to);

            ref T1 c1Ref =
                ref Unsafe.As<ComponentStorage<T1>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 0))[nextLocation.Index];
            c1Ref = c1;
            ref T2 c2Ref =
                ref Unsafe.As<ComponentStorage<T2>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 1))[nextLocation.Index];
            c2Ref = c2;
            ref T3 c3Ref =
                ref Unsafe.As<ComponentStorage<T3>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 2))[nextLocation.Index];
            c3Ref = c3;
            ref T4 c4Ref =
                ref Unsafe.As<ComponentStorage<T4>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 3))[nextLocation.Index];
            c4Ref = c4;
            ref T5 c5Ref =
                ref Unsafe.As<ComponentStorage<T5>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 4))[nextLocation.Index];
            c5Ref = c5;
            ref T6 c6Ref =
                ref Unsafe.As<ComponentStorage<T6>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 5))[nextLocation.Index];
            c6Ref = c6;
            ref T7 c7Ref =
                ref Unsafe.As<ComponentStorage<T7>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 6))[nextLocation.Index];
            c7Ref = c7;


            Component<T1>.Initer?.Invoke(this, ref c1Ref);
            Component<T2>.Initer?.Invoke(this, ref c2Ref);
            Component<T3>.Initer?.Invoke(this, ref c3Ref);
            Component<T4>.Initer?.Invoke(this, ref c4Ref);
            Component<T5>.Initer?.Invoke(this, ref c5Ref);
            Component<T6>.Initer?.Invoke(this, ref c6Ref);
            Component<T7>.Initer?.Invoke(this, ref c7Ref);


            GameObjectFlags flags = thisLookup.Flags;
            if (GameObjectLocation.HasEventFlag(flags | world.WorldEventFlags,
                    GameObjectFlags.AddComp | GameObjectFlags.AddGenericComp))
            {
                if (world.ComponentAddedEvent.HasListeners)
                {
                    InvokeComponentWorldEvents<T1, T2, T3, T4, T5, T6, T7>(ref world.ComponentAddedEvent, this);
                }

                if (GameObjectLocation.HasEventFlag(flags, GameObjectFlags.AddComp | GameObjectFlags.AddGenericComp))
                {
                    EventRecord events = world.EventLookup[EntityIdOnly];
                    InvokePerEntityEvents(this, GameObjectLocation.HasEventFlag(thisLookup.Flags, GameObjectFlags.AddGenericComp),
                        ref events.Add, ref c1Ref);
                }
            }
        }

        /// <summary>
        ///     Removes a component from this <see cref="GameObject" />
        /// </summary>
        /// <inheritdoc cref="Add{T}(in T)" />
        public void Remove<T1, T2, T3, T4, T5, T6, T7>()
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
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T7>.Id);

                return;
            }

            Archetype to = TraverseThroughCacheOrCreate<NeighborCache<T1, T2, T3, T4, T5, T6, T7>>(
                world,
                ref NeighborCacheRemove<T1, T2, T3, T4, T5, T6, T7>.Lookup,
                ref thisLookup,
                false);

            Span<ComponentHandle> runners = stackalloc ComponentHandle[7];
            world.MoveEntityToArchetypeRemove(runners, this, ref thisLookup, to);
            //scene.MoveEntityToArchetypeRemove invokes the events for us
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
        /// <typeparam name="T7">The </typeparam>
        /// <param name="e">The event</param>
        /// <param name="gameObject">The gameObject</param>
        public static void InvokeComponentWorldEvents<T1, T2, T3, T4, T5, T6, T7>(ref Event<ComponentId> e,
            GameObject gameObject)
        {
            e.InvokeInternal(gameObject, Component<T1>.Id);
            e.InvokeInternal(gameObject, Component<T2>.Id);
            e.InvokeInternal(gameObject, Component<T3>.Id);
            e.InvokeInternal(gameObject, Component<T4>.Id);
            e.InvokeInternal(gameObject, Component<T5>.Id);
            e.InvokeInternal(gameObject, Component<T6>.Id);
            e.InvokeInternal(gameObject, Component<T7>.Id);
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
        /// <typeparam name="T7">The </typeparam>
        /// <param name="gameObject">The gameObject</param>
        /// <param name="hasGenericEvent">The has generic event</param>
        /// <param name="events">The events</param>
        /// <param name="component1">The component</param>
        /// <param name="component2">The component</param>
        /// <param name="component3">The component</param>
        /// <param name="component4">The component</param>
        /// <param name="component5">The component</param>
        /// <param name="component6">The component</param>
        /// <param name="component7">The component</param>
        public static void InvokePerEntityEvents<T1, T2, T3, T4, T5, T6, T7>(GameObject gameObject, bool hasGenericEvent,
            ref ComponentEvent events, ref T1 component1, ref T2 component2, ref T3 component3, ref T4 component4,
            ref T5 component5, ref T6 component6, ref T7 component7)
        {
            events.NormalEvent.Invoke(gameObject, Component<T1>.Id);
            events.NormalEvent.Invoke(gameObject, Component<T2>.Id);
            events.NormalEvent.Invoke(gameObject, Component<T3>.Id);
            events.NormalEvent.Invoke(gameObject, Component<T4>.Id);
            events.NormalEvent.Invoke(gameObject, Component<T5>.Id);
            events.NormalEvent.Invoke(gameObject, Component<T6>.Id);
            events.NormalEvent.Invoke(gameObject, Component<T7>.Id);


            if (!hasGenericEvent)
            {
                return;
            }

            events.GenericEvent!.Invoke(gameObject, ref component1);
            events.GenericEvent!.Invoke(gameObject, ref component2);
            events.GenericEvent!.Invoke(gameObject, ref component3);
            events.GenericEvent!.Invoke(gameObject, ref component4);
            events.GenericEvent!.Invoke(gameObject, ref component5);
            events.GenericEvent!.Invoke(gameObject, ref component6);
            events.GenericEvent!.Invoke(gameObject, ref component7);
        }


        /// <summary>
        ///     Adds a component to this <see cref="GameObject" />.
        /// </summary>
        /// <remarks>If the scene is being updated, changed are deffered to the end of the scene update.</remarks>
        public void Add<T1, T2, T3, T4, T5, T6, T7, T8>(in T1 c1, in T2 c2, in T3 c3, in T4 c4, in T5 c5, in T6 c6,
            in T7 c7, in T8 c8)
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
                world.WorldUpdateCommandBuffer.AddComponent(this, c7);
                world.WorldUpdateCommandBuffer.AddComponent(this, c8);

                return;
            }

            Archetype to = TraverseThroughCacheOrCreate<NeighborCache<T1, T2, T3, T4, T5, T6, T7, T8>>(
                world,
                ref NeighborCacheAdd<T1, T2, T3, T4, T5, T6, T7, T8>.Lookup,
                ref thisLookup,
                true);

            Span<ComponentStorageBase> buff = [null!, null!, null!, null!, null!, null!, null!, null!];
            world.MoveEntityToArchetypeAdd(buff, this, ref thisLookup, out GameObjectLocation nextLocation, to);

            ref T1 c1Ref =
                ref Unsafe.As<ComponentStorage<T1>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 0))[nextLocation.Index];
            c1Ref = c1;
            ref T2 c2Ref =
                ref Unsafe.As<ComponentStorage<T2>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 1))[nextLocation.Index];
            c2Ref = c2;
            ref T3 c3Ref =
                ref Unsafe.As<ComponentStorage<T3>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 2))[nextLocation.Index];
            c3Ref = c3;
            ref T4 c4Ref =
                ref Unsafe.As<ComponentStorage<T4>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 3))[nextLocation.Index];
            c4Ref = c4;
            ref T5 c5Ref =
                ref Unsafe.As<ComponentStorage<T5>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 4))[nextLocation.Index];
            c5Ref = c5;
            ref T6 c6Ref =
                ref Unsafe.As<ComponentStorage<T6>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 5))[nextLocation.Index];
            c6Ref = c6;
            ref T7 c7Ref =
                ref Unsafe.As<ComponentStorage<T7>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 6))[nextLocation.Index];
            c7Ref = c7;
            ref T8 c8Ref =
                ref Unsafe.As<ComponentStorage<T8>>(Unsafe.Add(ref MemoryMarshal.GetReference(buff), 7))[nextLocation.Index];
            c8Ref = c8;


            Component<T1>.Initer?.Invoke(this, ref c1Ref);
            Component<T2>.Initer?.Invoke(this, ref c2Ref);
            Component<T3>.Initer?.Invoke(this, ref c3Ref);
            Component<T4>.Initer?.Invoke(this, ref c4Ref);
            Component<T5>.Initer?.Invoke(this, ref c5Ref);
            Component<T6>.Initer?.Invoke(this, ref c6Ref);
            Component<T7>.Initer?.Invoke(this, ref c7Ref);
            Component<T8>.Initer?.Invoke(this, ref c8Ref);


            GameObjectFlags flags = thisLookup.Flags;
            if (GameObjectLocation.HasEventFlag(flags | world.WorldEventFlags,
                    GameObjectFlags.AddComp | GameObjectFlags.AddGenericComp))
            {
                if (world.ComponentAddedEvent.HasListeners)
                {
                    InvokeComponentWorldEvents<T1, T2, T3, T4, T5, T6, T7, T8>(ref world.ComponentAddedEvent, this);
                }

                if (GameObjectLocation.HasEventFlag(flags, GameObjectFlags.AddComp | GameObjectFlags.AddGenericComp))
                {
                    EventRecord events = world.EventLookup[EntityIdOnly];
                    InvokePerEntityEvents(this, GameObjectLocation.HasEventFlag(thisLookup.Flags, GameObjectFlags.AddGenericComp),
                        ref events.Add, ref c1Ref);
                }
            }
        }

        /// <summary>
        ///     Removes a component from this <see cref="GameObject" />
        /// </summary>
        /// <inheritdoc cref="Add{T}(in T)" />
        public void Remove<T1, T2, T3, T4, T5, T6, T7, T8>()
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
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T7>.Id);
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T8>.Id);

                return;
            }

            Archetype to = TraverseThroughCacheOrCreate<NeighborCache<T1, T2, T3, T4, T5, T6, T7, T8>>(
                world,
                ref NeighborCacheRemove<T1, T2, T3, T4, T5, T6, T7, T8>.Lookup,
                ref thisLookup,
                false);

            Span<ComponentHandle> runners = stackalloc ComponentHandle[8];
            world.MoveEntityToArchetypeRemove(runners, this, ref thisLookup, to);
            //scene.MoveEntityToArchetypeRemove invokes the events for us
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
        /// <typeparam name="T7">The </typeparam>
        /// <typeparam name="T8">The </typeparam>
        /// <param name="e">The event</param>
        /// <param name="gameObject">The gameObject</param>
        public static void InvokeComponentWorldEvents<T1, T2, T3, T4, T5, T6, T7, T8>(ref Event<ComponentId> e,
            GameObject gameObject)
        {
            e.InvokeInternal(gameObject, Component<T1>.Id);
            e.InvokeInternal(gameObject, Component<T2>.Id);
            e.InvokeInternal(gameObject, Component<T3>.Id);
            e.InvokeInternal(gameObject, Component<T4>.Id);
            e.InvokeInternal(gameObject, Component<T5>.Id);
            e.InvokeInternal(gameObject, Component<T6>.Id);
            e.InvokeInternal(gameObject, Component<T7>.Id);
            e.InvokeInternal(gameObject, Component<T8>.Id);
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
        /// <typeparam name="T7">The </typeparam>
        /// <typeparam name="T8">The </typeparam>
        /// <param name="gameObject">The gameObject</param>
        /// <param name="hasGenericEvent">The has generic event</param>
        /// <param name="events">The events</param>
        /// <param name="component1">The component</param>
        /// <param name="component2">The component</param>
        /// <param name="component3">The component</param>
        /// <param name="component4">The component</param>
        /// <param name="component5">The component</param>
        /// <param name="component6">The component</param>
        /// <param name="component7">The component</param>
        /// <param name="component8">The component</param>
        public static void InvokePerEntityEvents<T1, T2, T3, T4, T5, T6, T7, T8>(GameObject gameObject, bool hasGenericEvent,
            ref ComponentEvent events, ref T1 component1, ref T2 component2, ref T3 component3, ref T4 component4,
            ref T5 component5, ref T6 component6, ref T7 component7, ref T8 component8)
        {
            events.NormalEvent.Invoke(gameObject, Component<T1>.Id);
            events.NormalEvent.Invoke(gameObject, Component<T2>.Id);
            events.NormalEvent.Invoke(gameObject, Component<T3>.Id);
            events.NormalEvent.Invoke(gameObject, Component<T4>.Id);
            events.NormalEvent.Invoke(gameObject, Component<T5>.Id);
            events.NormalEvent.Invoke(gameObject, Component<T6>.Id);
            events.NormalEvent.Invoke(gameObject, Component<T7>.Id);
            events.NormalEvent.Invoke(gameObject, Component<T8>.Id);


            if (!hasGenericEvent)
            {
                return;
            }

            events.GenericEvent!.Invoke(gameObject, ref component1);
            events.GenericEvent!.Invoke(gameObject, ref component2);
            events.GenericEvent!.Invoke(gameObject, ref component3);
            events.GenericEvent!.Invoke(gameObject, ref component4);
            events.GenericEvent!.Invoke(gameObject, ref component5);
            events.GenericEvent!.Invoke(gameObject, ref component6);
            events.GenericEvent!.Invoke(gameObject, ref component7);
            events.GenericEvent!.Invoke(gameObject, ref component8);
        }


        /// <summary>
        ///     Checks of this <see cref="GameObject" /> has a component specified by <paramref name="componentId" />.
        /// </summary>
        /// <param name="componentId">The component ID of the component type to check.</param>
        /// <returns>
        ///     <see langword="true" /> if the gameObject has a component of <paramref name="componentId" />, otherwise
        ///     <see langword="false" />.
        /// </returns>
        public bool Has(ComponentId componentId)
        {
            ref GameObjectLocation gameObjectLocation = ref AssertIsAlive(out _);
            return gameObjectLocation.Archetype.GetComponentIndex(componentId) != 0;
        }

        /// <summary>
        ///     Checks to see if this <see cref="GameObject" /> has a component of Type <typeparamref name="T" />.
        /// </summary>
        /// <typeparam name="T">The type of component to check.</typeparam>
        /// <returns>
        ///     <see langword="true" /> if the gameObject has a component of <typeparamref name="T" />, otherwise
        ///     <see langword="false" />.
        /// </returns>
        public bool Has<T>() => Has(Component<T>.Id);

        /// <summary>
        ///     Checks to see if this <see cref="GameObject" /> has a component of Type <paramref name="type" />.
        /// </summary>
        /// <param name="type">The component type to check if this gameObject has.</param>
        /// <returns>
        ///     <see langword="true" /> if the gameObject has a component of <paramref name="type" />, otherwise
        ///     <see langword="false" />.
        /// </returns>
        public bool Has(Type type) => Has(Component.GetComponentId(type));

        /// <summary>
        ///     Checks of this <see cref="GameObject" /> has a component specified by <paramref name="componentId" /> without
        ///     throwing
        ///     when dead.
        /// </summary>
        /// <param name="componentId">The component ID of the component type to check.</param>
        /// <returns>
        ///     <see langword="true" /> if the gameObject is alive and has a component of <paramref name="componentId" />,
        ///     otherwise <see langword="false" />.
        /// </returns>
        public bool TryHas(ComponentId componentId) => InternalIsAlive(out _, out GameObjectLocation entityLocation) &&
                                                       (entityLocation.Archetype.GetComponentIndex(componentId) != 0);

        /// <summary>
        ///     Checks of this <see cref="GameObject" /> has a component specified by <typeparamref name="T" /> without throwing
        ///     when
        ///     dead.
        /// </summary>
        /// <typeparam name="T">The type of component to check.</typeparam>
        /// <returns>
        ///     <see langword="true" /> if the gameObject is alive and has a component of <typeparamref name="T" />, otherwise
        ///     <see langword="false" />.
        /// </returns>
        public bool TryHas<T>() => TryHas(Component<T>.Id);

        /// <summary>
        ///     Checks of this <see cref="GameObject" /> has a component specified by <paramref name="type" /> without throwing
        ///     when
        ///     dead.
        /// </summary>
        /// <param name="type">The type of the component type to check.</param>
        /// <returns>
        ///     <see langword="true" /> if the gameObject is alive and has a component of <paramref name="type" />, otherwise
        ///     <see langword="false" />.
        /// </returns>
        public bool TryHas(Type type) => TryHas(Component.GetComponentId(type));


        /// <summary>
        ///     Gets this <see cref="GameObject" />'s component of type <typeparamref name="T" />.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        /// <exception cref="InvalidOperationException"><see cref="GameObject" /> is dead.</exception>
        /// <exception cref="NullReferenceException">
        ///     <see cref="GameObject" /> does not have component of type
        ///     <typeparamref name="T" />.
        /// </exception>
        /// <returns>A reference to the component in memory.</returns>
        public ref T Get<T>()
        {
            //Total: 4x lookup

            //1x
            ref GameObjectLocation lookup = ref AssertIsAlive(out Scene world);

            //1x
            //other lookup is optimized into indirect pointer addressing
            Archetype archetype = lookup.Archetype;

            int compIndex = archetype.GetComponentIndex<T>();

            //2x
            //hardware trap
            ComponentStorage<T> storage =
                Unsafe.As<ComponentStorage<T>>(Unsafe.Add(ref archetype.Components[0], compIndex));
            return ref storage[lookup.Index];
        } //2, 0

        /// <summary>
        ///     Gets this <see cref="GameObject" />'s component of type <paramref name="id" />.
        /// </summary>
        /// <param name="id">The ID of the type of component to get</param>
        /// <exception cref="InvalidOperationException"><see cref="GameObject" /> is dead.</exception>
        /// <exception cref="ComponentNotFoundException">
        ///     <see cref="GameObject" /> does not have component of type
        ///     <paramref name="id" />.
        /// </exception>
        /// <returns>The boxed component.</returns>
        public object Get(ComponentId id)
        {
            ref GameObjectLocation lookup = ref AssertIsAlive(out _);

            int compIndex = lookup.Archetype.GetComponentIndex(id);

            if (compIndex == 0)
            {
                throw new ComponentNotFoundException(id.Type);
            }

            return lookup.Archetype.Components[compIndex].GetAt(lookup.Index);
        }

        /// <summary>
        ///     Gets this <see cref="GameObject" />'s component of type <paramref name="type" />.
        /// </summary>
        /// <param name="type">The type of component to get</param>
        /// <exception cref="InvalidOperationException"><see cref="GameObject" /> is dead.</exception>
        /// <exception cref="ComponentNotFoundException">
        ///     <see cref="GameObject" /> does not have component of type
        ///     <paramref name="type" />.
        /// </exception>
        /// <returns>The component of type <paramref name="type" /></returns>
        public object Get(Type type) => Get(Component.GetComponentId(type));

        /// <summary>
        ///     Gets this <see cref="GameObject" />'s component of type <paramref name="id" />.
        /// </summary>
        /// <param name="id">The ID of the type of component to get</param>
        /// <param name="obj">The component to set</param>
        /// <exception cref="InvalidOperationException"><see cref="GameObject" /> is dead.</exception>
        /// <exception cref="ComponentNotFoundException">
        ///     <see cref="GameObject" /> does not have component of type
        ///     <paramref name="id" />.
        /// </exception>
        public void Set(ComponentId id, object obj)
        {
            ref GameObjectLocation lookup = ref AssertIsAlive(out _);

            //2x
            int compIndex = lookup.Archetype.GetComponentIndex(id);

            if (compIndex == 0)
            {
                throw new ComponentNotFoundException(id.Type);
            }

            //3x
            lookup.Archetype.Components[compIndex].SetAt(obj, lookup.Index);
        }

        /// <summary>
        ///     Gets this <see cref="GameObject" />'s component of type <paramref name="type" />.
        /// </summary>
        /// <param name="type">The type of component to get</param>
        /// <param name="obj">The component to set</param>
        /// <exception cref="InvalidOperationException"><see cref="GameObject" /> is dead.</exception>
        /// <exception cref="ComponentNotFoundException">
        ///     <see cref="GameObject" /> does not have component of type
        ///     <paramref name="type" />.
        /// </exception>
        /// <returns>The component of type <paramref name="type" /></returns>
        public void Set(Type type, object obj)
        {
            Set(Component.GetComponentId(type), obj);
        }


        /// <summary>
        ///     Attempts to get a component from an <see cref="GameObject" />.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        /// <param name="value">A wrapper over a reference to the component when <see langword="true" />.</param>
        /// <returns>
        ///     <see langword="true" /> if this gameObject has a component of type <typeparamref name="T" />, otherwise
        ///     <see langword="false" />.
        /// </returns>
        public bool TryGet<T>(out Ref<T> value)
        {
            value = TryGetCore<T>(out bool exists);
            return exists;
        }

        /// <summary>
        ///     Attempts to get a component from an <see cref="GameObject" />.
        /// </summary>
        /// <param name="value">A wrapper over a reference to the component when <see langword="true" />.</param>
        /// <param name="type">The type of component to try and get</param>
        /// <returns>
        ///     <see langword="true" /> if this gameObject has a component of type <paramref name="type" />, otherwise
        ///     <see langword="false" />.
        /// </returns>
        public bool TryGet(Type type, out object value)
        {
            ref GameObjectLocation lookup = ref AssertIsAlive(out _);

            ComponentId componentId = Component.GetComponentId(type);
            int compIndex = GlobalWorldTables.ComponentIndex(lookup.ArchetypeId, componentId);

            if (compIndex == 0)
            {
                value = null;
                return false;
            }

            value = lookup.Archetype.Components[compIndex].GetAt(lookup.Index);
            return true;
        }


        /// <summary>
        ///     Adds a component to this <see cref="GameObject" /> as its own type
        /// </summary>
        /// <param name="component">The component, which could be boxed</param>
        public void AddBoxed(object component)
        {
            AddAs(component.GetType(), component);
        }

        /// <summary>
        ///     Add a component to an <see cref="GameObject" />
        /// </summary>
        /// <param name="type">
        ///     The type to add the component as. Note that a component of type DerivedClass and BaseClass are
        ///     different component types.
        /// </param>
        /// <param name="component">The component to add</param>
        public void AddAs(Type type, object component)
        {
            AddAs(Component.GetComponentId(type), component);
        }

        /// <summary>
        ///     Adds a component to this <see cref="GameObject" />, as a specific component type.
        /// </summary>
        /// <param name="componentId">The component type to add as.</param>
        /// <param name="component">The component to add.</param>
        /// <exception cref="InvalidCastException">
        ///     <paramref name="component" /> is not assignable to the type represented by
        ///     <paramref name="componentId" />.
        /// </exception>
        public void AddAs(ComponentId componentId, object component)
        {
            ref GameObjectLocation lookup = ref AssertIsAlive(out Scene w);
            if (w.AllowStructualChanges)
            {
                ComponentStorageBase componentRunner = null!;
                w.AddComponent(this, ref lookup, componentId, ref componentRunner, out GameObjectLocation entityLocation);
                componentRunner.SetAt(component, entityLocation.Index);
            }
            else
            {
                w.WorldUpdateCommandBuffer.AddComponent(this, componentId, component);
            }
        }


        /// <summary>
        ///     Removes a component from this gameObject
        /// </summary>
        /// <param name="componentId">The <see cref="ComponentId" /> of the component to be removed</param>
        public void Remove(ComponentId componentId)
        {
            ref GameObjectLocation lookup = ref AssertIsAlive(out Scene w);
            if (w.AllowStructualChanges)
            {
                w.RemoveComponent(this, ref lookup, componentId);
            }
            else
            {
                w.WorldUpdateCommandBuffer.RemoveComponent(this, componentId);
            }
        }

        /// <summary>
        ///     Removes a component from an <see cref="GameObject" />
        /// </summary>
        /// <param name="type">The type of component to remove</param>
        /// <exception cref="InvalidOperationException"><see cref="GameObject" /> is dead.</exception>
        /// <exception cref="ComponentNotFoundException">
        ///     <see cref="GameObject" /> does not have component of type
        ///     <paramref name="type" />.
        /// </exception>
        public void Remove(Type type)
        {
            Remove(Component.GetComponentId(type));
        }

        /// <summary>
        ///     Raised when the gameObject is deleted
        /// </summary>
        public event Action<GameObject> OnDelete
        {
            add => InitalizeEventRecord(value, GameObjectFlags.OnDelete);
            remove => UnsubscribeEvent(value, GameObjectFlags.OnDelete);
        }

        /// <summary>
        ///     Raised when a component is added to an gameObject
        /// </summary>
        public event Action<GameObject, ComponentId> OnComponentAdded
        {
            add => InitalizeEventRecord(value, GameObjectFlags.AddComp);
            remove => UnsubscribeEvent(value, GameObjectFlags.AddComp);
        }

        /// <summary>
        ///     Raised when a component is removed from an gameObject
        /// </summary>
        public event Action<GameObject, ComponentId> OnComponentRemoved
        {
            add => InitalizeEventRecord(value, GameObjectFlags.RemoveComp);
            remove => UnsubscribeEvent(value, GameObjectFlags.RemoveComp);
        }

        /// <summary>
        ///     Raised when a component is added to an gameObject, with the generic parameter
        /// </summary>
        public GenericEvent OnComponentAddedGeneric
        {
            readonly set
            {
                /*the set is just to enable the += syntax*/
            }
            get
            {
                if (!InternalIsAlive(out Scene world, out _))
                {
                    return null;
                }

                world.EntityTable[EntityID].Flags |= GameObjectFlags.AddGenericComp;
                return world.EventLookup.GetOrAddNew(EntityIdOnly).Add.GenericEvent ??= new GenericEvent();
            }
        }

        /// <summary>
        ///     Raised when a component is removed to an gameObject, with the generic parameter
        /// </summary>
        public GenericEvent OnComponentRemovedGeneric
        {
            readonly set
            {
                /*the set is just to enable the += syntax*/
            }
            get
            {
                if (!InternalIsAlive(out Scene world, out _))
                {
                    return null;
                }

                world.EntityTable[EntityID].Flags |= GameObjectFlags.RemoveGenericComp;
                return world.EventLookup.GetOrAddNew(EntityIdOnly).Remove.GenericEvent ??= new GenericEvent();
            }
        }

        /// <summary>
        ///     Unsubscribes the event using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="flag">The flag</param>
        public void UnsubscribeEvent(object value, GameObjectFlags flag)
        {
            if (value is null || !InternalIsAlive(out Scene world, out GameObjectLocation entityLocation))
            {
                return;
            }

            bool exists = entityLocation.HasEvent(flag);
            EventRecord events = exists ? Scene.EventLookup[EntityIdOnly] : default(EventRecord);

            if (exists)
            {
                bool removeFlags = false;

                switch (flag)
                {
                    case GameObjectFlags.AddComp:
                        events!.Add.NormalEvent.Remove((Action<GameObject, ComponentId>) value);
                        removeFlags = !events.Add.HasListeners;
                        break;
                    case GameObjectFlags.RemoveComp:
                        events!.Remove.NormalEvent.Remove((Action<GameObject, ComponentId>) value);
                        removeFlags = !events.Remove.HasListeners;
                        break;
                    case GameObjectFlags.OnDelete:
                        events!.Delete.Remove((Action<GameObject>) value);
                        removeFlags = !events.Delete.Any;
                        break;
                }

                if (removeFlags)
                {
                    world.EntityTable[EntityID].Flags &= ~flag;
                }
            }
        }

        /// <summary>
        ///     Initalizes the event record using the specified delegate
        /// </summary>
        /// <param name="false">The false parameter.</param>
        /// <param name="d">The delegate</param>
        /// <param name="flag">The flag</param>
        /// <param name="isGenericEvent">The is generic event</param>
        public void InitalizeEventRecord(object d, GameObjectFlags flag, bool isGenericEvent = false)
        {
            if (d is null || !InternalIsAlive(out Scene world, out GameObjectLocation entityLocation))
            {
                return;
            }

            bool exists = entityLocation.HasEvent(flag);
            EventRecord record = exists ? Scene.EventLookup[EntityIdOnly] : default(EventRecord);

            world.EntityTable[EntityID].Flags |= flag;
            EventRecord.Initalize(exists, ref record!);

            switch (flag)
            {
                case GameObjectFlags.AddComp:
                    if (isGenericEvent)
                    {
                        record.Add.GenericEvent = (GenericEvent) d;
                    }
                    else
                    {
                        record.Add.NormalEvent.Add((Action<GameObject, ComponentId>) d);
                    }

                    break;
                case GameObjectFlags.RemoveComp:
                    if (isGenericEvent)
                    {
                        record.Remove.GenericEvent = (GenericEvent) d;
                    }
                    else
                    {
                        record.Remove.NormalEvent.Add((Action<GameObject, ComponentId>) d);
                    }

                    break;
                case GameObjectFlags.OnDelete:
                    record.Delete.Push((Action<GameObject>) d);
                    break;
            }
        }


        /// <summary>
        ///     Deletes this gameObject
        /// </summary>
        public void Delete()
        {
            Scene scene = GlobalWorldTables.Worlds.UnsafeIndexNoResize(WorldID);
            //hardware trap
            ref GameObjectLocation lookup = ref scene.EntityTable.UnsafeIndexNoResize(EntityID);

            if (lookup.Version != EntityVersion)
            {
                return;
            }

            if (scene.AllowStructualChanges)
            {
                scene.DeleteEntity(this, ref lookup);
            }
            else
            {
                scene.WorldUpdateCommandBuffer.DeleteEntity(this);
            }
        }

        /// <summary>
        ///     Checks to see if this <see cref="GameObject" /> is still alive
        /// </summary>
        /// <returns>
        ///     <see langword="true" /> if this gameObject is still alive (not deleted), otherwise <see langword="false" />
        /// </returns>
        public bool IsAlive => InternalIsAlive(out _, out _);

        /// <summary>
        ///     Checks to see if this <see cref="GameObject" /> instance is the null gameObject: <see langword="default" />(
        ///     <see cref="GameObject" />)
        /// </summary>
        public bool IsNull => PackedValue == 0;

        /// <summary>
        ///     Gets the scene this gameObject belongs to
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="GameObject" /> is dead.</exception>
        public Scene Scene =>
            GlobalWorldTables.Worlds.UnsafeIndexNoResize(WorldID) ?? throw new InvalidOperationException();

        /// <summary>
        ///     Gets the component types for this gameObject, ordered in update order
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="GameObject" /> is dead.</exception>
        public FastImmutableArray<ComponentId> ComponentTypes
        {
            get
            {
                ref GameObjectLocation lookup = ref AssertIsAlive(out _);
                return lookup.Archetype.ArchetypeTypeArray;
            }
        }

        /// <summary>
        ///     The <see cref="GameObjectType" /> of this <see cref="GameObject" />.
        /// </summary>
        public GameObjectType Type
        {
            get
            {
                ref GameObjectLocation lookup = ref AssertIsAlive(out _);
                return lookup.Archetype.Id;
            }
        }

        /// <summary>
        ///     Enumerates all components one by one
        /// </summary>
        /// <param name="onEach">The unbound generic function called on each item</param>
        public void EnumerateComponents(IGenericAction onEach)
        {
            ref GameObjectLocation lookup = ref AssertIsAlive(out Scene _);
            ComponentStorageBase[] runners = lookup.Archetype.Components;
            for (int i = 1; i < runners.Length; i++)
            {
                runners[i].InvokeGenericActionWith(onEach, lookup.Index);
            }
        }

        /// <summary>
        ///     The null gameObject
        /// </summary>
        public static GameObject Null => default(GameObject);

        /// <summary>
        ///     Gets an <see cref="GameObjectType" /> without needing an <see cref="GameObject" /> of the specific type.
        /// </summary>
        /// <param name="components">The components the <see cref="GameObjectType" /> should have.</param>
        /// <returns>The result of the operation.</returns>
        public static GameObjectType EntityTypeOf(ReadOnlySpan<ComponentId> components) => Archetype.GetArchetypeId(components);
    }
}