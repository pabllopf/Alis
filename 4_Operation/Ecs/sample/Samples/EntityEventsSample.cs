using System;
using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs.Sample.Samples
{
    internal sealed class EntityEventsSample : IEcsSample
    {
        public string Key => "entity-identity";

        public string Title => "Entity Identity";

        public string Description => "Compares live entities with GameObject.Null and checks liveness.";

        public void Run()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(10);

            Console.WriteLine($"Entity is null: {entity.IsNull}");
            Console.WriteLine($"GameObject.Null is null: {GameObject.Null.IsNull}");
            Console.WriteLine($"Entity equals GameObject.Null: {entity == GameObject.Null}");

            Console.WriteLine($"Entity alive before delete: {entity.IsAlive}");
            entity.Delete();
            Console.WriteLine($"Entity alive after delete: {entity.IsAlive}");
        }
    }
}

