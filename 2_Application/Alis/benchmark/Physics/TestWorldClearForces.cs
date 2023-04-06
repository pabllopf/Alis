using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alis.Benchmark.Physics
{
    /// <summary>
    /// The clear forces benchmark class
    /// </summary>
    public class TestWorldClearForces
    {
        /// <summary>
        /// The world
        /// </summary>
        private World world;

        /// <summary>
        /// The 
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnassignedField.Global
        [Params(10, 100, 1000, 1_000_000)] public int N;

        /// <summary>
        /// Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            world = new World();
            for (int i = 0; i < N; i++)
            {
                world.Bodies.Add(new Body());
            }
        }

        /// <summary>
        /// Originals this instance
        /// </summary>
        [Benchmark]
        public void ClearForcesOriginal() => world.ClearForcesOriginal();
        
        /// <summary>
        /// Optimize this instance
        /// </summary>
        [Benchmark]
        public void ClearForcesOptimizedWithCopyTemp() => world.ClearForcesOptimizedWithCopyTemp();
        
        /// <summary>
        /// Optimize this instance
        /// </summary>
        [Benchmark]
        public void ClearForcesOptimizedWithoutCopyTemp() => world.ClearForcesOptimizedWithoutCopyTemp();
        
        /// <summary>
        /// Optimize this instance
        /// </summary>
        [Benchmark]
        public void ClearForcesOptimizedWithParallel() => world.ClearForcesOptimizedWithParallel();

        
        /// <summary>
        /// The body class
        /// </summary>
        private class Body
        {
            /// <summary>
            /// Clears the forces
            /// </summary>
            public void ClearForces() { }
        }

        /// <summary>
        /// The world class
        /// </summary>
        private class World
        {
            /// <summary>
            /// Gets the value of the bodies
            /// </summary>
            public List<Body> Bodies { get; } = new List<Body>();

            /// <summary>
            /// Clears the forces original
            /// </summary>
            internal void ClearForcesOriginal() => Bodies.ForEach(i => i.ClearForces());
            
            /// <summary>
            /// Clears the forces original
            /// </summary>
            internal void ClearForcesOptimizedWithParallel() => Parallel.For(0, Bodies.Count, i => Bodies[i].ClearForces());

            /// <summary>
            /// Clears the forces optimized
            /// </summary>
            internal void ClearForcesOptimizedWithCopyTemp()
            {
                List<Body> bodies = Bodies;
                for (int i = 0; i < bodies.Count; i++)
                {
                    bodies[i].ClearForces();
                }
            }
            
            /// <summary>
            /// Clears the forces optimized v 2
            /// </summary>
            internal void ClearForcesOptimizedWithoutCopyTemp()
            {
                for (int i = 0; i < Bodies.Count; i++)
                {
                    Bodies[i].ClearForces();
                }
            }
        }
    }
}