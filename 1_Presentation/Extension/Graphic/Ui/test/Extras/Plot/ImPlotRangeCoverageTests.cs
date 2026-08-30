// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotRangeCoverageTests.cs
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
    ///     The im plot range coverage tests class
    /// </summary>
    public class ImPlotRangeCoverageTests
    {
        /// <summary>
        ///     Tests that default initialization properties have default values
        /// </summary>
        [Fact]
        public void ImPlotRange_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            ImPlotRange range = default(ImPlotRange);

            Assert.Equal(0d, range.Min);
            Assert.Equal(0d, range.Max);
        }

        /// <summary>
        ///     Tests that set properties stores values correctly
        /// </summary>
        [Fact]
        public void ImPlotRange_SetProperties_StoresValuesCorrectly()
        {
            ImPlotRange range = new ImPlotRange
            {
                Min = -1.5d,
                Max = 3.25d
            };

            Assert.Equal(-1.5d, range.Min);
            Assert.Equal(3.25d, range.Max);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void ImPlotRange_IsValueType_CopyIsIndependent()
        {
            ImPlotRange original = new ImPlotRange { Min = 10d };
            ImPlotRange copy = original;

            copy.Min = 20d;

            Assert.Equal(10d, original.Min);
            Assert.Equal(20d, copy.Min);
        }
    }
}