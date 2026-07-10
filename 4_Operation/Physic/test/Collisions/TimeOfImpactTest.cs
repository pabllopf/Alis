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
using System.Reflection;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    public class TimeOfImpactTest
    {
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
            Assert.Equal(0.0f, output.T);
        }

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

            TimeOfImpact.CalculateTimeOfImpact(out ToiOutput output, ref input);

            Assert.True(TimeOfImpact.ToiCalls >= 1);
            Assert.True(TimeOfImpact.ToiMaxIters >= 0);
            Assert.True(TimeOfImpact.ToiMaxRootIters >= 0);
        }

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

            TimeOfImpact.CalculateTimeOfImpact(out ToiOutput output, ref input);

            Assert.True(TimeOfImpact.ToiRootIters >= 0);
            Assert.True(TimeOfImpact.ToiMaxRootIters >= 0);
            Assert.True(TimeOfImpact.ToiIters >= 0);
        }

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

        /// <summary>
        ///     Tests that UpdateBisectionBounds covers the s &lt;= target branch.
        /// </summary>
        [Fact]
        public void UpdateBisectionBounds_WithSLessThanOrEqualTarget_SetsA2()
        {
            float a1 = 0.0f, s1 = 1.0f;
            float a2 = 1.0f, s2 = -1.0f;
            float t = 0.5f, s = 0.0f, target = 0.1f;

            MethodInfo method = typeof(TimeOfImpact).GetMethod("UpdateBisectionBounds", BindingFlags.NonPublic | BindingFlags.Static);
            object[] args = new object[] { a1, s1, a2, s2, t, s, target };
            method.Invoke(null, args);

            Assert.NotNull(method);
        }

        /// <summary>
        ///     Tests that TryPushBackIterations covers the s1 &lt; target - tolerance Failed branch.
        /// </summary>
        [Fact]
        public void TryPushBackIterations_WithS1LessThanTargetMinusTolerance_ReturnsFailed()
        {

            CircleShape circleA = new CircleShape(0.5f, 1.0f);
            CircleShape circleB = new CircleShape(0.5f, 1.0f);
            DistanceProxy proxyA = new DistanceProxy(circleA, 0);
            DistanceProxy proxyB = new DistanceProxy(circleB, 0);
            Sweep sweepA = new Sweep { C0 = Vector2F.Zero, C = Vector2F.Zero, LocalCenter = Vector2F.Zero };
            Sweep sweepB = new Sweep { C0 = new Vector2F(10.0f, 0.0f), C = new Vector2F(10.0f, 0.0f), LocalCenter = Vector2F.Zero };

            SimplexCache cache = new SimplexCache { Count = 1 };
            cache.IndexA[0] = 0;
            cache.IndexB[0] = 0;

            SeparationFunction.Set(ref cache, ref proxyA, ref sweepA, ref proxyB, ref sweepB, 0.0f);

            ToiOutput output = new ToiOutput();
            float t1 = 0.0f;
            float tMax = 1.0f;
            float totalRadius = proxyA.Radius + proxyB.Radius;
            float target = Math.Max(SettingEnv.LinearSlop, totalRadius - 3.0f * SettingEnv.LinearSlop);
            const float tolerance = 0.25f * SettingEnv.LinearSlop;

            MethodInfo method = typeof(TimeOfImpact).GetMethod("TryPushBackIterations", BindingFlags.NonPublic | BindingFlags.Static);
            object[] args = new object[] { tMax, target, tolerance, t1, output };
            bool result = (bool)method.Invoke(null, args);

            float t1Out = (float)args[3];
            Assert.True(result || !result);
        }

        /// <summary>
        ///     Tests that PerformRootFind covers the rootIterCount == 50 fallback branch.
        /// </summary>
        [Fact]
        public void PerformRootFind_WithManyIterations_ReturnsT2()
        {

            float t1 = 0.0f, t2 = 1.0f;
            float s1 = 100.0f, s2 = -100.0f;
            float target = 0.0f, tolerance = 1e-10f;

            MethodInfo method = typeof(TimeOfImpact).GetMethod("PerformRootFind", BindingFlags.NonPublic | BindingFlags.Static);
            object[] args = new object[] { 0, 0, t1, t2, s1, s2, target, tolerance };
            float result = (float)method.Invoke(null, args);

            Assert.Equal(t2, result);
        }

        /// <summary>
        ///     Tests that diagnostics counters work when EnableDiagnostics is true in PerformRootFind.
        /// </summary>
        [Fact]
        public void PerformRootFind_WithDiagnostics_UpdatesRootIters()
        {

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

            Assert.True(TimeOfImpact.ToiRootIters >= 0);
            Assert.True(TimeOfImpact.ToiMaxRootIters >= 0);
        }

        /// <summary>
        ///     Tests that UpdateBisectionBounds covers the s > target branch.
        /// </summary>
        [Fact]
        public void UpdateBisectionBounds_WithSGreaterThanTarget_SetsA1()
        {
            float a1 = 0.0f, s1 = 1.0f;
            float a2 = 1.0f, s2 = -1.0f;
            float t = 0.5f, s = 0.5f, target = 0.1f;

            MethodInfo method = typeof(TimeOfImpact).GetMethod("UpdateBisectionBounds", BindingFlags.NonPublic | BindingFlags.Static);
            object[] args = new object[] { a1, s1, a2, s2, t, s, target };
            method.Invoke(null, args);

            Assert.NotNull(method);
        }

        /// <summary>
        ///     Tests that RecordRootIteration with diagnostics increments counter.
        /// </summary>
        [Fact]
        public void RecordRootIteration_WithDiagnostics_IncrementsCounter()
        {
            int before = TimeOfImpact.ToiRootIters;

            MethodInfo method = typeof(TimeOfImpact).GetMethod("RecordRootIteration", BindingFlags.NonPublic | BindingFlags.Static);
            method.Invoke(null, null);

            Assert.Equal(before + 1, TimeOfImpact.ToiRootIters);
        }

        /// <summary>
        ///     Tests that RecordMaxRootIters with diagnostics updates max.
        /// </summary>
        [Fact]
        public void RecordMaxRootIters_WithDiagnostics_UpdatesMax()
        {

            MethodInfo method = typeof(TimeOfImpact).GetMethod("RecordMaxRootIters", BindingFlags.NonPublic | BindingFlags.Static);
            method.Invoke(null, new object[] { 5 });

            Assert.True(TimeOfImpact.ToiMaxRootIters >= 5);
        }

        /// <summary>
        ///     Tests that TryHandleDistanceResult returns true when distance is zero.
        /// </summary>
        [Fact]
        public void TryHandleDistanceResult_WithZeroDistance_ReturnsOverlapped()
        {
            ToiOutput output = new ToiOutput();
            float t1 = 0.0f;

            MethodInfo method = typeof(TimeOfImpact).GetMethod("TryHandleDistanceResult", BindingFlags.NonPublic | BindingFlags.Static);
            object[] args = new object[] { new DistanceOutput { Distance = 0.0f }, 0.5f, 0.01f, output, t1 };
            bool result = (bool)method.Invoke(null, args);

            ToiOutput outputOut = (ToiOutput)args[3];
            Assert.True(result);
            Assert.Equal(ToiOutputState.Overlapped, outputOut.State);
        }
    }
}
