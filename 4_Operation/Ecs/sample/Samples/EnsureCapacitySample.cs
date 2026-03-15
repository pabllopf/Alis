using System;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    /// The ensure capacity sample class
    /// </summary>
    /// <seealso cref="IEcsSample"/>
    internal sealed class EnsureCapacitySample : IEcsSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "ensure-capacity";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Ensure Capacity";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Preallocates archetype capacity before bulk creation.";

        /// <summary>
        /// Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();

            GameObject seed = scene.Create(0, 0f);
            scene.EnsureCapacity(seed.Type, 50);
            seed.Delete();

            for (int i = 0; i < 50; i++)
            {
                scene.Create(i, (float) i / 10);
            }

            Console.WriteLine($"Entity count after preallocated creation: {scene.EntityCount}");
        }
    }
}

