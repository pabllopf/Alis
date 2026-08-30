// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotRectCoverageTests.cs
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
    ///     The im plot rect coverage tests class
    /// </summary>
    public class ImPlotRectCoverageTests
    {
        /// <summary>
        ///     Tests that default initialization properties have default values
        /// </summary>
        [Fact]
        public void ImPlotRect_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            ImPlotRect rect = default(ImPlotRect);

            Assert.Equal(0d, rect.X.Min);
            Assert.Equal(0d, rect.X.Max);
            Assert.Equal(0d, rect.Y.Min);
            Assert.Equal(0d, rect.Y.Max);
        }

        /// <summary>
        ///     Tests that set properties stores values correctly
        /// </summary>
        [Fact]
        public void ImPlotRect_SetProperties_StoresValuesCorrectly()
        {
            ImPlotRect rect = new ImPlotRect
            {
                X = new ImPlotRange { Min = -2d, Max = 2d },
                Y = new ImPlotRange { Min = -5d, Max = 5d }
            };

            Assert.Equal(-2d, rect.X.Min);
            Assert.Equal(2d, rect.X.Max);
            Assert.Equal(-5d, rect.Y.Min);
            Assert.Equal(5d, rect.Y.Max);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void ImPlotRect_IsValueType_CopyIsIndependent()
        {
            ImPlotRect original = new ImPlotRect { X = new ImPlotRange { Min = 1d } };
            ImPlotRect copy = original;

            copy.X = new ImPlotRange { Min = 2d };

            Assert.Equal(1d, original.X.Min);
            Assert.Equal(2d, copy.X.Min);
        }
    }
}