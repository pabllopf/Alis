namespace Alis.Core.Physic.Collision
{
    /// <summary>
    /// The broad phase ray cast callback
    /// </summary>
    public delegate float BroadPhaseRayCastCallback(ref RayCastInput input, int proxyId);
}