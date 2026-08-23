// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PositionSolverManifoldTest.cs
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

using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    ///     The position solver manifold test class
    /// </summary>
    public class PositionSolverManifoldTest
    {
        /// <summary>
        ///     Tests that PositionSolverManifold class should be accessible
        /// </summary>
        [Fact]
        public void PositionSolverManifold_ClassShouldBeAccessible()
        {
            Assert.NotNull(typeof(PositionSolverManifold));
        }

        /// <summary>
        ///     Tests that PositionSolverManifold should be a static class
        /// </summary>
        [Fact]
        public void PositionSolverManifold_ShouldBeStaticClass()
        {
            Type type = typeof(PositionSolverManifold);
            Assert.True(type.IsSealed);
            Assert.True(type.IsAbstract);
        }

       


        /// <summary>
        ///     Tests that initialize with circles manifold type computes contact data
        /// </summary>
        [Fact]
        public void Initialize_WithCirclesType_ComputesContactData()
        {
            ContactPositionConstraint pc = new ContactPositionConstraint
            {
                Type = ManifoldType.Circles,
                LocalPoint = new Vector2F(0, 0),
                LocalPoints = { [0] = new Vector2F(1, 0) },
                RadiusA = 0.5f,
                RadiusB = 0.5f
            };
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = ControllerTransform.Identity;

            PositionSolverManifold.Initialize(pc, ref xfA, ref xfB, 0, out Vector2F normal, out Vector2F point, out float _);

            Assert.NotEqual(Vector2F.Zero, normal);
            Assert.NotEqual(Vector2F.Zero, point);
        }

        /// <summary>
        ///     Tests that initialize with circles type when points are identical handles zero normal
        /// </summary>
        [Fact]
        public void Initialize_WithCirclesType_WhenPointsIdentical_HandlesZeroNormal()
        {
            ContactPositionConstraint pc = new ContactPositionConstraint
            {
                Type = ManifoldType.Circles,
                LocalPoint = new Vector2F(0, 0),
                LocalPoints = { [0] = new Vector2F(0, 0) },
                RadiusA = 0.5f,
                RadiusB = 0.5f
            };
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = ControllerTransform.Identity;

            PositionSolverManifold.Initialize(pc, ref xfA, ref xfB, 0, out Vector2F normal, out Vector2F _, out float _);

            Assert.Equal(Vector2F.Zero, normal);
        }

        /// <summary>
        ///     Tests that initialize with face a type computes contact data
        /// </summary>
        [Fact]
        public void Initialize_WithFaceAType_ComputesContactData()
        {
            ContactPositionConstraint pc = new ContactPositionConstraint
            {
                Type = ManifoldType.FaceA,
                LocalNormal = new Vector2F(0, 1),
                LocalPoint = new Vector2F(0, 0),
                LocalPoints = { [0] = new Vector2F(1, 0) },
                RadiusA = 0.1f,
                RadiusB = 0.1f
            };
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = ControllerTransform.Identity;

            PositionSolverManifold.Initialize(pc, ref xfA, ref xfB, 0, out Vector2F normal, out Vector2F point, out float _);

            Assert.NotEqual(Vector2F.Zero, normal);
            Assert.NotEqual(Vector2F.Zero, point);
        }

        /// <summary>
        ///     Tests that initialize with face b type computes contact data with inverted normal
        /// </summary>
        [Fact]
        public void Initialize_WithFaceBType_ComputesContactData()
        {
            ContactPositionConstraint pc = new ContactPositionConstraint
            {
                Type = ManifoldType.FaceB,
                LocalNormal = new Vector2F(0, 1),
                LocalPoint = new Vector2F(0, 0),
                LocalPoints = { [0] = new Vector2F(0, 1) },
                RadiusA = 0.1f,
                RadiusB = 0.1f
            };
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = ControllerTransform.Identity;

            PositionSolverManifold.Initialize(pc, ref xfA, ref xfB, 0, out Vector2F normal, out Vector2F point, out float _);

            // FaceB normal should be negated (point from A to B)
            Assert.True(normal.Y < 0);
            Assert.NotEqual(Vector2F.Zero, point);
        }

        /// <summary>
        ///     Tests that initialize with unknown manifold type returns zeros
        /// </summary>
        [Fact]
        public void Initialize_WithUnknownType_ReturnsZeros()
        {
            ContactPositionConstraint pc = new ContactPositionConstraint
            {
                Type = (ManifoldType)99,
                RadiusA = 0.5f,
                RadiusB = 0.5f
            };
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = ControllerTransform.Identity;

            PositionSolverManifold.Initialize(pc, ref xfA, ref xfB, 0, out Vector2F normal, out Vector2F point, out float separation);

            Assert.Equal(Vector2F.Zero, normal);
            Assert.Equal(Vector2F.Zero, point);
            Assert.Equal(0, separation);
        }

        /// <summary>
        ///     Tests that initialize with circles type computes correct separation
        /// </summary>
        [Fact]
        public void Initialize_WithCirclesType_ComputesCorrectSeparation()
        {
            ContactPositionConstraint pc = new ContactPositionConstraint
            {
                Type = ManifoldType.Circles,
                LocalPoint = new Vector2F(0, 0),
                LocalPoints = { [0] = new Vector2F(2, 0) },
                RadiusA = 0.5f,
                RadiusB = 0.5f
            };
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = ControllerTransform.Identity;

            PositionSolverManifold.Initialize(pc, ref xfA, ref xfB, 0, out Vector2F _, out Vector2F _, out float separation);

            // separation = dot(pointB - pointA, normal) - radiusA - radiusB
            // = dot((2,0) - (0,0), (1,0)) - 1 = 2 - 1 = 1
            Assert.Equal(1.0f, separation, 4);
        }
    }
}
