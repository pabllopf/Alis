

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Represents the geometric features that intersect to form a contact point between two colliding shapes.
    ///     This struct must be 4 bytes or less to ensure efficient storage in contact manifolds.
    ///     Used to uniquely identify contact points for warm starting in iterative solvers.
    /// </summary>
    /// <remarks>
    ///     The features describe which edges, vertices, or faces of each shape are involved in the collision.
    ///     Index refers to the vertex/edge identifier, while Type indicates whether it's a vertex (0) or edge (1).
    /// </remarks>
    public struct ContactFeature
    {
        /// <summary>
        ///     Gets or sets the feature index (vertex/edge identifier) on ShapeA.
        /// </summary>
        /// <value>The zero-based index of the contacting feature on the first shape.</value>
        public byte IndexA;

        /// <summary>
        ///     Gets or sets the feature index (vertex/edge identifier) on ShapeB.
        /// </summary>
        /// <value>The zero-based index of the contacting feature on the second shape.</value>
        public byte IndexB;

        /// <summary>
        ///     Gets or sets the feature type on ShapeA (0 = vertex, 1 = edge).
        /// </summary>
        /// <value>The type of feature: 0 for vertex contact, 1 for edge contact.</value>
        public byte TypeA;

        /// <summary>
        ///     Gets or sets the feature type on ShapeB (0 = vertex, 1 = edge).
        /// </summary>
        /// <value>The type of feature: 0 for vertex contact, 1 for edge contact.</value>
        public byte TypeB;
    }
}