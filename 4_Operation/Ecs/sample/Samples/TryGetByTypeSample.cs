using System;
using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    /// The try get by type sample class
    /// </summary>
    /// <seealso cref="IEcsSample"/>
    internal sealed class TryGetByTypeSample : IEcsSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "tryget-type";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "TryGet Generic And Type";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Compares generic TryGet<T> with runtime TryGet(Type, out object).";

        /// <summary>
        /// Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(42, "sample");

            if (entity.TryGet(out Ref<int> intRef))
            {
                Console.WriteLine($"TryGet<int>: {intRef.Value}");
            }

            if (entity.TryGet(typeof(string), out object text))
            {
                Console.WriteLine($"TryGet(typeof(string)): {text}");
            }

            bool hasVelocity = entity.TryGet(typeof(float), out object _);
            Console.WriteLine($"TryGet(typeof(float)) found value: {hasVelocity}");
        }
    }
}

