// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImNodesColTest.cs
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
    ///     Provides unit coverage for <see cref="ImNodesCol" /> enum values.
    /// </summary>
    public class ImNodesColTest
    {
        /// <summary>
        ///     Verifies that NodeBackground is zero.
        /// </summary>
        [Fact]
        public void NodeBackground_ShouldBeZero()
        {
            Assert.Equal(0, (int) ImNodesCol.NodeBackground);
        }

        /// <summary>
        ///     Verifies that Count matches the expected number of entries.
        /// </summary>
        [Fact]
        public void Count_ShouldBeExpectedValue()
        {
            Assert.Equal(29, (int) ImNodesCol.Count);
        }

        /// <summary>
        ///     Verifies that selected color entries use distinct values.
        /// </summary>
        [Fact]
        public void Colors_ShouldBeDistinct()
        {
            Assert.NotEqual((int) ImNodesCol.NodeBackground, (int) ImNodesCol.TitleBar);
            Assert.NotEqual((int) ImNodesCol.Link, (int) ImNodesCol.Pin);
            Assert.NotEqual((int) ImNodesCol.GridBackground, (int) ImNodesCol.GridLine);
            Assert.NotEqual((int) ImNodesCol.MiniMapBackground, (int) ImNodesCol.MiniMapOutline);
        }
    }
}
