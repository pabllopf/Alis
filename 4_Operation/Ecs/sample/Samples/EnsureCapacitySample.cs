using System;

namespace Alis.Core.Ecs.Sample.Samples
{
    internal sealed class EnsureCapacitySample : IEcsSample
    {
        public string Key => "ensure-capacity";

        public string Title => "Ensure Capacity";

        public string Description => "Preallocates archetype capacity before bulk creation.";

        public void Run()
        {
            using Scene scene = new Scene();

            GameObject seed = scene.Create(0, 0f);
            scene.EnsureCapacity(seed.Type, 50);
            seed.Delete();

            for (int i = 0; i < 50; i++)
            {
                scene.Create(i, (float) i / 10);
            }

            Console.WriteLine($"Entity count after preallocated creation: {scene.EntityCount}");
        }
    }
}

