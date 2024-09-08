namespace Alis.Core.Physic.Collision
{
    /// <summary>
    ///     A node in the dynamic tree. The client does not interact with this directly.
    /// </summary>
    internal struct TreeNode<TNode>
    {
        /// <summary>
        ///     Enlarged AABB
        /// </summary>
        internal AABB AABB;

        /// <summary>
        /// The child
        /// </summary>
        internal int Child1;
        /// <summary>
        /// The child
        /// </summary>
        internal int Child2;

        // leaf = 0, free node = -1
        /// <summary>
        /// The height
        /// </summary>
        internal int Height;
        /// <summary>
        /// The parent
        /// </summary>
        internal int Parent;

        // to reduce struct size we use Parent for the Free linked-list
        /// <summary>
        ///     Next free node
        /// </summary>
        internal int Next
        {
            get => Parent;
            set => Parent = value;
        }

        /// <summary>
        /// The user data
        /// </summary>
        internal TNode UserData;


        /// <summary>
        /// Describes whether this instance is leaf
        /// </summary>
        /// <returns>The bool</returns>
        internal bool IsLeaf() => Child1 == DynamicTree<TNode>.NullNode;
    }
}