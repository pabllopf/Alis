// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PolygonShapeExecutionTests.cs
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
    ///     Exercises the ray-cast miss and AABB upper-bound paths of <see cref="PolygonShape" />.
    /// </summary>
    public class PolygonShapeExecutionTests
    {
        /// <summary>
        ///     Tests that a ray cast that misses the polygon returns false.
        /// </summary>
        [Fact]
        public void RayCast_WithMissedRay_ReturnsFalse()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(4f, 0f),
                new Vector2F(4f, 4f),
                new Vector2F(0f, 4f)
            });
            PolygonShape shape = new PolygonShape(vertices, 1.0f);
            ControllerTransform transform = new ControllerTransform(Vector2F.Zero, 0.0f);
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(2f, 2f),
                Point2 = new Vector2F(2f, 2f),
                MaxFraction = 1.0f
            };

            bool hit = shape.RayCast(out RayCastOutput output, ref input, ref transform, 0);

            Assert.False(hit);
        }

        /// <summary>
        ///     Tests that computing the aabb with a rotated polygon updates the upper bounds.
        /// </summary>
        [Fact]
        public void ComputeAabb_WithRotatedPolygon_UpdatesUpperBounds()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(4f, 0f),
                new Vector2F(4f, 4f),
                new Vector2F(0f, 4f)
            });
            PolygonShape shape = new PolygonShape(vertices, 1.0f);
            ControllerTransform transform = new ControllerTransform(Vector2F.Zero, new Complex(0.7071f, 0.7071f));

            shape.ComputeAabb(out Aabb aabb, ref transform, 0);

            Assert.True(aabb.UpperBound.X > 2.0f);
            Assert.True(aabb.UpperBound.Y > 2.0f);
        }
    }
}
