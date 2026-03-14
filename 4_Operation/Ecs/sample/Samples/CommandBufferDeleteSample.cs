using System;
using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs.Sample.Samples
{
    internal sealed class CommandBufferDeleteSample : IEcsSample
    {
        public string Key => "command-buffer-delete";

        public string Title => "Command Buffer Delete";

        public string Description => "Schedules entity deletion through CommandBuffer and applies it on playback.";

        public void Run()
        {
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);

            GameObject target = scene.Create("to-delete");
            Console.WriteLine($"Before playback -> IsAlive: {target.IsAlive}, EntityCount: {scene.EntityCount}");

            buffer.DeleteEntity(target);
            buffer.Playback();

            Console.WriteLine($"After playback  -> IsAlive: {target.IsAlive}, EntityCount: {scene.EntityCount}");
        }
    }
}

