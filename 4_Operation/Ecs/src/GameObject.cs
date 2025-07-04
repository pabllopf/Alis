using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetype;
using Alis.Core.Ecs.Redifinition;
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
                gameObjectLocation = default;
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
                Throw_EntityIsDead();
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
                goto doesntExist;

            int compIndex = GlobalWorldTables.ComponentIndex(entityLocation.ArchetypeId, Component<T>.Id);

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
        public static bool operator ==(GameObject a, GameObject b)
        {
            return a.Equals(b);
        }

        /// <summary>
        ///     Checks if two <see cref="GameObject" /> structs do not refer to the same gameObject.
        /// </summary>
        /// <param name="a">The first gameObject to compare.</param>
        /// <param name="b">The second gameObject to compare.</param>
        /// <returns><see langword="true" /> if the entities do not refer to the same gameObject; otherwise, <see langword="false" />.</returns>
        public static bool operator !=(GameObject a, GameObject b)
        {
            return !a.Equals(b);
        }

        /// <summary>
        ///     Determines whether the specified object is equal to the current <see cref="GameObject" />.
        /// </summary>
        /// <param name="obj">The object to compare with the current gameObject.</param>
        /// <returns>
        ///     <see langword="true" /> if the specified object is an <see cref="GameObject" /> and is equal to the current
        ///     gameObject; otherwise, <see langword="false" />.
        /// </returns>
        public override bool Equals(object obj)
        {
            return obj is GameObject entity && Equals(entity);
        }

        /// <summary>
        ///     Determines whether the specified <see cref="GameObject" /> is equal to the current <see cref="GameObject" />.
        /// </summary>
        /// <param name="other">The gameObject to compare with the current gameObject.</param>
        /// <returns>
        ///     <see langword="true" /> if the specified gameObject is equal to the current gameObject; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        public bool Equals(GameObject other)
        {
            return other.PackedValue == PackedValue;
        }

        /// <summary>
        ///     Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current <see cref="GameObject" />.</returns>
        public override int GetHashCode()
        {
            return PackedValue.GetHashCode();
        }
    } 
}