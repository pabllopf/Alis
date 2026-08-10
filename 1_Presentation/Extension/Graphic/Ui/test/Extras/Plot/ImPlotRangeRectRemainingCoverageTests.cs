// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotRangeRectRemainingCoverageTests.cs
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
    ///     The im plot range rect remaining coverage tests class
    /// </summary>
    public class ImPlotRangeRectRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that range properties round trip
        /// </summary>
        [Fact]
        public void Range_Properties_RoundTrip()
        {
            ImPlotRange range = new ImPlotRange
            {
                Min = -1.5,
                Max = 2.5
            };

            Assert.Equal(-1.5, range.Min);
            Assert.Equal(2.5, range.Max);
        }

        /// <summary>
        ///     Tests that range defaults are zero
        /// </summary>
        [Fact]
        public void Range_Defaults_AreZero()
        {
            ImPlotRange range = new ImPlotRange();

            Assert.Equal(0.0, range.Min);
            Assert.Equal(0.0, range.Max);
        }

        /// <summary>
        ///     Tests that rect properties round trip
        /// </summary>
        [Fact]
        public void Rect_Properties_RoundTrip()
        {
            ImPlotRect rect = new ImPlotRect
            {
                X = new ImPlotRange { Min = 0, Max = 10 },
                Y = new ImPlotRange { Min = -5, Max = 5 }
            };

            Assert.Equal(0, rect.X.Min);
            Assert.Equal(10, rect.X.Max);
            Assert.Equal(-5, rect.Y.Min);
            Assert.Equal(5, rect.Y.Max);
        }

        /// <summary>
        ///     Tests that rect defaults are zero
        /// </summary>
        [Fact]
        public void Rect_Defaults_AreZero()
        {
            ImPlotRect rect = new ImPlotRect();

            Assert.Equal(0.0, rect.X.Min);
            Assert.Equal(0.0, rect.X.Max);
            Assert.Equal(0.0, rect.Y.Min);
            Assert.Equal(0.0, rect.Y.Max);
        }
    }
}
