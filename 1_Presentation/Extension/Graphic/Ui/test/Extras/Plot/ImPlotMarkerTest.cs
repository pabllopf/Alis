// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotMarkerTest.cs
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
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    ///     Provides unit coverage for <see cref="ImPlotMarker" /> enum values.
    /// </summary>
    public class ImPlotMarkerTest
    {
        /// <summary>
        ///     Verifies that None has the expected value of -1.
        /// </summary>
        [RequireCImguiSystemFact]
        public void None_ShouldHaveCorrectValue()
        {
            ImPlotMarker marker = ImPlotMarker.None;
            Assert.Equal(-1, (int)marker);
        }

        /// <summary>
        ///     Verifies that Circle has the expected value of 0.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Circle_ShouldHaveCorrectValue()
        {
            ImPlotMarker marker = ImPlotMarker.Circle;
            Assert.Equal(0, (int)marker);
        }

        /// <summary>
        ///     Verifies that Square has the expected value of 1.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Square_ShouldHaveCorrectValue()
        {
            ImPlotMarker marker = ImPlotMarker.Square;
            Assert.Equal(1, (int)marker);
        }

        /// <summary>
        ///     Verifies that Diamond has the expected value of 2.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Diamond_ShouldHaveCorrectValue()
        {
            ImPlotMarker marker = ImPlotMarker.Diamond;
            Assert.Equal(2, (int)marker);
        }

        /// <summary>
        ///     Verifies that Up has the expected value of 3.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Up_ShouldHaveCorrectValue()
        {
            ImPlotMarker marker = ImPlotMarker.Up;
            Assert.Equal(3, (int)marker);
        }

        /// <summary>
        ///     Verifies that Down has the expected value of 4.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Down_ShouldHaveCorrectValue()
        {
            ImPlotMarker marker = ImPlotMarker.Down;
            Assert.Equal(4, (int)marker);
        }

        /// <summary>
        ///     Verifies that Left has the expected value of 5.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Left_ShouldHaveCorrectValue()
        {
            ImPlotMarker marker = ImPlotMarker.Left;
            Assert.Equal(5, (int)marker);
        }

        /// <summary>
        ///     Verifies that Right has the expected value of 6.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Right_ShouldHaveCorrectValue()
        {
            ImPlotMarker marker = ImPlotMarker.Right;
            Assert.Equal(6, (int)marker);
        }

        /// <summary>
        ///     Verifies that Cross has the expected value of 7.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Cross_ShouldHaveCorrectValue()
        {
            ImPlotMarker marker = ImPlotMarker.Cross;
            Assert.Equal(7, (int)marker);
        }

        /// <summary>
        ///     Verifies that Plus has the expected value of 8.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Plus_ShouldHaveCorrectValue()
        {
            ImPlotMarker marker = ImPlotMarker.Plus;
            Assert.Equal(8, (int)marker);
        }

        /// <summary>
        ///     Verifies that Asterisk has the expected value of 9.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Asterisk_ShouldHaveCorrectValue()
        {
            ImPlotMarker marker = ImPlotMarker.Asterisk;
            Assert.Equal(9, (int)marker);
        }

        /// <summary>
        ///     Verifies that Count has the expected value of 10.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Count_ShouldHaveCorrectValue()
        {
            ImPlotMarker marker = ImPlotMarker.Count;
            Assert.Equal(10, (int)marker);
        }
    }
}
