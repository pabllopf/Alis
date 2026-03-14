using System;
using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs.Sample.Samples
{
    internal sealed class CommandBufferPlaybackSample : IEcsSample
    {
        public string Key => "command-buffer";

        public string Title => "Command Buffer Playback";

        public string Description => "Queues structural changes and applies them with Playback.";

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

