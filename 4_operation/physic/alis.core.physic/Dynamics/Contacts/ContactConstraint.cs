using Alis.Core.Physic.Collision;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Contacts
{
    /// <summary>
    /// The contact constraint class
    /// </summary>
    public class ContactConstraint
    {
        /// <summary>
        /// The max manifold points
        /// </summary>
        public ContactConstraintPoint[] Points = new ContactConstraintPoint[Settings.MaxManifoldPoints];
        /// <summary>
        /// The local plane normal
        /// </summary>
        public Vec2 LocalPlaneNormal;
        /// <summary>
        /// The local point
        /// </summary>
        public Vec2 LocalPoint;
        /// <summary>
        /// The normal
        /// </summary>
        public Vec2 Normal;
        /// <summary>
        /// The normal mass
        /// </summary>
        public Mat22 NormalMass;
        /// <summary>
        /// The 
        /// </summary>
        public Mat22 K;
        /// <summary>
        /// The body
        /// </summary>
        public Body BodyA;
        /// <summary>
        /// The body
        /// </summary>
        public Body BodyB;
        /// <summary>
        /// The type
        /// </summary>
        public ManifoldType Type;
        /// <summary>
        /// The radius
        /// </summary>
        public float Radius;
        /// <summary>
        /// The friction
        /// </summary>
        public float Friction;
        /// <summary>
        /// The restitution
        /// </summary>
        public float Restitution;
        /// <summary>
        /// The point count
        /// </summary>
        public int PointCount;
        /// <summary>
        /// The manifold
        /// </summary>
        public Manifold Manifold;

        //public ContactConstraint()
        //{
        //	for (int i = 0; i < Settings.MaxManifoldPoints; i++)
        //		Points[i] = new ContactConstraintPoint();
        //}
    }
}