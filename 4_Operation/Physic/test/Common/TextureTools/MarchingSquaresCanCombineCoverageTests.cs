// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MarchingSquaresCanCombineCoverageTests.cs
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

using Alis.Core.Physic.Common.TextureTools;
using Xunit;

namespace Alis.Core.Physic.Test.Common.TextureTools
{
    /// <summary>
    ///     The marching squares can combine coverage tests class
    /// </summary>
    public class MarchingSquaresCanCombineCoverageTests
    {
        /// <summary>
        ///     The marching squares key bit that marks the top left corner of a cell as negative.
        /// </summary>
        private const int TopLeftNegative = 8;

        /// <summary>
        ///     The marching squares key bit that marks the top right corner of a cell as negative.
        /// </summary>
        private const int TopRightNegative = 4;

        /// <summary>
        ///     The marching squares key bit that marks the bottom left corner of a cell as negative.
        /// </summary>
        private const int BottomLeftNegative = 1;

        /// <summary>
        ///     The marching squares key bit that marks the bottom right corner of a cell as negative.
        /// </summary>
        private const int BottomRightNegative = 2;

        /// <summary>
        ///     Builds a two by two polygon grid holding the given cell below and current cell values.
        /// </summary>
        /// <param name="below">The value stored on the row below the inspected one.</param>
        /// <param name="current">The value stored on the inspected row.</param>
        /// <returns>The polygon grid</returns>
        private static GeomPolyVal[,] BuildPolyGrid(GeomPolyVal below, GeomPolyVal current)
        {
            GeomPolyVal[,] ps = new GeomPolyVal[2, 2];
            ps[0, 0] = below;
            ps[0, 1] = current;

            return ps;
        }

        /// <summary>
        ///     Tests that a cell without any generated polygon can never be combined with the cell below.
        /// </summary>
        [Fact]
        public void CanCombine_WhenCurrentCellHasNoPolygon_ReturnsFalse()
        {
            // Arrange
            GeomPolyVal[,] ps = BuildPolyGrid(new GeomPolyVal(new MarchingSquares.GeomPoly(), TopLeftNegative), null);

            // Act
            bool result = MarchingSquares.CanCombine(ps, 0, 1);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that a cell whose top corners are not negative can never be combined with the cell
        ///     below, because the polygon does not touch the shared boundary.
        /// </summary>
        [Fact]
        public void CanCombine_WhenCurrentCellTopCornersAreNotNegative_ReturnsFalse()
        {
            // Arrange
            GeomPolyVal current = new GeomPolyVal(new MarchingSquares.GeomPoly(), BottomLeftNegative | BottomRightNegative);
            GeomPolyVal[,] ps = BuildPolyGrid(new GeomPolyVal(new MarchingSquares.GeomPoly(), BottomRightNegative), current);

            // Act
            bool result = MarchingSquares.CanCombine(ps, 0, 1);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that a cell whose lower neighbour did not generate any polygon can never be combined.
        /// </summary>
        [Fact]
        public void CanCombine_WhenCellBelowHasNoPolygon_ReturnsFalse()
        {
            // Arrange
            GeomPolyVal current = new GeomPolyVal(new MarchingSquares.GeomPoly(), TopLeftNegative);
            GeomPolyVal[,] ps = BuildPolyGrid(null, current);

            // Act
            bool result = MarchingSquares.CanCombine(ps, 0, 1);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that a cell whose lower neighbour has no negative bottom corners can never be combined,
        ///     because the neighbour does not reach the shared boundary.
        /// </summary>
        [Fact]
        public void CanCombine_WhenCellBelowBottomCornersAreNotNegative_ReturnsFalse()
        {
            // Arrange
            GeomPolyVal below = new GeomPolyVal(new MarchingSquares.GeomPoly(), TopRightNegative);
            GeomPolyVal current = new GeomPolyVal(new MarchingSquares.GeomPoly(), TopLeftNegative);
            GeomPolyVal[,] ps = BuildPolyGrid(below, current);

            // Act
            bool result = MarchingSquares.CanCombine(ps, 0, 1);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that a cell already merged with the cell below can never be combined again.
        /// </summary>
        [Fact]
        public void CanCombine_WhenCurrentCellAndCellBelowShareTheSamePolygon_ReturnsFalse()
        {
            // Arrange
            MarchingSquares.GeomPoly shared = new MarchingSquares.GeomPoly();
            GeomPolyVal below = new GeomPolyVal(shared, TopRightNegative);
            GeomPolyVal current = new GeomPolyVal(shared, TopLeftNegative);
            GeomPolyVal[,] ps = BuildPolyGrid(below, current);

            // Act
            bool result = MarchingSquares.CanCombine(ps, 0, 1);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that a cell whose lower neighbour holds a different polygon and shares the negative
        ///     boundary can be combined.
        /// </summary>
        [Fact]
        public void CanCombine_WhenCellsAreDistinctAndShareTheNegativeBoundary_ReturnsTrue()
        {
            // Arrange
            GeomPolyVal below = new GeomPolyVal(new MarchingSquares.GeomPoly(), TopRightNegative | BottomRightNegative);
            GeomPolyVal current = new GeomPolyVal(new MarchingSquares.GeomPoly(), TopLeftNegative);
            GeomPolyVal[,] ps = BuildPolyGrid(below, current);

            // Act
            bool result = MarchingSquares.CanCombine(ps, 0, 1);

            // Assert
            Assert.True(result);
        }
    }
}
