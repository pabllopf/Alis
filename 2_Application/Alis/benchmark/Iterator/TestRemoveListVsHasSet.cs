// 

using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.Physics
{
    /// <summary>
    /// The test remove list vs hasset class
    /// </summary>
    public class TestRemoveListVsHasSet
    {
        /// <summary>
        /// The world
        /// </summary>
        private World world;
        /// <summary>
        /// The body set
        /// </summary>
        private HashSet<Body> bodySet;
        
        /// <summary>
        /// Gets or sets the value of the n
        /// </summary>
        [Params(10, 100, 1000)]
        // ReSharper disable once MemberCanBePrivate.Global
        public int N { get; set; }
        
        /// <summary>
        /// Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            world = new World();
            bodySet = new HashSet<Body>();
        
            for (int i = 0; i < N; i++)
            {
                Body body = new Body { Id = i };
                world.Bodies.Add(body);
                bodySet.Add(body);
            }
        }
        
        /// <summary>
        /// Removes the body from list
        /// </summary>
        [Benchmark]
        public void RemoveBodyFromList()
        {
            for (int i = 0; i < N; i++)
            {
                world.RemoveBody(world.Bodies[i]);
            }
        }
        
        /// <summary>
        /// Removes the body from set
        /// </summary>
        [Benchmark]
        public void RemoveBodyFromSet()
        {
            for (int i = 0; i < N; i++)
            {
                bodySet.Remove(world.Bodies[i]);
            }
        }


        /// <summary>
        /// The world class
        /// </summary>
        private class World
        {
            /// <summary>
            /// Gets or sets the value of the bodies
            /// </summary>
            public List<Body> Bodies { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="World"/> class
            /// </summary>
            public World()
            {
                Bodies = new List<Body>();
            }

            /// <summary>
            /// Removes the body using the specified body
            /// </summary>
            /// <param name="body">The body</param>
            public void RemoveBody(Body body) => Bodies.Remove(body);
        }

        /// <summary>
        /// The body class
        /// </summary>
        private class Body
        {
            /// <summary>
            /// Gets or sets the value of the id
            /// </summary>
            public int Id { get; set; }
        }

    }
}
    


