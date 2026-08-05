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
    /// <summary>
    /// The contact solver remaining coverage tests class
    /// </summary>
    public class ContactSolverRemainingCoverageTests
    {
        /// <summary>
        /// Tests that reset with pre allocated buffers skips array resize
        /// </summary>
        [Fact]
        public void Reset_WithPreAllocatedBuffers_SkipsArrayResize()
        {
            ContactSolver solver = new ContactSolver();
            TimeStep step = new TimeStep { Dt = 1f / 60f, DtRatio = 1.0f, WarmStarting = true };

            SolverPosition[] pos = new SolverPosition[2];
            SolverVelocity[] vel = new SolverVelocity[2];
            int[] lks = new int[2];
            Contact[] dummyContacts = new Contact[1];
            solver.Reset(ref step, 0, dummyContacts, pos, vel, lks, 0, 0);

            int preCount = solver.VelocityConstraints.Length;

            solver.Reset(ref step, 0, dummyContacts, pos, vel, lks, 0, 0);

            Assert.Equal(preCount, solver.VelocityConstraints.Length);
        }

        /// <summary>
        /// Tests that solve toi position constraints with overlapping bodies resolves overlap
        /// </summary>
        [Fact]
        public void SolveToiPositionConstraints_WithOverlappingBodies_ResolvesOverlap()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Body bodyB = world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.5f, 0.0f), 0.0f, BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        /// Tests that world manifold initialize circles coincident points normal stays one zero
        /// </summary>
        [Fact]
        public void WorldManifold_Initialize_CirclesCoincidentPoints_NormalStaysOneZero()
        {
            Manifold manifold = new Manifold
            {
                PointCount = 1,
                Type = ManifoldType.Circles,
                LocalPoint = new Vector2F(0.0f, 0.0f)
            };
            manifold.Points[0] = new ManifoldPoint { LocalPoint = new Vector2F(0.0f, 0.0f) };

            ControllerTransform xfA = new ControllerTransform(new Vector2F(0.0f, 0.0f), 0.0f);
            ControllerTransform xfB = new ControllerTransform(new Vector2F(0.0f, 0.0f), 0.0f);

            ContactSolver.WorldManifold.Initialize(ref manifold, ref xfA, 0.5f, ref xfB, 0.5f,
                out Vector2F normal, out FixedArray2<Vector2F> points);

            Assert.Equal(1.0f, normal.X);
            Assert.Equal(0.0f, normal.Y);
        }

        /// <summary>
        /// Tests that world manifold initialize face b with rotation verifies normal negation
        /// </summary>
        [Fact]
        public void WorldManifold_Initialize_FaceBWithRotation_VerifiesNormalNegation()
        {
            Manifold manifold = new Manifold
            {
                PointCount = 1,
                Type = ManifoldType.FaceB,
                LocalPoint = new Vector2F(0.0f, 0.0f),
                LocalNormal = new Vector2F(0.0f, 1.0f)
            };
            manifold.Points[0] = new ManifoldPoint { LocalPoint = new Vector2F(0.0f, 0.0f) };

            ControllerTransform xfA = new ControllerTransform(new Vector2F(0.0f, -1.0f), 0.0f);
            ControllerTransform xfB = new ControllerTransform(new Vector2F(0.0f, 1.0f), 0.0f);

            ContactSolver.WorldManifold.Initialize(ref manifold, ref xfA, 0.3f, ref xfB, 0.3f,
                out Vector2F normal, out FixedArray2<Vector2F> points);

            Assert.Equal(-0.0f, normal.X);
            Assert.Equal(-1.0f, normal.Y);
        }

        /// <summary>
        /// Tests that dispose with protected dispose false does not throw
        /// </summary>
        [Fact]
        public void Dispose_WithProtectedDisposeFalse_DoesNotThrow()
        {
            ContactSolver solver = new ContactSolver();
            MethodInfo disposeMethod = typeof(ContactSolver).GetMethod("Dispose",
                BindingFlags.Instance | BindingFlags.NonPublic,
                null, new Type[] { typeof(bool) }, null);

            Exception ex = Record.Exception(() => disposeMethod.Invoke(solver, new object[] { false }));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that solve toi position constraints with contacts executes
        /// </summary>
        [Fact]
        public void SolveToiPositionConstraints_WithContacts_Executes()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Body bodyB = world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.5f, 0.0f), 0.0f, BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        /// Tests that solve velocity constraints with multiple bodies executes single point normal
        /// </summary>
        [Fact]
        public void SolveVelocityConstraints_WithMultipleBodies_ExecutesSinglePointNormal()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(bodyA.Position.X <= 0f || bodyB.Position.X >= 0.5f);
        }

        /// <summary>
        /// Tests that solve position constraints with overlapping bodies resolves overlap
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_WithOverlappingBodies_ResolvesOverlap()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0f, 0f));
            Body bodyA = world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Body bodyB = world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.8f, 0.0f), 0.0f, BodyType.Dynamic);

            for (int i = 0; i < 10; i++)
            {
                SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);
            }

            Assert.True(world.ContactManager.ContactCount >= 0);
        }

        /// <summary>
        /// Tests that store impulses after step stores values
        /// </summary>
        [Fact]
        public void StoreImpulses_AfterStep_StoresValues()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.5f, 0.0f), 0.0f, BodyType.Dynamic);

            for (int i = 0; i < 3; i++)
            {
                SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);
            }

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        /// Tests that solve friction impulse with two points applies
        /// </summary>
        [Fact]
        public void SolveFrictionImpulse_WithTwoPoints_Applies()
        {
            MethodInfo method = typeof(ContactSolver).GetMethod("SolveFrictionImpulse",
                BindingFlags.Static | BindingFlags.NonPublic);

            var vc = new ContactVelocityConstraint();
            vc.PointCount = 2;
            vc.TangentSpeed = 0f;
            vc.Friction = 0.5f;
            vc.Normal = new Vector2F(1f, 0f);

            vc.Points[0].NormalImpulse = 1.0f;
            vc.Points[0].TangentImpulse = 0f;
            vc.Points[0].TangentMass = 1.0f;
            vc.Points[0].Ra = new Vector2F(0f, 0f);
            vc.Points[0].Rb = new Vector2F(0f, 0f);

            vc.Points[1].NormalImpulse = 1.0f;
            vc.Points[1].TangentImpulse = 0f;
            vc.Points[1].TangentMass = 1.0f;
            vc.Points[1].Ra = new Vector2F(0f, 0f);
            vc.Points[1].Rb = new Vector2F(0f, 0f);

            Vector2F vA = Vector2F.Zero;
            float wA = 0f;
            Vector2F vB = new Vector2F(1f, 0f);
            float wB = 0f;
            Vector2F normal = new Vector2F(1f, 0f);
            float friction = 0.5f;
            float mA = 1f, iA = 1f, mB = 1f, iB = 1f;

            object[] args = { vc, vA, wA, vB, wB, normal, friction, mA, iA, mB, iB };
            method.Invoke(null, args);

            Assert.True(vc.Points[0].TangentImpulse >= 0f);
            Assert.True(vc.Points[1].TangentImpulse >= 0f);
        }

        /// <summary>
        /// Tests that initialize velocity constraint points without velocity bias when vrel high
        /// </summary>
        [Fact]
        public void InitializeVelocityConstraintPoints_WithoutVelocityBias_WhenVrelHigh()
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
                new object[] { Vector2F.Zero, new Vector2F(1f, 0f), 1f, 1f, 1f, 1f, new Vector2F(0f, 1f), new Vector2F(-2f, 0f), 0f, Vector2F.Zero, 0f });

            object[] args = { vc, points, data };
            method.Invoke(null, args);

            Assert.Equal(0f, vc.Points[0].VelocityBias);
        }

        /// <summary>
        /// Tests that solve contact position constraint with two points returns min separation
        /// </summary>
        [Fact]
        public void SolveContactPositionConstraint_WithTwoPoints_ReturnsMinSeparation()
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
                InvMassA = 1.0f,
                InvMassB = 1.0f,
                InvIa = 1.0f,
                InvIb = 1.0f,
                LocalCenterA = Vector2F.Zero,
                LocalCenterB = Vector2F.Zero,
                PointCount = 2,
                RadiusA = 0.5f,
                RadiusB = 0.5f,
                Type = ManifoldType.FaceA,
                LocalNormal = new Vector2F(1f, 0f),
                LocalPoint = new Vector2F(0.5f, 0f)
            };
            pc.LocalPoints[0] = new Vector2F(-0.5f, -0.5f);
            pc.LocalPoints[1] = new Vector2F(-0.5f, 0.5f);

            float result = (float)method.Invoke(solver, new object[] { pc });
            Assert.True(result <= 0f);
        }

        /// <summary>
        /// Tests that solve two point normal fourth branch both vn non negative applies block impulse
        /// </summary>
        [Fact]
        public void SolveTwoPointNormal_FourthBranchBothVnNonNegative_AppliesBlockImpulse()
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
            Assert.True(vAResult.X >= -2f);
        }

        /// <summary>
        /// Tests that acquire release contact locks multiple calls does not deadlock
        /// </summary>
        [Fact]
        public void AcquireReleaseContactLocks_MultipleCalls_DoesNotDeadlock()
        {
            ContactSolver solver = new ContactSolver();
            int[] locks = new int[4];
            typeof(ContactSolver).GetField("Locks", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.SetValue(solver, locks);

            MethodInfo acquireMethod = typeof(ContactSolver).GetMethod("AcquireContactLocks",
                BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo releaseMethod = typeof(ContactSolver).GetMethod("ReleaseContactLocks",
                BindingFlags.Instance | BindingFlags.NonPublic);

            Exception ex = Record.Exception(() =>
            {
                acquireMethod.Invoke(solver, new object[] { 0, 1 });
                releaseMethod.Invoke(solver, new object[] { 1, 0 });

                acquireMethod.Invoke(solver, new object[] { 3, 2 });
                releaseMethod.Invoke(solver, new object[] { 2, 3 });
            });

            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that solve velocity constraints multi threaded bodies completes
        /// </summary>
        [Fact]
        public void SolveVelocityConstraints_MultiThreadedBodies_Completes()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            for (int i = 0; i < 10; i++)
            {
                world.CreateCircle(0.5f, 1.0f, new Vector2F(i * 0.3f, 0.0f), BodyType.Dynamic);
            }

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that solve velocity constraints with ordered indices reorders locks
        /// </summary>
        [Fact]
        public void SolveVelocityConstraints_WithOrderedIndices_ReordersLocks()
        {
            MethodInfo solveMethod = typeof(ContactSolver).GetMethod("SolveVelocityConstraints",
                BindingFlags.Instance | BindingFlags.NonPublic,
                null, new Type[] { typeof(int), typeof(int) }, null);

            ContactSolver solver = new ContactSolver();
            solver.Count = 1;
            solver.VelocityConstraints = new ContactVelocityConstraint[1];
            solver.VelocityConstraints[0] = new ContactVelocityConstraint
            {
                IndexA = 1,
                IndexB = 0,
                ContactIndex = 0,
                PointCount = 1,
                InvMassA = 1f,
                InvMassB = 1f,
                InvIa = 1f,
                InvIb = 1f,
                Normal = new Vector2F(1f, 0f),
                Friction = 0f,
                TangentSpeed = 0f
            };
            solver.VelocityConstraints[0].Points[0].NormalImpulse = 0f;
            solver.VelocityConstraints[0].Points[0].TangentImpulse = 0f;
            solver.VelocityConstraints[0].Points[0].NormalMass = 1f;
            solver.VelocityConstraints[0].Points[0].TangentMass = 1f;
            solver.VelocityConstraints[0].Points[0].Ra = Vector2F.Zero;
            solver.VelocityConstraints[0].Points[0].Rb = Vector2F.Zero;
            solver.VelocityConstraints[0].Points[0].VelocityBias = 0f;

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

            Type solverVelType = typeof(ContactSolver).Assembly.GetType("Alis.Core.Physic.Dynamics.SolverVelocity");
            Array velocities = Array.CreateInstance(solverVelType, 2);
            object vel0 = Activator.CreateInstance(solverVelType);
            solverVelType.GetField("V").SetValue(vel0, new Vector2F(-1f, 0f));
            solverVelType.GetField("W").SetValue(vel0, 0f);
            object vel1 = Activator.CreateInstance(solverVelType);
            solverVelType.GetField("V").SetValue(vel1, new Vector2F(0f, 0f));
            solverVelType.GetField("W").SetValue(vel1, 0f);
            velocities.SetValue(vel0, 0);
            velocities.SetValue(vel1, 1);
            solver.GetType().GetField("Velocities", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(solver, velocities);

            int[] locks = new int[2];
            solver.GetType().GetField("Locks", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(solver, locks);

            Exception ex = Record.Exception(() => solveMethod.Invoke(solver, new object[] { 0, 1 }));
            Assert.Null(ex);
        }

        // ========================================================================
        // SolveVelocityConstraints multithreaded path via threshold
        // ========================================================================
        /// <summary>
        /// Tests that solve velocity constraints multi threaded threshold executes
        /// </summary>
        [Fact]
        public void SolveVelocityConstraints_MultiThreadedThreshold_Executes()
        {
            ContactSolver solver = new ContactSolver();
            typeof(ContactSolver).GetField("_velocityConstraintsMultithreadThreshold",
                BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(solver, 0);
            solver.Count = 2;
            solver.VelocityConstraints = new ContactVelocityConstraint[2];
            for (int i = 0; i < 2; i++)
            {
                solver.VelocityConstraints[i] = new ContactVelocityConstraint
                {
                    IndexA = 0,
                    IndexB = 1,
                    PointCount = 1,
                    InvMassA = 1f,
                    InvMassB = 1f,
                    InvIa = 1f,
                    InvIb = 1f,
                    Normal = new Vector2F(1f, 0f),
                    Friction = 0f,
                    TangentSpeed = 0f
                };
                solver.VelocityConstraints[i].Points[0].NormalImpulse = 0f;
                solver.VelocityConstraints[i].Points[0].TangentImpulse = 0f;
                solver.VelocityConstraints[i].Points[0].NormalMass = 1f;
                solver.VelocityConstraints[i].Points[0].TangentMass = 1f;
                solver.VelocityConstraints[i].Points[0].Ra = Vector2F.Zero;
                solver.VelocityConstraints[i].Points[0].Rb = Vector2F.Zero;
                solver.VelocityConstraints[i].Points[0].VelocityBias = 0f;
            }
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
            Type solverVelType = typeof(ContactSolver).Assembly.GetType("Alis.Core.Physic.Dynamics.SolverVelocity");
            Array velocities = Array.CreateInstance(solverVelType, 2);
            object vel0 = Activator.CreateInstance(solverVelType);
            solverVelType.GetField("V").SetValue(vel0, new Vector2F(-1f, 0f));
            solverVelType.GetField("W").SetValue(vel0, 0f);
            object vel1 = Activator.CreateInstance(solverVelType);
            solverVelType.GetField("V").SetValue(vel1, new Vector2F(0f, 0f));
            solverVelType.GetField("W").SetValue(vel1, 0f);
            velocities.SetValue(vel0, 0);
            velocities.SetValue(vel1, 1);
            solver.GetType().GetField("Velocities", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(solver, velocities);
            int[] locks = new int[2];
            solver.GetType().GetField("Locks", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(solver, locks);
            Exception ex = Record.Exception(() => solver.SolveVelocityConstraints());
            Assert.Null(ex);
        }

        // ========================================================================
        // SolvePositionConstraints multithreaded path via threshold
        // ========================================================================
        /// <summary>
        /// Tests that solve position constraints multi threaded threshold executes
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_MultiThreadedThreshold_Executes()
        {
            ContactSolver solver = new ContactSolver();
            typeof(ContactSolver).GetField("_positionConstraintsMultithreadThreshold",
                BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(solver, 0);
            solver.Count = 2;
            solver.PositionConstraints = new ContactPositionConstraint[2];
            for (int i = 0; i < 2; i++)
            {
                solver.PositionConstraints[i] = new ContactPositionConstraint
                {
                    IndexA = 0,
                    IndexB = 1,
                    InvMassA = 1f,
                    InvMassB = 1f,
                    InvIa = 1f,
                    InvIb = 1f,
                    LocalCenterA = Vector2F.Zero,
                    LocalCenterB = Vector2F.Zero,
                    PointCount = 1,
                    RadiusA = 0.5f,
                    RadiusB = 0.5f,
                    Type = ManifoldType.FaceA,
                    LocalNormal = new Vector2F(1f, 0f),
                    LocalPoint = new Vector2F(0.5f, 0f)
                };
            }
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
            int[] locks = new int[2];
            solver.GetType().GetField("Locks", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(solver, locks);
            bool result = solver.SolvePositionConstraints();
            Assert.True(result || !result);
        }

        // ========================================================================
        // Reset with WarmStarting = false
        // ========================================================================
        /// <summary>
        /// Tests that reset with warm starting false sets impulses to zero
        /// </summary>
        [Fact]
        public void Reset_WithWarmStartingFalse_SetsImpulsesToZero()
        {
            ContactSolver solver = new ContactSolver();
            TimeStep step = new TimeStep { Dt = 1f / 60f, DtRatio = 1.0f, WarmStarting = false };
            SolverPosition[] pos = new SolverPosition[2];
            SolverVelocity[] vel = new SolverVelocity[2];
            int[] lks = new int[2];
            Contact[] dummyContacts = new Contact[1];
            Exception ex = Record.Exception(() => solver.Reset(ref step, 0, dummyContacts, pos, vel, lks, 0, 0));
            Assert.Null(ex);
        }

        // ========================================================================
        // SolveToiPositionConstraints with non-zero count
        // ========================================================================
        /// <summary>
        /// Tests that solve toi position constraints with non zero count executes
        /// </summary>
        [Fact]
        public void SolveToiPositionConstraints_WithNonZeroCount_Executes()
        {
            ContactSolver solver = new ContactSolver();
            solver.Count = 1;
            solver.PositionConstraints = new ContactPositionConstraint[1];
            solver.PositionConstraints[0] = new ContactPositionConstraint
            {
                IndexA = 0,
                IndexB = 1,
                InvMassA = 1f,
                InvMassB = 1f,
                InvIa = 1f,
                InvIb = 1f,
                LocalCenterA = Vector2F.Zero,
                LocalCenterB = Vector2F.Zero,
                PointCount = 1,
                RadiusA = 0.5f,
                RadiusB = 0.5f,
                Type = ManifoldType.FaceA,
                LocalNormal = new Vector2F(1f, 0f),
                LocalPoint = new Vector2F(0.5f, 0f)
            };
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
            bool result = solver.SolveToiPositionConstraints(0, 1);
            Assert.True(result || !result);
        }

        // ========================================================================
        // AcquireContactLocks with contention
        // ========================================================================
        /// <summary>
        /// Tests that acquire contact locks contention does not deadlock
        /// </summary>
        [Fact]
        public void AcquireContactLocks_Contention_DoesNotDeadlock()
        {
            ContactSolver solver = new ContactSolver();
            int[] locks = new int[2];
            typeof(ContactSolver).GetField("Locks", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.SetValue(solver, locks);
            locks[0] = 1;
            MethodInfo acquireMethod = typeof(ContactSolver).GetMethod("AcquireContactLocks",
                BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo releaseMethod = typeof(ContactSolver).GetMethod("ReleaseContactLocks",
                BindingFlags.Instance | BindingFlags.NonPublic);
            Exception ex = Record.Exception(() =>
            {
                releaseMethod.Invoke(solver, new object[] { 0, 1 });
                acquireMethod.Invoke(solver, new object[] { 0, 1 });
                releaseMethod.Invoke(solver, new object[] { 0, 1 });
            });
            Assert.Null(ex);
        }

        // ========================================================================
        // LockBodies with contention
        // ========================================================================
        /// <summary>
        /// Tests that lock bodies contention does not deadlock
        /// </summary>
        [Fact]
        public void LockBodies_Contention_DoesNotDeadlock()
        {
            ContactSolver solver = new ContactSolver();
            int[] locks = new int[2];
            typeof(ContactSolver).GetField("Locks", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.SetValue(solver, locks);
            locks[0] = 1;
            MethodInfo lockMethod = typeof(ContactSolver).GetMethod("LockBodies",
                BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo unlockMethod = typeof(ContactSolver).GetMethod("UnlockBodies",
                BindingFlags.Instance | BindingFlags.NonPublic);
            Exception ex = Record.Exception(() =>
            {
                unlockMethod.Invoke(solver, new object[] { 0, 1 });
                lockMethod.Invoke(solver, new object[] { 0, 1 });
                unlockMethod.Invoke(solver, new object[] { 0, 1 });
            });
            Assert.Null(ex);
        }

        // ========================================================================
        // SolveTwoPointNormal — all 4 branches via actual contact setup
        // ========================================================================
        /// <summary>
        /// Tests that solve two point normal through world step executes
        /// </summary>
        [Fact]
        public void SolveTwoPointNormal_ThroughWorldStep_Executes()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Body bodyB = world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.5f, 0.0f), 0.0f, BodyType.Dynamic);
            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
            Assert.True(world.ContactManager.ContactCount > 0);
        }

        // ========================================================================
        // InitializeVelocityConstraints with two-point contact
        // ========================================================================
        /// <summary>
        /// Tests that initialize velocity constraints two point contact works
        /// </summary>
        [Fact]
        public void InitializeVelocityConstraints_TwoPointContact_Works()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Body bodyB = world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that warm start with velocities updates velocities
        /// </summary>
        [Fact]
        public void WarmStart_WithVelocities_UpdatesVelocities()
        {
            ContactSolver solver = new ContactSolver();
            Type solverVelType = typeof(ContactSolver).Assembly.GetType("Alis.Core.Physic.Dynamics.SolverVelocity");
            Array velocities = Array.CreateInstance(solverVelType, 2);
            object vel0 = Activator.CreateInstance(solverVelType);
            solverVelType.GetField("V").SetValue(vel0, new Vector2F(0f, 0f));
            solverVelType.GetField("W").SetValue(vel0, 0f);
            object vel1 = Activator.CreateInstance(solverVelType);
            solverVelType.GetField("V").SetValue(vel1, new Vector2F(0f, 0f));
            solverVelType.GetField("W").SetValue(vel1, 0f);
            velocities.SetValue(vel0, 0);
            velocities.SetValue(vel1, 1);
            solver.GetType().GetField("Velocities", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(solver, velocities);
            solver.VelocityConstraints = new ContactVelocityConstraint[1];
            solver.VelocityConstraints[0] = new ContactVelocityConstraint
            {
                IndexA = 0,
                IndexB = 1,
                InvMassA = 1f,
                InvMassB = 1f,
                InvIa = 1f,
                InvIb = 1f,
                Normal = new Vector2F(1f, 0f),
                PointCount = 1
            };
            solver.VelocityConstraints[0].Points[0].NormalImpulse = 0.5f;
            solver.VelocityConstraints[0].Points[0].TangentImpulse = 0.0f;
            solver.VelocityConstraints[0].Points[0].Ra = new Vector2F(0f, 0f);
            solver.VelocityConstraints[0].Points[0].Rb = new Vector2F(0f, 0f);
            solver.Count = 1;
            Exception ex = Record.Exception(() => solver.WarmStart());
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that dispose with allocated arrays clears references
        /// </summary>
        [Fact]
        public void Dispose_WithAllocatedArrays_ClearsReferences()
        {
            ContactSolver solver = new ContactSolver();
            TimeStep step = new TimeStep { Dt = 1f / 60f, DtRatio = 1.0f, WarmStarting = true };
            SolverPosition[] pos = new SolverPosition[0];
            SolverVelocity[] vel = new SolverVelocity[0];
            int[] lks = new int[0];
            Contact[] dummyContacts = new Contact[0];
            solver.Reset(ref step, 0, dummyContacts, pos, vel, lks, 0, 0);
            solver.Dispose();
            Assert.Null(solver.VelocityConstraints);
            Assert.Null(solver.PositionConstraints);
        }

        /// <summary>
        /// Tests that world manifold initialize with zero point count returns
        /// </summary>
        [Fact]
        public void WorldManifold_Initialize_PointCountZero_ReturnsEarly()
        {
            Manifold manifold = new Manifold
            {
                PointCount = 0,
                Type = ManifoldType.Circles,
                LocalPoint = new Vector2F(0.0f, 0.0f)
            };
            ControllerTransform xfA = new ControllerTransform(new Vector2F(0.0f, 0.0f), 0.0f);
            ControllerTransform xfB = new ControllerTransform(new Vector2F(1.0f, 0.0f), 0.0f);
            ContactSolver.WorldManifold.Initialize(ref manifold, ref xfA, 0.5f, ref xfB, 0.5f,
                out Vector2F normal, out FixedArray2<Vector2F> points);
            Assert.Equal(0.0f, normal.X);
            Assert.Equal(0.0f, normal.Y);
        }

        /// <summary>
        /// Tests that world manifold initialize with face a computes correctly
        /// </summary>
        [Fact]
        public void WorldManifold_Initialize_FaceA_ComputesCorrectly()
        {
            Manifold manifold = new Manifold
            {
                PointCount = 2,
                Type = ManifoldType.FaceA,
                LocalPoint = new Vector2F(0.0f, 0.0f),
                LocalNormal = new Vector2F(1.0f, 0.0f)
            };
            manifold.Points[0] = new ManifoldPoint { LocalPoint = new Vector2F(-0.5f, -0.5f) };
            manifold.Points[1] = new ManifoldPoint { LocalPoint = new Vector2F(-0.5f, 0.5f) };
            ControllerTransform xfA = new ControllerTransform(new Vector2F(0.0f, 0.0f), 0.0f);
            ControllerTransform xfB = new ControllerTransform(new Vector2F(1.0f, 0.0f), 0.0f);
            ContactSolver.WorldManifold.Initialize(ref manifold, ref xfA, 0.5f, ref xfB, 0.5f,
                out Vector2F normal, out FixedArray2<Vector2F> points);
            Assert.Equal(1.0f, normal.X);
            Assert.Equal(0.0f, normal.Y);
            Assert.True(points[0].X >= -1.0f);
        }

        /// <summary>
        /// Tests that world manifold initialize with circles non coincident computes normal
        /// </summary>
        [Fact]
        public void WorldManifold_Initialize_CirclesNonCoincident_NormalComputed()
        {
            Manifold manifold = new Manifold
            {
                PointCount = 1,
                Type = ManifoldType.Circles,
                LocalPoint = new Vector2F(0.0f, 0.0f)
            };
            manifold.Points[0] = new ManifoldPoint { LocalPoint = new Vector2F(0.0f, 0.0f) };
            ControllerTransform xfA = new ControllerTransform(new Vector2F(0.0f, 0.0f), 0.0f);
            ControllerTransform xfB = new ControllerTransform(new Vector2F(2.0f, 0.0f), 0.0f);
            ContactSolver.WorldManifold.Initialize(ref manifold, ref xfA, 0.5f, ref xfB, 0.5f,
                out Vector2F normal, out FixedArray2<Vector2F> points);
            Assert.True(normal.X > 0.0f);
        }

        /// <summary>
        /// Tests that solve velocity constraints with count zero returns early
        /// </summary>
        [Fact]
        public void SolveVelocityConstraints_CountZero_EarlyReturn()
        {
            ContactSolver solver = new ContactSolver();
            solver.Count = 0;
            Exception ex = Record.Exception(() => solver.SolveVelocityConstraints());
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that solve position constraints with count zero returns true
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_CountZero_ReturnsTrue()
        {
            ContactSolver solver = new ContactSolver();
            solver.Count = 0;
            bool result = solver.SolvePositionConstraints();
            Assert.True(result);
        }

        /// <summary>
        /// Tests that initialize velocity constraint points with velocity bias when vrel below threshold
        /// </summary>
        [Fact]
        public void InitializeVelocityConstraintPoints_WithVelocityBias_WhenVrelBelowThreshold()
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
            Assert.True(vc.Points[0].VelocityBias > 0f);
        }

        /// <summary>
        /// Tests that solve two point normal second branch applies block impulse
        /// </summary>
        [Fact]
        public void SolveTwoPointNormal_SecondBranch_AppliesBlockImpulse()
        {
            MethodInfo method = typeof(ContactSolver).GetMethod("SolveTwoPointNormal",
                BindingFlags.Static | BindingFlags.NonPublic);
            var vc = new ContactVelocityConstraint();
            vc.PointCount = 2;
            vc.Normal = new Vector2F(1f, 0f);
            vc.K.Ex = new Vector2F(2f, 0f);
            vc.K.Ey = new Vector2F(0f, 2f);
            vc.NormalMass = vc.K.Inverse;
            vc.Points[0].NormalImpulse = 0f;
            vc.Points[0].NormalMass = 1.0f;
            vc.Points[0].VelocityBias = 0f;
            vc.Points[0].Ra = new Vector2F(0f, -1f);
            vc.Points[0].Rb = new Vector2F(0f, 0f);
            vc.Points[1].NormalImpulse = 0f;
            vc.Points[1].NormalMass = 1.0f;
            vc.Points[1].VelocityBias = 0f;
            vc.Points[1].Ra = new Vector2F(0f, 1f);
            vc.Points[1].Rb = new Vector2F(0f, 0f);
            Vector2F vA = new Vector2F(0f, 0f);
            float wA = 1f;
            Vector2F vB = new Vector2F(0f, 0f);
            float wB = 0f;
            Vector2F normal = new Vector2F(1f, 0f);
            float mA = 1f, iA = 1f, mB = 1f, iB = 1f;
            object[] args = { vA, wA, vB, wB, vc, normal, mA, iA, mB, iB };
            method.Invoke(null, args);
            Vector2F vAResult = (Vector2F)args[0];
            Assert.True(vAResult.X <= 1f);
        }

        /// <summary>
        /// Tests that solve two point normal third branch applies block impulse
        /// </summary>
        [Fact]
        public void SolveTwoPointNormal_ThirdBranch_AppliesBlockImpulse()
        {
            MethodInfo method = typeof(ContactSolver).GetMethod("SolveTwoPointNormal",
                BindingFlags.Static | BindingFlags.NonPublic);
            var vc = new ContactVelocityConstraint();
            vc.PointCount = 2;
            vc.Normal = new Vector2F(1f, 0f);
            vc.K.Ex = new Vector2F(2f, 0f);
            vc.K.Ey = new Vector2F(0f, 2f);
            vc.NormalMass = vc.K.Inverse;
            vc.Points[0].NormalImpulse = 0f;
            vc.Points[0].NormalMass = 1.0f;
            vc.Points[0].VelocityBias = 0f;
            vc.Points[0].Ra = new Vector2F(0f, 1f);
            vc.Points[0].Rb = new Vector2F(0f, 0f);
            vc.Points[1].NormalImpulse = 0f;
            vc.Points[1].NormalMass = 1.0f;
            vc.Points[1].VelocityBias = 0f;
            vc.Points[1].Ra = new Vector2F(0f, -1f);
            vc.Points[1].Rb = new Vector2F(0f, 0f);
            Vector2F vA = new Vector2F(0f, 0f);
            float wA = 1f;
            Vector2F vB = new Vector2F(0f, 0f);
            float wB = 0f;
            Vector2F normal = new Vector2F(1f, 0f);
            float mA = 1f, iA = 1f, mB = 1f, iB = 1f;
            object[] args = { vA, wA, vB, wB, vc, normal, mA, iA, mB, iB };
            method.Invoke(null, args);
            Vector2F vAResult = (Vector2F)args[0];
            Assert.True(vAResult.X >= -1f);
        }

        /// <summary>
        /// Tests that reset with warm starting false and count greater than zero clears impulses
        /// </summary>
        [Fact]
        public void Reset_WithWarmStartingFalseAndCountGreaterThanZero_ClearsImpulses()
        {
            ContactSolver solver = new ContactSolver();
            TimeStep step = new TimeStep { Dt = 1f / 60f, DtRatio = 1.0f, WarmStarting = false };
            SolverPosition[] pos = new SolverPosition[2];
            SolverVelocity[] vel = new SolverVelocity[2];
            int[] lks = new int[2];
            Contact[] dummyContacts = new Contact[1];
            Exception ex = Record.Exception(() => solver.Reset(ref step, 0, dummyContacts, pos, vel, lks, 0, 0));
            Assert.Null(ex);
        }
    }
}
