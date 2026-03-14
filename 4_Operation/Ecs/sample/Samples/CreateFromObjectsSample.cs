using System;

namespace Alis.Core.Ecs.Sample.Samples
{
    internal sealed class CreateFromObjectsSample : IEcsSample
    {
        public string Key => "create-from-objects";

        public string Title => "Create From Objects";

        public string Description => "Creates entities from a runtime object array using CreateFromObjects.";

        public void Run()
        {
            using Scene scene = new Scene();

            object[] first = [1, "runtime", 2.5f];
            object[] second = [2, "object array", 9.8f];

            GameObject entityA = scene.CreateFromObjects(first);
            GameObject entityB = scene.CreateFromObjects(second);

            Console.WriteLine($"Entity A -> int={entityA.Get<int>()}, string={entityA.Get<string>()}, float={entityA.Get<float>()}");
            Console.WriteLine($"Entity B -> int={entityB.Get<int>()}, string={entityB.Get<string>()}, float={entityB.Get<float>()}");
        }
    }
}

