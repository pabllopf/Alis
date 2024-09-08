using Alis.Core.Physic.Dynamics.Contacts;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    /// The on separation event handler
    /// </summary>
    public delegate void OnSeparationEventHandler(Fixture sender, Fixture other, Contact contact);
}