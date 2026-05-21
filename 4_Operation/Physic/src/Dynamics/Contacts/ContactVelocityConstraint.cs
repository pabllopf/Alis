

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Contacts
{
    /// <summary>
    ///     The contact velocity constraint class
    /// </summary>
    public sealed class ContactVelocityConstraint
    {
        /// <summary>
        ///     The max manifold points
        /// </summary>
        public readonly VelocityConstraintPoint[] Points = new VelocityConstraintPoint[SettingEnv.MaxManifoldPoints];

        /// <summary>
        ///     The contact index
        /// </summary>
        public int ContactIndex;

        /// <summary>
        ///     The friction
        /// </summary>
        public float Friction;

        /// <summary>
        ///     The index
        /// </summary>
        public int IndexA;

        /// <summary>
        ///     The index
        /// </summary>
        public int IndexB;

        /// <summary>
        ///     The inv ib
        /// </summary>
        public float InvIa, InvIb;

        /// <summary>
        ///     The inv mass
        /// </summary>
        public float InvMassA, InvMassB;

        /// <summary>
        ///     The
        /// </summary>
        public Mat22 K;

        /// <summary>
        ///     The normal
        /// </summary>
        public Vector2F Normal;

        /// <summary>
        ///     The normal mass
        /// </summary>
        public Mat22 NormalMass;

        /// <summary>
        ///     The point count
        /// </summary>
        public int PointCount;

        /// <summary>
        ///     The restitution
        /// </summary>
        public float Restitution;

        /// <summary>
        ///     The tangent speed
        /// </summary>
        public float TangentSpeed;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ContactVelocityConstraint" /> class
        /// </summary>
        public ContactVelocityConstraint()
        {
            for (int i = 0; i < SettingEnv.MaxManifoldPoints; i++)
            {
                Points[i] = new VelocityConstraintPoint();
            }
        }
    }
}