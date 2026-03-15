using System;
using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    /// The scene events sample class
    /// </summary>
    /// <seealso cref="IEcsSample"/>
    internal sealed class SceneEventsSample : IEcsSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "scene-events";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Scene Events";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Subscribes to scene-level entity and component events.";

        /// <summary>
        /// Runs this instance
        /// </summary>
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
                Console.WriteLine($"Component added: {componentId.ToString()}");
            };
            scene.ComponentRemoved += (_, componentId) =>
            {
                removed++;
                Console.WriteLine($"Component removed: {componentId.ToString()}");
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

