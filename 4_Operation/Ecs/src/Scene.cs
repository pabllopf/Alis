using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetype;
using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Kernel.Memory;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     A collection of entities that can be updated and queried.
    /// </summary>
    public partial class Scene : IDisposable
    {


        /// <summary>
        ///     The next scene id
        /// </summary>
        private static ushort _nextWorldId = 1;



        //entityID -> gameObject metadata
        /// <summary>
        ///     The gameObject location
        /// </summary>
        internal FastestTable<GameObjectLocation> EntityTable = new FastestTable<GameObjectLocation>(256);

        //archetype ID -> Archetype?
        /// <summary>
        ///     The scene archetype table
        /// </summary>
        internal WorldArchetypeTableItem[] WorldArchetypeTable;

        /// <summary>
        ///     The archetype graph edges
        /// </summary>
        internal Dictionary<ArchetypeEdgeKey, Archetype> ArchetypeGraphEdges = [];

        /// <summary>
        ///     The gameObject id only
        /// </summary>
        internal FastestStack<GameObjectIdOnly> RecycledEntityIds = new FastestStack<GameObjectIdOnly>(256);

        /// <summary>
        ///     The updates by attributes
        /// </summary>
        private readonly Dictionary<Type, SceneUpdateFilter> _updatesByAttributes = [];

        /// <summary>
        ///     The single component updates
        /// </summary>
        private readonly Dictionary<ComponentId, SingleComponentUpdateFilter> _singleComponentUpdates = [];

        /// <summary>
        ///     The next gameObject id
        /// </summary>
        internal int NextEntityId;

        /// <summary>
        ///     The id
        /// </summary>
        internal readonly ushort Id;

        /// <summary>
        ///     The default scene gameObject
        /// </summary>
        internal readonly GameObject DefaultWorldGameObject;

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
        internal FastestStack<GameObjectType> EnabledArchetypes = FastestStack<GameObjectType>.Create(16);

        // -1: normal state
        // 0: some kind of transition in End/Enter
        // n: n systems/updates active
        /// <summary>
        ///     The allow structural changes
        /// </summary>
        private int _allowStructuralChanges = -1;

        /// <summary>
        ///     The scene update command buffer
        /// </summary>
        internal CommandBuffer WorldUpdateCommandBuffer;

        /// <summary>
        ///     The gameObject only event
        /// </summary>
        internal GameObjectOnlyEvent EntityCreatedEvent = new GameObjectOnlyEvent();

        /// <summary>
        ///     The gameObject only event
        /// </summary>
        internal GameObjectOnlyEvent EntityDeletedEvent = new GameObjectOnlyEvent();

        /// <summary>
        ///     The component id
        /// </summary>
        internal Event<ComponentId> ComponentAddedEvent = new Event<ComponentId>();

        /// <summary>
        ///     The component id
        /// </summary>
        internal Event<ComponentId> ComponentRemovedEvent = new Event<ComponentId>();

        /// <summary>
        ///     The tag event
        /// </summary>
        internal Event<TagId> Tagged = new Event<TagId>();

        /// <summary>
        ///     The tag event
        /// </summary>
        internal Event<TagId> Detached = new Event<TagId>();

        //these lookups exists for programmical api optimization
        //normal <T1, T2...> methods use a shared global static cache
        /// <summary>
        ///     The add component lookup
        /// </summary>
        internal FastLookup AddComponentLookup = new();

        /// <summary>
        ///     The remove component lookup
        /// </summary>
        internal FastLookup RemoveComponentLookup = new();

        /// <summary>
        ///     The add tag lookup
        /// </summary>
        internal FastLookup AddTagLookup = new();

        /// <summary>
        ///     The remove tag lookup
        /// </summary>
        internal FastLookup RemoveTagLookup = new();


        /// <summary>
        ///     The scene event flags
        /// </summary>
        internal GameObjectFlags WorldEventFlags;

        /// <summary>
        ///     The create
        /// </summary>
        internal FastestStack<ArchetypeDeferredUpdateRecord> DeferredCreationArchetypes =
            FastestStack<ArchetypeDeferredUpdateRecord>.Create(4);

        /// <summary>
        ///     The create
        /// </summary>
        private FastestStack<ArchetypeDeferredUpdateRecord> _altDeferredCreationArchetypes =
            FastestStack<ArchetypeDeferredUpdateRecord>.Create(4);

        /// <summary>
        ///     Gets the current number of entities managed by the scene.
        /// </summary>
        public int EntityCount => NextEntityId - RecycledEntityIds.Count;
        
        /// <summary>
        ///     The event lookup
        /// </summary>
        internal Dictionary<GameObjectIdOnly, EventRecord> EventLookup = [];

        /// <summary>
        ///     The default archetype
        /// </summary>
        internal readonly Archetype DefaultArchetype;

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
                    WorldEventFlags &= ~GameObjectFlags.WorldCreate;
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
                    WorldEventFlags &= ~GameObjectFlags.OnDelete;
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
        ///     Invoked whenever a tag is added to an gameObject.
        /// </summary>
        public event Action<GameObject, TagId> TagTagged
        {
            add => AddEvent(ref Tagged, value, GameObjectFlags.Tagged);
            remove => RemoveEvent(ref Tagged, value, GameObjectFlags.Tagged);
        }

        /// <summary>
        ///     Invoked whenever a tag is removed from an gameObject.
        /// </summary>
        public event Action<GameObject, TagId> TagDetached
        {
            add => AddEvent(ref Detached, value, GameObjectFlags.Detach);
            remove => RemoveEvent(ref Detached, value, GameObjectFlags.Detach);
        }

        /// <summary>
        ///     Adds the event using the specified event
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="@event">The event</param>
        /// <param name="action">The action</param>
        /// <param name="flag">The flag</param>
        private void AddEvent<T>(ref Event<T> @event, Action<GameObject, T> action, GameObjectFlags flag)
        {
            @event.Add(action);
            WorldEventFlags |= flag;
        }

        /// <summary>
        ///     Removes the event using the specified event
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="@event">The event</param>
        /// <param name="action">The action</param>
        /// <param name="flag">The flag</param>
        private void RemoveEvent<T>(ref Event<T> @event, Action<GameObject, T> action, GameObjectFlags flag)
        {
            @event.Remove(action);
            if (!@event.HasListeners)
                WorldEventFlags &= ~flag;
        }

        /// <summary>
        ///     Creates a scene with zero entities and a uniform provider.
        /// </summary>
        /// <param name="uniformProvider">The initial uniform provider to be used.</param>
        /// <param name="config">The inital config to use. If not provided, <see cref="Config.Singlethreaded" /> is used.</param>
        public Scene()
        {
            Id = _nextWorldId++;

            GlobalWorldTables.Worlds[Id] = this;

            WorldArchetypeTable = new WorldArchetypeTableItem[GlobalWorldTables.ComponentTagLocationTable.Length];

            WorldUpdateCommandBuffer = new CommandBuffer(this);
            DefaultWorldGameObject = new GameObject(Id, default, default);
            DefaultArchetype = Archetype.CreateOrGetExistingArchetype([], [], this, FastImmutableArray<ComponentId>.Empty,
                FastImmutableArray<TagId>.Empty);
        }

        /// <summary>
        ///     Creates the gameObject from location using the specified gameObject location
        /// </summary>
        /// <param name="gameObjectLocation">The gameObject location</param>
        /// <returns>The gameObject</returns>
        internal GameObject CreateEntityFromLocation(GameObjectLocation gameObjectLocation)
        {
            (int id, ushort version) =
                RecycledEntityIds.TryPop(out GameObjectIdOnly v) ? v : new GameObjectIdOnly(NextEntityId++, 0);
            gameObjectLocation.Version = version;
            EntityTable[id] = gameObjectLocation;
            return new GameObject(Id, version, id);
        }

        /// <summary>
        ///     Updates all component instances in the scene that implement a component interface, e.g., <see cref="IComponent{TArg1,TArg2,TArg3,TArg4,TArg5,TArg6,TArg7,TArg8,TArg9,TArg10,TArg11}" />
        /// </summary>
        public void Update()
        {
            EnterDisallowState();
            try
            {
                foreach (GameObjectType element in EnabledArchetypes.AsSpan())
                    element.Archetype(this)!.Update(this);
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
            SceneUpdateFilter appliesTo = default;
            try
            {
                if (!_updatesByAttributes.TryGetValue(attributeType, out appliesTo))
                    _updatesByAttributes[attributeType] = appliesTo = new SceneUpdateFilter(this, attributeType);
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
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
                if (!_singleComponentUpdates.TryGetValue(componentType, out singleComponent))
                    _singleComponentUpdates[componentType] = singleComponent = new(this, componentType);
#else
            singleComponent =
                CollectionsMarshal.GetValueRefOrAddDefault(_singleComponentUpdates, componentType, out _) ??= new(this, componentType);
#endif

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
                queryHash.AddRule(rule);

            int hashCode = queryHash.ToHashCode();

            if (!QueryCache.TryGetValue(hashCode, out Query query))
                QueryCache[hashCode] = query = CreateQueryFromSpan([.. rules]);

            return query;
        }

        /// <summary>
        ///     Archetypes the added using the specified archetype
        /// </summary>
        /// <param name="archetype">The archetype</param>
        /// <param name="temporaryCreationArchetype">The temporary creation archetype</param>
        internal void ArchetypeAdded(Archetype archetype, Archetype temporaryCreationArchetype)
        {
            if (!GlobalWorldTables.HasTag(archetype.Id, Tag<Disable>.Id))
                EnabledArchetypes.Push(archetype.Id);
            foreach (KeyValuePair<int, Query> qkvp in QueryCache)
                qkvp.Value.TryAttachArchetype(archetype);
            foreach (KeyValuePair<Type, SceneUpdateFilter> fkvp in _updatesByAttributes)
                fkvp.Value.ArchetypeAdded(archetype);
            foreach (KeyValuePair<ComponentId, SingleComponentUpdateFilter> fkvp in _singleComponentUpdates)
                fkvp.Value.ArchetypeAdded(archetype);
        }

        /// <summary>
        ///     Creates the query using the specified rules
        /// </summary>
        /// <param name="rules">The rules</param>
        /// <returns>The </returns>
        internal Query CreateQuery(FastImmutableArray<Rule> rules)
        {
            Query q = new Query(this, rules);
            foreach (ref WorldArchetypeTableItem element in WorldArchetypeTable.AsSpan())
                if (element.Archetype is not null)
                    q.TryAttachArchetype(element.Archetype);
            return q;
        }

        /// <summary>
        ///     Creates the query from span using the specified rules
        /// </summary>
        /// <param name="rules">The rules</param>
        /// <returns>The query</returns>
        internal Query CreateQueryFromSpan(ReadOnlySpan<Rule> rules)
        {
            return CreateQuery(MemoryHelpers.ReadOnlySpanToImmutableArray(rules));
        }

        /// <summary>
        ///     Updates the archetype table using the specified new size
        /// </summary>
        /// <param name="newSize">The new size</param>
        internal void UpdateArchetypeTable(int newSize)
        {
            Array.Resize(ref WorldArchetypeTable, newSize);
        }

        /// <summary>
        ///     Enters the disallow state
        /// </summary>
        internal void EnterDisallowState()
        {
            if (Interlocked.Increment(ref _allowStructuralChanges) == 0) Interlocked.Increment(ref _allowStructuralChanges);
        }

        /// <summary>
        ///     The deferred gameObject operation recursion limit
        /// </summary>
        private const int DeferredEntityOperationRecursionLimit = 200;

        /// <summary>
        ///     Exits the disallow state using the specified filter used
        /// </summary>
        /// <param name="filterUsed">The filter used</param>
        /// <param name="updateDeferredEntities">The update deferred entities</param>
        internal void ExitDisallowState(IComponentUpdateFilter filterUsed, bool updateDeferredEntities = false)
        {
            if (Interlocked.Decrement(ref _allowStructuralChanges) == 0)
            {
                if (DeferredCreationArchetypes.Count > 0)
                {
                    if (updateDeferredEntities)
                        ResolveUpdateDeferredCreationEntities(filterUsed);
                    else
                        foreach ((Archetype archetype, Archetype tmp, int _) in DeferredCreationArchetypes.AsSpan())
                            archetype.ResolveDeferredEntityCreations(this, tmp);
                }

                DeferredCreationArchetypes.Clear();
                Interlocked.Decrement(ref _allowStructuralChanges);

                int count = 0;
                while (WorldUpdateCommandBuffer.Playback())
                    if (++count > DeferredEntityOperationRecursionLimit)
                        throw new InvalidOperationException(
                            "Deferred gameObject creation recursion limit exceeded! Are your component events creating command buffer items? (which create more command buffer items...)?");
            }
        }

        /// <summary>
        ///     Resolves the update deferred creation entities using the specified filter used
        /// </summary>
        /// <param name="filterUsed">The filter used</param>
        private void ResolveUpdateDeferredCreationEntities(IComponentUpdateFilter filterUsed)
        {
            Span<ArchetypeDeferredUpdateRecord> resolveArchetypes = DeferredCreationArchetypes.AsSpan();

            Interlocked.Increment(ref _allowStructuralChanges);

            int createRecursionCount = 0;
            while (resolveArchetypes.Length != 0)
            {
                foreach ((Archetype archetype, Archetype tmp, int _) in resolveArchetypes)
                    archetype.ResolveDeferredEntityCreations(this, tmp);

                (_altDeferredCreationArchetypes, DeferredCreationArchetypes) =
                    (DeferredCreationArchetypes, _altDeferredCreationArchetypes);
                DeferredCreationArchetypes.Clear();

                if (filterUsed is not null)
                    filterUsed?.UpdateSubset(resolveArchetypes);
                else
                    foreach ((Archetype archetype, Archetype _, int start) in resolveArchetypes)
                        archetype.Update(this, start, archetype.EntityCount - start);

                resolveArchetypes = DeferredCreationArchetypes.AsSpan();

                if (++createRecursionCount > DeferredEntityOperationRecursionLimit)
                    throw new InvalidOperationException(
                        "Deferred gameObject creation recursion limit exceeded! Are your components creating entities (which create more entities...)?");
            }

            DeferredCreationArchetypes.Clear();
            Interlocked.Decrement(ref _allowStructuralChanges);
        }

#if (!NETSTANDARD && !NETFRAMEWORK && !NETCOREAPP) || (NET6_0_OR_GREATER)
    /// <summary>
    /// Tries the get event data using the specified gameObject location
    /// </summary>
    /// <param name="gameObjectLocation">The gameObject location</param>
    /// <param name="gameObject">The gameObject</param>
    /// <param name="eventType">The event type</param>
    /// <param name="exists">The exists</param>
    /// <returns>The ref event record</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal ref EventRecord TryGetEventData(GameObjectLocation gameObjectLocation, GameObjectIdOnly gameObject, GameObjectFlags eventType, out bool exists)
    {
        if (gameObjectLocation.HasEvent(eventType))
        {
            exists = true;
            return ref System.Runtime.InteropServices.CollectionsMarshal.GetValueRefOrNullRef(EventLookup, gameObject);
        }


        exists = false;
        return ref Unsafe.NullRef<EventRecord>();
    }
#endif

        /// <summary>
        ///     Gets the value of the allow structual changes
        /// </summary>
        internal bool AllowStructualChanges => _allowStructuralChanges == -1;

        /// <summary>
        ///     Disposes of the <see cref="Scene" />.
        /// </summary>
        public void Dispose()
        {
            GlobalWorldTables.Worlds[Id] = null!;

            foreach (ref WorldArchetypeTableItem item in WorldArchetypeTable.AsSpan())
                if (item.Archetype is not null)
                {
                    item.Archetype.ReleaseArrays();
                    item.DeferredCreationArchetype.ReleaseArrays();
                }

            _sharedCountdown.Dispose();
            RecycledEntityIds.Dispose();
            //EntityTable.Dispose();
        }

        /// <summary>
        ///     Creates an <see cref="GameObject" />
        /// </summary>
        /// <param name="components">The components to use</param>
        /// <returns>The created gameObject</returns>
        public GameObject CreateFromObjects(ReadOnlySpan<object> components)
        {
            if (components.Length > MemoryHelpers.MaxComponentCount)
                throw new ArgumentException("Max 127 components on an gameObject", nameof(components));
            Span<ComponentId> types = stackalloc ComponentId[components.Length];

            for (int i = 0; i < components.Length; i++)
                types[i] = Component.GetComponentId(components[i].GetType());

            Archetype archetype = Archetype.CreateOrGetExistingArchetype(types!, [], this);

            ref GameObjectIdOnly entityId = ref archetype.CreateEntityLocation(GameObjectFlags.None, out GameObjectLocation loc);
            GameObject gameObject = CreateEntityFromLocation(loc);
            entityId.ID = gameObject.EntityID;
            entityId.Version = gameObject.EntityVersion;

            Span<ComponentStorageBase> archetypeComponents = archetype.Components.AsSpan();
            for (int i = 1; i < archetypeComponents.Length; i++) archetypeComponents[i].SetAt(components[i - 1], loc.Index);

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
        internal GameObject CreateEntityWithoutEvent()
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
        internal void InvokeEntityCreated(GameObject gameObject)
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
                return;
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
                throw new ArgumentOutOfRangeException("Count must be positive", nameof(count));
            archetype.EnsureCapacity(count);
            EntityTable.EnsureCapacity(count + EntityCount);
        }
    }
}