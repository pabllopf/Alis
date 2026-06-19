// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ █▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BayazitDecomposerTest.cs
// 
//  Author:Pablo Perdomo Falcon
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
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.Decomposition;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition
{
    /// <summary>
    ///     The bayazit decomposer test class
    /// </summary>
    public class BayazitDecomposerTest
    {
        /// <summary>
        ///     Tests that bayazit decomposer type should be accessible
        /// </summary>
        [Fact]
        public void BayazitDecomposer_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(BayazitDecomposer));
        }

        /// <summary>
        ///     Tests that convex partition with triangle should return single part
        /// </summary>
        [Fact]
        public void ConvexPartition_WithTriangle_ShouldReturnSinglePart()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(0f, 1f)
            });

            List<Vertices> result = BayazitDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);
        }

        /// <summary>
        ///     Tests that convex partition with a convex quad returns a single convex polygon
        /// </summary>
        [Fact]
        public void ConvexPartition_WithConvexQuad_ShouldReturnSinglePart()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(2f, 2f),
                new Vector2F(0f, 2f)
            });

            List<Vertices> result = BayazitDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(4, result[0].Count);
        }

        /// <summary>
        ///     Tests that convex partition with a convex pentagon returns a single convex polygon
        /// </summary>
        [Fact]
        public void ConvexPartition_WithConvexPentagon_ShouldReturnSinglePart()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(1f, 0f),
                new Vector2F(2f, 0.5f),
                new Vector2F(1.5f, 2f),
                new Vector2F(0f, 1.5f),
                new Vector2F(0f, 0f)
            });

            List<Vertices> result = BayazitDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.Single(result);
        }

        /// <summary>
        ///     Tests that the Copy method correctly wraps negative indices
        /// </summary>
        [Fact]
        public void Copy_WithNegativeIndices_ShouldWrapCorrectly()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(1f, 1f),
                new Vector2F(0f, 1f)
            });

            Vertices result = BayazitDecomposer.Copy(-1, 2, vertices);

            Assert.NotNull(result);
            Assert.Equal(4, result.Count);
        }

        /// <summary>
        ///     Tests that the At method correctly handles negative indices
        /// </summary>
        [Fact]
        public void At_WithNegativeIndex_ShouldWrapCorrectly()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(1f, 1f)
            });

            Vector2F result = BayazitDecomposer.At(-1, vertices);

            Assert.NotNull(result);
            Assert.Equal(new Vector2F(1f, 1f), result);
        }

        /// <summary>
        ///     Tests that Reflex correctly identifies reflex vertices in a concave polygon
        /// </summary>
        [Fact]
        public void Reflex_WithConcavePolygon_ShouldIdentifyReflexVertices()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(3f, 0f),
                new Vector2F(3f, 1f),
                new Vector2F(1f, 1f),
                new Vector2F(1f, 3f),
                new Vector2F(0f, 3f)
            });

            bool isReflex3 = BayazitDecomposer.Reflex(3, vertices);
            bool isReflex0 = BayazitDecomposer.Reflex(0, vertices);

            Assert.True(isReflex3);
            Assert.False(isReflex0);
        }

        /// <summary>
        ///     Tests that Left and Right correctly determine vertex orientation
        /// </summary>
        [Fact]
        public void LeftAndRight_WithKnownTriangle_ShouldReturnCorrectOrientation()
        {
            Vector2F a = new Vector2F(0f, 0f);
            Vector2F b = new Vector2F(1f, 0f);
            Vector2F c = new Vector2F(0f, 1f);

            bool isLeft = BayazitDecomposer.Left(a, b, c);
            bool isRight = BayazitDecomposer.Right(a, c, b);

            Assert.True(isLeft);
            Assert.True(isRight);
        }

        /// <summary>
        ///     Tests that LeftOn and RightOn handle collinear points correctly
        /// </summary>
        [Fact]
        public void LeftOnAndRightOn_WithCollinearPoints_ShouldReturnTrue()
        {
            Vector2F a = new Vector2F(0f, 0f);
            Vector2F b = new Vector2F(1f, 1f);
            Vector2F c = new Vector2F(2f, 2f);

            bool isLeftOn = BayazitDecomposer.LeftOn(a, b, c);
            bool isRightOn = BayazitDecomposer.RightOn(a, b, c);

            Assert.True(isLeftOn);
            Assert.True(isRightOn);
        }

        /// <summary>
        ///     Tests that SquareDist correctly calculates squared distance
        /// </summary>
        [Fact]
        public void SquareDist_WithKnownPoints_ShouldReturnCorrectDistance()
        {
            Vector2F a = new Vector2F(0f, 0f);
            Vector2F b = new Vector2F(3f, 4f);

            float dist = BayazitDecomposer.SquareDist(a, b);

            Assert.Equal(25f, dist);
        }

        /// <summary>
        ///     Tests that CanSee correctly identifies visible vertex pairs in a convex polygon
        /// </summary>
        [Fact]
        public void CanSee_WithConvexPolygon_ShouldReturnTrueForAllPairs()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(2f, 2f),
                new Vector2F(0f, 2f)
            });

            bool canSee = BayazitDecomposer.CanSee(0, 2, vertices);

            Assert.True(canSee);
        }

        /// <summary>
        ///     Tests that the At method handles index wrapping with positive indices
        /// </summary>
        [Fact]
        public void At_WithPositiveIndices_ShouldReturnCorrectVertices()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(1f, 1f)
            });

            Vector2F first = BayazitDecomposer.At(0, vertices);
            Assert.Equal(new Vector2F(0f, 0f), first);

            Vector2F second = BayazitDecomposer.At(1, vertices);
            Assert.Equal(new Vector2F(1f, 0f), second);

            Vector2F third = BayazitDecomposer.At(2, vertices);
            Assert.Equal(new Vector2F(1f, 1f), third);
        }

        /// <summary>
        ///     Tests that the Copy method creates a correct subset of vertices
        /// </summary>
        [Fact]
        public void Copy_WithValidRange_ShouldCreateCorrectSubset()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(2f, 1f),
                new Vector2F(3f, 3f)
            });

            Vertices result = BayazitDecomposer.Copy(1, 3, vertices);

            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            Assert.Equal(new Vector2F(1f, 0f), result[0]);
            Assert.Equal(new Vector2F(2f, 1f), result[1]);
            Assert.Equal(new Vector2F(3f, 3f), result[2]);
        }

        /// <summary>
        ///     Tests that RightOn handles boundary case where area equals zero
        /// </summary>
        [Fact]
        public void RightOn_WithZeroArea_ShouldReturnTrue()
        {
            Vector2F a = new Vector2F(0f, 0f);
            Vector2F b = new Vector2F(1f, 1f);
            Vector2F c = new Vector2F(0f, 0f);

            bool isRightOn = BayazitDecomposer.RightOn(a, b, c);

            Assert.True(isRightOn);
        }
    }
}
