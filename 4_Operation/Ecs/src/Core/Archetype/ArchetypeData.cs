using System.Collections.Immutable;

namespace Alis.Core.Ecs.Core.Archetype
{
    internal record struct ArchetypeData(EntityType ID, ImmutableArray<ComponentID> ComponentTypes, ImmutableArray<TagID> TagTypes);
}