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
        /// Tests that next should map to parent storage
        /// </summary>
        [Fact]
        public void Next_ShouldMapToParentStorage()
        {
            TreeNode<int> node = new TreeNode<int>();

            node.Next = 42;

            Assert.Equal(42, node.Next);
            Assert.Equal(42, node.Parent);
        }

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

