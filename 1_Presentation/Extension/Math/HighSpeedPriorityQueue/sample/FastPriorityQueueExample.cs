

using Alis.Core.Aspect.Logging;

namespace Alis.Extension.Math.HighSpeedPriorityQueue.Sample
{
    /// <summary>
    ///     The fast priority queue example class
    /// </summary>
    public static class FastPriorityQueueExample
    {
        /// <summary>
        ///     The max users in queue
        /// </summary>
        private const int MaxUsersInQueue = 10;

        /// <summary>
        ///     Runs the example
        /// </summary>
        public static void RunExample()
        {
            FastPriorityQueue<User> priorityQueue = new FastPriorityQueue<User>(MaxUsersInQueue);

            User user1 = new User("1 - Jason");
            User user2 = new User("2 - Tyler");
            User user3 = new User("3 - Valerie");
            User user4 = new User("4 - Joseph");
            User user42 = new User("4 - Ryan");

            priorityQueue.Enqueue(user4, 4);
            priorityQueue.Enqueue(user2, 0); //Note: Priority = 0 right now!
            priorityQueue.Enqueue(user1, 1);
            priorityQueue.Enqueue(user42, 4);
            priorityQueue.Enqueue(user3, 3);

            priorityQueue.UpdatePriority(user2, 2);

            while (priorityQueue.Count != 0)
            {
                User nextUser = priorityQueue.Dequeue();
                Logger.Info(nextUser.Name);
            }

            //4 - Ryan

        }

        /// <summary>
        ///     The user class
        /// </summary>
        /// <seealso cref="FastPriorityQueueNode" />
        public class User : FastPriorityQueueNode
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="User" /> class
            /// </summary>
            /// <param name="name">The name</param>
            public User(string name) => Name = name;

            /// <summary>
            ///     Gets or sets the value of the name
            /// </summary>
            public string Name { get; }
        }
    }
}