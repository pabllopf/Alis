using System;
using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    /// The entity type inspection sample class
    /// </summary>
    /// <seealso cref="IEcsSample"/>
    internal sealed class EntityTypeInspectionSample : IEcsSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "entity-type";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Entity Type Inspection";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Reads component type metadata from a live entity.";

        /// <summary>
        /// Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(7, 3.5f, "metadata");

            Console.WriteLine($"Entity type id: {entity.Type}");
            Console.WriteLine("Component types:");

            foreach (ComponentId componentType in entity.ComponentTypes)
            {
                Console.WriteLine($"- {componentType.ToString()}");
            }
        }
    }
}

