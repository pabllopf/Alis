

namespace Alis.Core.Physic.Dynamics
{
/// <summary>
///     Represents a method that handles fixture-related events in the physics simulation.
///     This delegate is used for callbacks when fixture-related events occur,
///     such as before/after collision events or other fixture-specific interactions.
///     The delegate receives the physics world, the body that owns the fixture,
///     and the fixture itself as parameters.
/// </summary>
    public delegate void FixtureDelegate(WorldPhysic sender, Body body, Fixture fixture);
}