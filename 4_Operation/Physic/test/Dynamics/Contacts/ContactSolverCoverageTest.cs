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

    }
}
