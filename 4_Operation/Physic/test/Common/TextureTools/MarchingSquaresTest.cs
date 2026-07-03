// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MarchingSquaresTest.cs
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
using Alis.Core.Physic.Common.TextureTools;
using Xunit;

namespace Alis.Core.Physic.Test.Common.TextureTools
{
    public class MarchingSquaresTest
    {
        [Fact]
        public void MarchingSquares_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(MarchingSquares));
        }

        [Fact]
        public void CxFastList_Add_ShouldIncreaseCount()
        {
            MarchingSquares.CxFastList<int> list = new MarchingSquares.CxFastList<int>();
            list.Add(1);
            Assert.Equal(1, list.Size());
        }

        [Fact]
        public void CxFastList_AddMultiple_ShouldMaintainOrder()
        {
            MarchingSquares.CxFastList<int> list = new MarchingSquares.CxFastList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.Equal(3, list.Size());
        }

        [Fact]
        public void CxFastList_Empty_OnNewList_ReturnsTrue()
        {
            MarchingSquares.CxFastList<int> list = new MarchingSquares.CxFastList<int>();
            Assert.True(list.Empty());
        }

        [Fact]
        public void CxFastList_Remove_ExistingElement_ReturnsTrue()
        {
            MarchingSquares.CxFastList<int> list = new MarchingSquares.CxFastList<int>();
            list.Add(1);
            list.Add(2);
            Assert.True(list.Remove(2));
        }

        [Fact]
        public void CxFastList_Remove_NonExistingElement_ReturnsFalse()
        {
            MarchingSquares.CxFastList<int> list = new MarchingSquares.CxFastList<int>();
            list.Add(1);
            Assert.False(list.Remove(99));
        }

        [Fact]
        public void CxFastList_Pop_ShouldRemoveHead()
        {
            MarchingSquares.CxFastList<int> list = new MarchingSquares.CxFastList<int>();
            list.Add(1);
            list.Add(2);
            list.Pop();
            Assert.Equal(1, list.Size());
        }

        [Fact]
        public void CxFastList_Clear_ShouldEmptyList()
        {
            MarchingSquares.CxFastList<int> list = new MarchingSquares.CxFastList<int>();
            list.Add(1);
            list.Add(2);
            list.Clear();
            Assert.True(list.Empty());
        }

        [Fact]
        public void CxFastList_Begin_OnEmptyList_ReturnsNull()
        {
            MarchingSquares.CxFastList<int> list = new MarchingSquares.CxFastList<int>();
            Assert.Null(list.Begin());
        }

        [Fact]
        public void CxFastList_End_ShouldReturnNull()
        {
            MarchingSquares.CxFastList<int> list = new MarchingSquares.CxFastList<int>();
            Assert.Null(list.End());
        }

        [Fact]
        public void CxFastList_Front_ShouldReturnHeadValue()
        {
            MarchingSquares.CxFastList<int> list = new MarchingSquares.CxFastList<int>();
            list.Add(42);
            list.Add(7);
            Assert.Equal(7, list.Front());
        }

        [Fact]
        public void CxFastList_Has_ShouldFindElement()
        {
            MarchingSquares.CxFastList<int> list = new MarchingSquares.CxFastList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.True(list.Has(2));
            Assert.False(list.Has(99));
        }

        [Fact]
        public void CxFastList_Insert_ShouldAddAfterNode()
        {
            MarchingSquares.CxFastList<int> list = new MarchingSquares.CxFastList<int>();
            list.Add(1);
            list.Add(3);
            CxFastListNode<int> node = list.Find(3);
            list.Insert(node, 2);
            Assert.True(list.Has(2));
        }

        [Fact]
        public void CxFastList_Erase_ShouldRemoveNode()
        {
            MarchingSquares.CxFastList<int> list = new MarchingSquares.CxFastList<int>();
            list.Add(1);
            list.Add(2);
            CxFastListNode<int> node = list.Find(2);
            list.Erase(null, node);
            Assert.False(list.Has(2));
        }

        [Fact]
        public void CxFastList_GetListOfElements_ShouldReturnAll()
        {
            MarchingSquares.CxFastList<int> list = new MarchingSquares.CxFastList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            var elements = list.GetListOfElements();
            Assert.Equal(3, elements.Count);
        }

        [Fact]
        public void CxFastListNode_Constructor_ShouldStoreValue()
        {
            CxFastListNode<int> node = new CxFastListNode<int>(42);
            Assert.Equal(42, node.GetElem());
        }

        [Fact]
        public void CxFastListNode_NextPos_WithNext_ShouldReturnNext()
        {
            CxFastListNode<int> node1 = new CxFastListNode<int>(1);
            CxFastListNode<int> node2 = new CxFastListNode<int>(2);
            node1.Next = node2;
            Assert.Equal(node2, node1.NextPos());
        }

        [Fact]
        public void GeomPoly_Constructor_ShouldInitializeEmpty()
        {
            MarchingSquares.GeomPoly poly = new MarchingSquares.GeomPoly();
            Assert.NotNull(poly.Points);
            Assert.Equal(0, poly.Length);
        }
    }
}
