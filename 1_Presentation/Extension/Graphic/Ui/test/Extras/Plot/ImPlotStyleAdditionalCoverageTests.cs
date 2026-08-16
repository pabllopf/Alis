// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotStyleAdditionalCoverageTests.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    ///     The im plot style additional coverage tests class
    /// </summary>
    public class ImPlotStyleAdditionalCoverageTests
    {
        /// <summary>
        ///     Tests that middle color properties round trip
        /// </summary>
        [RequireImNodesSystemFact]
        public void MiddleColorProperties_RoundTrip()
        {
            ImPlotStyle style = new ImPlotStyle();

            style.Colors1 = new Vector4F(1.0f, 2.0f, 3.0f, 4.0f);
            style.Colors2 = new Vector4F(5.0f, 6.0f, 7.0f, 8.0f);
            style.Colors3 = new Vector4F(9.0f, 10.0f, 11.0f, 12.0f);
            style.Colors4 = new Vector4F(13.0f, 14.0f, 15.0f, 16.0f);
            style.Colors5 = new Vector4F(17.0f, 18.0f, 19.0f, 20.0f);
            style.Colors6 = new Vector4F(21.0f, 22.0f, 23.0f, 24.0f);
            style.Colors7 = new Vector4F(25.0f, 26.0f, 27.0f, 28.0f);
            style.Colors8 = new Vector4F(29.0f, 30.0f, 31.0f, 32.0f);
            style.Colors9 = new Vector4F(33.0f, 34.0f, 35.0f, 36.0f);

            Assert.Equal(1.0f, style.Colors1.X, 5);
            Assert.Equal(2.0f, style.Colors1.Y, 5);
            Assert.Equal(3.0f, style.Colors1.Z, 5);
            Assert.Equal(4.0f, style.Colors1.W, 5);
            Assert.Equal(5.0f, style.Colors2.X, 5);
            Assert.Equal(6.0f, style.Colors2.Y, 5);
            Assert.Equal(7.0f, style.Colors2.Z, 5);
            Assert.Equal(8.0f, style.Colors2.W, 5);
            Assert.Equal(9.0f, style.Colors3.X, 5);
            Assert.Equal(10.0f, style.Colors3.Y, 5);
            Assert.Equal(11.0f, style.Colors3.Z, 5);
            Assert.Equal(12.0f, style.Colors3.W, 5);
            Assert.Equal(13.0f, style.Colors4.X, 5);
            Assert.Equal(14.0f, style.Colors4.Y, 5);
            Assert.Equal(15.0f, style.Colors4.Z, 5);
            Assert.Equal(16.0f, style.Colors4.W, 5);
            Assert.Equal(17.0f, style.Colors5.X, 5);
            Assert.Equal(18.0f, style.Colors5.Y, 5);
            Assert.Equal(19.0f, style.Colors5.Z, 5);
            Assert.Equal(20.0f, style.Colors5.W, 5);
            Assert.Equal(21.0f, style.Colors6.X, 5);
            Assert.Equal(22.0f, style.Colors6.Y, 5);
            Assert.Equal(23.0f, style.Colors6.Z, 5);
            Assert.Equal(24.0f, style.Colors6.W, 5);
            Assert.Equal(25.0f, style.Colors7.X, 5);
            Assert.Equal(26.0f, style.Colors7.Y, 5);
            Assert.Equal(27.0f, style.Colors7.Z, 5);
            Assert.Equal(28.0f, style.Colors7.W, 5);
            Assert.Equal(29.0f, style.Colors8.X, 5);
            Assert.Equal(30.0f, style.Colors8.Y, 5);
            Assert.Equal(31.0f, style.Colors8.Z, 5);
            Assert.Equal(32.0f, style.Colors8.W, 5);
            Assert.Equal(33.0f, style.Colors9.X, 5);
            Assert.Equal(34.0f, style.Colors9.Y, 5);
            Assert.Equal(35.0f, style.Colors9.Z, 5);
            Assert.Equal(36.0f, style.Colors9.W, 5);
        }

        /// <summary>
        ///     Tests that upper color properties round trip
        /// </summary>
        [RequireImNodesSystemFact]
        public void UpperColorProperties_RoundTrip()
        {
            ImPlotStyle style = new ImPlotStyle();

            style.Colors10 = new Vector4F(0.1f, 0.2f, 0.3f, 0.4f);
            style.Colors11 = new Vector4F(0.5f, 0.6f, 0.7f, 0.8f);
            style.Colors12 = new Vector4F(0.9f, 1.0f, 1.1f, 1.2f);
            style.Colors13 = new Vector4F(1.3f, 1.4f, 1.5f, 1.6f);
            style.Colors14 = new Vector4F(1.7f, 1.8f, 1.9f, 2.0f);
            style.Colors15 = new Vector4F(2.1f, 2.2f, 2.3f, 2.4f);
            style.Colors16 = new Vector4F(2.5f, 2.6f, 2.7f, 2.8f);
            style.Colors17 = new Vector4F(2.9f, 3.0f, 3.1f, 3.2f);
            style.Colors18 = new Vector4F(3.3f, 3.4f, 3.5f, 3.6f);
            style.Colors19 = new Vector4F(3.7f, 3.8f, 3.9f, 4.0f);

            Assert.Equal(0.1f, style.Colors10.X, 5);
            Assert.Equal(0.2f, style.Colors10.Y, 5);
            Assert.Equal(0.3f, style.Colors10.Z, 5);
            Assert.Equal(0.4f, style.Colors10.W, 5);
            Assert.Equal(0.5f, style.Colors11.X, 5);
            Assert.Equal(0.6f, style.Colors11.Y, 5);
            Assert.Equal(0.7f, style.Colors11.Z, 5);
            Assert.Equal(0.8f, style.Colors11.W, 5);
            Assert.Equal(0.9f, style.Colors12.X, 5);
            Assert.Equal(1.0f, style.Colors12.Y, 5);
            Assert.Equal(1.1f, style.Colors12.Z, 5);
            Assert.Equal(1.2f, style.Colors12.W, 5);
            Assert.Equal(1.3f, style.Colors13.X, 5);
            Assert.Equal(1.4f, style.Colors13.Y, 5);
            Assert.Equal(1.5f, style.Colors13.Z, 5);
            Assert.Equal(1.6f, style.Colors13.W, 5);
            Assert.Equal(1.7f, style.Colors14.X, 5);
            Assert.Equal(1.8f, style.Colors14.Y, 5);
            Assert.Equal(1.9f, style.Colors14.Z, 5);
            Assert.Equal(2.0f, style.Colors14.W, 5);
            Assert.Equal(2.1f, style.Colors15.X, 5);
            Assert.Equal(2.2f, style.Colors15.Y, 5);
            Assert.Equal(2.3f, style.Colors15.Z, 5);
            Assert.Equal(2.4f, style.Colors15.W, 5);
            Assert.Equal(2.5f, style.Colors16.X, 5);
            Assert.Equal(2.6f, style.Colors16.Y, 5);
            Assert.Equal(2.7f, style.Colors16.Z, 5);
            Assert.Equal(2.8f, style.Colors16.W, 5);
            Assert.Equal(2.9f, style.Colors17.X, 5);
            Assert.Equal(3.0f, style.Colors17.Y, 5);
            Assert.Equal(3.1f, style.Colors17.Z, 5);
            Assert.Equal(3.2f, style.Colors17.W, 5);
            Assert.Equal(3.3f, style.Colors18.X, 5);
            Assert.Equal(3.4f, style.Colors18.Y, 5);
            Assert.Equal(3.5f, style.Colors18.Z, 5);
            Assert.Equal(3.6f, style.Colors18.W, 5);
            Assert.Equal(3.7f, style.Colors19.X, 5);
            Assert.Equal(3.8f, style.Colors19.Y, 5);
            Assert.Equal(3.9f, style.Colors19.Z, 5);
            Assert.Equal(4.0f, style.Colors19.W, 5);
        }

        /// <summary>
        ///     Tests that middle color properties are zero by default
        /// </summary>
        [RequireImNodesSystemFact]
        public void MiddleColorProperties_AreZeroByDefault()
        {
            ImPlotStyle style = new ImPlotStyle();

            Assert.Equal(0.0f, style.Colors1.X, 5);
            Assert.Equal(0.0f, style.Colors2.Y, 5);
            Assert.Equal(0.0f, style.Colors3.Z, 5);
            Assert.Equal(0.0f, style.Colors4.W, 5);
            Assert.Equal(0.0f, style.Colors5.X, 5);
            Assert.Equal(0.0f, style.Colors6.Y, 5);
            Assert.Equal(0.0f, style.Colors7.Z, 5);
            Assert.Equal(0.0f, style.Colors8.W, 5);
            Assert.Equal(0.0f, style.Colors9.X, 5);
        }

        /// <summary>
        ///     Tests that upper color properties are zero by default
        /// </summary>
        [RequireImNodesSystemFact]
        public void UpperColorProperties_AreZeroByDefault()
        {
            ImPlotStyle style = new ImPlotStyle();

            Assert.Equal(0.0f, style.Colors10.X, 5);
            Assert.Equal(0.0f, style.Colors11.Y, 5);
            Assert.Equal(0.0f, style.Colors12.Z, 5);
            Assert.Equal(0.0f, style.Colors13.W, 5);
            Assert.Equal(0.0f, style.Colors14.X, 5);
            Assert.Equal(0.0f, style.Colors15.Y, 5);
            Assert.Equal(0.0f, style.Colors16.Z, 5);
            Assert.Equal(0.0f, style.Colors17.W, 5);
            Assert.Equal(0.0f, style.Colors18.X, 5);
            Assert.Equal(0.0f, style.Colors19.Y, 5);
        }
    }
}
