// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TimeOfImpactMaxIterationTests.cs
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
    ///     Coverage tests for the non-converging branches of <see cref="TimeOfImpact" />.
    ///     The scenarios below are deliberately pathological (fast linear motion combined with
    ///     rotating shapes) so that the swept separating axis algorithm exhausts its iteration
    ///     budget instead of reporting <c>Touching</c>/<c>Seperated</c>.
    /// </summary>
    public class TimeOfImpactMaxIterationTests
    {
        /// <summary>
        ///     Tests that <see cref="TimeOfImpact.CalculateTimeOfImpact" /> reports
        ///     <see cref="ToiOutputState.Failed" /> and returns the search interval bound when the
        ///     outer loop reaches its maximum iteration count.
        /// </summary>
        [Fact]
        public void CalculateTimeOfImpact_WhenIterationLimitReached_ReturnsFailedAtTMax()
        {
            PolygonShape polygonA = new PolygonShape(PolygonTools.CreateRectangle(0.13760632f, 1.379985f), 1.0f);
            CircleShape circleB = new CircleShape(1.4878528f, 1.0f);

            ToiInput input = new ToiInput
            {
                ProxyA = new DistanceProxy(polygonA, 0),
                ProxyB = new DistanceProxy(circleB, 0),
                SweepA = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = new Vector2F(-3.6855638f, 3.351657f),
                    C = new Vector2F(-2.8274388f, -1.0514412f),
                    A0 = -2.506178f,
                    A = -0.3305246f,
                    Alpha0 = 0.0f
                },
                SweepB = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = new Vector2F(2.077877f, 2.2161725f),
                    C = new Vector2F(-1.6577545f, -1.2033148f),
                    A0 = -0.50841326f,
                    A = 2.5420632f,
                    Alpha0 = 0.0f
                },
                TMax = 0.8942891f
            };

            TimeOfImpact.ToiMaxIters = 0;

            TimeOfImpact.CalculateTimeOfImpact(out ToiOutput output, ref input);

            Assert.Equal(ToiOutputState.Failed, output.State);
            Assert.Equal(input.TMax, output.T, 5);
            Assert.Equal(20, TimeOfImpact.ToiMaxIters);
        }

        /// <summary>
        ///     Tests that <see cref="TimeOfImpact.CalculateTimeOfImpact" /> reports
        ///     <see cref="ToiOutputState.Failed" /> when the push-back search already detects a
        ///     collapsed separation at the start of the interval.
        /// </summary>
        [Fact]
        public void CalculateTimeOfImpact_WhenInitialSeparationCollapsed_ReturnsFailed()
        {
            PolygonShape polygonA = new PolygonShape(PolygonTools.CreateRectangle(0.37378088f, 0.8531948f), 1.0f);
            CircleShape circleB = new CircleShape(0.92628473f, 1.0f);

            ToiInput input = new ToiInput
            {
                ProxyA = new DistanceProxy(polygonA, 0),
                ProxyB = new DistanceProxy(circleB, 0),
                SweepA = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = new Vector2F(-3.5654335f, -2.511763f),
                    C = new Vector2F(-0.3796356f, 0.77301574f),
                    A0 = 2.3583217f,
                    A = 1.2805876f,
                    Alpha0 = 0.0f
                },
                SweepB = new Sweep
                {
                    LocalCenter = Vector2F.Zero,
                    C0 = new Vector2F(-4.1177144f, -4.018411f),
                    C = new Vector2F(-1.1419764f, 4.893079f),
                    A0 = -0.6172069f,
                    A = -1.3002527f,
                    Alpha0 = 0.0f
                },
                TMax = 1.0f
            };

            TimeOfImpact.ToiMaxIters = 0;

            TimeOfImpact.CalculateTimeOfImpact(out ToiOutput output, ref input);

            Assert.Equal(ToiOutputState.Failed, output.State);
            Assert.Equal(0.0f, output.T, 5);
            Assert.Equal(0, TimeOfImpact.ToiMaxIters);
        }
    }
}
