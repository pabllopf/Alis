using Alis.Core.Ecs.Core;
using Alis.Core.Ecs.Core.Archetype;

namespace Alis.Core.Ecs.Updating
{
    internal record struct ArchetypeDeferredUpdateRecord(Archetype Archetype, Archetype TemporaryBuffers, int InitalEntityCount);
}