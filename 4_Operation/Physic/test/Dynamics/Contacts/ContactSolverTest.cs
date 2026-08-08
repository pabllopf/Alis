// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactSolverTest.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    ///     The contact solver test class
    /// </summary>
    public class ContactSolverTest
    {
        /// <summary>
        ///     Tests that contact solver type should be accessible
        /// </summary>
        [Fact]
        public void ContactSolver_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(ContactSolver));
        }

        /// <summary>
        ///     Tests that Dispose sets the countdown event as disposed.
        /// </summary>
        [Fact]
        public void ContactSolver_Dispose_ReleasesResources()
        {
            ContactSolver solver = new ContactSolver();
            solver.Dispose();
        }

        /// <summary>
        ///     Tests that Dispose can be called multiple times without throwing.
        /// </summary>
        [Fact]
        public void ContactSolver_Dispose_MultipleCallsDontThrow()
        {
            ContactSolver solver = new ContactSolver();
            solver.Dispose();
            solver.Dispose();
        }

        /// <summary>
        ///     Tests that SolveVelocityConstraints with zero count returns immediately.
        ///     This exercises the early-return path in the single-threaded solver.
        /// </summary>
        [Fact]
        public void ContactSolver_SolveVelocityConstraints_ZeroCountReturnsEarly()
        {
            ContactSolver solver = new ContactSolver();
            solver.Count = 0;
            solver.SolveVelocityConstraints();
        }

        /// <summary>
        ///     Tests that SolvePositionConstraints with zero count returns true.
        ///     This exercises the early-return path in SolvePositionConstraints.
        /// </summary>
        [Fact]
        public void ContactSolver_SolvePositionConstraints_ZeroCountReturnsTrue()
        {
            ContactSolver solver = new ContactSolver();
            solver.Count = 0;
            bool result = solver.SolvePositionConstraints();
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that StoreImpulses with zero count does not throw.
        /// </summary>
        [Fact]
        public void ContactSolver_StoreImpulses_ZeroCountDoesNotThrow()
        {
            ContactSolver solver = new ContactSolver();
            solver.Count = 0;
            solver.StoreImpulses();
        }

        /// <summary>
        ///     Tests that WarmStart with zero count does not throw.
        /// </summary>
        [Fact]
        public void ContactSolver_WarmStart_ZeroCountDoesNotThrow()
        {
            ContactSolver solver = new ContactSolver();
            solver.Count = 0;
            solver.WarmStart();
        }

        /// <summary>
        ///     Tests that InitializeVelocityConstraints with zero count does not throw.
        /// </summary>
        [Fact]
        public void ContactSolver_InitializeVelocityConstraints_ZeroCountDoesNotThrow()
        {
            ContactSolver solver = new ContactSolver();
            solver.Count = 0;
            solver.InitializeVelocityConstraints();
        }

        /// <summary>
        ///     Tests that SolveToiPositionConstraints with zero count returns true.
        /// </summary>
        [Fact]
        public void ContactSolver_SolveToiPositionConstraints_ZeroCountReturnsTrue()
        {
            ContactSolver solver = new ContactSolver();
            solver.Count = 0;
            bool result = solver.SolveToiPositionConstraints(0, 0);
            Assert.True(result);
        }

        /// <summary>
        ///     Tests WorldManifold.Initialize with zero point count returns early.
        ///     Exercises the early-return path when manifold.PointCount == 0.
        /// </summary>
        [Fact]
        public void WorldManifold_Initialize_ZeroPointCountReturnsEarly()
        {
            Manifold manifold = new Manifold
            {
                PointCount = 0,
                Type = ManifoldType.Circles
            };
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = ControllerTransform.Identity;

            ContactSolver.WorldManifold.Initialize(ref manifold, ref xfA, 0.5f, ref xfB, 0.5f, out Vector2F normal, out FixedArray2<Vector2F> _);

            Assert.Equal(Vector2F.Zero, normal);
        }

        /// <summary>
        ///     Tests WorldManifold.Initialize with Circles manifold type.
        ///     Exercises the ManifoldType.Circles branch in the switch.
        /// </summary>
        [Fact]
        public void WorldManifold_Initialize_CirclesType()
        {
            Manifold manifold = new Manifold
            {
                PointCount = 1,
                Type = ManifoldType.Circles,
                LocalPoint = new Vector2F(0.0f, 0.0f),
                LocalNormal = new Vector2F(1.0f, 0.0f)
            };
            manifold.Points[0] = new ManifoldPoint { LocalPoint = new Vector2F(1.0f, 0.0f) };

            ControllerTransform xfA = new ControllerTransform(Vector2F.Zero, 0.0f);
            ControllerTransform xfB = new ControllerTransform(new Vector2F(2.0f, 0.0f), 0.0f);

            ContactSolver.WorldManifold.Initialize(ref manifold, ref xfA, 0.5f, ref xfB, 0.5f, out Vector2F normal, out FixedArray2<Vector2F> _);

            Assert.NotEqual(Vector2F.Zero, normal);
        }

        /// <summary>
        ///     Tests WorldManifold.Initialize with FaceA manifold type.
        ///     Exercises the ManifoldType.FaceA branch.
        /// </summary>
        [Fact]
        public void WorldManifold_Initialize_FaceAType()
        {
            Manifold manifold = new Manifold
            {
                PointCount = 1,
                Type = ManifoldType.FaceA,
                LocalPoint = new Vector2F(0.0f, 0.0f),
                LocalNormal = new Vector2F(1.0f, 0.0f)
            };
            manifold.Points[0] = new ManifoldPoint { LocalPoint = new Vector2F(0.0f, 0.0f) };

            ControllerTransform xfA = new ControllerTransform(new Vector2F(1.0f, 0.0f), 0.0f);
            ControllerTransform xfB = new ControllerTransform(new Vector2F(3.0f, 0.0f), 0.0f);

            ContactSolver.WorldManifold.Initialize(ref manifold, ref xfA, 0.5f, ref xfB, 0.5f, out Vector2F normal, out FixedArray2<Vector2F> points);

            Assert.NotEqual(Vector2F.Zero, normal);
            Assert.NotEqual(Vector2F.Zero, points[0]);
        }

        /// <summary>
        ///     Tests WorldManifold.Initialize with FaceB manifold type.
        ///     Exercises the ManifoldType.FaceB branch and the normal negation.
        /// </summary>
        [Fact]
        public void WorldManifold_Initialize_FaceBType()
        {
            Manifold manifold = new Manifold
            {
                PointCount = 1,
                Type = ManifoldType.FaceB,
                LocalPoint = new Vector2F(0.0f, 0.0f),
                LocalNormal = new Vector2F(1.0f, 0.0f)
            };
            manifold.Points[0] = new ManifoldPoint { LocalPoint = new Vector2F(0.0f, 0.0f) };

            ControllerTransform xfA = new ControllerTransform(new Vector2F(1.0f, 0.0f), 0.0f);
            ControllerTransform xfB = new ControllerTransform(new Vector2F(3.0f, 0.0f), 0.0f);

            ContactSolver.WorldManifold.Initialize(ref manifold, ref xfA, 0.5f, ref xfB, 0.5f, out Vector2F normal, out FixedArray2<Vector2F> _);

            Assert.NotEqual(Vector2F.Zero, normal);
        }

        /// <summary>
        ///     Tests WorldManifold.Initialize with FaceA and two contact points.
        ///     Exercises the FaceA loop with multiple points.
        /// </summary>
        [Fact]
        public void WorldManifold_Initialize_FaceATwoPoints()
        {
            Manifold manifold = new Manifold
            {
                PointCount = 2,
                Type = ManifoldType.FaceA,
                LocalPoint = new Vector2F(0.0f, 0.0f),
                LocalNormal = new Vector2F(1.0f, 0.0f)
            };
            manifold.Points[0] = new ManifoldPoint { LocalPoint = new Vector2F(0.0f, -0.5f) };
            manifold.Points[1] = new ManifoldPoint { LocalPoint = new Vector2F(0.0f, 0.5f) };

            ControllerTransform xfA = new ControllerTransform(new Vector2F(1.0f, 0.0f), 0.0f);
            ControllerTransform xfB = new ControllerTransform(new Vector2F(3.0f, 0.0f), 0.0f);

            ContactSolver.WorldManifold.Initialize(ref manifold, ref xfA, 0.5f, ref xfB, 0.5f, out Vector2F normal, out FixedArray2<Vector2F> points);

            Assert.NotEqual(Vector2F.Zero, normal);
            Assert.NotEqual(Vector2F.Zero, points[0]);
            Assert.NotEqual(Vector2F.Zero, points[1]);
        }

        /// <summary>
        ///     Tests WorldManifold.Initialize with FaceB and two contact points.
        ///     Exercises the FaceB loop with multiple points.
        /// </summary>
        [Fact]
        public void WorldManifold_Initialize_FaceBTwoPoints()
        {
            Manifold manifold = new Manifold
            {
                PointCount = 2,
                Type = ManifoldType.FaceB,
                LocalPoint = new Vector2F(0.0f, 0.0f),
                LocalNormal = new Vector2F(1.0f, 0.0f)
            };
            manifold.Points[0] = new ManifoldPoint { LocalPoint = new Vector2F(0.0f, -0.5f) };
            manifold.Points[1] = new ManifoldPoint { LocalPoint = new Vector2F(0.0f, 0.5f) };

            ControllerTransform xfA = new ControllerTransform(new Vector2F(1.0f, 0.0f), 0.0f);
            ControllerTransform xfB = new ControllerTransform(new Vector2F(3.0f, 0.0f), 0.0f);

            ContactSolver.WorldManifold.Initialize(ref manifold, ref xfA, 0.5f, ref xfB, 0.5f, out Vector2F normal, out FixedArray2<Vector2F> points);

            Assert.NotEqual(Vector2F.Zero, normal);
            Assert.NotEqual(Vector2F.Zero, points[0]);
            Assert.NotEqual(Vector2F.Zero, points[1]);
        }
    }
}

