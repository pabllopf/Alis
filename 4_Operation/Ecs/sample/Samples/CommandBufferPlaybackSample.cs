using System;
using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    /// The command buffer playback sample class
    /// </summary>
    /// <seealso cref="IEcsSample"/>
    internal sealed class CommandBufferPlaybackSample : IEcsSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "command-buffer";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Command Buffer Playback";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Queues structural changes and applies them with Playback.";

        /// <summary>
        /// Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);

            GameObject entity = scene.Create(100);

            buffer.AddComponent(entity, "queued string");
            buffer.RemoveComponent<int>(entity);
            bool applied = buffer.Playback();

            Console.WriteLine($"Playback applied changes: {applied}");
            Console.WriteLine($"Has<int>: {entity.Has<int>()}");
            Console.WriteLine($"Has<string>: {entity.Has<string>()}");
            Console.WriteLine($"String value: {entity.Get<string>()}");
        }
    }
}

