using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision;

namespace Alis.Core.Physic.Dynamics.Contacts
{
    /// <summary>
    /// The contact position constraint class
    /// </summary>
    public sealed class ContactPositionConstraint
    {
        /// <summary>
        /// The index
        /// </summary>
        public int indexA;
        /// <summary>
        /// The index
        /// </summary>
        public int indexB;
        /// <summary>
        /// The inv ib
        /// </summary>
        public float invIA, invIB;
        /// <summary>
        /// The inv mass
        /// </summary>
        public float invMassA, invMassB;
        /// <summary>
        /// The local center
        /// </summary>
        public Vector2 localCenterA, localCenterB;
        /// <summary>
        /// The local normal
        /// </summary>
        public Vector2 localNormal;
        /// <summary>
        /// The local point
        /// </summary>
        public Vector2 localPoint;
        /// <summary>
        /// The max manifold points
        /// </summary>
        public Vector2[] localPoints = new Vector2[Settings.MaxManifoldPoints];
        /// <summary>
        /// The point count
        /// </summary>
        public int pointCount;
        /// <summary>
        /// The radius
        /// </summary>
        public float radiusA, radiusB;
        /// <summary>
        /// The type
        /// </summary>
        public ManifoldType type;
    }
}