// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PolygonShapeLatestCoverageTests.cs
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
    ///     The polygon shape latest coverage tests class
    /// </summary>
    public class PolygonShapeLatestCoverageTests
    {
        /// <summary>
        ///     Tests that ray cast returns false when the ray starts inside the polygon
        /// </summary>
        [Fact]
        public void RayCast_StartingInsidePolygon_ReturnsFalse()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(4, 0),
                new Vector2F(4, 4),
                new Vector2F(0, 4)
            };
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            ControllerTransform transform = ControllerTransform.Identity;
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(2, 2),
                Point2 = new Vector2F(2, 4),
                MaxFraction = 1.0f
            };

            bool hit = polygon.RayCast(out RayCastOutput output, ref input, ref transform, 0);

            Assert.False(hit);
            Assert.Equal(0, output.Fraction);
        }

        /// <summary>
        ///     Tests that compute aabb with a clockwise rotated polygon updates the upper bounds
        /// </summary>
        [Fact]
        public void ComputeAabb_WithClockwiseRotatedPolygon_UpdatesUpperBounds()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(4, 0),
                new Vector2F(4, 4),
                new Vector2F(0, 4)
            };
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            ControllerTransform transform = new ControllerTransform(Vector2F.Zero, new Complex(-0.7071f, 0.7071f));

            polygon.ComputeAabb(out Aabb aabb, ref transform, 0);

            Assert.True(aabb.LowerBound.X < -2.0f);
            Assert.True(aabb.LowerBound.Y < -2.0f);
            Assert.True(aabb.UpperBound.X > -0.1f);
            Assert.True(aabb.UpperBound.Y > 2.0f);
        }

        /// <summary>
        ///     Tests that compare to returns false when the radius differs
        /// </summary>
        [Fact]
        public void CompareTo_DifferentRadius_ReturnsFalse()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(0, 1)
            };
            PolygonShape a = new PolygonShape(vertices, 1.0f);
            PolygonShape b = new PolygonShape(vertices, 1.0f);
            b.GetRadius = a.GetRadius + 0.5f;

            bool equal = a.CompareTo(b);

            Assert.False(equal);
        }

        /// <summary>
        ///     Tests that compare to returns false when the mass data differs
        /// </summary>
        [Fact]
        public void CompareTo_DifferentMassData_ReturnsFalse()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(0, 1)
            };
            PolygonShape a = new PolygonShape(vertices, 1.0f);
            PolygonShape b = new PolygonShape(vertices, 1.0f);
            b.GetDensity = 2.0f;

            bool equal = a.CompareTo(b);

            Assert.False(equal);
        }
    }
}
