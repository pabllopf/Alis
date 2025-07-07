using System;
using System.Runtime.CompilerServices;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel.Archetype;
using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Redifinition;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs.Kernel
{
    /// <summary>
    ///     Stores a set of structual changes that can be applied to a <see cref="Scene" />.
    /// </summary>
    public class CommandBuffer
    {
        /// <summary>
        ///     The max component count
        /// </summary>
        private readonly ComponentStorageBase[] _componentRunnerBuffer =
            new ComponentStorageBase[MemoryHelpers.MaxComponentCount];

        /// <summary>
        ///     The create
        /// </summary>
        internal FastestStack<AddComponent> AddComponentBuffer = FastestStack<AddComponent>.Create(2);

        /// <summary>
        ///     The create
        /// </summary>
        internal FastestStack<CreateCommand> CreateEntityBuffer = FastestStack<CreateCommand>.Create(2);

        /// <summary>
        ///     The create
        /// </summary>
        internal FastestStack<ComponentHandle> CreateEntityComponents = FastestStack<ComponentHandle>.Create(2);

        /// <summary>
        ///     The create
        /// </summary>
        internal FastestStack<GameObjectIdOnly> DeleteEntityBuffer = FastestStack<GameObjectIdOnly>.Create(2);

        /// <summary>
        ///     The create
        /// </summary>
        internal FastestStack<TagCommand> DetachTagEntityBuffer = FastestStack<TagCommand>.Create(2);

        /// <summary>
        ///     The is inactive
        /// </summary>
        internal bool IsInactive;

        //-1 indicates normal state
        /// <summary>
        ///     The last create gameObject components buffer index
        /// </summary>
        internal int LastCreateEntityComponentsBufferIndex = -1;

        /// <summary>
        ///     The create
        /// </summary>
        internal FastestStack<DeleteComponent> RemoveComponentBuffer = FastestStack<DeleteComponent>.Create(2);

        /// <summary>
        ///     The scene
        /// </summary>
        internal Scene Scene;

        /// <summary>
        ///     The create
        /// </summary>
        internal FastestStack<TagCommand> TagEntityBuffer = FastestStack<TagCommand>.Create(2);

        /// <summary>
        ///     Creates a command buffer, which stores changes to a scene without directly applying them.
        /// </summary>
        /// <param name="scene">The scene to apply things to.</param>
        public CommandBuffer(Scene scene)
        {
            Scene = scene;
            IsInactive = true;
        }

        /// <summary>
        ///     Whether or not the buffer currently has items to be played back.
        /// </summary>
        public bool HasBufferItems => !IsInactive;

        /// <summary>
        ///     Deletes a component from when <see cref="Playback" /> is called.
        /// </summary>
        /// <param name="gameObject">The gameObject that will be deleted on playback.</param>
        public void DeleteEntity(GameObject gameObject)
        {
            SetIsActive();
            DeleteEntityBuffer.Push(gameObject.EntityIdOnly);
        }

        /// <summary>
        ///     Removes a component from when <see cref="Playback" /> is called.
        /// </summary>
        /// <param name="gameObject">The gameObject to remove a component from.</param>
        /// <param name="component">The component to remove.</param>
        public void RemoveComponent(GameObject gameObject, ComponentId component)
        {
            SetIsActive();
            RemoveComponentBuffer.Push(new DeleteComponent(gameObject.EntityIdOnly, component));
        }

        /// <summary>
        ///     Removes a component from when <see cref="Playback" /> is called.
        /// </summary>
        /// <typeparam name="T">The component type to remove.</typeparam>
        /// <param name="gameObject">The gameObject to remove a component from.</param>
        public void RemoveComponent<T>(GameObject gameObject)
        {
            RemoveComponent(gameObject, Component<T>.Id);
        }

        /// <summary>
        ///     Removes a component from when <see cref="Playback" /> is called.
        /// </summary>
        /// <param name="gameObject">The gameObject to remove a component from.</param>
        /// <param name="type">The type of component to remove.</param>
        public void RemoveComponent(GameObject gameObject, Type type)
        {
            RemoveComponent(gameObject, Component.GetComponentId(type));
        }

        /// <summary>
        ///     Adds a component to an gameObject when <see cref="Playback" /> is called.
        /// </summary>
        /// <typeparam name="T">The component type to add.</typeparam>
        /// <param name="gameObject">The gameObject to add to.</param>
        /// <param name="component">The component to add.</param>
        public void AddComponent<T>(GameObject gameObject, in T component)
        {
            SetIsActive();
            AddComponentBuffer.Push(new AddComponent(gameObject.EntityIdOnly, ComponentHandle.Create(component)));
        }

        /// <summary>
        ///     Adds a component to an gameObject when <see cref="Playback" /> is called.
        /// </summary>
        /// <param name="gameObject">The gameObject to add to.</param>
        /// <param name="component">The component to add.</param>
        /// <param name="componentId">The ID of the component type to add as.</param>
        /// <remarks><paramref name="component" /> must be assignable to <see cref="ComponentId.Type" />.</remarks>
        public void AddComponent(GameObject gameObject, ComponentId componentId, object component)
        {
            SetIsActive();
            AddComponentBuffer.Push(new AddComponent(gameObject.EntityIdOnly,
                ComponentHandle.CreateFromBoxed(componentId, component)));
        }

        /// <summary>
        ///     Adds a component to an gameObject when <see cref="Playback" /> is called.
        /// </summary>
        /// <param name="gameObject">The gameObject to add to.</param>
        /// <param name="component">The component to add.</param>
        /// <param name="componentType">The type to add the component as.</param>
        /// <remarks><paramref name="component" /> must be assignable to <paramref name="componentType" />.</remarks>
        public void AddComponent(GameObject gameObject, Type componentType, object component)
        {
            AddComponent(gameObject, Component.GetComponentId(componentType), component);
        }

        /// <summary>
        ///     Adds a component to an gameObject when <see cref="Playback" /> is called.
        /// </summary>
        /// <param name="gameObject">The gameObject to add to.</param>
        /// <param name="component">The component to add.</param>
        public void AddComponent(GameObject gameObject, object component)
        {
            AddComponent(gameObject, component.GetType(), component);
        }

        /// <summary>
        ///     Removes all commands without playing them back.
        /// </summary>
        /// <remarks>This command also removes all empty entities (without events) that have been created by this command buffer.</remarks>
        public void Clear()
        {
            IsInactive = true;

            while (CreateEntityBuffer.TryPop(out CreateCommand createCommand))
            {
                GameObjectIdOnly item = createCommand.Entity;
                ref GameObjectLocation record = ref Scene.EntityTable[item.ID];
                if (record.Version == item.Version) Scene.DeleteEntityWithoutEvents(item.ToEntity(Scene), ref record);
            }

            RemoveComponentBuffer.Clear();
            DeleteEntityBuffer.Clear();
        }

        /// <summary>
        ///     Plays all the queued commands, applying them to a scene.
        /// </summary>
        /// <returns>
        ///     <see langword="true" /> when at least one change was made; <see langword="false" /> when this command buffer
        ///     is empty and not active.
        /// </returns>
        public bool Playback()
        {
            if (!Scene.AllowStructualChanges)
                throw new InvalidOperationException("The scene currently does not allow structural changes!");
            return PlaybackInternal();
        }

        /// <summary>
        ///     Playbacks the internal
        /// </summary>
        /// <returns>The has items</returns>
        internal bool PlaybackInternal()
        {
            bool hasItems = (DeleteEntityBuffer.Count > 0) | (CreateEntityBuffer.Count > 0) |
                            (RemoveComponentBuffer.Count > 0) | (AddComponentBuffer.Count > 0);

            if (!hasItems)
                return hasItems;

            while (CreateEntityBuffer.TryPop(out CreateCommand createCommand))
            {
                GameObject concrete = createCommand.Entity.ToEntity(Scene);
                ref GameObjectLocation lookup = ref Scene.EntityTable.UnsafeIndexNoResize(concrete.EntityID);

                if (createCommand.BufferLength > 0)
                {
                    Span<ComponentStorageBase> runners = _componentRunnerBuffer.AsSpan(0, createCommand.BufferLength);

                    GameObjectType id = Scene.DefaultArchetype.Id;
                    Span<ComponentHandle> handles = CreateEntityComponents.AsSpan()
                        .Slice(createCommand.BufferIndex, createCommand.BufferLength);
                    for (int i = 0; i < handles.Length; i++)
                        id = Scene.AddComponentLookup.FindAdjacentArchetypeId(handles[i].ComponentId, id, Scene,
                            ArchetypeEdgeType.AddComponent);

                    Scene.MoveEntityToArchetypeAdd(runners, concrete, ref lookup, out GameObjectLocation location,
                        id.Archetype(Scene)!);
                }

                Scene.InvokeEntityCreated(concrete);
            }

            while (DeleteEntityBuffer.TryPop(out GameObjectIdOnly item))
            {
                //double check that its alive
                ref GameObjectLocation record = ref Scene.EntityTable[item.ID];
                if (record.Version == item.Version) Scene.DeleteEntity(item.ToEntity(Scene), ref record);
            }

            while (RemoveComponentBuffer.TryPop(out DeleteComponent item))
            {
                int id = item.Entity.ID;
                ref GameObjectLocation record = ref Scene.EntityTable[id];
                if (record.Version == item.Entity.Version)
                    Scene.RemoveComponent(item.Entity.ToEntity(Scene), ref record, item.ComponentId);
            }

            while (AddComponentBuffer.TryPop(out AddComponent command))
            {
                int id = command.Entity.ID;
                ref GameObjectLocation record = ref Scene.EntityTable[id];
                if (record.Version == command.Entity.Version)
                {
                    GameObject concrete = command.Entity.ToEntity(Scene);

                    ComponentStorageBase runner = null!;
                    Scene.AddComponent(concrete, ref record, command.ComponentHandle.ComponentId, ref runner,
                        out GameObjectLocation location);

                    runner.PullComponentFrom(command.ComponentHandle.ParentTable, location.Index,
                        command.ComponentHandle.Index);

                    if (record.HasEvent(GameObjectFlags.AddComp))
                    {
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
                        EventRecord events = Scene.EventLookup[command.Entity];
#else
                    ref EventRecord events =
                        ref System.Runtime.InteropServices.CollectionsMarshal.GetValueRefOrNullRef(Scene.EventLookup, command.Entity);
#endif
                        events.Add.NormalEvent.Invoke(concrete, command.ComponentHandle.ComponentId);
                        runner.InvokeGenericActionWith(events.Add.GenericEvent, concrete, location.Index);
                    }

                    command.ComponentHandle.Dispose();
                }
            }

            while (TagEntityBuffer.TryPop(out TagCommand command))
            {
                ref GameObjectLocation record = ref Scene.EntityTable[command.Entity.ID];
                if (record.Version == command.Entity.Version)
                    Scene.MoveEntityToArchetypeIso(command.Entity.ToEntity(Scene), ref record,
                        Archetype.Archetype.GetAdjacentArchetypeLookup(Scene,
                            ArchetypeEdgeKey.Tag(command.TagId, record.Archetype.Id, ArchetypeEdgeType.AddTag)));
            }

            while (DetachTagEntityBuffer.TryPop(out TagCommand command))
            {
                ref GameObjectLocation record = ref Scene.EntityTable[command.Entity.ID];
                if (record.Version == command.Entity.Version)
                    Scene.MoveEntityToArchetypeIso(command.Entity.ToEntity(Scene), ref record,
                        Archetype.Archetype.GetAdjacentArchetypeLookup(Scene,
                            ArchetypeEdgeKey.Tag(command.TagId, record.Archetype.Id, ArchetypeEdgeType.RemoveTag)));
            }

            IsInactive = true;

            return hasItems;
        }

        /// <summary>
        ///     Asserts the creating gameObject
        /// </summary>
        /// <exception cref="InvalidOperationException">Use CommandBuffer.GameObject() to begin creating an gameObject!</exception>
        private void AssertCreatingEntity()
        {
            if (LastCreateEntityComponentsBufferIndex < 0) Throw();

            [MethodImpl(MethodImplOptions.NoInlining)]
            static void Throw()
            {
                throw new InvalidOperationException("Use CommandBuffer.GameObject() to begin creating an gameObject!");
            }
        }

        /// <summary>
        ///     Sets the is active
        /// </summary>
        private void SetIsActive()
        {
            IsInactive = false;
        }



        /// <summary>
        ///     Tags an gameObject with a tag when <see cref="Playback" /> is called.
        /// </summary>
        /// <typeparam name="T">The type to tag the gameObject with.</typeparam>
        /// <param name="gameObject">The gameObject to tag.</param>
        public void Tag<T>(GameObject gameObject)
        {
            Tag(gameObject, Kernel.Tag<T>.Id);
        }

        /// <summary>
        ///     Tags an gameObject with a tag when <see cref="Playback" /> is called.
        /// </summary>
        /// <param name="tagId">The ID of the tag type to tag.</param>
        /// <param name="gameObject">The gameObject to tag.</param>
        public void Tag(GameObject gameObject, TagId tagId)
        {
            SetIsActive();
            TagEntityBuffer.Push(new(gameObject.EntityIdOnly, tagId));
        }

        /// <summary>
        ///     Detaches a tag from an gameObject when <see cref="Playback" /> is called.
        /// </summary>
        /// <typeparam name="T">The type of tag to detach.</typeparam>
        /// <param name="gameObject">The gameObject to detach from.</param>
        public void Detach<T>(GameObject gameObject)
        {
            Detach(gameObject, Kernel.Tag<T>.Id);
        }

        /// <summary>
        ///     Detaches a tag from an gameObject when <see cref="Playback" /> is called.
        /// </summary>
        /// <param name="gameObject">The gameObject to detach from.</param>
        /// <param name="tagId">The ID of the tag type to detach from the gameObject.</param>
        public void Detach(GameObject gameObject, TagId tagId)
        {
            SetIsActive();
            DetachTagEntityBuffer.Push(new(gameObject.EntityIdOnly, tagId));
        }





        /// <summary>
        ///     Begins to create an gameObject, which will be resolved when <see cref="Playback" /> is called.
        /// </summary>
        /// <returns><see langword="this" /> instance, for method chaining.</returns>
        /// <exception cref="InvalidOperationException">An gameObject is already being created.</exception>
        public CommandBuffer Entity()
        {
            SetIsActive();
            if (LastCreateEntityComponentsBufferIndex >= 0)
                throw new InvalidOperationException(
                    "An gameObject is currently being created! Use 'End' to finish an gameObject creation!");
            LastCreateEntityComponentsBufferIndex = CreateEntityComponents.Count;
            return this;
        }

        /// <summary>
        ///     Records <paramref name="component" /> to be part of the gameObject created when resolved.
        /// </summary>
        /// <returns><see langword="this" /> instance, for method chaining.</returns>
        /// <exception cref="InvalidOperationException"><see cref="Entity" /> has not been called."/></exception>
        public CommandBuffer With<T>(T component)
        {
            AssertCreatingEntity();
            CreateEntityComponents.Push(ComponentHandle.Create(in component));
            return this;
        }

        /// <summary>
        ///     Records <paramref name="component" /> to be part of the gameObject created when resolved as a component type
        ///     represented by <paramref name="componentId" />.
        /// </summary>
        /// <returns><see langword="this" /> instance, for method chaining.</returns>
        /// <exception cref="InvalidOperationException"><see cref="Entity" /> has not been called."/></exception>
        public CommandBuffer WithBoxed(ComponentId componentId, object component)
        {
            AssertCreatingEntity();
            //we don't check IsAssignableTo - reason is perf - InvalidCastException anyways
            int index = Component.ComponentTable[componentId.RawIndex].Storage.CreateBoxed(component);
            CreateEntityComponents.Push(new ComponentHandle(index, componentId));
            return this;
        }

        /// <summary>
        ///     Records <paramref name="component" /> to be part of the gameObject created when resolved.
        /// </summary>
        /// <returns><see langword="this" /> instance, for method chaining.</returns>
        /// <exception cref="InvalidOperationException"><see cref="Entity" /> has not been called."/></exception>
        public CommandBuffer WithBoxed(object component)
        {
            return WithBoxed(component.GetType(), component);
        }

        /// <summary>
        ///     Records <paramref name="component" /> to be part of the gameObject created when resolved as a component type of
        ///     <paramref name="type" />.
        /// </summary>
        /// <returns><see langword="this" /> instance, for method chaining.</returns>
        /// <exception cref="InvalidOperationException"><see cref="Entity" /> has not been called."/></exception>
        public CommandBuffer WithBoxed(Type type, object component)
        {
            return WithBoxed(Component.GetComponentId(type), component);
        }

        /// <summary>
        ///     Finishes recording gameObject creation and returns an gameObject with zero components. Recorded components will be added on
        ///     playback.
        /// </summary>
        /// <returns>The created gameObject ID</returns>
        public GameObject End()
        {
            //CreateCommand points to a segment of the _createEntityComponents stack
            GameObject e = Scene.CreateEntityWithoutEvent();
            CreateEntityBuffer.Push(new CreateCommand(
                e.EntityIdOnly,
                LastCreateEntityComponentsBufferIndex,
                CreateEntityComponents.Count - LastCreateEntityComponentsBufferIndex));
            LastCreateEntityComponentsBufferIndex = -1;
            return e;
        }


    }
}