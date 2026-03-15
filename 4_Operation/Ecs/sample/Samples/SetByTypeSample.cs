using System;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    /// The set by type sample class
    /// </summary>
    /// <seealso cref="IEcsSample"/>
    internal sealed class SetByTypeSample : IEcsSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "set-by-type";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Set By Type";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Updates existing components using runtime Type-based Set.";

        /// <summary>
        /// Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(10, "initial");

            entity.Set(typeof(int), 42);
            entity.Set(typeof(string), "updated with Set(Type, object)");

            Console.WriteLine($"int component: {entity.Get<int>()}");
            Console.WriteLine($"string component: {entity.Get<string>()}");
        }
    }
}

