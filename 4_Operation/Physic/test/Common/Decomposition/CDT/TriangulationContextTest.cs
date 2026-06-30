// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TriangulationContextTest.cs
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

using Alis.Core.Physic.Common.Decomposition.CDT;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT
{
    /// <summary>
    /// The triangulation context test class
    /// </summary>
    public class TriangulationContextTest
    {
        /// <summary>
        /// Tests that triangulation context type should be accessible
        /// </summary>
        [Fact]
        public void TriangulationContext_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(TriangulationContext));
        }

        /// <summary>
        /// Tests that wait until notified returns false by default
        /// </summary>
        [Fact]
        public void WaitUntilNotified_ShouldBeFalseByDefault()
        {
            DtSweepContext ctx = new DtSweepContext();

            Assert.False(ctx.WaitUntilNotified);
        }

        /// <summary>
        /// Tests that done increments step count
        /// </summary>
        [Fact]
        public void Done_ShouldIncrementStepCount()
        {
            DtSweepContext ctx = new DtSweepContext();
            int before = ctx.StepCount;

            ctx.Done();

            Assert.Equal(before + 1, ctx.StepCount);
        }
    }
}
