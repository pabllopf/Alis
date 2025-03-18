using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Frent.Core
{
    /// <summary>
    /// The entity id only
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
//TODO: rename this?
    internal struct EntityIDOnly(int id, ushort version)
    {
        /// <summary>
        /// The id
        /// </summary>
        internal int ID = id;
        /// <summary>
        /// The version
        /// </summary>
        internal ushort Version = version;
        /// <summary>
        /// Returns the entity using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <returns>The entity</returns>
        internal Entity ToEntity(World world) => new Entity(world.ID, Version, ID);
        /// <summary>
        /// Deconstructs the id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="version">The version</param>
        internal void Deconstruct(out int id, out ushort version)
        {
            id = ID;
            version = Version;
        }

        /// <summary>
        /// Sets the entity using the specified entity
        /// </summary>
        /// <param name="entity">The entity</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void SetEntity(ref Entity entity)
        {
            entity.EntityVersion = Version;
            entity.EntityID = ID;
        }

        /// <summary>
        /// Inits the entity
        /// </summary>
        /// <param name="entity">The entity</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void Init(Entity entity)
        {
            Version = entity.EntityVersion;
            ID = entity.EntityID;
        }

        /// <summary>
        /// Inits the entity
        /// </summary>
        /// <param name="entity">The entity</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void Init(EntityIDOnly entity)
        {
            Version = entity.Version;
            ID = entity.ID;
        }
    }
    internal record struct DeleteComponent(EntityIDOnly Entity, ComponentID ComponentID);
    internal record struct AddComponent(EntityIDOnly Entity, ComponentHandle ComponentHandle);
    internal record struct CreateCommand(EntityIDOnly Entity, int BufferIndex, int BufferLength);
}