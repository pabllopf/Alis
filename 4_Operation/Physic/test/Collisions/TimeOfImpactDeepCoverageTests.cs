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
    ///     Coverage tests for the defensive iteration guards of <see cref="TimeOfImpact" />.
    ///     These guards are only reachable when the swept separating-axis evaluation becomes
    ///     non-finite, in which case every numeric comparison is false and neither the
    ///     push-back loop nor the root finder can converge. The solver must stop through its
    ///     iteration budgets and report <see cref="ToiOutputState.Failed" /> instead of looping
    ///     indefinitely.
    /// </summary>
    public class TimeOfImpactDeepCoverageTests
    {
        /// <summary>
        ///     A NaN sweep position makes every separation comparison false, so the push-back
        ///     loop exhausts its polygon-vertex budget and the root finder exhausts its 50-step
        ///     budget on every outer iteration. The solver must terminate and report failure.
        /// </summary>
        [Fact]
        public void CalculateTimeOfImpact_WhenSweepContainsNaN_TerminatesThroughIterationGuards()
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
        ///     An infinite sweep bound produces the same non-finite behaviour as NaN. The solver
        ///     must terminate through the same push-back and root-find iteration guards.
        /// </summary>
        [Fact]
        public void CalculateTimeOfImpact_WhenSweepContainsInfinity_TerminatesThroughIterationGuards()
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
