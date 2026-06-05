// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotScaleTest.cs
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
    ///     Provides unit coverage for <see cref="ImPlotScale" /> enum values.
    /// </summary>
    public class ImPlotScaleTest
    {
        /// <summary>
        ///     Verifies that Linear has the expected value of 0.
        /// </summary>
        [Fact]
        public void Linear_ShouldHaveCorrectValue()
        {
            ImPlotScale scale = ImPlotScale.Linear;
            Assert.Equal(0, (int)scale);
        }

        /// <summary>
        ///     Verifies that Time has the expected value of 1.
        /// </summary>
        [Fact]
        public void Time_ShouldHaveCorrectValue()
        {
            ImPlotScale scale = ImPlotScale.Time;
            Assert.Equal(1, (int)scale);
        }

        /// <summary>
        ///     Verifies that Log10 has the expected value of 2.
        /// </summary>
        [Fact]
        public void Log10_ShouldHaveCorrectValue()
        {
            ImPlotScale scale = ImPlotScale.Log10;
            Assert.Equal(2, (int)scale);
        }

        /// <summary>
        ///     Verifies that SymLog has the expected value of 3.
        /// </summary>
        [Fact]
        public void SymLog_ShouldHaveCorrectValue()
        {
            ImPlotScale scale = ImPlotScale.SymLog;
            Assert.Equal(3, (int)scale);
        }

        /// <summary>
        ///     Verifies that all enum values are sequential from 0 to SymLog.
        /// </summary>
        [Fact]
        public void Values_ShouldBeSequential()
        {
            ImPlotScale[] values = (ImPlotScale[])Enum.GetValues(typeof(ImPlotScale));

            for (int i = 0; i < values.Length; i++)
            {
                Assert.Equal(i, (int)values[i]);
            }
        }

        /// <summary>
        ///     Verifies that all enum values are unique.
        /// </summary>
        [Fact]
        public void Values_ShouldBeUnique()
        {
            ImPlotScale[] values = (ImPlotScale[])Enum.GetValues(typeof(ImPlotScale));
            int[] intValues = Array.ConvertAll(values, v => (int)v);

            int[] uniqueValues = intValues.Distinct().ToArray();
            Assert.Equal(intValues.Length, uniqueValues.Length);
        }
    }
}
