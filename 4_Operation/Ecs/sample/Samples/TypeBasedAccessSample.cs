using System;
using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs.Sample.Samples
{
    internal sealed class TypeBasedAccessSample : IEcsSample
    {
        public string Key => "type-access";

        public string Title => "Type-Based Access";

        public string Description => "Uses AddAs, Get(Type), Set(Type) and Remove(Type) for runtime workflows.";

        public void Run()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.AddAs(typeof(int), 10);
            entity.AddAs(typeof(string), "dynamic value");

            object valueBefore = entity.Get(typeof(int));
            Console.WriteLine($"Value before Set(Type): {valueBefore}");

            entity.Set(typeof(int), 500);
            object valueAfter = entity.Get(typeof(int));
            Console.WriteLine($"Value after Set(Type): {valueAfter}");

            entity.Remove(typeof(string));
            Console.WriteLine($"Has<string> after Remove(Type): {entity.Has<string>()}");
        }
    }
}

