using System;
using Alis.Core.Ecs.Systems;

namespace Alis.Core.Ecs.Sample.Samples
{
    internal sealed class EnumerateEntitiesOnlySample : IEcsSample
    {
        public string Key => "enumerate-entities";

        public string Title => "Enumerate Entities Only";

        public string Description => "Uses query entity enumeration without pulling component refs.";

        public void Run()
        {
            using Scene scene = new Scene();

            scene.Create("A");
            scene.Create("B");
            scene.Create("C");

            int count = 0;
            foreach (GameObject entity in scene.Query<With<string>>().EnumerateWithEntities())
            {
                count++;
                Console.WriteLine($"Entity {count} -> value='{entity.Get<string>()}'");
            }
        }
    }
}

