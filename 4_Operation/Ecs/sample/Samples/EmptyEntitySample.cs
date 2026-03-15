using System;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    /// The empty entity sample class
    /// </summary>
    /// <seealso cref="IEcsSample"/>
    internal sealed class EmptyEntitySample : IEcsSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "empty-entity";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Empty Entity";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Creates an entity with zero components and builds it progressively.";

        /// <summary>
        /// Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();

            GameObject entity = scene.Create();
            Console.WriteLine($"Created empty entity. IsAlive: {entity.IsAlive}");

            entity.Add(123);
            entity.Add("late-bound component");

            Console.WriteLine($"Has<int>: {entity.Has<int>()}");
            Console.WriteLine($"Has<string>: {entity.Has<string>()}");
            Console.WriteLine($"Values -> int={entity.Get<int>()}, string='{entity.Get<string>()}'");
        }
    }
}

