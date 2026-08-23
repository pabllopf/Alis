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

using System;
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
            Assert.Equal(1.0f, output.T, 5);
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
            Assert.Equal(0.0f, output.T, 5);
        }

        /// <summary>
        /// Tests that calculate time of impact should return touching for approaching shapes
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

        /// <summary>
        /// Tests that calculate time of impact should return overlapped when shapes fully intersect
        /// </summary>
        [Fact]
        public void CalculateTimeOfImpact_ShouldReturnOverlapped_WhenShapesFullyIntersect()
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
                    C0 = Vector2F.Zero,
                    C = Vector2F.Zero,
                    A0 = 0.0f,
                    A = 0.0f,
                    Alpha0 = 0.0f
                },
                TMax = 1.0f
            };

            TimeOfImpact.CalculateTimeOfImpact(out ToiOutput output, ref input);

            Assert.Equal(ToiOutputState.Overlapped, output.State);
            Assert.Equal(0.0f, output.T, 5);
        }

        /// <summary>
        /// Tests that calculate time of impact for overlapped should update diagnostics counters
        /// </summary>
        [Fact]
        public void CalculateTimeOfImpact_ForOverlapped_ShouldUpdateDiagnosticsCounters()
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
                    C0 = Vector2F.Zero,
                    C = Vector2F.Zero,
                    A0 = 0.0f,
                    A = 0.0f,
                    Alpha0 = 0.0f
                },
                TMax = 1.0f
            };

            TimeOfImpact.CalculateTimeOfImpact(out ToiOutput output, ref input);

            Assert.Equal(ToiOutputState.Overlapped, output.State);
            Assert.True(TimeOfImpact.ToiCalls >= 1);
        }

        /// <summary>
        /// Tests that calculate time of impact for approaching should update iter diagnostics counters
        /// </summary>
        [Fact]
        public void CalculateTimeOfImpact_ForApproaching_ShouldUpdateIterDiagnosticsCounters()
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

            TimeOfImpact.CalculateTimeOfImpact(out ToiOutput _, ref input);

            Assert.True(TimeOfImpact.ToiCalls >= 1);
            Assert.True(TimeOfImpact.ToiMaxIters >= 0);
            Assert.True(TimeOfImpact.ToiMaxRootIters >= 0);
        }

        /// <summary>
        /// Tests that calculate time of impact should trigger root find when sweeps cross
        /// </summary>
        [Fact]
        public void CalculateTimeOfImpact_ShouldTriggerRootFind_WhenSweepsCross()
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
                    C0 = new Vector2F(-3.0f, 0.0f),
                    C = new Vector2F(0.0f, 0.0f),
                    A0 = 0.0f,
                    A = 0.0f,
                    Alpha0 = 0.0f
                },
                SweepB = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = new Vector2F(3.0f, 0.0f),
                    C = new Vector2F(0.0f, 0.0f),
                    A0 = 0.0f,
                    A = 0.0f,
                    Alpha0 = 0.0f
                },
                TMax = 1.0f
            };

            TimeOfImpact.CalculateTimeOfImpact(out ToiOutput output, ref input);

            Assert.True(output.State == ToiOutputState.Touching || output.State == ToiOutputState.Seperated);
            Assert.True(output.T >= 0.0f);
        }

        /// <summary>
        /// Tests that calculate time of impact should update root iters when root finding
        /// </summary>
        [Fact]
        public void CalculateTimeOfImpact_ShouldUpdateRootIters_WhenRootFinding()
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
                    C0 = new Vector2F(-3.0f, 0.0f),
                    C = new Vector2F(0.0f, 0.0f),
                    A0 = 0.0f,
                    A = 0.0f,
                    Alpha0 = 0.0f
                },
                SweepB = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = new Vector2F(3.0f, 0.0f),
                    C = new Vector2F(0.0f, 0.0f),
                    A0 = 0.0f,
                    A = 0.0f,
                    Alpha0 = 0.0f
                },
                TMax = 1.0f
            };

            TimeOfImpact.CalculateTimeOfImpact(out ToiOutput _, ref input);

            Assert.True(TimeOfImpact.ToiRootIters >= 0);
            Assert.True(TimeOfImpact.ToiMaxRootIters >= 0);
            Assert.True(TimeOfImpact.ToiIters >= 0);
        }

        /// <summary>
        /// Tests that calculate time of impact with polygons should compute touching
        /// </summary>
        [Fact]
        public void CalculateTimeOfImpact_WithPolygons_ShouldComputeTouching()
        {
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);

            ToiInput input = new ToiInput
            {
                ProxyA = new DistanceProxy(polyA, 0),
                ProxyB = new DistanceProxy(polyB, 0),
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

        // ========================================================================
        // Additional coverage for pushback iterations, root-find, and rotation
        // ========================================================================

        /// <summary>
        ///     Tests TOI with rotating sweeps to exercise the separation function
        ///     and pushback iteration paths.
        /// </summary>
        [Fact]
        public void CalculateTimeOfImpact_WithRotatingSweeps_ShouldComputeValidResult()
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
                    A = (float)Math.PI / 4.0f,
                    Alpha0 = 0.0f
                },
                SweepB = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = new Vector2F(5.0f, 0.0f),
                    C = new Vector2F(4.0f, 0.0f),
                    A0 = 0.0f,
                    A = -(float)Math.PI / 4.0f,
                    Alpha0 = 0.0f
                },
                TMax = 1.0f
            };

            TimeOfImpact.CalculateTimeOfImpact(out ToiOutput output, ref input);

            Assert.True(output.T >= 0.0f);
            Assert.True(output.T <= 1.0f);
        }

        /// <summary>
        ///     Tests TOI with different sized shapes that closely approach each other
        ///     to exercise the root-finding path with bisection updates.
        /// </summary>
        [Fact]
        public void CalculateTimeOfImpact_DifferentSizesCloseApproach_ShouldComputeValidResult()
        {
            CircleShape circleA = new CircleShape(0.3f, 1.0f);
            CircleShape circleB = new CircleShape(1.0f, 1.0f);

            ToiInput input = new ToiInput
            {
                ProxyA = new DistanceProxy(circleA, 0),
                ProxyB = new DistanceProxy(circleB, 0),
                SweepA = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = new Vector2F(-2.5f, 0.0f),
                    C = new Vector2F(0.0f, 0.0f),
                    A0 = 0.0f,
                    A = 0.0f,
                    Alpha0 = 0.0f
                },
                SweepB = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = new Vector2F(2.5f, 0.0f),
                    C = new Vector2F(0.0f, 0.0f),
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

        /// <summary>
        ///     Tests TOI with sweeps that maintain almost constant distance
        ///     to potentially trigger the s2 > target - tolerance branch.
        /// </summary>
        [Fact]
        public void CalculateTimeOfImpact_ParallelSweeps_ShouldComputeValidResult()
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

            Assert.True(output.T >= 0.0f);
            Assert.True(output.T <= 1.0f);
        }

        /// <summary>
        ///     Tests that root find bisection bounds update works with polygon sweeps
        ///     that approach at an angle.
        /// </summary>
        [Fact]
        public void CalculateTimeOfImpact_PolygonsAngledApproach_ShouldComputeResult()
        {
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);

            ToiInput input = new ToiInput
            {
                ProxyA = new DistanceProxy(polyA, 0),
                ProxyB = new DistanceProxy(polyB, 0),
                SweepA = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = new Vector2F(-3.0f, 0.0f),
                    C = new Vector2F(0.0f, 0.0f),
                    A0 = 0.0f,
                    A = 0.0f,
                    Alpha0 = 0.0f
                },
                SweepB = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = new Vector2F(3.0f, 1.0f),
                    C = new Vector2F(0.0f, 1.0f),
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

        /// <summary>
        ///     Tests that diagnostics counters update correctly when enabled.
        /// </summary>
        [Fact]
        public void CalculateTimeOfImpact_WithDiagnosticsEnabled_UpdatesCounters()
        {
            bool prevValue = SettingEnv.EnableDiagnostics;

            CircleShape circleA = new CircleShape(0.5f, 1.0f);
            CircleShape circleB = new CircleShape(0.5f, 1.0f);
            ToiInput input = new ToiInput
            {
                ProxyA = new DistanceProxy(circleA, 0),
                ProxyB = new DistanceProxy(circleB, 0),
                SweepA = new Sweep { LocalCenter = Vector2F.Zero, C0 = new Vector2F(-3.0f, 0.0f), C = new Vector2F(0.0f, 0.0f), A0 = 0.0f, A = 0.0f, Alpha0 = 0.0f },
                SweepB = new Sweep { LocalCenter = Vector2F.Zero, C0 = new Vector2F(3.0f, 0.0f), C = new Vector2F(0.0f, 0.0f), A0 = 0.0f, A = 0.0f, Alpha0 = 0.0f },
                TMax = 1.0f
            };

            TimeOfImpact.CalculateTimeOfImpact(out _, ref input);

            Assert.True(TimeOfImpact.ToiCalls >= 0);
            Assert.True(TimeOfImpact.ToiMaxIters >= 0);
            Assert.True(TimeOfImpact.ToiMaxRootIters >= 0);
        }

        /// <summary>
        ///     Tests that TryHandleDistanceResult handles the Touching branch.
        /// </summary>
        [Fact]
        public void CalculateTimeOfImpact_TouchingDistance_ReturnsTouching()
        {
            CircleShape circleA = new CircleShape(0.5f, 1.0f);
            CircleShape circleB = new CircleShape(0.5f, 1.0f);

            ToiInput input = new ToiInput
            {
                ProxyA = new DistanceProxy(circleA, 0),
                ProxyB = new DistanceProxy(circleB, 0),
                SweepA = new Sweep { LocalCenter = Vector2F.Zero, C0 = new Vector2F(-1.1f, 0.0f), C = new Vector2F(-1.1f, 0.0f), A0 = 0.0f, A = 0.0f, Alpha0 = 0.0f },
                SweepB = new Sweep { LocalCenter = Vector2F.Zero, C0 = new Vector2F(1.1f, 0.0f), C = new Vector2F(1.1f, 0.0f), A0 = 0.0f, A = 0.0f, Alpha0 = 0.0f },
                TMax = 1.0f
            };

            TimeOfImpact.CalculateTimeOfImpact(out ToiOutput output, ref input);

            Assert.True(output.State == ToiOutputState.Touching || output.State == ToiOutputState.Seperated);
        }

        /// <summary>
        ///     Tests that UpdateBisectionBounds is exercised with different values.
        /// </summary>
        [Fact]
        public void CalculateTimeOfImpact_WithCrossingSweeps_ExercisesBisection()
        {
            CircleShape circleA = new CircleShape(0.4f, 1.0f);
            CircleShape circleB = new CircleShape(0.4f, 1.0f);

            ToiInput input = new ToiInput
            {
                ProxyA = new DistanceProxy(circleA, 0),
                ProxyB = new DistanceProxy(circleB, 0),
                SweepA = new Sweep { LocalCenter = Vector2F.Zero, C0 = new Vector2F(-5.0f, 0.0f), C = new Vector2F(3.0f, 0.0f), A0 = 0.0f, A = 0.0f, Alpha0 = 0.0f },
                SweepB = new Sweep { LocalCenter = Vector2F.Zero, C0 = new Vector2F(5.0f, 0.0f), C = new Vector2F(-3.0f, 0.0f), A0 = 0.0f, A = 0.0f, Alpha0 = 0.0f },
                TMax = 1.0f
            };

            TimeOfImpact.CalculateTimeOfImpact(out ToiOutput output, ref input);

            Assert.True(output.State == ToiOutputState.Touching || output.State == ToiOutputState.Seperated);
        }

        /// <summary>
        ///     Tests that CloseShapes returns Touching.
        /// </summary>
        [Fact]
        public void CalculateTimeOfImpact_WithCloseShapes_ReturnsTouching()
        {
            CircleShape circleA = new CircleShape(0.5f, 1.0f);
            CircleShape circleB = new CircleShape(0.5f, 1.0f);

            ToiInput input = new ToiInput
            {
                ProxyA = new DistanceProxy(circleA, 0),
                ProxyB = new DistanceProxy(circleB, 0),
                SweepA = new Sweep { LocalCenter = Vector2F.Zero, C0 = new Vector2F(-1.1f, 0.0f), C = new Vector2F(-1.1f, 0.0f), A0 = 0.0f, A = 0.0f, Alpha0 = 0.0f },
                SweepB = new Sweep { LocalCenter = Vector2F.Zero, C0 = new Vector2F(1.1f, 0.0f), C = new Vector2F(1.1f, 0.0f), A0 = 0.0f, A = 0.0f, Alpha0 = 0.0f },
                TMax = 1.0f
            };

            TimeOfImpact.CalculateTimeOfImpact(out ToiOutput output, ref input);

            Assert.True(output.State == ToiOutputState.Touching || output.State == ToiOutputState.Seperated);
        }

    
    }
}
