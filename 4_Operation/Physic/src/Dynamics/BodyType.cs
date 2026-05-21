

namespace Alis.Core.Physic.Dynamics
{
/// <summary>
///     Defines the type of a physics body, which determines how it behaves in the simulation.
///     The body type affects how the body responds to forces, collisions, and user input.
///     There are three types: Static (fixed position), Kinematic (user-controlled motion),
///     and Dynamic (fully simulated physics).
/// </summary>
    public enum BodyType
    {
        /// <summary>
        ///     Zero velocity, may be manually moved. Note: even static bodies have mass.
        /// </summary>
        Static,

        /// <summary>
        ///     Zero mass, non-zero velocity set by user, moved by solver
        /// </summary>
        Kinematic,

        /// <summary>
        ///     Positive mass, non-zero velocity determined by forces, moved by solver
        /// </summary>
        Dynamic
    }
}