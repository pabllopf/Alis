using System;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems;

namespace Alis.Core.Ecs.Sample.Samples
{
    internal sealed class NotRuleQuerySample : IEcsSample
    {
        public string Key => "query-not";

        public string Title => "Query With Not Rule";

        public string Description => "Filters entities with int but without bool using Not<T>.";

        public void Run()
        {
            using Scene scene = new Scene();

            scene.Create(1);
            scene.Create(2, true);
            scene.Create(3);
            scene.Create(4, false);

            Console.WriteLine("Entities that match With<int> + Not<bool>:");
            foreach (RefTuple<int> tuple in scene.Query<With<int>, Not<bool>>().Enumerate<int>())
            {
                Console.WriteLine($"Value: {tuple.Item1.Value}");
            }
        }
    }
}

