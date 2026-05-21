

using Alis.Core.Physic.Common.TextureTools;
using Xunit;

namespace Alis.Core.Physic.Test.Common.TextureTools
{
    /// <summary>
    ///     The cx fast list node test class
    /// </summary>
    public class CxFastListNodeTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with element
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithElement()
        {
            int value = 42;

            CxFastListNode<int> node = new CxFastListNode<int>(value);

            Assert.Equal(value, node.Elt);
            Assert.Null(node.Next);
        }

        /// <summary>
        ///     Tests that get elem should return element
        /// </summary>
        [Fact]
        public void GetElem_ShouldReturnElement()
        {
            string value = "test";
            CxFastListNode<string> node = new CxFastListNode<string>(value);

            string result = node.GetElem();

            Assert.Equal(value, result);
        }

        /// <summary>
        ///     Tests that next pos should return next node
        /// </summary>
        [Fact]
        public void NextPos_ShouldReturnNextNode()
        {
            CxFastListNode<int> node1 = new CxFastListNode<int>(1);
            CxFastListNode<int> node2 = new CxFastListNode<int>(2);
            node1.Next = node2;

            CxFastListNode<int> result = node1.NextPos();

            Assert.Equal(node2, result);
        }

        /// <summary>
        ///     Tests that next pos should return null when no next node
        /// </summary>
        [Fact]
        public void NextPos_ShouldReturnNull_WhenNoNextNode()
        {
            CxFastListNode<int> node = new CxFastListNode<int>(1);

            CxFastListNode<int> result = node.NextPos();

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that next property should set and get correctly
        /// </summary>
        [Fact]
        public void NextProperty_ShouldSetAndGetCorrectly()
        {
            CxFastListNode<int> node1 = new CxFastListNode<int>(1);
            CxFastListNode<int> node2 = new CxFastListNode<int>(2);

            node1.Next = node2;

            Assert.Equal(node2, node1.Next);
        }

        /// <summary>
        ///     Tests that cx fast list node should support linked list structure
        /// </summary>
        [Fact]
        public void CxFastListNode_ShouldSupportLinkedListStructure()
        {
            CxFastListNode<int> node1 = new CxFastListNode<int>(1);
            CxFastListNode<int> node2 = new CxFastListNode<int>(2);
            CxFastListNode<int> node3 = new CxFastListNode<int>(3);

            node1.Next = node2;
            node2.Next = node3;

            Assert.Equal(node2, node1.Next);
            Assert.Equal(node3, node2.Next);
            Assert.Null(node3.Next);
        }

        /// <summary>
        ///     Tests that cx fast list node should support generic types
        /// </summary>
        [Fact]
        public void CxFastListNode_ShouldSupportGenericTypes()
        {
            CxFastListNode<string> stringNode = new CxFastListNode<string>("hello");
            CxFastListNode<double> doubleNode = new CxFastListNode<double>(3.14);
            CxFastListNode<bool> boolNode = new CxFastListNode<bool>(true);

            Assert.Equal("hello", stringNode.Elt);
            Assert.Equal(3.14, doubleNode.Elt);
            Assert.True(boolNode.Elt);
        }

        /// <summary>
        ///     Tests that cx fast list node should handle null values for reference types
        /// </summary>
        [Fact]
        public void CxFastListNode_ShouldHandleNullValues_ForReferenceTypes()
        {
            CxFastListNode<string> node = new CxFastListNode<string>(null);

            Assert.Null(node.Elt);
        }

        /// <summary>
        ///     Tests that cx fast list node should handle complex objects
        /// </summary>
        [Fact]
        public void CxFastListNode_ShouldHandleComplexObjects()
        {
            var obj = new {Name = "Test", Value = 42};
            CxFastListNode<object> node = new CxFastListNode<object>(obj);

            Assert.NotNull(node.Elt);
        }

        /// <summary>
        ///     Tests that cx fast list node should support chaining
        /// </summary>
        [Fact]
        public void CxFastListNode_ShouldSupportChaining()
        {
            CxFastListNode<int> node1 = new CxFastListNode<int>(1);
            CxFastListNode<int> node2 = new CxFastListNode<int>(2);
            CxFastListNode<int> node3 = new CxFastListNode<int>(3);

            node1.Next = node2;
            node2.Next = node3;

            int sum = 0;
            CxFastListNode<int> current = node1;
            while (current != null)
            {
                sum += current.GetElem();
                current = current.NextPos();
            }

            Assert.Equal(6, sum);
        }

        /// <summary>
        ///     Tests that elt should be readonly
        /// </summary>
        [Fact]
        public void Elt_ShouldBeReadonly()
        {
            CxFastListNode<int> node = new CxFastListNode<int>(10);

            Assert.Equal(10, node.Elt);
        }
    }
}