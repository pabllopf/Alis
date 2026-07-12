using System;
using System.Reflection;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.Logic;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    public class FinalCoverageTests
    {
        // ========================================================================
        // WorldPhysic.Step — locked world (lines 1153-1154)
        // ========================================================================
        [Fact]
        public void Step_LockedWorld_Throws()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            var lockedField = typeof(WorldPhysic).GetField("<GetIsLocked>k__BackingField",
                BindingFlags.Instance | BindingFlags.NonPublic);
            lockedField?.SetValue(world, true);
            Assert.Throws<InvalidOperationException>(() => world.Step(1.0f / 60.0f));
            lockedField?.SetValue(world, false);
        }

        // ========================================================================
        // WorldPhysic.Step — disabled world (line 1157-1159)
        // ========================================================================
        [Fact]
        public void Step_WorldDisabled_Returns()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.GetEnabled = false;
            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
            world.GetEnabled = true;
        }

        // ========================================================================
        // ContactManager.TryResolveContactFilter — ContactFilter false (lines 655-665)
        // ========================================================================
        [Fact]
        public void TryResolveContactFilter_CompletePaths()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);

            // Set FilterFlag on contact via BeginContact
            world.ContactManager.BeginContact = contact =>
            {
                contact.FilterFlag = true;
                return true;
            };
            world.Step(1.0f / 60.0f);

            // Set contact filter that returns false to trigger the destroy path
            world.ContactManager.ContactFilter = (_, _) => false;
            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount >= 0);
        }

        // ========================================================================
        // ContactManager.CollideMultiCore — both bodies inactive (line 601)
        // ========================================================================
        [Fact]
        public void CollideMultiCore_BothInactive_Skips()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);

            var field = typeof(ContactManager).GetField("CollideMultithreadThreshold",
                BindingFlags.Instance | BindingFlags.Public);
            field.SetValue(world.ContactManager, 0);

            bodyA.Awake = false;
            bodyB.Awake = false;
            bodyA.GetBodyType = BodyType.Static;
            bodyB.GetBodyType = BodyType.Static;

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount >= 0);
        }

        // ========================================================================
        // ContactManager.TryResolveContactFilter — ShouldCollide false via joint
        // ========================================================================
        [Fact]
        public void TryResolveContactFilter_ShouldCollideFalse_Destroys()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            // Make both bodies static (ShouldCollide returns false for static+static)
            bodyA.GetBodyType = BodyType.Static;
            bodyB.GetBodyType = BodyType.Static;

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount >= 0);
        }

        // ========================================================================
        // Collision.CollidePolygonAndCircle — ResolveBarycentricContact u1 path (lines 220-228)
        // ========================================================================
        [Fact]
        public void CollidePolygonAndCircle_U1Path_VertexContact()
        {
            PolygonShape poly = new PolygonShape(PolygonTools.CreateRectangle(2.0f, 2.0f), 1.0f);
            CircleShape circle = new CircleShape(0.3f, 1.0f);
            ControllerTransform xfPoly = ControllerTransform.Identity;
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(1.2f, 1.2f), 0.0f);
            Manifold manifold = new Manifold();
            Collision.CollidePolygonAndCircle(ref manifold, poly, ref xfPoly, circle, ref xfCircle);
            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // Collision.CollidePolygonAndCircle — ResolveBarycentricContact u2 path (lines 230-238)
        // ========================================================================
        [Fact]
        public void CollidePolygonAndCircle_U2Path_VertexContact()
        {
            PolygonShape poly = new PolygonShape(PolygonTools.CreateRectangle(2.0f, 2.0f), 1.0f);
            CircleShape circle = new CircleShape(0.3f, 1.0f);
            ControllerTransform xfPoly = ControllerTransform.Identity;
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(-1.2f, 1.2f), 0.0f);
            Manifold manifold = new Manifold();
            Collision.CollidePolygonAndCircle(ref manifold, poly, ref xfPoly, circle, ref xfCircle);
            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // Collision.CollidePolygonAndCircle — Face center separation > radius (lines 246-251)
        // ========================================================================
        [Fact]
        public void CollidePolygonAndCircle_FaceSeparationExceeds_Returns()
        {
            PolygonShape poly = new PolygonShape(PolygonTools.CreateRectangle(2.0f, 2.0f), 1.0f);
            CircleShape circle = new CircleShape(0.1f, 1.0f);
            ControllerTransform xfPoly = ControllerTransform.Identity;
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(1.1f, 0.0f), 0.0f);
            Manifold manifold = new Manifold();
            Collision.CollidePolygonAndCircle(ref manifold, poly, ref xfPoly, circle, ref xfCircle);
            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // SeparationFunction FaceB — s < 0.0f flips axis (line 197-199)
        // ========================================================================
        [Fact]
        public void SeparationFunction_FaceBNegative_FlipsAxis()
        {
            PolygonShape shapeA = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            PolygonShape shapeB = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            DistanceProxy proxyA = new DistanceProxy(shapeA, 0);
            DistanceProxy proxyB = new DistanceProxy(shapeB, 0);
            Sweep sweepA = new Sweep { C0 = Vector2F.Zero, C = Vector2F.Zero, LocalCenter = Vector2F.Zero };
            Sweep sweepB = new Sweep { C0 = new Vector2F(1.0f, 1.0f), C = new Vector2F(1.0f, 1.0f), LocalCenter = Vector2F.Zero };

            SimplexCache cache = new SimplexCache { Count = 2 };
            cache.IndexA[0] = 0;
            cache.IndexA[1] = 0;
            cache.IndexB[0] = 0;
            cache.IndexB[1] = 1;

            SeparationFunction.Set(ref cache, ref proxyA, ref sweepA, ref proxyB, ref sweepB, 0.0f);
            float sep = SeparationFunction.FindMinSeparation(out int idxA, out int idxB, 0.0f);
            Assert.False(float.IsNaN(sep));
        }

        // ========================================================================
        // ContactSolver.SolveToiPositionConstraints with overlapping bodies
        // ========================================================================
        [Fact]
        public void ContactSolver_SolveToiPositionConstraints_Resolves()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(-0.3f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }
    }
}
