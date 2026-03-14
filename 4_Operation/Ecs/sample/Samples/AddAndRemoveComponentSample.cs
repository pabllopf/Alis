using System;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    /// The add and remove component sample class
    /// </summary>
    /// <seealso cref="IEcsSample"/>
    internal sealed class AddAndRemoveComponentSample : IEcsSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "add-remove";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Add And Remove Components";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Shows runtime structural changes with Add<T> and Remove<T>.";

        /// <summary>
        /// Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(42);

            Console.WriteLine($"Has<string> before Add: {entity.Has<string>()}");
            entity.Add("temporary component");
            Console.WriteLine($"Has<string> after Add: {entity.Has<string>()}");

            entity.Remove<string>();
            Console.WriteLine($"Has<string> after Remove: {entity.Has<string>()}");
        }
    }
}

