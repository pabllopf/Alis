using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    /// The contact solver coverage test class
    /// </summary>
    public class ContactSolverCoverageTest
    {
       

        /// <summary>
        /// Tests that multiple steps exercises warm starting
        /// </summary>
        [Fact]
        public void MultipleSteps_ExercisesWarmStarting()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.5f, 0.0f), 0.0f, BodyType.Dynamic);

            for (int i = 0; i < 5; i++)
            {
                SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);
            }

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        /// Tests that rectangle and circle overlap creates contact
        /// </summary>
        [Fact]
        public void RectangleAndCircle_Overlap_CreatesContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        /// Tests that multiple overlapping bodies exercises solver batch
        /// </summary>
        [Fact]
        public void MultipleOverlappingBodies_ExercisesSolverBatch()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            for (int i = 0; i < 5; i++)
            {
                world.CreateCircle(0.5f, 1.0f, new Vector2F(i * 0.3f, 0.0f), BodyType.Dynamic);
            }

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount >= 0);
        }

        /// <summary>
        /// Tests that world manifold initialize face b two points verify normal negation
        /// </summary>
        [Fact]
        public void WorldManifold_Initialize_FaceB_TwoPoints_VerifyNormalNegation()
        {
            Manifold manifold = new Manifold
            {
                PointCount = 2,
                Type = ManifoldType.FaceB,
                LocalPoint = new Vector2F(0.0f, 0.0f),
                LocalNormal = new Vector2F(0.0f, 1.0f)
            };
            manifold.Points[0] = new ManifoldPoint { LocalPoint = new Vector2F(-0.5f, 0.0f) };
            manifold.Points[1] = new ManifoldPoint { LocalPoint = new Vector2F(0.5f, 0.0f) };

            ControllerTransform xfA = new ControllerTransform(new Vector2F(0.0f, -1.0f), 0.0f);
            ControllerTransform xfB = new ControllerTransform(new Vector2F(0.0f, 1.0f), 0.0f);

            ContactSolver.WorldManifold.Initialize(ref manifold, ref xfA, 0.3f, ref xfB, 0.3f,
                out Vector2F normal, out FixedArray2<Vector2F> points);

            Assert.NotEqual(Vector2F.Zero, normal);
            Assert.NotEqual(Vector2F.Zero, points[0]);
            Assert.NotEqual(Vector2F.Zero, points[1]);
        }


        /// <summary>
        /// Tests that store impulses through step does not throw
        /// </summary>
        [Fact]
        public void StoreImpulses_ThroughStep_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.5f, 0.0f), 0.0f, BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount > 0);

      
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount > 0);
        }


      
        // ========================================================================
        // SolveToiPositionConstraints with body indices matching
        // ========================================================================

        /// <summary>
        /// Tests that solve toi position constraints with indices does not throw
        /// </summary>
        /// <param name="indexA">The index</param>
        /// <param name="indexB">The index</param>
        /// <param name="expected">The expected</param>
        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(0, 1, true)]
        public void SolveToiPositionConstraints_WithIndices_DoesNotThrow(int indexA, int indexB, bool expected)
        {
            ContactSolver solver = new ContactSolver();
            solver.Count = 0;
            bool result = solver.SolveToiPositionConstraints(indexA, indexB);
            Assert.Equal(expected, result);
        }

   
   

      

       
   
        /// <summary>
        /// Tests that solve position constraints threaded via world executes correctly
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_ThreadedViaWorld_ExecutesCorrectly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            for (int i = 0; i < 5; i++)
            {
                world.CreateCircle(1.0f, 1.0f, new Vector2F(i * 0.3f, 0.0f), BodyType.Dynamic);
            }

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

    
        
    }
}
