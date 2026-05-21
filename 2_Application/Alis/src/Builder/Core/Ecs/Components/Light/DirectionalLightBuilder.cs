

using Alis.Core.Aspect.Fluent;
using Alis.Core.Ecs.Components.Light;

namespace Alis.Builder.Core.Ecs.Components.Light
{
    /// <summary>
    ///     The directional light builder class
    /// </summary>
    public class DirectionalLightBuilder :
        IBuild<DirectionalLight>
    {
        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The directional light builder</returns>
        public DirectionalLight Build() => new DirectionalLight();
    }
}