using System;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    /// The entity lifecycle sample class
    /// </summary>
    /// <seealso cref="IEcsSample"/>
    internal sealed class EntityLifecycleSample : IEcsSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "entity-lifecycle";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Entity Lifecycle";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Creates an entity, deletes it and verifies liveness state.";

        /// <summary>
        /// Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create("temporary");

            Console.WriteLine($"Entity is alive before Delete: {entity.IsAlive}");
            entity.Delete();
            Console.WriteLine($"Entity is alive after Delete:  {entity.IsAlive}");
            Console.WriteLine($"Current scene entity count: {scene.EntityCount}");
        }
    }
}

