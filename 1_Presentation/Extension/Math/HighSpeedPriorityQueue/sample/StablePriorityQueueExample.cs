

using Alis.Core.Aspect.Logging;

namespace Alis.Extension.Math.HighSpeedPriorityQueue.Sample
{
    /// <summary>
    ///     Demonstrates FIFO behavior for equal priorities in StablePriorityQueue.
    /// </summary>
    public static class StablePriorityQueueExample
    {
        /// <summary>
        ///     Runs the example.
        /// </summary>
        public static void RunExample()
        {
            StablePriorityQueue<Job> queue = new StablePriorityQueue<Job>(10);

            Job first = new Job("first", "Generate thumbnails");
            Job second = new Job("second", "Upload metadata");
            Job third = new Job("third", "Send notifications");

            queue.Enqueue(first, 5f);
            queue.Enqueue(second, 5f);
            queue.Enqueue(third, 5f);

            while (queue.Count > 0)
            {
                Job next = queue.Dequeue();
                Logger.Info($"[{next.Id}] {next.Description}");
            }
        }

        /// <summary>
        ///     Simple payload node used by this sample.
        /// </summary>
        public sealed class Job : StablePriorityQueueNode
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Job"/> class
            /// </summary>
            /// <param name="id">The id</param>
            /// <param name="description">The description</param>
            public Job(string id, string description)
            {
                Id = id;
                Description = description;
            }

            /// <summary>
            /// Gets the value of the id
            /// </summary>
            public string Id { get; }

            /// <summary>
            /// Gets the value of the description
            /// </summary>
            public string Description { get; }
        }
    }
}

