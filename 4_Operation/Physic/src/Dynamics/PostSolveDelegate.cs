using Alis.Core.Physic.Dynamics.Contacts;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    /// The post solve delegate
    /// </summary>
    public delegate void PostSolveDelegate(Contact contact, ContactVelocityConstraint impulse);
}