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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs.Arch;
using Alis.Core.Ecs.Buffers;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Events;
using Alis.Core.Ecs.Marshalling;
using Alis.Core.Ecs.Operations;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     A collection of entities that can be updated and queried.
    /// </summary>
    public partial class Scene : IDisposable, IScene
    {
        /// <summary>
        ///     The next world id
        /// </summary>
        private static ushort _nextWorldID = 1;

        //entityID -> entity metadata
        /// <summary>
        ///     The entity location
        /// </summary>
        internal Table<EntityLocation> EntityTable = new Table<EntityLocation>(256);

        //archetype ID -> Archetype?
        /// <summary>
        ///     The world archetype table
        /// </summary>
        internal Archetype[] WorldArchetypeTable;

        /// <summary>
        ///     The archetype graph edges
        /// </summary>
        internal Dictionary<ArchetypeEdgeKey, Archetype> ArchetypeGraphEdges = [];

        /// <summary>
        ///     The entity id only
        /// </summary>
        internal FastStack<EntityIdOnly> RecycledEntityIds = new FastStack<EntityIdOnly>(256);

        /// <summary>
        ///     The updates by attributes
        /// </summary>
        private readonly Dictionary<Type, WorldUpdateFilter> _updatesByAttributes = [];

        /// <summary>
        ///     The next entity id
        /// </summary>
        internal int NextEntityID;

        /// <summary>
        ///     The id
        /// </summary>
        internal readonly ushort ID;

        /// <summary>
        ///     The default world entity
        /// </summary>
        internal readonly GameObject DefaultWorldGameObject;

        /// <summary>
        ///     The is disposed
        /// </summary>
        private bool _isDisposed;

        /// <summary>
        ///     The query cache
        /// </summary>
        internal Dictionary<int, Query> QueryCache = [];

        /// <summary>
        ///     Gets the value of the shared countdown
        /// </summary>
        internal CountdownEvent SharedCountdown => _sharedCountdown;

        /// <summary>
        ///     The shared countdown
        /// </summary>
        private readonly CountdownEvent _sharedCountdown = new(0);

        /// <summary>
        ///     The create
        /// </summary>
        private FastStack<ArchetypeID> _enabledArchetypes = FastStack<ArchetypeID>.Create(16);

        /// <summary>
        ///     The allow structural changes
        /// </summary>
        private int _allowStructuralChanges;

        /// <summary>
        ///     The world update command buffer
        /// </summary>
        internal CommandBuffer WorldUpdateCommandBuffer;

        /// <summary>
        ///     The entity only event
        /// </summary>
        internal EntityOnlyEvent EntityCreatedEvent = new EntityOnlyEvent();

        /// <summary>
        ///     The entity only event
        /// </summary>
        internal EntityOnlyEvent EntityDeletedEvent = new EntityOnlyEvent();

        /// <summary>
        ///     The component id
        /// </summary>
        internal Event<ComponentID> ComponentAddedEvent = new Event<ComponentID>();

        /// <summary>
        ///     The component id
        /// </summary>
        internal Event<ComponentID> ComponentRemovedEvent = new Event<ComponentID>();

        /// <summary>
        ///     The tag event
        /// </summary>
        internal TagEvent Tagged = new TagEvent();

        /// <summary>
        ///     The tag event
        /// </summary>
        internal TagEvent Detached = new TagEvent();

        //these lookups exists for programmical api optimization
        //normal <T1, T2...> methods use a shared global static cache
        /// <summary>
        ///     The add component lookup
        /// </summary>
        internal FastLookup AddComponentLookup;

        /// <summary>
        ///     The remove component lookup
        /// </summary>
        internal FastLookup RemoveComponentLookup;

        /// <summary>
        ///     The add tag lookup
        /// </summary>
        internal FastLookup AddTagLookup;

        /// <summary>
        ///     The remove tag lookup
        /// </summary>
        internal FastLookup RemoveTagLookup;


        /// <summary>
        ///     The world event flags
        /// </summary>
        internal EntityFlags WorldEventFlags;

        /// <summary>
        ///     The create
        /// </summary>
        internal FastStack<Archetype> DeferredCreationArchetypes = FastStack<Archetype>.Create(4);

        /// <summary>
        ///     Invoked whenever an entity is created on this world.
        /// </summary>
        public event Action<GameObject> EntityCreated
        {
            add
            {
                EntityCreatedEvent.Add(value);
                WorldEventFlags |= EntityFlags.WorldCreate;
            }
            remove
            {
                EntityCreatedEvent.Remove(value);
                if (!EntityCreatedEvent.HasListeners)
                {
                    WorldEventFlags &= ~EntityFlags.WorldCreate;
                }
            }
        }

        /// <summary>
        ///     Invoked whenever an entity belonging to this world is deleted.
        /// </summary>
        public event Action<GameObject> EntityDeleted
        {
            add
            {
                EntityDeletedEvent.Add(value);
                WorldEventFlags |= EntityFlags.OnDelete;
            }
            remove
            {
                EntityDeletedEvent.Remove(value);
                if (!EntityDeletedEvent.HasListeners)
                {
                    WorldEventFlags &= ~EntityFlags.OnDelete;
                }
            }
        }

        /// <summary>
        ///     Invoked whenever a component is added to an entity.
        /// </summary>
        public event Action<GameObject, ComponentID> ComponentAdded
        {
            add => AddEvent(ref ComponentAddedEvent, value, EntityFlags.AddComp);
            remove => RemoveEvent(ref ComponentAddedEvent, value, EntityFlags.AddComp);
        }

        /// <summary>
        ///     Invoked whenever a component is removed from an entity.
        /// </summary>
        public event Action<GameObject, ComponentID> ComponentRemoved
        {
            add => AddEvent(ref ComponentRemovedEvent, value, EntityFlags.RemoveComp);
            remove => RemoveEvent(ref ComponentRemovedEvent, value, EntityFlags.RemoveComp);
        }

        /// <summary>
        ///     Invoked whenever a tag is added to an entity.
        /// </summary>
        public event Action<GameObject, TagId> TagTagged
        {
            add => AddEvent(ref Tagged, value, EntityFlags.Tagged);
            remove => RemoveEvent(ref Tagged, value, EntityFlags.Tagged);
        }

        /// <summary>
        ///     Invoked whenever a tag is removed from an entity.
        /// </summary>
        public event Action<GameObject, TagId> TagDetached
        {
            add => AddEvent(ref Detached, value, EntityFlags.Detach);
            remove => RemoveEvent(ref Detached, value, EntityFlags.Detach);
        }

        /// <summary>
        ///     Adds the event using the specified event
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="event">The event</param>
        /// <param name="action">The action</param>
        /// <param name="flag">The flag</param>
        private void AddEvent<T>(ref Event<T> @event, Action<GameObject, T> action, EntityFlags flag)
        {
            @event.Add(action);
            WorldEventFlags |= flag;
        }

        /// <summary>
        ///     Removes the event using the specified event
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="event">The event</param>
        /// <param name="action">The action</param>
        /// <param name="flag">The flag</param>
        private void RemoveEvent<T>(ref Event<T> @event, Action<GameObject, T> action, EntityFlags flag)
        {
            @event.Remove(action);
            if (!@event.HasListeners)
            {
                WorldEventFlags &= ~flag;
            }
        }

        /// <summary>
        ///     The event lookup
        /// </summary>
        internal Dictionary<EntityIdOnly, EventRecord> EventLookup = [];

        /// <summary>
        ///     The current uniform provider used when updating components/queries with uniforms.
        /// </summary>
        public IUniformProvider UniformProvider
        {
            get => _uniformProvider;
            set => _uniformProvider = value ?? NullUniformProvider.Instance;
        }

        /// <summary>
        ///     The uniform provider
        /// </summary>
        private IUniformProvider _uniformProvider;

        /// <summary>
        ///     Gets the current number of entities managed by the world.
        /// </summary>
        public int EntityCount => NextEntityID - RecycledEntityIds.Count;

        /// <summary>
        ///     The current world config.
        /// </summary>
        public Config CurrentConfig { get; set; }

        /// <summary>
        ///     The default archetype
        /// </summary>
        internal readonly Archetype DefaultArchetype;

        /// <summary>
        ///     The deferred create archetype
        /// </summary>
        internal readonly Archetype DeferredCreateArchetype;

        /// <summary>
        ///     Creates a world with zero entities and a uniform provider.
        /// </summary>
        /// <param name="uniformProvider">The initial uniform provider to be used.</param>
        /// <param name="config">The inital config to use. If not provided, <see cref="Config.Singlethreaded" /> is used.</param>
        public Scene(IUniformProvider uniformProvider = null, Config config = null)
        {
            CurrentConfig = config ?? Config.Singlethreaded;
            _uniformProvider = uniformProvider ?? NullUniformProvider.Instance;
            ID = _nextWorldID++;

            GlobalWorldTables.Worlds[ID] = this;

            WorldArchetypeTable = new Archetype[GlobalWorldTables.ComponentTagLocationTable.Length];

            WorldUpdateCommandBuffer = new CommandBuffer(this);
            DefaultWorldGameObject = new GameObject(ID, default(ushort), default(int));
            DefaultArchetype = Archetype.CreateOrGetExistingArchetype([], [], this, FastImmutableArray<ComponentID>.Empty, FastImmutableArray<TagId>.Empty);
            DeferredCreateArchetype = Archetype.CreateOrGetExistingArchetype(Archetype.DeferredCreate, this);
        }

        /// <summary>
        ///     Creates the entity from location using the specified entity location
        /// </summary>
        /// <param name="entityLocation">The entity location</param>
        /// <returns>The entity</returns>
        internal GameObject CreateEntityFromLocation(EntityLocation entityLocation)
        {
            (int id, ushort version) = RecycledEntityIds.TryPop(out EntityIdOnly v) ? v : new EntityIdOnly(NextEntityID++, 0);
            entityLocation.Version = version;
            EntityTable[id] = entityLocation;
            return new GameObject(ID, version, id);
        }

        /// <summary>
        ///     Updates all component instances in the world that implement a component interface, e.g., <see cref="IComponent" />
        /// </summary>
        public void Update()
        {
            EnterDisallowState();
            try
            {
                if (CurrentConfig.MultiThreadedUpdate)
                {
                    foreach (ArchetypeID element in _enabledArchetypes.AsSpan())
                    {
                        element.Archetype(this).MultiThreadedUpdate(_sharedCountdown, this);
                    }
                }
                else
                {
                    foreach (ArchetypeID element in _enabledArchetypes.AsSpan())
                    {
                        element.Archetype(this).Update(this);
                    }
                }
            }
            finally
            {
                ExitDisallowState();
            }
        }

        /// <summary>
        ///     Updates all component instances in the world that implement a component interface and have update methods with the
        ///     <typeparamref name="T" /> attribute
        /// </summary>
        /// <typeparam name="T">The type of attribute to filter</typeparam>
        public void Update<T>() where T : UpdateTypeAttribute => Update(typeof(T));

        /// <summary>
        ///     Updates all component instances in the world that implement a component interface and have update methods with an
        ///     attribute of type <paramref name="attributeType" />
        /// </summary>
        /// <param name="attributeType">The attribute type to filter</param>
        public void Update(Type attributeType)
        {
            EnterDisallowState();

            try
            {
                if (!_updatesByAttributes.TryGetValue(attributeType, out WorldUpdateFilter appliesTo))
                {
                    _updatesByAttributes[attributeType] = appliesTo = new WorldUpdateFilter();
                }

                //fill up the table with the correct IDs
                //works for initalization as well as updating it
                if (GenerationServices.TypeAttributeCache.TryGetValue(attributeType, out HashSet<Type> compSet))
                {
                    int size = Component.ComponentTable.Count;
                    for (ref int i = ref appliesTo.NextComponentIndex; i < size; i++)
                    {
                        ComponentID id = new ComponentID((ushort) i);
                        if (compSet.Contains(id.Type))
                        {
                            appliesTo.Stack.Push(id);
                        }
                    }
                }

                foreach (ComponentID compid in appliesTo.Stack.AsSpan())
                {
                    foreach (ArchetypeID item in _enabledArchetypes.AsSpan())
                    {
                        item.Archetype(this).Update(this, compid);
                    }
                }
            }
            finally
            {
                ExitDisallowState();
            }
        }

        /// <summary>
        ///     Creates a custom query from the given set of rules. For an entity to be queried, all rules must apply.
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
        internal void ArchetypeAdded(Archetype archetype)
        {
            if (!GlobalWorldTables.HasTag(archetype.ID, Tag<Disable>.ID))
            {
                _enabledArchetypes.Push(archetype.ID);
            }

            foreach (KeyValuePair<int, Query> qkvp in QueryCache)
            {
                qkvp.Value.TryAttachArchetype(archetype);
            }
        }

        /// <summary>
        ///     Creates the query using the specified rules
        /// </summary>
        /// <param name="rules">The rules</param>
        /// <returns>The </returns>
        internal Query CreateQuery(FastImmutableArray<Rule> rules)
        {
            Query q = new Query(this, rules);
            foreach (ref Archetype element in WorldArchetypeTable.AsSpan())
            {
                if (element is not null)
                {
                    q.TryAttachArchetype(element);
                }
            }

            return q;
        }

        /// <summary>
        ///     Creates the query from span using the specified rules
        /// </summary>
        /// <param name="rules">The rules</param>
        /// <returns>The query</returns>
        internal Query CreateQueryFromSpan(ReadOnlySpan<Rule> rules) => CreateQuery(MemoryHelpers.ReadOnlySpanToImmutableArray(rules));

        /// <summary>
        ///     Updates the archetype table using the specified new size
        /// </summary>
        /// <param name="newSize">The new size</param>
        internal void UpdateArchetypeTable(int newSize) => ComponentArrayPool<Archetype>.ResizeArrayFromPool(ref WorldArchetypeTable, newSize);

        /// <summary>
        ///     Enters the disallow state
        /// </summary>
        internal void EnterDisallowState()
        {
            Interlocked.Increment(ref _allowStructuralChanges);
        }

        /// <summary>
        ///     Exits the disallow state
        /// </summary>
        internal void ExitDisallowState()
        {
            if (Interlocked.Decrement(ref _allowStructuralChanges) == 0)
            {
                Span<Archetype> resolveArchetypes = DeferredCreationArchetypes.AsSpan();

                foreach (Archetype archetype in resolveArchetypes)
                {
                    archetype.ResolveDeferredEntityCreations(this);
                }

                DeferredCreationArchetypes.Clear();

                //i plan on adding events later, so even more command buffer events could be added during playback
                while (WorldUpdateCommandBuffer.Playback())
                {
                    ;
                }
            }
        }

#if (!NETSTANDARD && !NETFRAMEWORK && !NETCOREAPP) || NET6_0_OR_GREATER
        /// <summary>
        /// Tries the get event data using the specified entity location
        /// </summary>
        /// <param name="entityLocation">The entity location</param>
        /// <param name="entity">The entity</param>
        /// <param name="eventType">The event type</param>
        /// <param name="exists">The exists</param>
        /// <returns>The ref event record</returns>
        internal ref EventRecord TryGetEventData(EntityLocation entityLocation, EntityIdOnly entity, EntityFlags eventType, out bool exists)
        {
            if (entityLocation.HasEvent(eventType))
            {
                exists = true;
                return ref CollectionsMarshal.GetValueRefOrNullRef(EventLookup, entity);
            }


            exists = false;
            return ref Unsafe.NullRef<EventRecord>();
        }
#endif

        /// <summary>
        ///     Gets the value of the allow structual changes
        /// </summary>
        internal bool AllowStructualChanges => _allowStructuralChanges == 0;

        /// <summary>
        ///     Disposes of the <see cref="Scene" />.
        /// </summary>
        public void Dispose()
        {
            if (_isDisposed)
            {
                throw new InvalidOperationException("World is already disposed!");
            }

            GlobalWorldTables.Worlds[ID] = null!;

            foreach (ref Archetype item in WorldArchetypeTable.AsSpan())
            {
                if (item is not null)
                {
                    item.ReleaseArrays();
                }
            }

            _sharedCountdown.Dispose();

            _isDisposed = true;

            RecycledEntityIds.Dispose();
            //EntityTable.Dispose();
        }

        /// <summary>
        ///     Creates an <see cref="GameObject" />
        /// </summary>
        /// <param name="components">The components to use</param>
        /// <returns>The created entity</returns>
        public GameObject CreateFromObjects(ReadOnlySpan<object> components)
        {
            if (components.Length > MemoryHelpers.MaxComponentCount)
            {
                throw new ArgumentException("Max 127 components on an entity", nameof(components));
            }

            Span<ComponentID> types = stackalloc ComponentID[components.Length];

            int size = components.Length;
            for (int i = 0; i < size; i++)
            {
                types[i] = Component.GetComponentID(components[i].GetType());
            }

            Archetype archetype = Archetype.CreateOrGetExistingArchetype(types!, [], this);

            ref EntityIdOnly entityID = ref archetype.CreateEntityLocation(EntityFlags.None, out EntityLocation loc);
            GameObject gameObject = CreateEntityFromLocation(loc);
            entityID.ID = gameObject.EntityID;
            entityID.Version = gameObject.EntityVersion;

            Span<ComponentStorageBase> archetypeComponents = archetype.Components.AsSpan(0, components.Length);
            int sizearchetypeComponents = archetypeComponents.Length;
            for (int i = 1; i < sizearchetypeComponents; i++)
            {
                archetypeComponents[i].SetAt(components[i - 1], loc.Index);
            }

            EntityCreatedEvent.Invoke(gameObject);
            return gameObject;
        }

        /// <summary>
        ///     Creates an <see cref="GameObject" /> with zero components.
        /// </summary>
        /// <returns>The entity that was created.</returns>
        public GameObject Create()
        {
            GameObject gameObject = CreateEntityWithoutEvent();
            EntityCreatedEvent.Invoke(gameObject);
            return gameObject;
        }

        /// <summary>
        ///     Creates the entity without event
        /// </summary>
        /// <returns>The entity</returns>
        internal GameObject CreateEntityWithoutEvent()
        {
            ref EntityIdOnly entity = ref DefaultArchetype.CreateEntityLocation(EntityFlags.None, out EntityLocation eloc);

            (int id, ushort version) = entity = RecycledEntityIds.CanPop() ? RecycledEntityIds.Pop() : new EntityIdOnly(NextEntityID++, 0);
            eloc.Version = version;
            EntityTable[id] = eloc;

            return new GameObject(ID, version, id);
        }

        /// <summary>
        ///     Invokes the entity created using the specified entity
        /// </summary>
        /// <param name="gameObject">The entity</param>
        internal void InvokeEntityCreated(GameObject gameObject)
        {
            EntityCreatedEvent.Invoke(gameObject);
        }

        /// <summary>
        ///     Allocates memory sufficient to store <paramref name="count" /> entities of a type
        /// </summary>
        /// <param name="entityType">The types of the entity to allocate for</param>
        /// <param name="count">Number of entity spaces to allocate</param>
        /// <remarks>Use this method when creating a large number of entities</remarks>
        public void EnsureCapacity(ArchetypeID entityType, int count)
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
        internal void EnsureCapacityCore(Archetype archetype, int count)
        {
            if (count < 1)
            {
                throw new ArgumentOutOfRangeException("Count must be positive", nameof(count));
            }

            archetype.EnsureCapacity(count);
            EntityTable.EnsureCapacity(count + EntityCount);
        }

        /// <summary>
        ///     Removes the component using the specified entity
        /// </summary>
        /// <param name="gameObject">The entity</param>
        /// <param name="lookup">The lookup</param>
        /// <param name="componentID">The component id</param>
        internal void RemoveComponent(GameObject gameObject, ref EntityLocation lookup, ComponentID componentID)
        {
            Archetype destination = RemoveComponentLookup.FindAdjacentArchetypeId(componentID, lookup.ArchetypeID, this, ArchetypeEdgeType.RemoveComponent)
                .Archetype(this);

#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && !NET6_0_OR_GREATER
            //array is allocated
            //Span<ComponentHandle> tmpHandleSpan = [default!];
            MoveEntityToArchetypeRemove(_sharedOneElementComponentHandle, gameObject, ref lookup, destination);
#else
            Unsafe.SkipInit(out ComponentHandle tmpHandle);
            MemoryHelpers.Poison(ref tmpHandle);
            MoveEntityToArchetypeRemove(MemoryMarshal.CreateSpan(ref tmpHandle, 1), gameObject, ref lookup, destination);
#endif
        }

        /// <summary>
        ///     Adds the component using the specified entity
        /// </summary>
        /// <param name="gameObject">The entity</param>
        /// <param name="lookup">The lookup</param>
        /// <param name="componentID">The component id</param>
        /// <param name="runner">The runner</param>
        /// <param name="entityLocation">The entity location</param>
        internal void AddComponent(GameObject gameObject, ref EntityLocation lookup, ComponentID componentID, ref ComponentStorageBase runner, out EntityLocation entityLocation)
        {
            Archetype destination = AddComponentLookup.FindAdjacentArchetypeId(componentID, lookup.ArchetypeID, this, ArchetypeEdgeType.AddComponent)
                .Archetype(this);
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && !NET6_0_OR_GREATER
            MoveEntityToArchetypeAdd(_sharedOneElementComponentStorage, gameObject, ref lookup, out entityLocation, destination);
            runner = _sharedOneElementComponentStorage[0];
#else
            MoveEntityToArchetypeAdd(MemoryMarshal.CreateSpan(ref runner, 1), gameObject, ref lookup, out entityLocation, destination);
#endif
        }

        /// <summary>
        ///     Moves the entity to archetype add using the specified write to
        /// </summary>
        /// <param name="writeTo">The write to</param>
        /// <param name="gameObject">The entity</param>
        /// <param name="currentLookup">The current lookup</param>
        /// <param name="nextLocation">The next location</param>
        /// <param name="destination">The destination</param>
        internal void MoveEntityToArchetypeAdd(Span<ComponentStorageBase> writeTo, GameObject gameObject, ref EntityLocation currentLookup, out EntityLocation nextLocation, Archetype destination)
        {
            Archetype from = currentLookup.Archetype;

            destination.CreateEntityLocation(currentLookup.Flags, out nextLocation).Init(gameObject);
            nextLocation.Version = currentLookup.Version;

            EntityIdOnly movedDown = from.DeleteEntityFromStorage(currentLookup.Index, out int deletedIndex);

            ComponentStorageBase[] fromRunners = from.Components;
            ComponentStorageBase[] destRunners = destination.Components;
            byte[] fromMap = from.ComponentTagTable;

            FastImmutableArray<ComponentID> destinationComponents = destination.ArchetypeTypeArray;

            int writeToIndex = 0;
            int size = destinationComponents.Length;
            for (int i = 0; i < size;)
            {
                ComponentID componentToMove = destinationComponents[i];
                int fromIndex = fromMap.UnsafeArrayIndex(componentToMove.RawIndex) & GlobalWorldTables.IndexBits;

                //index for dest is offset by one for hardware trap
                i++;

                if (fromIndex == 0)
                {
                    writeTo.UnsafeSpanIndex(writeToIndex++) = destRunners[i];
                }
                else
                {
                    destRunners.UnsafeArrayIndex(i).PullComponentFromAndClearTryDevirt(fromRunners.UnsafeArrayIndex(fromIndex), nextLocation.Index, currentLookup.Index, deletedIndex);
                }
            }

            EntityTable.UnsafeIndexNoResize(movedDown.ID) = currentLookup;
            currentLookup = nextLocation;
        }

        /// <summary>
        ///     Moves the entity to archetype remove using the specified component handles
        /// </summary>
        /// <param name="componentHandles">The component handles</param>
        /// <param name="gameObject">The entity</param>
        /// <param name="currentLookup">The current lookup</param>
        /// <param name="destination">The destination</param>
        internal void MoveEntityToArchetypeRemove(Span<ComponentHandle> componentHandles, GameObject gameObject, ref EntityLocation currentLookup, Archetype destination)
        {
            Archetype from = currentLookup.Archetype;

            destination.CreateEntityLocation(currentLookup.Flags, out EntityLocation nextLocation).Init(gameObject);
            nextLocation.Version = currentLookup.Version;

            EntityIdOnly movedDown = from.DeleteEntityFromStorage(currentLookup.Index, out int deletedIndex);

            ComponentStorageBase[] fromRunners = from.Components;
            ComponentStorageBase[] destRunners = destination.Components;
            byte[] destMap = destination.ComponentTagTable;

            FastImmutableArray<ComponentID> fromComponents = from.ArchetypeTypeArray;

            bool hasGenericRemoveEvent = EntityLocation.HasEventFlag(currentLookup.Flags, EntityFlags.RemoveGenericComp);

            int writeToIndex = 0;

            DeleteComponentData deleteData = new DeleteComponentData(currentLookup.Index, deletedIndex);

            int size = fromComponents.Length;
            for (int i = 0; i < size;)
            {
                ComponentID componentToMoveFromFromToTo = fromComponents[i];
                int toIndex = destMap.UnsafeArrayIndex(componentToMoveFromFromToTo.RawIndex);

                i++;

                if (toIndex == 0)
                {
                    ComponentStorageBase runner = fromRunners.UnsafeArrayIndex(i);
                    ref ComponentHandle writeTo = ref componentHandles.UnsafeSpanIndex(writeToIndex++);
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
                    destRunners.UnsafeArrayIndex(toIndex).PullComponentFromAndClearTryDevirt(fromRunners.UnsafeArrayIndex(i), nextLocation.Index, currentLookup.Index, deletedIndex);
                }
            }

            EntityTable.UnsafeIndexNoResize(movedDown.ID) = currentLookup;
            currentLookup = nextLocation;

            if (EntityLocation.HasEventFlag(currentLookup.Flags | WorldEventFlags, EntityFlags.RemoveComp | EntityFlags.RemoveGenericComp))
            {
                if (ComponentRemovedEvent.HasListeners)
                {
                    foreach (ComponentHandle handle in componentHandles)
                    {
                        ComponentRemovedEvent.Invoke(gameObject, handle.ComponentID);
                    }
                }

                if (EntityLocation.HasEventFlag(currentLookup.Flags, EntityFlags.RemoveComp | EntityFlags.RemoveGenericComp))
                {
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && !NET6_0_OR_GREATER
                    EventRecord lookup = EventLookup[gameObject.EntityIdOnly];
#else
                    ref EventRecord lookup = ref CollectionsMarshal.GetValueRefOrNullRef(EventLookup, gameObject.EntityIdOnly);
#endif

                    if (hasGenericRemoveEvent)
                    {
                        foreach (ComponentHandle handle in componentHandles)
                        {
                            lookup.Remove.NormalEvent.Invoke(gameObject, handle.ComponentID);
                            handle.InvokeComponentEventAndConsume(gameObject, lookup.Remove.GenericEvent);
                        }
                    }
                    else
                    {
                        //no need to dispose here, as they were never created
                        foreach (ComponentHandle handle in componentHandles)
                        {
                            lookup.Remove.NormalEvent.Invoke(gameObject, handle.ComponentID);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Moves the entity to archetype iso using the specified entity
        /// </summary>
        /// <param name="gameObject">The entity</param>
        /// <param name="currentLookup">The current lookup</param>
        /// <param name="destination">The destination</param>
        internal void MoveEntityToArchetypeIso(GameObject gameObject, ref EntityLocation currentLookup, Archetype destination)
        {
            Archetype from = currentLookup.Archetype;

            destination.CreateEntityLocation(currentLookup.Flags, out EntityLocation nextLocation).Init(gameObject);
            nextLocation.Version = currentLookup.Version;

            EntityIdOnly movedDown = from.DeleteEntityFromStorage(currentLookup.Index, out int deletedIndex);

            ComponentStorageBase[] fromRunners = from.Components;
            ComponentStorageBase[] destRunners = destination.Components;
            byte[] destMap = destination.ComponentTagTable;

            FastImmutableArray<ComponentID> fromComponents = from.ArchetypeTypeArray;

            int size = fromComponents.Length;
            for (int i = 0; i < size;)
            {
                int toIndex = destMap.UnsafeArrayIndex(fromComponents[i].RawIndex) & GlobalWorldTables.IndexBits;

                i++;

                destRunners[toIndex].PullComponentFromAndClearTryDevirt(fromRunners[i], nextLocation.Index, currentLookup.Index, deletedIndex);
            }

            EntityTable.UnsafeIndexNoResize(movedDown.ID) = currentLookup;
            currentLookup = nextLocation;
        }


#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && !NET6_0_OR_GREATER
        [ThreadStatic] private static readonly ComponentHandle[] _sharedOneElementComponentHandle = new ComponentHandle[1];

        [ThreadStatic] private static readonly ComponentStorageBase[] _sharedOneElementComponentStorage = new ComponentStorageBase[1];
#endif

        //Delete
        /// <summary>
        ///     Deletes the entity using the specified entity
        /// </summary>
        /// <param name="gameObject">The entity</param>
        /// <param name="entityLocation">The entity location</param>
        internal void DeleteEntity(GameObject gameObject, ref EntityLocation entityLocation)
        {
            EntityFlags check = entityLocation.Flags | WorldEventFlags;
            if ((check & EntityFlags.Events) != 0)
            {
                InvokeDeleteEvents(gameObject, entityLocation);
            }

            DeleteEntityWithoutEvents(gameObject, ref entityLocation);
        }

        //let the jit decide whether or not to inline
        /// <summary>
        ///     Invokes the delete events using the specified entity
        /// </summary>
        /// <param name="gameObject">The entity</param>
        /// <param name="entityLocation">The entity location</param>
        private void InvokeDeleteEvents(GameObject gameObject, EntityLocation entityLocation)
        {
            EntityDeletedEvent.Invoke(gameObject);
            if (entityLocation.HasEvent(EntityFlags.OnDelete))
            {
                foreach (Action<GameObject> @event in EventLookup[gameObject.EntityIdOnly].Delete.AsSpan())
                {
                    @event.Invoke(gameObject);
                }
            }

            EventLookup.Remove(gameObject.EntityIdOnly);
        }

        /// <summary>
        ///     Deletes the entity without events using the specified entity
        /// </summary>
        /// <param name="gameObject">The entity</param>
        /// <param name="currentLookup">The current lookup</param>
        internal void DeleteEntityWithoutEvents(GameObject gameObject, ref EntityLocation currentLookup)
        {
            //entity is guaranteed to be alive here
            EntityIdOnly replacedEntity = currentLookup.Archetype.DeleteEntity(currentLookup.Index);

            ref EntityLocation replaced = ref EntityTable.UnsafeIndexNoResize(replacedEntity.ID);
            replaced = currentLookup;
            replaced.Version = replacedEntity.Version;
            currentLookup.Version = ushort.MaxValue;

            if (gameObject.EntityVersion != ushort.MaxValue - 1)
            {
                // can't use max value as an ID, as it is used as a default value
                EntityIdOnly id = gameObject.EntityIdOnly;
                id.Version++;
                RecycledEntityIds.Push(id);
            }
        }

        /// <summary>
        ///     Creates an <see cref="GameObject" /> with the given component(s)
        /// </summary>
        /// <returns>An <see cref="GameObject" /> that can be used to acsess the component data</returns>
        public GameObject Create<T>(in T comp)
        {
            Archetype archetype = Archetype<T>.CreateNewOrGetExistingArchetype(this);

            ref EntityIdOnly entity = ref Unsafe.NullRef<EntityIdOnly>();
            EntityLocation eloc = default(EntityLocation);

            ComponentStorageBase[] components;
            Unsafe.SkipInit(out int index);
            MemoryHelpers.Poison(ref index);

            if (AllowStructualChanges)
            {
                components = archetype.Components;
                entity = ref archetype.CreateEntityLocation(EntityFlags.None, out eloc);
                index = eloc.Index;
            }
            else
            {
                entity = ref archetype.CreateDeferredEntityLocation(this, ref eloc, out index, out components);
                eloc.Archetype = DeferredCreateArchetype;
            }

            //manually inlined from World.CreateEntityFromLocation
            //The jit likes to inline the outer create function and not inline
            //the inner functions - benchmarked to improve perf by 10-20%
            (int id, ushort version) = entity = RecycledEntityIds.CanPop() ? RecycledEntityIds.Pop() : new(NextEntityID++, 0);
            eloc.Version = version;
            EntityTable[id] = eloc;

            //1x array lookup per component
            ref T ref1 = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T>>(components.UnsafeArrayIndex(Archetype<T>.OfComponent<T>.Index))[index];
            ref1 = comp;

            GameObject concreteGameObject = new GameObject(ID, version, id);

            Component<T>.Initer?.Invoke(concreteGameObject, ref ref1);
            EntityCreatedEvent.Invoke(concreteGameObject);

            return concreteGameObject;
        }

        [SkipLocalsInit]
        public ChunkTuple<T> CreateMany<T>(int count)
        {
            if ((uint)count == 0) // Efficient validation for non-positive values
                throw new ArgumentOutOfRangeException(nameof(count));
        
            var archetype = Archetype<T>.CreateNewOrGetExistingArchetype(this);
            int initialEntityCount = archetype.EntityCount;
        
            EntityTable.EnsureCapacity(EntityCount + count);
        
            // Create entity locations directly in a Span
            Span<EntityIdOnly> entityLocations = archetype.CreateEntityLocations(count, this);
        
            // Invoke events if listeners are present
            if (EntityCreatedEvent.HasListeners)
            {
                foreach (ref var entityId in entityLocations)
                {
                    EntityCreatedEvent.Invoke(entityId.ToEntity(this));
                }
            }
        
            // Return the result with calculated spans
            return new ChunkTuple<T>
            {
                Entities = new EntityEnumerator.EntityEnumerable(this, entityLocations),
                Span = archetype.GetComponentSpan<T>().Slice(initialEntityCount, count)
            };
        }
    }
}