using System;
using Alis.Core.Ecs.Systems;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    /// The enumerate with entities sample class
    /// </summary>
    /// <seealso cref="IEcsSample"/>
    internal sealed class EnumerateWithEntitiesSample : IEcsSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "enumerate-with-entities";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Enumerate With Entities";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Iterates components and owning entities at the same time.";

        /// <summary>
        /// Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();

            scene.Create(5);
            scene.Create(7);
            scene.Create(9);

            foreach (var tuple in scene.Query<With<int>>().EnumerateWithEntities<int>())
            {
                Console.WriteLine($"Entity alive={tuple.GameObject.IsAlive}, value={tuple.Item1.Value}");
            }
        }
    }
}

