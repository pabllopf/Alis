using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    public class TreeNodeTest
    {
        [Fact]
        public void Next_ShouldMapToParentStorage()
        {
            TreeNode<int> node = new TreeNode<int>();

            node.Next = 42;

            Assert.Equal(42, node.Next);
            Assert.Equal(42, node.Parent);
        }

        [Fact]
        public void IsLeaf_ShouldReturnTrue_WhenChild1IsNullNode()
        {
            TreeNode<int> node = new TreeNode<int>();
            node.Child1 = DynamicTree<int>.NullNode;

            Assert.True(node.IsLeaf());
        }

        [Fact]
        public void IsLeaf_ShouldReturnFalse_WhenChild1IsValid()
        {
            TreeNode<int> node = new TreeNode<int>();
            node.Child1 = 0;

            Assert.False(node.IsLeaf());
        }
    }
}

