using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
    /// The jacobian
    /// </summary>
    public struct Jacobian
    {
        /// <summary>
        /// The linear
        /// </summary>
        public Vec2 Linear1;
        /// <summary>
        /// The angular
        /// </summary>
        public float Angular1;
        /// <summary>
        /// The linear
        /// </summary>
        public Vec2 Linear2;
        /// <summary>
        /// The angular
        /// </summary>
        public float Angular2;

        /// <summary>
        /// Sets the zero
        /// </summary>
        public void SetZero()
        {
            Linear1.SetZero(); Angular1 = 0.0f;
            Linear2.SetZero(); Angular2 = 0.0f;
        }

        /// <summary>
        /// Sets the x 1
        /// </summary>
        /// <param name="x1">The </param>
        /// <param name="a1">The </param>
        /// <param name="x2">The </param>
        /// <param name="a2">The </param>
        public void Set(Vec2 x1, float a1, Vec2 x2, float a2)
        {
            Linear1 = x1; Angular1 = a1;
            Linear2 = x2; Angular2 = a2;
        }

        /// <summary>
        /// Computes the x 1
        /// </summary>
        /// <param name="x1">The </param>
        /// <param name="a1">The </param>
        /// <param name="x2">The </param>
        /// <param name="a2">The </param>
        /// <returns>The float</returns>
        public float Compute(Vec2 x1, float a1, Vec2 x2, float a2)
        {
            return Vec2.Dot(Linear1, x1) + Angular1 * a1 + Vec2.Dot(Linear2, x2) + Angular2 * a2;
        }
    }
}