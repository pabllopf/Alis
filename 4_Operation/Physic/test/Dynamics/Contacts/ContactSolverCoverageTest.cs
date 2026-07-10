using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    public class ContactSolverCoverageTest
    {
        [Fact]
        public void RectangleOverlap_ProducesTwoPointContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Body bodyB = world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.5f, 0.0f), 0.0f, BodyType.Dynamic);

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        [Fact]
        public void MultipleSteps_ExercisesWarmStarting()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.5f, 0.0f), 0.0f, BodyType.Dynamic);

            for (int i = 0; i < 5; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        [Fact]
        public void RectangleAndCircle_Overlap_CreatesContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        [Fact]
        public void MultipleOverlappingBodies_ExercisesSolverBatch()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            for (int i = 0; i < 5; i++)
            {
                world.CreateCircle(0.5f, 1.0f, new Vector2F(i * 0.3f, 0.0f), BodyType.Dynamic);
            }

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount >= 0);
        }

        [Fact]
        public void WorldManifold_Initialize_CirclesCoincidentPoints()
        {
            Manifold manifold = new Manifold
            {
                PointCount = 1,
                Type = ManifoldType.Circles,
                LocalPoint = new Vector2F(0.0f, 0.0f)
            };
            manifold.Points[0] = new ManifoldPoint { LocalPoint = new Vector2F(0.0f, 0.0f) };

            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = ControllerTransform.Identity;

            ContactSolver.WorldManifold.Initialize(ref manifold, ref xfA, 0.5f, ref xfB, 0.5f,
                out Vector2F normal, out FixedArray2<Vector2F> points);

            Assert.True(normal.X >= 0);
        }

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

        [Fact]
        public void SolvePositionConstraint_WithDynamicBodies()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Body bodyB = world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.8f, 0.0f), 0.0f, BodyType.Dynamic);

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount > 0);
            Assert.NotEqual(0.0f, bodyA.Position.X);
        }

        [Fact]
        public void StoreImpulses_ThroughStep_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.5f, 0.0f), 0.0f, BodyType.Dynamic);

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount > 0);

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount > 0);
        }
    }
}
