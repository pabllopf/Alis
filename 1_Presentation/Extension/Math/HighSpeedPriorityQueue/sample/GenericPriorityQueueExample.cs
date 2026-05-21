

using Alis.Core.Aspect.Logging;
using System;

namespace Alis.Extension.Math.HighSpeedPriorityQueue.Sample
{
    /// <summary>
    ///     Demonstrates GenericPriorityQueue with a custom comparer and non-float priorities.
    /// </summary>
    public static class GenericPriorityQueueExample
    {
        /// <summary>
        ///     Runs the example.
        /// </summary>
        public static void RunExample()
        {
            GenericPriorityQueue<BuildTask, DateTime> queue =
                new GenericPriorityQueue<BuildTask, DateTime>(10, (left, right) => left.CompareTo(right));

            DateTime now = DateTime.UtcNow;
            queue.Enqueue(new BuildTask("Compile gameplay"), now.AddMinutes(20));
            queue.Enqueue(new BuildTask("Generate docs"), now.AddMinutes(10));
            queue.Enqueue(new BuildTask("Run tests"), now.AddMinutes(10));

            while (queue.Count > 0)
            {
                BuildTask next = queue.Dequeue();
                Logger.Info(next.Name);
            }
        }

        /// <summary>
        ///     Simple payload node used by this sample.
        /// </summary>
        public sealed class BuildTask : GenericPriorityQueueNode<DateTime>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="BuildTask"/> class
            /// </summary>
            /// <param name="name">The name</param>
            public BuildTask(string name) => Name = name;

            /// <summary>
            /// Gets the value of the name
            /// </summary>
            public string Name { get; }
        }
    }
}

