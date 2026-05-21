

using Alis.Core.Aspect.Fluent;
using Alis.Core.Ecs.Components.Collider;

namespace Alis.Builder.Core.Ecs.Components.Collider
{
    /// <summary>
    ///     The circle collider builder class
    /// </summary>
    public class CircleColliderBuilder :
        IBuild<CircleCollider>
    {
        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The circle collider</returns>
        public CircleCollider Build() => new CircleCollider();
    }
}