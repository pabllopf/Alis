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
        ///     Verifies that location values are defined.
        /// </summary>
        [Fact]
        public void Center_ShouldBeDefined()
        {
            ImPlotLocation location = ImPlotLocation.Center;
            Assert.Equal(0, (int) location);
        }

        /// <summary>
        ///     Verifies that different locations have distinct values.
        /// </summary>
        [Fact]
        public void EnumValues_ShouldBeDistinct()
        {
            ImPlotLocation center = ImPlotLocation.Center;
            ImPlotLocation north = ImPlotLocation.North;
            ImPlotLocation south = ImPlotLocation.South;

            Assert.NotEqual((int) center, (int) north);
            Assert.NotEqual((int) north, (int) south);
        }
    }
}