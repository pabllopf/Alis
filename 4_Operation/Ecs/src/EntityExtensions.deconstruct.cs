using Alis.Core.Ecs.Core;
using Alis.Core.Ecs.Updating;
using Alis.Core.Ecs.Updating.Runners;
using System.Runtime.CompilerServices;
using Alis.Core.Ecs.Core.Archetype;
using Alis.Core.Ecs.Core.Memory;

namespace Alis.Core.Ecs
{
    partial class EntityExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Ref<TC> GetComp<TC>(byte[] archetypeTable, ComponentStorageBase[] comps, int index)
        {
            int compIndex = archetypeTable.UnsafeArrayIndex(Component<TC>.ID.RawIndex) & GlobalWorldTables.IndexBits;
            return new Ref<TC>(UnsafeExtensions.UnsafeCast<ComponentStorage<TC>>(comps.UnsafeArrayIndex(compIndex)), index);
        }
    }
}
