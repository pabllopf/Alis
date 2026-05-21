

using Alis.Core.Aspect.Logging;

namespace Alis.Extension.Math.HighSpeedPriorityQueue.Sample
{
    /// <summary>
    ///     The simple priority queue example class
    /// </summary>
    public static class SimplePriorityQueueExample
    {
        /// <summary>
        ///     Runs the example
        /// </summary>
        public static void RunExample()
        {
            SimplePriorityQueue<string> priorityQueue = new SimplePriorityQueue<string>();

            priorityQueue.Enqueue("4 - Joseph", 4);
            priorityQueue.Enqueue("2 - Tyler", 0); //Note: Priority = 0 right now!
            priorityQueue.Enqueue("1 - Jason", 1);
            priorityQueue.Enqueue("4 - Ryan", 4);
            priorityQueue.Enqueue("3 - Valerie", 3);

            priorityQueue.UpdatePriority("2 - Tyler", 2);

            while (priorityQueue.Count != 0)
            {
                string nextUser = priorityQueue.Dequeue();
                Logger.Info(nextUser);
            }

            //4 - Ryan

        }
    }
}