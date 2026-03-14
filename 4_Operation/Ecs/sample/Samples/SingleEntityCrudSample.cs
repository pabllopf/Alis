using System;
using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs.Sample.Samples
{
    internal sealed class SingleEntityCrudSample : IEcsSample
    {
        public string Key => "entity-crud";

        public string Title => "Single Entity CRUD";

        public string Description => "Shows create, read, update, add, remove and delete operations on one entity.";

        public void Run()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(1, "player");

            Console.WriteLine($"Initial -> int={entity.Get<int>()}, string={entity.Get<string>()}");

            entity.Set(typeof(int), 99);
            entity.Add(3.5f);
            Console.WriteLine($"After update -> int={entity.Get<int>()}, float={entity.Get<float>()}");

            entity.Remove<string>();
            Console.WriteLine($"Has<string> after remove: {entity.Has<string>()}");

            entity.Delete();
            Console.WriteLine($"IsAlive after delete: {entity.IsAlive}");
        }
    }
}

