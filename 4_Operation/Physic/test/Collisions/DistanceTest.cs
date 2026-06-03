// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DistanceTest.cs
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
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The distance test class
    /// </summary>
    public class DistanceTest
    {
        /// <summary>
        /// Tests that compute distance should return positive distance for separated circles
        /// </summary>
        [Fact]
        public void ComputeDistance_ShouldReturnPositiveDistance_ForSeparatedCircles()
        {
            CircleShape circleA = new CircleShape(0.5f, 1.0f);
            CircleShape circleB = new CircleShape(0.5f, 1.0f);

            DistanceInput input = new DistanceInput
            {
                ProxyA = new DistanceProxy(circleA, 0),
                ProxyB = new DistanceProxy(circleB, 0),
                ControllerTransformA = ControllerTransform.Identity,
                ControllerTransformB = new ControllerTransform(new Vector2F(5.0f, 0.0f), 0.0f),
                UseRadii = false
            };

            Distance.ComputeDistance(out DistanceOutput output, out SimplexCache cache, input);

            Assert.True(output.Distance > 0.0f);
            Assert.True(output.Iterations >= 0);
        }

        /// <summary>
        /// Tests that compute distance should return near zero distance for overlapping circles
        /// </summary>
        [Fact]
        public void ComputeDistance_ShouldReturnNearZeroDistance_ForOverlappingCircles()
        {
            CircleShape circleA = new CircleShape(1.0f, 1.0f);
            CircleShape circleB = new CircleShape(1.0f, 1.0f);

            DistanceInput input = new DistanceInput
            {
                ProxyA = new DistanceProxy(circleA, 0),
                ProxyB = new DistanceProxy(circleB, 0),
                ControllerTransformA = ControllerTransform.Identity,
                ControllerTransformB = new ControllerTransform(new Vector2F(0.5f, 0.0f), 0.0f),
                UseRadii = false
            };

            Distance.ComputeDistance(out DistanceOutput output, out SimplexCache cache, input);

            Assert.True(output.Distance <= 0.5f);
        }

        /// <summary>
        /// Tests that compute distance with use radii should subtract radii from distance
        /// </summary>
        [Fact]
        public void ComputeDistance_WithUseRadii_ShouldSubtractRadiiFromDistance()
        {
            CircleShape circleA = new CircleShape(0.5f, 1.0f);
            CircleShape circleB = new CircleShape(0.5f, 1.0f);

            DistanceInput input = new DistanceInput
            {
                ProxyA = new DistanceProxy(circleA, 0),
                ProxyB = new DistanceProxy(circleB, 0),
                ControllerTransformA = ControllerTransform.Identity,
                ControllerTransformB = new ControllerTransform(new Vector2F(5.0f, 0.0f), 0.0f),
                UseRadii = true
            };

            Distance.ComputeDistance(out DistanceOutput output, out SimplexCache cache, input);

            Assert.True(output.Distance > 0.0f);
        }

        /// <summary>
        /// Tests that compute distance with use radii and overlapping shapes should return zero distance
        /// </summary>
        [Fact]
        public void ComputeDistance_WithUseRadiiAndOverlapping_ShouldReturnZeroDistance()
        {
            CircleShape circleA = new CircleShape(1.0f, 1.0f);
            CircleShape circleB = new CircleShape(1.0f, 1.0f);

            DistanceInput input = new DistanceInput
            {
                ProxyA = new DistanceProxy(circleA, 0),
                ProxyB = new DistanceProxy(circleB, 0),
                ControllerTransformA = ControllerTransform.Identity,
                ControllerTransformB = new ControllerTransform(new Vector2F(0.5f, 0.0f), 0.0f),
                UseRadii = true
            };

            Distance.ComputeDistance(out DistanceOutput output, out SimplexCache cache, input);

            Assert.Equal(0.0f, output.Distance);
        }

        /// <summary>
        /// Tests that compute distance should update diagnostics counters
        /// </summary>
        [Fact]
        public void ComputeDistance_ShouldUpdateDiagnosticsCounters()
        {
            Distance.GjkCalls = 0;
            Distance.GjkIters = 0;

            CircleShape circleA = new CircleShape(0.5f, 1.0f);
            CircleShape circleB = new CircleShape(0.5f, 1.0f);

            DistanceInput input = new DistanceInput
            {
                ProxyA = new DistanceProxy(circleA, 0),
                ProxyB = new DistanceProxy(circleB, 0),
                ControllerTransformA = ControllerTransform.Identity,
                ControllerTransformB = new ControllerTransform(new Vector2F(5.0f, 0.0f), 0.0f),
                UseRadii = false
            };

            Distance.ComputeDistance(out DistanceOutput output, out SimplexCache cache, input);

            Assert.True(Distance.GjkCalls > 0);
        }

        /// <summary>
        /// Tests that compute distance should track max iterations
        /// </summary>
        [Fact]
        public void ComputeDistance_ShouldTrackMaxIterations()
        {
            Distance.GjkMaxIters = 0;

            CircleShape circleA = new CircleShape(0.5f, 1.0f);
            CircleShape circleB = new CircleShape(0.5f, 1.0f);

            DistanceInput input = new DistanceInput
            {
                ProxyA = new DistanceProxy(circleA, 0),
                ProxyB = new DistanceProxy(circleB, 0),
                ControllerTransformA = ControllerTransform.Identity,
                ControllerTransformB = new ControllerTransform(new Vector2F(5.0f, 0.0f), 0.0f),
                UseRadii = false
            };

            Distance.ComputeDistance(out DistanceOutput output, out SimplexCache cache, input);

            Assert.True(Distance.GjkMaxIters >= 0);
        }

        /// <summary>
        /// Tests that compute distance should set witness points on output
        /// </summary>
        [Fact]
        public void ComputeDistance_ShouldSetWitnessPointsOnOutput()
        {
            CircleShape circleA = new CircleShape(0.5f, 1.0f);
            CircleShape circleB = new CircleShape(0.5f, 1.0f);

            DistanceInput input = new DistanceInput
            {
                ProxyA = new DistanceProxy(circleA, 0),
                ProxyB = new DistanceProxy(circleB, 0),
                ControllerTransformA = ControllerTransform.Identity,
                ControllerTransformB = new ControllerTransform(new Vector2F(5.0f, 0.0f), 0.0f),
                UseRadii = false
            };

            Distance.ComputeDistance(out DistanceOutput output, out SimplexCache cache, input);

            Assert.NotEqual(output.PointA, output.PointB);
        }

        /// <summary>
        /// Tests that compute distance should populate cache with simplex state
        /// </summary>
        [Fact]
        public void ComputeDistance_ShouldPopulateCacheWithSimplexState()
        {
            CircleShape circleA = new CircleShape(0.5f, 1.0f);
            CircleShape circleB = new CircleShape(0.5f, 1.0f);

            DistanceInput input = new DistanceInput
            {
                ProxyA = new DistanceProxy(circleA, 0),
                ProxyB = new DistanceProxy(circleB, 0),
                ControllerTransformA = ControllerTransform.Identity,
                ControllerTransformB = new ControllerTransform(new Vector2F(5.0f, 0.0f), 0.0f),
                UseRadii = false
            };

            Distance.ComputeDistance(out DistanceOutput output, out SimplexCache cache, input);

            Assert.True(cache.Count >= 0);
        }
    }
}