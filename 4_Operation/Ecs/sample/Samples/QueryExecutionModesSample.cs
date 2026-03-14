using System;
using Alis.Core.Ecs.Sample.Components;
using Alis.Core.Ecs.Systems;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    /// The query execution modes sample class
    /// </summary>
    /// <seealso cref="IEcsSample"/>
    internal sealed class QueryExecutionModesSample : IEcsSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "query-modes";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Query Execution Modes";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Compares Delegate and Inline query execution on the same data.";

        /// <summary>
        /// Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();

            for (int i = 0; i < 5; i++)
            {
                scene.Create(i);
            }

            Console.Write("Delegate: ");
            scene.Query<With<int>>().Delegate((ref int x) => Console.Write($"{x++}, "));
            Console.WriteLine();

            Console.Write("Inline:   ");
            scene.Query<With<int>>().Inline<WriteAction, int>(default(WriteAction));
            Console.WriteLine();
        }
    }
}

