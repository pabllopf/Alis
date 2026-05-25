// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TreeNodeTest.cs
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

using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    /// The tree node test class
    /// </summary>
    public class TreeNodeTest
    {
        /// <summary>
        /// Tests that is leaf should return true when child 1 is null node
        /// </summary>
        [Fact]
        public void IsLeaf_ShouldReturnTrue_WhenChild1IsNullNode()
        {
            TreeNode<int> node = new TreeNode<int>();
            node.Child1 = DynamicTree<int>.NullNode;

            Assert.True(node.IsLeaf());
        }

        /// <summary>
        /// Tests that is leaf should return false when child 1 is valid
        /// </summary>
        [Fact]
        public void IsLeaf_ShouldReturnFalse_WhenChild1IsValid()
        {
            TreeNode<int> node = new TreeNode<int>();
            node.Child1 = 0;

            Assert.False(node.IsLeaf());
        }
    }
}

