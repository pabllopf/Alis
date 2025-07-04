using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Core.Archetype;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The gameObject location
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    
    public struct GameObjectLocation
    {
        //128 bits
        /// <summary>
        ///     The archetype
        /// </summary>
        internal Archetype Archetype;

        /// <summary>
        ///     The index
        /// </summary>
        internal int Index;

        /// <summary>
        ///     The flags
        /// </summary>
        internal GameObjectFlags Flags;

        /// <summary>
        ///     The version
        /// </summary>
        internal ushort Version;

        /// <summary>
        ///     Gets the value of the archetype id
        /// </summary>
        internal readonly ArchetypeID ArchetypeId => Archetype.Id;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameObjectLocation" /> class
        /// </summary>
        /// <param name="archetype">The archetype</param>
        /// <param name="index">The index</param>
        public GameObjectLocation(Archetype archetype, int index)
        {
            Archetype = archetype;
            Index = index;
            Flags = GameObjectFlags.None;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameObjectLocation" /> class
        /// </summary>
        /// <param name="archetype">The archetype</param>
        /// <param name="index">The index</param>
        /// <param name="flags">The flags</param>
        public GameObjectLocation(Archetype archetype, int index, GameObjectFlags flags)
        {
            Archetype = archetype;
            Index = index;
            Flags = flags;
        }

        /// <summary>
        ///     Gets the value of the default
        /// </summary>
        public static GameObjectLocation Default { get; } = new GameObjectLocation(null!, int.MaxValue);

        /// <summary>
        ///     Hases the event using the specified gameObject flags
        /// </summary>
        /// <param name="entityFlags">The gameObject flags</param>
        /// <returns>The res</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool HasEvent(GameObjectFlags entityFlags)
        {
            bool res = (Flags & entityFlags) != GameObjectFlags.None;
            return res;
        }

        /// <summary>
        ///     Hases the event flag using the specified gameObject flags
        /// </summary>
        /// <param name="entityFlags">The gameObject flags</param>
        /// <param name="target">The target</param>
        /// <returns>The res</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasEventFlag(GameObjectFlags entityFlags, GameObjectFlags target)
        {
            bool res = (entityFlags & target) != GameObjectFlags.None;
            return res;
        }
    }
}