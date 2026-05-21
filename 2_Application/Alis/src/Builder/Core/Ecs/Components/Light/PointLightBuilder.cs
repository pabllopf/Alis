

using Alis.Core.Aspect.Fluent;
using Alis.Core.Ecs.Components.Light;

namespace Alis.Builder.Core.Ecs.Components.Light
{
    /// <summary>
    ///     The point light builder class
    /// </summary>
    public class PointLightBuilder :
        IBuild<PointLight>
    {
        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The point light</returns>
        public PointLight Build() => new PointLight();
    }
}