// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImNodesStyleRemainingCoverageTests.cs
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
using Alis.Extension.Graphic.Ui.Extras.Node;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Node
{
    /// <summary>
    ///     The im nodes style remaining coverage tests class
    /// </summary>
    public class ImNodesStyleRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that properties round trip
        /// </summary>
         [RequireCImguiSystemFact]
        public void Properties_RoundTrip()
        {
            ImNodesStyle style = new ImNodesStyle
            {
                GridSpacing = 32.0f,
                NodeCornerRounding = 4.0f,
                NodePadding = new Vector2F(8, 8),
                NodeBorderThickness = 1.0f,
                LinkThickness = 3.0f,
                LinkLineSegmentsPerLength = 0.1f,
                LinkHoverDistance = 10.0f,
                PinCircleRadius = 4.0f,
                PinQuadSideLength = 8.0f,
                PinTriangleSideLength = 10.0f,
                PinLineThickness = 2.0f,
                PinHoverRadius = 10.0f,
                PinOffset = 0.0f,
                MiniMapPadding = new Vector2F(8, 8),
                MiniMapOffset = new Vector2F(12, 12),
                Flags = ImNodesStyleFlags.None
            };

            Assert.Equal(32.0f, style.GridSpacing, 5);
            Assert.Equal(4.0f, style.NodeCornerRounding, 5);
            Assert.Equal(8, style.NodePadding.X);
            Assert.Equal(8, style.NodePadding.Y);
            Assert.Equal(1.0f, style.NodeBorderThickness, 5);
            Assert.Equal(3.0f, style.LinkThickness, 5);
            Assert.Equal(0.1f, style.LinkLineSegmentsPerLength, 5);
            Assert.Equal(10.0f, style.LinkHoverDistance, 5);
            Assert.Equal(4.0f, style.PinCircleRadius, 5);
            Assert.Equal(8.0f, style.PinQuadSideLength, 5);
            Assert.Equal(10.0f, style.PinTriangleSideLength, 5);
            Assert.Equal(2.0f, style.PinLineThickness, 5);
            Assert.Equal(10.0f, style.PinHoverRadius, 5);
            Assert.Equal(0.0f, style.PinOffset, 5);
            Assert.Equal(8, style.MiniMapPadding.X);
            Assert.Equal(12, style.MiniMapOffset.Y);
            Assert.Equal(ImNodesStyleFlags.None, style.Flags);
        }

        /// <summary>
        ///     Tests that defaults are zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void Defaults_AreZero()
        {
            ImNodesStyle style = new ImNodesStyle();

            Assert.Equal(0.0f, style.GridSpacing, 5);
            Assert.Equal(0.0f, style.NodeCornerRounding, 5);
            Assert.Equal(0.0f, style.NodeBorderThickness, 5);
            Assert.Equal(0.0f, style.LinkThickness, 5);
            Assert.Equal(ImNodesStyleFlags.None, style.Flags);
        }

        /// <summary>
        ///     Tests that flags with node outline round trip
        /// </summary>
         [RequireCImguiSystemFact]
        public void Flags_WithNodeOutline_RoundTrip()
        {
            ImNodesStyle style = new ImNodesStyle();

            style.Flags = ImNodesStyleFlags.NodeOutline | ImNodesStyleFlags.GridLines;

            Assert.Equal(ImNodesStyleFlags.NodeOutline | ImNodesStyleFlags.GridLines, style.Flags);
        }
    }
}
