using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics
{
    /// Contact impulses for reporting. Impulses are used instead of forces because
    /// sub-step forces may approach infinity for rigid body collisions. These
    /// match up one-to-one with the contact points in b2Manifold.
    public class ContactImpulse
    {
        /// <summary>
        /// The max manifold points
        /// </summary>
        public float[] NormalImpulses = new float[Settings.MaxManifoldPoints];
        /// <summary>
        /// The max manifold points
        /// </summary>
        public float[] TangentImpulses = new float[Settings.MaxManifoldPoints];
    }
}