using Alis.Core.Physic.Collision;
using Alis.Core.Physic.Dynamics.Contacts;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    /// The pre solve delegate
    /// </summary>
    public delegate void PreSolveDelegate(Contact contact, ref Manifold oldManifold);
}