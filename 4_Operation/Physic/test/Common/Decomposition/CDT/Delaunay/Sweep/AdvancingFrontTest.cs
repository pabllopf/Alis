// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AdvancingFrontTest.cs
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

using Alis.Core.Physic.Common.Decomposition.CDT;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Delaunay.Sweep
{
    /// <summary>
    ///     The advancing front test class
    /// </summary>
    public class AdvancingFrontTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with head and tail
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithHeadAndTail()
        {
            TriangulationPoint headPoint = new TriangulationPoint(0, 0);
            TriangulationPoint tailPoint = new TriangulationPoint(10, 0);
            AdvancingFrontNode head = new AdvancingFrontNode(headPoint);
            AdvancingFrontNode tail = new AdvancingFrontNode(tailPoint);

            AdvancingFront front = new AdvancingFront(head, tail);

            Assert.Equal(head, front.Head);
            Assert.Equal(tail, front.Tail);
        }

        /// <summary>
        ///     Tests that add node should be callable
        /// </summary>
        [Fact]
        public void AddNode_ShouldBeCallable()
        {
            TriangulationPoint headPoint = new TriangulationPoint(0, 0);
            TriangulationPoint tailPoint = new TriangulationPoint(10, 0);
            AdvancingFrontNode head = new AdvancingFrontNode(headPoint);
            AdvancingFrontNode tail = new AdvancingFrontNode(tailPoint);
            AdvancingFront front = new AdvancingFront(head, tail);

            TriangulationPoint newPoint = new TriangulationPoint(5, 5);
            AdvancingFrontNode newNode = new AdvancingFrontNode(newPoint);

            front.AddNode(newNode);

            Assert.NotNull(front);
        }

        /// <summary>
        ///     Tests that remove node should be callable
        /// </summary>
        [Fact]
        public void RemoveNode_ShouldBeCallable()
        {
            TriangulationPoint headPoint = new TriangulationPoint(0, 0);
            TriangulationPoint tailPoint = new TriangulationPoint(10, 0);
            AdvancingFrontNode head = new AdvancingFrontNode(headPoint);
            AdvancingFrontNode tail = new AdvancingFrontNode(tailPoint);
            AdvancingFront front = new AdvancingFront(head, tail);

            TriangulationPoint newPoint = new TriangulationPoint(5, 5);
            AdvancingFrontNode newNode = new AdvancingFrontNode(newPoint);
            front.AddNode(newNode);

            front.RemoveNode(newNode);

            Assert.NotNull(front);
        }


        /// <summary>
        ///     Tests that to string should return string representation
        /// </summary>
        [Fact]
        public void ToString_ShouldReturnStringRepresentation()
        {
            TriangulationPoint headPoint = new TriangulationPoint(0, 0);
            TriangulationPoint tailPoint = new TriangulationPoint(10, 0);
            AdvancingFrontNode head = new AdvancingFrontNode(headPoint);
            AdvancingFrontNode tail = new AdvancingFrontNode(tailPoint);
            head.Next = tail;
            tail.Prev = head;
            AdvancingFront front = new AdvancingFront(head, tail);

            string result = front.ToString();

            Assert.NotNull(result);
            Assert.Contains("0", result);
            Assert.Contains("10", result);
        }

        /// <summary>
        ///     Tests that advancing front should be reference type
        /// </summary>
        [Fact]
        public void AdvancingFront_ShouldBeReferenceType()
        {
            TriangulationPoint headPoint = new TriangulationPoint(0, 0);
            TriangulationPoint tailPoint = new TriangulationPoint(10, 0);
            AdvancingFrontNode head = new AdvancingFrontNode(headPoint);
            AdvancingFrontNode tail = new AdvancingFrontNode(tailPoint);
            AdvancingFront front1 = new AdvancingFront(head, tail);
            AdvancingFront front2 = front1;

            Assert.Same(front1, front2);
        }

        /// <summary>
        ///     Tests that head property should be accessible
        /// </summary>
        [Fact]
        public void HeadProperty_ShouldBeAccessible()
        {
            TriangulationPoint headPoint = new TriangulationPoint(0, 0);
            TriangulationPoint tailPoint = new TriangulationPoint(10, 0);
            AdvancingFrontNode head = new AdvancingFrontNode(headPoint);
            AdvancingFrontNode tail = new AdvancingFrontNode(tailPoint);
            AdvancingFront front = new AdvancingFront(head, tail);

            AdvancingFrontNode headNode = front.Head;

            Assert.Equal(head, headNode);
        }

        /// <summary>
        ///     Tests that tail property should be accessible
        /// </summary>
        [Fact]
        public void TailProperty_ShouldBeAccessible()
        {
            TriangulationPoint headPoint = new TriangulationPoint(0, 0);
            TriangulationPoint tailPoint = new TriangulationPoint(10, 0);
            AdvancingFrontNode head = new AdvancingFrontNode(headPoint);
            AdvancingFrontNode tail = new AdvancingFrontNode(tailPoint);
            AdvancingFront front = new AdvancingFront(head, tail);

            AdvancingFrontNode tailNode = front.Tail;

            Assert.Equal(tail, tailNode);
        }

        /// <summary>
        ///     Tests that multiple fronts should be independent
        /// </summary>
        [Fact]
        public void MultipleFronts_ShouldBeIndependent()
        {
            TriangulationPoint headPoint1 = new TriangulationPoint(0, 0);
            TriangulationPoint tailPoint1 = new TriangulationPoint(10, 0);
            AdvancingFrontNode head1 = new AdvancingFrontNode(headPoint1);
            AdvancingFrontNode tail1 = new AdvancingFrontNode(tailPoint1);

            TriangulationPoint headPoint2 = new TriangulationPoint(5, 5);
            TriangulationPoint tailPoint2 = new TriangulationPoint(15, 5);
            AdvancingFrontNode head2 = new AdvancingFrontNode(headPoint2);
            AdvancingFrontNode tail2 = new AdvancingFrontNode(tailPoint2);

            AdvancingFront front1 = new AdvancingFront(head1, tail1);
            AdvancingFront front2 = new AdvancingFront(head2, tail2);

            Assert.NotSame(front1, front2);
        }

        /// <summary>
        ///     Tests that LocateNode returns correct node for x between head and next
        /// </summary>
        [Fact]
        public void LocateNode_BetweenHeadAndFirstNode_ReturnsHead()
        {
            TriangulationPoint headPoint = new TriangulationPoint(0, 0);
            TriangulationPoint midPoint = new TriangulationPoint(5, 0);
            TriangulationPoint tailPoint = new TriangulationPoint(10, 0);

            AdvancingFrontNode head = new AdvancingFrontNode(headPoint);
            AdvancingFrontNode mid = new AdvancingFrontNode(midPoint);
            AdvancingFrontNode tail = new AdvancingFrontNode(tailPoint);

            head.Next = mid;
            mid.Prev = head;
            mid.Next = tail;
            tail.Prev = mid;

            AdvancingFront front = new AdvancingFront(head, tail);

            AdvancingFrontNode result = front.LocateNode(new TriangulationPoint(3, 0));

            Assert.Same(head, result);
        }

        /// <summary>
        ///     Tests that LocateNode returns correct node for x between two inner nodes
        /// </summary>
        [Fact]
        public void LocateNode_BetweenMiddleNodes_ReturnsPreviousNode()
        {
            TriangulationPoint headPoint = new TriangulationPoint(0, 0);
            TriangulationPoint mid1Point = new TriangulationPoint(5, 0);
            TriangulationPoint mid2Point = new TriangulationPoint(8, 0);
            TriangulationPoint tailPoint = new TriangulationPoint(10, 0);

            AdvancingFrontNode head = new AdvancingFrontNode(headPoint);
            AdvancingFrontNode mid1 = new AdvancingFrontNode(mid1Point);
            AdvancingFrontNode mid2 = new AdvancingFrontNode(mid2Point);
            AdvancingFrontNode tail = new AdvancingFrontNode(tailPoint);

            head.Next = mid1;
            mid1.Prev = head;
            mid1.Next = mid2;
            mid2.Prev = mid1;
            mid2.Next = tail;
            tail.Prev = mid2;

            AdvancingFront front = new AdvancingFront(head, tail);

            AdvancingFrontNode result = front.LocateNode(new TriangulationPoint(6, 0));

            Assert.Same(mid1, result);
        }

        /// <summary>
        ///     Tests that LocateNode returns null when x is beyond tail
        /// </summary>
        [Fact]
        public void LocateNode_AfterTail_ReturnsNull()
        {
            TriangulationPoint headPoint = new TriangulationPoint(0, 0);
            TriangulationPoint tailPoint = new TriangulationPoint(10, 0);

            AdvancingFrontNode head = new AdvancingFrontNode(headPoint);
            AdvancingFrontNode tail = new AdvancingFrontNode(tailPoint);

            head.Next = tail;
            tail.Prev = head;

            AdvancingFront front = new AdvancingFront(head, tail);

            AdvancingFrontNode result = front.LocateNode(new TriangulationPoint(20, 0));

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that LocateNode returns null when x is before head
        /// </summary>
        [Fact]
        public void LocateNode_BeforeHead_ReturnsNull()
        {
            TriangulationPoint headPoint = new TriangulationPoint(0, 0);
            TriangulationPoint tailPoint = new TriangulationPoint(10, 0);

            AdvancingFrontNode head = new AdvancingFrontNode(headPoint);
            AdvancingFrontNode tail = new AdvancingFrontNode(tailPoint);

            head.Next = tail;
            tail.Prev = head;

            AdvancingFront front = new AdvancingFront(head, tail);

            AdvancingFrontNode result = front.LocateNode(new TriangulationPoint(-5, 0));

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that LocatePoint finds exact match on head
        /// </summary>
        [Fact]
        public void LocatePoint_ExactMatchOnHead_ReturnsHead()
        {
            TriangulationPoint headPoint = new TriangulationPoint(0, 0);
            TriangulationPoint tailPoint = new TriangulationPoint(10, 0);

            AdvancingFrontNode head = new AdvancingFrontNode(headPoint);
            AdvancingFrontNode tail = new AdvancingFrontNode(tailPoint);

            head.Next = tail;
            tail.Prev = head;

            AdvancingFront front = new AdvancingFront(head, tail);

            AdvancingFrontNode result = front.LocatePoint(headPoint);

            Assert.Same(head, result);
        }

        /// <summary>
        ///     Tests that LocatePoint searches forward and finds the node
        /// </summary>
        [Fact]
        public void LocatePoint_SearchForward_FindsNode()
        {
            TriangulationPoint headPoint = new TriangulationPoint(0, 0);
            TriangulationPoint midPoint = new TriangulationPoint(5, 0);
            TriangulationPoint tailPoint = new TriangulationPoint(10, 0);

            AdvancingFrontNode head = new AdvancingFrontNode(headPoint);
            AdvancingFrontNode mid = new AdvancingFrontNode(midPoint);
            AdvancingFrontNode tail = new AdvancingFrontNode(tailPoint);

            head.Next = mid;
            mid.Prev = head;
            mid.Next = tail;
            tail.Prev = mid;

            AdvancingFront front = new AdvancingFront(head, tail);

            AdvancingFrontNode result = front.LocatePoint(midPoint);

            Assert.Same(mid, result);
        }

        /// <summary>
        ///     Tests that LocatePoint returns null when searching backward and point is not found
        /// </summary>
        [Fact]
        public void LocatePoint_SearchPrevDirection_NotFound_ReturnsNull()
        {
            TriangulationPoint headPoint = new TriangulationPoint(0, 0);
            TriangulationPoint tailPoint = new TriangulationPoint(10, 0);

            AdvancingFrontNode head = new AdvancingFrontNode(headPoint);
            AdvancingFrontNode tail = new AdvancingFrontNode(tailPoint);

            head.Next = tail;
            tail.Prev = head;

            AdvancingFront front = new AdvancingFront(head, tail);

            // px=-1 < head.X=0 → SearchPrevDirection → head.Prev is null → returns null
            AdvancingFrontNode result = front.LocatePoint(new TriangulationPoint(-1, 0));

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that LocateNode returns correct node for x near tail
        /// </summary>
        [Fact]
        public void LocateNode_NearTail_ReturnsLastInnerNode()
        {
            TriangulationPoint headPoint = new TriangulationPoint(0, 0);
            TriangulationPoint midPoint = new TriangulationPoint(5, 0);
            TriangulationPoint tailPoint = new TriangulationPoint(10, 0);

            AdvancingFrontNode head = new AdvancingFrontNode(headPoint);
            AdvancingFrontNode mid = new AdvancingFrontNode(midPoint);
            AdvancingFrontNode tail = new AdvancingFrontNode(tailPoint);

            head.Next = mid;
            mid.Prev = head;
            mid.Next = tail;
            tail.Prev = mid;

            AdvancingFront front = new AdvancingFront(head, tail);

            AdvancingFrontNode result = front.LocateNode(new TriangulationPoint(9, 0));

            Assert.Same(mid, result);
        }
    }
}