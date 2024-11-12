// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StyleTest.cs
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

using Alis.Extension.Graphic.ImGui.Extras.Node;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test.Extras.Node
{
    /// <summary>
    ///     The style test class
    /// </summary>
    public class StyleTest
    {
        /// <summary>
        ///     Tests that grid spacing should set and get correctly
        /// </summary>
        [Fact]
        public void GridSpacing_Should_SetAndGetCorrectly()
        {
            Style style = new Style();
            float value = 10.0f;
            style.GridSpacing = value;
            Assert.Equal(value, style.GridSpacing);
        }

        /// <summary>
        ///     Tests that node corner rounding should set and get correctly
        /// </summary>
        [Fact]
        public void NodeCornerRounding_Should_SetAndGetCorrectly()
        {
            Style style = new Style();
            float value = 5.0f;
            style.NodeCornerRounding = value;
            Assert.Equal(value, style.NodeCornerRounding);
        }

        /// <summary>
        ///     Tests that node padding horizontal should set and get correctly
        /// </summary>
        [Fact]
        public void NodePaddingHorizontal_Should_SetAndGetCorrectly()
        {
            Style style = new Style();
            float value = 3.0f;
            style.NodePaddingHorizontal = value;
            Assert.Equal(value, style.NodePaddingHorizontal);
        }

        /// <summary>
        ///     Tests that node padding vertical should set and get correctly
        /// </summary>
        [Fact]
        public void NodePaddingVertical_Should_SetAndGetCorrectly()
        {
            Style style = new Style();
            float value = 4.0f;
            style.NodePaddingVertical = value;
            Assert.Equal(value, style.NodePaddingVertical);
        }

        /// <summary>
        ///     Tests that node border thickness should set and get correctly
        /// </summary>
        [Fact]
        public void NodeBorderThickness_Should_SetAndGetCorrectly()
        {
            Style style = new Style();
            float value = 2.0f;
            style.NodeBorderThickness = value;
            Assert.Equal(value, style.NodeBorderThickness);
        }

        /// <summary>
        ///     Tests that link thickness should set and get correctly
        /// </summary>
        [Fact]
        public void LinkThickness_Should_SetAndGetCorrectly()
        {
            Style style = new Style();
            float value = 1.5f;
            style.LinkThickness = value;
            Assert.Equal(value, style.LinkThickness);
        }

        /// <summary>
        ///     Tests that link line segments per length should set and get correctly
        /// </summary>
        [Fact]
        public void LinkLineSegmentsPerLength_Should_SetAndGetCorrectly()
        {
            Style style = new Style();
            float value = 1.0f;
            style.LinkLineSegmentsPerLength = value;
            Assert.Equal(value, style.LinkLineSegmentsPerLength);
        }

        /// <summary>
        ///     Tests that link hover distance should set and get correctly
        /// </summary>
        [Fact]
        public void LinkHoverDistance_Should_SetAndGetCorrectly()
        {
            Style style = new Style();
            float value = 2.5f;
            style.LinkHoverDistance = value;
            Assert.Equal(value, style.LinkHoverDistance);
        }

        /// <summary>
        ///     Tests that pin circle radius should set and get correctly
        /// </summary>
        [Fact]
        public void PinCircleRadius_Should_SetAndGetCorrectly()
        {
            Style style = new Style();
            float value = 3.5f;
            style.PinCircleRadius = value;
            Assert.Equal(value, style.PinCircleRadius);
        }

        /// <summary>
        ///     Tests that pin quad side length should set and get correctly
        /// </summary>
        [Fact]
        public void PinQuadSideLength_Should_SetAndGetCorrectly()
        {
            Style style = new Style();
            float value = 4.5f;
            style.PinQuadSideLength = value;
            Assert.Equal(value, style.PinQuadSideLength);
        }

        /// <summary>
        ///     Tests that pin triangle side length should set and get correctly
        /// </summary>
        [Fact]
        public void PinTriangleSideLength_Should_SetAndGetCorrectly()
        {
            Style style = new Style();
            float value = 5.5f;
            style.PinTriangleSideLength = value;
            Assert.Equal(value, style.PinTriangleSideLength);
        }

        /// <summary>
        ///     Tests that pin line thickness should set and get correctly
        /// </summary>
        [Fact]
        public void PinLineThickness_Should_SetAndGetCorrectly()
        {
            Style style = new Style();
            float value = 1.0f;
            style.PinLineThickness = value;
            Assert.Equal(value, style.PinLineThickness);
        }

        /// <summary>
        ///     Tests that pin hover radius should set and get correctly
        /// </summary>
        [Fact]
        public void PinHoverRadius_Should_SetAndGetCorrectly()
        {
            Style style = new Style();
            float value = 2.0f;
            style.PinHoverRadius = value;
            Assert.Equal(value, style.PinHoverRadius);
        }

        /// <summary>
        ///     Tests that pin offset should set and get correctly
        /// </summary>
        [Fact]
        public void PinOffset_Should_SetAndGetCorrectly()
        {
            Style style = new Style();
            float value = 1.0f;
            style.PinOffset = value;
            Assert.Equal(value, style.PinOffset);
        }

        /// <summary>
        ///     Tests that flags should set and get correctly
        /// </summary>
        [Fact]
        public void Flags_Should_SetAndGetCorrectly()
        {
            Style style = new Style();
            StyleFlags value = StyleFlags.None;
            style.Flags = value;
            Assert.Equal(value, style.Flags);
        }

        /// <summary>
        ///     Tests that colors should set and get correctly
        /// </summary>
        [Fact]
        public void Colors_Should_SetAndGetCorrectly()
        {
            Style style = new Style();
            uint[] value = {0xFFFFFFFF, 0xFF000000};
            style.Colors = value;
            Assert.Equal(value, style.Colors);
        }
    }
}