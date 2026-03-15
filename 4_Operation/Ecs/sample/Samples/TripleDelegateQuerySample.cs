using System;
using Alis.Core.Ecs.Systems;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    /// The triple delegate query sample class
    /// </summary>
    /// <seealso cref="IEcsSample"/>
    internal sealed class TripleDelegateQuerySample : IEcsSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "query-triple-delegate";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Triple Delegate Query";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Applies Delegate<T1,T2,T3> over entities with three components.";

        /// <summary>
        /// Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();

            scene.Create(1, 2f, 3d);
            scene.Create(10, 5f, 2d);

            scene.Query<With<int>, With<float>, With<double>>().Delegate((ref int a, ref float b, ref double c) =>
            {
                a += 1;
                b *= 2;
                c -= 1;
            });

            foreach (RefTuple<int, float, double> tuple in scene.Query<With<int>, With<float>, With<double>>().Enumerate<int, float, double>())
            {
                Console.WriteLine($"Values -> int={tuple.Item1.Value}, float={tuple.Item2.Value}, double={tuple.Item3.Value}");
            }
        }
    }
}

