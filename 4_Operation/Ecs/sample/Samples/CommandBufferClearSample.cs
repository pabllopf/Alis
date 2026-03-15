using System;
using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    /// The command buffer clear sample class
    /// </summary>
    /// <seealso cref="IEcsSample"/>
    internal sealed class CommandBufferClearSample : IEcsSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "command-buffer-clear";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Command Buffer Clear";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Queues commands, clears the buffer, and inspects playback behavior.";

        /// <summary>
        /// Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);
            GameObject entity = scene.Create(12);

            buffer.AddComponent(entity, "queued but cleared");
            buffer.RemoveComponent<int>(entity);

            Console.WriteLine($"Has buffered changes before Clear: {buffer.HasBufferItems}");
            buffer.Clear();
            Console.WriteLine($"Has buffered changes after Clear:  {buffer.HasBufferItems}");

            bool applied = buffer.Playback();
            Console.WriteLine($"Playback applied changes: {applied}");
            Console.WriteLine($"Entity still has int: {entity.Has<int>()}");
            Console.WriteLine($"Entity has string: {entity.Has<string>()}");
            Console.WriteLine("Use this sample to validate buffer semantics in your current ECS version.");
        }
    }
}


