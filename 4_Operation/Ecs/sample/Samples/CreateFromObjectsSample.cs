using System;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    /// The create from objects sample class
    /// </summary>
    /// <seealso cref="IEcsSample"/>
    internal sealed class CreateFromObjectsSample : IEcsSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "create-from-objects";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Create From Objects";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Creates entities from a runtime object array using CreateFromObjects.";

        /// <summary>
        /// Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();

            object[] first = [1, "runtime", 2.5f];
            object[] second = [2, "object array", 9.8f];

            GameObject entityA = scene.CreateFromObjects(first);
            GameObject entityB = scene.CreateFromObjects(second);

            Console.WriteLine($"Entity A -> int={entityA.Get<int>()}, string={entityA.Get<string>()}, float={entityA.Get<float>()}");
            Console.WriteLine($"Entity B -> int={entityB.Get<int>()}, string={entityB.Get<string>()}, float={entityB.Get<float>()}");
        }
    }
}

