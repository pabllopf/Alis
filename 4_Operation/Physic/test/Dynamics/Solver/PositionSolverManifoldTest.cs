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

using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.NarrowPhase;
using Alis.Core.Physic.Dynamics.Solver;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Solver
{
    /// <summary>
    ///     The position solver manifold test class
    /// </summary>
    public class PositionSolverManifoldTest
    {
        /// <summary>
        ///     Tests that initialize circles test
        /// </summary>
        [Fact]
        public void InitializeCirclesTest()
        {
            // Arrange
            ContactPositionConstraint pc = new ContactPositionConstraint
            {
                PointCount = 1,
                Type = ManifoldType.Circles,
                LocalPoint = new Vector2(1.0f, 1.0f),
                LocalPoints = new[] {new Vector2(2.0f, 2.0f)},
                RadiusA = 1.0f,
                RadiusB = 1.0f
            };
            Vector2 position = new Vector2(1.0f, 1.0f); // Replace with the actual position
            Rotation rotation = new Rotation(0.0f); // Replace with the actual rotation
            Vector2 scale = new Vector2(1.0f, 1.0f); // Replace with the actual scale
            
            Transform xfA = new Transform(position, rotation, scale);
            Transform xfB = new Transform(position, rotation, scale);
            
            // Act
            PositionSolverManifold.Initialize(pc, ref xfA, ref xfB, 0, out Vector2 normal, out Vector2 point, out float separation);
            
            // Assert
            Assert.Equal(new Vector2(0.70710677f, 0.70710677f), normal);
            Assert.Equal(new Vector2(2.5f, 2.5f), point);
            Assert.Equal(-0.585786462f, separation);
        }
        
        /// <summary>
        ///     Tests that initialize face a test
        /// </summary>
        [Fact]
        public void InitializeFaceATest()
        {
            // Arrange
            ContactPositionConstraint pc = new ContactPositionConstraint
            {
                PointCount = 1,
                Type = ManifoldType.FaceA,
                LocalNormal = new Vector2(1.0f, 0.0f),
                LocalPoint = new Vector2(1.0f, 1.0f),
                LocalPoints = new[] {new Vector2(2.0f, 2.0f)},
                RadiusA = 1.0f,
                RadiusB = 1.0f
            };
            Vector2 position = new Vector2(1.0f, 1.0f); // Replace with the actual position
            Rotation rotation = new Rotation(0.0f); // Replace with the actual rotation
            Vector2 scale = new Vector2(1.0f, 1.0f); // Replace with the actual scale
            
            Transform xfA = new Transform(position, rotation, scale);
            Transform xfB = new Transform(position, rotation, scale);
            
            // Act
            PositionSolverManifold.Initialize(pc, ref xfA, ref xfB, 0, out Vector2 normal, out Vector2 point, out float separation);
            
            // Assert
            Assert.Equal(new Vector2(1.0f, 0.0f), normal);
            Assert.Equal(new Vector2(3.0f, 3.0f), point);
            Assert.Equal(-1.0f, separation);
        }
        
        /// <summary>
        ///     Tests that initialize face b test
        /// </summary>
        [Fact]
        public void InitializeFaceBTest()
        {
            // Arrange
            ContactPositionConstraint pc = new ContactPositionConstraint
            {
                PointCount = 1,
                Type = ManifoldType.FaceB,
                LocalNormal = new Vector2(1.0f, 0.0f),
                LocalPoint = new Vector2(1.0f, 1.0f),
                LocalPoints = new[] {new Vector2(2.0f, 2.0f)},
                RadiusA = 1.0f,
                RadiusB = 1.0f
            };
            
            Vector2 position = new Vector2(1.0f, 1.0f); // Replace with the actual position
            Rotation rotation = new Rotation(0.0f); // Replace with the actual rotation
            Vector2 scale = new Vector2(1.0f, 1.0f); // Replace with the actual scale
            
            Transform xfA = new Transform(position, rotation, scale);
            Transform xfB = new Transform(position, rotation, scale);
            
            // Act
            PositionSolverManifold.Initialize(pc, ref xfA, ref xfB, 0, out Vector2 normal, out Vector2 point, out float separation);
            
            // Assert
            Assert.Equal(new Vector2(-1.0f, 0.0f), normal);
            Assert.Equal(new Vector2(3.0f, 3.0f), point);
            Assert.Equal(-1.0f, separation);
        }
    }
}