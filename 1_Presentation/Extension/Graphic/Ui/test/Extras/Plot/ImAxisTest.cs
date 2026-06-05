// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImAxisTest.cs
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
    ///     Provides unit coverage for <see cref="ImAxis" /> enum values.
    /// </summary>
    public class ImAxisTest
    {
        /// <summary>
        ///     Verifies that X1 has the expected value of 0.
        /// </summary>
        [Fact]
        public void X1_ShouldHaveCorrectValue()
        {
            ImAxis axis = ImAxis.X1;
            Assert.Equal(0, (int)axis);
        }

        /// <summary>
        ///     Verifies that X2 has the expected value of 1.
        /// </summary>
        [Fact]
        public void X2_ShouldHaveCorrectValue()
        {
            ImAxis axis = ImAxis.X2;
            Assert.Equal(1, (int)axis);
        }

        /// <summary>
        ///     Verifies that X3 has the expected value of 2.
        /// </summary>
        [Fact]
        public void X3_ShouldHaveCorrectValue()
        {
            ImAxis axis = ImAxis.X3;
            Assert.Equal(2, (int)axis);
        }

        /// <summary>
        ///     Verifies that Y1 has the expected value of 3.
        /// </summary>
        [Fact]
        public void Y1_ShouldHaveCorrectValue()
        {
            ImAxis axis = ImAxis.Y1;
            Assert.Equal(3, (int)axis);
        }

        /// <summary>
        ///     Verifies that Y2 has the expected value of 4.
        /// </summary>
        [Fact]
        public void Y2_ShouldHaveCorrectValue()
        {
            ImAxis axis = ImAxis.Y2;
            Assert.Equal(4, (int)axis);
        }

        /// <summary>
        ///     Verifies that Y3 has the expected value of 5.
        /// </summary>
        [Fact]
        public void Y3_ShouldHaveCorrectValue()
        {
            ImAxis axis = ImAxis.Y3;
            Assert.Equal(5, (int)axis);
        }

        /// <summary>
        ///     Verifies that Count has the expected value of 6.
        /// </summary>
        [Fact]
        public void Count_ShouldHaveCorrectValue()
        {
            ImAxis axis = ImAxis.Count;
            Assert.Equal(6, (int)axis);
        }

        /// <summary>
        ///     Verifies that all enum values are sequential from 0 to Count.
        /// </summary>
        [Fact]
        public void Values_ShouldBeSequential()
        {
            ImAxis[] values = (ImAxis[])Enum.GetValues(typeof(ImAxis));

            for (int i = 0; i < values.Length; i++)
            {
                Assert.Equal(i, (int)values[i]);
            }
        }
    }
}
