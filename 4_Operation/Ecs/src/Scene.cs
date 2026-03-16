// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Scene.cs
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
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Redifinition;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     A collection of entities that can be updated and queried.
    /// </summary>
    public class Scene : IDisposable
    {
        /// <summary>
        ///     The deferred gameObject operation recursion limit
        /// </summary>
        internal const int DeferredEntityOperationRecursionLimit = 200;

        /// <summary>
        ///     The next scene id
        /// </summary>
        internal static ushort _nextWorldId = 1;

        /// <summary>
        ///     The shared countdown
        /// </summary>
        internal readonly CountdownEvent _sharedCountdown = new CountdownEvent(0);

        /// <summary>
        ///     The single component updates
        /// </summary>
        internal readonly Dictionary<ComponentId, SingleComponentUpdateFilter> _singleComponentUpdates = [];

        /// <summary>
        ///     The updates by attributes
        /// </summary>
        internal readonly Dictionary<Type, SceneUpdateFilter> _updatesByAttributes = [];

        /// <summary>
        ///     The default archetype
        /// </summary>
        public readonly Archetype DefaultArchetype;

        /// <summary>
        ///     The default scene gameObject
        /// </summary>
        public readonly GameObject DefaultWorldGameObject;

        /// <summary>
        ///     The id
        /// </summary>
        public readonly ushort Id;

        // -1: normal state
        // 0: some kind of transition in End/Enter
        // n: n systems/updates active
        /// <summary>
        ///     The allow structural changes
        /// </summary>
        internal int _allowStructuralChanges = -1;

        /// <summary>
        ///     The create
        /// </summary>
        internal FastestStack<ArchetypeDeferredUpdateRecord> _altDeferredCreationArchetypes =
            FastestStack<ArchetypeDeferredUpdateRecord>.Create(4);

        //these lookups exists for programmical api optimization
        //normal <T1, T2...> methods use a shared global static cache
        /// <summary>
        ///     The add component lookup
        /// </summary>
        public FastLookup AddComponentLookup = new FastLookup();

        /// <summary>
        ///     The add tag lookup
        /// </summary>
        public FastLookup AddTagLookup = new FastLookup();

        /// <summary>
        ///     The archetype graph edges
        /// </summary>
        public Dictionary<ArchetypeEdgeKey, Archetype> ArchetypeGraphEdges = [];

        /// <summary>
        ///     The component id
        /// </summary>
        public Event<ComponentId> ComponentAddedEvent = new Event<ComponentId>();

        /// <summary>
        ///     The component id
        /// </summary>
        public Event<ComponentId> ComponentRemovedEvent = new Event<ComponentId>();

        /// <summary>
        ///     The create
        /// </summary>
        public FastestStack<ArchetypeDeferredUpdateRecord> DeferredCreationArchetypes =
            FastestStack<ArchetypeDeferredUpdateRecord>.Create(4);

        /// <summary>
        ///     The create
        /// </summary>
        public FastestStack<GameObjectType> EnabledArchetypes = FastestStack<GameObjectType>.Create(16);

        /// <summary>
        ///     The gameObject only event
        /// </summary>
        public GameObjectOnlyEvent EntityCreatedEvent = new GameObjectOnlyEvent();

        /// <summary>
        ///     The gameObject only event
        /// </summary>
        public GameObjectOnlyEvent EntityDeletedEvent = new GameObjectOnlyEvent();

        //entityID -> gameObject metadata
        /// <summary>
        ///     The gameObject location
        /// </summary>
        public FastestTable<GameObjectLocation> EntityTable = new FastestTable<GameObjectLocation>(256);

        /// <summary>
        ///     The event lookup
        /// </summary>
        public Dictionary<GameObjectIdOnly, EventRecord> EventLookup = [];

        /// <summary>
        ///     The next gameObject id
        /// </summary>
        public int NextEntityId;

        /// <summary>
        ///     The query cache
        /// </summary>
        public Dictionary<int, Query> QueryCache = [];

        /// <summary>
        ///     The gameObject id only
        /// </summary>
        public FastestStack<GameObjectIdOnly> RecycledEntityIds = new FastestStack<GameObjectIdOnly>(256);

        /// <summary>
        ///     The remove component lookup
        /// </summary>
        public FastLookup RemoveComponentLookup = new FastLookup();

        /// <summary>
        ///     The remove tag lookup
        /// </summary>
        public FastLookup RemoveTagLookup = new FastLookup();

        //archetype ID -> Archetype?
        /// <summary>
        ///     The scene archetype table
        /// </summary>
        public WorldArchetypeTableItem[] WorldArchetypeTable;


        /// <summary>
        ///     The scene event flags
        /// </summary>
        public GameObjectFlags WorldEventFlags;

        /// <summary>
        ///     The scene update command buffer
        /// </summary>
        public CommandBuffer WorldUpdateCommandBuffer;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Scene" /> class
        /// </summary>
        public Scene()
        {
            Id = _nextWorldId++;

            GlobalWorldTables.Worlds[Id] = this;

            WorldArchetypeTable = new WorldArchetypeTableItem[GlobalWorldTables.ComponentTagLocationTable.Length];

            WorldUpdateCommandBuffer = new CommandBuffer(this);
            DefaultWorldGameObject = new GameObject(Id, default(ushort), default(int));
            DefaultArchetype = Archetype.CreateOrGetExistingArchetype([], this, FastImmutableArray<ComponentId>.Empty);
        }

        /// <summary>
        ///     Gets the value of the shared countdown
        /// </summary>

        public CountdownEvent SharedCountdown => _sharedCountdown;

        /// <summary>
        ///     Gets the current number of entities managed by the scene.
        /// </summary>
        public int EntityCount => NextEntityId - RecycledEntityIds.Count;

        /// <summary>
        ///     Gets the value of the allow structual changes
        /// </summary>
        public bool AllowStructualChanges => _allowStructuralChanges == -1;

        /// <summary>
        ///     Disposes of the <see cref="Scene" />.
        /// </summary>
        public void Dispose()
        {
            GlobalWorldTables.Worlds[Id] = null!;

            foreach (ref WorldArchetypeTableItem item in WorldArchetypeTable.AsSpan())
            {
                if (item.Archetype is not null)
                {
                    item.Archetype.ReleaseArrays();
                    item.DeferredCreationArchetype.ReleaseArrays();
                }
            }

            _sharedCountdown.Dispose();
            RecycledEntityIds.Dispose();

            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Invoked whenever an gameObject is created on this scene.
        /// </summary>
        public event Action<GameObject> EntityCreated
        {
            add
            {
                EntityCreatedEvent.Add(value);
                WorldEventFlags |= GameObjectFlags.WorldCreate;
            }
            remove
            {
                EntityCreatedEvent.Remove(value);
                if (!EntityCreatedEvent.HasListeners)
                {
                    WorldEventFlags &= ~GameObjectFlags.WorldCreate;
                }
            }
        }

        /// <summary>
        ///     Invoked whenever an gameObject belonging to this scene is deleted.
        /// </summary>
        public event Action<GameObject> EntityDeleted
        {
            add
            {
                EntityDeletedEvent.Add(value);
                WorldEventFlags |= GameObjectFlags.OnDelete;
            }
            remove
            {
                EntityDeletedEvent.Remove(value);
                if (!EntityDeletedEvent.HasListeners)
                {
                    WorldEventFlags &= ~GameObjectFlags.OnDelete;
                }
            }
        }

        /// <summary>
        ///     Invoked whenever a component is added to an gameObject.
        /// </summary>
        public event Action<GameObject, ComponentId> ComponentAdded
        {
            add => AddEvent(ref ComponentAddedEvent, value, GameObjectFlags.AddComp);
            remove => RemoveEvent(ref ComponentAddedEvent, value, GameObjectFlags.AddComp);
        }

        /// <summary>
        ///     Invoked whenever a component is removed from an gameObject.
        /// </summary>
        public event Action<GameObject, ComponentId> ComponentRemoved
        {
            add => AddEvent(ref ComponentRemovedEvent, value, GameObjectFlags.RemoveComp);
            remove => RemoveEvent(ref ComponentRemovedEvent, value, GameObjectFlags.RemoveComp);
        }


        /// <summary>
        ///     Adds the event using the specified event
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="e">The event</param>
        /// <param name="action">The action</param>
        /// <param name="flag">The flag</param>
        internal void AddEvent<T>(ref Event<T> e, Action<GameObject, T> action, GameObjectFlags flag)
        {
            e.Add(action);
            WorldEventFlags |= flag;
        }

        /// <summary>
        ///     Removes the event using the specified event
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="e">The event</param>
        /// <param name="action">The action</param>
        /// <param name="flag">The flag</param>
        internal void RemoveEvent<T>(ref Event<T> e, Action<GameObject, T> action, GameObjectFlags flag)
        {
            e.Remove(action);
            if (!e.HasListeners)
            {
                WorldEventFlags &= ~flag;
            }
        }

        /// <summary>
        ///     Creates the gameObject from location using the specified gameObject location
        /// </summary>
        /// <param name="gameObjectLocation">The gameObject location</param>
        /// <returns>The gameObject</returns>
        public GameObject CreateEntityFromLocation(GameObjectLocation gameObjectLocation)
        {
            (int id, ushort version) =
                RecycledEntityIds.TryPop(out GameObjectIdOnly v) ? v : new GameObjectIdOnly(NextEntityId++, 0);
            gameObjectLocation.Version = version;
            EntityTable[id] = gameObjectLocation;
            return new GameObject(Id, version, id);
        }

        /// <summary>
        /// </summary>
        public void Update()
        {
            EnterDisallowState();
            try
            {
                foreach (GameObjectType element in EnabledArchetypes.AsSpan())
                {
                    element.Archetype(this)!.Update(this);
                }
            }
            finally
            {
                ExitDisallowState(null, true);
            }
        }

        /// <summary>
        ///     Updates all component instances in the scene that implement a component interface and have update methods with the
        ///     <typeparamref name="T" /> attribute
        /// </summary>
        /// <typeparam name="T">The type of attribute to filter</typeparam>
        public void Update<T>() where T : UpdateTypeAttribute
        {
            Update(typeof(T));
        }

        /// <summary>
        ///     Updates all component instances in the scene that implement a component interface and have update methods with an
        ///     attribute of type <paramref name="attributeType" />
        /// </summary>
        /// <param name="attributeType">The attribute type to filter</param>
        public void Update(Type attributeType)
        {
            EnterDisallowState();
            SceneUpdateFilter appliesTo = default(SceneUpdateFilter);
            try
            {
                if (!_updatesByAttributes.TryGetValue(attributeType, out appliesTo))
                {
                    _updatesByAttributes[attributeType] = appliesTo = new SceneUpdateFilter(this, attributeType);
                }

                appliesTo.Update();
            }
            finally
            {
                ExitDisallowState(appliesTo, true);
            }
        }

        /// <summary>
        ///     Updates all instances of a specific component type.
        /// </summary>
        /// <param name="componentType"></param>
        public void UpdateComponent(ComponentId componentType)
        {
            EnterDisallowState();
            SingleComponentUpdateFilter singleComponent = null;

            try
            {
                if (!_singleComponentUpdates.TryGetValue(componentType, out singleComponent))
                {
                    _singleComponentUpdates[componentType] = singleComponent = new SingleComponentUpdateFilter(this, componentType);
                }

                singleComponent.Update();
            }
            finally
            {
                ExitDisallowState(singleComponent, true);
            }
        }

        /// <summary>
        ///     Creates a custom query from the given set of rules. For an gameObject to be queried, all rules must apply.
        /// </summary>
        /// <param name="rules">The rules governing which entities are queried.</param>
        /// <returns>A query object representing all the entities that satisfy all the rules.</returns>
        public Query CustomQuery(params Rule[] rules)
        {
            QueryHash queryHash = QueryHash.New();
            foreach (Rule rule in rules)
            {
                queryHash.AddRule(rule);
            }

            int hashCode = queryHash.ToHashCode();

            if (!QueryCache.TryGetValue(hashCode, out Query query))
            {
                QueryCache[hashCode] = query = CreateQueryFromSpan([.. rules]);
            }

            return query;
        }

        /// <summary>
        ///     Archetypes the added using the specified archetype
        /// </summary>
        /// <param name="archetype">The archetype</param>
        /// <param name="temporaryCreationArchetype">The temporary creation archetype</param>
        public void ArchetypeAdded(Archetype archetype, Archetype temporaryCreationArchetype)
        {
            if (!GlobalWorldTables.Has(archetype.Id))
            {
                EnabledArchetypes.Push(archetype.Id);
            }

            foreach (KeyValuePair<int, Query> qkvp in QueryCache)
            {
                qkvp.Value.TryAttachArchetype(archetype);
            }

            foreach (KeyValuePair<Type, SceneUpdateFilter> fkvp in _updatesByAttributes)
            {
                fkvp.Value.ArchetypeAdded(archetype);
            }

            foreach (KeyValuePair<ComponentId, SingleComponentUpdateFilter> fkvp in _singleComponentUpdates)
            {
                fkvp.Value.ArchetypeAdded(archetype);
            }
        }

        /// <summary>
        ///     Creates the query using the specified rules
        /// </summary>
        /// <param name="rules">The rules</param>
        /// <returns>The </returns>
        public Query CreateQuery(FastImmutableArray<Rule> rules)
        {
            Query q = new Query(this, rules);
            foreach (ref WorldArchetypeTableItem element in WorldArchetypeTable.AsSpan())
            {
                if (element.Archetype is not null)
                {
                    q.TryAttachArchetype(element.Archetype);
                }
            }

            return q;
        }

        /// <summary>
        ///     Creates the query from span using the specified rules
        /// </summary>
        /// <param name="rules">The rules</param>
        /// <returns>The query</returns>
        public Query CreateQueryFromSpan(ReadOnlySpan<Rule> rules) => CreateQuery(MemoryHelpers.ReadOnlySpanToImmutableArray(rules));

        /// <summary>
        ///     Updates the archetype table using the specified new size
        /// </summary>
        /// <param name="newSize">The new size</param>
        public void UpdateArchetypeTable(int newSize)
        {
            Array.Resize(ref WorldArchetypeTable, newSize);
        }

        /// <summary>
        ///     Enters the disallow state
        /// </summary>
        public void EnterDisallowState()
        {
            if (Interlocked.Increment(ref _allowStructuralChanges) == 0)
            {
                Interlocked.Increment(ref _allowStructuralChanges);
            }
        }

        /// <summary>
        ///     Exits the disallow state using the specified filter used
        /// </summary>
        /// <param name="filterUsed">The filter used</param>
        /// <param name="updateDeferredEntities">The update deferred entities</param>
        public void ExitDisallowState(IComponentUpdateFilter filterUsed, bool updateDeferredEntities = false)
        {
            if (Interlocked.Decrement(ref _allowStructuralChanges) == 0)
            {
                if (DeferredCreationArchetypes.Count > 0)
                {
                    if (updateDeferredEntities)
                    {
                        ResolveUpdateDeferredCreationEntities(filterUsed);
                    }
                    else
                    {
                        foreach ((Archetype archetype, Archetype tmp, int _) in DeferredCreationArchetypes.AsSpan())
                        {
                            archetype.ResolveDeferredEntityCreations(this, tmp);
                        }
                    }
                }

                DeferredCreationArchetypes.Clear();
                Interlocked.Decrement(ref _allowStructuralChanges);

                int count = 0;
                while (WorldUpdateCommandBuffer.Playback())
                {
                    if (++count > DeferredEntityOperationRecursionLimit)
                    {
                        throw new InvalidOperationException(
                            "Deferred gameObject creation recursion limit exceeded! Are your component events creating command buffer items? (which create more command buffer items...)?");
                    }
                }
            }
        }

        /// <summary>
        ///     Resolves the update deferred creation entities using the specified filter used
        /// </summary>
        /// <param name="filterUsed">The filter used</param>
        internal void ResolveUpdateDeferredCreationEntities(IComponentUpdateFilter filterUsed)
        {
            Span<ArchetypeDeferredUpdateRecord> resolveArchetypes = DeferredCreationArchetypes.AsSpan();

            Interlocked.Increment(ref _allowStructuralChanges);

            int createRecursionCount = 0;
            while (resolveArchetypes.Length != 0)
            {
                foreach ((Archetype archetype, Archetype tmp, int _) in resolveArchetypes)
                {
                    archetype.ResolveDeferredEntityCreations(this, tmp);
                }

                (_altDeferredCreationArchetypes, DeferredCreationArchetypes) =
                    (DeferredCreationArchetypes, _altDeferredCreationArchetypes);
                DeferredCreationArchetypes.Clear();

                if (filterUsed is not null)
                {
                    filterUsed?.UpdateSubset(resolveArchetypes);
                }
                else
                {
                    foreach ((Archetype archetype, Archetype _, int start) in resolveArchetypes)
                    {
                        archetype.Update(this, start, archetype.EntityCount - start);
                    }
                }

                resolveArchetypes = DeferredCreationArchetypes.AsSpan();

                if (++createRecursionCount > DeferredEntityOperationRecursionLimit)
                {
                    throw new InvalidOperationException(
                        "Deferred gameObject creation recursion limit exceeded! Are your components creating entities (which create more entities...)?");
                }
            }

            DeferredCreationArchetypes.Clear();
            Interlocked.Decrement(ref _allowStructuralChanges);
        }

        /// <summary>
        ///     Creates an <see cref="GameObject" />
        /// </summary>
        /// <param name="components">The components to use</param>
        /// <returns>The created gameObject</returns>
        public GameObject CreateFromObjects(ReadOnlySpan<object> components)
        {
            if (components.Length > MemoryHelpers.MaxComponentCount)
            {
                throw new ArgumentException("Max 127 components on an gameObject", nameof(components));
            }

            Span<ComponentId> types = stackalloc ComponentId[components.Length];

            for (int i = 0; i < components.Length; i++)
            {
                types[i] = Component.GetComponentId(components[i].GetType());
            }

            Archetype archetype = Archetype.CreateOrGetExistingArchetype(types!, this);

            ref GameObjectIdOnly entityId = ref archetype.CreateEntityLocation(GameObjectFlags.None, out GameObjectLocation loc);
            GameObject gameObject = CreateEntityFromLocation(loc);
            entityId.ID = gameObject.EntityID;
            entityId.Version = gameObject.EntityVersion;

            Span<ComponentStorageBase> archetypeComponents = archetype.Components.AsSpan();
            for (int i = 1; i < archetypeComponents.Length; i++)
            {
                archetypeComponents[i].SetAt(components[i - 1], loc.Index);
            }

            EntityCreatedEvent.Invoke(gameObject);
            return gameObject;
        }

        /// <summary>
        ///     Creates an <see cref="GameObject" /> with zero components.
        /// </summary>
        /// <returns>The gameObject that was created.</returns>
        public GameObject Create()
        {
            GameObject gameObject = CreateEntityWithoutEvent();
            EntityCreatedEvent.Invoke(gameObject);
            return gameObject;
        }

        /// <summary>
        ///     Creates the gameObject without event
        /// </summary>
        /// <returns>The gameObject</returns>
        public GameObject CreateEntityWithoutEvent()
        {
            ref GameObjectIdOnly entity = ref DefaultArchetype.CreateEntityLocation(GameObjectFlags.None, out GameObjectLocation eloc);

            (int id, ushort version) =
                entity = RecycledEntityIds.CanPop() ? RecycledEntityIds.Pop() : new GameObjectIdOnly(NextEntityId++, 0);
            eloc.Version = version;
            EntityTable[id] = eloc;

            return new GameObject(Id, version, id);
        }

        /// <summary>
        ///     Invokes the gameObject created using the specified gameObject
        /// </summary>
        /// <param name="gameObject">The gameObject</param>
        public void InvokeEntityCreated(GameObject gameObject)
        {
            EntityCreatedEvent.Invoke(gameObject);
        }

        /// <summary>
        ///     Allocates memory sufficient to store <paramref name="count" /> entities of a type
        /// </summary>
        /// <param name="entityType">The types of the gameObject to allocate for</param>
        /// <param name="count">Number of gameObject spaces to allocate</param>
        /// <remarks>Use this method when creating a large number of entities</remarks>
        public void EnsureCapacity(GameObjectType entityType, int count)
        {
            if (count < 1)
            {
                return;
            }

            Archetype archetype = Archetype.CreateOrGetExistingArchetype(entityType, this);
            EnsureCapacityCore(archetype, count);
        }

        /// <summary>
        ///     Ensures the capacity core using the specified archetype
        /// </summary>
        /// <param name="archetype">The archetype</param>
        /// <param name="count">The count</param>
        /// <exception cref="ArgumentOutOfRangeException">Count must be positive </exception>
        public void EnsureCapacityCore(Archetype archetype, int count)
        {
            if (count < 1)
            {
                throw new ArgumentOutOfRangeException("Count must be positive", nameof(count));
            }

            archetype.EnsureCapacity(count);
            EntityTable.EnsureCapacity(count + EntityCount);
        }


        /// <summary>
        ///     Creates an <see cref="GameObject" /> with the given component(s)
        /// </summary>
        /// <returns>An <see cref="GameObject" /> that can be used to acsess the component data</returns>
        public GameObject Create<T1, T2>(in T1 comp1, in T2 comp2)
        {
            WorldArchetypeTableItem archetypes = Archetype<T1, T2>.CreateNewOrGetExistingArchetypes(this);

            ref GameObjectIdOnly entity = ref Unsafe.NullRef<GameObjectIdOnly>();
            GameObjectLocation eloc = default(GameObjectLocation);

            ComponentStorageBase[] components;

            if (AllowStructualChanges)
            {
                components = archetypes.Archetype.Components;
                entity = ref archetypes.Archetype.CreateEntityLocation(GameObjectFlags.None, out eloc);
            }
            else
            {
                // we don't need to manually set flags, they are already zeroed
                entity = ref archetypes.Archetype.CreateDeferredEntityLocation(this, archetypes.DeferredCreationArchetype,
                    ref eloc, out components);
            }

            //manually inlined from Scene.CreateEntityFromLocation
            //The jit likes to inline the outer create function and not inline
            //the inner functions - benchmarked to improve perf by 10-20%
            (int id, ushort version) =
                entity = RecycledEntityIds.CanPop() ? RecycledEntityIds.Pop() : new GameObjectIdOnly(NextEntityId++, 0);
            eloc.Version = version;
            EntityTable[id] = eloc;

            //1x array lookup per component
            ref T1 ref1 =
                ref Unsafe.As<ComponentStorage<T1>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T1>.Index))[eloc.Index];
            ref1 = comp1;
            ref T2 ref2 =
                ref Unsafe.As<ComponentStorage<T2>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T2>.Index))[eloc.Index];
            ref2 = comp2;


            GameObject concreteGameObject = new GameObject(Id, version, id);

            Component<T1>.Initer?.Invoke(concreteGameObject, ref ref1);
            Component<T2>.Initer?.Invoke(concreteGameObject, ref ref2);

            EntityCreatedEvent.Invoke(concreteGameObject);

            return concreteGameObject;
        }


        /// <summary>
        ///     Creates the many using the specified count
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <param name="count">The count</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>A chunk tuple of t 1 and t 2</returns>
        public ChunkTuple<T1, T2> CreateMany<T1, T2>(int count)
        {
            if ((uint) count == 0) // Efficient validation for non-positive values
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            WorldArchetypeTableItem archetype = Archetype<T1, T2>.CreateNewOrGetExistingArchetypes(this);
            int entityCount = archetype.Archetype.EntityCount;

            EntityTable.EnsureCapacity(EntityCount + count);

            // Create gameObject locations directly in a Span
            Span<GameObjectIdOnly> entityLocations = archetype.Archetype.CreateEntityLocations(count, this);

            // Invoke events if listeners are present
            if (EntityCreatedEvent.HasListeners)
            {
                foreach (ref GameObjectIdOnly entityId in entityLocations)
                {
                    EntityCreatedEvent.Invoke(entityId.ToEntity(this));
                }
            }

            // Return the result with calculated spans
            return new ChunkTuple<T1, T2>
            {
                Entities = new GameObjectEnumerator.EntityEnumerable(this, entityLocations),
                Span1 = archetype.Archetype.GetComponentSpan<T1>().Slice(entityCount, count),
                Span2 = archetype.Archetype.GetComponentSpan<T2>().Slice(entityCount, count)
            };
        }


        /// <summary>
        ///     Creates an <see cref="GameObject" /> with the given component(s)
        /// </summary>
        /// <returns>An <see cref="GameObject" /> that can be used to acsess the component data</returns>
        public GameObject Create<T1, T2, T3>(in T1 comp1, in T2 comp2, in T3 comp3)
        {
            WorldArchetypeTableItem archetypes = Archetype<T1, T2, T3>.CreateNewOrGetExistingArchetypes(this);

            ref GameObjectIdOnly entity = ref Unsafe.NullRef<GameObjectIdOnly>();
            GameObjectLocation eloc = default(GameObjectLocation);

            ComponentStorageBase[] components;

            if (AllowStructualChanges)
            {
                components = archetypes.Archetype.Components;
                entity = ref archetypes.Archetype.CreateEntityLocation(GameObjectFlags.None, out eloc);
            }
            else
            {
                // we don't need to manually set flags, they are already zeroed
                entity = ref archetypes.Archetype.CreateDeferredEntityLocation(this, archetypes.DeferredCreationArchetype,
                    ref eloc, out components);
            }

            //manually inlined from Scene.CreateEntityFromLocation
            //The jit likes to inline the outer create function and not inline
            //the inner functions - benchmarked to improve perf by 10-20%
            (int id, ushort version) =
                entity = RecycledEntityIds.CanPop() ? RecycledEntityIds.Pop() : new GameObjectIdOnly(NextEntityId++, 0);
            eloc.Version = version;
            EntityTable[id] = eloc;

            //1x array lookup per component
            ref T1 ref1 =
                ref Unsafe.As<ComponentStorage<T1>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T3, T1>.Index))[eloc.Index];
            ref1 = comp1;
            ref T2 ref2 =
                ref Unsafe.As<ComponentStorage<T2>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T3, T2>.Index))[eloc.Index];
            ref2 = comp2;
            ref T3 ref3 =
                ref Unsafe.As<ComponentStorage<T3>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T3, T3>.Index))[eloc.Index];
            ref3 = comp3;


            GameObject concreteGameObject = new GameObject(Id, version, id);

            Component<T1>.Initer?.Invoke(concreteGameObject, ref ref1);
            Component<T2>.Initer?.Invoke(concreteGameObject, ref ref2);
            Component<T3>.Initer?.Invoke(concreteGameObject, ref ref3);

            EntityCreatedEvent.Invoke(concreteGameObject);

            return concreteGameObject;
        }

        /// <summary>
        ///     Creates a large amount of entities quickly
        /// </summary>
        /// <param name="count">The number of entities to create</param>
        /// <returns>The entities created and their component spans</returns>
        public ChunkTuple<T1, T2, T3> CreateMany<T1, T2, T3>(int count)
        {
            if ((uint) count == 0) // Efficient validation for non-positive values
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            WorldArchetypeTableItem archetype = Archetype<T1, T2, T3>.CreateNewOrGetExistingArchetypes(this);
            int entityCount = archetype.Archetype.EntityCount;

            EntityTable.EnsureCapacity(EntityCount + count);

            // Create gameObject locations directly in a Span
            Span<GameObjectIdOnly> entityLocations = archetype.Archetype.CreateEntityLocations(count, this);

            // Invoke events if listeners are present
            if (EntityCreatedEvent.HasListeners)
            {
                foreach (ref GameObjectIdOnly entityId in entityLocations)
                {
                    EntityCreatedEvent.Invoke(entityId.ToEntity(this));
                }
            }

            // Return the result with calculated spans
            return new ChunkTuple<T1, T2, T3>
            {
                Entities = new GameObjectEnumerator.EntityEnumerable(this, entityLocations),
                Span1 = archetype.Archetype.GetComponentSpan<T1>().Slice(entityCount, count),
                Span2 = archetype.Archetype.GetComponentSpan<T2>().Slice(entityCount, count),
                Span3 = archetype.Archetype.GetComponentSpan<T3>().Slice(entityCount, count)
            };
        }

        /// <summary>
        ///     Creates an <see cref="GameObject" /> with the given component(s)
        /// </summary>
        /// <returns>An <see cref="GameObject" /> that can be used to acsess the component data</returns>
        public GameObject Create<T1, T2, T3, T4>(in T1 comp1, in T2 comp2, in T3 comp3, in T4 comp4)
        {
            WorldArchetypeTableItem archetypes = Archetype<T1, T2, T3, T4>.CreateNewOrGetExistingArchetypes(this);

            ref GameObjectIdOnly entity = ref Unsafe.NullRef<GameObjectIdOnly>();
            GameObjectLocation eloc = default(GameObjectLocation);

            ComponentStorageBase[] components;

            if (AllowStructualChanges)
            {
                components = archetypes.Archetype.Components;
                entity = ref archetypes.Archetype.CreateEntityLocation(GameObjectFlags.None, out eloc);
            }
            else
            {
                // we don't need to manually set flags, they are already zeroed
                entity = ref archetypes.Archetype.CreateDeferredEntityLocation(this, archetypes.DeferredCreationArchetype,
                    ref eloc, out components);
            }

            //manually inlined from Scene.CreateEntityFromLocation
            //The jit likes to inline the outer create function and not inline
            //the inner functions - benchmarked to improve perf by 10-20%
            (int id, ushort version) =
                entity = RecycledEntityIds.CanPop() ? RecycledEntityIds.Pop() : new GameObjectIdOnly(NextEntityId++, 0);
            eloc.Version = version;
            EntityTable[id] = eloc;

            //1x array lookup per component
            ref T1 ref1 =
                ref Unsafe.As<ComponentStorage<T1>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T3, T4, T1>.Index))[eloc.Index];
            ref1 = comp1;
            ref T2 ref2 =
                ref Unsafe.As<ComponentStorage<T2>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T3, T4, T2>.Index))[eloc.Index];
            ref2 = comp2;
            ref T3 ref3 =
                ref Unsafe.As<ComponentStorage<T3>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T3, T4, T3>.Index))[eloc.Index];
            ref3 = comp3;
            ref T4 ref4 =
                ref Unsafe.As<ComponentStorage<T4>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T3, T4, T4>.Index))[eloc.Index];
            ref4 = comp4;


            GameObject concreteGameObject = new GameObject(Id, version, id);

            Component<T1>.Initer?.Invoke(concreteGameObject, ref ref1);
            Component<T2>.Initer?.Invoke(concreteGameObject, ref ref2);
            Component<T3>.Initer?.Invoke(concreteGameObject, ref ref3);
            Component<T4>.Initer?.Invoke(concreteGameObject, ref ref4);

            EntityCreatedEvent.Invoke(concreteGameObject);

            return concreteGameObject;
        }

        /// <summary>
        ///     Creates a large amount of entities quickly
        /// </summary>
        /// <param name="count">The number of entities to create</param>
        /// <returns>The entities created and their component spans</returns>
        public ChunkTuple<T1, T2, T3, T4> CreateMany<T1, T2, T3, T4>(int count)
        {
            if ((uint) count == 0) // Efficient validation for non-positive values
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            WorldArchetypeTableItem archetype = Archetype<T1, T2, T3, T4>.CreateNewOrGetExistingArchetypes(this);
            int entityCount = archetype.Archetype.EntityCount;

            EntityTable.EnsureCapacity(EntityCount + count);

            // Create gameObject locations directly in a Span
            Span<GameObjectIdOnly> entityLocations = archetype.Archetype.CreateEntityLocations(count, this);

            // Invoke events if listeners are present
            if (EntityCreatedEvent.HasListeners)
            {
                foreach (ref GameObjectIdOnly entityId in entityLocations)
                {
                    EntityCreatedEvent.Invoke(entityId.ToEntity(this));
                }
            }

            // Return the result with calculated spans
            return new ChunkTuple<T1, T2, T3, T4>
            {
                Entities = new GameObjectEnumerator.EntityEnumerable(this, entityLocations),
                Span1 = archetype.Archetype.GetComponentSpan<T1>().Slice(entityCount, count),
                Span2 = archetype.Archetype.GetComponentSpan<T2>().Slice(entityCount, count),
                Span3 = archetype.Archetype.GetComponentSpan<T3>().Slice(entityCount, count),
                Span4 = archetype.Archetype.GetComponentSpan<T4>().Slice(entityCount, count)
            };
        }


        /// <summary>
        ///     Creates an <see cref="GameObject" /> with the given component(s)
        /// </summary>
        /// <returns>An <see cref="GameObject" /> that can be used to acsess the component data</returns>
        public GameObject Create<T1, T2, T3, T4, T5>(in T1 comp1, in T2 comp2, in T3 comp3, in T4 comp4, in T5 comp5)
        {
            WorldArchetypeTableItem archetypes = Archetype<T1, T2, T3, T4, T5>.CreateNewOrGetExistingArchetypes(this);

            ref GameObjectIdOnly entity = ref Unsafe.NullRef<GameObjectIdOnly>();
            GameObjectLocation eloc = default(GameObjectLocation);

            ComponentStorageBase[] components;

            if (AllowStructualChanges)
            {
                components = archetypes.Archetype.Components;
                entity = ref archetypes.Archetype.CreateEntityLocation(GameObjectFlags.None, out eloc);
            }
            else
            {
                // we don't need to manually set flags, they are already zeroed
                entity = ref archetypes.Archetype.CreateDeferredEntityLocation(this, archetypes.DeferredCreationArchetype,
                    ref eloc, out components);
            }

            //manually inlined from Scene.CreateEntityFromLocation
            //The jit likes to inline the outer create function and not inline
            //the inner functions - benchmarked to improve perf by 10-20%
            (int id, ushort version) =
                entity = RecycledEntityIds.CanPop() ? RecycledEntityIds.Pop() : new GameObjectIdOnly(NextEntityId++, 0);
            eloc.Version = version;
            EntityTable[id] = eloc;

            //1x array lookup per component
            ref T1 ref1 =
                ref Unsafe.As<ComponentStorage<T1>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T3, T4, T5, T1>.Index))[eloc.Index];
            ref1 = comp1;
            ref T2 ref2 =
                ref Unsafe.As<ComponentStorage<T2>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T3, T4, T5, T2>.Index))[eloc.Index];
            ref2 = comp2;
            ref T3 ref3 =
                ref Unsafe.As<ComponentStorage<T3>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T3, T4, T5, T3>.Index))[eloc.Index];
            ref3 = comp3;
            ref T4 ref4 =
                ref Unsafe.As<ComponentStorage<T4>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T3, T4, T5, T4>.Index))[eloc.Index];
            ref4 = comp4;
            ref T5 ref5 =
                ref Unsafe.As<ComponentStorage<T5>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T3, T4, T5, T5>.Index))[eloc.Index];
            ref5 = comp5;


            GameObject concreteGameObject = new GameObject(Id, version, id);

            Component<T1>.Initer?.Invoke(concreteGameObject, ref ref1);
            Component<T2>.Initer?.Invoke(concreteGameObject, ref ref2);
            Component<T3>.Initer?.Invoke(concreteGameObject, ref ref3);
            Component<T4>.Initer?.Invoke(concreteGameObject, ref ref4);
            Component<T5>.Initer?.Invoke(concreteGameObject, ref ref5);

            EntityCreatedEvent.Invoke(concreteGameObject);

            return concreteGameObject;
        }


        /// <summary>
        ///     Creates the many using the specified count
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <param name="count">The count</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>A chunk tuple of t 1 and t 2 and t 3 and t 4 and t 5</returns>
        public ChunkTuple<T1, T2, T3, T4, T5> CreateMany<T1, T2, T3, T4, T5>(int count)
        {
            if ((uint) count == 0) // Efficient validation for non-positive values
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            WorldArchetypeTableItem archetype = Archetype<T1, T2, T3, T4, T5>.CreateNewOrGetExistingArchetypes(this);
            int entityCount = archetype.Archetype.EntityCount;

            EntityTable.EnsureCapacity(EntityCount + count);

            // Create gameObject locations directly in a Span
            Span<GameObjectIdOnly> entityLocations = archetype.Archetype.CreateEntityLocations(count, this);

            // Invoke events if listeners are present
            if (EntityCreatedEvent.HasListeners)
            {
                foreach (ref GameObjectIdOnly entityId in entityLocations)
                {
                    EntityCreatedEvent.Invoke(entityId.ToEntity(this));
                }
            }

            // Return the result with calculated spans
            return new ChunkTuple<T1, T2, T3, T4, T5>
            {
                Entities = new GameObjectEnumerator.EntityEnumerable(this, entityLocations),
                Span1 = archetype.Archetype.GetComponentSpan<T1>().Slice(entityCount, count),
                Span2 = archetype.Archetype.GetComponentSpan<T2>().Slice(entityCount, count),
                Span3 = archetype.Archetype.GetComponentSpan<T3>().Slice(entityCount, count),
                Span4 = archetype.Archetype.GetComponentSpan<T4>().Slice(entityCount, count),
                Span5 = archetype.Archetype.GetComponentSpan<T5>().Slice(entityCount, count)
            };
        }

        /// <summary>
        ///     Creates an <see cref="GameObject" /> with the given component(s)
        /// </summary>
        /// <returns>An <see cref="GameObject" /> that can be used to acsess the component data</returns>
        public GameObject Create<T1, T2, T3, T4, T5, T6>(in T1 comp1, in T2 comp2, in T3 comp3, in T4 comp4, in T5 comp5,
            in T6 comp6)
        {
            WorldArchetypeTableItem archetypes = Archetype<T1, T2, T3, T4, T5, T6>.CreateNewOrGetExistingArchetypes(this);

            ref GameObjectIdOnly entity = ref Unsafe.NullRef<GameObjectIdOnly>();
            GameObjectLocation eloc = default(GameObjectLocation);

            ComponentStorageBase[] components;

            if (AllowStructualChanges)
            {
                components = archetypes.Archetype.Components;
                entity = ref archetypes.Archetype.CreateEntityLocation(GameObjectFlags.None, out eloc);
            }
            else
            {
                // we don't need to manually set flags, they are already zeroed
                entity = ref archetypes.Archetype.CreateDeferredEntityLocation(this, archetypes.DeferredCreationArchetype,
                    ref eloc, out components);
            }

            //manually inlined from Scene.CreateEntityFromLocation
            //The jit likes to inline the outer create function and not inline
            //the inner functions - benchmarked to improve perf by 10-20%
            (int id, ushort version) =
                entity = RecycledEntityIds.CanPop() ? RecycledEntityIds.Pop() : new GameObjectIdOnly(NextEntityId++, 0);
            eloc.Version = version;
            EntityTable[id] = eloc;

            //1x array lookup per component
            ref T1 ref1 =
                ref Unsafe.As<ComponentStorage<T1>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T3, T4, T5, T6, T1>.Index))[eloc.Index];
            ref1 = comp1;
            ref T2 ref2 =
                ref Unsafe.As<ComponentStorage<T2>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T3, T4, T5, T6, T2>.Index))[eloc.Index];
            ref2 = comp2;
            ref T3 ref3 =
                ref Unsafe.As<ComponentStorage<T3>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T3, T4, T5, T6, T3>.Index))[eloc.Index];
            ref3 = comp3;
            ref T4 ref4 =
                ref Unsafe.As<ComponentStorage<T4>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T3, T4, T5, T6, T4>.Index))[eloc.Index];
            ref4 = comp4;
            ref T5 ref5 =
                ref Unsafe.As<ComponentStorage<T5>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T3, T4, T5, T6, T5>.Index))[eloc.Index];
            ref5 = comp5;
            ref T6 ref6 =
                ref Unsafe.As<ComponentStorage<T6>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T3, T4, T5, T6, T6>.Index))[eloc.Index];
            ref6 = comp6;


            GameObject concreteGameObject = new GameObject(Id, version, id);

            Component<T1>.Initer?.Invoke(concreteGameObject, ref ref1);
            Component<T2>.Initer?.Invoke(concreteGameObject, ref ref2);
            Component<T3>.Initer?.Invoke(concreteGameObject, ref ref3);
            Component<T4>.Initer?.Invoke(concreteGameObject, ref ref4);
            Component<T5>.Initer?.Invoke(concreteGameObject, ref ref5);
            Component<T6>.Initer?.Invoke(concreteGameObject, ref ref6);

            EntityCreatedEvent.Invoke(concreteGameObject);

            return concreteGameObject;
        }


        /// <summary>
        ///     Creates the many using the specified count
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <param name="count">The count</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>A chunk tuple of t 1 and t 2 and t 3 and t 4 and t 5 and t 6</returns>
        public ChunkTuple<T1, T2, T3, T4, T5, T6> CreateMany<T1, T2, T3, T4, T5, T6>(int count)
        {
            if ((uint) count == 0) // Efficient validation for non-positive values
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            WorldArchetypeTableItem archetype = Archetype<T1, T2, T3, T4, T5, T6>.CreateNewOrGetExistingArchetypes(this);
            int entityCount = archetype.Archetype.EntityCount;

            EntityTable.EnsureCapacity(EntityCount + count);

            // Create gameObject locations directly in a Span
            Span<GameObjectIdOnly> entityLocations = archetype.Archetype.CreateEntityLocations(count, this);

            // Invoke events if listeners are present
            if (EntityCreatedEvent.HasListeners)
            {
                foreach (ref GameObjectIdOnly entityId in entityLocations)
                {
                    EntityCreatedEvent.Invoke(entityId.ToEntity(this));
                }
            }

            // Return the result with calculated spans
            return new ChunkTuple<T1, T2, T3, T4, T5, T6>
            {
                Entities = new GameObjectEnumerator.EntityEnumerable(this, entityLocations),
                Span1 = archetype.Archetype.GetComponentSpan<T1>().Slice(entityCount, count),
                Span2 = archetype.Archetype.GetComponentSpan<T2>().Slice(entityCount, count),
                Span3 = archetype.Archetype.GetComponentSpan<T3>().Slice(entityCount, count),
                Span4 = archetype.Archetype.GetComponentSpan<T4>().Slice(entityCount, count),
                Span5 = archetype.Archetype.GetComponentSpan<T5>().Slice(entityCount, count),
                Span6 = archetype.Archetype.GetComponentSpan<T6>().Slice(entityCount, count)
            };
        }

        /// <summary>
        ///     Creates an <see cref="GameObject" /> with the given component(s)
        /// </summary>
        /// <returns>An <see cref="GameObject" /> that can be used to acsess the component data</returns>
        public GameObject Create<T1, T2, T3, T4, T5, T6, T7>(in T1 comp1, in T2 comp2, in T3 comp3, in T4 comp4, in T5 comp5,
            in T6 comp6, in T7 comp7)
        {
            WorldArchetypeTableItem archetypes =
                Archetype<T1, T2, T3, T4, T5, T6, T7>.CreateNewOrGetExistingArchetypes(this);

            ref GameObjectIdOnly entity = ref Unsafe.NullRef<GameObjectIdOnly>();
            GameObjectLocation eloc = default(GameObjectLocation);

            ComponentStorageBase[] components;

            if (AllowStructualChanges)
            {
                components = archetypes.Archetype.Components;
                entity = ref archetypes.Archetype.CreateEntityLocation(GameObjectFlags.None, out eloc);
            }
            else
            {
                // we don't need to manually set flags, they are already zeroed
                entity = ref archetypes.Archetype.CreateDeferredEntityLocation(this, archetypes.DeferredCreationArchetype,
                    ref eloc, out components);
            }

            //manually inlined from Scene.CreateEntityFromLocation
            //The jit likes to inline the outer create function and not inline
            //the inner functions - benchmarked to improve perf by 10-20%
            (int id, ushort version) =
                entity = RecycledEntityIds.CanPop() ? RecycledEntityIds.Pop() : new GameObjectIdOnly(NextEntityId++, 0);
            eloc.Version = version;
            EntityTable[id] = eloc;

            //1x array lookup per component
            ref T1 ref1 =
                ref Unsafe.As<ComponentStorage<T1>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T3, T4, T5, T6, T7, T1>.Index))[eloc.Index];
            ref1 = comp1;
            ref T2 ref2 =
                ref Unsafe.As<ComponentStorage<T2>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T3, T4, T5, T6, T7, T2>.Index))[eloc.Index];
            ref2 = comp2;
            ref T3 ref3 =
                ref Unsafe.As<ComponentStorage<T3>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T3, T4, T5, T6, T7, T3>.Index))[eloc.Index];
            ref3 = comp3;
            ref T4 ref4 =
                ref Unsafe.As<ComponentStorage<T4>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T3, T4, T5, T6, T7, T4>.Index))[eloc.Index];
            ref4 = comp4;
            ref T5 ref5 =
                ref Unsafe.As<ComponentStorage<T5>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T3, T4, T5, T6, T7, T5>.Index))[eloc.Index];
            ref5 = comp5;
            ref T6 ref6 =
                ref Unsafe.As<ComponentStorage<T6>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T3, T4, T5, T6, T7, T6>.Index))[eloc.Index];
            ref6 = comp6;
            ref T7 ref7 =
                ref Unsafe.As<ComponentStorage<T7>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T3, T4, T5, T6, T7, T7>.Index))[eloc.Index];
            ref7 = comp7;


            GameObject concreteGameObject = new GameObject(Id, version, id);

            Component<T1>.Initer?.Invoke(concreteGameObject, ref ref1);
            Component<T2>.Initer?.Invoke(concreteGameObject, ref ref2);
            Component<T3>.Initer?.Invoke(concreteGameObject, ref ref3);
            Component<T4>.Initer?.Invoke(concreteGameObject, ref ref4);
            Component<T5>.Initer?.Invoke(concreteGameObject, ref ref5);
            Component<T6>.Initer?.Invoke(concreteGameObject, ref ref6);
            Component<T7>.Initer?.Invoke(concreteGameObject, ref ref7);

            EntityCreatedEvent.Invoke(concreteGameObject);

            return concreteGameObject;
        }


        /// <summary>
        ///     Creates the many using the specified count
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <typeparam name="T7">The </typeparam>
        /// <param name="count">The count</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>A chunk tuple of t 1 and t 2 and t 3 and t 4 and t 5 and t 6 and t 7</returns>
        public ChunkTuple<T1, T2, T3, T4, T5, T6, T7> CreateMany<T1, T2, T3, T4, T5, T6, T7>(int count)
        {
            if ((uint) count == 0) // Efficient validation for non-positive values
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            WorldArchetypeTableItem archetype =
                Archetype<T1, T2, T3, T4, T5, T6, T7>.CreateNewOrGetExistingArchetypes(this);
            int entityCount = archetype.Archetype.EntityCount;

            EntityTable.EnsureCapacity(EntityCount + count);

            // Create gameObject locations directly in a Span
            Span<GameObjectIdOnly> entityLocations = archetype.Archetype.CreateEntityLocations(count, this);

            // Invoke events if listeners are present
            if (EntityCreatedEvent.HasListeners)
            {
                foreach (ref GameObjectIdOnly entityId in entityLocations)
                {
                    EntityCreatedEvent.Invoke(entityId.ToEntity(this));
                }
            }

            // Return the result with calculated spans
            return new ChunkTuple<T1, T2, T3, T4, T5, T6, T7>
            {
                Entities = new GameObjectEnumerator.EntityEnumerable(this, entityLocations),
                Span1 = archetype.Archetype.GetComponentSpan<T1>().Slice(entityCount, count),
                Span2 = archetype.Archetype.GetComponentSpan<T2>().Slice(entityCount, count),
                Span3 = archetype.Archetype.GetComponentSpan<T3>().Slice(entityCount, count),
                Span4 = archetype.Archetype.GetComponentSpan<T4>().Slice(entityCount, count),
                Span5 = archetype.Archetype.GetComponentSpan<T5>().Slice(entityCount, count),
                Span6 = archetype.Archetype.GetComponentSpan<T6>().Slice(entityCount, count),
                Span7 = archetype.Archetype.GetComponentSpan<T7>().Slice(entityCount, count)
            };
        }

        /// <summary>
        ///     Creates an <see cref="GameObject" /> with the given component(s)
        /// </summary>
        /// <returns>An <see cref="GameObject" /> that can be used to acsess the component data</returns>
        public GameObject Create<T1, T2, T3, T4, T5, T6, T7, T8>(in T1 comp1, in T2 comp2, in T3 comp3, in T4 comp4,
            in T5 comp5, in T6 comp6, in T7 comp7, in T8 comp8)
        {
            WorldArchetypeTableItem archetypes =
                Archetype<T1, T2, T3, T4, T5, T6, T7, T8>.CreateNewOrGetExistingArchetypes(this);

            ref GameObjectIdOnly entity = ref Unsafe.NullRef<GameObjectIdOnly>();
            GameObjectLocation eloc = default(GameObjectLocation);

            ComponentStorageBase[] components;

            if (AllowStructualChanges)
            {
                components = archetypes.Archetype.Components;
                entity = ref archetypes.Archetype.CreateEntityLocation(GameObjectFlags.None, out eloc);
            }
            else
            {
                // we don't need to manually set flags, they are already zeroed
                entity = ref archetypes.Archetype.CreateDeferredEntityLocation(this, archetypes.DeferredCreationArchetype,
                    ref eloc, out components);
            }

            //manually inlined from Scene.CreateEntityFromLocation
            //The jit likes to inline the outer create function and not inline
            //the inner functions - benchmarked to improve perf by 10-20%
            (int id, ushort version) =
                entity = RecycledEntityIds.CanPop() ? RecycledEntityIds.Pop() : new GameObjectIdOnly(NextEntityId++, 0);
            eloc.Version = version;
            EntityTable[id] = eloc;

            //1x array lookup per component
            ref T1 ref1 =
                ref Unsafe.As<ComponentStorage<T1>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T3, T4, T5, T6, T7, T8, T1>.Index))[
                    eloc.Index];
            ref1 = comp1;
            ref T2 ref2 =
                ref Unsafe.As<ComponentStorage<T2>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T3, T4, T5, T6, T7, T8, T2>.Index))[
                    eloc.Index];
            ref2 = comp2;
            ref T3 ref3 =
                ref Unsafe.As<ComponentStorage<T3>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T3, T4, T5, T6, T7, T8, T3>.Index))[
                    eloc.Index];
            ref3 = comp3;
            ref T4 ref4 =
                ref Unsafe.As<ComponentStorage<T4>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T3, T4, T5, T6, T7, T8, T4>.Index))[
                    eloc.Index];
            ref4 = comp4;
            ref T5 ref5 =
                ref Unsafe.As<ComponentStorage<T5>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T3, T4, T5, T6, T7, T8, T5>.Index))[
                    eloc.Index];
            ref5 = comp5;
            ref T6 ref6 =
                ref Unsafe.As<ComponentStorage<T6>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T3, T4, T5, T6, T7, T8, T6>.Index))[
                    eloc.Index];
            ref6 = comp6;
            ref T7 ref7 =
                ref Unsafe.As<ComponentStorage<T7>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T3, T4, T5, T6, T7, T8, T7>.Index))[
                    eloc.Index];
            ref7 = comp7;
            ref T8 ref8 =
                ref Unsafe.As<ComponentStorage<T8>>(
                    Unsafe.Add(ref components[0], OfComponent<T1, T2, T3, T4, T5, T6, T7, T8, T8>.Index))[
                    eloc.Index];
            ref8 = comp8;


            GameObject concreteGameObject = new GameObject(Id, version, id);

            Component<T1>.Initer?.Invoke(concreteGameObject, ref ref1);
            Component<T2>.Initer?.Invoke(concreteGameObject, ref ref2);
            Component<T3>.Initer?.Invoke(concreteGameObject, ref ref3);
            Component<T4>.Initer?.Invoke(concreteGameObject, ref ref4);
            Component<T5>.Initer?.Invoke(concreteGameObject, ref ref5);
            Component<T6>.Initer?.Invoke(concreteGameObject, ref ref6);
            Component<T7>.Initer?.Invoke(concreteGameObject, ref ref7);
            Component<T8>.Initer?.Invoke(concreteGameObject, ref ref8);

            EntityCreatedEvent.Invoke(concreteGameObject);

            return concreteGameObject;
        }


        /// <summary>
        ///     Creates the many using the specified count
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <typeparam name="T7">The </typeparam>
        /// <typeparam name="T8">The </typeparam>
        /// <param name="count">The count</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>A chunk tuple of t 1 and t 2 and t 3 and t 4 and t 5 and t 6 and t 7 and t 8</returns>
        public ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8> CreateMany<T1, T2, T3, T4, T5, T6, T7, T8>(int count)
        {
            if ((uint) count == 0) // Efficient validation for non-positive values
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            WorldArchetypeTableItem archetype =
                Archetype<T1, T2, T3, T4, T5, T6, T7, T8>.CreateNewOrGetExistingArchetypes(this);
            int entityCount = archetype.Archetype.EntityCount;

            EntityTable.EnsureCapacity(EntityCount + count);

            // Create gameObject locations directly in a Span
            Span<GameObjectIdOnly> entityLocations = archetype.Archetype.CreateEntityLocations(count, this);

            // Invoke events if listeners are present
            if (EntityCreatedEvent.HasListeners)
            {
                foreach (ref GameObjectIdOnly entityId in entityLocations)
                {
                    EntityCreatedEvent.Invoke(entityId.ToEntity(this));
                }
            }

            // Return the result with calculated spans
            return new ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8>
            {
                Entities = new GameObjectEnumerator.EntityEnumerable(this, entityLocations),
                Span1 = archetype.Archetype.GetComponentSpan<T1>().Slice(entityCount, count),
                Span2 = archetype.Archetype.GetComponentSpan<T2>().Slice(entityCount, count),
                Span3 = archetype.Archetype.GetComponentSpan<T3>().Slice(entityCount, count),
                Span4 = archetype.Archetype.GetComponentSpan<T4>().Slice(entityCount, count),
                Span5 = archetype.Archetype.GetComponentSpan<T5>().Slice(entityCount, count),
                Span6 = archetype.Archetype.GetComponentSpan<T6>().Slice(entityCount, count),
                Span7 = archetype.Archetype.GetComponentSpan<T7>().Slice(entityCount, count),
                Span8 = archetype.Archetype.GetComponentSpan<T8>().Slice(entityCount, count)
            };
        }

        /// <summary>
        ///     Creates an <see cref="GameObject" /> with the given component(s)
        /// </summary>
        /// <returns>An <see cref="GameObject" /> that can be used to acsess the component data</returns>
        public GameObject Create<T>(in T comp)
        {
            WorldArchetypeTableItem archetypes = Archetype<T>.CreateNewOrGetExistingArchetypes(this);

            ref GameObjectIdOnly entity = ref Unsafe.NullRef<GameObjectIdOnly>();
            GameObjectLocation eloc = default(GameObjectLocation);

            ComponentStorageBase[] components;

            if (AllowStructualChanges)
            {
                components = archetypes.Archetype.Components;
                entity = ref archetypes.Archetype.CreateEntityLocation(GameObjectFlags.None, out eloc);
            }
            else
            {
                // we don't need to manually set flags, they are already zeroed
                entity = ref archetypes.Archetype.CreateDeferredEntityLocation(this, archetypes.DeferredCreationArchetype,
                    ref eloc, out components);
            }

            //manually inlined from Scene.CreateEntityFromLocation
            //The jit likes to inline the outer create function and not inline
            //the inner functions - benchmarked to improve perf by 10-20%
            (int id, ushort version) =
                entity = RecycledEntityIds.CanPop() ? RecycledEntityIds.Pop() : new GameObjectIdOnly(NextEntityId++, 0);
            eloc.Version = version;
            EntityTable[id] = eloc;

            //1x array lookup per component
            ref T ref1 = ref Unsafe.As<ComponentStorage<T>>(Unsafe.Add(ref components[0], Archetype<T>.OfComponent<T>.Index))[eloc.Index];

            ref1 = comp;

            GameObject concreteGameObject = new GameObject(Id, version, id);

            Component<T>.Initer?.Invoke(concreteGameObject, ref ref1);
            EntityCreatedEvent.Invoke(concreteGameObject);

            return concreteGameObject;
        }


        /// <summary>
        ///     Creates the many using the specified count
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="count">The count</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>A chunk tuple of t</returns>
        public ChunkTuple<T> CreateMany<T>(int count)
        {
            if ((uint) count == 0) // Efficient validation for non-positive values
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            WorldArchetypeTableItem archetype = Archetype<T>.CreateNewOrGetExistingArchetypes(this);
            int initialEntityCount = archetype.Archetype.EntityCount;

            EntityTable.EnsureCapacity(EntityCount + count);

            // Create gameObject locations directly in a Span
            Span<GameObjectIdOnly> entityLocations = archetype.Archetype.CreateEntityLocations(count, this);

            // Invoke events if listeners are present
            if (EntityCreatedEvent.HasListeners)
            {
                foreach (ref GameObjectIdOnly entityId in entityLocations)
                {
                    EntityCreatedEvent.Invoke(entityId.ToEntity(this));
                }
            }

            // Return the result with calculated spans
            return new ChunkTuple<T>
            {
                Entities = new GameObjectEnumerator.EntityEnumerable(this, entityLocations),
                Span = archetype.Archetype.GetComponentSpan<T>().Slice(initialEntityCount, count)
            };
        }

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

            MoveEntityToArchetypeRemove(MemoryHelpers.SharedTempComponentHandleBuffer.AsSpan(0, 1), gameObject, ref lookup, destination);
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
            MoveEntityToArchetypeAdd(MemoryHelpers.SharedTempComponentStorageBuffer.AsSpan(0, 1), gameObject, ref lookup,
                out gameObjectLocation, destination);
            runner = MemoryHelpers.SharedTempComponentStorageBuffer[0];
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
                {
                    Unsafe.Add(ref MemoryMarshal.GetReference(writeTo), writeToIndex++) = destRunners[i];
                }
                else
                {
                    Unsafe.Add(ref destRunners[0], i).PullComponentFromAndClearTryDevirt(
                        Unsafe.Add(ref fromRunners[0], fromIndex), nextLocation.Index, currentLookup.Index, deletedIndex);
                }
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
                    {
                        writeTo = runner.Store(currentLookup.Index);
                    }
                    else //kinda illegal but whatever
                    {
                        writeTo = new ComponentHandle(0, componentToMoveFromFromToTo);
                    }

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
                {
                    foreach (ComponentHandle handle in componentHandles)
                    {
                        ComponentRemovedEvent.Invoke(gameObject, handle.ComponentId);
                    }
                }

                if (GameObjectLocation.HasEventFlag(currentLookup.Flags,
                        GameObjectFlags.RemoveComp | GameObjectFlags.RemoveGenericComp))
                {
                    EventRecord lookup = EventLookup[gameObject.EntityIdOnly];

                    if (hasGenericRemoveEvent)
                    {
                        foreach (ComponentHandle handle in componentHandles)
                        {
                            lookup.Remove.NormalEvent.Invoke(gameObject, handle.ComponentId);
                            handle.InvokeComponentEventAndConsume(gameObject, lookup.Remove.GenericEvent);
                        }
                    }
                    else
                        //no need to dispose here, as they were never created
                    {
                        foreach (ComponentHandle handle in componentHandles)
                        {
                            lookup.Remove.NormalEvent.Invoke(gameObject, handle.ComponentId);
                        }
                    }
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
            {
                InvokeDeleteEvents(gameObject, gameObjectLocation);
            }

            DeleteEntityWithoutEvents(gameObject, ref gameObjectLocation);
        }

        //let the jit decide whether or not to inline
        /// <summary>
        ///     Invokes the delete events using the specified gameObject
        /// </summary>
        /// <param name="gameObject">The gameObject</param>
        /// <param name="gameObjectLocation">The gameObject location</param>
        internal void InvokeDeleteEvents(GameObject gameObject, GameObjectLocation gameObjectLocation)
        {
            EntityDeletedEvent.Invoke(gameObject);
            if (gameObjectLocation.HasEvent(GameObjectFlags.OnDelete))
            {
                foreach (Action<GameObject> e in EventLookup[gameObject.EntityIdOnly].Delete.AsSpan())
                {
                    e.Invoke(gameObject);
                }
            }

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