// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactSolverZeroMassCoverageTests.cs
// 
//  --------------------------------------------------------------------------

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    ///     Exercises the zero effective-mass branches of the contact solver, which are only
    ///     reachable when both bodies involved in a constraint carry zero inverse mass/inertia.
    /// </summary>
    public class ContactSolverZeroMassCoverageTests
    {
        /// <summary>
        ///     A contact between two massless (static) bodies yields a zero normal/tangent
        ///     effective mass, so both guarded divisions fall back to a zero mass.
        /// </summary>
        [Fact]
        public void InitializeVelocityConstraints_WithZeroInverseMass_UsesZeroMasses()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, Vector2F.Zero, BodyType.Static);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Static);
            bodyA.GetIslandIndex = 0;
            bodyB.GetIslandIndex = 1;

            Contact contact = Contact.Create(world.ContactManager, bodyA.FixtureList[0], 0, bodyB.FixtureList[0], 0);
            Manifold manifold = contact.Manifold;
            manifold.Type = ManifoldType.Circles;
            manifold.PointCount = 1;
            manifold.LocalPoint = Vector2F.Zero;
            manifold.Points[0] = new ManifoldPoint { LocalPoint = new Vector2F(0.5f, 0.0f) };
            contact.Manifold = manifold;

            ContactSolver solver = new ContactSolver();
            TimeStep step = new TimeStep { Dt = 1.0f / 60.0f, InvDt = 60.0f, DtRatio = 1.0f, WarmStarting = true };
            solver.Reset(ref step, 1, new[] { contact }, new SolverPosition[2], new SolverVelocity[2], new int[2], int.MaxValue, int.MaxValue);

            solver.InitializeVelocityConstraints();

            Assert.Equal(0.0f, solver.VelocityConstraints[0].Points[0].NormalMass);
            Assert.Equal(0.0f, solver.VelocityConstraints[0].Points[0].TangentMass);

            solver.Dispose();
        }

        /// <summary>
        ///     A position constraint whose bodies have zero inverse mass uses the zero-mass
        ///     fallback for the normal impulse.
        /// </summary>
        [Fact]
        public void SolveContactPositionConstraint_WithZeroInverseMass_UsesZeroImpulse()
        {
            ContactSolver solver = new ContactSolver();
            solver.Positions = new SolverPosition[2];

            ContactPositionConstraint pc = new ContactPositionConstraint
            {
                IndexA = 0,
                IndexB = 1,
                InvMassA = 0.0f,
                InvMassB = 0.0f,
                InvIa = 0.0f,
                InvIb = 0.0f,
                LocalCenterA = Vector2F.Zero,
                LocalCenterB = Vector2F.Zero,
                LocalNormal = new Vector2F(0.0f, 1.0f),
                LocalPoint = Vector2F.Zero,
                RadiusA = 0.5f,
                RadiusB = 0.5f,
                Type = ManifoldType.Circles,
                PointCount = 1
            };
            pc.LocalPoints[0] = new Vector2F(0.0f, 1.0f);

            float minSeparation = solver.SolveContactPositionConstraint(pc);

            Assert.Equal(0.0f, solver.Positions[0].C.X);
            Assert.Equal(0.0f, solver.Positions[0].C.Y);
            Assert.Equal(0.0f, minSeparation);
        }

        /// <summary>
        ///     A TOI solve whose body indices are not part of the constraint zeroes the
        ///     inverse masses, exercising the zero effective-mass fallback.
        /// </summary>
        [Fact]
        public void SolveToiPositionConstraints_WithUnrelatedToiIndices_UsesZeroImpulse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);
            bodyA.GetIslandIndex = 0;
            bodyB.GetIslandIndex = 1;

            Contact contact = Contact.Create(world.ContactManager, bodyA.FixtureList[0], 0, bodyB.FixtureList[0], 0);
            Manifold manifold = contact.Manifold;
            manifold.Type = ManifoldType.Circles;
            manifold.PointCount = 1;
            manifold.LocalPoint = Vector2F.Zero;
            manifold.Points[0] = new ManifoldPoint { LocalPoint = new Vector2F(1.0f, 0.0f) };
            contact.Manifold = manifold;

            ContactSolver solver = new ContactSolver();
            TimeStep step = new TimeStep { Dt = 1.0f / 60.0f, InvDt = 60.0f, DtRatio = 1.0f, WarmStarting = true };
            solver.Reset(ref step, 1, new[] { contact }, new SolverPosition[2], new SolverVelocity[2], new int[2], int.MaxValue, int.MaxValue);

            bool result = solver.SolveToiPositionConstraints(5, 6);

            Assert.True(result);

            solver.Dispose();
        }
    }
}
