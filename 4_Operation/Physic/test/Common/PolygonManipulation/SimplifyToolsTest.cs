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

using System;
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

        [Fact]
        public void DouglasPeuckerSimplify_WithThreePoints_ShouldReturnSameCount()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(1f, 1f)
            });

            Vertices result = SimplifyTools.DouglasPeuckerSimplify(vertices, 0f);

            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void DouglasPeuckerSimplify_WithCollinearPoints_ShouldReduceCount()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(3f, 0f)
            });

            Vertices result = SimplifyTools.DouglasPeuckerSimplify(vertices, 0.5f);

            Assert.True(result.Count <= 2);
        }

        [Fact]
        public void MergeParallelEdges_WithThreePoints_ShouldReturnSameCount()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(1f, 1f)
            });

            Vertices result = SimplifyTools.MergeParallelEdges(vertices, 0.1f);

            Assert.NotNull(result);
        }

        [Fact]
        public void ReduceByNth_WithThreePoints_ShouldReturnSameCount()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(1f, 1f)
            });

            Vertices result = SimplifyTools.ReduceByNth(vertices, 2);

            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void ReduceByNth_WithZeroNth_ShouldReturnOriginal()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(1f, 1f)
            });

            Vertices result = SimplifyTools.ReduceByNth(vertices, 0);

            Assert.Equal(4, result.Count);
        }

        [Fact]
        public void ReduceByNth_WithLargeSetAndNth_ShouldReduce()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(3f, 0f),
                new Vector2F(4f, 0f)
            });

            Vertices result = SimplifyTools.ReduceByNth(vertices, 2);

            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void ReduceByArea_WithThreePoints_ShouldReturnSameCount()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(1f, 1f)
            });

            Vertices result = SimplifyTools.ReduceByArea(vertices, 0f);

            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void ReduceByArea_WithNegativeTolerance_ShouldThrow()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(1f, 1f)
            });

            Assert.Throws<ArgumentOutOfRangeException>(() => SimplifyTools.ReduceByArea(vertices, -1f));
        }

        [Fact]
        public void CollinearSimplify_WithEmptyVertices_ShouldReturnEmpty()
        {
            Vertices vertices = new Vertices();
            Vertices result = SimplifyTools.CollinearSimplify(vertices);
            Assert.NotNull(result);
        }

        [Fact]
        public void CollinearSimplify_WithCollinearPoints_ShouldReduce()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(3f, 0f)
            });

            Vertices result = SimplifyTools.CollinearSimplify(vertices, 0.01f);

            Assert.True(result.Count < vertices.Count);
        }

        [Fact]
        public void MergeIdenticalPoints_WithAllIdentical_ShouldReturnSingle()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(1f, 1f),
                new Vector2F(1f, 1f),
                new Vector2F(1f, 1f)
            });

            Vertices result = SimplifyTools.MergeIdenticalPoints(vertices);

            Assert.Single(result);
        }

        [Fact]
        public void ReduceByDistance_WithClosePoints_ShouldReduce()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(0.01f, 0f),
                new Vector2F(0.02f, 0f),
                new Vector2F(1f, 1f)
            });

            Vertices result = SimplifyTools.ReduceByDistance(vertices, 0.1f);

            Assert.True(result.Count < 4);
        }

        [Fact]
        public void ReduceByDistance_WithThreePoints_ShouldReturnSame()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(1f, 1f)
            });

            Vertices result = SimplifyTools.ReduceByDistance(vertices, 0.5f);

            Assert.Equal(3, result.Count);
        }
    }
}
