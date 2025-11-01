// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObject.public.cs
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
using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Exceptions;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Redifinition;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The gameObject
    /// </summary>
    partial struct GameObject
    {
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
        ///     Checks whether this <see cref="GameObject" /> has a specific tag, using a <see cref="TagId" /> to represent the
        ///     tag.
        /// </summary>
        /// <param name="tagId">The identifier of the tag to check.</param>
        /// <returns>
        ///     <see langword="true" /> if the tag identified by <paramref name="tagId" /> has this <see cref="GameObject" />;
        ///     otherwise, <see langword="false" />.
        /// </returns>
        /// <exception cref="InvalidOperationException">Thrown if the <see cref="GameObject" /> is not alive.</exception>
        public bool Tagged(TagId tagId)
        {
            ref GameObjectLocation lookup = ref AssertIsAlive(out Scene w);
            return lookup.Archetype.HasTag(tagId);
        }

        /// <summary>
        ///     Checks whether this <see cref="GameObject" /> has a specific tag, using a generic type parameter to represent the
        ///     tag.
        /// </summary>
        /// <typeparam name="T">The type used as the tag.</typeparam>
        /// <returns>
        ///     <see langword="true" /> if the tag of type <typeparamref name="T" /> has this <see cref="GameObject" />; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        /// <exception cref="InvalidOperationException">Thrown if the <see cref="GameObject" /> is not alive.</exception>
        public bool Tagged<T>() => Tagged(Kernel.Tag<T>.Id);

        /// <summary>
        ///     Checks whether this <see cref="GameObject" /> has a specific tag, using a <see cref="Type" /> to represent the tag.
        /// </summary>
        /// <remarks>
        ///     Prefer the <see cref="Tagged(TagId)" /> or <see cref="Tagged{T}()" /> overloads. Use
        ///     <see cref="Kernel.Tag{T}.Id" /> to get a <see cref="TagId" /> instance
        /// </remarks>
        /// <param name="type">The <see cref="Type" /> representing the tag to check.</param>
        /// <returns>
        ///     <see langword="true" /> if the tag represented by <paramref name="type" /> has this <see cref="GameObject" />;
        ///     otherwise, <see langword="false" />.
        /// </returns>
        /// <exception cref="InvalidOperationException">Thrown if the <see cref="GameObject" /> not alive.</exception>
        public bool Tagged(Type type) => Tagged(Kernel.Tag.GetTagId(type));

        /// <summary>
        ///     Adds a tag to this <see cref="GameObject" />. Tags are like components but do not take up extra memory.
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="GameObject" /> is dead.</exception>
        /// <param name="type">The type to use as a tag</param>
        public bool Tag(Type type) => Tag(Kernel.Tag.GetTagId(type));

        /// <summary>
        ///     Adds a tag to this <see cref="GameObject" />. Tags are like components but do not take up extra memory.
        /// </summary>
        /// <remarks>
        ///     Prefer the <see cref="Tag(TagId)" /> or <see cref="Tag{T}()" /> overloads. Use <see cref="Kernel.Tag{T}.Id" />
        ///     to get a <see cref="TagId" /> instance
        /// </remarks>
        /// <exception cref="InvalidOperationException"><see cref="GameObject" /> is dead.</exception>
        /// <param name="tagId">The tagID to use as the tag</param>
        public bool Tag(TagId tagId)
        {
            ref GameObjectLocation lookup = ref AssertIsAlive(out Scene w);
            if (lookup.Archetype.HasTag(tagId))
            {
                return false;
            }

            GameObjectType archetype =
                w.AddTagLookup.FindAdjacentArchetypeId(tagId, lookup.Archetype.Id, Scene, ArchetypeEdgeType.AddTag);
            w.MoveEntityToArchetypeIso(this, ref lookup, archetype.Archetype(w));

            return true;
        }


        /// <summary>
        ///     Removes a tag from this <see cref="GameObject" />. Tags are like components but do not take up extra memory.
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="GameObject" /> is dead.</exception>
        /// <returns>
        ///     <see langword="true" /> if the Tag was removed successfully, <see langword="false" /> when the
        ///     <see cref="GameObject" /> doesn't have the component
        /// </returns>
        /// <param name="type">The type of tag to remove.</param>
        public bool Detach(Type type) => Detach(Kernel.Tag.GetTagId(type));

        /// <summary>
        ///     Removes a tag from this <see cref="GameObject" />. Tags are like components but do not take up extra memory.
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="GameObject" /> is dead.</exception>
        /// <returns>
        ///     <see langword="true" /> if the Tag was removed successfully, <see langword="false" /> when the
        ///     <see cref="GameObject" /> doesn't have the component
        /// </returns>
        /// <param name="tagId">The type of tag to remove.</param>
        public bool Detach(TagId tagId)
        {
            ref GameObjectLocation lookup = ref AssertIsAlive(out Scene w);
            if (!lookup.Archetype.HasTag(tagId))
            {
                return false;
            }

            GameObjectType archetype =
                w.AddTagLookup.FindAdjacentArchetypeId(tagId, lookup.Archetype.Id, Scene, ArchetypeEdgeType.RemoveTag);
            w.MoveEntityToArchetypeIso(this, ref lookup, archetype.Archetype(w));

            return true;
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
                return world.EventLookup.GetOrAddNew(EntityIdOnly).Add.GenericEvent ??= new();
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
                return world.EventLookup.GetOrAddNew(EntityIdOnly).Remove.GenericEvent ??= new();
            }
        }

        /// <summary>
        ///     Raised when the gameObject is tagged
        /// </summary>
        public event Action<GameObject, TagId> OnTagged
        {
            add => InitalizeEventRecord(value, GameObjectFlags.Tagged);
            remove => UnsubscribeEvent(value, GameObjectFlags.Tagged);
        }

        /// <summary>
        ///     Raised when a tag is detached from the gameObject
        /// </summary>
        public event Action<GameObject, TagId> OnDetach
        {
            add => InitalizeEventRecord(value, GameObjectFlags.Detach);
            remove => UnsubscribeEvent(value, GameObjectFlags.Detach);
        }

        /// <summary>
        ///     Unsubscribes the event using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="flag">The flag</param>
        private void UnsubscribeEvent(object value, GameObjectFlags flag)
        {
            if (value is null || !InternalIsAlive(out Scene world, out GameObjectLocation entityLocation))
            {
                return;
            }

#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
            bool exists = entityLocation.HasEvent(flag);
            EventRecord events = exists ? Scene.EventLookup[EntityIdOnly] : default;
#else
            ref EventRecord events = ref Scene.TryGetEventData(entityLocation, EntityIdOnly, flag, out bool exists);
#endif


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
                    case GameObjectFlags.Tagged:
                        events!.Tag.Remove((Action<GameObject, TagId>) value);
                        removeFlags = !events.Tag.HasListeners;
                        break;
                    case GameObjectFlags.Detach:
                        events!.Detach.Remove((Action<GameObject, TagId>) value);
                        removeFlags = !events.Detach.HasListeners;
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
        /// <param name="d">The delegate</param>
        /// <param name="flag">The flag</param>
        /// <param name="isGenericEvent">The is generic event</param>
        private void InitalizeEventRecord(object d, GameObjectFlags flag, bool isGenericEvent = false)
        {
            if (d is null || !InternalIsAlive(out Scene world, out GameObjectLocation entityLocation))
            {
                return;
            }
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
            bool exists = entityLocation.HasEvent(flag);
            EventRecord record = exists ? Scene.EventLookup[EntityIdOnly] : default;
#else
            ref EventRecord record =
                ref CollectionsMarshal.GetValueRefOrAddDefault(Scene.EventLookup, EntityIdOnly, out bool exists);
#endif
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
                case GameObjectFlags.Tagged:
                    record.Tag.Add((Action<GameObject, TagId>) d);
                    break;
                case GameObjectFlags.Detach:
                    record.Detach.Add((Action<GameObject, TagId>) d);
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
        ///     Gets tags the gameObject has
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="GameObject" /> is dead.</exception>
        public FastImmutableArray<TagId> TagTypes
        {
            get
            {
                ref GameObjectLocation lookup = ref AssertIsAlive(out _);
                return lookup.Archetype.ArchetypeTagArray;
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
        /// <param name="tags">The tags the <see cref="GameObjectType" /> should have.</param>
        
        public static GameObjectType EntityTypeOf(ReadOnlySpan<ComponentId> components, ReadOnlySpan<TagId> tags) => Archetype.GetArchetypeId(components, tags);
    }
}