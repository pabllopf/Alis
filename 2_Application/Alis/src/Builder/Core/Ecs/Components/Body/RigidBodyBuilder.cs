

using Alis.Core.Aspect.Fluent;
using Alis.Core.Ecs.Components.Body;

namespace Alis.Builder.Core.Ecs.Components.Body
{
    /// <summary>
    ///     The rigid body builder class
    /// </summary>
    public class RigidBodyBuilder :
        IBuild<RigidBody>
    {
        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The rigid body</returns>
        public RigidBody Build() => new RigidBody();
    }
}