

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;

namespace Alis.Core.Physic.Dynamics.Contacts
{
    /// <summary>
    ///     The contact position constraint class
    /// </summary>
    public sealed class ContactPositionConstraint
    {
        /// <summary>
        ///     The max manifold points
        /// </summary>
        public readonly Vector2F[] LocalPoints = new Vector2F[SettingEnv.MaxManifoldPoints];

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
        ///     The local center
        /// </summary>
        public Vector2F LocalCenterA, LocalCenterB;

        /// <summary>
        ///     The local normal
        /// </summary>
        public Vector2F LocalNormal;

        /// <summary>
        ///     The local point
        /// </summary>
        public Vector2F LocalPoint;

        /// <summary>
        ///     The point count
        /// </summary>
        public int PointCount;

        /// <summary>
        ///     The radius
        /// </summary>
        public float RadiusA, RadiusB;

        /// <summary>
        ///     The type
        /// </summary>
        public ManifoldType Type;
    }
}