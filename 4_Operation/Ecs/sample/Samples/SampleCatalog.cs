using System.Collections.Generic;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    /// The sample catalog class
    /// </summary>
    internal static class SampleCatalog
    {
        /// <summary>
        /// Gets the value of the all
        /// </summary>
        public static IReadOnlyList<IEcsSample> All { get; } =
        [
            new SingleEntityCrudSample(),
            new BasicComponentUpdateSample(),
            new CreateFromObjectsSample(),
            new TypeBasedAccessSample(),
            new TryGetByTypeSample(),
            new QueryAndMutateSample(),
            new ComponentCallbacksSample(),
            new InitLifecycleSample(),
            new SimpleGameLoopSample(),
            new TripleDelegateQuerySample(),
            new QueryExecutionModesSample(),
            new EntityApiSample(),
            new AddAndRemoveComponentSample(),
            new EntityLifecycleSample(),
            new MultiComponentQuerySample(),
            new SceneEventsSample(),
            new EntityEventsSample(),
            new NotRuleQuerySample(),
            new EnumerateWithEntitiesSample(),
            new EnumerateEntitiesOnlySample(),
            new ChunkEnumerationSample(),
            new ChunkWithEntitySample(),
            new CreateManySample(),
            new BulkCreateAndMutateSample(),
            new EnsureCapacitySample(),
            new CommandBufferPlaybackSample(),
            new CommandBufferClearSample(),
            new CommandBufferDeleteSample(),
            new SetByTypeSample(),
            new BulkDeleteByQuerySample(),
            new EmptyEntitySample(),
            new EntityTypeInspectionSample(),
            new RuntimeComponentEnumerationSample()
        ];
    }
}

