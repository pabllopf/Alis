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

using Alis.Core.Physic.Collision.BroadPhase;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.BroadPhase
{
    /// <summary>
    ///     The tree node test class
    /// </summary>
    public class TreeNodeTest
    {
        /// <summary>
        ///     Tests that test child 1
        /// </summary>
        [Fact]
        public void TestChild1()
        {
            TreeNode<int> treeNode = new TreeNode<int>
            {
                Child1 = 1
            };
            Assert.Equal(1, treeNode.Child1);
        }
        
        /// <summary>
        ///     Tests that test child 2
        /// </summary>
        [Fact]
        public void TestChild2()
        {
            TreeNode<int> treeNode = new TreeNode<int>
            {
                Child2 = 2
            };
            Assert.Equal(2, treeNode.Child2);
        }
        
        /// <summary>
        ///     Tests that test height
        /// </summary>
        [Fact]
        public void TestHeight()
        {
            TreeNode<int> treeNode = new TreeNode<int>
            {
                Height = 3
            };
            Assert.Equal(3, treeNode.Height);
        }
        
        /// <summary>
        ///     Tests that test moved
        /// </summary>
        [Fact]
        public void TestMoved()
        {
            TreeNode<int> treeNode = new TreeNode<int>
            {
                Moved = true
            };
            Assert.True(treeNode.Moved);
        }
        
        /// <summary>
        ///     Tests that test parent or next
        /// </summary>
        [Fact]
        public void TestParentOrNext()
        {
            TreeNode<int> treeNode = new TreeNode<int>
            {
                ParentOrNext = 4
            };
            Assert.Equal(4, treeNode.ParentOrNext);
        }
        
        /// <summary>
        ///     Tests that test user data
        /// </summary>
        [Fact]
        public void TestUserData()
        {
            TreeNode<int> treeNode = new TreeNode<int>
            {
                UserData = 5
            };
            Assert.Equal(5, treeNode.UserData);
        }
        
        /// <summary>
        ///     Tests that test is leaf
        /// </summary>
        [Fact]
        public void TestIsLeaf()
        {
            TreeNode<int> treeNode = new TreeNode<int>
            {
                Child1 = DynamicTree<int>.NullNode
            };
            Assert.True(treeNode.IsLeaf());
        }
    }
}