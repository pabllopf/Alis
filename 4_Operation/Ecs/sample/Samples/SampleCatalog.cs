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
            new BasicComponentUpdateSample(),
            new QueryAndMutateSample(),
            new ComponentCallbacksSample(),
            new InitLifecycleSample(),
            new SimpleGameLoopSample(),
            new QueryExecutionModesSample(),
            new EntityApiSample(),
            new AddAndRemoveComponentSample(),
            new EntityLifecycleSample(),
            new MultiComponentQuerySample()
        ];
    }
}

