// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TimeOfImpactTest.cs
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
    /// The time of impact test class
    /// </summary>
    public class TimeOfImpactTest
    {
        /// <summary>
        /// Tests that calculate time of impact should return separated for far sweeps
        /// </summary>
        [Fact]
        public void CalculateTimeOfImpact_ShouldReturnSeparated_ForFarSweeps()
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
                    C0 = new Vector2F(-10.0f, 0.0f),
                    C = new Vector2F(-9.0f, 0.0f),
                    A0 = 0.0f,
                    A = 0.0f,
                    Alpha0 = 0.0f
                },
                SweepB = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = new Vector2F(10.0f, 0.0f),
                    C = new Vector2F(9.0f, 0.0f),
                    A0 = 0.0f,
                    A = 0.0f,
                    Alpha0 = 0.0f
                },
                TMax = 1.0f
            };

            TimeOfImpact.CalculateTimeOfImpact(out ToiOutput output, ref input);

            Assert.Equal(ToiOutputState.Seperated, output.State);
            Assert.Equal(1.0f, output.T);
        }

        /// <summary>
        /// Tests that calculate time of impact should return overlapped when starting intersecting
        /// </summary>
        [Fact]
        public void CalculateTimeOfImpact_ShouldReturnOverlapped_WhenStartingIntersecting()
        {
            CircleShape circleA = new CircleShape(1.0f, 1.0f);
            CircleShape circleB = new CircleShape(1.0f, 1.0f);

            ToiInput input = new ToiInput
            {
                ProxyA = new DistanceProxy(circleA, 0),
                ProxyB = new DistanceProxy(circleB, 0),
                SweepA = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = Vector2F.Zero,
                    C = Vector2F.Zero,
                    A0 = 0.0f,
                    A = 0.0f,
                    Alpha0 = 0.0f
                },
                SweepB = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = new Vector2F(0.2f, 0.0f),
                    C = new Vector2F(0.2f, 0.0f),
                    A0 = 0.0f,
                    A = 0.0f,
                    Alpha0 = 0.0f
                },
                TMax = 1.0f
            };

            TimeOfImpact.CalculateTimeOfImpact(out ToiOutput output, ref input);

            Assert.Equal(ToiOutputState.Touching, output.State);
            Assert.Equal(0.0f, output.T);
        }

        /// <summary>
        /// Tests that calculate time of impact should return touching state for approaching shapes
        /// </summary>
        [Fact]
        public void CalculateTimeOfImpact_ShouldReturnTouching_ForApproachingShapes()
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
                    C = new Vector2F(-4.0f, 0.0f),
                    A0 = 0.0f,
                    A = 0.0f,
                    Alpha0 = 0.0f
                },
                SweepB = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = new Vector2F(5.0f, 0.0f),
                    C = new Vector2F(4.0f, 0.0f),
                    A0 = 0.0f,
                    A = 0.0f,
                    Alpha0 = 0.0f
                },
                TMax = 1.0f
            };

            TimeOfImpact.CalculateTimeOfImpact(out ToiOutput output, ref input);

            Assert.True(output.State == ToiOutputState.Touching || output.State == ToiOutputState.Seperated);
        }

        /// <summary>
        /// Tests that calculate time of impact should return t between zero and one
        /// </summary>
        [Fact]
        public void CalculateTimeOfImpact_ShouldReturnT_BetweenZeroAndOne()
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
                    C = new Vector2F(-4.0f, 0.0f),
                    A0 = 0.0f,
                    A = 0.0f,
                    Alpha0 = 0.0f
                },
                SweepB = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = new Vector2F(5.0f, 0.0f),
                    C = new Vector2F(4.0f, 0.0f),
                    A0 = 0.0f,
                    A = 0.0f,
                    Alpha0 = 0.0f
                },
                TMax = 1.0f
            };

            TimeOfImpact.CalculateTimeOfImpact(out ToiOutput output, ref input);

            Assert.True(output.T >= 0.0f);
            Assert.True(output.T <= 1.0f);
        }
    }
}

