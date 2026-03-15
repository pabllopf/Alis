using System;
using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    /// The entity events sample class
    /// </summary>
    /// <seealso cref="IEcsSample"/>
    internal sealed class EntityEventsSample : IEcsSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "entity-identity";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Entity Identity";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Compares live entities with GameObject.Null and checks liveness.";

        /// <summary>
        /// Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(10);

            Console.WriteLine($"Entity is null: {entity.IsNull}");
            Console.WriteLine($"GameObject.Null is null: {GameObject.Null.IsNull}");
            Console.WriteLine($"Entity equals GameObject.Null: {entity == GameObject.Null}");

            Console.WriteLine($"Entity alive before delete: {entity.IsAlive}");
            entity.Delete();
            Console.WriteLine($"Entity alive after delete: {entity.IsAlive}");
        }
    }
}

