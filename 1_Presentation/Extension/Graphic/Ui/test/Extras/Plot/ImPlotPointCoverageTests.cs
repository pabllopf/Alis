// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotPointCoverageTests.cs
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
    ///     The im plot point coverage tests class
    /// </summary>
    public class ImPlotPointCoverageTests
    {
        /// <summary>
        ///     Tests that default initialization properties have default values
        /// </summary>
        [Fact]
        public void ImPlotPoint_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            ImPlotPoint point = default(ImPlotPoint);

            Assert.Equal(0d, point.X);
            Assert.Equal(0d, point.Y);
        }

        /// <summary>
        ///     Tests that set properties stores values correctly
        /// </summary>
        [Fact]
        public void ImPlotPoint_SetProperties_StoresValuesCorrectly()
        {
            ImPlotPoint point = new ImPlotPoint
            {
                X = 1.5d,
                Y = -2.25d
            };

            Assert.Equal(1.5d, point.X);
            Assert.Equal(-2.25d, point.Y);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void ImPlotPoint_IsValueType_CopyIsIndependent()
        {
            ImPlotPoint original = new ImPlotPoint { X = 100d };
            ImPlotPoint copy = original;

            copy.X = 200d;

            Assert.Equal(100d, original.X);
            Assert.Equal(200d, copy.X);
        }
    }
}