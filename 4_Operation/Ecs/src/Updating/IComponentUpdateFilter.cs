using System;

namespace Alis.Core.Ecs.Updating
{
    internal interface IComponentUpdateFilter
    {
        public void UpdateSubset(ReadOnlySpan<ArchetypeDeferredUpdateRecord> archetypes);
    }
}
