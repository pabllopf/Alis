

using Alis.Core.Ecs.Components.Collider;

namespace Alis.Builder.Core.Ecs.Components.Collider
{
    /// <summary>
    ///     The box collider config
    /// </summary>
    public delegate void BoxColliderConfig<T>(BoxColliderBuilder builder) where T : IBoxCollider;
}