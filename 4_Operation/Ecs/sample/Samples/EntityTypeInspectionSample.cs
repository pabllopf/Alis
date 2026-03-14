using System;
using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs.Sample.Samples
{
    internal sealed class EntityTypeInspectionSample : IEcsSample
    {
        public string Key => "entity-type";

        public string Title => "Entity Type Inspection";

        public string Description => "Reads component type metadata from a live entity.";

        public void Run()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(7, 3.5f, "metadata");

            Console.WriteLine($"Entity type id: {entity.Type}");
            Console.WriteLine("Component types:");

            foreach (ComponentId componentType in entity.ComponentTypes)
            {
                Console.WriteLine($"- {componentType.Type.Name}");
            }
        }
    }
}

