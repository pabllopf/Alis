using System;

namespace Alis.Core.Ecs.Sample.Samples
{
    internal sealed class SetByTypeSample : IEcsSample
    {
        public string Key => "set-by-type";

        public string Title => "Set By Type";

        public string Description => "Updates existing components using runtime Type-based Set.";

        public void Run()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(10, "initial");

            entity.Set(typeof(int), 42);
            entity.Set(typeof(string), "updated with Set(Type, object)");

            Console.WriteLine($"int component: {entity.Get<int>()}");
            Console.WriteLine($"string component: {entity.Get<string>()}");
        }
    }
}

