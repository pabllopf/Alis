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
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     An GameObject reference; refers to a collection of components of unqiue types.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public partial struct GameObject : IEquatable<GameObject>, IGameObject
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
        ///     The gameObject id
        /// </summary>
        internal int EntityID;

        /// <summary>
        ///     The gameObject version
        /// </summary>
        internal ushort EntityVersion;

        /// <summary>
        ///     The scene id
        /// </summary>
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
        ///     Internals the is alive using the specified scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="gameObjectLocation">The gameObject location</param>
        /// <returns>The bool</returns>
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
        ///     Tries the get core using the specified exists
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="exists">The exists</param>
        /// <returns>A ref of t</returns>
        private Ref<T> TryGetCore<T>(out bool exists)
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
        private static void Throw_EntityIsDead()
        {
            throw new InvalidOperationException(EntityIsDeadMessage);
        }

        //captial N null to distinguish between actual null and default
        /// <summary>
        ///     Gets the value of the debugger display string
        /// </summary>
        internal string DebuggerDisplayString => IsNull ? "Null" :
            InternalIsAlive(out _, out _) ? $"Scene: {WorldID}, ID: {EntityID}, Version {EntityVersion}" :
            EntityIsDeadMessage;

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

            Archetype to = TraverseThroughCacheOrCreate<ComponentId, NeighborCache<T>>(
                world,
                ref NeighborCache<T>.Add.Lookup,
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
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
                    EventRecord events = world.EventLookup[EntityIdOnly];
#else
                    ref EventRecord events =
                        ref CollectionsMarshal.GetValueRefOrNullRef(world.EventLookup, EntityIdOnly);
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
        public void Remove<T>()
        {
            ref GameObjectLocation thisLookup = ref AssertIsAlive(out Scene world);

            if (!world.AllowStructualChanges)
            {
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T>.Id);
                return;
            }

            Archetype to = TraverseThroughCacheOrCreate<ComponentId, NeighborCache<T>>(
                world,
                ref NeighborCache<T>.Remove.Lookup,
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
        private static void InvokeComponentWorldEvents<T>(ref Event<ComponentId> e, GameObject gameObject)
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
        private static void InvokePerEntityEvents<T>(GameObject gameObject, bool hasGenericEvent, ref ComponentEvent events,
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
        /// <typeparam name="T">The </typeparam>
        /// <typeparam name="TEdge">The edge</typeparam>
        /// <param name="scene">The scene</param>
        /// <param name="cache">The cache</param>
        /// <param name="currentLookup">The current lookup</param>
        /// <param name="add">The add</param>
        /// <returns>The archetype</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Archetype TraverseThroughCacheOrCreate<T, TEdge>(
            Scene scene,
            ref ArchetypeNeighborCache cache,
            ref GameObjectLocation currentLookup,
            bool add)
            where T : ITypeId
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

                if (typeof(T) == typeof(ComponentId))
                {
                    default(TEdge).ModifyComponents(ref componentIDs, add);
                }

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

            Archetype to = TraverseThroughCacheOrCreate<ComponentId, NeighborCache<T1, T2>>(
                world,
                ref NeighborCache<T1, T2>.Add.Lookup,
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
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
                    EventRecord events = world.EventLookup[EntityIdOnly];
#else
                    ref EventRecord events =
                        ref CollectionsMarshal.GetValueRefOrNullRef(world.EventLookup, EntityIdOnly);
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
        public void Remove<T1, T2>()
        {
            ref GameObjectLocation thisLookup = ref AssertIsAlive(out Scene world);

            if (!world.AllowStructualChanges)
            {
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T1>.Id);
                world.WorldUpdateCommandBuffer.RemoveComponent(this, Component<T2>.Id);

                return;
            }

            Archetype to = TraverseThroughCacheOrCreate<ComponentId, NeighborCache<T1, T2>>(
                world,
                ref NeighborCache<T1, T2>.Remove.Lookup,
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
        private static void InvokeComponentWorldEvents<T1, T2>(ref Event<ComponentId> e, GameObject gameObject)
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
        private static void InvokePerEntityEvents<T1, T2>(GameObject gameObject, bool hasGenericEvent, ref ComponentEvent events,
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

            Archetype to = TraverseThroughCacheOrCreate<ComponentId, NeighborCache<T1, T2, T3>>(
                world,
                ref NeighborCache<T1, T2, T3>.Add.Lookup,
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
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
                    EventRecord events = world.EventLookup[EntityIdOnly];
#else
                    ref EventRecord events =
                        ref CollectionsMarshal.GetValueRefOrNullRef(world.EventLookup, EntityIdOnly);
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

            Archetype to = TraverseThroughCacheOrCreate<ComponentId, NeighborCache<T1, T2, T3>>(
                world,
                ref NeighborCache<T1, T2, T3>.Remove.Lookup,
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
        private static void InvokeComponentWorldEvents<T1, T2, T3>(ref Event<ComponentId> e, GameObject gameObject)
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
        private static void InvokePerEntityEvents<T1, T2, T3>(GameObject gameObject, bool hasGenericEvent,
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

            Archetype to = TraverseThroughCacheOrCreate<ComponentId, NeighborCache<T1, T2, T3, T4>>(
                world,
                ref NeighborCache<T1, T2, T3, T4>.Add.Lookup,
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
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
                    EventRecord events = world.EventLookup[EntityIdOnly];
#else
                    ref EventRecord events =
                        ref CollectionsMarshal.GetValueRefOrNullRef(world.EventLookup, EntityIdOnly);
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

            Archetype to = TraverseThroughCacheOrCreate<ComponentId, NeighborCache<T1, T2, T3, T4>>(
                world,
                ref NeighborCache<T1, T2, T3, T4>.Remove.Lookup,
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
        private static void InvokeComponentWorldEvents<T1, T2, T3, T4>(ref Event<ComponentId> e, GameObject gameObject)
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
        private static void InvokePerEntityEvents<T1, T2, T3, T4>(GameObject gameObject, bool hasGenericEvent,
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

            Archetype to = TraverseThroughCacheOrCreate<ComponentId, NeighborCache<T1, T2, T3, T4, T5>>(
                world,
                ref NeighborCache<T1, T2, T3, T4, T5>.Add.Lookup,
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
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
                    EventRecord events = world.EventLookup[EntityIdOnly];
#else
                    ref EventRecord events =
                        ref CollectionsMarshal.GetValueRefOrNullRef(world.EventLookup, EntityIdOnly);
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

            Archetype to = TraverseThroughCacheOrCreate<ComponentId, NeighborCache<T1, T2, T3, T4, T5>>(
                world,
                ref NeighborCache<T1, T2, T3, T4, T5>.Remove.Lookup,
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
        private static void InvokeComponentWorldEvents<T1, T2, T3, T4, T5>(ref Event<ComponentId> e, GameObject gameObject)
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
        private static void InvokePerEntityEvents<T1, T2, T3, T4, T5>(GameObject gameObject, bool hasGenericEvent,
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

            Archetype to = TraverseThroughCacheOrCreate<ComponentId, NeighborCache<T1, T2, T3, T4, T5, T6>>(
                world,
                ref NeighborCache<T1, T2, T3, T4, T5, T6>.Add.Lookup,
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
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
                    EventRecord events = world.EventLookup[EntityIdOnly];
#else
                    ref EventRecord events =
                        ref CollectionsMarshal.GetValueRefOrNullRef(world.EventLookup, EntityIdOnly);
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
        private static void InvokeComponentWorldEvents<T1, T2, T3, T4, T5, T6>(ref Event<ComponentId> e, GameObject gameObject)
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

            Archetype to = TraverseThroughCacheOrCreate<ComponentId, NeighborCache<T1, T2, T3, T4, T5, T6, T7>>(
                world,
                ref NeighborCache<T1, T2, T3, T4, T5, T6, T7>.Add.Lookup,
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
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
                    EventRecord events = world.EventLookup[EntityIdOnly];
#else
                    ref EventRecord events =
                        ref CollectionsMarshal.GetValueRefOrNullRef(world.EventLookup, EntityIdOnly);
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

            Archetype to = TraverseThroughCacheOrCreate<ComponentId, NeighborCache<T1, T2, T3, T4, T5, T6, T7>>(
                world,
                ref NeighborCache<T1, T2, T3, T4, T5, T6, T7>.Remove.Lookup,
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
        private static void InvokeComponentWorldEvents<T1, T2, T3, T4, T5, T6, T7>(ref Event<ComponentId> e,
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
        private static void InvokePerEntityEvents<T1, T2, T3, T4, T5, T6, T7>(GameObject gameObject, bool hasGenericEvent,
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

            Archetype to = TraverseThroughCacheOrCreate<ComponentId, NeighborCache<T1, T2, T3, T4, T5, T6, T7, T8>>(
                world,
                ref NeighborCache<T1, T2, T3, T4, T5, T6, T7, T8>.Add.Lookup,
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
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
                    EventRecord events = world.EventLookup[EntityIdOnly];
#else
                    ref EventRecord events =
                        ref CollectionsMarshal.GetValueRefOrNullRef(world.EventLookup, EntityIdOnly);
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

            Archetype to = TraverseThroughCacheOrCreate<ComponentId, NeighborCache<T1, T2, T3, T4, T5, T6, T7, T8>>(
                world,
                ref NeighborCache<T1, T2, T3, T4, T5, T6, T7, T8>.Remove.Lookup,
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
        private static void InvokeComponentWorldEvents<T1, T2, T3, T4, T5, T6, T7, T8>(ref Event<ComponentId> e,
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
        private static void InvokePerEntityEvents<T1, T2, T3, T4, T5, T6, T7, T8>(GameObject gameObject, bool hasGenericEvent,
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
    }
}