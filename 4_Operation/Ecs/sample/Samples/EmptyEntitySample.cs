using System;

namespace Alis.Core.Ecs.Sample.Samples
{
    internal sealed class EmptyEntitySample : IEcsSample
    {
        public string Key => "empty-entity";

        public string Title => "Empty Entity";

        public string Description => "Creates an entity with zero components and builds it progressively.";

        public void Run()
        {
            using Scene scene = new Scene();

            GameObject entity = scene.Create();
            Console.WriteLine($"Created empty entity. IsAlive: {entity.IsAlive}");

            entity.Add(123);
            entity.Add("late-bound component");

            Console.WriteLine($"Has<int>: {entity.Has<int>()}");
            Console.WriteLine($"Has<string>: {entity.Has<string>()}");
            Console.WriteLine($"Values -> int={entity.Get<int>()}, string='{entity.Get<string>()}'");
        }
    }
}

