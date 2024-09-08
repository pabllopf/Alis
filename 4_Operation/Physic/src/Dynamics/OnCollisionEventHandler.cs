using Alis.Core.Physic.Dynamics.Contacts;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    /// The on collision event handler
    /// </summary>
    public delegate bool OnCollisionEventHandler(Fixture sender, Fixture other, Contact contact);
}