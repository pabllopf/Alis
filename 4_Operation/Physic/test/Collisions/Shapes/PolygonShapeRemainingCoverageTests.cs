// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PolygonShapeRemainingCoverageTests.cs
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
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions.Shapes
{
    /// <summary>
    /// The polygon shape remaining coverage tests class
    /// </summary>
    public class PolygonShapeRemainingCoverageTests
    {
        /// <summary>
        /// Tests that ray cast ray starting inside returns false
        /// </summary>
        [Fact]
        public void RayCast_RayStartingInside_ReturnsFalse()
        {
            Vertices vertices = new Vertices { new Vector2F(0, 0), new Vector2F(10, 0), new Vector2F(10, 10), new Vector2F(0, 10) };
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            ControllerTransform transform = ControllerTransform.Identity;
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(5, 5),
                Point2 = new Vector2F(5, 25),
                MaxFraction = 1.0f
            };

            bool hit = polygon.RayCast(out RayCastOutput _, ref input, ref transform, 0);

            Assert.False(hit);
        }

        /// <summary>
        /// Tests that compute aabb should update upper bound x and lower bound y
        /// </summary>
        [Fact]
        public void ComputeAabb_ShouldUpdateUpperBoundXAndLowerBoundY()
        {
            Vertices vertices = new Vertices { new Vector2F(0, 5), new Vector2F(5, 0), new Vector2F(2, 4) };
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            ControllerTransform transform = ControllerTransform.Identity;

            polygon.ComputeAabb(out Aabb aabb, ref transform, 0);

            Assert.True(aabb.LowerBound.X <= aabb.UpperBound.X);
            Assert.True(aabb.LowerBound.Y <= aabb.UpperBound.Y);
        }

        /// <summary>
        /// Tests that compare to with different radius returns false
        /// </summary>
        [Fact]
        public void CompareTo_WithDifferentRadius_ReturnsFalse()
        {
            Vertices vertices = new Vertices { new Vector2F(0, 0), new Vector2F(1, 0), new Vector2F(0, 1) };
            PolygonShape a = new PolygonShape(vertices, 1.0f);
            PolygonShape b = new PolygonShape(vertices, 1.0f);
            b.GetRadius = b.GetRadius + 1.0f;

            bool result = a.CompareTo(b);

            Assert.False(result);
        }

        /// <summary>
        /// Tests that compare to with same radius different mass data returns false
        /// </summary>
        [Fact]
        public void CompareTo_WithSameRadiusDifferentMassData_ReturnsFalse()
        {
            Vertices vertices = new Vertices { new Vector2F(0, 0), new Vector2F(1, 0), new Vector2F(0, 1) };
            PolygonShape a = new PolygonShape(vertices, 1.0f);
            PolygonShape b = new PolygonShape(vertices, 1.0f)
                {
                    MassData = new MassData()
                };

            bool result = a.CompareTo(b);

            Assert.False(result);
        }
    }
}
