using System;
using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    /// The type based access sample class
    /// </summary>
    /// <seealso cref="IEcsSample"/>
    internal sealed class TypeBasedAccessSample : IEcsSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "type-access";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Type-Based Access";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Uses AddAs, Get(Type), Set(Type) and Remove(Type) for runtime workflows.";

        /// <summary>
        /// Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.AddAs(typeof(int), 10);
            entity.AddAs(typeof(string), "dynamic value");

            object valueBefore = entity.Get(typeof(int));
            Console.WriteLine($"Value before Set(Type): {valueBefore}");

            entity.Set(typeof(int), 500);
            object valueAfter = entity.Get(typeof(int));
            Console.WriteLine($"Value after Set(Type): {valueAfter}");

            entity.Remove(typeof(string));
            Console.WriteLine($"Has<string> after Remove(Type): {entity.Has<string>()}");
        }
    }
}

