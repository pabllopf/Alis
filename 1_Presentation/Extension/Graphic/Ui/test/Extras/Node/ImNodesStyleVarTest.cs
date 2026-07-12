// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImNodesStyleVarTest.cs
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

using Alis.Extension.Graphic.Ui.Extras.Node;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Node
{
    /// <summary>
    ///     Provides unit coverage for <see cref="ImNodesStyleVar" /> enum values.
    /// </summary>
    public class ImNodesStyleVarTest
    {
        /// <summary>
        ///     Verifies that GridSpacing is zero.
        /// </summary>
        [Fact]
        public void GridSpacing_ShouldBeZero()
        {
            Assert.Equal(0, (int) ImNodesStyleVar.GridSpacing);
        }

        /// <summary>
        ///     Verifies that Count matches the expected number of entries.
        /// </summary>
        [Fact]
        public void Count_ShouldBeExpectedValue()
        {
            Assert.Equal(15, (int) ImNodesStyleVar.Count);
        }

        /// <summary>
        ///     Verifies that selected style var entries use distinct values.
        /// </summary>
        [Fact]
        public void StyleVars_ShouldBeDistinct()
        {
            Assert.NotEqual((int) ImNodesStyleVar.GridSpacing, (int) ImNodesStyleVar.NodeCornerRounding);
            Assert.NotEqual((int) ImNodesStyleVar.LinkThickness, (int) ImNodesStyleVar.PinCircleRadius);
            Assert.NotEqual((int) ImNodesStyleVar.MiniMapPadding, (int) ImNodesStyleVar.MiniMapOffset);
        }
    }
}
