// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SimplifyToolsTest.cs
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
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.PolygonManipulation;
using Xunit;

namespace Alis.Core.Physic.Test.Common.PolygonManipulation
{
    /// <summary>
    /// The simplify tools test class
    /// </summary>
    public class SimplifyToolsTest
    {
        /// <summary>
        /// Tests that simplify tools type should be accessible
        /// </summary>
        [Fact]
        public void SimplifyTools_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(SimplifyTools));
        }

        /// <summary>
        /// Tests that collinear simplify with three points should return same count
        /// </summary>
        [Fact]
        public void CollinearSimplify_WithThreePoints_ShouldReturnSameCount()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(1f, 1f)
            });

            Vertices result = SimplifyTools.CollinearSimplify(vertices);

            Assert.Equal(3, result.Count);
        }

        /// <summary>
        /// Tests that merge identical points should remove duplicates
        /// </summary>
        [Fact]
        public void MergeIdenticalPoints_ShouldRemoveDuplicates()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(1f, 1f)
            });

            Vertices result = SimplifyTools.MergeIdenticalPoints(vertices);

            Assert.Equal(3, result.Count);
        }

        /// <summary>
        /// Tests that merge identical points with no duplicates should keep all
        /// </summary>
        [Fact]
        public void MergeIdenticalPoints_WithNoDuplicates_ShouldKeepAll()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(1f, 1f)
            });

            Vertices result = SimplifyTools.MergeIdenticalPoints(vertices);

            Assert.Equal(3, result.Count);
        }

        /// <summary>
        /// Tests that reduce by distance should work with valid input
        /// </summary>
        [Fact]
        public void ReduceByDistance_WithValidInput_ShouldReturnResult()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(2f, 1f)
            });

            Vertices result = SimplifyTools.ReduceByDistance(vertices, 0.5f);

            Assert.NotNull(result);
            Assert.True(result.Count >= 2);
        }
    }
}
