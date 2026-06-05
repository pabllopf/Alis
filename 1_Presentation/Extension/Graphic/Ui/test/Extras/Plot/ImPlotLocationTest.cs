// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotLocationTest.cs
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
using System.Linq;
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    ///     Provides unit coverage for <see cref="ImPlotLocation" /> enum values.
    /// </summary>
    public class ImPlotLocationTest
    {
        /// <summary>
        ///     Verifies that Center has the expected value of 0.
        /// </summary>
        [Fact]
        public void Center_ShouldHaveCorrectValue()
        {
            ImPlotLocation location = ImPlotLocation.Center;
            Assert.Equal(0, (int)location);
        }

        /// <summary>
        ///     Verifies that North has the expected value of 1.
        /// </summary>
        [Fact]
        public void North_ShouldHaveCorrectValue()
        {
            ImPlotLocation location = ImPlotLocation.North;
            Assert.Equal(1, (int)location);
        }

        /// <summary>
        ///     Verifies that South has the expected value of 2.
        /// </summary>
        [Fact]
        public void South_ShouldHaveCorrectValue()
        {
            ImPlotLocation location = ImPlotLocation.South;
            Assert.Equal(2, (int)location);
        }

        /// <summary>
        ///     Verifies that West has the expected value of 4.
        /// </summary>
        [Fact]
        public void West_ShouldHaveCorrectValue()
        {
            ImPlotLocation location = ImPlotLocation.West;
            Assert.Equal(4, (int)location);
        }

        /// <summary>
        ///     Verifies that East has the expected value of 8.
        /// </summary>
        [Fact]
        public void East_ShouldHaveCorrectValue()
        {
            ImPlotLocation location = ImPlotLocation.East;
            Assert.Equal(8, (int)location);
        }

        /// <summary>
        ///     Verifies that NorthWest has the expected value of 5.
        /// </summary>
        [Fact]
        public void NorthWest_ShouldHaveCorrectValue()
        {
            ImPlotLocation location = ImPlotLocation.NorthWest;
            Assert.Equal(5, (int)location);
        }

        /// <summary>
        ///     Verifies that NorthEast has the expected value of 9.
        /// </summary>
        [Fact]
        public void NorthEast_ShouldHaveCorrectValue()
        {
            ImPlotLocation location = ImPlotLocation.NorthEast;
            Assert.Equal(9, (int)location);
        }

        /// <summary>
        ///     Verifies that SouthWest has the expected value of 6.
        /// </summary>
        [Fact]
        public void SouthWest_ShouldHaveCorrectValue()
        {
            ImPlotLocation location = ImPlotLocation.SouthWest;
            Assert.Equal(6, (int)location);
        }

        /// <summary>
        ///     Verifies that SouthEast has the expected value of 10.
        /// </summary>
        [Fact]
        public void SouthEast_ShouldHaveCorrectValue()
        {
            ImPlotLocation location = ImPlotLocation.SouthEast;
            Assert.Equal(10, (int)location);
        }

        /// <summary>
        ///     Verifies that locations can be combined with bitwise OR.
        /// </summary>
        [Fact]
        public void Locations_ShouldBeCombinable()
        {
            ImPlotLocation combined = ImPlotLocation.North | ImPlotLocation.West;
            int expected = 1 | 4;
            Assert.Equal(expected, (int)combined);
        }

        /// <summary>
        ///     Verifies that NorthWest is the combination of North and West.
        /// </summary>
        [Fact]
        public void NorthWest_ShouldBeCombinationOfNorthAndWest()
        {
            ImPlotLocation combined = ImPlotLocation.North | ImPlotLocation.West;
            Assert.Equal(ImPlotLocation.NorthWest, combined);
        }

        /// <summary>
        ///     Verifies that SouthEast is the combination of South and East.
        /// </summary>
        [Fact]
        public void SouthEast_ShouldBeCombinationOfSouthAndEast()
        {
            ImPlotLocation combined = ImPlotLocation.South | ImPlotLocation.East;
            Assert.Equal(ImPlotLocation.SouthEast, combined);
        }

        /// <summary>
        ///     Verifies that all enum values are unique.
        /// </summary>
        [Fact]
        public void Values_ShouldBeUnique()
        {
            ImPlotLocation[] values = (ImPlotLocation[])Enum.GetValues(typeof(ImPlotLocation));
            int[] intValues = Array.ConvertAll(values, v => (int)v);

            int[] uniqueValues = intValues.Distinct().ToArray();
            Assert.Equal(intValues.Length, uniqueValues.Length);
        }
    }
}
