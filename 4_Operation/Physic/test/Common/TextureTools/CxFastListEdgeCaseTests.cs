// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CxFastListEdgeCaseTests.cs
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

using Alis.Core.Physic.Common.TextureTools;
using Xunit;

namespace Alis.Core.Physic.Test.Common.TextureTools
{
    /// <summary>
    ///     Coverage tests for the cx fast list edge cases
    /// </summary>
    public class CxFastListEdgeCaseTests
    {
        /// <summary>
        ///     Tests that find returns null on an empty list
        /// </summary>
        [Fact]
        public void Find_OnEmptyList_ReturnsNull()
        {
            MarchingSquares.CxFastList<int> list = new MarchingSquares.CxFastList<int>();

            Assert.Null(list.Find(5));
            Assert.False(list.Has(5));
        }

        /// <summary>
        ///     Tests that find default returns null when the list has no default element
        /// </summary>
        [Fact]
        public void FindDefault_WhenNoDefaultElement_ReturnsNull()
        {
            MarchingSquares.CxFastList<int> list = new MarchingSquares.CxFastList<int>();
            list.Add(1);
            list.Add(2);

            Assert.Null(list.Find(0));
        }

        /// <summary>
        ///     Tests that find default returns the default element when present
        /// </summary>
        [Fact]
        public void FindDefault_WhenDefaultElementPresent_ReturnsIt()
        {
            MarchingSquares.CxFastList<int> list = new MarchingSquares.CxFastList<int>();
            list.Add(0);
            list.Add(1);

            Assert.Equal(0, list.Find(0).GetElem());
        }

        /// <summary>
        ///     Tests that erase on an empty list returns null
        /// </summary>
        [Fact]
        public void Erase_OnEmptyList_ReturnsNull()
        {
            MarchingSquares.CxFastList<int> list = new MarchingSquares.CxFastList<int>();
            CxFastListNode<int> node = new CxFastListNode<int>(1);

            Assert.Null(list.Erase(null, node));
        }

        /// <summary>
        ///     Tests that erase with a previous node patches the previous node
        /// </summary>
        [Fact]
        public void Erase_WithPreviousNode_PatchesLinks()
        {
            MarchingSquares.CxFastList<int> list = new MarchingSquares.CxFastList<int>();
            CxFastListNode<int> first = list.Add(1);
            CxFastListNode<int> second = list.Add(2);
            CxFastListNode<int> third = list.Add(3);

            CxFastListNode<int> result = list.Erase(third, second);

            Assert.Equal(1, result.GetElem());
            Assert.Equal(2, list.Size());
            Assert.Equal(3, list.Begin().GetElem());
        }
    }
}
