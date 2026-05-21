

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Kernel.Archetypes;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     Describes the location of a <see cref="GameObject"/> within the ECS world, including its archetype,
    ///     index within that archetype, associated flags, and version for stale-reference detection.
    /// </summary>
    /// <remarks>
    ///     Memory layout optimized: Archetype (reference, 8 bytes) -&gt; Index (4 bytes) -&gt; Flags (4 bytes enum) -&gt; Version (2
    ///     bytes)
    ///     Total: 18 bytes + 6 bytes padding = 24 bytes aligned
    ///     Pack = 4 for optimal performance on 64-bit architectures while minimizing padding
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct GameObjectLocation
    {
        /// <summary>
        ///     The archetype this entity belongs to, which defines the set of component types it contains.
        /// </summary>
        internal Archetype Archetype;

        /// <summary>
        ///     The index of this entity within its archetype's component storage arrays.
        /// </summary>
        internal int Index;

        /// <summary>
        ///     Bitwise flags associated with this entity, tracking event subscriptions and pending operations.
        /// </summary>
        internal GameObjectFlags Flags;

        /// <summary>
        ///     The version number of this entity, used for detecting stale references after deletion and ID recycling.
        /// </summary>
        internal ushort Version;

        /// <summary>
        ///     Gets the unique archetype identifier for this entity's archetype.
        /// </summary>
        internal readonly ArchetypeID ArchetypeId => Archetype.Id;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameObjectLocation"/> struct with the specified archetype and index.
        /// </summary>
        /// <param name="archetype">The archetype this entity belongs to.</param>
        /// <param name="index">The index within the archetype's component storage.</param>
        public GameObjectLocation(Archetype archetype, int index)
        {
            Archetype = archetype;
            Index = index;
            Flags = GameObjectFlags.None;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameObjectLocation"/> struct with the specified archetype, index, and flags.
        /// </summary>
        /// <param name="archetype">The archetype this entity belongs to.</param>
        /// <param name="index">The index within the archetype's component storage.</param>
        /// <param name="flags">The initial flags for this entity location.</param>
        public GameObjectLocation(Archetype archetype, int index, GameObjectFlags flags)
        {
            Archetype = archetype;
            Index = index;
            Flags = flags;
        }

        /// <summary>
        ///     Gets the default <see cref="GameObjectLocation"/> value, representing an invalid or uninitialized location.
        /// </summary>
        public static GameObjectLocation Default { get; } = new GameObjectLocation(null!, int.MaxValue);

        /// <summary>
        ///     Determines whether this entity location has any of the specified flags set.
        /// </summary>
        /// <param name="entityFlags">The flags to check against this entity's flags.</param>
        /// <returns><see langword="true"/> if any of the specified flags are set; otherwise, <see langword="false"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool HasEvent(GameObjectFlags entityFlags)
        {
            bool res = (Flags & entityFlags) != GameObjectFlags.None;
            return res;
        }

        /// <summary>
        ///     Determines whether the specified flags contain any of the target flags.
        /// </summary>
        /// <param name="entityFlags">The entity flags to check.</param>
        /// <param name="target">The target flags to look for within the entity flags.</param>
        /// <returns><see langword="true"/> if any of the target flags are present in <paramref name="entityFlags"/>; otherwise, <see langword="false"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasEventFlag(GameObjectFlags entityFlags, GameObjectFlags target)
        {
            bool res = (entityFlags & target) != GameObjectFlags.None;
            return res;
        }
    }
}