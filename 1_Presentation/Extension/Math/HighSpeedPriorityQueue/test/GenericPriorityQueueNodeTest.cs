// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GenericPriorityQueueNodeTest.cs
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

using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Alis.Extension.Math.HighSpeedPriorityQueue.Test
{
    /// <summary>
    ///     The generic priority queue node test class
    /// </summary>
    	 [ExcludeFromCodeCoverage] 
	 public class GenericPriorityQueueNodeTest 
    {
        /// <summary>
        ///     Tests that priority set and get returns correct value
        /// </summary>
        [Fact]
        public void Priority_SetAndGet_ReturnsCorrectValue()
        {
            GenericPriorityQueueNode<int> node = new GenericPriorityQueueNode<int>();
            node.Priority = 5;
            Assert.Equal(5, node.Priority);
        }

        /// <summary>
        ///     Tests that queue index set and get returns correct value
        /// </summary>
        [Fact]
        public void QueueIndex_SetAndGet_ReturnsCorrectValue()
        {
            GenericPriorityQueueNode<int> node = new GenericPriorityQueueNode<int>();
            node.QueueIndex = 2;
            Assert.Equal(2, node.QueueIndex);
        }

        /// <summary>
        ///     Tests that insertion index set and get returns correct value
        /// </summary>
        [Fact]
        public void InsertionIndex_SetAndGet_ReturnsCorrectValue()
        {
            GenericPriorityQueueNode<int> node = new GenericPriorityQueueNode<int>();
            node.InsertionIndex = 10;
            Assert.Equal(10, node.InsertionIndex);
        }
    }
}