using System;
using Alis.Core.Ecs.Systems;

namespace Alis.Core.Ecs.Sample.Samples
{
    internal sealed class EnumerateWithEntitiesSample : IEcsSample
    {
        public string Key => "enumerate-with-entities";

        public string Title => "Enumerate With Entities";

        public string Description => "Iterates components and owning entities at the same time.";

        public void Run()
        {
            using Scene scene = new Scene();

            scene.Create(5);
            scene.Create(7);
            scene.Create(9);

            foreach (var tuple in scene.Query<With<int>>().EnumerateWithEntities<int>())
            {
                Console.WriteLine($"Entity alive={tuple.GameObject.IsAlive}, value={tuple.Item1.Value}");
            }
        }
    }
}

