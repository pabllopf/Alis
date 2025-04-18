// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CommandBuffer.cs
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
    ///     Stores a set of structual changes that can be applied to a <see cref="Scene" />.
    /// </summary>
    public class CommandBuffer
    {
        /// <summary>
        ///     The max component count
        /// </summary>
        private readonly ComponentStorageBase[] _componentRunnerBuffer = new ComponentStorageBase[MemoryHelpers.MaxComponentCount];

        /// <summary>
        ///     The create
        /// </summary>
        internal FastStack<AddComponent> _addComponentBuffer = FastStack<AddComponent>.Create(4);

        /// <summary>
        ///     The create
        /// </summary>
        internal FastStack<CreateCommand> _createEntityBuffer = FastStack<CreateCommand>.Create(4);

        /// <summary>
        ///     The create
        /// </summary>
        internal FastStack<ComponentHandle> _createEntityComponents = FastStack<ComponentHandle>.Create(4);

        /// <summary>
        ///     The create
        /// </summary>
        internal FastStack<EntityIdOnly> _deleteEntityBuffer = FastStack<EntityIdOnly>.Create(4);

        /// <summary>
        ///     The is inactive
        /// </summary>
        internal bool _isInactive;

        //-1 indicates normal state
        /// <summary>
        ///     The last create entity components buffer index
        /// </summary>
        internal int _lastCreateEntityComponentsBufferIndex = -1;

        /// <summary>
        ///     The create
        /// </summary>
        internal FastStack<DeleteComponent> _removeComponentBuffer = FastStack<DeleteComponent>.Create(4);

        /// <summary>
        ///     The world
        /// </summary>
        internal Scene Scene;

        /// <summary>
        ///     Creates a command buffer, which stores changes to a world without directly applying them.
        /// </summary>
        /// <param name="scene">The world to apply things to.</param>
        public CommandBuffer(Scene scene)
        {
            Scene = scene;
            _isInactive = true;
        }

        /// <summary>
        ///     Whether or not the buffer currently has items to be played back.
        /// </summary>
        public bool HasBufferItems => !_isInactive;

        /// <summary>
        ///     Deletes a component from when <see cref="Playback" /> is called.
        /// </summary>
        /// <param name="gameObject">The entity that will be deleted on playback.</param>
        public void DeleteEntity(GameObject gameObject)
        {
            SetIsActive();
            _deleteEntityBuffer.Push(gameObject.EntityIdOnly);
        }

        /// <summary>
        ///     Removes a component from when <see cref="Playback" /> is called.
        /// </summary>
        /// <param name="gameObject">The entity to remove a component from.</param>
        /// <param name="component">The component to remove.</param>
        public void RemoveComponent(GameObject gameObject, ComponentID component)
        {
            SetIsActive();
            _removeComponentBuffer.Push(new DeleteComponent(gameObject.EntityIdOnly, component));
        }

        /// <summary>
        ///     Removes a component from when <see cref="Playback" /> is called.
        /// </summary>
        /// <typeparam name="T">The component type to remove.</typeparam>
        /// <param name="gameObject">The entity to remove a component from.</param>
        public void RemoveComponent<T>(GameObject gameObject) => RemoveComponent(gameObject, Component<T>.ID);

        /// <summary>
        ///     Removes a component from when <see cref="Playback" /> is called.
        /// </summary>
        /// <param name="gameObject">The entity to remove a component from.</param>
        /// <param name="type">The type of component to remove.</param>
        public void RemoveComponent(GameObject gameObject, Type type) => RemoveComponent(gameObject, Component.GetComponentID(type));

        /// <summary>
        ///     Adds a component to an entity when <see cref="Playback" /> is called.
        /// </summary>
        /// <typeparam name="T">The component type to add.</typeparam>
        /// <param name="gameObject">The entity to add to.</param>
        /// <param name="component">The component to add.</param>
        public void AddComponent<T>(GameObject gameObject, in T component)
        {
            SetIsActive();
            _addComponentBuffer.Push(new AddComponent(gameObject.EntityIdOnly, ComponentHandle.Create(component)));
        }

        /// <summary>
        ///     Adds a component to an entity when <see cref="Playback" /> is called.
        /// </summary>
        /// <param name="gameObject">The entity to add to.</param>
        /// <param name="component">The component to add.</param>
        /// <param name="componentID">The ID of the component type to add as.</param>
        /// <remarks><paramref name="component" /> must be assignable to <see cref="ComponentID.Type" />.</remarks>
        public void AddComponent(GameObject gameObject, ComponentID componentID, object component)
        {
            SetIsActive();
            _addComponentBuffer.Push(new AddComponent(gameObject.EntityIdOnly, ComponentHandle.CreateFromBoxed(componentID, component)));
        }

        /// <summary>
        ///     Adds a component to an entity when <see cref="Playback" /> is called.
        /// </summary>
        /// <param name="gameObject">The entity to add to.</param>
        /// <param name="component">The component to add.</param>
        /// <param name="componentType">The type to add the component as.</param>
        /// <remarks><paramref name="component" /> must be assignable to <paramref name="componentType" />.</remarks>
        public void AddComponent(GameObject gameObject, Type componentType, object component) => AddComponent(gameObject, Component.GetComponentID(componentType), component);

        /// <summary>
        ///     Adds a component to an entity when <see cref="Playback" /> is called.
        /// </summary>
        /// <param name="gameObject">The entity to add to.</param>
        /// <param name="component">The component to add.</param>
        public void AddComponent(GameObject gameObject, object component) => AddComponent(gameObject, component.GetType(), component);

        /// <summary>
        ///     Removes all commands without playing them back.
        /// </summary>
        /// <remarks>This command also removes all empty entities (without events) that have been created by this command buffer.</remarks>
        public void Clear()
        {
            _isInactive = true;

            while (_createEntityBuffer.TryPop(out CreateCommand createCommand))
            {
                EntityIdOnly item = createCommand.Entity;
                ref EntityLocation record = ref Scene.EntityTable[item.ID];
                if (record.Version == item.Version)
                {
                    Scene.DeleteEntityWithoutEvents(item.ToEntity(Scene), ref record);
                }
            }

            _removeComponentBuffer.Clear();
            _deleteEntityBuffer.Clear();
        }

        /// <summary>
        ///     Plays all the queued commands, applying them to a world.
        /// </summary>
        /// <returns>
        ///     <see langword="true" /> when at least one change was made; <see langword="false" /> when this command buffer
        ///     is empty and not active.
        /// </returns>
        public bool Playback()
        {
            bool hasItems = (_deleteEntityBuffer.Count > 0) | (_createEntityBuffer.Count > 0) | (_removeComponentBuffer.Count > 0) | (_addComponentBuffer.Count > 0);

            if (!hasItems)
            {
                return hasItems;
            }

            while (_createEntityBuffer.TryPop(out CreateCommand createCommand))
            {
                GameObject concrete = createCommand.Entity.ToEntity(Scene);
                ref EntityLocation lookup = ref Scene.EntityTable.UnsafeIndexNoResize(concrete.EntityID);

                if (createCommand.BufferLength > 0)
                {
                    Span<ComponentStorageBase> runners = _componentRunnerBuffer.AsSpan(0, createCommand.BufferLength);

                    EntityType id = Scene.DefaultArchetype.ID;
                    Span<ComponentHandle> handles = _createEntityComponents.AsSpan().Slice(createCommand.BufferIndex, createCommand.BufferLength);
                    int size = handles.Length;
                    for (int i = 0; i < size; i++)
                    {
                        id = Scene.AddComponentLookup.FindAdjacentArchetypeId(handles[i].ComponentID, id, Scene, ArchetypeEdgeType.AddComponent);
                    }

                    Scene.MoveEntityToArchetypeAdd(runners, concrete, ref lookup, out EntityLocation location, id.Archetype(Scene));
                }

                Scene.InvokeEntityCreated(concrete);
            }

            while (_deleteEntityBuffer.TryPop(out EntityIdOnly item))
            {
                //double check that its alive
                ref EntityLocation record = ref Scene.EntityTable[item.ID];
                if (record.Version == item.Version)
                {
                    Scene.DeleteEntity(item.ToEntity(Scene), ref record);
                }
            }

            while (_removeComponentBuffer.TryPop(out DeleteComponent item))
            {
                int id = item.Entity.ID;
                ref EntityLocation record = ref Scene.EntityTable[id];
                if (record.Version == item.Entity.Version)
                {
                    Scene.RemoveComponent(item.Entity.ToEntity(Scene), ref record, item.ComponentId);
                }
            }

            while (_addComponentBuffer.TryPop(out AddComponent command))
            {
                int id = command.Entity.ID;
                ref EntityLocation record = ref Scene.EntityTable[id];
                if (record.Version == command.Entity.Version)
                {
                    GameObject concrete = command.Entity.ToEntity(Scene);

                    ComponentStorageBase runner = null!;
                    Scene.AddComponent(concrete, ref record, command.ComponentHandle.ComponentID, ref runner, out EntityLocation location);

                    runner.PullComponentFrom(command.ComponentHandle.ParentTable, location.Index, command.ComponentHandle.Index);

                    if (record.HasEvent(EntityFlags.AddComp))
                    {
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && !NET6_0_OR_GREATER
                        EventRecord events = Scene.EventLookup[command.Entity];
#else
                        ref EventRecord events = ref CollectionsMarshal.GetValueRefOrNullRef(Scene.EventLookup, command.Entity);
#endif
                        events.Add.NormalEvent.Invoke(concrete, command.ComponentHandle.ComponentID);
                        runner.InvokeGenericActionWith(events.Add.GenericEvent, concrete, location.Index);
                    }

                    command.ComponentHandle.Dispose();
                }
            }

            _isInactive = true;

            return hasItems;
        }

        /// <summary>
        ///     Asserts the creating entity
        /// </summary>
        /// <exception cref="InvalidOperationException">Use CommandBuffer.Entity() to begin creating an entity!</exception>
        private void AssertCreatingEntity()
        {
            if (_lastCreateEntityComponentsBufferIndex < 0)
            {
                Throw();
            }

            [MethodImpl(MethodImplOptions.NoInlining)]
            static void Throw() => throw new InvalidOperationException("Use CommandBuffer.Entity() to begin creating an entity!");
        }

        /// <summary>
        ///     Sets the is active
        /// </summary>
        private void SetIsActive()
        {
            _isInactive = false;
        }


        /// <summary>
        ///     Begins to create an entity, which will be resolved when <see cref="Playback" /> is called.
        /// </summary>
        /// <returns><see langword="this" /> instance, for method chaining.</returns>
        /// <exception cref="InvalidOperationException">An entity is already being created.</exception>
        public CommandBuffer Entity()
        {
            SetIsActive();
            if (_lastCreateEntityComponentsBufferIndex >= 0)
            {
                throw new InvalidOperationException("An entity is currently being created! Use 'End' to finish an entity creation!");
            }

            _lastCreateEntityComponentsBufferIndex = _createEntityComponents.Count;
            return this;
        }

        /// <summary>
        ///     Records <paramref name="component" /> to be part of the entity created when resolved.
        /// </summary>
        /// <returns><see langword="this" /> instance, for method chaining.</returns>
        /// <exception cref="InvalidOperationException"><see cref="Entity" /> has not been called."/></exception>
        public CommandBuffer With<T>(T component)
        {
            AssertCreatingEntity();
            _createEntityComponents.Push(Component<T>.StoreComponent(in component));
            return this;
        }

        /// <summary>
        ///     Records <paramref name="component" /> to be part of the entity created when resolved as a component type
        ///     represented by <paramref name="componentID" />.
        /// </summary>
        /// <returns><see langword="this" /> instance, for method chaining.</returns>
        /// <exception cref="InvalidOperationException"><see cref="Entity" /> has not been called."/></exception>
        public CommandBuffer WithBoxed(ComponentID componentID, object component)
        {
            AssertCreatingEntity();
            //we don't check IsAssignableTo - reason is perf - InvalidCastException anyways
            int index = Component.ComponentTable[componentID.RawIndex].Storage.CreateBoxed(component);
            _createEntityComponents.Push(new ComponentHandle(index, componentID));
            return this;
        }

        /// <summary>
        ///     Records <paramref name="component" /> to be part of the entity created when resolved.
        /// </summary>
        /// <returns><see langword="this" /> instance, for method chaining.</returns>
        /// <exception cref="InvalidOperationException"><see cref="Entity" /> has not been called."/></exception>
        public CommandBuffer WithBoxed(object component) => WithBoxed(component.GetType(), component);

        /// <summary>
        ///     Records <paramref name="component" /> to be part of the entity created when resolved as a component type of
        ///     <paramref name="type" />.
        /// </summary>
        /// <returns><see langword="this" /> instance, for method chaining.</returns>
        /// <exception cref="InvalidOperationException"><see cref="Entity" /> has not been called."/></exception>
        public CommandBuffer WithBoxed(Type type, object component) => WithBoxed(Component.GetComponentID(type), component);

        /// <summary>
        ///     Finishes recording entity creation and returns an entity with zero components. Recorded components will be added on
        ///     playback.
        /// </summary>
        /// <returns>The created entity ID</returns>
        public GameObject End()
        {
            //CreateCommand points to a segment of the _createEntityComponents stack
            GameObject e = Scene.CreateEntityWithoutEvent();
            _createEntityBuffer.Push(new CreateCommand(
                e.EntityIdOnly,
                _lastCreateEntityComponentsBufferIndex,
                _createEntityComponents.Count - _lastCreateEntityComponentsBufferIndex));
            _lastCreateEntityComponentsBufferIndex = -1;
            return e;
        }
    }
}