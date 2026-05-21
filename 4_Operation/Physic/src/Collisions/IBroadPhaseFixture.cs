

using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Defines the contract for a broad-phase collision detection system that manages <see cref="FixtureProxy"/> pairs.
    /// </summary>
    /// <seealso cref="IBroadPhaseFixtureNode{TNode}" />
    public interface IBroadPhaseFixture : IBroadPhaseFixtureNode<FixtureProxy>
    {
    }
}