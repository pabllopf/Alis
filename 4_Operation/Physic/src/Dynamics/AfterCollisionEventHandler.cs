using Alis.Core.Physic.Dynamics.Contacts;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    /// The after collision event handler
    /// </summary>
    public delegate void AfterCollisionEventHandler(Fixture sender, Fixture other, Contact contact, ContactVelocityConstraint impulse);
}