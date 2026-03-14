using System;
using Alis.Core.Ecs.Systems;

namespace Alis.Core.Ecs.Sample.Samples
{
    internal sealed class BulkCreateAndMutateSample : IEcsSample
    {
        public string Key => "bulk-create-mutate";

        public string Title => "Bulk Create And Mutate";

        public string Description => "Creates many entities quickly and mutates all of them with a query.";

        public void Run()
        {
            using Scene scene = new Scene();

            ChunkTuple<int> chunk = scene.CreateMany<int>(20);
            for (int i = 0; i < chunk.Span.Length; i++)
            {
                chunk.Span[i] = i;
            }

            scene.Query<With<int>>().Delegate((ref int value) => value *= 3);

            int sum = 0;
            foreach (RefTuple<int> tuple in scene.Query<With<int>>().Enumerate<int>())
            {
                sum += tuple.Item1.Value;
            }

            Console.WriteLine($"Entity count: {scene.EntityCount}");
            Console.WriteLine($"Sum after multiply by 3: {sum}");
        }
    }
}

