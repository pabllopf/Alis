

namespace Alis.Core.Physic.Controllers
{
/// <summary>
///     Specifies the type of gravity calculation to be used by controllers.
///     This enumeration defines different gravity models that can be applied
///     to simulate various gravitational behaviors in the physics simulation.
/// </summary>
    public enum GravityType
    {
        /// <summary>
        ///     Linear gravity falloff: force is proportional to 1/r.
        ///     Produces a more uniform gravitational field over distance.
        /// </summary>
        Linear,

        /// <summary>
        ///     Distance-squared gravity falloff: force is proportional to 1/r².
        ///     Follows Newton's law of universal gravitation for realistic planetary gravity simulation.
        /// </summary>
        DistanceSquared
    }
}