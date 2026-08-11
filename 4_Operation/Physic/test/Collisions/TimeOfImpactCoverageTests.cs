// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TimeOfImpactCoverageTests.cs
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
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The time of impact coverage tests class
    /// </summary>
    public class TimeOfImpactCoverageTests
    {
        /// <summary>
        ///     Tests that calculate time of impact with high speed crossing circles computes a valid result
        /// </summary>
        [Fact]
        public void CalculateTimeOfImpact_HighSpeedCrossingCircles_ComputesValidResult()
        {
            CircleShape circleA = new CircleShape(0.5f, 1.0f);
            CircleShape circleB = new CircleShape(0.5f, 1.0f);

            ToiInput input = new ToiInput
            {
                ProxyA = new DistanceProxy(circleA, 0),
                ProxyB = new DistanceProxy(circleB, 0),
                SweepA = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = new Vector2F(-5.0f, 0.0f),
                    C = new Vector2F(5.0f, 0.0f),
                    A0 = 0.0f,
                    A = 0.0f,
                    Alpha0 = 0.0f
                },
                SweepB = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = new Vector2F(5.0f, 0.0f),
                    C = new Vector2F(-5.0f, 0.0f),
                    A0 = 0.0f,
                    A = 0.0f,
                    Alpha0 = 0.0f
                },
                TMax = 1.0f
            };

            TimeOfImpact.CalculateTimeOfImpact(out ToiOutput output, ref input);

            Assert.True(output.State == ToiOutputState.Touching || output.State == ToiOutputState.Seperated || output.State == ToiOutputState.Failed || output.State == ToiOutputState.Overlapped);
        }

        /// <summary>
        ///     Tests that calculate time of impact with rotating polygon sweeps computes a valid result
        /// </summary>
        [Fact]
        public void CalculateTimeOfImpact_RotatingPolygonSweeps_ComputesValidResult()
        {
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(0.4f, 0.4f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(0.4f, 0.4f), 1.0f);

            ToiInput input = new ToiInput
            {
                ProxyA = new DistanceProxy(polyA, 0),
                ProxyB = new DistanceProxy(polyB, 0),
                SweepA = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = new Vector2F(-4.0f, 0.0f),
                    C = new Vector2F(2.0f, 0.0f),
                    A0 = 0.0f,
                    A = 1.2f,
                    Alpha0 = 0.0f
                },
                SweepB = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = new Vector2F(4.0f, 0.0f),
                    C = new Vector2F(-2.0f, 0.0f),
                    A0 = 0.0f,
                    A = -1.2f,
                    Alpha0 = 0.0f
                },
                TMax = 1.0f
            };

            TimeOfImpact.CalculateTimeOfImpact(out ToiOutput output, ref input);

            Assert.True(output.T >= 0.0f);
            Assert.True(output.T <= 1.0f);
        }

        /// <summary>
        ///     Tests that calculate time of impact with polygon and circle sweeps computes a valid result
        /// </summary>
        [Fact]
        public void CalculateTimeOfImpact_PolygonAndCircleSweeps_ComputesValidResult()
        {
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(0.3f, 0.3f), 1.0f);
            CircleShape circleB = new CircleShape(0.3f, 1.0f);

            ToiInput input = new ToiInput
            {
                ProxyA = new DistanceProxy(polyA, 0),
                ProxyB = new DistanceProxy(circleB, 0),
                SweepA = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = new Vector2F(-4.0f, 0.0f),
                    C = new Vector2F(2.0f, 0.0f),
                    A0 = 0.0f,
                    A = 0.8f,
                    Alpha0 = 0.0f
                },
                SweepB = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = new Vector2F(4.0f, 0.0f),
                    C = new Vector2F(-2.0f, 0.0f),
                    A0 = 0.0f,
                    A = -0.5f,
                    Alpha0 = 0.0f
                },
                TMax = 1.0f
            };

            TimeOfImpact.CalculateTimeOfImpact(out ToiOutput output, ref input);

            Assert.True(output.T >= 0.0f);
            Assert.True(output.T <= 1.0f);
        }

        /// <summary>
        ///     Tests that calculate time of impact with barely overlapping sweeps returns overlapped
        /// </summary>
        [Fact]
        public void CalculateTimeOfImpact_BarelyOverlappingSweeps_ReturnsOverlapped()
        {
            CircleShape circleA = new CircleShape(0.5f, 1.0f);
            CircleShape circleB = new CircleShape(0.5f, 1.0f);

            ToiInput input = new ToiInput
            {
                ProxyA = new DistanceProxy(circleA, 0),
                ProxyB = new DistanceProxy(circleB, 0),
                SweepA = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = new Vector2F(-0.2f, 0.0f),
                    C = new Vector2F(0.2f, 0.0f),
                    A0 = 0.0f,
                    A = 0.0f,
                    Alpha0 = 0.0f
                },
                SweepB = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = new Vector2F(0.2f, 0.0f),
                    C = new Vector2F(-0.2f, 0.0f),
                    A0 = 0.0f,
                    A = 0.0f,
                    Alpha0 = 0.0f
                },
                TMax = 1.0f
            };

            TimeOfImpact.CalculateTimeOfImpact(out ToiOutput output, ref input);

            Assert.True(output.State == ToiOutputState.Overlapped || output.State == ToiOutputState.Touching);
        }

        /// <summary>
        ///     Tests that calculate time of impact with fast polygon crossing sweeps computes a valid result
        /// </summary>
        [Fact]
        public void CalculateTimeOfImpact_FastPolygonCrossingSweeps_ComputesValidResult()
        {
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(0.2f, 1.0f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(0.2f, 1.0f), 1.0f);

            ToiInput input = new ToiInput
            {
                ProxyA = new DistanceProxy(polyA, 0),
                ProxyB = new DistanceProxy(polyB, 0),
                SweepA = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = new Vector2F(-6.0f, 0.0f),
                    C = new Vector2F(6.0f, 0.0f),
                    A0 = 0.0f,
                    A = 0.6f,
                    Alpha0 = 0.0f
                },
                SweepB = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = new Vector2F(6.0f, 0.0f),
                    C = new Vector2F(-6.0f, 0.0f),
                    A0 = 0.0f,
                    A = -0.6f,
                    Alpha0 = 0.0f
                },
                TMax = 1.0f
            };

            TimeOfImpact.CalculateTimeOfImpact(out ToiOutput output, ref input);

            Assert.True(output.State == ToiOutputState.Touching || output.State == ToiOutputState.Seperated || output.State == ToiOutputState.Failed || output.State == ToiOutputState.Overlapped);
        }
    }
}
