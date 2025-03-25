// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Entity.cs
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
using System.Collections.Immutable;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Core;
using Alis.Core.Ecs.Core.Archetype;
using Alis.Core.Ecs.Core.Events;
using Alis.Core.Ecs.Core.Memory;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     An Entity reference; refers to a collection of components of unqiue types.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct Entity : IEquatable<Entity>
    {
        /// <summary>
        ///     Creates an <see cref="Entity" /> identical to <see cref="Entity.Null" />
        /// </summary>
        /// <remarks><see cref="Entity" /> generally shouldn't manually constructed</remarks>
        public Entity()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Entity" /> class
        /// </summary>
        /// <param name="worldID">The world id</param>
        /// <param name="version">The version</param>
        /// <param name="entityID">The entity id</param>
        internal Entity(ushort worldID, ushort version, int entityID)
        {
            WorldID = worldID;
            EntityVersion = version;
            EntityID = entityID;
        }

        //WARNING
        //DO NOT CHANGE STRUCT LAYOUT
        /// <summary>
        ///     The entity id
        /// </summary>
        internal int EntityID;

        /// <summary>
        ///     The entity version
        /// </summary>
        internal ushort EntityVersion;

        /// <summary>
        ///     The world id
        /// </summary>
        internal ushort WorldID;


        /// <summary>
        ///     Gets the value of the entity id only
        /// </summary>
        internal EntityIDOnly EntityIDOnly => Unsafe.As<Entity, EntityWorldInfoAccess>(ref this).EntityIDOnly;

        /// <summary>
        ///     Gets the value of the packed value
        /// </summary>
        internal long PackedValue => Unsafe.As<Entity, long>(ref this);

        /// <summary>
        ///     Gets the value of the entity low
        /// </summary>
        internal int EntityLow => Unsafe.As<Entity, EntityHighLow>(ref this).EntityLow;







        /// <summary>
        ///     Internals the is alive using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="entityLocation">The entity location</param>
        /// <returns>The bool</returns>
        internal bool InternalIsAlive(out World world, out EntityLocation entityLocation)
        {
            world = GlobalWorldTables.Worlds.UnsafeIndexNoResize(WorldID);
            if (world is null)
            {
                entityLocation = default(EntityLocation);
                return false;
            }

            entityLocation = world.EntityTable.UnsafeIndexNoResize(EntityID);
            return entityLocation.Version == EntityVersion;
        }

        /// <summary>
        ///     Asserts the is alive using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <returns>The ref entity location</returns>
        internal ref EntityLocation AssertIsAlive(out World world)
        {
            world = GlobalWorldTables.Worlds.UnsafeIndexNoResize(WorldID);
            //hardware trap
            ref EntityLocation lookup = ref world.EntityTable.UnsafeIndexNoResize(EntityID);
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
            if (!InternalIsAlive(out World _, out EntityLocation entityLocation))
            {
                goto doesntExist;
            }

            int compIndex = GlobalWorldTables.ComponentIndex(entityLocation.ArchetypeID, Component<T>.ID);

            if (compIndex == 0)
            {
                goto doesntExist;
            }

            exists = true;
            ComponentStorage<T> storage = UnsafeExtensions.UnsafeCast<ComponentStorage<T>>(
                entityLocation.Archetype.Components.UnsafeArrayIndex(compIndex));

            return new Ref<T>(storage, entityLocation.Index);

            doesntExist:
            exists = false;
            return default(Ref<T>);
        }

        /// <summary>
        ///     Ms
        /// </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void M()
        {
        }

        /// <summary>
        ///     Throws the entity is dead
        /// </summary>
        private static void Throw_EntityIsDead() => throw new InvalidOperationException(EntityIsDeadMessage);

        //captial N null to distinguish between actual null and default
        /// <summary>
        ///     Gets the value of the debugger display string
        /// </summary>
        internal string DebuggerDisplayString => IsNull ? "Null" : InternalIsAlive(out _, out _) ? $"World: {WorldID}, ID: {EntityID}, Version {EntityVersion}" : EntityIsDeadMessage;

        /// <summary>
        ///     The entity is dead message
        /// </summary>
        internal const string EntityIsDeadMessage = "Entity is Dead";

        /// <summary>
        ///     The does not have tag message
        /// </summary>
        internal const string DoesNotHaveTagMessage = "This Entity does not have this tag";

        /// <summary>
        ///     The entity debug view class
        /// </summary>
        private class EntityDebugView(Entity target)
        {
            /// <summary>
            ///     Gets the value of the component types
            /// </summary>
            public ImmutableArray<ComponentID> ComponentTypes => target.ComponentTypes;

            /// <summary>
            ///     Gets the value of the tags
            /// </summary>
            public ImmutableArray<TagId> Tags => target.TagTypes;

            /// <summary>
            ///     Gets the value of the components
            /// </summary>
            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public Dictionary<Type, object> Components
            {
                get
                {
                    if (!target.InternalIsAlive(out World world, out EntityLocation eloc))
                    {
                        return [];
                    }

                    Dictionary<Type, object> components = [];

                    int size = ComponentTypes.Length;
                    for (int i = 0; i < size; i++)
                    {
                        components[ComponentTypes[i].Type] = target.Get(ComponentTypes[i]);
                    }

                    return components;
                }
            }
        }





        /// <summary>
        ///     Checks if two <see cref="Entity" /> structs refer to the same entity.
        /// </summary>
        /// <param name="a">The first entity to compare.</param>
        /// <param name="b">The second entity to compare.</param>
        /// <returns><see langword="true" /> if the entities refer to the same entity; otherwise, <see langword="false" />.</returns>
        public static bool operator ==(Entity a, Entity b) => a.Equals(b);

        /// <summary>
        ///     Checks if two <see cref="Entity" /> structs do not refer to the same entity.
        /// </summary>
        /// <param name="a">The first entity to compare.</param>
        /// <param name="b">The second entity to compare.</param>
        /// <returns><see langword="true" /> if the entities do not refer to the same entity; otherwise, <see langword="false" />.</returns>
        public static bool operator !=(Entity a, Entity b) => !a.Equals(b);

        /// <summary>
        ///     Determines whether the specified object is equal to the current <see cref="Entity" />.
        /// </summary>
        /// <param name="obj">The object to compare with the current entity.</param>
        /// <returns>
        ///     <see langword="true" /> if the specified object is an <see cref="Entity" /> and is equal to the current
        ///     entity; otherwise, <see langword="false" />.
        /// </returns>
        public override bool Equals(object obj) => obj is Entity entity && Equals(entity);

        /// <summary>
        ///     Determines whether the specified <see cref="Entity" /> is equal to the current <see cref="Entity" />.
        /// </summary>
        /// <param name="other">The entity to compare with the current entity.</param>
        /// <returns>
        ///     <see langword="true" /> if the specified entity is equal to the current entity; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        public bool Equals(Entity other) => other.PackedValue == PackedValue;

        /// <summary>
        ///     Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Entity" />.</returns>
        public override int GetHashCode() => PackedValue.GetHashCode();


        /// <summary>
        ///     Checks of this <see cref="Entity" /> has a component specified by <paramref name="componentID" />.
        /// </summary>
        /// <param name="componentID">The component ID of the component type to check.</param>
        /// <returns>
        ///     <see langword="true" /> if the entity has a component of <paramref name="componentID" />, otherwise
        ///     <see langword="false" />.
        /// </returns>
        public bool Has(ComponentID componentID)
        {
            ref EntityLocation entityLocation = ref AssertIsAlive(out _);
            return entityLocation.Archetype.GetComponentIndex(componentID) != 0;
        }

        /// <summary>
        ///     Checks to see if this <see cref="Entity" /> has a component of Type <typeparamref name="T" />.
        /// </summary>
        /// <typeparam name="T">The type of component to check.</typeparam>
        /// <returns>
        ///     <see langword="true" /> if the entity has a component of <typeparamref name="T" />, otherwise
        ///     <see langword="false" />.
        /// </returns>
        public bool Has<T>() => Has(Component<T>.ID);

        /// <summary>
        ///     Checks to see if this <see cref="Entity" /> has a component of Type <paramref name="type" />.
        /// </summary>
        /// <param name="type">The component type to check if this entity has.</param>
        /// <returns>
        ///     <see langword="true" /> if the entity has a component of <paramref name="type" />, otherwise
        ///     <see langword="false" />.
        /// </returns>
        public bool Has(Type type) => Has(Component.GetComponentID(type));

        /// <summary>
        ///     Checks of this <see cref="Entity" /> has a component specified by <paramref name="componentID" /> without throwing
        ///     when dead.
        /// </summary>
        /// <param name="componentID">The component ID of the component type to check.</param>
        /// <returns>
        ///     <see langword="true" /> if the entity is alive and has a component of <paramref name="componentID" />,
        ///     otherwise <see langword="false" />.
        /// </returns>
        public bool TryHas(ComponentID componentID) =>
            InternalIsAlive(out _, out EntityLocation entityLocation) &&
            (entityLocation.Archetype.GetComponentIndex(componentID) != 0);

        /// <summary>
        ///     Checks of this <see cref="Entity" /> has a component specified by <typeparamref name="T" /> without throwing when
        ///     dead.
        /// </summary>
        /// <typeparam name="T">The type of component to check.</typeparam>
        /// <returns>
        ///     <see langword="true" /> if the entity is alive and has a component of <typeparamref name="T" />, otherwise
        ///     <see langword="false" />.
        /// </returns>
        public bool TryHas<T>() => TryHas(Component<T>.ID);

        /// <summary>
        ///     Checks of this <see cref="Entity" /> has a component specified by <paramref name="type" /> without throwing when
        ///     dead.
        /// </summary>
        /// <param name="type">The type of the component type to check.</param>
        /// <returns>
        ///     <see langword="true" /> if the entity is alive and has a component of <paramref name="type" />, otherwise
        ///     <see langword="false" />.
        /// </returns>
        public bool TryHas(Type type) => TryHas(Component.GetComponentID(type));





        /// <summary>
        ///     Gets this <see cref="Entity" />'s component of type <typeparamref name="T" />.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        /// <exception cref="InvalidOperationException"><see cref="Entity" /> is dead.</exception>
        /// <exception cref="ComponentNotFoundException">
        ///     <see cref="Entity" /> does not have component of type
        ///     <typeparamref name="T" />.
        /// </exception>
        /// <returns>A reference to the component in memory.</returns>
        
        public ref T Get<T>()
        {
            //Total: 4x lookup

            //1x
            ref EntityLocation lookup = ref AssertIsAlive(out World world);

            //1x
            //other lookup is optimized into indirect pointer addressing
            Archetype archetype = lookup.Archetype;

            int compIndex = archetype.GetComponentIndex<T>();

            //2x
            //hardware trap
            ComponentStorage<T> storage = UnsafeExtensions.UnsafeCast<ComponentStorage<T>>(archetype.Components.UnsafeArrayIndex(compIndex));
            return ref storage[lookup.Index];
        } //2, 0

        /// <summary>
        ///     Gets this <see cref="Entity" />'s component of type <paramref name="id" />.
        /// </summary>
        /// <param name="id">The ID of the type of component to get</param>
        /// <exception cref="InvalidOperationException"><see cref="Entity" /> is dead.</exception>
        /// <exception cref="ComponentNotFoundException">
        ///     <see cref="Entity" /> does not have component of type
        ///     <paramref name="type" />.
        /// </exception>
        /// <returns>The boxed component.</returns>
        public object Get(ComponentID id)
        {
            ref EntityLocation lookup = ref AssertIsAlive(out _);

            int compIndex = lookup.Archetype.GetComponentIndex(id);

            return lookup.Archetype.Components[compIndex].GetAt(lookup.Index);
        }

        /// <summary>
        ///     Gets this <see cref="Entity" />'s component of type <paramref name="type" />.
        /// </summary>
        /// <param name="type">The type of component to get</param>
        /// <exception cref="InvalidOperationException"><see cref="Entity" /> is dead.</exception>
        /// <exception cref="ComponentNotFoundException">
        ///     <see cref="Entity" /> does not have component of type
        ///     <paramref name="type" />.
        /// </exception>
        /// <returns>The component of type <paramref name="type" /></returns>
        public object Get(Type type) => Get(Component.GetComponentID(type));

        /// <summary>
        ///     Gets this <see cref="Entity" />'s component of type <paramref name="id" />.
        /// </summary>
        /// <param name="id">The ID of the type of component to get</param>
        /// <param name="obj">The component to set</param>
        /// <exception cref="InvalidOperationException"><see cref="Entity" /> is dead.</exception>
        /// <exception cref="ComponentNotFoundException">
        ///     <see cref="Entity" /> does not have component of type
        ///     <paramref name="id" />.
        /// </exception>
        public void Set(ComponentID id, object obj)
        {
            ref EntityLocation lookup = ref AssertIsAlive(out _);

            //2x
            int compIndex = lookup.Archetype.GetComponentIndex(id);

            if (compIndex == 0)
            {
                FrentExceptions.Throw_ComponentNotFoundException(id.Type);
            }

            //3x
            lookup.Archetype.Components[compIndex].SetAt(obj, lookup.Index);
        }

        /// <summary>
        ///     Gets this <see cref="Entity" />'s component of type <paramref name="type" />.
        /// </summary>
        /// <param name="type">The type of component to get</param>
        /// <param name="obj">The component to set</param>
        /// <exception cref="InvalidOperationException"><see cref="Entity" /> is dead.</exception>
        /// <exception cref="ComponentNotFoundException">
        ///     <see cref="Entity" /> does not have component of type
        ///     <paramref name="type" />.
        /// </exception>
        /// <returns>The component of type <paramref name="type" /></returns>
        public void Set(Type type, object obj) => Set(Component.GetComponentID(type), obj);





        /// <summary>
        ///     Attempts to get a component from an <see cref="Entity" />.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        /// <param name="value">A wrapper over a reference to the component when <see langword="true" />.</param>
        /// <returns>
        ///     <see langword="true" /> if this entity has a component of type <typeparamref name="T" />, otherwise
        ///     <see langword="false" />.
        /// </returns>
        public bool TryGet<T>(out Ref<T> value)
        {
            value = TryGetCore<T>(out bool exists)!;
            return exists;
        }

        /// <summary>
        ///     Attempts to get a component from an <see cref="Entity" />.
        /// </summary>
        /// <param name="value">A wrapper over a reference to the component when <see langword="true" />.</param>
        /// <param name="type">The type of component to try and get</param>
        /// <returns>
        ///     <see langword="true" /> if this entity has a component of type <paramref name="type" />, otherwise
        ///     <see langword="false" />.
        /// </returns>
        public bool TryGet(Type type, out object value)
        {
            ref EntityLocation lookup = ref AssertIsAlive(out _);

            ComponentID componentId = Component.GetComponentID(type);
            int compIndex = GlobalWorldTables.ComponentIndex(lookup.ArchetypeID, componentId);

            if (compIndex == 0)
            {
                value = null;
                return false;
            }

            value = lookup.Archetype.Components[compIndex].GetAt(lookup.Index);
            return true;
        }





        /// <summary>
        ///     Adds a component to this <see cref="Entity" /> as its own type
        /// </summary>
        /// <param name="component">The component, which could be boxed</param>
        public void AddBoxed(object component) => AddAs(component.GetType(), component);

        /// <summary>
        ///     Add a component to an <see cref="Entity" />
        /// </summary>
        /// <param name="type">
        ///     The type to add the component as. Note that a component of type DerivedClass and BaseClass are
        ///     different component types.
        /// </param>
        /// <param name="component">The component to add</param>
        public void AddAs(Type type, object component) => AddAs(Component.GetComponentID(type), component);

        /// <summary>
        ///     Adds a component to this <see cref="Entity" />, as a specific component type.
        /// </summary>
        /// <param name="componentID">The component type to add as.</param>
        /// <param name="component">The component to add.</param>
        /// <exception cref="InvalidCastException">
        ///     <paramref name="component" /> is not assignable to the type represented by
        ///     <paramref name="componentID" />.
        /// </exception>
        public void AddAs(ComponentID componentID, object component)
        {
            ref EntityLocation lookup = ref AssertIsAlive(out World w);
            if (w.AllowStructualChanges)
            {
                ComponentStorageBase componentRunner = null!;
                w.AddComponent(this, ref lookup, componentID, ref componentRunner, out EntityLocation entityLocation);
                componentRunner.SetAt(component, entityLocation.Index);
            }
            else
            {
                w.WorldUpdateCommandBuffer.AddComponent(this, componentID, component);
            }
        }





        /// <summary>
        ///     Removes a component from this entity
        /// </summary>
        /// <param name="componentID">The <see cref="ComponentID" /> of the component to be removed</param>
        public void Remove(ComponentID componentID)
        {
            ref EntityLocation lookup = ref AssertIsAlive(out World w);
            if (w.AllowStructualChanges)
            {
                w.RemoveComponent(this, ref lookup, componentID);
            }
            else
            {
                w.WorldUpdateCommandBuffer.RemoveComponent(this, componentID);
            }
        }

        /// <summary>
        ///     Removes a component from an <see cref="Entity" />
        /// </summary>
        /// <param name="type">The type of component to remove</param>
        /// <exception cref="InvalidOperationException"><see cref="Entity" /> is dead.</exception>
        /// <exception cref="ComponentNotFoundException">
        ///     <see cref="Entity" /> does not have component of type
        ///     <paramref name="type" />.
        /// </exception>
        public void Remove(Type type) => Remove(Component.GetComponentID(type));





        /// <summary>
        ///     Checks whether this <see cref="Entity" /> has a specific tag, using a <see cref="TagId" /> to represent the tag.
        /// </summary>
        /// <param name="tagID">The identifier of the tag to check.</param>
        /// <returns>
        ///     <see langword="true" /> if the tag identified by <paramref name="tagID" /> has this <see cref="Entity" />;
        ///     otherwise, <see langword="false" />.
        /// </returns>
        /// <exception cref="InvalidOperationException">Thrown if the <see cref="Entity" /> is not alive.</exception>
        public bool Tagged(TagId tagID)
        {
            ref EntityLocation lookup = ref AssertIsAlive(out World w);
            return lookup.Archetype.HasTag(tagID);
        }

        /// <summary>
        ///     Checks whether this <see cref="Entity" /> has a specific tag, using a generic type parameter to represent the tag.
        /// </summary>
        /// <typeparam name="T">The type used as the tag.</typeparam>
        /// <returns>
        ///     <see langword="true" /> if the tag of type <typeparamref name="T" /> has this <see cref="Entity" />; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        /// <exception cref="InvalidOperationException">Thrown if the <see cref="Entity" /> is not alive.</exception>
        public bool Tagged<T>() => Tagged(Core.Tag<T>.ID);

        /// <summary>
        ///     Checks whether this <see cref="Entity" /> has a specific tag, using a <see cref="Type" /> to represent the tag.
        /// </summary>
        /// <remarks>
        ///     Prefer the <see cref="Tagged(TagId)" /> or <see cref="Tagged{T}()" /> overloads. Use <see cref="Tag{T}.ID" />
        ///     to get a <see cref="TagId" /> instance
        /// </remarks>
        /// <param name="type">The <see cref="Type" /> representing the tag to check.</param>
        /// <returns>
        ///     <see langword="true" /> if the tag represented by <paramref name="type" /> has this <see cref="Entity" />;
        ///     otherwise, <see langword="false" />.
        /// </returns>
        /// <exception cref="InvalidOperationException">Thrown if the <see cref="Entity" /> not alive.</exception>
        public bool Tagged(Type type) => Tagged(Core.Tag.GetTagID(type));

        /// <summary>
        ///     Adds a tag to this <see cref="Entity" />. Tags are like components but do not take up extra memory.
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="Entity" /> is dead.</exception>
        /// <param name="type">The type to use as a tag</param>
        public bool Tag(Type type) => Tag(Core.Tag.GetTagID(type));

        /// <summary>
        ///     Adds a tag to this <see cref="Entity" />. Tags are like components but do not take up extra memory.
        /// </summary>
        /// <remarks>
        ///     Prefer the <see cref="Tag(TagId)" /> or <see cref="Tag{T}()" /> overloads. Use <see cref="Tag{T}.ID" /> to get
        ///     a <see cref="TagId" /> instance
        /// </remarks>
        /// <exception cref="InvalidOperationException"><see cref="Entity" /> is dead.</exception>
        /// <param name="tagID">The tagID to use as the tag</param>
        public bool Tag(TagId tagID)
        {
            ref EntityLocation lookup = ref AssertIsAlive(out World w);
            if (lookup.Archetype.HasTag(tagID))
            {
                return false;
            }

            ArchetypeID archetype = w.AddTagLookup.FindAdjacentArchetypeId(tagID, lookup.Archetype.ID, World, ArchetypeEdgeType.AddTag);
            w.MoveEntityToArchetypeIso(this, ref lookup, archetype.Archetype(w));

            return true;
        }





        /// <summary>
        ///     Removes a tag from this <see cref="Entity" />. Tags are like components but do not take up extra memory.
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="Entity" /> is dead.</exception>
        /// <returns>
        ///     <see langword="true" /> if the Tag was removed successfully, <see langword="false" /> when the
        ///     <see cref="Entity" /> doesn't have the component
        /// </returns>
        /// <param name="type">The type of tag to remove.</param>
        public bool Detach(Type type) => Detach(Core.Tag.GetTagID(type));

        /// <summary>
        ///     Removes a tag from this <see cref="Entity" />. Tags are like components but do not take up extra memory.
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="Entity" /> is dead.</exception>
        /// <returns>
        ///     <see langword="true" /> if the Tag was removed successfully, <see langword="false" /> when the
        ///     <see cref="Entity" /> doesn't have the component
        /// </returns>
        /// <param name="tagID">The type of tag to remove.</param>
        public bool Detach(TagId tagID)
        {
            ref EntityLocation lookup = ref AssertIsAlive(out World w);
            if (!lookup.Archetype.HasTag(tagID))
            {
                return false;
            }

            ArchetypeID archetype = w.AddTagLookup.FindAdjacentArchetypeId(tagID, lookup.Archetype.ID, World, ArchetypeEdgeType.RemoveTag);
            w.MoveEntityToArchetypeIso(this, ref lookup, archetype.Archetype(w));

            return true;
        }





        /// <summary>
        ///     Raised when the entity is deleted
        /// </summary>
        public event Action<Entity> OnDelete
        {
            add => InitalizeEventRecord(value, EntityFlags.OnDelete);
            remove => UnsubscribeEvent(value, EntityFlags.OnDelete);
        }

        /// <summary>
        ///     Raised when a component is added to an entity
        /// </summary>
        public event Action<Entity, ComponentID> OnComponentAdded
        {
            add => InitalizeEventRecord(value, EntityFlags.AddComp);
            remove => UnsubscribeEvent(value, EntityFlags.AddComp);
        }

        /// <summary>
        ///     Raised when a component is removed from an entity
        /// </summary>
        public event Action<Entity, ComponentID> OnComponentRemoved
        {
            add => InitalizeEventRecord(value, EntityFlags.RemoveComp);
            remove => UnsubscribeEvent(value, EntityFlags.RemoveComp);
        }

        /// <summary>
        ///     Raised when a component is added to an entity, with the generic parameter
        /// </summary>
        public GenericEvent OnComponentAddedGeneric
        {
            readonly set
            {
                /*the set is just to enable the += syntax*/
            }
            get
            {
                if (!InternalIsAlive(out World world, out _))
                {
                    return null;
                }

                world.EntityTable[EntityID].Flags |= EntityFlags.AddGenericComp;
                return world.EventLookup.GetOrAddNew(EntityIDOnly).Add.GenericEvent ??= new();
            }
        }

        /// <summary>
        ///     Raised when a component is removed to an entity, with the generic parameter
        /// </summary>
        public GenericEvent OnComponentRemovedGeneric
        {
            readonly set
            {
                /*the set is just to enable the += syntax*/
            }
            get
            {
                if (!InternalIsAlive(out World world, out _))
                {
                    return null;
                }

                world.EntityTable[EntityID].Flags |= EntityFlags.RemoveGenericComp;
                return world.EventLookup.GetOrAddNew(EntityIDOnly).Remove.GenericEvent ??= new();
            }
        }

        /// <summary>
        ///     Raised when the entity is tagged
        /// </summary>
        public event Action<Entity, TagId> OnTagged
        {
            add => InitalizeEventRecord(value, EntityFlags.Tagged);
            remove => UnsubscribeEvent(value, EntityFlags.Tagged);
        }

        /// <summary>
        ///     Raised when a tag is detached from the entity
        /// </summary>
        public event Action<Entity, TagId> OnDetach
        {
            add => InitalizeEventRecord(value, EntityFlags.Detach);
            remove => UnsubscribeEvent(value, EntityFlags.Detach);
        }

        /// <summary>
        ///     Unsubscribes the event using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="flag">The flag</param>
        private void UnsubscribeEvent(object value, EntityFlags flag)
        {
            if (value is null || !InternalIsAlive(out World world, out EntityLocation entityLocation))
            {
                return;
            }

#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && !NET6_0_OR_GREATER
            bool exists = entityLocation.HasEvent(flag);
            EventRecord events = exists ? world.EventLookup[EntityIDOnly] : default(EventRecord);
#else
            ref EventRecord events = ref world.TryGetEventData(entityLocation, EntityIDOnly, flag, out bool exists);
#endif


            if (exists)
            {
                bool removeFlags = false;

                switch (flag)
                {
                    case EntityFlags.AddComp:
                        events!.Add.NormalEvent.Remove((Action<Entity, ComponentID>) value);
                        removeFlags = !events.Add.HasListeners;
                        break;
                    case EntityFlags.RemoveComp:
                        events!.Remove.NormalEvent.Remove((Action<Entity, ComponentID>) value);
                        removeFlags = !events.Remove.HasListeners;
                        break;
                    case EntityFlags.Tagged:
                        events!.Tag.Remove((Action<Entity, TagId>) value);
                        removeFlags = !events.Tag.HasListeners;
                        break;
                    case EntityFlags.Detach:
                        events!.Detach.Remove((Action<Entity, TagId>) value);
                        removeFlags = !events.Detach.HasListeners;
                        break;
                    case EntityFlags.OnDelete:
                        events!.Delete.Remove((Action<Entity>) value);
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
        /// <param name="@delegate">The delegate</param>
        /// <param name="flag">The flag</param>
        /// <param name="isGenericEvent">The is generic event</param>
        private void InitalizeEventRecord(object @delegate, EntityFlags flag, bool isGenericEvent = false)
        {
            if (@delegate is null || !InternalIsAlive(out World world, out EntityLocation entityLocation))
            {
                return;
            }
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && !NET6_0_OR_GREATER
            bool exists = entityLocation.HasEvent(flag);
            EventRecord record = exists ? world.EventLookup[EntityIDOnly] : default(EventRecord);
#else
            ref EventRecord record = ref CollectionsMarshal.GetValueRefOrAddDefault(world.EventLookup, EntityIDOnly, out bool exists);
#endif
            world.EntityTable[EntityID].Flags |= flag;
            EventRecord.Initalize(exists, ref record!);

            switch (flag)
            {
                case EntityFlags.AddComp:
                    if (isGenericEvent)
                    {
                        record.Add.GenericEvent = (GenericEvent) @delegate;
                    }
                    else
                    {
                        record.Add.NormalEvent.Add((Action<Entity, ComponentID>) @delegate);
                    }

                    break;
                case EntityFlags.RemoveComp:
                    if (isGenericEvent)
                    {
                        record.Remove.GenericEvent = (GenericEvent) @delegate;
                    }
                    else
                    {
                        record.Remove.NormalEvent.Add((Action<Entity, ComponentID>) @delegate);
                    }

                    break;
                case EntityFlags.Tagged:
                    record.Tag.Add((Action<Entity, TagId>) @delegate);
                    break;
                case EntityFlags.Detach:
                    record.Detach.Add((Action<Entity, TagId>) @delegate);
                    break;
                case EntityFlags.OnDelete:
                    record.Delete.Push((Action<Entity>) @delegate);
                    break;
            }
        }





        /// <summary>
        ///     Deletes this entity
        /// </summary>
        
        public void Delete()
        {
            World world = GlobalWorldTables.Worlds.UnsafeIndexNoResize(WorldID);
            //hardware trap
            ref EntityLocation lookup = ref world.EntityTable.UnsafeIndexNoResize(EntityID);

            if (lookup.Version != EntityVersion)
            {
                return;
            }

            if (world.AllowStructualChanges)
            {
                world.DeleteEntity(this, ref lookup);
            }
            else
            {
                world.WorldUpdateCommandBuffer.DeleteEntity(this);
            }
        }

        /// <summary>
        ///     Checks to see if this <see cref="Entity" /> is still alive
        /// </summary>
        /// <returns>
        ///     <see langword="true" /> if this entity is still alive (not deleted), otherwise <see langword="false" />
        /// </returns>
        public bool IsAlive => InternalIsAlive(out _, out _);

        /// <summary>
        ///     Checks to see if this <see cref="Entity" /> instance is the null entity: <see langword="default" />(
        ///     <see cref="Entity" />)
        /// </summary>
        public bool IsNull => PackedValue == 0;

        /// <summary>
        ///     Gets the world this entity belongs to
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="Entity" /> is dead.</exception>
        public World World => GlobalWorldTables.Worlds.UnsafeIndexNoResize(WorldID) ?? throw new InvalidOperationException();

        /// <summary>
        ///     Gets the component types for this entity, ordered in update order
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="Entity" /> is dead.</exception>
        public ImmutableArray<ComponentID> ComponentTypes
        {
            get
            {
                ref EntityLocation lookup = ref AssertIsAlive(out _);
                return lookup.Archetype.ArchetypeTypeArray;
            }
        }

        /// <summary>
        ///     Gets tags the entity has
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="Entity" /> is dead.</exception>
        public ImmutableArray<TagId> TagTypes
        {
            get
            {
                ref EntityLocation lookup = ref AssertIsAlive(out _);
                return lookup.Archetype.ArchetypeTagArray;
            }
        }

        /// <summary>
        ///     The <see cref="EntityType" /> of this <see cref="Entity" />.
        /// </summary>
        public EntityType Type
        {
            get
            {
                ref EntityLocation lookup = ref AssertIsAlive(out _);
                return lookup.Archetype.ID;
            }
        }

        /// <summary>
        ///     Enumerates all components one by one
        /// </summary>
        /// <param name="onEach">The unbound generic function called on each item</param>
        public void EnumerateComponents(IGenericAction onEach)
        {
            ref EntityLocation lookup = ref AssertIsAlive(out World _);
            ComponentStorageBase[] runners = lookup.Archetype.Components;
            int size = runners.Length;
            for (int i = 1; i < size; i++)
            {
                runners[i].InvokeGenericActionWith(onEach, lookup.Index);
            }
        }

        /// <summary>
        ///     The null entity
        /// </summary>
        public static Entity Null => default(Entity);

        /// <summary>
        ///     Gets an <see cref="EntityType" /> without needing an <see cref="Entity" /> of the specific type.
        /// </summary>
        /// <param name="components">The components the <see cref="EntityType" /> should have.</param>
        /// <param name="tags">The tags the <see cref="EntityType" /> should have.</param>
        public static EntityType EntityTypeOf(ReadOnlySpan<ComponentID> components, ReadOnlySpan<TagId> tags) => Archetype.GetArchetypeID(components, tags);

        //traversing archetype graph strategy:
        //1. hit small & fast static per type cache - 1 branch
        //2. dictionary lookup
        //3. find existing archetype
        //4. create new archetype

        /// <summary>
        ///     Adds a component to this <see cref="Entity" />.
        /// </summary>
        /// <remarks>If the world is being updated, changed are deffered to the end of the world update.</remarks>
        
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

            ref T c1ref = ref UnsafeExtensions.UnsafeCast<ComponentStorage<T>>(buff.UnsafeSpanIndex(0))[nextLocation.Index];
            c1ref = c1;

            Component<T>.Initer?.Invoke(this, ref c1ref);

            EntityFlags flags = thisLookup.Flags;
            if (EntityLocation.HasEventFlag(flags | world.WorldEventFlags, EntityFlags.AddComp | EntityFlags.AddGenericComp))
            {
                if (world.ComponentAddedEvent.HasListeners)
                {
                    InvokeComponentWorldEvents<T>(ref world.ComponentAddedEvent, this);
                }

                if (EntityLocation.HasEventFlag(flags, EntityFlags.AddComp | EntityFlags.AddGenericComp))
                {
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && !NET6_0_OR_GREATER
                    EventRecord events = world.EventLookup[EntityIDOnly];
#else
                    ref EventRecord events = ref CollectionsMarshal.GetValueRefOrNullRef(world.EventLookup, EntityIDOnly);
#endif
                    InvokePerEntityEvents(this, EntityLocation.HasEventFlag(thisLookup.Flags, EntityFlags.AddGenericComp), ref events.Add, ref c1ref);
                }
            }
        }

        /// <summary>
        ///     Removes a component from this <see cref="Entity" />
        /// </summary>
        /// <inheritdoc cref="Add{T}(in T)" />
        
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
        ///     Adds a tag to this <see cref="Entity" />
        /// </summary>
        /// <inheritdoc cref="Add{T}(in T)" />
        
        public void Tag<T>()
        {
            ref EntityLocation thisLookup = ref AssertIsAlive(out World world);

            Archetype to = TraverseThroughCacheOrCreate<TagId, NeighborCache<T>>(
                world,
                ref NeighborCache<T>.Tag.Lookup,
                ref thisLookup,
                true);

            world.MoveEntityToArchetypeIso(this, ref thisLookup, to);

            EntityFlags flags = thisLookup.Flags | world.WorldEventFlags;
            if (EntityLocation.HasEventFlag(flags, EntityFlags.Tagged))
            {
                if (world.Tagged.HasListeners)
                {
                    InvokeTagWorldEvents<T>(ref world.Tagged, this);
                }

                if (EntityLocation.HasEventFlag(flags, EntityFlags.Tagged))
                {
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && !NET6_0_OR_GREATER
                    EventRecord events = world.EventLookup[EntityIDOnly];
#else
                    ref EventRecord events = ref CollectionsMarshal.GetValueRefOrNullRef(world.EventLookup, EntityIDOnly);
#endif
                    InvokePerEntityTagEvents<T>(this, ref events.Tag);
                }
            }
        }

        /// <summary>
        ///     Removes a tag from this <see cref="Entity" />
        /// </summary>
        /// <inheritdoc cref="Add{T}(in T)" />
        public void Detach<T>()
        {
            ref EntityLocation thisLookup = ref AssertIsAlive(out World world);

            Archetype to = TraverseThroughCacheOrCreate<TagId, NeighborCache<T>>(
                world,
                ref NeighborCache<T>.Detach.Lookup,
                ref thisLookup,
                false);

            world.MoveEntityToArchetypeIso(this, ref thisLookup, to);

            EntityFlags flags = thisLookup.Flags | world.WorldEventFlags;
            if (EntityLocation.HasEventFlag(flags, EntityFlags.Detach))
            {
                if (world.Detached.HasListeners)
                {
                    InvokeTagWorldEvents<T>(ref world.Detached, this);
                }

                if (EntityLocation.HasEventFlag(flags, EntityFlags.Detach))
                {
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && !NET6_0_OR_GREATER
                    EventRecord events = world.EventLookup[EntityIDOnly];
#else
                    ref EventRecord events = ref CollectionsMarshal.GetValueRefOrNullRef(world.EventLookup, EntityIDOnly);
#endif
                    InvokePerEntityTagEvents<T>(this, ref events.Detach);
                }
            }
        }

        /// <summary>
        ///     Invokes the component world events using the specified event
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="@event">The event</param>
        /// <param name="entity">The entity</param>
        private static void InvokeComponentWorldEvents<T>(ref Event<ComponentID> @event, Entity entity)
        {
            @event.InvokeInternal(entity, Component<T>.ID);
        }

        /// <summary>
        ///     Invokes the per entity events using the specified entity
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
            {
                return;
            }

            events.GenericEvent!.Invoke(entity, ref component);
        }

        /// <summary>
        ///     Invokes the tag world events using the specified event
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="@event">The event</param>
        /// <param name="entity">The entity</param>
        private static void InvokeTagWorldEvents<T>(ref TagEvent @event, Entity entity)
        {
            @event.InvokeInternal(entity, Core.Tag<T>.ID);
        }

        /// <summary>
        ///     Invokes the per entity tag events using the specified entity
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="entity">The entity</param>
        /// <param name="events">The events</param>
        private static void InvokePerEntityTagEvents<T>(Entity entity, ref TagEvent events)
        {
            events.Invoke(entity, Core.Tag<T>.ID);
        }

        /// <summary>
        ///     Traverses the through cache or create using the specified world
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <typeparam name="TEdge">The edge</typeparam>
        /// <param name="world">The world</param>
        /// <param name="cache">The cache</param>
        /// <param name="currentLookup">The current lookup</param>
        /// <param name="add">The add</param>
        /// <returns>The archetype</returns>
        
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

            return Archetype.CreateOrGetExistingArchetype(new EntityType(cache.Lookup(index)), world);

            static Archetype NotInCache(World world, ref ArchetypeNeighborCache cache, ArchetypeID archetypeFromID, bool add)
            {
                ImmutableArray<ComponentID> componentIDs = archetypeFromID.Types;
                ImmutableArray<TagId> tagIDs = archetypeFromID.Tags;

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
    }
}