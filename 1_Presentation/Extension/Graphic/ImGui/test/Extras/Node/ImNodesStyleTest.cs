// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImNodesStyleTest.cs
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
using Alis.Extension.Graphic.ImGui.Extras.Node;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test.Extras.Node
{
    /// <summary>
    ///     The im nodes style test class
    /// </summary>
    public class ImNodesStyleTest
    {
        /// <summary>
        ///     Tests that grid spacing should be initialized
        /// </summary>
        [Fact]
        public void GridSpacing_ShouldBeInitialized()
        {
            ImNodesStyle style = new ImNodesStyle();
            Assert.Equal(default(float), style.GridSpacing);
        }

        /// <summary>
        ///     Tests that node corner rounding should be initialized
        /// </summary>
        [Fact]
        public void NodeCornerRounding_ShouldBeInitialized()
        {
            ImNodesStyle style = new ImNodesStyle();
            Assert.Equal(default(float), style.NodeCornerRounding);
        }

        /// <summary>
        ///     Tests that node padding should be initialized
        /// </summary>
        [Fact]
        public void NodePadding_ShouldBeInitialized()
        {
            ImNodesStyle style = new ImNodesStyle();
            Assert.Equal(default(Vector2F), style.NodePadding);
        }

        /// <summary>
        ///     Tests that node border thickness should be initialized
        /// </summary>
        [Fact]
        public void NodeBorderThickness_ShouldBeInitialized()
        {
            ImNodesStyle style = new ImNodesStyle();
            Assert.Equal(default(float), style.NodeBorderThickness);
        }

        /// <summary>
        ///     Tests that link thickness should be initialized
        /// </summary>
        [Fact]
        public void LinkThickness_ShouldBeInitialized()
        {
            ImNodesStyle style = new ImNodesStyle();
            Assert.Equal(default(float), style.LinkThickness);
        }

        /// <summary>
        ///     Tests that link line segments per length should be initialized
        /// </summary>
        [Fact]
        public void LinkLineSegmentsPerLength_ShouldBeInitialized()
        {
            ImNodesStyle style = new ImNodesStyle();
            Assert.Equal(default(float), style.LinkLineSegmentsPerLength);
        }

        /// <summary>
        ///     Tests that link hover distance should be initialized
        /// </summary>
        [Fact]
        public void LinkHoverDistance_ShouldBeInitialized()
        {
            ImNodesStyle style = new ImNodesStyle();
            Assert.Equal(default(float), style.LinkHoverDistance);
        }

        /// <summary>
        ///     Tests that pin circle radius should be initialized
        /// </summary>
        [Fact]
        public void PinCircleRadius_ShouldBeInitialized()
        {
            ImNodesStyle style = new ImNodesStyle();
            Assert.Equal(default(float), style.PinCircleRadius);
        }

        /// <summary>
        ///     Tests that pin quad side length should be initialized
        /// </summary>
        [Fact]
        public void PinQuadSideLength_ShouldBeInitialized()
        {
            ImNodesStyle style = new ImNodesStyle();
            Assert.Equal(default(float), style.PinQuadSideLength);
        }

        /// <summary>
        ///     Tests that pin triangle side length should be initialized
        /// </summary>
        [Fact]
        public void PinTriangleSideLength_ShouldBeInitialized()
        {
            ImNodesStyle style = new ImNodesStyle();
            Assert.Equal(default(float), style.PinTriangleSideLength);
        }

        /// <summary>
        ///     Tests that pin line thickness should be initialized
        /// </summary>
        [Fact]
        public void PinLineThickness_ShouldBeInitialized()
        {
            ImNodesStyle style = new ImNodesStyle();
            Assert.Equal(default(float), style.PinLineThickness);
        }

        /// <summary>
        ///     Tests that pin hover radius should be initialized
        /// </summary>
        [Fact]
        public void PinHoverRadius_ShouldBeInitialized()
        {
            ImNodesStyle style = new ImNodesStyle();
            Assert.Equal(default(float), style.PinHoverRadius);
        }

        /// <summary>
        ///     Tests that pin offset should be initialized
        /// </summary>
        [Fact]
        public void PinOffset_ShouldBeInitialized()
        {
            ImNodesStyle style = new ImNodesStyle();
            Assert.Equal(default(float), style.PinOffset);
        }

        /// <summary>
        ///     Tests that mini map padding should be initialized
        /// </summary>
        [Fact]
        public void MiniMapPadding_ShouldBeInitialized()
        {
            ImNodesStyle style = new ImNodesStyle();
            Assert.Equal(default(Vector2F), style.MiniMapPadding);
        }

        /// <summary>
        ///     Tests that mini map offset should be initialized
        /// </summary>
        [Fact]
        public void MiniMapOffset_ShouldBeInitialized()
        {
            ImNodesStyle style = new ImNodesStyle();
            Assert.Equal(default(Vector2F), style.MiniMapOffset);
        }

        /// <summary>
        ///     Tests that flags should be initialized
        /// </summary>
        [Fact]
        public void Flags_ShouldBeInitialized()
        {
            ImNodesStyle style = new ImNodesStyle();
            Assert.Equal(default(ImNodesStyleFlags), style.Flags);
        }

        /// <summary>
        ///     Tests that colors should be initialized
        /// </summary>
        [Fact]
        public void Colors_ShouldBeInitialized()
        {
            ImNodesStyle style = new ImNodesStyle();
            Assert.Null(style.Colors);
        }

        /// <summary>
        ///     Tests that grid spacing should set and get correctly
        /// </summary>
        [Fact]
        public void GridSpacing_Should_SetAndGetCorrectly()
        {
            ImNodesStyle style = new ImNodesStyle();
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
            ImNodesStyle style = new ImNodesStyle();
            float value = 5.0f;
            style.NodeCornerRounding = value;
            Assert.Equal(value, style.NodeCornerRounding);
        }

        /// <summary>
        ///     Tests that node padding should set and get correctly
        /// </summary>
        [Fact]
        public void NodePadding_Should_SetAndGetCorrectly()
        {
            ImNodesStyle style = new ImNodesStyle();
            Vector2F value = new Vector2F(1.0f, 2.0f);
            style.NodePadding = value;
            Assert.Equal(value, style.NodePadding);
        }

        /// <summary>
        ///     Tests that node border thickness should set and get correctly
        /// </summary>
        [Fact]
        public void NodeBorderThickness_Should_SetAndGetCorrectly()
        {
            ImNodesStyle style = new ImNodesStyle();
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
            ImNodesStyle style = new ImNodesStyle();
            float value = 3.0f;
            style.LinkThickness = value;
            Assert.Equal(value, style.LinkThickness);
        }

        /// <summary>
        ///     Tests that link line segments per length should set and get correctly
        /// </summary>
        [Fact]
        public void LinkLineSegmentsPerLength_Should_SetAndGetCorrectly()
        {
            ImNodesStyle style = new ImNodesStyle();
            float value = 4.0f;
            style.LinkLineSegmentsPerLength = value;
            Assert.Equal(value, style.LinkLineSegmentsPerLength);
        }

        /// <summary>
        ///     Tests that link hover distance should set and get correctly
        /// </summary>
        [Fact]
        public void LinkHoverDistance_Should_SetAndGetCorrectly()
        {
            ImNodesStyle style = new ImNodesStyle();
            float value = 5.0f;
            style.LinkHoverDistance = value;
            Assert.Equal(value, style.LinkHoverDistance);
        }

        /// <summary>
        ///     Tests that pin circle radius should set and get correctly
        /// </summary>
        [Fact]
        public void PinCircleRadius_Should_SetAndGetCorrectly()
        {
            ImNodesStyle style = new ImNodesStyle();
            float value = 6.0f;
            style.PinCircleRadius = value;
            Assert.Equal(value, style.PinCircleRadius);
        }

        /// <summary>
        ///     Tests that pin quad side length should set and get correctly
        /// </summary>
        [Fact]
        public void PinQuadSideLength_Should_SetAndGetCorrectly()
        {
            ImNodesStyle style = new ImNodesStyle();
            float value = 7.0f;
            style.PinQuadSideLength = value;
            Assert.Equal(value, style.PinQuadSideLength);
        }

        /// <summary>
        ///     Tests that pin triangle side length should set and get correctly
        /// </summary>
        [Fact]
        public void PinTriangleSideLength_Should_SetAndGetCorrectly()
        {
            ImNodesStyle style = new ImNodesStyle();
            float value = 8.0f;
            style.PinTriangleSideLength = value;
            Assert.Equal(value, style.PinTriangleSideLength);
        }

        /// <summary>
        ///     Tests that pin line thickness should set and get correctly
        /// </summary>
        [Fact]
        public void PinLineThickness_Should_SetAndGetCorrectly()
        {
            ImNodesStyle style = new ImNodesStyle();
            float value = 9.0f;
            style.PinLineThickness = value;
            Assert.Equal(value, style.PinLineThickness);
        }

        /// <summary>
        ///     Tests that pin hover radius should set and get correctly
        /// </summary>
        [Fact]
        public void PinHoverRadius_Should_SetAndGetCorrectly()
        {
            ImNodesStyle style = new ImNodesStyle();
            float value = 10.0f;
            style.PinHoverRadius = value;
            Assert.Equal(value, style.PinHoverRadius);
        }

        /// <summary>
        ///     Tests that pin offset should set and get correctly
        /// </summary>
        [Fact]
        public void PinOffset_Should_SetAndGetCorrectly()
        {
            ImNodesStyle style = new ImNodesStyle();
            float value = 11.0f;
            style.PinOffset = value;
            Assert.Equal(value, style.PinOffset);
        }

        /// <summary>
        ///     Tests that mini map padding should set and get correctly
        /// </summary>
        [Fact]
        public void MiniMapPadding_Should_SetAndGetCorrectly()
        {
            ImNodesStyle style = new ImNodesStyle();
            Vector2F value = new Vector2F(3.0f, 4.0f);
            style.MiniMapPadding = value;
            Assert.Equal(value, style.MiniMapPadding);
        }

        /// <summary>
        ///     Tests that mini map offset should set and get correctly
        /// </summary>
        [Fact]
        public void MiniMapOffset_Should_SetAndGetCorrectly()
        {
            ImNodesStyle style = new ImNodesStyle();
            Vector2F value = new Vector2F(5.0f, 6.0f);
            style.MiniMapOffset = value;
            Assert.Equal(value, style.MiniMapOffset);
        }

        /// <summary>
        ///     Tests that flags should set and get correctly
        /// </summary>
        [Fact]
        public void Flags_Should_SetAndGetCorrectly()
        {
            ImNodesStyle style = new ImNodesStyle();
            ImNodesStyleFlags value = ImNodesStyleFlags.NodeOutline;
            style.Flags = value;
            Assert.Equal(value, style.Flags);
        }

        /// <summary>
        ///     Tests that colors should set and get correctly
        /// </summary>
        [Fact]
        public void Colors_Should_SetAndGetCorrectly()
        {
            ImNodesStyle style = new ImNodesStyle();
            uint[] value = {0xFF0000, 0x00FF00, 0x0000FF};
            style.Colors = value;
            Assert.Equal(value, style.Colors);
        }
    }
}