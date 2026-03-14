using System;
using Alis.Core.Ecs.Systems;

namespace Alis.Core.Ecs.Sample.Samples
{
    internal sealed class CreateManySample : IEcsSample
    {
        public string Key => "create-many";

        public string Title => "Create Many";

        public string Description => "Creates many entities at once and initializes component spans.";

        public void Run()
        {
            using Scene scene = new Scene();

            ChunkTuple<int, float> chunk = scene.CreateMany<int, float>(5);
            for (int i = 0; i < chunk.Span1.Length; i++)
            {
                chunk.Span1[i] = i + 1;
                chunk.Span2[i] = (i + 1) * 1.5f;
            }

            int entityIndex = 0;
            foreach (GameObject entity in chunk.Entities)
            {
                entityIndex++;
                Console.WriteLine($"Entity {entityIndex}: int={entity.Get<int>()}, float={entity.Get<float>()}");
            }

            Console.WriteLine($"Scene entity count: {scene.EntityCount}");
        }
    }
}

