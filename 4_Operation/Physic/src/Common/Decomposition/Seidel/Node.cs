

using System.Collections.Generic;

namespace Alis.Core.Physic.Common.Decomposition.Seidel
{
    /// <summary>
    ///     The node class
    /// </summary>
    internal abstract class Node
    {
        /// <summary>
        ///     The parent list
        /// </summary>
        public readonly List<Node> ParentList;

        /// <summary>
        ///     The left child
        /// </summary>
        protected Node LeftChild;

        /// <summary>
        ///     The right child
        /// </summary>
        protected Node RightChild;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Node" /> class
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        protected Node(Node left, Node right)
        {
            ParentList = new List<Node>();
            LeftChild = left;
            RightChild = right;

            if (left != null)
            {
                left.ParentList.Add(this);
            }

            if (right != null)
            {
                right.ParentList.Add(this);
            }
        }

        /// <summary>
        ///     Locates the s
        /// </summary>
        /// <param name="s">The </param>
        /// <returns>The sink</returns>
        public abstract Sink Locate(Edge s);

        /// <summary>
        ///     Replaces the node
        /// </summary>
        /// <param name="node">The node</param>
        public void Replace(Node node)
        {
            foreach (Node parent in node.ParentList)
            {
                if (parent.LeftChild == node)
                {
                    parent.LeftChild = this;
                }
                else
                {
                    parent.RightChild = this;
                }
            }

            ParentList.AddRange(node.ParentList);
        }
    }
}