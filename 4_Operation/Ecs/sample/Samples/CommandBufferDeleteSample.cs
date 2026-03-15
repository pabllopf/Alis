using System;
using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    /// The command buffer delete sample class
    /// </summary>
    /// <seealso cref="IEcsSample"/>
    internal sealed class CommandBufferDeleteSample : IEcsSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "command-buffer-delete";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Command Buffer Delete";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Schedules entity deletion through CommandBuffer and applies it on playback.";

        /// <summary>
        /// Runs this instance
        /// </summary>
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

