// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TimeOfImpactDeepCoverageTests.cs
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
    ///     Deep coverage tests for <see cref="TimeOfImpact"/> that exercise the
    ///     non-convergence, deep-penetration and non-finite numeric guard paths
    ///     of the pushed-back and root-finding iterations.
    /// </summary>
    public class TimeOfImpactDeepCoverageTests
    {
        /// <summary>
        ///     A rotating elongated polygon sweeping across a smaller circle forces the
        ///     outer refinement loop to exhaust its maximum of 20 iterations without
        ///     ever returning a touching/separated/solved result. The solver must stop
        ///     and report <see cref="ToiOutputState.Failed"/> at the end of the interval.
        /// </summary>
        [Fact]
        public void CalculateTimeOfImpact_WhenOuterRefinementExhaustsIterations_ReturnsFailed()
        {
            // Arrange
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(0.16464213f, 1.248905f), 1.0f);
            CircleShape circleB = new CircleShape(0.36402512f, 1.0f);

            ToiInput input = new ToiInput
            {
                ProxyA = new DistanceProxy(polyA, 0),
                ProxyB = new DistanceProxy(circleB, 0),
                SweepA = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = new Vector2F(2.7628725f, -0.21295898f),
                    C = new Vector2F(-4.859678f, 3.0342803f),
                    A0 = -2.273467f,
                    A = -2.2759256f,
                    Alpha0 = 0.0f
                },
                SweepB = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = new Vector2F(-4.4850407f, -2.1217678f),
                    C = new Vector2F(-4.6912622f, 1.0961182f),
                    A0 = -1.2687654f,
                    A = 0.61746293f,
                    Alpha0 = 0.0f
                },
                TMax = 0.38558662f
            };

            TimeOfImpact.ToiMaxIters = 0;

            // Act
            TimeOfImpact.CalculateTimeOfImpact(out ToiOutput output, ref input);

            // Assert
            Assert.Equal(ToiOutputState.Failed, output.State);
            Assert.Equal(input.TMax, output.T, 5);
            Assert.Equal(20, TimeOfImpact.ToiMaxIters);
        }

        /// <summary>
        ///     A configuration where, at the current lower bound time, both shapes are
        ///     deeply penetrating along the cached separating axis (the separation is
        ///     below the target minus the tolerance). The push-back loop must report the
        ///     failed state immediately.
        /// </summary>
        [Fact]
        public void CalculateTimeOfImpact_WhenLowerBoundSeparationBelowTarget_ReturnsFailed()
        {
            // Arrange
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(0.35967946f, 1.0583495f), 1.0f);
            CircleShape circleB = new CircleShape(1.6764258f, 1.0f);

            ToiInput input = new ToiInput
            {
                ProxyA = new DistanceProxy(polyA, 0),
                ProxyB = new DistanceProxy(circleB, 0),
                SweepA = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = new Vector2F(0.60026014f, 3.4634476f),
                    C = new Vector2F(-0.08933244f, -5.750021f),
                    A0 = 2.442108f,
                    A = 2.9517143f,
                    Alpha0 = 0.0f
                },
                SweepB = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = new Vector2F(-0.5767907f, 1.529783f),
                    C = new Vector2F(-2.7965093f, -5.1525965f),
                    A0 = 0.016832361f,
                    A = -0.045914624f,
                    Alpha0 = 0.0f
                },
                TMax = 1.3377153f
            };

            TimeOfImpact.ToiMaxIters = 0;

            // Act
            TimeOfImpact.CalculateTimeOfImpact(out ToiOutput output, ref input);

            // Assert
            Assert.Equal(ToiOutputState.Failed, output.State);
            Assert.Equal(0.0f, output.T);
            Assert.True(TimeOfImpact.ToiMaxIters < 20);
        }

        /// <summary>
        ///     A non-finite (NaN) sweep position makes every separation comparison false,
        ///     so neither the push-back loop nor the root finder can converge. The solver
        ///     must terminate through its iterative guard clauses and report failure
        ///     instead of looping forever.
        /// </summary>
        [Fact]
        public void CalculateTimeOfImpact_WhenSweepContainsNaN_TerminatesAndReturnsFailed()
        {
            // Arrange
            CircleShape circleA = new CircleShape(0.5f, 1.0f);
            CircleShape circleB = new CircleShape(0.5f, 1.0f);

            ToiInput input = new ToiInput
            {
                ProxyA = new DistanceProxy(circleA, 0),
                ProxyB = new DistanceProxy(circleB, 0),
                SweepA = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = new Vector2F(float.NaN, 0.0f),
                    C = Vector2F.Zero,
                    A0 = 0.0f,
                    A = 0.0f,
                    Alpha0 = 0.0f
                },
                SweepB = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = new Vector2F(3.0f, 0.0f),
                    C = new Vector2F(2.0f, 0.0f),
                    A0 = 0.0f,
                    A = 0.0f,
                    Alpha0 = 0.0f
                },
                TMax = 1.0f
            };

            TimeOfImpact.ToiMaxIters = 0;
            TimeOfImpact.ToiMaxRootIters = 0;

            // Act
            TimeOfImpact.CalculateTimeOfImpact(out ToiOutput output, ref input);

            // Assert
            Assert.Equal(ToiOutputState.Failed, output.State);
            Assert.Equal(20, TimeOfImpact.ToiMaxIters);
            Assert.Equal(50, TimeOfImpact.ToiMaxRootIters);
        }

        /// <summary>
        ///     An infinite sweep bound makes the separation evaluation non-finite in the
        ///     same way as NaN. The solver must still terminate through its iteration
        ///     guards and report failure.
        /// </summary>
        [Fact]
        public void CalculateTimeOfImpact_WhenSweepContainsInfinity_TerminatesAndReturnsFailed()
        {
            // Arrange
            CircleShape circleA = new CircleShape(0.5f, 1.0f);
            CircleShape circleB = new CircleShape(0.5f, 1.0f);

            ToiInput input = new ToiInput
            {
                ProxyA = new DistanceProxy(circleA, 0),
                ProxyB = new DistanceProxy(circleB, 0),
                SweepA = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = new Vector2F(float.PositiveInfinity, 0.0f),
                    C = Vector2F.Zero,
                    A0 = 0.0f,
                    A = 0.0f,
                    Alpha0 = 0.0f
                },
                SweepB = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = new Vector2F(3.0f, 0.0f),
                    C = new Vector2F(2.0f, 0.0f),
                    A0 = 0.0f,
                    A = 0.0f,
                    Alpha0 = 0.0f
                },
                TMax = 1.0f
            };

            TimeOfImpact.ToiMaxIters = 0;
            TimeOfImpact.ToiMaxRootIters = 0;

            // Act
            TimeOfImpact.CalculateTimeOfImpact(out ToiOutput output, ref input);

            // Assert
            Assert.Equal(ToiOutputState.Failed, output.State);
            Assert.Equal(20, TimeOfImpact.ToiMaxIters);
            Assert.Equal(50, TimeOfImpact.ToiMaxRootIters);
        }
    }
}
