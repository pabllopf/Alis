using Alis.Core.Ecs.Core;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Core.Archetype;

namespace Alis.Core.Ecs
{
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct EntityLocation
    {
        //128 bits
        internal Archetype Archetype;
        internal int Index;
        internal EntityFlags Flags;
        internal ushort Version;

        internal readonly ArchetypeID ArchetypeID => Archetype.ID;

        public EntityLocation(Archetype archetype, int index)
        {
            Archetype = archetype;
            Index = index;
            Flags = EntityFlags.None;
        }

        public EntityLocation(Archetype archetype, int index, EntityFlags flags)
        {
            Archetype = archetype;
            Index = index;
            Flags = flags;
        }

        public static EntityLocation Default { get; } = new EntityLocation(null!, int.MaxValue);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool HasEvent(EntityFlags entityFlags)
        {
            var res = (Flags & entityFlags) != EntityFlags.None;
            return res;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasEventFlag(EntityFlags entityFlags, EntityFlags target)
        {
            var res = (entityFlags & target) != EntityFlags.None;
            return res;
        }
    }
}