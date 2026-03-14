using System;
using Alis.Core.Ecs.Systems;

namespace Alis.Core.Ecs.Sample.Samples
{
    internal sealed class BulkDeleteByQuerySample : IEcsSample
    {
        public string Key => "bulk-delete-query";

        public string Title => "Bulk Delete By Query";

        public string Description => "Finds entities with a query and deletes a subset.";

        public void Run()
        {
            using Scene scene = new Scene();

            for (int i = 1; i <= 8; i++)
            {
                scene.Create(i);
            }

            Console.WriteLine($"Initial entity count: {scene.EntityCount}");

            foreach (var tuple in scene.Query<With<int>>().EnumerateWithEntities<int>())
            {
                if (tuple.Item1.Value % 2 == 0)
                {
                    tuple.GameObject.Delete();
                }
            }

            scene.Update();

            Console.WriteLine($"Entity count after deleting even values: {scene.EntityCount}");
            Console.Write("Remaining values: ");
            foreach (RefTuple<int> tuple in scene.Query<With<int>>().Enumerate<int>())
            {
                Console.Write($"{tuple.Item1.Value} ");
            }

            Console.WriteLine();
        }
    }
}

