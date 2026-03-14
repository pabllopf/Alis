using System;
using Alis.Core.Ecs.Sample.Components;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    /// The basic component update sample class
    /// </summary>
    /// <seealso cref="IEcsSample"/>
    internal sealed class BasicComponentUpdateSample : IEcsSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "basic-update";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Basic Component Update";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Creates entities with text components and updates the scene once.";

        /// <summary>
        /// Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();

            for (int i = 0; i < 3; i++)
            {
                scene.Create<string, ConsoleText>("Hello from ECS", new ConsoleText(ConsoleColor.Cyan));
            }

            scene.Update();
        }
    }
}

