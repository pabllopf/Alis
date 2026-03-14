using System;
using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs.Sample.Samples
{
    internal sealed class SceneEventsSample : IEcsSample
    {
        public string Key => "scene-events";

        public string Title => "Scene Events";

        public string Description => "Subscribes to scene-level entity and component events.";

        public void Run()
        {
            using Scene scene = new Scene();

            int created = 0;
            int deleted = 0;
            int added = 0;
            int removed = 0;

            scene.EntityCreated += _ => created++;
            scene.EntityDeleted += _ => deleted++;
            scene.ComponentAdded += (_, componentId) =>
            {
                added++;
                Console.WriteLine($"Component added: {componentId.Type.Name}");
            };
            scene.ComponentRemoved += (_, componentId) =>
            {
                removed++;
                Console.WriteLine($"Component removed: {componentId.Type.Name}");
            };

            GameObject entity = scene.Create(7);
            entity.Add("hello");
            entity.Remove<int>();
            entity.Delete();

            Console.WriteLine($"Created events:  {created}");
            Console.WriteLine($"Deleted events:  {deleted}");
            Console.WriteLine($"Added events:    {added}");
            Console.WriteLine($"Removed events:  {removed}");
        }
    }
}

