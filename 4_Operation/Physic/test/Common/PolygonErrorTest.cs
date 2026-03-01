// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PolygonErrorTest.cs
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

using Alis.Core.Physic.Common;
using Xunit;

namespace Alis.Core.Physic.Test.Common
{
    /// <summary>
    ///     The polygon error test class
    /// </summary>
    public class PolygonErrorTest
    {
        /// <summary>
        ///     Tests that no error should have value zero
        /// </summary>
        [Fact]
        public void NoError_ShouldHaveValueZero()
        {
            Assert.Equal(0, (int)PolygonError.NoError);
        }

        /// <summary>
        ///     Tests that invalid amount of vertices should have value one
        /// </summary>
        [Fact]
        public void InvalidAmountOfVertices_ShouldHaveValueOne()
        {
            Assert.Equal(1, (int)PolygonError.InvalidAmountOfVertices);
        }

        /// <summary>
        ///     Tests that not simple should have value two
        /// </summary>
        [Fact]
        public void NotSimple_ShouldHaveValueTwo()
        {
            Assert.Equal(2, (int)PolygonError.NotSimple);
        }

        /// <summary>
        ///     Tests that not counter clock wise should have value three
        /// </summary>
        [Fact]
        public void NotCounterClockWise_ShouldHaveValueThree()
        {
            Assert.Equal(3, (int)PolygonError.NotCounterClockWise);
        }

        /// <summary>
        ///     Tests that not convex should have value four
        /// </summary>
        [Fact]
        public void NotConvex_ShouldHaveValueFour()
        {
            Assert.Equal(4, (int)PolygonError.NotConvex);
        }

        /// <summary>
        ///     Tests that area too small should have value five
        /// </summary>
        [Fact]
        public void AreaTooSmall_ShouldHaveValueFive()
        {
            Assert.Equal(5, (int)PolygonError.AreaTooSmall);
        }

        /// <summary>
        ///     Tests that side too small should have value six
        /// </summary>
        [Fact]
        public void SideTooSmall_ShouldHaveValueSix()
        {
            Assert.Equal(6, (int)PolygonError.SideTooSmall);
        }

        /// <summary>
        ///     Tests that all values should be unique
        /// </summary>
        [Fact]
        public void AllValues_ShouldBeUnique()
        {
            PolygonError[] values = new[]
            {
                PolygonError.NoError,
                PolygonError.InvalidAmountOfVertices,
                PolygonError.NotSimple,
                PolygonError.NotCounterClockWise,
                PolygonError.NotConvex,
                PolygonError.AreaTooSmall,
                PolygonError.SideTooSmall
            };
            
            for (int i = 0; i < values.Length; i++)
            {
                for (int j = i + 1; j < values.Length; j++)
                {
                    Assert.NotEqual(values[i], values[j]);
                }
            }
        }

        /// <summary>
        ///     Tests that values should be sequential
        /// </summary>
        [Fact]
        public void Values_ShouldBeSequential()
        {
            Assert.Equal(0, (int)PolygonError.NoError);
            Assert.Equal(1, (int)PolygonError.InvalidAmountOfVertices);
            Assert.Equal(2, (int)PolygonError.NotSimple);
            Assert.Equal(3, (int)PolygonError.NotCounterClockWise);
            Assert.Equal(4, (int)PolygonError.NotConvex);
            Assert.Equal(5, (int)PolygonError.AreaTooSmall);
            Assert.Equal(6, (int)PolygonError.SideTooSmall);
        }
    }
}

