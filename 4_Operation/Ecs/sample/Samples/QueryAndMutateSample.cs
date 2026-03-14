using System;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Sample.Components;
using Alis.Core.Ecs.Systems;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    /// The query and mutate sample class
    /// </summary>
    /// <seealso cref="IEcsSample"/>
    internal sealed class QueryAndMutateSample : IEcsSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "query-mutate";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Query And Mutate";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Queries all string components and mutates them through Ref<T>.";

        /// <summary>
        /// Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();

            for (int i = 0; i < 3; i++)
            {
                scene.Create<string, ConsoleText>("Mutable text", new ConsoleText(ConsoleColor.Yellow));
            }

            foreach (RefTuple<string> tuple in scene.Query<With<string>>().Enumerate<string>())
            {
                Ref<string> text = tuple.Item1;
                text.Value += " -> updated by query";
            }

            scene.Update();
        }
    }
}

