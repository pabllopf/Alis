using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Kernel
{
    /// <summary>
    ///     The gameObject id only
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    
    public struct GameObjectIdOnly(int id, ushort version)
    {
        /// <summary>
        ///     The id
        /// </summary>
        internal int ID = id;

        /// <summary>
        ///     The version
        /// </summary>
        internal ushort Version = version;

        /// <summary>
        ///     Returns the gameObject using the specified scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <returns>The gameObject</returns>
        internal GameObject ToEntity(Scene scene)
        {
            return new GameObject(scene.Id, Version, ID);
        }

        /// <summary>
        ///     Deconstructs the id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="version">The version</param>
        internal void Deconstruct(out int id, out ushort version)
        {
            id = ID;
            version = Version;
        }

        /// <summary>
        ///     Sets the gameObject using the specified gameObject
        /// </summary>
        /// <param name="gameObject">The gameObject</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void SetEntity(ref GameObject gameObject)
        {
            gameObject.EntityVersion = Version;
            gameObject.EntityID = ID;
        }

        /// <summary>
        ///     Inits the gameObject
        /// </summary>
        /// <param name="gameObject">The gameObject</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void Init(GameObject gameObject)
        {
            Version = gameObject.EntityVersion;
            ID = gameObject.EntityID;
        }

        /// <summary>
        ///     Inits the gameObject
        /// </summary>
        /// <param name="entity">The gameObject</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void Init(GameObjectIdOnly entity)
        {
            Version = entity.Version;
            ID = entity.ID;
        }
    }
}