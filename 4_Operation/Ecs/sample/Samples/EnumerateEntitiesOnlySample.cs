using System;
using Alis.Core.Ecs.Systems;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    /// The enumerate entities only sample class
    /// </summary>
    /// <seealso cref="IEcsSample"/>
    internal sealed class EnumerateEntitiesOnlySample : IEcsSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "enumerate-entities";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Enumerate Entities Only";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Uses query entity enumeration without pulling component refs.";

        /// <summary>
        /// Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();

            scene.Create("A");
            scene.Create("B");
            scene.Create("C");

            int count = 0;
            foreach (GameObject entity in scene.Query<With<string>>().EnumerateWithEntities())
            {
                count++;
                Console.WriteLine($"Entity {count} -> value='{entity.Get<string>()}'");
            }
        }
    }
}

