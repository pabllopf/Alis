// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotFlagsTest.cs
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
    ///     Provides unit coverage for <see cref="ImPlotFlags" /> values and compositions.
    /// </summary>
    public class ImPlotFlagsTest
    {
        /// <summary>
        ///     Verifies that none is zero.
        /// </summary>
        [Fact]
        public void None_ShouldBeZero()
        {
            Assert.Equal(0, (int) ImPlotFlags.None);
        }

        /// <summary>
        ///     Verifies that canvas-only is the expected combination of interaction-disabling flags.
        /// </summary>
        [Fact]
        public void CanvasOnly_ShouldMatchExpectedComposition()
        {
            ImPlotFlags expected = ImPlotFlags.NoTitle
                                   | ImPlotFlags.NoLegend
                                   | ImPlotFlags.NoMouseText
                                   | ImPlotFlags.NoMenus
                                   | ImPlotFlags.NoBoxSelect;

            Assert.Equal(expected, ImPlotFlags.CanvasOnly);
        }

        /// <summary>
        ///     Verifies that selected standalone flags use distinct values.
        /// </summary>
        [Fact]
        public void StandaloneFlags_ShouldBeDistinct()
        {
            Assert.NotEqual((int) ImPlotFlags.NoFrame, (int) ImPlotFlags.Crosshairs);
            Assert.NotEqual((int) ImPlotFlags.NoInputs, (int) ImPlotFlags.Equal);
        }
    }
}