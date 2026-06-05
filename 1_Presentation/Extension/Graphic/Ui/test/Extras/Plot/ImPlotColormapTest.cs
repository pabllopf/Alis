// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotColormapTest.cs
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
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    ///     Provides unit coverage for <see cref="ImPlotColormap" /> enum values.
    /// </summary>
    public class ImPlotColormapTest
    {
        /// <summary>
        ///     Verifies that Deep has the expected value of 0.
        /// </summary>
        [Fact]
        public void Deep_ShouldHaveCorrectValue()
        {
            ImPlotColormap colormap = ImPlotColormap.Deep;
            Assert.Equal(0, (int)colormap);
        }

        /// <summary>
        ///     Verifies that Dark has the expected value of 1.
        /// </summary>
        [Fact]
        public void Dark_ShouldHaveCorrectValue()
        {
            ImPlotColormap colormap = ImPlotColormap.Dark;
            Assert.Equal(1, (int)colormap);
        }

        /// <summary>
        ///     Verifies that Pastel has the expected value of 2.
        /// </summary>
        [Fact]
        public void Pastel_ShouldHaveCorrectValue()
        {
            ImPlotColormap colormap = ImPlotColormap.Pastel;
            Assert.Equal(2, (int)colormap);
        }

        /// <summary>
        ///     Verifies that Paired has the expected value of 3.
        /// </summary>
        [Fact]
        public void Paired_ShouldHaveCorrectValue()
        {
            ImPlotColormap colormap = ImPlotColormap.Paired;
            Assert.Equal(3, (int)colormap);
        }

        /// <summary>
        ///     Verifies that Viridis has the expected value of 4.
        /// </summary>
        [Fact]
        public void Viridis_ShouldHaveCorrectValue()
        {
            ImPlotColormap colormap = ImPlotColormap.Viridis;
            Assert.Equal(4, (int)colormap);
        }

        /// <summary>
        ///     Verifies that Plasma has the expected value of 5.
        /// </summary>
        [Fact]
        public void Plasma_ShouldHaveCorrectValue()
        {
            ImPlotColormap colormap = ImPlotColormap.Plasma;
            Assert.Equal(5, (int)colormap);
        }

        /// <summary>
        ///     Verifies that Hot has the expected value of 6.
        /// </summary>
        [Fact]
        public void Hot_ShouldHaveCorrectValue()
        {
            ImPlotColormap colormap = ImPlotColormap.Hot;
            Assert.Equal(6, (int)colormap);
        }

        /// <summary>
        ///     Verifies that Cool has the expected value of 7.
        /// </summary>
        [Fact]
        public void Cool_ShouldHaveCorrectValue()
        {
            ImPlotColormap colormap = ImPlotColormap.Cool;
            Assert.Equal(7, (int)colormap);
        }

        /// <summary>
        ///     Verifies that Pink has the expected value of 8.
        /// </summary>
        [Fact]
        public void Pink_ShouldHaveCorrectValue()
        {
            ImPlotColormap colormap = ImPlotColormap.Pink;
            Assert.Equal(8, (int)colormap);
        }

        /// <summary>
        ///     Verifies that Jet has the expected value of 9.
        /// </summary>
        [Fact]
        public void Jet_ShouldHaveCorrectValue()
        {
            ImPlotColormap colormap = ImPlotColormap.Jet;
            Assert.Equal(9, (int)colormap);
        }

        /// <summary>
        ///     Verifies that Twilight has the expected value of 10.
        /// </summary>
        [Fact]
        public void Twilight_ShouldHaveCorrectValue()
        {
            ImPlotColormap colormap = ImPlotColormap.Twilight;
            Assert.Equal(10, (int)colormap);
        }

        /// <summary>
        ///     Verifies that RdBu has the expected value of 11.
        /// </summary>
        [Fact]
        public void RdBu_ShouldHaveCorrectValue()
        {
            ImPlotColormap colormap = ImPlotColormap.RdBu;
            Assert.Equal(11, (int)colormap);
        }

        /// <summary>
        ///     Verifies that BrBg has the expected value of 12.
        /// </summary>
        [Fact]
        public void BrBg_ShouldHaveCorrectValue()
        {
            ImPlotColormap colormap = ImPlotColormap.BrBg;
            Assert.Equal(12, (int)colormap);
        }

        /// <summary>
        ///     Verifies that PiYg has the expected value of 13.
        /// </summary>
        [Fact]
        public void PiYg_ShouldHaveCorrectValue()
        {
            ImPlotColormap colormap = ImPlotColormap.PiYg;
            Assert.Equal(13, (int)colormap);
        }

        /// <summary>
        ///     Verifies that Spectral has the expected value of 14.
        /// </summary>
        [Fact]
        public void Spectral_ShouldHaveCorrectValue()
        {
            ImPlotColormap colormap = ImPlotColormap.Spectral;
            Assert.Equal(14, (int)colormap);
        }

        /// <summary>
        ///     Verifies that Greys has the expected value of 15.
        /// </summary>
        [Fact]
        public void Greys_ShouldHaveCorrectValue()
        {
            ImPlotColormap colormap = ImPlotColormap.Greys;
            Assert.Equal(15, (int)colormap);
        }

        /// <summary>
        ///     Verifies that all enum values are sequential from 0 to Greys.
        /// </summary>
        [Fact]
        public void Values_ShouldBeSequential()
        {
            ImPlotColormap[] values = (ImPlotColormap[])Enum.GetValues(typeof(ImPlotColormap));

            for (int i = 0; i < values.Length; i++)
            {
                Assert.Equal(i, (int)values[i]);
            }
        }
    }
}
