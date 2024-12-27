// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StablePriorityQueueNodeTest.cs
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
    ///     The stable priority queue node test class
    /// </summary>
    	  
	 public class StablePriorityQueueNodeTest 
    {
        /// <summary>
        ///     Tests that insertion index initially zero
        /// </summary>
        [Fact]
        public void InsertionIndex_InitiallyZero()
        {
            StablePriorityQueueNode node = new StablePriorityQueueNode();
            Assert.Equal(0, node.InsertionIndex);
        }

        /// <summary>
        ///     Tests that insertion index set correctly
        /// </summary>
        [Fact]
        public void InsertionIndex_SetCorrectly()
        {
            StablePriorityQueueNode node = new StablePriorityQueueNode();
            node.InsertionIndex = 5;
            Assert.Equal(5, node.InsertionIndex);
        }
    }
}