using System;
using Alis.Core.Ecs.Kernel.Events;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    /// The runtime component enumeration sample class
    /// </summary>
    /// <seealso cref="IEcsSample"/>
    internal sealed class RuntimeComponentEnumerationSample : IEcsSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "enumerate-components-runtime";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Runtime Component Enumeration";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Enumerates all components on an entity without knowing generic types at compile time.";

        /// <summary>
        /// Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(3, "runtime", 1.25f);

            Console.WriteLine("Enumerating component values:");
            entity.EnumerateComponents(default(PrintComponentAction));
        }

        /// <summary>
        /// The print component action
        /// </summary>
        private struct PrintComponentAction : IGenericAction
        {
            /// <summary>
            /// Invokes the type
            /// </summary>
            /// <typeparam name="T">The </typeparam>
            /// <param name="type">The type</param>
            public void Invoke<T>(ref T type)
            {
                Console.WriteLine($"- {nameof(type)}: {type}");
            }
        }
    }
}

