using System;
using Frent.Core;
using Frent.Core.Structures;
using Frent.Updating.Runners;
using System.Buffers;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Frent
{
    /// <summary>
    /// An Entity reference; refers to a collection of components of unqiue types.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    [DebuggerDisplay(AttributeHelpers.DebuggerDisplay)]
    [DebuggerTypeProxy(typeof(EntityDebugView))]
    public partial struct Entity : IEquatable<Entity>
    {
        
        /// <summary>
        /// Creates an <see cref="Entity"/> identical to <see cref="Entity.Null"/>
        /// </summary>
        /// <remarks><see cref="Entity"/> generally shouldn't manually constructed</remarks>
        public Entity() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class
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
        /// The entity id
        /// </summary>
        internal int EntityID;
        /// <summary>
        /// The entity version
        /// </summary>
        internal ushort EntityVersion;
        /// <summary>
        /// The world id
        /// </summary>
        internal ushort WorldID;
        

        
        /// <summary>
        /// The entity world info access
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct EntityWorldInfoAccess
        {
            /// <summary>
            /// The entity id only
            /// </summary>
            internal EntityIDOnly EntityIDOnly;
            /// <summary>
            /// The world id
            /// </summary>
            internal ushort WorldID;
        }

        /// <summary>
        /// The entity high low
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct EntityHighLow
        {
            /// <summary>
            /// The entity id
            /// </summary>
            internal int EntityID;
            /// <summary>
            /// The entity low
            /// </summary>
            internal int EntityLow;
        }

        /// <summary>
        /// The entity data
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct EntityData
        {
            /// <summary>
            /// The entity id
            /// </summary>
            internal int EntityID;
            /// <summary>
            /// The entity version
            /// </summary>
            internal ushort EntityVersion;
            /// <summary>
            /// The world id
            /// </summary>
            internal ushort WorldID;
        }

        /// <summary>
        /// Gets the value of the entity id only
        /// </summary>
        internal EntityIDOnly EntityIDOnly => Unsafe.As<Entity, EntityWorldInfoAccess>(ref this).EntityIDOnly;
        /// <summary>
        /// Gets the value of the packed value
        /// </summary>
        internal long PackedValue => Unsafe.As<Entity, long>(ref this);
        /// <summary>
        /// Gets the value of the entity low
        /// </summary>
        internal int EntityLow => Unsafe.As<Entity, EntityHighLow>(ref this).EntityLow;
        

        

        
        /// <summary>
        /// Internals the is alive using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="entityLocation">The entity location</param>
        /// <returns>The bool</returns>
        internal bool InternalIsAlive(out World world, out EntityLocation entityLocation)
        {
            world = GlobalWorldTables.Worlds.UnsafeIndexNoResize(WorldID);
            if (world is null)
            {
                entityLocation = default;
                return false;
            }
            entityLocation = world.EntityTable.UnsafeIndexNoResize(EntityID);
            return entityLocation.Version == EntityVersion;
        }

        /// <summary>
        /// Asserts the is alive using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <returns>The ref entity location</returns>
        internal ref EntityLocation AssertIsAlive(out World world)
        {
            world = GlobalWorldTables.Worlds.UnsafeIndexNoResize(WorldID);
            //hardware trap
            ref var lookup = ref world.EntityTable.UnsafeIndexNoResize(EntityID);
            if (lookup.Version != EntityVersion)
                Throw_EntityIsDead();
            return ref lookup;
        }

        

        /// <summary>
        /// Tries the get core using the specified exists
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="exists">The exists</param>
        /// <returns>A ref of t</returns>
        private Ref<T> TryGetCore<T>(out bool exists)
        {
            if (!InternalIsAlive(out var _, out var entityLocation))
                goto doesntExist;

            int compIndex = GlobalWorldTables.ComponentIndex(entityLocation.ArchetypeID, Component<T>.ID);

            if (compIndex == 0)
                goto doesntExist;

            exists = true;
            ComponentStorage<T> storage = UnsafeExtensions.UnsafeCast<ComponentStorage<T>>(
                entityLocation.Archetype.Components.UnsafeArrayIndex(compIndex));

            return new Ref<T>(storage, entityLocation.Index);

            doesntExist:
            exists = false;
            return default;
        }

        /// <summary>
        /// Ms
        /// </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void M()
        {

        }

        /// <summary>
        /// Throws the entity is dead
        /// </summary>
        private static void Throw_EntityIsDead() => throw new InvalidOperationException(EntityIsDeadMessage);

        //captial N null to distinguish between actual null and default
        /// <summary>
        /// Gets the value of the debugger display string
        /// </summary>
        internal string DebuggerDisplayString => IsNull ? "Null" : InternalIsAlive(out _, out _) ? $"World: {WorldID}, ID: {EntityID}, Version {EntityVersion}" : EntityIsDeadMessage;
        /// <summary>
        /// The entity is dead message
        /// </summary>
        internal const string EntityIsDeadMessage = "Entity is Dead";
        /// <summary>
        /// The does not have tag message
        /// </summary>
        internal const string DoesNotHaveTagMessage = "This Entity does not have this tag";

        /// <summary>
        /// The entity debug view class
        /// </summary>
        private class EntityDebugView(Entity target)
        {
            /// <summary>
            /// Gets the value of the component types
            /// </summary>
            public ImmutableArray<ComponentID> ComponentTypes => target.ComponentTypes;
            /// <summary>
            /// Gets the value of the tags
            /// </summary>
            public ImmutableArray<TagID> Tags => target.TagTypes;

            /// <summary>
            /// Gets the value of the components
            /// </summary>
            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public Dictionary<Type, object> Components
            {
                get
                {
                    if (!target.InternalIsAlive(out World? world, out var eloc))
                        return [];

                    Dictionary<Type, object> components = [];

                    for (int i = 0; i < ComponentTypes.Length; i++)
                    {
                        components[ComponentTypes[i].Type] = target.Get(ComponentTypes[i]);
                    }

                    return components;
                }
            }
        }
        

        
        /// <summary>
        /// Checks if two <see cref="Entity"/> structs refer to the same entity.
        /// </summary>
        /// <param name="a">The first entity to compare.</param>
        /// <param name="b">The second entity to compare.</param>
        /// <returns><see langword="true"/> if the entities refer to the same entity; otherwise, <see langword="false"/>.</returns>
        public static bool operator ==(Entity a, Entity b) => a.Equals(b);

        /// <summary>
        /// Checks if two <see cref="Entity"/> structs do not refer to the same entity.
        /// </summary>
        /// <param name="a">The first entity to compare.</param>
        /// <param name="b">The second entity to compare.</param>
        /// <returns><see langword="true"/> if the entities do not refer to the same entity; otherwise, <see langword="false"/>.</returns>
        public static bool operator !=(Entity a, Entity b) => !a.Equals(b);

        /// <summary>
        /// Determines whether the specified object is equal to the current <see cref="Entity"/>.
        /// </summary>
        /// <param name="obj">The object to compare with the current entity.</param>
        /// <returns><see langword="true"/> if the specified object is an <see cref="Entity"/> and is equal to the current entity; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object? obj) => obj is Entity entity && Equals(entity);

        /// <summary>
        /// Determines whether the specified <see cref="Entity"/> is equal to the current <see cref="Entity"/>.
        /// </summary>
        /// <param name="other">The entity to compare with the current entity.</param>
        /// <returns><see langword="true"/> if the specified entity is equal to the current entity; otherwise, <see langword="false"/>.</returns>
        public bool Equals(Entity other) => other.PackedValue == PackedValue;

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Entity"/>.</returns>
        public override int GetHashCode() => PackedValue.GetHashCode();
        
    }
}