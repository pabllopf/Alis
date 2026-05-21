// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SimplexTest.cs
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
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    /// The simplex test class
    /// </summary>
    public class SimplexTest
    {
        /// <summary>
        /// Tests that get search direction with single vertex should negate vertex
        /// </summary>
        [Fact]
        public void GetSearchDirection_WithSingleVertex_ShouldNegateVertex()
        {
            Simplex simplex = new Simplex
            {
                Count = 1,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(2.0f, -3.0f) };

            Vector2F direction = simplex.GetSearchDirection();

            Assert.Equal(new Vector2F(-2.0f, 3.0f), direction);
        }

        /// <summary>
        /// Tests that solve 2 should reduce to closest vertex when origin outside segment
        /// </summary>
        [Fact]
        public void Solve2_ShouldReduceToClosestVertex_WhenOriginOutsideSegment()
        {
            Simplex simplex = new Simplex
            {
                Count = 2,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(5.0f, 0.0f) };
            simplex.V[1] = new SimplexVertex { W = new Vector2F(7.0f, 0.0f) };

            simplex.Solve2();

            Assert.Equal(1, simplex.Count);
        }

        /// <summary>
        /// Tests that get metric with two points should return segment length
        /// </summary>
        [Fact]
        public void GetMetric_WithTwoPoints_ShouldReturnSegmentLength()
        {
            Simplex simplex = new Simplex
            {
                Count = 2,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(0.0f, 0.0f) };
            simplex.V[1] = new SimplexVertex { W = new Vector2F(3.0f, 4.0f) };

            float metric = simplex.GetMetric();

            Assert.Equal(5.0f, metric);
        }

        /// <summary>
        /// Tests that get witness points with single point should return stored points
        /// </summary>
        [Fact]
        public void GetWitnessPoints_WithSinglePoint_ShouldReturnStoredPoints()
        {
            Simplex simplex = new Simplex
            {
                Count = 1,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex
            {
                Wa = new Vector2F(1.0f, 2.0f),
                Wb = new Vector2F(3.0f, 4.0f)
            };

            simplex.GetWitnessPoints(out Vector2F pointA, out Vector2F pointB);

            Assert.Equal(new Vector2F(1.0f, 2.0f), pointA);
            Assert.Equal(new Vector2F(3.0f, 4.0f), pointB);
        }
    }
}

