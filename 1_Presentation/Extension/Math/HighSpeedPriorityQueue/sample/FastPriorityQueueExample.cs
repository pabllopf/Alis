using System;

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
        private const int MAX_USERS_IN_QUEUE = 10;

        /// <summary>
        ///     Runs the example
        /// </summary>
        public static void RunExample()
        {
            //First, we create the priority queue.  We'll specify a max of 10 users in the queue
            FastPriorityQueue<User> priorityQueue = new FastPriorityQueue<User>(MAX_USERS_IN_QUEUE);

            //Next, we'll create 5 users to enqueue
            User user1 = new User("1 - Jason");
            User user2 = new User("2 - Tyler");
            User user3 = new User("3 - Valerie");
            User user4 = new User("4 - Joseph");
            User user42 = new User("4 - Ryan");

            //Now, let's add them all to the queue (in some arbitrary order)!
            priorityQueue.Enqueue(user4, 4);
            priorityQueue.Enqueue(user2, 0); //Note: Priority = 0 right now!
            priorityQueue.Enqueue(user1, 1);
            priorityQueue.Enqueue(user42, 4);
            priorityQueue.Enqueue(user3, 3);

            //Change user2's priority to 2.  Since user2 is already in the priority queue, we call UpdatePriority() to do this
            priorityQueue.UpdatePriority(user2, 2);

            //Finally, we'll dequeue all the users and print out their names
            while (priorityQueue.Count != 0)
            {
                User nextUser = priorityQueue.Dequeue();
                Console.WriteLine(nextUser.Name);
            }

            //Output:
            //1 - Jason
            //2 - Tyler
            //3 - Valerie
            //4 - Joseph
            //4 - Ryan

            //Notice that when two users with the same priority were enqueued, they were dequeued in the same order that they were enqueued.
        }

        //The class to be enqueued.
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