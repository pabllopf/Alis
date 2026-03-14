using System;
using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    /// The entity api sample class
    /// </summary>
    /// <seealso cref="IEcsSample"/>
    internal sealed class EntityApiSample : IEcsSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "entity-api";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Entity API";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Uses Has, Add, TryGet, Get and Deconstruct on a single entity.";

        /// <summary>
        /// Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(69, 3.14, 2.71f);

            Console.WriteLine($"IsAlive: {entity.IsAlive}");
            Console.WriteLine($"Has<int>: {entity.Has<int>()}");
            Console.WriteLine($"Has<bool>: {entity.Has<bool>()}");

            entity.Add("I like Alis");

            if (entity.TryGet(out Ref<string> text))
            {
                Console.WriteLine($"Current string: {text.Value}");
                text.Value = "Do you like Alis?";
            }

            Console.WriteLine($"String via Get<string>: {entity.Get<string>()}");

            entity.Deconstruct(out Ref<double> number, out Ref<int> integer, out Ref<float> floating, out Ref<string> message);
            number.Value = 4;
            message.Value = "Hello, ECS scene!";

            Console.WriteLine($"Updated values -> double: {number.Value}, int: {integer.Value}, float: {floating.Value}, string: {message.Value}");
        }
    }
}

