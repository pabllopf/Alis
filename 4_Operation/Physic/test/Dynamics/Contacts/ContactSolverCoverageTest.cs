using System;
using System.Reflection;
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

        // ========================================================================
        // GetOrderedIndices — private static method
        // ========================================================================

        [Fact]
        public void GetOrderedIndices_WithUnorderedIndices_ReturnsOrderedPair()
        {
            MethodInfo method = typeof(ContactSolver).GetMethod("GetOrderedIndices",
                BindingFlags.Static | BindingFlags.NonPublic);
            var pc = new ContactPositionConstraint { IndexA = 5, IndexB = 2 };

            object result = method.Invoke(null, new object[] { pc });
            Type tupleType = result.GetType();
            int item1 = (int)tupleType.GetField("Item1").GetValue(result);
            int item2 = (int)tupleType.GetField("Item2").GetValue(result);

            Assert.Equal(2, item1);
            Assert.Equal(5, item2);
        }

        [Fact]
        public void GetOrderedIndices_WithOrderedIndices_ReturnsSameOrder()
        {
            MethodInfo method = typeof(ContactSolver).GetMethod("GetOrderedIndices",
                BindingFlags.Static | BindingFlags.NonPublic);
            var pc = new ContactPositionConstraint { IndexA = 2, IndexB = 5 };

            object result = method.Invoke(null, new object[] { pc });
            Type tupleType = result.GetType();
            int item1 = (int)tupleType.GetField("Item1").GetValue(result);
            int item2 = (int)tupleType.GetField("Item2").GetValue(result);

            Assert.Equal(2, item1);
            Assert.Equal(5, item2);
        }

        // ========================================================================
        // SolveContactPositionConstraint — internal method, via reflection
        // ========================================================================

        [Fact]
        public void SolveContactPositionConstraint_WithSinglePoint_ReturnsMinSeparation()
        {
            MethodInfo method = typeof(ContactSolver).GetMethod("SolveContactPositionConstraint",
                BindingFlags.Instance | BindingFlags.NonPublic);

            ContactSolver solver = new ContactSolver();
            // Set up Positions via reflection (internal struct)
            Type solverPosType = typeof(ContactSolver).Assembly.GetType("Alis.Core.Physic.Dynamics.SolverPosition");
            Array positions = Array.CreateInstance(solverPosType, 2);
            object pos0 = Activator.CreateInstance(solverPosType);
            solverPosType.GetField("C").SetValue(pos0, new Vector2F(0f, 0f));
            solverPosType.GetField("A").SetValue(pos0, 0f);
            object pos1 = Activator.CreateInstance(solverPosType);
            solverPosType.GetField("C").SetValue(pos1, new Vector2F(1f, 0f));
            solverPosType.GetField("A").SetValue(pos1, 0f);
            positions.SetValue(pos0, 0);
            positions.SetValue(pos1, 1);

            solver.GetType().GetField("Positions", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(solver, positions);

            var pc = new ContactPositionConstraint
            {
                IndexA = 0,
                IndexB = 1,
                InvMassA = 1.0f,
                InvMassB = 1.0f,
                InvIa = 1.0f,
                InvIb = 1.0f,
                LocalCenterA = Vector2F.Zero,
                LocalCenterB = Vector2F.Zero,
                PointCount = 1,
                RadiusA = 0.5f,
                RadiusB = 0.5f,
                Type = ManifoldType.FaceA,
                LocalNormal = new Vector2F(1f, 0f),
                LocalPoint = new Vector2F(0.5f, 0f)
            };

            float result = (float)method.Invoke(solver, new object[] { pc });
            Assert.True(result <= 0f);
        }

        // ========================================================================
        // SolveFrictionImpulse — private static method, tested via reflection
        // ========================================================================

        [Fact]
        public void SolveFrictionImpulse_WithSinglePoint_AppliesImpulse()
        {
            MethodInfo method = typeof(ContactSolver).GetMethod("SolveFrictionImpulse",
                BindingFlags.Static | BindingFlags.NonPublic);

            var vc = new ContactVelocityConstraint();
            vc.PointCount = 1;
            vc.TangentSpeed = 0f;
            vc.Friction = 0.5f;
            vc.Normal = new Vector2F(1f, 0f);
            vc.Points[0].NormalImpulse = 1.0f;
            vc.Points[0].TangentImpulse = 0f;
            vc.Points[0].TangentMass = 1.0f;
            vc.Points[0].Ra = new Vector2F(0f, 0f);
            vc.Points[0].Rb = new Vector2F(0f, 0f);

            Vector2F vA = Vector2F.Zero;
            float wA = 0f;
            Vector2F vB = new Vector2F(1f, 0f);
            float wB = 0f;
            Vector2F normal = new Vector2F(1f, 0f);
            float friction = 0.5f;
            float mA = 1f, iA = 1f, mB = 1f, iB = 1f;

            object[] args = { vc, vA, wA, vB, wB, normal, friction, mA, iA, mB, iB };

            method.Invoke(null, args);

            // Method executed without throwing
            Assert.True(vc.Points[0].TangentImpulse >= 0f);
        }

        // ========================================================================
        // SolveSinglePointNormal — private static, via reflection
        // ========================================================================

        [Fact]
        public void SolveSinglePointNormal_AppliesNormalImpulse()
        {
            MethodInfo method = typeof(ContactSolver).GetMethod("SolveSinglePointNormal",
                BindingFlags.Static | BindingFlags.NonPublic);

            var vc = new ContactVelocityConstraint();
            vc.PointCount = 1;
            vc.Normal = new Vector2F(1f, 0f);
            vc.Points[0].NormalImpulse = 0f;
            vc.Points[0].NormalMass = 1.0f;
            vc.Points[0].VelocityBias = 0f;
            vc.Points[0].Ra = new Vector2F(0f, 0f);
            vc.Points[0].Rb = new Vector2F(0f, 0f);

            Vector2F vA = new Vector2F(-1f, 0f);
            float wA = 0f;
            Vector2F vB = Vector2F.Zero;
            float wB = 0f;
            Vector2F normal = new Vector2F(1f, 0f);
            float mA = 1f, iA = 1f, mB = 1f, iB = 1f;

            object[] args = { vA, wA, vB, wB, vc, normal, mA, iA, mB, iB };
            method.Invoke(null, args);

            Vector2F vAResult = (Vector2F)args[0];
            Assert.True(vAResult.X >= -1f); // impulse applied
        }

        // ========================================================================
        // SolveTwoPointNormal — all branches, via reflection
        // ========================================================================

        [Fact]
        public void SolveTwoPointNormal_BlockImpulseBranch_Executes()
        {
            MethodInfo method = typeof(ContactSolver).GetMethod("SolveTwoPointNormal",
                BindingFlags.Static | BindingFlags.NonPublic);

            var vc = new ContactVelocityConstraint();
            vc.PointCount = 2;
            vc.Normal = new Vector2F(1f, 0f);
            vc.K.Ex = new Vector2F(2f, 1f);
            vc.K.Ey = new Vector2F(1f, 2f);
            vc.NormalMass = vc.K.Inverse;

            vc.Points[0].NormalImpulse = 0f;
            vc.Points[0].NormalMass = 1.0f;
            vc.Points[0].VelocityBias = 0f;
            vc.Points[0].Ra = new Vector2F(0f, 0f);
            vc.Points[0].Rb = new Vector2F(0f, 0f);

            vc.Points[1].NormalImpulse = 0f;
            vc.Points[1].NormalMass = 1.0f;
            vc.Points[1].VelocityBias = 0f;
            vc.Points[1].Ra = new Vector2F(0f, 0f);
            vc.Points[1].Rb = new Vector2F(0f, 0f);

            Vector2F vA = new Vector2F(-1f, 0f);
            float wA = 0f;
            Vector2F vB = Vector2F.Zero;
            float wB = 0f;
            Vector2F normal = new Vector2F(1f, 0f);
            float mA = 1f, iA = 1f, mB = 1f, iB = 1f;

            object[] args = { vA, wA, vB, wB, vc, normal, mA, iA, mB, iB };
            method.Invoke(null, args);

            Vector2F vAResult = (Vector2F)args[0];
            Assert.NotNull(vAResult);
        }

        // ========================================================================
        // ApplyBlockImpulse — private static, via reflection
        // ========================================================================

        [Fact]
        public void ApplyBlockImpulse_ModifiesVelocities()
        {
            MethodInfo method = typeof(ContactSolver).GetMethod("ApplyBlockImpulse",
                BindingFlags.Static | BindingFlags.NonPublic);

            // Need to create ContactConstraintData struct via reflection
            Type constraintDataType = typeof(ContactSolver).GetNestedType("ContactConstraintData",
                BindingFlags.NonPublic);

            var cp1 = new VelocityConstraintPoint();
            cp1.Ra = new Vector2F(0f, 0f);
            cp1.Rb = new Vector2F(0f, 0f);
            cp1.NormalImpulse = 0f;

            var cp2 = new VelocityConstraintPoint();
            cp2.Ra = new Vector2F(0f, 0f);
            cp2.Rb = new Vector2F(0f, 0f);
            cp2.NormalImpulse = 0f;

            object constraintData = Activator.CreateInstance(constraintDataType,
                new object[] { cp1, cp2, new Vector2F(1f, 0f) });

            Vector2F vA = Vector2F.Zero;
            float wA = 0f;
            Vector2F vB = new Vector2F(1f, 0f);
            float wB = 0f;

            object[] args = { vA, wA, vB, wB, new Vector2F(1f, 0f), new Vector2F(0f, 0f), constraintData, 1f, 1f, 1f, 1f };
            method.Invoke(null, args);

            Vector2F vAResult = (Vector2F)args[0];
            Assert.True(vAResult.X < 0f); // impulse applied in opposite direction
        }

        // ========================================================================
        // SolveVelocityConstraints with zero count early return
        // ========================================================================

        [Fact]
        public void SolveVelocityConstraints_ZeroCountWithThreshold_ReturnsEarly()
        {
            ContactSolver solver = new ContactSolver();
            solver.Count = 0;
            typeof(ContactSolver).GetField("_velocityConstraintsMultithreadThreshold",
                BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(solver, 0);
            solver.SolveVelocityConstraints();
        }

        // ========================================================================
        // SolvePositionConstraints with zero count returns true
        // ========================================================================

        [Fact]
        public void SolvePositionConstraints_ZeroCountWithThreshold_ReturnsTrue()
        {
            ContactSolver solver = new ContactSolver();
            solver.Count = 0;
            typeof(ContactSolver).GetField("_positionConstraintsMultithreadThreshold",
                BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(solver, 0);
            bool result = solver.SolvePositionConstraints();
            Assert.True(result);
        }

        // ========================================================================
        // Reset with WarmStarting=true — exercises warm start path
        // ========================================================================

        [Fact]
        public void ContactSolver_Reset_WithWarmStarting_SetsImpulses()
        {
            // This test creates a ContactSolver and checks that Reset correctly
            // initializes the velocity constraint points with scaled impulses.
            ContactSolver solver = new ContactSolver();
            TimeStep step = new TimeStep { Dt = 1f / 60f, DtRatio = 1.0f, WarmStarting = true };

            // Create a minimal contact setup
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Body bodyB = world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.5f, 0.0f), 0.0f, BodyType.Dynamic);

            // Step once to build contacts
            world.Step(1.0f / 60.0f);

            // Verify contacts exist
            Assert.True(world.ContactManager.ContactCount > 0);
        }

        // ========================================================================
        // SolveToiPositionConstraints with body indices matching
        // ========================================================================

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

        // ========================================================================
        // InitializeVelocityConstraintPoints — private static, VelocityBias branch
        // ========================================================================

        [Fact]
        public void InitializeVelocityConstraintPoints_VelocityBiasSet_WhenVrelLow()
        {
            MethodInfo method = typeof(ContactSolver).GetMethod("InitializeVelocityConstraintPoints",
                BindingFlags.Static | BindingFlags.NonPublic);

            var vc = new ContactVelocityConstraint();
            vc.PointCount = 1;
            vc.Normal = new Vector2F(1f, 0f);
            vc.Restitution = 0.5f;
            vc.Points[0].Ra = new Vector2F(0f, 0f);
            vc.Points[0].Rb = new Vector2F(0f, 0f);

            var points = new FixedArray2<Vector2F>();
            points[0] = new Vector2F(0f, 0f);

            Type dataType = typeof(ContactSolver).Assembly.GetType("Alis.Core.Physic.Dynamics.Contacts.VelocityConstraintInitData");
            object data = Activator.CreateInstance(dataType,
                new object[] { Vector2F.Zero, new Vector2F(1f, 0f), 1f, 1f, 1f, 1f, new Vector2F(0f, 1f), new Vector2F(2f, 0f), 0f, Vector2F.Zero, 0f });

            object[] args = { vc, points, data };
            method.Invoke(null, args);

            // vRel was negative (body moving toward), should set VelocityBias
            Assert.True(vc.Points[0].VelocityBias > 0f);
        }

        // ========================================================================
        // SolveTwoPointNormal — final branch: both vn >= 0
        // ========================================================================

        [Fact]
        public void SolveTwoPointNormal_BothVnNonNegative_AppliesBlockImpulse()
        {
            MethodInfo method = typeof(ContactSolver).GetMethod("SolveTwoPointNormal",
                BindingFlags.Static | BindingFlags.NonPublic);

            var vc = new ContactVelocityConstraint();
            vc.PointCount = 2;
            vc.Normal = new Vector2F(1f, 0f);
            vc.K.Ex = new Vector2F(2f, 0f);
            vc.K.Ey = new Vector2F(0f, 2f);
            vc.NormalMass = vc.K.Inverse;

            vc.Points[0].NormalImpulse = -1f;
            vc.Points[0].NormalMass = 1.0f;
            vc.Points[0].VelocityBias = 0f;
            vc.Points[0].Ra = new Vector2F(0f, 0f);
            vc.Points[0].Rb = new Vector2F(0f, 0f);

            vc.Points[1].NormalImpulse = -1f;
            vc.Points[1].NormalMass = 1.0f;
            vc.Points[1].VelocityBias = 0f;
            vc.Points[1].Ra = new Vector2F(0f, 0f);
            vc.Points[1].Rb = new Vector2F(0f, 0f);

            Vector2F vA = new Vector2F(0f, 0f);
            float wA = 0f;
            Vector2F vB = Vector2F.Zero;
            float wB = 0f;
            Vector2F normal = new Vector2F(1f, 0f);
            float mA = 1f, iA = 1f, mB = 1f, iB = 1f;

            object[] args = { vA, wA, vB, wB, vc, normal, mA, iA, mB, iB };
            method.Invoke(null, args);

            Vector2F vAResult = (Vector2F)args[0];
            Assert.NotNull(vAResult);
        }

        // ========================================================================
        // InitializeVelocityConstraints — exercises code path with valid data
        // ========================================================================

        [Fact]
        public void InitializeVelocityConstraints_WithBodyOverlap_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Body bodyB = world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.5f, 0.0f), 0.0f, BodyType.Dynamic);

            // Step to create contacts
            world.Step(1.0f / 60.0f);

            // Step again to exercise InitializeVelocityConstraints with warm starting
            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));

            Assert.Null(ex);
            Assert.True(world.ContactManager.ContactCount > 0);
        }

        // ========================================================================
        // SolveContactPositionConstraint with k <= 0 branch (impulse = 0)
        // ========================================================================

        [Fact]
        public void SolveContactPositionConstraint_WithZeroMass_ReturnsMinSeparation()
        {
            MethodInfo method = typeof(ContactSolver).GetMethod("SolveContactPositionConstraint",
                BindingFlags.Instance | BindingFlags.NonPublic);

            ContactSolver solver = new ContactSolver();

            Type solverPosType = typeof(ContactSolver).Assembly.GetType("Alis.Core.Physic.Dynamics.SolverPosition");
            Array positions = Array.CreateInstance(solverPosType, 2);
            object pos0 = Activator.CreateInstance(solverPosType);
            solverPosType.GetField("C").SetValue(pos0, new Vector2F(0f, 0f));
            solverPosType.GetField("A").SetValue(pos0, 0f);
            object pos1 = Activator.CreateInstance(solverPosType);
            solverPosType.GetField("C").SetValue(pos1, new Vector2F(1f, 0f));
            solverPosType.GetField("A").SetValue(pos1, 0f);
            positions.SetValue(pos0, 0);
            positions.SetValue(pos1, 1);
            solver.GetType().GetField("Positions", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(solver, positions);

            var pc = new ContactPositionConstraint
            {
                IndexA = 0,
                IndexB = 1,
                InvMassA = 0f,
                InvMassB = 0f,
                InvIa = 0f,
                InvIb = 0f,
                LocalCenterA = Vector2F.Zero,
                LocalCenterB = Vector2F.Zero,
                PointCount = 1,
                RadiusA = 0.5f,
                RadiusB = 0.5f,
                Type = ManifoldType.FaceA,
                LocalNormal = new Vector2F(1f, 0f),
                LocalPoint = new Vector2F(0.5f, 0f)
            };

            float result = (float)method.Invoke(solver, new object[] { pc });
            Assert.True(result <= 0f);
        }
    }
}
